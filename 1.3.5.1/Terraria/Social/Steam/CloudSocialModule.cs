// Decompiled with JetBrains decompiler
// Type: Terraria.Social.Steam.CloudSocialModule
// Assembly: TerrariaServer, Version=1.3.5.1, Culture=neutral, PublicKeyToken=null
// MVID: 5CBA2320-074B-43F7-8CDC-BF1E2B81EE4B
// Assembly location: C:\Users\kevzhao\Downloads\TerrariaServer.exe

using Steamworks;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Terraria.Social.Steam
{
  public class CloudSocialModule : Terraria.Social.Base.CloudSocialModule
  {
    private object ioLock = new object();
    private byte[] writeBuffer = new byte[new IntPtr(1024)];
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
      bool flag = false;
      object ioLock;
      try
      {
        Monitor.Enter(ioLock = this.ioLock, ref flag);
        int fileCount = SteamRemoteStorage.GetFileCount();
        List<string> stringList = new List<string>(fileCount);
        for (int index = 0; index < fileCount; ++index)
        {
          int num;
          stringList.Add(SteamRemoteStorage.GetFileNameAndSize(index, ref num));
        }
        return (IEnumerable<string>) stringList;
      }
      finally
      {
        if (flag)
          Monitor.Exit(ioLock);
      }
    }

    public override bool Write(string path, byte[] data, int length)
    {
      bool flag = false;
      object ioLock;
      try
      {
        Monitor.Enter(ioLock = this.ioLock, ref flag);
        UGCFileWriteStreamHandle_t writeStreamHandleT = SteamRemoteStorage.FileWriteStreamOpen(path);
        uint num1 = 0;
        while ((long) num1 < (long) length)
        {
          int num2 = (int) Math.Min(1024L, (long) length - (long) num1);
          Array.Copy((Array) data, (long) num1, (Array) this.writeBuffer, 0L, (long) num2);
          SteamRemoteStorage.FileWriteStreamWriteChunk(writeStreamHandleT, this.writeBuffer, num2);
          num1 += 1024U;
        }
        return SteamRemoteStorage.FileWriteStreamClose(writeStreamHandleT);
      }
      finally
      {
        if (flag)
          Monitor.Exit(ioLock);
      }
    }

    public override int GetFileSize(string path)
    {
      bool flag = false;
      object ioLock;
      try
      {
        Monitor.Enter(ioLock = this.ioLock, ref flag);
        return SteamRemoteStorage.GetFileSize(path);
      }
      finally
      {
        if (flag)
          Monitor.Exit(ioLock);
      }
    }

    public override void Read(string path, byte[] buffer, int size)
    {
      bool flag = false;
      object ioLock;
      try
      {
        Monitor.Enter(ioLock = this.ioLock, ref flag);
        SteamRemoteStorage.FileRead(path, buffer, size);
      }
      finally
      {
        if (flag)
          Monitor.Exit(ioLock);
      }
    }

    public override bool HasFile(string path)
    {
      bool flag = false;
      object ioLock;
      try
      {
        Monitor.Enter(ioLock = this.ioLock, ref flag);
        return SteamRemoteStorage.FileExists(path);
      }
      finally
      {
        if (flag)
          Monitor.Exit(ioLock);
      }
    }

    public override bool Delete(string path)
    {
      bool flag = false;
      object ioLock;
      try
      {
        Monitor.Enter(ioLock = this.ioLock, ref flag);
        return SteamRemoteStorage.FileDelete(path);
      }
      finally
      {
        if (flag)
          Monitor.Exit(ioLock);
      }
    }
  }
}
