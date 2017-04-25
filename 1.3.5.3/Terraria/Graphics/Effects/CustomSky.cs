// Decompiled with JetBrains decompiler
// Type: Terraria.Graphics.Effects.CustomSky
// Assembly: TerrariaServer, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: AA3606A2-F3DB-4481-937B-7295FB97CD3E
// Assembly location: E:\TSHOCK\TerrariaServer.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Terraria.Graphics.Effects
{
  public abstract class CustomSky : GameEffect
  {
    public abstract void Update(GameTime gameTime);

    public abstract void Draw(SpriteBatch spriteBatch, float minDepth, float maxDepth);

    public abstract bool IsActive();

    public abstract void Reset();

    public virtual Color OnTileColor(Color inColor)
    {
      return inColor;
    }

    public virtual float GetCloudAlpha()
    {
      return 1f;
    }

    public override bool IsVisible()
    {
      return true;
    }
  }
}
