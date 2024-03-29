﻿// Decompiled with JetBrains decompiler
// Type: Terraria.DataStructures.TileObjectPreviewData
// Assembly: TerrariaServer, Version=1.3.5.0, Culture=neutral, PublicKeyToken=null
// MVID: 13381DB9-8FD8-4EBB-8CED-9CF82DC89291
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Terraria\TerrariaServer.exe

using System;

namespace Terraria.DataStructures
{
  public class TileObjectPreviewData
  {
    public const int None = 0;
    public const int ValidSpot = 1;
    public const int InvalidSpot = 2;
    private ushort _type;
    private short _style;
    private int _alternate;
    private int _random;
    private bool _active;
    private Point16 _size;
    private Point16 _coordinates;
    private Point16 _objectStart;
    private int[,] _data;
    private Point16 _dataSize;
    private float _percentValid;
    public static TileObjectPreviewData placementCache;
    public static TileObjectPreviewData randomCache;

    public bool Active
    {
      get
      {
        return this._active;
      }
      set
      {
        this._active = value;
      }
    }

    public ushort Type
    {
      get
      {
        return this._type;
      }
      set
      {
        this._type = value;
      }
    }

    public short Style
    {
      get
      {
        return this._style;
      }
      set
      {
        this._style = value;
      }
    }

    public int Alternate
    {
      get
      {
        return this._alternate;
      }
      set
      {
        this._alternate = value;
      }
    }

    public int Random
    {
      get
      {
        return this._random;
      }
      set
      {
        this._random = value;
      }
    }

    public Point16 Size
    {
      get
      {
        return this._size;
      }
      set
      {
        if ((int) value.X <= 0 || (int) value.Y <= 0)
          throw new FormatException("PlacementData.Size was set to a negative value.");
        if ((int) value.X > (int) this._dataSize.X || (int) value.Y > (int) this._dataSize.Y)
        {
          int X = (int) value.X > (int) this._dataSize.X ? (int) value.X : (int) this._dataSize.X;
          int Y = (int) value.Y > (int) this._dataSize.Y ? (int) value.Y : (int) this._dataSize.Y;
          int[,] numArray = new int[X, Y];
          if (this._data != null)
          {
            for (int index1 = 0; index1 < (int) this._dataSize.X; ++index1)
            {
              for (int index2 = 0; index2 < (int) this._dataSize.Y; ++index2)
                numArray[index1, index2] = this._data[index1, index2];
            }
          }
          this._data = numArray;
          this._dataSize = new Point16(X, Y);
        }
        this._size = value;
      }
    }

    public Point16 Coordinates
    {
      get
      {
        return this._coordinates;
      }
      set
      {
        this._coordinates = value;
      }
    }

    public Point16 ObjectStart
    {
      get
      {
        return this._objectStart;
      }
      set
      {
        this._objectStart = value;
      }
    }

    public int this[int x, int y]
    {
      get
      {
        if (x < 0 || y < 0 || (x >= (int) this._size.X || y >= (int) this._size.Y))
          throw new IndexOutOfRangeException();
        return this._data[x, y];
      }
      set
      {
        if (x < 0 || y < 0 || (x >= (int) this._size.X || y >= (int) this._size.Y))
          throw new IndexOutOfRangeException();
        this._data[x, y] = value;
      }
    }

    public void Reset()
    {
      this._active = false;
      this._size = Point16.Zero;
      this._coordinates = Point16.Zero;
      this._objectStart = Point16.Zero;
      this._percentValid = 0.0f;
      this._type = (ushort) 0;
      this._style = (short) 0;
      this._alternate = -1;
      this._random = -1;
      if (this._data == null)
        return;
      Array.Clear((Array) this._data, 0, (int) this._dataSize.X * (int) this._dataSize.Y);
    }

    public void CopyFrom(TileObjectPreviewData copy)
    {
      this._type = copy._type;
      this._style = copy._style;
      this._alternate = copy._alternate;
      this._random = copy._random;
      this._active = copy._active;
      this._size = copy._size;
      this._coordinates = copy._coordinates;
      this._objectStart = copy._objectStart;
      this._percentValid = copy._percentValid;
      if (this._data == null)
      {
        this._data = new int[(int) copy._dataSize.X, (int) copy._dataSize.Y];
        this._dataSize = copy._dataSize;
      }
      else
        Array.Clear((Array) this._data, 0, this._data.Length);
      if ((int) this._dataSize.X < (int) copy._dataSize.X || (int) this._dataSize.Y < (int) copy._dataSize.Y)
      {
        int X = (int) copy._dataSize.X > (int) this._dataSize.X ? (int) copy._dataSize.X : (int) this._dataSize.X;
        int Y = (int) copy._dataSize.Y > (int) this._dataSize.Y ? (int) copy._dataSize.Y : (int) this._dataSize.Y;
        this._data = new int[X, Y];
        this._dataSize = new Point16(X, Y);
      }
      for (int index1 = 0; index1 < (int) copy._dataSize.X; ++index1)
      {
        for (int index2 = 0; index2 < (int) copy._dataSize.Y; ++index2)
          this._data[index1, index2] = copy._data[index1, index2];
      }
    }

    public void AllInvalid()
    {
      for (int index1 = 0; index1 < (int) this._size.X; ++index1)
      {
        for (int index2 = 0; index2 < (int) this._size.Y; ++index2)
        {
          if (this._data[index1, index2] != 0)
            this._data[index1, index2] = 2;
        }
      }
    }
  }
}
