// Decompiled with JetBrains decompiler
// Type: Terraria.Modules.LiquidPlacementModule
// Assembly: TerrariaServer, Version=1.3.5.0, Culture=neutral, PublicKeyToken=null
// MVID: 13381DB9-8FD8-4EBB-8CED-9CF82DC89291
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Terraria\TerrariaServer.exe

using Terraria.Enums;

namespace Terraria.Modules
{
  public class LiquidPlacementModule
  {
    public LiquidPlacement water;
    public LiquidPlacement lava;

    public LiquidPlacementModule(LiquidPlacementModule copyFrom = null)
    {
      if (copyFrom == null)
      {
        this.water = LiquidPlacement.Allowed;
        this.lava = LiquidPlacement.Allowed;
      }
      else
      {
        this.water = copyFrom.water;
        this.lava = copyFrom.lava;
      }
    }
  }
}
