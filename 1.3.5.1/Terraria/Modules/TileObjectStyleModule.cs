﻿// Decompiled with JetBrains decompiler
// Type: Terraria.Modules.TileObjectStyleModule
// Assembly: TerrariaServer, Version=1.3.5.1, Culture=neutral, PublicKeyToken=null
// MVID: 5CBA2320-074B-43F7-8CDC-BF1E2B81EE4B
// Assembly location: C:\Users\kevzhao\Downloads\TerrariaServer.exe

namespace Terraria.Modules
{
  public class TileObjectStyleModule
  {
    public int style;
    public bool horizontal;
    public int styleWrapLimit;
    public int styleMultiplier;
    public int styleLineSkip;

    public TileObjectStyleModule(TileObjectStyleModule copyFrom = null)
    {
      if (copyFrom == null)
      {
        this.style = 0;
        this.horizontal = false;
        this.styleWrapLimit = 0;
        this.styleMultiplier = 1;
        this.styleLineSkip = 1;
      }
      else
      {
        this.style = copyFrom.style;
        this.horizontal = copyFrom.horizontal;
        this.styleWrapLimit = copyFrom.styleWrapLimit;
        this.styleMultiplier = copyFrom.styleMultiplier;
        this.styleLineSkip = copyFrom.styleLineSkip;
      }
    }
  }
}
