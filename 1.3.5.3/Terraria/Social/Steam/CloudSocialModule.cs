// Decompiled with JetBrains decompiler
// Type: Terraria.Social.Steam.CloudSocialModule
// Assembly: TerrariaServer, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: AA3606A2-F3DB-4481-937B-7295FB97CD3E
// Assembly location: E:\TSHOCK\TerrariaServer.exe

using Steamworks;
using System;
using System.Collections.Generic;

namespace Terraria.Social.Steam
{
  public class CloudSocialModule : Terraria.Social.Base.CloudSocialModule
  {
    private object ioLock = new object();
    private byte[] writeBuffer = new byte[1024];
    private const uint WRITE_CHUNK_SIZE = 1024;

    public override void Initialize()
    {
      base.Initialize();
    }

    public override void Shutdown()
    {
    }

    public override IEnumerable<string> GetFiles()
    {
      lock (this.ioLock)
      {
        int local_2 = SteamRemoteStorage.GetFileCount();
        List<string> local_3 = new List<string>(local_2);
        for (int local_5 = 0; local_5 < local_2; ++local_5)
        {
          int local_4;
          local_3.Add(SteamRemoteStorage.GetFileNameAndSize(local_5, ref local_4));
        }
        return (IEnumerable<string>) local_3;
      }
    }

    public override bool Write(string path, byte[] data, int length)
    {
      lock (this.ioLock)
      {
        UGCFileWriteStreamHandle_t local_2 = SteamRemoteStorage.FileWriteStreamOpen(path);
        uint local_3 = 0;
        while ((long) local_3 < (long) length)
        {
          int local_4 = (int) Math.Min(1024L, (long) length - (long) local_3);
          Array.Copy((Array) data, (long) local_3, (Array) this.writeBuffer, 0L, (long) local_4);
          SteamRemoteStorage.FileWriteStreamWriteChunk(local_2, this.writeBuffer, local_4);
          local_3 += 1024U;
        }
        return SteamRemoteStorage.FileWriteStreamClose(local_2);
      }
    }

    public override int GetFileSize(string path)
    {
      lock (this.ioLock)
        return SteamRemoteStorage.GetFileSize(path);
    }

    public override void Read(string path, byte[] buffer, int size)
    {
      lock (this.ioLock)
        SteamRemoteStorage.FileRead(path, buffer, size);
    }

    public override bool HasFile(string path)
    {
      lock (this.ioLock)
        return SteamRemoteStorage.FileExists(path);
    }

    public override bool Delete(string path)
    {
      lock (this.ioLock)
        return SteamRemoteStorage.FileDelete(path);
    }
  }
}
