// Decompiled with JetBrains decompiler
// Type: Terraria.Net.LegacyNetBufferPool
// Assembly: TerrariaServer, Version=1.3.5.1, Culture=neutral, PublicKeyToken=null
// MVID: 5CBA2320-074B-43F7-8CDC-BF1E2B81EE4B
// Assembly location: C:\Users\kevzhao\Downloads\TerrariaServer.exe

using System;
using System.Collections.Generic;
using System.Threading;

namespace Terraria.Net
{
  public class LegacyNetBufferPool
  {
    private static object bufferLock = new object();
    private static Queue<byte[]> _smallBufferQueue = new Queue<byte[]>();
    private static Queue<byte[]> _mediumBufferQueue = new Queue<byte[]>();
    private static Queue<byte[]> _largeBufferQueue = new Queue<byte[]>();
    private static int _smallBufferCount = 0;
    private static int _mediumBufferCount = 0;
    private static int _largeBufferCount = 0;
    private static int _customBufferCount = 0;
    private const int SMALL_BUFFER_SIZE = 256;
    private const int MEDIUM_BUFFER_SIZE = 1024;
    private const int LARGE_BUFFER_SIZE = 16384;

    public static byte[] RequestBuffer(int size)
    {
      bool flag = false;
      object bufferLock;
      try
      {
        Monitor.Enter(bufferLock = LegacyNetBufferPool.bufferLock, ref flag);
        if (size <= 256)
        {
          if (LegacyNetBufferPool._smallBufferQueue.Count != 0)
            return LegacyNetBufferPool._smallBufferQueue.Dequeue();
          ++LegacyNetBufferPool._smallBufferCount;
          return new byte[256];
        }
        if (size <= 1024)
        {
          if (LegacyNetBufferPool._mediumBufferQueue.Count != 0)
            return LegacyNetBufferPool._mediumBufferQueue.Dequeue();
          ++LegacyNetBufferPool._mediumBufferCount;
          return new byte[1024];
        }
        if (size <= 16384)
        {
          if (LegacyNetBufferPool._largeBufferQueue.Count != 0)
            return LegacyNetBufferPool._largeBufferQueue.Dequeue();
          ++LegacyNetBufferPool._largeBufferCount;
          return new byte[16384];
        }
        ++LegacyNetBufferPool._customBufferCount;
        return new byte[size];
      }
      finally
      {
        if (flag)
          Monitor.Exit(bufferLock);
      }
    }

    public static byte[] RequestBuffer(byte[] data, int offset, int size)
    {
      byte[] numArray = LegacyNetBufferPool.RequestBuffer(size);
      Buffer.BlockCopy((Array) data, offset, (Array) numArray, 0, size);
      return numArray;
    }

    public static void ReturnBuffer(byte[] buffer)
    {
      int length = buffer.Length;
      bool flag = false;
      object bufferLock;
      try
      {
        Monitor.Enter(bufferLock = LegacyNetBufferPool.bufferLock, ref flag);
        if (length <= 256)
          LegacyNetBufferPool._smallBufferQueue.Enqueue(buffer);
        else if (length <= 1024)
        {
          LegacyNetBufferPool._mediumBufferQueue.Enqueue(buffer);
        }
        else
        {
          if (length > 16384)
            return;
          LegacyNetBufferPool._largeBufferQueue.Enqueue(buffer);
        }
      }
      finally
      {
        if (flag)
          Monitor.Exit(bufferLock);
      }
    }

    public static void DisplayBufferSizes()
    {
      bool flag = false;
      object bufferLock;
      try
      {
        Monitor.Enter(bufferLock = LegacyNetBufferPool.bufferLock, ref flag);
        Main.NewText("Small Buffers:  " + (object) LegacyNetBufferPool._smallBufferQueue.Count + " queued of " + (object) LegacyNetBufferPool._smallBufferCount, byte.MaxValue, byte.MaxValue, byte.MaxValue, false);
        Main.NewText("Medium Buffers: " + (object) LegacyNetBufferPool._mediumBufferQueue.Count + " queued of " + (object) LegacyNetBufferPool._mediumBufferCount, byte.MaxValue, byte.MaxValue, byte.MaxValue, false);
        Main.NewText("Large Buffers:  " + (object) LegacyNetBufferPool._largeBufferQueue.Count + " queued of " + (object) LegacyNetBufferPool._largeBufferCount, byte.MaxValue, byte.MaxValue, byte.MaxValue, false);
        Main.NewText("Custom Buffers: 0 queued of " + (object) LegacyNetBufferPool._customBufferCount, byte.MaxValue, byte.MaxValue, byte.MaxValue, false);
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
        Monitor.Enter(bufferLock = LegacyNetBufferPool.bufferLock, ref flag);
        Console.WriteLine("Small Buffers:  " + (object) LegacyNetBufferPool._smallBufferQueue.Count + " queued of " + (object) LegacyNetBufferPool._smallBufferCount);
        Console.WriteLine("Medium Buffers: " + (object) LegacyNetBufferPool._mediumBufferQueue.Count + " queued of " + (object) LegacyNetBufferPool._mediumBufferCount);
        Console.WriteLine("Large Buffers:  " + (object) LegacyNetBufferPool._largeBufferQueue.Count + " queued of " + (object) LegacyNetBufferPool._largeBufferCount);
        Console.WriteLine("Custom Buffers: 0 queued of " + (object) LegacyNetBufferPool._customBufferCount);
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
