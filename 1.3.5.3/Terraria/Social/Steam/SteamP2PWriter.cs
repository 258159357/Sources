﻿// Decompiled with JetBrains decompiler
// Type: Terraria.Social.Steam.SteamP2PWriter
// Assembly: TerrariaServer, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: AA3606A2-F3DB-4481-937B-7295FB97CD3E
// Assembly location: E:\TSHOCK\TerrariaServer.exe

using Steamworks;
using System;
using System.Collections.Generic;

namespace Terraria.Social.Steam
{
  public class SteamP2PWriter
  {
    private Dictionary<CSteamID, Queue<SteamP2PWriter.WriteInformation>> _pendingSendData = new Dictionary<CSteamID, Queue<SteamP2PWriter.WriteInformation>>();
    private Dictionary<CSteamID, Queue<SteamP2PWriter.WriteInformation>> _pendingSendDataSwap = new Dictionary<CSteamID, Queue<SteamP2PWriter.WriteInformation>>();
    private Queue<byte[]> _bufferPool = new Queue<byte[]>();
    private object _lock = new object();
    private const int BUFFER_SIZE = 1024;
    private int _channel;

    public SteamP2PWriter(int channel)
    {
      this._channel = channel;
    }

    public void QueueSend(CSteamID user, byte[] data, int length)
    {
      lock (this._lock)
      {
        Queue<SteamP2PWriter.WriteInformation> local_2;
        if (this._pendingSendData.ContainsKey(user))
          local_2 = this._pendingSendData[user];
        else
          this._pendingSendData[user] = local_2 = new Queue<SteamP2PWriter.WriteInformation>();
        int local_3 = length;
        int local_4 = 0;
        while (local_3 > 0)
        {
          SteamP2PWriter.WriteInformation local_5;
          if (local_2.Count == 0 || 1024 - local_2.Peek().Size == 0)
          {
            local_5 = this._bufferPool.Count <= 0 ? new SteamP2PWriter.WriteInformation() : new SteamP2PWriter.WriteInformation(this._bufferPool.Dequeue());
            local_2.Enqueue(local_5);
          }
          else
            local_5 = local_2.Peek();
          int local_6 = Math.Min(local_3, 1024 - local_5.Size);
          Array.Copy((Array) data, local_4, (Array) local_5.Data, local_5.Size, local_6);
          local_5.Size += local_6;
          local_3 -= local_6;
          local_4 += local_6;
        }
      }
    }

    public void ClearUser(CSteamID user)
    {
      lock (this._lock)
      {
        if (this._pendingSendData.ContainsKey(user))
        {
          Queue<SteamP2PWriter.WriteInformation> local_2 = this._pendingSendData[user];
          while (local_2.Count > 0)
            this._bufferPool.Enqueue(local_2.Dequeue().Data);
        }
        if (!this._pendingSendDataSwap.ContainsKey(user))
          return;
        Queue<SteamP2PWriter.WriteInformation> local_3 = this._pendingSendDataSwap[user];
        while (local_3.Count > 0)
          this._bufferPool.Enqueue(local_3.Dequeue().Data);
      }
    }

    public void SendAll()
    {
      lock (this._lock)
        Utils.Swap<Dictionary<CSteamID, Queue<SteamP2PWriter.WriteInformation>>>(ref this._pendingSendData, ref this._pendingSendDataSwap);
      using (Dictionary<CSteamID, Queue<SteamP2PWriter.WriteInformation>>.Enumerator enumerator = this._pendingSendDataSwap.GetEnumerator())
      {
        while (enumerator.MoveNext())
        {
          KeyValuePair<CSteamID, Queue<SteamP2PWriter.WriteInformation>> current = enumerator.Current;
          Queue<SteamP2PWriter.WriteInformation> writeInformationQueue = current.Value;
          while (writeInformationQueue.Count > 0)
          {
            SteamP2PWriter.WriteInformation writeInformation = writeInformationQueue.Dequeue();
            SteamNetworking.SendP2PPacket(current.Key, writeInformation.Data, (uint) writeInformation.Size, (EP2PSend) 2, this._channel);
            this._bufferPool.Enqueue(writeInformation.Data);
          }
        }
      }
    }

    public class WriteInformation
    {
      public byte[] Data;
      public int Size;

      public WriteInformation()
      {
        this.Data = new byte[1024];
        this.Size = 0;
      }

      public WriteInformation(byte[] data)
      {
        this.Data = data;
        this.Size = 0;
      }
    }
  }
}
