﻿// Decompiled with JetBrains decompiler
// Type: Terraria.ID.SetFactory
// Assembly: TerrariaServer, Version=1.3.5.1, Culture=neutral, PublicKeyToken=null
// MVID: 5CBA2320-074B-43F7-8CDC-BF1E2B81EE4B
// Assembly location: C:\Users\kevzhao\Downloads\TerrariaServer.exe

using System;
using System.Collections.Generic;
using System.Threading;

namespace Terraria.ID
{
  public class SetFactory
  {
    private Queue<int[]> _intBufferCache = new Queue<int[]>();
    private Queue<ushort[]> _ushortBufferCache = new Queue<ushort[]>();
    private Queue<bool[]> _boolBufferCache = new Queue<bool[]>();
    private Queue<float[]> _floatBufferCache = new Queue<float[]>();
    private object _queueLock = new object();
    protected int _size;

    public SetFactory(int size)
    {
      this._size = size;
    }

    protected bool[] GetBoolBuffer()
    {
      bool flag = false;
      object queueLock;
      try
      {
        Monitor.Enter(queueLock = this._queueLock, ref flag);
        if (this._boolBufferCache.Count == 0)
          return new bool[this._size];
        return this._boolBufferCache.Dequeue();
      }
      finally
      {
        if (flag)
          Monitor.Exit(queueLock);
      }
    }

    protected int[] GetIntBuffer()
    {
      bool flag = false;
      object queueLock;
      try
      {
        Monitor.Enter(queueLock = this._queueLock, ref flag);
        if (this._intBufferCache.Count == 0)
          return new int[this._size];
        return this._intBufferCache.Dequeue();
      }
      finally
      {
        if (flag)
          Monitor.Exit(queueLock);
      }
    }

    protected ushort[] GetUshortBuffer()
    {
      bool flag = false;
      object queueLock;
      try
      {
        Monitor.Enter(queueLock = this._queueLock, ref flag);
        if (this._ushortBufferCache.Count == 0)
          return new ushort[this._size];
        return this._ushortBufferCache.Dequeue();
      }
      finally
      {
        if (flag)
          Monitor.Exit(queueLock);
      }
    }

    protected float[] GetFloatBuffer()
    {
      bool flag = false;
      object queueLock;
      try
      {
        Monitor.Enter(queueLock = this._queueLock, ref flag);
        if (this._floatBufferCache.Count == 0)
          return new float[this._size];
        return this._floatBufferCache.Dequeue();
      }
      finally
      {
        if (flag)
          Monitor.Exit(queueLock);
      }
    }

    public void Recycle<T>(T[] buffer)
    {
      bool flag = false;
      object queueLock;
      try
      {
        Monitor.Enter(queueLock = this._queueLock, ref flag);
        if (typeof (T).Equals(typeof (bool)))
        {
          this._boolBufferCache.Enqueue((bool[]) buffer);
        }
        else
        {
          if (!typeof (T).Equals(typeof (int)))
            return;
          this._intBufferCache.Enqueue((int[]) buffer);
        }
      }
      finally
      {
        if (flag)
          Monitor.Exit(queueLock);
      }
    }

    public bool[] CreateBoolSet(params int[] types)
    {
      return this.CreateBoolSet(false, types);
    }

    public bool[] CreateBoolSet(bool defaultState, params int[] types)
    {
      bool[] boolBuffer = this.GetBoolBuffer();
      for (int index = 0; index < boolBuffer.Length; ++index)
        boolBuffer[index] = defaultState;
      for (int index = 0; index < types.Length; ++index)
        boolBuffer[types[index]] = !defaultState;
      return boolBuffer;
    }

    public int[] CreateIntSet(int defaultState, params int[] inputs)
    {
      if (inputs.Length % 2 != 0)
        throw new Exception("You have a bad length for inputs on CreateArraySet");
      int[] intBuffer = this.GetIntBuffer();
      for (int index = 0; index < intBuffer.Length; ++index)
        intBuffer[index] = defaultState;
      int index1 = 0;
      while (index1 < inputs.Length)
      {
        intBuffer[inputs[index1]] = inputs[index1 + 1];
        index1 += 2;
      }
      return intBuffer;
    }

    public ushort[] CreateUshortSet(ushort defaultState, params ushort[] inputs)
    {
      if (inputs.Length % 2 != 0)
        throw new Exception("You have a bad length for inputs on CreateArraySet");
      ushort[] ushortBuffer = this.GetUshortBuffer();
      for (int index = 0; index < ushortBuffer.Length; ++index)
        ushortBuffer[index] = defaultState;
      int index1 = 0;
      while (index1 < inputs.Length)
      {
        ushortBuffer[(int) inputs[index1]] = inputs[index1 + 1];
        index1 += 2;
      }
      return ushortBuffer;
    }

    public float[] CreateFloatSet(float defaultState, params float[] inputs)
    {
      if (inputs.Length % 2 != 0)
        throw new Exception("You have a bad length for inputs on CreateArraySet");
      float[] floatBuffer = this.GetFloatBuffer();
      for (int index = 0; index < floatBuffer.Length; ++index)
        floatBuffer[index] = defaultState;
      int index1 = 0;
      while (index1 < inputs.Length)
      {
        floatBuffer[(int) inputs[index1]] = inputs[index1 + 1];
        index1 += 2;
      }
      return floatBuffer;
    }

    public T[] CreateCustomSet<T>(T defaultState, params object[] inputs)
    {
      if (inputs.Length % 2 != 0)
        throw new Exception("You have a bad length for inputs on CreateCustomSet");
      T[] objArray = new T[this._size];
      for (int index = 0; index < objArray.Length; ++index)
        objArray[index] = defaultState;
      if (inputs != null)
      {
        int index = 0;
        while (index < inputs.Length)
        {
          objArray[(int) (short) inputs[index]] = (T) inputs[index + 1];
          index += 2;
        }
      }
      return objArray;
    }
  }
}
