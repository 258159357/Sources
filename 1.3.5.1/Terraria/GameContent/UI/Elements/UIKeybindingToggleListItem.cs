﻿// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.Elements.UIKeybindingToggleListItem
// Assembly: TerrariaServer, Version=1.3.5.1, Culture=neutral, PublicKeyToken=null
// MVID: 5CBA2320-074B-43F7-8CDC-BF1E2B81EE4B
// Assembly location: C:\Users\kevzhao\Downloads\TerrariaServer.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria.Graphics;
using Terraria.UI;
using Terraria.UI.Chat;

namespace Terraria.GameContent.UI.Elements
{
  public class UIKeybindingToggleListItem : UIElement
  {
    private Color _color;
    private Func<string> _TextDisplayFunction;
    private Func<bool> _IsOnFunction;
    private Texture2D _toggleTexture;

    public UIKeybindingToggleListItem(Func<string> getText, Func<bool> getStatus, Color color)
    {
      this._color = color;
      this._toggleTexture = TextureManager.Load("Images/UI/Settings_Toggle");
      Func<string> func1;
      if (getText == null)
      {
        // ISSUE: reference to a compiler-generated field
        if (UIKeybindingToggleListItem.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate2 == null)
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: method pointer
          UIKeybindingToggleListItem.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate2 = new Func<string>((object) null, __methodptr(\u003C\u002Ector\u003Eb__0));
        }
        // ISSUE: reference to a compiler-generated field
        func1 = UIKeybindingToggleListItem.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate2;
      }
      else
        func1 = getText;
      this._TextDisplayFunction = func1;
      Func<bool> func2;
      if (getStatus == null)
      {
        // ISSUE: reference to a compiler-generated field
        if (UIKeybindingToggleListItem.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate3 == null)
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: method pointer
          UIKeybindingToggleListItem.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate3 = new Func<bool>((object) null, __methodptr(\u003C\u002Ector\u003Eb__1));
        }
        // ISSUE: reference to a compiler-generated field
        func2 = UIKeybindingToggleListItem.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate3;
      }
      else
        func2 = getStatus;
      this._IsOnFunction = func2;
    }

    protected override void DrawSelf(SpriteBatch spriteBatch)
    {
      float num1 = 6f;
      base.DrawSelf(spriteBatch);
      CalculatedStyle dimensions = this.GetDimensions();
      float num2 = dimensions.Width + 1f;
      Vector2 vector2_1;
      // ISSUE: explicit reference operation
      ((Vector2) @vector2_1).\u002Ector(dimensions.X, dimensions.Y);
      bool flag = false;
      Vector2 baseScale;
      // ISSUE: explicit reference operation
      ((Vector2) @baseScale).\u002Ector(0.8f);
      Color baseColor = Color.Lerp(flag ? Color.get_Gold() : (this.IsMouseHovering ? Color.get_White() : Color.get_Silver()), Color.get_White(), this.IsMouseHovering ? 0.5f : 0.0f);
      Color color = this.IsMouseHovering ? this._color : this._color.MultiplyRGBA(new Color(180, 180, 180));
      Vector2 position = vector2_1;
      Utils.DrawSettingsPanel(spriteBatch, position, num2, color);
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Vector2& local1 = @position;
      // ISSUE: explicit reference operation
      double num3 = (^local1).X + 8.0;
      // ISSUE: explicit reference operation
      (^local1).X = (__Null) num3;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Vector2& local2 = @position;
      // ISSUE: explicit reference operation
      double num4 = (^local2).Y + (2.0 + (double) num1);
      // ISSUE: explicit reference operation
      (^local2).Y = (__Null) num4;
      ChatManager.DrawColorCodedStringWithShadow(spriteBatch, Main.fontItemStack, this._TextDisplayFunction.Invoke(), position, baseColor, 0.0f, Vector2.get_Zero(), baseScale, num2, 2f);
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Vector2& local3 = @position;
      // ISSUE: explicit reference operation
      double num5 = (^local3).X - 17.0;
      // ISSUE: explicit reference operation
      (^local3).X = (__Null) num5;
      Rectangle rectangle;
      // ISSUE: explicit reference operation
      ((Rectangle) @rectangle).\u002Ector(this._IsOnFunction.Invoke() ? (this._toggleTexture.get_Width() - 2) / 2 + 2 : 0, 0, (this._toggleTexture.get_Width() - 2) / 2, this._toggleTexture.get_Height());
      Vector2 vector2_2;
      // ISSUE: explicit reference operation
      ((Vector2) @vector2_2).\u002Ector((float) rectangle.Width, 0.0f);
      // ISSUE: explicit reference operation
      ((Vector2) @position).\u002Ector((float) ((double) dimensions.X + (double) dimensions.Width - vector2_2.X - 10.0), dimensions.Y + 2f + num1);
      spriteBatch.Draw(this._toggleTexture, position, new Rectangle?(rectangle), Color.get_White(), 0.0f, Vector2.get_Zero(), Vector2.get_One(), (SpriteEffects) 0, 0.0f);
    }
  }
}
