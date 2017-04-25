// Decompiled with JetBrains decompiler
// Type: Terraria.Social.Steam.SteamP2PReader
// Assembly: TerrariaServer, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: AA3606A2-F3DB-4481-937B-7295FB97CD3E
// Assembly location: E:\TSHOCK\TerrariaServer.exe

using Steamworks;
using System;
using System.Collections.Generic;

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
      lock (this._pendingReadBuffers)
        this._deletionQueue.Enqueue(id);
    }

    public bool IsDataAvailable(CSteamID id)
    {
      lock (this._pendingReadBuffers)
      {
        if (!this._pendingReadBuffers.ContainsKey(id))
          return false;
        Queue<SteamP2PReader.ReadResult> local_2 = this._pendingReadBuffers[id];
        return local_2.Count != 0 && (int) local_2.Peek().Size != 0;
      }
    }

    public void SetReadEvent(SteamP2PReader.OnReadEvent method)
    {
      this._readEvent = method;
    }

    private bool IsPacketAvailable(out uint size)
    {
      lock (this.SteamLock)
        return SteamNetworking.IsP2PPacketAvailable(ref size, this._channel);
    }

    public void ReadTick()
    {
      lock (this._pendingReadBuffers)
      {
        while (this._deletionQueue.Count > 0)
          this._pendingReadBuffers.Remove(this._deletionQueue.Dequeue());
        uint local_2;
        while (this.IsPacketAvailable(out local_2))
        {
          byte[] local_3 = this._bufferPool.Count != 0 ? this._bufferPool.Dequeue() : new byte[(int) Math.Max(local_2, 4096U)];
          uint local_5;
          CSteamID local_4;
          bool local_6;
          lock (this.SteamLock)
            local_6 = SteamNetworking.ReadP2PPacket(local_3, (uint) local_3.Length, ref local_5, ref local_4, this._channel);
          if (local_6)
          {
            if (this._readEvent == null || this._readEvent(local_3, (int) local_5, local_4))
            {
              if (!this._pendingReadBuffers.ContainsKey(local_4))
                this._pendingReadBuffers[local_4] = new Queue<SteamP2PReader.ReadResult>();
              this._pendingReadBuffers[local_4].Enqueue(new SteamP2PReader.ReadResult(local_3, local_5));
            }
            else
              this._bufferPool.Enqueue(local_3);
          }
        }
      }
    }

    public int Receive(CSteamID user, byte[] buffer, int bufferOffset, int bufferSize)
    {
      uint num = 0;
      lock (this._pendingReadBuffers)
      {
        if (!this._pendingReadBuffers.ContainsKey(user))
          return 0;
        Queue<SteamP2PReader.ReadResult> local_3 = this._pendingReadBuffers[user];
        while (local_3.Count > 0)
        {
          SteamP2PReader.ReadResult local_5 = local_3.Peek();
          uint local_6 = Math.Min((uint) bufferSize - num, local_5.Size - local_5.Offset);
          if ((int) local_6 == 0)
            return (int) num;
          Array.Copy((Array) local_5.Data, (long) local_5.Offset, (Array) buffer, (long) bufferOffset + (long) num, (long) local_6);
          if ((int) local_6 == (int) local_5.Size - (int) local_5.Offset)
            this._bufferPool.Enqueue(local_3.Dequeue().Data);
          else
            local_5.Offset += local_6;
          num += local_6;
        }
      }
      return (int) num;
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
