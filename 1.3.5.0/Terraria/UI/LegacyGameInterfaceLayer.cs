// Decompiled with JetBrains decompiler
// Type: Terraria.UI.LegacyGameInterfaceLayer
// Assembly: TerrariaServer, Version=1.3.5.0, Culture=neutral, PublicKeyToken=null
// MVID: 13381DB9-8FD8-4EBB-8CED-9CF82DC89291
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Terraria\TerrariaServer.exe

namespace Terraria.UI
{
  public class LegacyGameInterfaceLayer : GameInterfaceLayer
  {
    private GameInterfaceDrawMethod _drawMethod;

    public LegacyGameInterfaceLayer(string name, GameInterfaceDrawMethod drawMethod, InterfaceScaleType scaleType = InterfaceScaleType.Game)
      : base(name, scaleType)
    {
      this._drawMethod = drawMethod;
    }

    protected override bool DrawSelf()
    {
      return this._drawMethod();
    }
  }
}
