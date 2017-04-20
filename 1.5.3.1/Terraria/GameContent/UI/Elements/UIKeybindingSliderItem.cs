﻿// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.Elements.UIKeybindingSliderItem
// Assembly: TerrariaServer, Version=1.3.5.1, Culture=neutral, PublicKeyToken=null
// MVID: 5CBA2320-074B-43F7-8CDC-BF1E2B81EE4B
// Assembly location: C:\Users\kevzhao\Downloads\TerrariaServer.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria.GameInput;
using Terraria.Graphics;
using Terraria.UI;
using Terraria.UI.Chat;

namespace Terraria.GameContent.UI.Elements
{
  public class UIKeybindingSliderItem : UIElement
  {
    private Color _color;
    private Func<string> _TextDisplayFunction;
    private Func<float> _GetStatusFunction;
    private Action<float> _SlideKeyboardAction;
    private Action _SlideGamepadAction;
    private int _sliderIDInPage;
    private Texture2D _toggleTexture;

    public UIKeybindingSliderItem(Func<string> getText, Func<float> getStatus, Action<float> setStatusKeyboard, Action setStatusGamepad, int sliderIDInPage, Color color)
    {
      this._color = color;
      this._toggleTexture = TextureManager.Load("Images/UI/Settings_Toggle");
      Func<string> func1;
      if (getText == null)
      {
        // ISSUE: reference to a compiler-generated field
        if (UIKeybindingSliderItem.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate4 == null)
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: method pointer
          UIKeybindingSliderItem.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate4 = new Func<string>((object) null, __methodptr(\u003C\u002Ector\u003Eb__0));
        }
        // ISSUE: reference to a compiler-generated field
        func1 = UIKeybindingSliderItem.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate4;
      }
      else
        func1 = getText;
      this._TextDisplayFunction = func1;
      Func<float> func2;
      if (getStatus == null)
      {
        // ISSUE: reference to a compiler-generated field
        if (UIKeybindingSliderItem.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate5 == null)
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: method pointer
          UIKeybindingSliderItem.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate5 = new Func<float>((object) null, __methodptr(\u003C\u002Ector\u003Eb__1));
        }
        // ISSUE: reference to a compiler-generated field
        func2 = UIKeybindingSliderItem.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate5;
      }
      else
        func2 = getStatus;
      this._GetStatusFunction = func2;
      this._SlideKeyboardAction = setStatusKeyboard != null ? setStatusKeyboard : (Action<float>) (s => {});
      Action action;
      if (setStatusGamepad == null)
      {
        // ISSUE: reference to a compiler-generated field
        if (UIKeybindingSliderItem.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate7 == null)
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: method pointer
          UIKeybindingSliderItem.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate7 = new Action((object) null, __methodptr(\u003C\u002Ector\u003Eb__3));
        }
        // ISSUE: reference to a compiler-generated field
        action = UIKeybindingSliderItem.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate7;
      }
      else
        action = setStatusGamepad;
      this._SlideGamepadAction = action;
      this._sliderIDInPage = sliderIDInPage;
    }

    protected override void DrawSelf(SpriteBatch spriteBatch)
    {
      float num1 = 6f;
      base.DrawSelf(spriteBatch);
      int lockState = 0;
      IngameOptions.rightHover = -1;
      if (!Main.mouseLeft)
        IngameOptions.rightLock = -1;
      if (IngameOptions.rightLock == this._sliderIDInPage)
        lockState = 1;
      else if (IngameOptions.rightLock != -1)
        lockState = 2;
      CalculatedStyle dimensions = this.GetDimensions();
      float num2 = dimensions.Width + 1f;
      Vector2 vector2;
      // ISSUE: explicit reference operation
      ((Vector2) @vector2).\u002Ector(dimensions.X, dimensions.Y);
      bool flag1 = false;
      bool flag2 = this.IsMouseHovering;
      if (lockState == 1)
        flag2 = true;
      if (lockState == 2)
        flag2 = false;
      Vector2 baseScale;
      // ISSUE: explicit reference operation
      ((Vector2) @baseScale).\u002Ector(0.8f);
      Color baseColor = Color.Lerp(flag1 ? Color.get_Gold() : (flag2 ? Color.get_White() : Color.get_Silver()), Color.get_White(), flag2 ? 0.5f : 0.0f);
      Color color = flag2 ? this._color : this._color.MultiplyRGBA(new Color(180, 180, 180));
      Vector2 position = vector2;
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
      Main.colorBarTexture.Frame(1, 1, 0, 0);
      // ISSUE: explicit reference operation
      ((Vector2) @position).\u002Ector((float) ((double) dimensions.X + (double) dimensions.Width - 10.0), dimensions.Y + 10f + num1);
      IngameOptions.valuePosition = position;
      float num6 = IngameOptions.DrawValueBar(spriteBatch, 1f, this._GetStatusFunction.Invoke(), lockState, (Utils.ColorLerpMethod) null);
      if (IngameOptions.inBar || IngameOptions.rightLock == this._sliderIDInPage)
      {
        IngameOptions.rightHover = this._sliderIDInPage;
        if (PlayerInput.Triggers.Current.MouseLeft && PlayerInput.CurrentProfile.AllowEditting && (!PlayerInput.UsingGamepad && IngameOptions.rightLock == this._sliderIDInPage))
          this._SlideKeyboardAction(num6);
      }
      if (IngameOptions.rightHover != -1 && IngameOptions.rightLock == -1)
        IngameOptions.rightLock = IngameOptions.rightHover;
      if (!this.IsMouseHovering || !PlayerInput.CurrentProfile.AllowEditting)
        return;
      this._SlideGamepadAction.Invoke();
    }
  }
}
