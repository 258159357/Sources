// Decompiled with JetBrains decompiler
// Type: Terraria.DataStructures.BufferPool
// Assembly: TerrariaServer, Version=1.3.5.1, Culture=neutral, PublicKeyToken=null
// MVID: 5CBA2320-074B-43F7-8CDC-BF1E2B81EE4B
// Assembly location: C:\Users\kevzhao\Downloads\TerrariaServer.exe

using System;
using System.Collections.Generic;
using System.Threading;

namespace Terraria.DataStructures
{
  public static class BufferPool
  {
    private static object bufferLock = new object();
    private static Queue<CachedBuffer> SmallBufferQueue = new Queue<CachedBuffer>();
    private static Queue<CachedBuffer> MediumBufferQueue = new Queue<CachedBuffer>();
    private static Queue<CachedBuffer> LargeBufferQueue = new Queue<CachedBuffer>();
    private const int SMALL_BUFFER_SIZE = 32;
    private const int MEDIUM_BUFFER_SIZE = 256;
    private const int LARGE_BUFFER_SIZE = 16384;

    public static CachedBuffer Request(int size)
    {
      bool flag = false;
      object bufferLock;
      try
      {
        Monitor.Enter(bufferLock = BufferPool.bufferLock, ref flag);
        if (size <= 32)
        {
          if (BufferPool.SmallBufferQueue.Count == 0)
            return new CachedBuffer(new byte[32]);
          return BufferPool.SmallBufferQueue.Dequeue().Activate();
        }
        if (size <= 256)
        {
          if (BufferPool.MediumBufferQueue.Count == 0)
            return new CachedBuffer(new byte[256]);
          return BufferPool.MediumBufferQueue.Dequeue().Activate();
        }
        if (size > 16384)
          return new CachedBuffer(new byte[size]);
        if (BufferPool.LargeBufferQueue.Count == 0)
          return new CachedBuffer(new byte[16384]);
        return BufferPool.LargeBufferQueue.Dequeue().Activate();
      }
      finally
      {
        if (flag)
          Monitor.Exit(bufferLock);
      }
    }

    public static CachedBuffer Request(byte[] data, int offset, int size)
    {
      CachedBuffer cachedBuffer = BufferPool.Request(size);
      Buffer.BlockCopy((Array) data, offset, (Array) cachedBuffer.Data, 0, size);
      return cachedBuffer;
    }

    public static void Recycle(CachedBuffer buffer)
    {
      int length = buffer.Length;
      bool flag = false;
      object bufferLock;
      try
      {
        Monitor.Enter(bufferLock = BufferPool.bufferLock, ref flag);
        if (length <= 32)
          BufferPool.SmallBufferQueue.Enqueue(buffer);
        else if (length <= 256)
        {
          BufferPool.MediumBufferQueue.Enqueue(buffer);
        }
        else
        {
          if (length > 16384)
            return;
          BufferPool.LargeBufferQueue.Enqueue(buffer);
        }
      }
      finally
      {
        if (flag)
          Monitor.Exit(bufferLock);
      }
    }

    public static void PrintBufferSizes()
    {
      bool flag = false;
      object bufferLock;
      try
      {
        Monitor.Enter(bufferLock = BufferPool.bufferLock, ref flag);
        Console.WriteLine("SmallBufferQueue.Count: " + (object) BufferPool.SmallBufferQueue.Count);
        Console.WriteLine("MediumBufferQueue.Count: " + (object) BufferPool.MediumBufferQueue.Count);
        Console.WriteLine("LargeBufferQueue.Count: " + (object) BufferPool.LargeBufferQueue.Count);
        Console.WriteLine("");
      }
      finally
      {
        if (flag)
          Monitor.Exit(bufferLock);
      }
    }
  }
}
