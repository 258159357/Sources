﻿// Decompiled with JetBrains decompiler
// Type: Terraria.UI.StyleDimension
// Assembly: TerrariaServer, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: AA3606A2-F3DB-4481-937B-7295FB97CD3E
// Assembly location: E:\TSHOCK\TerrariaServer.exe

namespace Terraria.UI
{
  public struct StyleDimension
  {
    public static StyleDimension Fill = new StyleDimension(0.0f, 1f);
    public static StyleDimension Empty = new StyleDimension(0.0f, 0.0f);
    public float Pixels;
    public float Precent;

    public StyleDimension(float pixels, float precent)
    {
      this.Pixels = pixels;
      this.Precent = precent;
    }

    public void Set(float pixels, float precent)
    {
      this.Pixels = pixels;
      this.Precent = precent;
    }

    public float GetValue(float containerSize)
    {
      return this.Pixels + this.Precent * containerSize;
    }
  }
}
