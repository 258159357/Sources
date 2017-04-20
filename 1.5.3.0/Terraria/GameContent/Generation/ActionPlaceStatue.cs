// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Generation.ActionPlaceStatue
// Assembly: TerrariaServer, Version=1.3.5.0, Culture=neutral, PublicKeyToken=null
// MVID: 13381DB9-8FD8-4EBB-8CED-9CF82DC89291
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Terraria\TerrariaServer.exe

using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria.World.Generation;

namespace Terraria.GameContent.Generation
{
  public class ActionPlaceStatue : GenAction
  {
    private int _statueIndex;

    public ActionPlaceStatue(int index = -1)
    {
      this._statueIndex = index;
    }

    public override bool Apply(Point origin, int x, int y, params object[] args)
    {
      Point16 point16 = this._statueIndex != -1 ? WorldGen.statueList[this._statueIndex] : WorldGen.statueList[GenBase._random.Next(2, WorldGen.statueList.Length)];
      WorldGen.PlaceTile(x, y, (int) point16.X, true, false, -1, (int) point16.Y);
      return this.UnitApply(origin, x, y, args);
    }
  }
}
