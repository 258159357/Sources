﻿// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.Elements.UIHeader
// Assembly: TerrariaServer, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: AA3606A2-F3DB-4481-937B-7295FB97CD3E
// Assembly location: E:\TSHOCK\TerrariaServer.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using Terraria.UI;

namespace Terraria.GameContent.UI.Elements
{
  public class UIHeader : UIElement
  {
    private string _text;

    public string Text
    {
      get
      {
        return this._text;
      }
      set
      {
        if (!(this._text != value))
          return;
        this._text = value;
        this.Width.Precent = 0.0f;
        this.Height.Precent = 0.0f;
        this.Recalculate();
      }
    }

    public UIHeader()
    {
      this.Text = "";
    }

    public UIHeader(string text)
    {
      this.Text = text;
    }

    protected override void DrawSelf(SpriteBatch spriteBatch)
    {
      CalculatedStyle dimensions = this.GetDimensions();
      DynamicSpriteFontExtensionMethods.DrawString(spriteBatch, Main.fontDeathText, this.Text, new Vector2(dimensions.X, dimensions.Y), Color.White);
    }
  }
}
