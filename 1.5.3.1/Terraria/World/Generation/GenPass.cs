// Decompiled with JetBrains decompiler
// Type: Terraria.World.Generation.GenPass
// Assembly: TerrariaServer, Version=1.3.5.1, Culture=neutral, PublicKeyToken=null
// MVID: 5CBA2320-074B-43F7-8CDC-BF1E2B81EE4B
// Assembly location: C:\Users\kevzhao\Downloads\TerrariaServer.exe

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
