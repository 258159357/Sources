﻿// Decompiled with JetBrains decompiler
// Type: Terraria.Graphics.Effects.Filter
// Assembly: TerrariaServer, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: AA3606A2-F3DB-4481-937B-7295FB97CD3E
// Assembly location: E:\TSHOCK\TerrariaServer.exe

using Microsoft.Xna.Framework;
using Terraria.Graphics.Shaders;

namespace Terraria.Graphics.Effects
{
  public class Filter : GameEffect
  {
    public bool Active;
    private ScreenShaderData _shader;
    public bool IsHidden;

    public Filter(ScreenShaderData shader, EffectPriority priority = EffectPriority.VeryLow)
    {
      this._shader = shader;
      this._priority = priority;
    }

    public void Update(GameTime gameTime)
    {
      this._shader.UseGlobalOpacity(this.Opacity);
      this._shader.Update(gameTime);
    }

    public void Apply()
    {
      this._shader.Apply();
    }

    public ScreenShaderData GetShader()
    {
      return this._shader;
    }

    internal override void Activate(Vector2 position, params object[] args)
    {
      this._shader.UseGlobalOpacity(this.Opacity);
      this._shader.UseTargetPosition(position);
      this.Active = true;
    }

    internal override void Deactivate(params object[] args)
    {
      this.Active = false;
    }

    public bool IsInUse()
    {
      if (!this.Active)
        return (double) this.Opacity != 0.0;
      return true;
    }

    public bool IsActive()
    {
      return this.Active;
    }

    public override bool IsVisible()
    {
      if ((double) this.GetShader().CombinedOpacity > 0.0)
        return !this.IsHidden;
      return false;
    }
  }
}
