// Decompiled with JetBrains decompiler
// Type: Terraria.Graphics.Effects.CustomSky
// Assembly: TerrariaServer, Version=1.3.5.0, Culture=neutral, PublicKeyToken=null
// MVID: 13381DB9-8FD8-4EBB-8CED-9CF82DC89291
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Terraria\TerrariaServer.exe

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
