// Decompiled with JetBrains decompiler
// Type: Terraria.UI.GameInterfaceLayer
// Assembly: TerrariaServer, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: AA3606A2-F3DB-4481-937B-7295FB97CD3E
// Assembly location: E:\TSHOCK\TerrariaServer.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameInput;

namespace Terraria.UI
{
  public class GameInterfaceLayer
  {
    public readonly string Name;
    public InterfaceScaleType ScaleType;

    public GameInterfaceLayer(string name, InterfaceScaleType scaleType)
    {
      this.Name = name;
      this.ScaleType = scaleType;
    }

    public bool Draw()
    {
      Matrix transformMatrix;
      if (this.ScaleType == InterfaceScaleType.Game)
      {
        PlayerInput.SetZoom_World();
        transformMatrix = Main.GameViewMatrix.ZoomMatrix;
      }
      else if (this.ScaleType == InterfaceScaleType.UI)
      {
        PlayerInput.SetZoom_UI();
        transformMatrix = Main.UIScaleMatrix;
      }
      else
      {
        PlayerInput.SetZoom_Unscaled();
        transformMatrix = Matrix.Identity;
      }
      Main.spriteBatch.Begin(SpriteSortMode.Deferred, (BlendState) null, (SamplerState) null, (DepthStencilState) null, (RasterizerState) null, (Effect) null, transformMatrix);
      int num = this.DrawSelf() ? 1 : 0;
      Main.spriteBatch.End();
      return num != 0;
    }

    protected virtual bool DrawSelf()
    {
      return true;
    }
  }
}
