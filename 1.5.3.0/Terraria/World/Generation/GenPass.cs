// Decompiled with JetBrains decompiler
// Type: Terraria.World.Generation.GenPass
// Assembly: TerrariaServer, Version=1.3.5.0, Culture=neutral, PublicKeyToken=null
// MVID: 13381DB9-8FD8-4EBB-8CED-9CF82DC89291
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Terraria\TerrariaServer.exe

namespace Terraria.World.Generation
{
  public abstract class GenPass : GenBase
  {
    public string Name;
    public float Weight;

    public GenPass(string name, float loadWeight)
    {
      this.Name = name;
      this.Weight = loadWeight;
    }

    public abstract void Apply(GenerationProgress progress);
  }
}
