// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.Elements.UIKeybindingSimpleListItem
// Assembly: TerrariaServer, Version=1.3.5.1, Culture=neutral, PublicKeyToken=null
// MVID: 5CBA2320-074B-43F7-8CDC-BF1E2B81EE4B
// Assembly location: C:\Users\kevzhao\Downloads\TerrariaServer.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria.UI;
using Terraria.UI.Chat;

namespace Terraria.GameContent.UI.Elements
{
  public class UIKeybindingSimpleListItem : UIElement
  {
    private Color _color;
    private Func<string> _GetTextFunction;

    public UIKeybindingSimpleListItem(Func<string> getText, Color color)
    {
      this._color = color;
      Func<string> func;
      if (getText == null)
      {
        // ISSUE: reference to a compiler-generated field
        if (UIKeybindingSimpleListItem.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate1 == null)
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: method pointer
          UIKeybindingSimpleListItem.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate1 = new Func<string>((object) null, __methodptr(\u003C\u002Ector\u003Eb__0));
        }
        // ISSUE: reference to a compiler-generated field
        func = UIKeybindingSimpleListItem.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate1;
      }
      else
        func = getText;
      this._GetTextFunction = func;
    }

    protected override void DrawSelf(SpriteBatch spriteBatch)
    {
      float num1 = 6f;
      base.DrawSelf(spriteBatch);
      CalculatedStyle dimensions = this.GetDimensions();
      float num2 = dimensions.Width + 1f;
      Vector2 vector2;
      // ISSUE: explicit reference operation
      ((Vector2) @vector2).\u002Ector(dimensions.X, dimensions.Y);
      Vector2 baseScale;
      // ISSUE: explicit reference operation
      ((Vector2) @baseScale).\u002Ector(0.8f);
      Color baseColor = Color.Lerp(this.IsMouseHovering ? Color.get_White() : Color.get_Silver(), Color.get_White(), this.IsMouseHovering ? 0.5f : 0.0f);
      Color color = this.IsMouseHovering ? this._color : this._color.MultiplyRGBA(new Color(180, 180, 180));
      Vector2 position = vector2;
      Utils.DrawSettings2Panel(spriteBatch, position, num2, color);
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
      string text = this._GetTextFunction.Invoke();
      Vector2 stringSize = ChatManager.GetStringSize(Main.fontItemStack, text, baseScale, -1f);
      position.X = (__Null) ((double) dimensions.X + (double) dimensions.Width / 2.0 - stringSize.X / 2.0);
      ChatManager.DrawColorCodedStringWithShadow(spriteBatch, Main.fontItemStack, text, position, baseColor, 0.0f, Vector2.get_Zero(), baseScale, num2, 2f);
    }
  }
}
