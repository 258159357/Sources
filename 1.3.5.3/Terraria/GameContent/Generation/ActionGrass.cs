// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Generation.ActionGrass
// Assembly: TerrariaServer, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: AA3606A2-F3DB-4481-937B-7295FB97CD3E
// Assembly location: E:\TSHOCK\TerrariaServer.exe

using Microsoft.Xna.Framework;
using Terraria.World.Generation;

namespace Terraria.GameContent.Generation
{
  public class ActionGrass : GenAction
  {
    public override bool Apply(Point origin, int x, int y, params object[] args)
    {
      if (GenBase._tiles[x, y].active() || GenBase._tiles[x, y - 1].active())
        return false;
      WorldGen.PlaceTile(x, y, (int) Utils.SelectRandom<ushort>(GenBase._random, new ushort[2]
      {
        (ushort) 3,
        (ushort) 73
      }), 1 != 0, 0 != 0, -1, 0);
      return this.UnitApply(origin, x, y, args);
    }
  }
}
