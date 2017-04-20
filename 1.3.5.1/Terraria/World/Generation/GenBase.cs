// Decompiled with JetBrains decompiler
// Type: Terraria.World.Generation.GenBase
// Assembly: TerrariaServer, Version=1.3.5.1, Culture=neutral, PublicKeyToken=null
// MVID: 5CBA2320-074B-43F7-8CDC-BF1E2B81EE4B
// Assembly location: C:\Users\kevzhao\Downloads\TerrariaServer.exe

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
