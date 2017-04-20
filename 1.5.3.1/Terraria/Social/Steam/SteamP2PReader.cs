// Decompiled with JetBrains decompiler
// Type: Terraria.Social.Steam.SteamP2PReader
// Assembly: TerrariaServer, Version=1.3.5.1, Culture=neutral, PublicKeyToken=null
// MVID: 5CBA2320-074B-43F7-8CDC-BF1E2B81EE4B
// Assembly location: C:\Users\kevzhao\Downloads\TerrariaServer.exe

using Steamworks;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Terraria.Social.Steam
{
  public class SteamP2PReader
  {
    public object SteamLock = new object();
    private Dictionary<CSteamID, Queue<SteamP2PReader.ReadResult>> _pendingReadBuffers = new Dictionary<CSteamID, Queue<SteamP2PReader.ReadResult>>();
    private Queue<CSteamID> _deletionQueue = new Queue<CSteamID>();
    private Queue<byte[]> _bufferPool = new Queue<byte[]>();
    private const int BUFFER_SIZE = 4096;
    private int _channel;
    private SteamP2PReader.OnReadEvent _readEvent;

    public SteamP2PReader(int channel)
    {
      this._channel = channel;
    }

    public void ClearUser(CSteamID id)
    {
      bool flag = false;
      Dictionary<CSteamID, Queue<SteamP2PReader.ReadResult>> pendingReadBuffers;
      try
      {
        Monitor.Enter((object) (pendingReadBuffers = this._pendingReadBuffers), ref flag);
        this._deletionQueue.Enqueue(id);
      }
      finally
      {
        if (flag)
          Monitor.Exit((object) pendingReadBuffers);
      }
    }

    public bool IsDataAvailable(CSteamID id)
    {
      bool flag = false;
      Dictionary<CSteamID, Queue<SteamP2PReader.ReadResult>> pendingReadBuffers;
      try
      {
        Monitor.Enter((object) (pendingReadBuffers = this._pendingReadBuffers), ref flag);
        if (!this._pendingReadBuffers.ContainsKey(id))
          return false;
        Queue<SteamP2PReader.ReadResult> pendingReadBuffer = this._pendingReadBuffers[id];
        return pendingReadBuffer.Count != 0 && (int) pendingReadBuffer.Peek().Size != 0;
      }
      finally
      {
        if (flag)
          Monitor.Exit((object) pendingReadBuffers);
      }
    }

    public void SetReadEvent(SteamP2PReader.OnReadEvent method)
    {
      this._readEvent = method;
    }

    private bool IsPacketAvailable(out uint size)
    {
      bool flag = false;
      object steamLock;
      try
      {
        Monitor.Enter(steamLock = this.SteamLock, ref flag);
        return SteamNetworking.IsP2PPacketAvailable(ref size, this._channel);
      }
      finally
      {
        if (flag)
          Monitor.Exit(steamLock);
      }
    }

    public void ReadTick()
    {
      bool flag1 = false;
      Dictionary<CSteamID, Queue<SteamP2PReader.ReadResult>> pendingReadBuffers;
      try
      {
        Monitor.Enter((object) (pendingReadBuffers = this._pendingReadBuffers), ref flag1);
        while (this._deletionQueue.Count > 0)
          this._pendingReadBuffers.Remove(this._deletionQueue.Dequeue());
        uint size1;
        while (this.IsPacketAvailable(out size1))
        {
          byte[] data = this._bufferPool.Count != 0 ? this._bufferPool.Dequeue() : new byte[(IntPtr) Math.Max(size1, 4096U)];
          bool flag2 = false;
          object steamLock;
          uint size2;
          CSteamID index;
          bool flag3;
          try
          {
            Monitor.Enter(steamLock = this.SteamLock, ref flag2);
            flag3 = SteamNetworking.ReadP2PPacket(data, (uint) data.Length, ref size2, ref index, this._channel);
          }
          finally
          {
            if (flag2)
              Monitor.Exit(steamLock);
          }
          if (flag3)
          {
            if (this._readEvent == null || this._readEvent(data, (int) size2, index))
            {
              if (!this._pendingReadBuffers.ContainsKey(index))
                this._pendingReadBuffers[index] = new Queue<SteamP2PReader.ReadResult>();
              this._pendingReadBuffers[index].Enqueue(new SteamP2PReader.ReadResult(data, size2));
            }
            else
              this._bufferPool.Enqueue(data);
          }
        }
      }
      finally
      {
        if (flag1)
          Monitor.Exit((object) pendingReadBuffers);
      }
    }

    public int Receive(CSteamID user, byte[] buffer, int bufferOffset, int bufferSize)
    {
      uint num1 = 0;
      bool flag = false;
      Dictionary<CSteamID, Queue<SteamP2PReader.ReadResult>> pendingReadBuffers;
      try
      {
        Monitor.Enter((object) (pendingReadBuffers = this._pendingReadBuffers), ref flag);
        if (!this._pendingReadBuffers.ContainsKey(user))
          return 0;
        Queue<SteamP2PReader.ReadResult> pendingReadBuffer = this._pendingReadBuffers[user];
        while (pendingReadBuffer.Count > 0)
        {
          SteamP2PReader.ReadResult readResult = pendingReadBuffer.Peek();
          uint num2 = Math.Min((uint) bufferSize - num1, readResult.Size - readResult.Offset);
          if ((int) num2 == 0)
            return (int) num1;
          Array.Copy((Array) readResult.Data, (long) readResult.Offset, (Array) buffer, (long) bufferOffset + (long) num1, (long) num2);
          if ((int) num2 == (int) readResult.Size - (int) readResult.Offset)
            this._bufferPool.Enqueue(pendingReadBuffer.Dequeue().Data);
          else
            readResult.Offset += num2;
          num1 += num2;
        }
      }
      finally
      {
        if (flag)
          Monitor.Exit((object) pendingReadBuffers);
      }
      return (int) num1;
    }

    public class ReadResult
    {
      public byte[] Data;
      public uint Size;
      public uint Offset;

      public ReadResult(byte[] data, uint size)
      {
        this.Data = data;
        this.Size = size;
        this.Offset = 0U;
      }
    }

    public delegate bool OnReadEvent(byte[] data, int size, CSteamID user);
  }
}
