﻿// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Dyes.LegacyHairShaderData
// Assembly: TerrariaServer, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: AA3606A2-F3DB-4481-937B-7295FB97CD3E
// Assembly location: E:\TSHOCK\TerrariaServer.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Graphics.Shaders;

namespace Terraria.GameContent.Dyes
{
  public class LegacyHairShaderData : HairShaderData
  {
    private LegacyHairShaderData.ColorProcessingMethod _colorProcessor;

    public LegacyHairShaderData()
      : base((Ref<Effect>) null, (string) null)
    {
      this._shaderDisabled = true;
    }

    public override Color GetColor(Player player, Color lightColor)
    {
      bool lighting = true;
      Color color = this._colorProcessor(player, player.hairColor, ref lighting);
      if (lighting)
        return new Color(color.ToVector4() * lightColor.ToVector4());
      return color;
    }

    public LegacyHairShaderData UseLegacyMethod(LegacyHairShaderData.ColorProcessingMethod colorProcessor)
    {
      this._colorProcessor = colorProcessor;
      return this;
    }

    public delegate Color ColorProcessingMethod(Player player, Color color, ref bool lighting);
  }
}
