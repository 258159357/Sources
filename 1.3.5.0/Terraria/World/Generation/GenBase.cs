﻿// Decompiled with JetBrains decompiler
// Type: Terraria.World.Generation.GenBase
// Assembly: TerrariaServer, Version=1.3.5.0, Culture=neutral, PublicKeyToken=null
// MVID: 13381DB9-8FD8-4EBB-8CED-9CF82DC89291
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Terraria\TerrariaServer.exe

using Terraria.Utilities;

namespace Terraria.World.Generation
{
  public class GenBase
  {
    protected static UnifiedRandom _random
    {
      get
      {
        return WorldGen.genRand;
      }
    }

    protected static Tile[,] _tiles
    {
      get
      {
        return Main.tile;
      }
    }

    protected static int _worldWidth
    {
      get
      {
        return Main.maxTilesX;
      }
    }

    protected static int _worldHeight
    {
      get
      {
        return Main.maxTilesY;
      }
    }

    public delegate bool CustomPerUnitAction(int x, int y, params object[] args);
  }
}
