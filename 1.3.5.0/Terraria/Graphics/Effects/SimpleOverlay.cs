﻿// Decompiled with JetBrains decompiler
// Type: Terraria.Graphics.Effects.SimpleOverlay
// Assembly: TerrariaServer, Version=1.3.5.0, Culture=neutral, PublicKeyToken=null
// MVID: 13381DB9-8FD8-4EBB-8CED-9CF82DC89291
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Terraria\TerrariaServer.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Graphics.Shaders;

namespace Terraria.Graphics.Effects
{
  public class SimpleOverlay : Overlay
  {
    public Vector2 TargetPosition = Vector2.Zero;
    private Ref<Texture2D> _texture;
    private ScreenShaderData _shader;

    public SimpleOverlay(string textureName, ScreenShaderData shader, EffectPriority priority = EffectPriority.VeryLow, RenderLayers layer = RenderLayers.All)
      : base(priority, layer)
    {
      this._texture = TextureManager.AsyncLoad(textureName == null ? "" : textureName);
      this._shader = shader;
    }

    public SimpleOverlay(string textureName, string shaderName = "Default", EffectPriority priority = EffectPriority.VeryLow, RenderLayers layer = RenderLayers.All)
      : base(priority, layer)
    {
      this._texture = TextureManager.AsyncLoad(textureName == null ? "" : textureName);
      this._shader = new ScreenShaderData(Main.ScreenShaderRef, shaderName);
    }

    public ScreenShaderData GetShader()
    {
      return this._shader;
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
      this._shader.UseGlobalOpacity(this.Opacity);
      this._shader.UseTargetPosition(this.TargetPosition);
      this._shader.Apply();
      spriteBatch.Draw(this._texture.Value, new Rectangle(0, 0, Main.screenWidth, Main.screenHeight), Main.bgColor);
    }

    public override void Update(GameTime gameTime)
    {
      this._shader.Update(gameTime);
    }

    internal override void Activate(Vector2 position, params object[] args)
    {
      this.TargetPosition = position;
      this.Mode = OverlayMode.FadeIn;
    }

    internal override void Deactivate(params object[] args)
    {
      this.Mode = OverlayMode.FadeOut;
    }

    public override bool IsVisible()
    {
      return (double) this._shader.CombinedOpacity > 0.0;
    }
  }
}
