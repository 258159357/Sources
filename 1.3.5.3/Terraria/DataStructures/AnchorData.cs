﻿// Decompiled with JetBrains decompiler
// Type: Terraria.DataStructures.AnchorData
// Assembly: TerrariaServer, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: AA3606A2-F3DB-4481-937B-7295FB97CD3E
// Assembly location: E:\TSHOCK\TerrariaServer.exe

using Terraria.Enums;

namespace Terraria.DataStructures
{
  public struct AnchorData
  {
    public AnchorType type;
    public int tileCount;
    public int checkStart;
    public static AnchorData Empty;

    public AnchorData(AnchorType type, int count, int start)
    {
      this.type = type;
      this.tileCount = count;
      this.checkStart = start;
    }

    public static bool operator ==(AnchorData data1, AnchorData data2)
    {
      if (data1.type == data2.type && data1.tileCount == data2.tileCount)
        return data1.checkStart == data2.checkStart;
      return false;
    }

    public static bool operator !=(AnchorData data1, AnchorData data2)
    {
      if (data1.type == data2.type && data1.tileCount == data2.tileCount)
        return data1.checkStart != data2.checkStart;
      return true;
    }

    public override bool Equals(object obj)
    {
      if (obj is AnchorData && this.type == ((AnchorData) obj).type && this.tileCount == ((AnchorData) obj).tileCount)
        return this.checkStart == ((AnchorData) obj).checkStart;
      return false;
    }

    public override int GetHashCode()
    {
      return (int) (ushort) this.type << 16 | (int) (byte) this.tileCount << 8 | (int) (byte) this.checkStart;
    }
  }
}
