﻿// Decompiled with JetBrains decompiler
// Type: Terraria.World.Generation.MicroBiome
// Assembly: TerrariaServer, Version=1.3.5.0, Culture=neutral, PublicKeyToken=null
// MVID: 13381DB9-8FD8-4EBB-8CED-9CF82DC89291
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Terraria\TerrariaServer.exe

namespace Terraria.World.Generation
{
  public abstract class MicroBiome : GenStructure
  {
    public virtual void Reset()
    {
    }

    public static void ResetAll()
    {
      foreach (MicroBiome biome in BiomeCollection.Biomes)
        biome.Reset();
    }
  }
}
