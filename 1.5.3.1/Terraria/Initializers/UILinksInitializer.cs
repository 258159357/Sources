// Decompiled with JetBrains decompiler
// Type: Terraria.Initializers.UILinksInitializer
// Assembly: TerrariaServer, Version=1.3.5.1, Culture=neutral, PublicKeyToken=null
// MVID: 5CBA2320-074B-43F7-8CDC-BF1E2B81EE4B
// Assembly location: C:\Users\kevzhao\Downloads\TerrariaServer.exe

using Microsoft.Xna.Framework;
using System;
using Terraria.GameContent.UI.States;
using Terraria.GameInput;
using Terraria.UI;
using Terraria.UI.Gamepad;

namespace Terraria.Initializers
{
  public class UILinksInitializer
  {
    public static bool NothingMoreImportantThanNPCChat()
    {
      if (!Main.hairWindow && Main.npcShop == 0)
        return Main.player[Main.myPlayer].chest == -1;
      return false;
    }

    public static float HandleSlider(float currentValue, float min, float max, float deadZone = 0.2f, float sensitivity = 0.5f)
    {
      float x = (float) PlayerInput.GamepadThumbstickLeft.X;
      float num = (double) x < -(double) deadZone || (double) x > (double) deadZone ? MathHelper.Lerp(0.0f, sensitivity / 60f, (float) (((double) Math.Abs(x) - (double) deadZone) / (1.0 - (double) deadZone))) * (float) Math.Sign(x) : 0.0f;
      return MathHelper.Clamp((float) (((double) currentValue - (double) min) / ((double) max - (double) min)) + num, 0.0f, 1f) * (max - min) + min;
    }

    public static void Load()
    {
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate7a == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate7a = new Func<string>((object) null, __methodptr(\u003CLoad\u003Eb__0));
      }
      // ISSUE: reference to a compiler-generated field
      Func<string> methodDelegate7a = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate7a;
      UILinkPage page1 = new UILinkPage();
      UILinkPage uiLinkPage1 = page1;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate7b == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate7b = new Action((object) null, __methodptr(\u003CLoad\u003Eb__1));
      }
      // ISSUE: reference to a compiler-generated field
      Action methodDelegate7b = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate7b;
      uiLinkPage1.UpdateEvent += methodDelegate7b;
      for (int index = 0; index < 20; ++index)
        page1.LinkMap.Add(2000 + index, new UILinkPoint(2000 + index, true, -3, -4, -1, -2));
      UILinkPage uiLinkPage2 = page1;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate7c == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate7c = new Func<string>((object) null, __methodptr(\u003CLoad\u003Eb__2));
      }
      // ISSUE: reference to a compiler-generated field
      Func<string> methodDelegate7c = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate7c;
      uiLinkPage2.OnSpecialInteracts += methodDelegate7c;
      UILinkPage uiLinkPage3 = page1;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate7d == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate7d = new Action((object) null, __methodptr(\u003CLoad\u003Eb__3));
      }
      // ISSUE: reference to a compiler-generated field
      Action methodDelegate7d = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate7d;
      uiLinkPage3.UpdateEvent += methodDelegate7d;
      UILinkPage uiLinkPage4 = page1;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate7e == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate7e = new Func<bool>((object) null, __methodptr(\u003CLoad\u003Eb__4));
      }
      // ISSUE: reference to a compiler-generated field
      Func<bool> methodDelegate7e = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate7e;
      uiLinkPage4.IsValidEvent += methodDelegate7e;
      UILinkPage uiLinkPage5 = page1;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate7f == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate7f = new Func<bool>((object) null, __methodptr(\u003CLoad\u003Eb__5));
      }
      // ISSUE: reference to a compiler-generated field
      Func<bool> methodDelegate7f = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate7f;
      uiLinkPage5.CanEnterEvent += methodDelegate7f;
      UILinkPointNavigator.RegisterPage(page1, 1000, true);
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      UILinksInitializer.\u003C\u003Ec__DisplayClassdd cDisplayClassdd = new UILinksInitializer.\u003C\u003Ec__DisplayClassdd();
      // ISSUE: reference to a compiler-generated field
      cDisplayClassdd.cp = new UILinkPage();
      // ISSUE: reference to a compiler-generated field
      cDisplayClassdd.cp.LinkMap.Add(2500, new UILinkPoint(2500, true, -3, 2501, -1, -2));
      // ISSUE: reference to a compiler-generated field
      cDisplayClassdd.cp.LinkMap.Add(2501, new UILinkPoint(2501, true, 2500, 2502, -1, -2));
      // ISSUE: reference to a compiler-generated field
      cDisplayClassdd.cp.LinkMap.Add(2502, new UILinkPoint(2502, true, 2501, -4, -1, -2));
      // ISSUE: reference to a compiler-generated field
      // ISSUE: method pointer
      cDisplayClassdd.cp.UpdateEvent += new Action((object) cDisplayClassdd, __methodptr(\u003CLoad\u003Eb__6));
      // ISSUE: reference to a compiler-generated field
      UILinkPage cp1 = cDisplayClassdd.cp;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate80 == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate80 = new Func<string>((object) null, __methodptr(\u003CLoad\u003Eb__7));
      }
      // ISSUE: reference to a compiler-generated field
      Func<string> methodDelegate80 = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate80;
      cp1.OnSpecialInteracts += methodDelegate80;
      // ISSUE: reference to a compiler-generated field
      UILinkPage cp2 = cDisplayClassdd.cp;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate81 == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate81 = new Func<bool>((object) null, __methodptr(\u003CLoad\u003Eb__8));
      }
      // ISSUE: reference to a compiler-generated field
      Func<bool> methodDelegate81 = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate81;
      cp2.IsValidEvent += methodDelegate81;
      // ISSUE: reference to a compiler-generated field
      UILinkPage cp3 = cDisplayClassdd.cp;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate82 == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate82 = new Func<bool>((object) null, __methodptr(\u003CLoad\u003Eb__9));
      }
      // ISSUE: reference to a compiler-generated field
      Func<bool> methodDelegate82 = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate82;
      cp3.CanEnterEvent += methodDelegate82;
      // ISSUE: reference to a compiler-generated field
      UILinkPage cp4 = cDisplayClassdd.cp;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate83 == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate83 = new Action((object) null, __methodptr(\u003CLoad\u003Eb__a));
      }
      // ISSUE: reference to a compiler-generated field
      Action methodDelegate83 = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate83;
      cp4.EnterEvent += methodDelegate83;
      // ISSUE: reference to a compiler-generated field
      UILinkPage cp5 = cDisplayClassdd.cp;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate84 == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate84 = new Action((object) null, __methodptr(\u003CLoad\u003Eb__b));
      }
      // ISSUE: reference to a compiler-generated field
      Action methodDelegate84 = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate84;
      cp5.LeaveEvent += methodDelegate84;
      // ISSUE: reference to a compiler-generated field
      UILinkPointNavigator.RegisterPage(cDisplayClassdd.cp, 1003, true);
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      UILinksInitializer.\u003C\u003Ec__DisplayClassdf cDisplayClassdf = new UILinksInitializer.\u003C\u003Ec__DisplayClassdf();
      // ISSUE: reference to a compiler-generated field
      cDisplayClassdf.cp = new UILinkPage();
      // ISSUE: reference to a compiler-generated field
      UILinkPage cp6 = cDisplayClassdf.cp;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate85 == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate85 = new Func<string>((object) null, __methodptr(\u003CLoad\u003Eb__c));
      }
      // ISSUE: reference to a compiler-generated field
      Func<string> methodDelegate85 = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate85;
      cp6.OnSpecialInteracts += methodDelegate85;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate86 == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate86 = new Func<string>((object) null, __methodptr(\u003CLoad\u003Eb__d));
      }
      // ISSUE: reference to a compiler-generated field
      Func<string> methodDelegate86 = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate86;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate87 == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate87 = new Func<string>((object) null, __methodptr(\u003CLoad\u003Eb__e));
      }
      // ISSUE: reference to a compiler-generated field
      Func<string> methodDelegate87 = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate87;
      for (int index = 0; index <= 49; ++index)
      {
        UILinkPoint uiLinkPoint = new UILinkPoint(index, true, index - 1, index + 1, index - 10, index + 10);
        uiLinkPoint.OnSpecialInteracts += methodDelegate86;
        int num = index;
        if (num < 10)
          uiLinkPoint.Up = -1;
        if (num >= 40)
          uiLinkPoint.Down = -2;
        if (num % 10 == 9)
          uiLinkPoint.Right = -4;
        if (num % 10 == 0)
          uiLinkPoint.Left = -3;
        // ISSUE: reference to a compiler-generated field
        cDisplayClassdf.cp.LinkMap.Add(index, uiLinkPoint);
      }
      // ISSUE: reference to a compiler-generated field
      cDisplayClassdf.cp.LinkMap[9].Right = 0;
      // ISSUE: reference to a compiler-generated field
      cDisplayClassdf.cp.LinkMap[19].Right = 50;
      // ISSUE: reference to a compiler-generated field
      cDisplayClassdf.cp.LinkMap[29].Right = 51;
      // ISSUE: reference to a compiler-generated field
      cDisplayClassdf.cp.LinkMap[39].Right = 52;
      // ISSUE: reference to a compiler-generated field
      cDisplayClassdf.cp.LinkMap[49].Right = 53;
      // ISSUE: reference to a compiler-generated field
      cDisplayClassdf.cp.LinkMap[0].Left = 9;
      // ISSUE: reference to a compiler-generated field
      cDisplayClassdf.cp.LinkMap[10].Left = 54;
      // ISSUE: reference to a compiler-generated field
      cDisplayClassdf.cp.LinkMap[20].Left = 55;
      // ISSUE: reference to a compiler-generated field
      cDisplayClassdf.cp.LinkMap[30].Left = 56;
      // ISSUE: reference to a compiler-generated field
      cDisplayClassdf.cp.LinkMap[40].Left = 57;
      // ISSUE: reference to a compiler-generated field
      cDisplayClassdf.cp.LinkMap.Add(300, new UILinkPoint(300, true, 302, 301, 49, -2));
      // ISSUE: reference to a compiler-generated field
      cDisplayClassdf.cp.LinkMap.Add(301, new UILinkPoint(301, true, 300, 302, 53, 50));
      // ISSUE: reference to a compiler-generated field
      cDisplayClassdf.cp.LinkMap.Add(302, new UILinkPoint(302, true, 301, 300, 57, 54));
      // ISSUE: reference to a compiler-generated field
      cDisplayClassdf.cp.LinkMap[301].OnSpecialInteracts += methodDelegate7a;
      // ISSUE: reference to a compiler-generated field
      cDisplayClassdf.cp.LinkMap[302].OnSpecialInteracts += methodDelegate7a;
      // ISSUE: reference to a compiler-generated field
      cDisplayClassdf.cp.LinkMap[300].OnSpecialInteracts += methodDelegate87;
      // ISSUE: reference to a compiler-generated field
      // ISSUE: method pointer
      cDisplayClassdf.cp.UpdateEvent += new Action((object) cDisplayClassdf, __methodptr(\u003CLoad\u003Eb__f));
      // ISSUE: reference to a compiler-generated field
      UILinkPage cp7 = cDisplayClassdf.cp;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate88 == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate88 = new Func<bool>((object) null, __methodptr(\u003CLoad\u003Eb__10));
      }
      // ISSUE: reference to a compiler-generated field
      Func<bool> methodDelegate88 = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate88;
      cp7.IsValidEvent += methodDelegate88;
      // ISSUE: reference to a compiler-generated field
      cDisplayClassdf.cp.PageOnLeft = 9;
      // ISSUE: reference to a compiler-generated field
      cDisplayClassdf.cp.PageOnRight = 2;
      // ISSUE: reference to a compiler-generated field
      UILinkPointNavigator.RegisterPage(cDisplayClassdf.cp, 0, true);
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      UILinksInitializer.\u003C\u003Ec__DisplayClasse1 cDisplayClasse1 = new UILinksInitializer.\u003C\u003Ec__DisplayClasse1();
      // ISSUE: reference to a compiler-generated field
      cDisplayClasse1.cp = new UILinkPage();
      // ISSUE: reference to a compiler-generated field
      UILinkPage cp8 = cDisplayClasse1.cp;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate89 == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate89 = new Func<string>((object) null, __methodptr(\u003CLoad\u003Eb__11));
      }
      // ISSUE: reference to a compiler-generated field
      Func<string> methodDelegate89 = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate89;
      cp8.OnSpecialInteracts += methodDelegate89;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate8a == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate8a = new Func<string>((object) null, __methodptr(\u003CLoad\u003Eb__12));
      }
      // ISSUE: reference to a compiler-generated field
      Func<string> methodDelegate8a = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate8a;
      for (int index = 50; index <= 53; ++index)
      {
        UILinkPoint uiLinkPoint = new UILinkPoint(index, true, -3, -4, index - 1, index + 1);
        uiLinkPoint.OnSpecialInteracts += methodDelegate8a;
        // ISSUE: reference to a compiler-generated field
        cDisplayClasse1.cp.LinkMap.Add(index, uiLinkPoint);
      }
      // ISSUE: reference to a compiler-generated field
      cDisplayClasse1.cp.LinkMap[50].Left = 19;
      // ISSUE: reference to a compiler-generated field
      cDisplayClasse1.cp.LinkMap[51].Left = 29;
      // ISSUE: reference to a compiler-generated field
      cDisplayClasse1.cp.LinkMap[52].Left = 39;
      // ISSUE: reference to a compiler-generated field
      cDisplayClasse1.cp.LinkMap[53].Left = 49;
      // ISSUE: reference to a compiler-generated field
      cDisplayClasse1.cp.LinkMap[50].Right = 54;
      // ISSUE: reference to a compiler-generated field
      cDisplayClasse1.cp.LinkMap[51].Right = 55;
      // ISSUE: reference to a compiler-generated field
      cDisplayClasse1.cp.LinkMap[52].Right = 56;
      // ISSUE: reference to a compiler-generated field
      cDisplayClasse1.cp.LinkMap[53].Right = 57;
      // ISSUE: reference to a compiler-generated field
      cDisplayClasse1.cp.LinkMap[50].Up = -1;
      // ISSUE: reference to a compiler-generated field
      cDisplayClasse1.cp.LinkMap[53].Down = -2;
      // ISSUE: reference to a compiler-generated field
      // ISSUE: method pointer
      cDisplayClasse1.cp.UpdateEvent += new Action((object) cDisplayClasse1, __methodptr(\u003CLoad\u003Eb__13));
      // ISSUE: reference to a compiler-generated field
      UILinkPage cp9 = cDisplayClasse1.cp;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate8b == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate8b = new Func<bool>((object) null, __methodptr(\u003CLoad\u003Eb__14));
      }
      // ISSUE: reference to a compiler-generated field
      Func<bool> methodDelegate8b = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate8b;
      cp9.IsValidEvent += methodDelegate8b;
      // ISSUE: reference to a compiler-generated field
      cDisplayClasse1.cp.PageOnLeft = 0;
      // ISSUE: reference to a compiler-generated field
      cDisplayClasse1.cp.PageOnRight = 2;
      // ISSUE: reference to a compiler-generated field
      UILinkPointNavigator.RegisterPage(cDisplayClasse1.cp, 1, true);
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      UILinksInitializer.\u003C\u003Ec__DisplayClasse3 cDisplayClasse3 = new UILinksInitializer.\u003C\u003Ec__DisplayClasse3();
      // ISSUE: reference to a compiler-generated field
      cDisplayClasse3.cp = new UILinkPage();
      // ISSUE: reference to a compiler-generated field
      UILinkPage cp10 = cDisplayClasse3.cp;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate8c == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate8c = new Func<string>((object) null, __methodptr(\u003CLoad\u003Eb__15));
      }
      // ISSUE: reference to a compiler-generated field
      Func<string> methodDelegate8c = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate8c;
      cp10.OnSpecialInteracts += methodDelegate8c;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate8d == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate8d = new Func<string>((object) null, __methodptr(\u003CLoad\u003Eb__16));
      }
      // ISSUE: reference to a compiler-generated field
      Func<string> methodDelegate8d = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate8d;
      for (int index = 54; index <= 57; ++index)
      {
        UILinkPoint uiLinkPoint = new UILinkPoint(index, true, -3, -4, index - 1, index + 1);
        uiLinkPoint.OnSpecialInteracts += methodDelegate8d;
        // ISSUE: reference to a compiler-generated field
        cDisplayClasse3.cp.LinkMap.Add(index, uiLinkPoint);
      }
      // ISSUE: reference to a compiler-generated field
      cDisplayClasse3.cp.LinkMap[54].Left = 50;
      // ISSUE: reference to a compiler-generated field
      cDisplayClasse3.cp.LinkMap[55].Left = 51;
      // ISSUE: reference to a compiler-generated field
      cDisplayClasse3.cp.LinkMap[56].Left = 52;
      // ISSUE: reference to a compiler-generated field
      cDisplayClasse3.cp.LinkMap[57].Left = 53;
      // ISSUE: reference to a compiler-generated field
      cDisplayClasse3.cp.LinkMap[54].Right = 10;
      // ISSUE: reference to a compiler-generated field
      cDisplayClasse3.cp.LinkMap[55].Right = 20;
      // ISSUE: reference to a compiler-generated field
      cDisplayClasse3.cp.LinkMap[56].Right = 30;
      // ISSUE: reference to a compiler-generated field
      cDisplayClasse3.cp.LinkMap[57].Right = 40;
      // ISSUE: reference to a compiler-generated field
      cDisplayClasse3.cp.LinkMap[54].Up = -1;
      // ISSUE: reference to a compiler-generated field
      cDisplayClasse3.cp.LinkMap[57].Down = -2;
      // ISSUE: reference to a compiler-generated field
      // ISSUE: method pointer
      cDisplayClasse3.cp.UpdateEvent += new Action((object) cDisplayClasse3, __methodptr(\u003CLoad\u003Eb__17));
      // ISSUE: reference to a compiler-generated field
      cDisplayClasse3.cp.PageOnLeft = 0;
      // ISSUE: reference to a compiler-generated field
      cDisplayClasse3.cp.PageOnRight = 8;
      // ISSUE: reference to a compiler-generated field
      UILinkPointNavigator.RegisterPage(cDisplayClasse3.cp, 2, true);
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      UILinksInitializer.\u003C\u003Ec__DisplayClasse5 cDisplayClasse5 = new UILinksInitializer.\u003C\u003Ec__DisplayClasse5();
      // ISSUE: reference to a compiler-generated field
      cDisplayClasse5.cp = new UILinkPage();
      // ISSUE: reference to a compiler-generated field
      UILinkPage cp11 = cDisplayClasse5.cp;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate8e == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate8e = new Func<string>((object) null, __methodptr(\u003CLoad\u003Eb__18));
      }
      // ISSUE: reference to a compiler-generated field
      Func<string> methodDelegate8e = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate8e;
      cp11.OnSpecialInteracts += methodDelegate8e;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate8f == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate8f = new Func<string>((object) null, __methodptr(\u003CLoad\u003Eb__19));
      }
      // ISSUE: reference to a compiler-generated field
      Func<string> methodDelegate8f = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate8f;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate90 == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate90 = new Func<string>((object) null, __methodptr(\u003CLoad\u003Eb__1a));
      }
      // ISSUE: reference to a compiler-generated field
      Func<string> methodDelegate90 = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate90;
      for (int index = 100; index <= 119; ++index)
      {
        UILinkPoint uiLinkPoint = new UILinkPoint(index, true, index + 10, index - 10, index - 1, index + 1);
        uiLinkPoint.OnSpecialInteracts += methodDelegate8f;
        int num = index - 100;
        if (num == 0)
          uiLinkPoint.Up = 305;
        if (num == 10)
          uiLinkPoint.Up = 306;
        if (num == 9 || num == 19)
          uiLinkPoint.Down = -2;
        if (num >= 10)
          uiLinkPoint.Left = 120 + num % 10;
        else
          uiLinkPoint.Right = -4;
        // ISSUE: reference to a compiler-generated field
        cDisplayClasse5.cp.LinkMap.Add(index, uiLinkPoint);
      }
      for (int index = 120; index <= 129; ++index)
      {
        UILinkPoint uiLinkPoint = new UILinkPoint(index, true, -3, index - 10, index - 1, index + 1);
        uiLinkPoint.OnSpecialInteracts += methodDelegate90;
        int num = index - 120;
        if (num == 0)
          uiLinkPoint.Up = 307;
        if (num == 9)
        {
          uiLinkPoint.Down = 308;
          uiLinkPoint.Left = 1557;
        }
        // ISSUE: reference to a compiler-generated field
        cDisplayClasse5.cp.LinkMap.Add(index, uiLinkPoint);
      }
      // ISSUE: reference to a compiler-generated field
      UILinkPage cp12 = cDisplayClasse5.cp;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate91 == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate91 = new Func<bool>((object) null, __methodptr(\u003CLoad\u003Eb__1b));
      }
      // ISSUE: reference to a compiler-generated field
      Func<bool> methodDelegate91 = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate91;
      cp12.IsValidEvent += methodDelegate91;
      // ISSUE: reference to a compiler-generated field
      // ISSUE: method pointer
      cDisplayClasse5.cp.UpdateEvent += new Action((object) cDisplayClasse5, __methodptr(\u003CLoad\u003Eb__1c));
      // ISSUE: reference to a compiler-generated field
      cDisplayClasse5.cp.PageOnLeft = 8;
      // ISSUE: reference to a compiler-generated field
      cDisplayClasse5.cp.PageOnRight = 8;
      // ISSUE: reference to a compiler-generated field
      UILinkPointNavigator.RegisterPage(cDisplayClasse5.cp, 3, true);
      UILinkPage page2 = new UILinkPage();
      UILinkPage uiLinkPage6 = page2;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate92 == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate92 = new Func<string>((object) null, __methodptr(\u003CLoad\u003Eb__1d));
      }
      // ISSUE: reference to a compiler-generated field
      Func<string> methodDelegate92 = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate92;
      uiLinkPage6.OnSpecialInteracts += methodDelegate92;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate93 == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate93 = new Func<string>((object) null, __methodptr(\u003CLoad\u003Eb__1e));
      }
      // ISSUE: reference to a compiler-generated field
      Func<string> methodDelegate93 = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate93;
      for (int index = 400; index <= 439; ++index)
      {
        UILinkPoint uiLinkPoint = new UILinkPoint(index, true, index - 1, index + 1, index - 10, index + 10);
        uiLinkPoint.OnSpecialInteracts += methodDelegate93;
        int num = index - 400;
        if (num < 10)
          uiLinkPoint.Up = 40 + num;
        if (num >= 30)
          uiLinkPoint.Down = -2;
        if (num % 10 == 9)
          uiLinkPoint.Right = -4;
        if (num % 10 == 0)
          uiLinkPoint.Left = -3;
        page2.LinkMap.Add(index, uiLinkPoint);
      }
      page2.LinkMap.Add(500, new UILinkPoint(500, true, 409, -4, 53, 501));
      page2.LinkMap.Add(501, new UILinkPoint(501, true, 419, -4, 500, 502));
      page2.LinkMap.Add(502, new UILinkPoint(502, true, 429, -4, 501, 503));
      page2.LinkMap.Add(503, new UILinkPoint(503, true, 439, -4, 502, 505));
      page2.LinkMap.Add(505, new UILinkPoint(505, true, 439, -4, 503, 504));
      page2.LinkMap.Add(504, new UILinkPoint(504, true, 439, -4, 505, 50));
      page2.LinkMap[500].OnSpecialInteracts += methodDelegate7a;
      page2.LinkMap[501].OnSpecialInteracts += methodDelegate7a;
      page2.LinkMap[502].OnSpecialInteracts += methodDelegate7a;
      page2.LinkMap[503].OnSpecialInteracts += methodDelegate7a;
      page2.LinkMap[504].OnSpecialInteracts += methodDelegate7a;
      page2.LinkMap[505].OnSpecialInteracts += methodDelegate7a;
      page2.LinkMap[409].Right = 500;
      page2.LinkMap[419].Right = 501;
      page2.LinkMap[429].Right = 502;
      page2.LinkMap[439].Right = 503;
      page2.LinkMap[439].Down = 300;
      page2.PageOnLeft = 0;
      page2.PageOnRight = 0;
      page2.DefaultPoint = 500;
      UILinkPointNavigator.RegisterPage(page2, 4, false);
      UILinkPage uiLinkPage7 = page2;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate94 == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate94 = new Func<bool>((object) null, __methodptr(\u003CLoad\u003Eb__1f));
      }
      // ISSUE: reference to a compiler-generated field
      Func<bool> methodDelegate94 = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate94;
      uiLinkPage7.IsValidEvent += methodDelegate94;
      UILinkPage page3 = new UILinkPage();
      UILinkPage uiLinkPage8 = page3;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate95 == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate95 = new Func<string>((object) null, __methodptr(\u003CLoad\u003Eb__20));
      }
      // ISSUE: reference to a compiler-generated field
      Func<string> methodDelegate95 = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate95;
      uiLinkPage8.OnSpecialInteracts += methodDelegate95;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate96 == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate96 = new Func<string>((object) null, __methodptr(\u003CLoad\u003Eb__21));
      }
      // ISSUE: reference to a compiler-generated field
      Func<string> methodDelegate96 = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate96;
      for (int index = 2700; index <= 2739; ++index)
      {
        UILinkPoint uiLinkPoint = new UILinkPoint(index, true, index - 1, index + 1, index - 10, index + 10);
        uiLinkPoint.OnSpecialInteracts += methodDelegate96;
        int num = index - 2700;
        if (num < 10)
          uiLinkPoint.Up = 40 + num;
        if (num >= 30)
          uiLinkPoint.Down = -2;
        if (num % 10 == 9)
          uiLinkPoint.Right = -4;
        if (num % 10 == 0)
          uiLinkPoint.Left = -3;
        page3.LinkMap.Add(index, uiLinkPoint);
      }
      page3.LinkMap[2739].Down = 300;
      page3.PageOnLeft = 0;
      page3.PageOnRight = 0;
      UILinkPointNavigator.RegisterPage(page3, 13, true);
      UILinkPage uiLinkPage9 = page3;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate97 == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate97 = new Func<bool>((object) null, __methodptr(\u003CLoad\u003Eb__22));
      }
      // ISSUE: reference to a compiler-generated field
      Func<bool> methodDelegate97 = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate97;
      uiLinkPage9.IsValidEvent += methodDelegate97;
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      UILinksInitializer.\u003C\u003Ec__DisplayClasse7 cDisplayClasse7 = new UILinksInitializer.\u003C\u003Ec__DisplayClasse7();
      // ISSUE: reference to a compiler-generated field
      cDisplayClasse7.cp = new UILinkPage();
      // ISSUE: reference to a compiler-generated field
      cDisplayClasse7.cp.LinkMap.Add(303, new UILinkPoint(303, true, 304, 304, 40, -2));
      // ISSUE: reference to a compiler-generated field
      cDisplayClasse7.cp.LinkMap.Add(304, new UILinkPoint(304, true, 303, 303, 40, -2));
      // ISSUE: reference to a compiler-generated field
      UILinkPage cp13 = cDisplayClasse7.cp;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate98 == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate98 = new Func<string>((object) null, __methodptr(\u003CLoad\u003Eb__23));
      }
      // ISSUE: reference to a compiler-generated field
      Func<string> methodDelegate98 = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate98;
      cp13.OnSpecialInteracts += methodDelegate98;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate99 == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate99 = new Func<string>((object) null, __methodptr(\u003CLoad\u003Eb__24));
      }
      // ISSUE: reference to a compiler-generated field
      Func<string> methodDelegate99 = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate99;
      // ISSUE: reference to a compiler-generated field
      cDisplayClasse7.cp.LinkMap[303].OnSpecialInteracts += methodDelegate99;
      // ISSUE: reference to a compiler-generated field
      UILinkPoint link = cDisplayClasse7.cp.LinkMap[304];
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate9a == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate9a = new Func<string>((object) null, __methodptr(\u003CLoad\u003Eb__25));
      }
      // ISSUE: reference to a compiler-generated field
      Func<string> methodDelegate9a = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate9a;
      link.OnSpecialInteracts += methodDelegate9a;
      // ISSUE: reference to a compiler-generated field
      // ISSUE: method pointer
      cDisplayClasse7.cp.UpdateEvent += new Action((object) cDisplayClasse7, __methodptr(\u003CLoad\u003Eb__26));
      // ISSUE: reference to a compiler-generated field
      UILinkPage cp14 = cDisplayClasse7.cp;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate9b == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate9b = new Func<bool>((object) null, __methodptr(\u003CLoad\u003Eb__27));
      }
      // ISSUE: reference to a compiler-generated field
      Func<bool> methodDelegate9b = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate9b;
      cp14.IsValidEvent += methodDelegate9b;
      // ISSUE: reference to a compiler-generated field
      cDisplayClasse7.cp.PageOnLeft = 0;
      // ISSUE: reference to a compiler-generated field
      cDisplayClasse7.cp.PageOnRight = 0;
      // ISSUE: reference to a compiler-generated field
      UILinkPointNavigator.RegisterPage(cDisplayClasse7.cp, 5, true);
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      UILinksInitializer.\u003C\u003Ec__DisplayClasse9 cDisplayClasse9 = new UILinksInitializer.\u003C\u003Ec__DisplayClasse9();
      // ISSUE: reference to a compiler-generated field
      cDisplayClasse9.cp = new UILinkPage();
      // ISSUE: reference to a compiler-generated field
      UILinkPage cp15 = cDisplayClasse9.cp;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate9c == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate9c = new Func<string>((object) null, __methodptr(\u003CLoad\u003Eb__28));
      }
      // ISSUE: reference to a compiler-generated field
      Func<string> methodDelegate9c = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate9c;
      cp15.OnSpecialInteracts += methodDelegate9c;
      for (int index = 600; index <= 650; ++index)
      {
        UILinkPoint uiLinkPoint = new UILinkPoint(index, true, index + 10, index - 10, index - 1, index + 1);
        // ISSUE: reference to a compiler-generated field
        cDisplayClasse9.cp.LinkMap.Add(index, uiLinkPoint);
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: method pointer
      cDisplayClasse9.cp.UpdateEvent += new Action((object) cDisplayClasse9, __methodptr(\u003CLoad\u003Eb__29));
      // ISSUE: reference to a compiler-generated field
      UILinkPage cp16 = cDisplayClasse9.cp;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate9d == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate9d = new Func<bool>((object) null, __methodptr(\u003CLoad\u003Eb__2a));
      }
      // ISSUE: reference to a compiler-generated field
      Func<bool> methodDelegate9d = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate9d;
      cp16.IsValidEvent += methodDelegate9d;
      // ISSUE: reference to a compiler-generated field
      cDisplayClasse9.cp.PageOnLeft = 8;
      // ISSUE: reference to a compiler-generated field
      cDisplayClasse9.cp.PageOnRight = 8;
      // ISSUE: reference to a compiler-generated field
      UILinkPointNavigator.RegisterPage(cDisplayClasse9.cp, 6, true);
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      UILinksInitializer.\u003C\u003Ec__DisplayClasseb cDisplayClasseb = new UILinksInitializer.\u003C\u003Ec__DisplayClasseb();
      // ISSUE: reference to a compiler-generated field
      cDisplayClasseb.cp = new UILinkPage();
      // ISSUE: reference to a compiler-generated field
      UILinkPage cp17 = cDisplayClasseb.cp;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate9e == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate9e = new Func<string>((object) null, __methodptr(\u003CLoad\u003Eb__2b));
      }
      // ISSUE: reference to a compiler-generated field
      Func<string> methodDelegate9e = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate9e;
      cp17.OnSpecialInteracts += methodDelegate9e;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate9f == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate9f = new Func<string>((object) null, __methodptr(\u003CLoad\u003Eb__2c));
      }
      // ISSUE: reference to a compiler-generated field
      Func<string> methodDelegate9f = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate9f;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatea0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatea0 = new Func<string>((object) null, __methodptr(\u003CLoad\u003Eb__2d));
      }
      // ISSUE: reference to a compiler-generated field
      Func<string> methodDelegatea0 = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatea0;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatea1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatea1 = new Func<string>((object) null, __methodptr(\u003CLoad\u003Eb__2e));
      }
      // ISSUE: reference to a compiler-generated field
      Func<string> methodDelegatea1 = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatea1;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatea2 == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatea2 = new Func<string>((object) null, __methodptr(\u003CLoad\u003Eb__2f));
      }
      // ISSUE: reference to a compiler-generated field
      Func<string> methodDelegatea2 = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatea2;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatea3 == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatea3 = new Func<string>((object) null, __methodptr(\u003CLoad\u003Eb__30));
      }
      // ISSUE: reference to a compiler-generated field
      Func<string> methodDelegatea3 = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatea3;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatea4 == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatea4 = new Func<string>((object) null, __methodptr(\u003CLoad\u003Eb__31));
      }
      // ISSUE: reference to a compiler-generated field
      Func<string> methodDelegatea4 = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatea4;
      for (int index = 180; index <= 184; ++index)
      {
        UILinkPoint uiLinkPoint = new UILinkPoint(index, true, 185 + index - 180, -4, index - 1, index + 1);
        int num = index - 180;
        if (num == 0)
          uiLinkPoint.Up = 305;
        if (num == 4)
          uiLinkPoint.Down = 308;
        // ISSUE: reference to a compiler-generated field
        cDisplayClasseb.cp.LinkMap.Add(index, uiLinkPoint);
        switch (index)
        {
          case 180:
            uiLinkPoint.OnSpecialInteracts += methodDelegatea0;
            break;
          case 181:
            uiLinkPoint.OnSpecialInteracts += methodDelegate9f;
            break;
          case 182:
            uiLinkPoint.OnSpecialInteracts += methodDelegatea1;
            break;
          case 183:
            uiLinkPoint.OnSpecialInteracts += methodDelegatea2;
            break;
          case 184:
            uiLinkPoint.OnSpecialInteracts += methodDelegatea3;
            break;
        }
      }
      for (int index = 185; index <= 189; ++index)
      {
        UILinkPoint uiLinkPoint = new UILinkPoint(index, true, -3, index - 5, index - 1, index + 1);
        uiLinkPoint.OnSpecialInteracts += methodDelegatea4;
        int num = index - 185;
        if (num == 0)
          uiLinkPoint.Up = 306;
        if (num == 4)
          uiLinkPoint.Down = 308;
        // ISSUE: reference to a compiler-generated field
        cDisplayClasseb.cp.LinkMap.Add(index, uiLinkPoint);
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: method pointer
      cDisplayClasseb.cp.UpdateEvent += new Action((object) cDisplayClasseb, __methodptr(\u003CLoad\u003Eb__32));
      // ISSUE: reference to a compiler-generated field
      UILinkPage cp18 = cDisplayClasseb.cp;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatea5 == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatea5 = new Func<bool>((object) null, __methodptr(\u003CLoad\u003Eb__33));
      }
      // ISSUE: reference to a compiler-generated field
      Func<bool> methodDelegatea5 = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatea5;
      cp18.IsValidEvent += methodDelegatea5;
      // ISSUE: reference to a compiler-generated field
      cDisplayClasseb.cp.PageOnLeft = 8;
      // ISSUE: reference to a compiler-generated field
      cDisplayClasseb.cp.PageOnRight = 8;
      // ISSUE: reference to a compiler-generated field
      UILinkPointNavigator.RegisterPage(cDisplayClasseb.cp, 7, true);
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      UILinksInitializer.\u003C\u003Ec__DisplayClassed cDisplayClassed = new UILinksInitializer.\u003C\u003Ec__DisplayClassed();
      // ISSUE: reference to a compiler-generated field
      cDisplayClassed.cp = new UILinkPage();
      // ISSUE: reference to a compiler-generated field
      UILinkPage cp19 = cDisplayClassed.cp;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatea6 == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatea6 = new Func<string>((object) null, __methodptr(\u003CLoad\u003Eb__34));
      }
      // ISSUE: reference to a compiler-generated field
      Func<string> methodDelegatea6 = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatea6;
      cp19.OnSpecialInteracts += methodDelegatea6;
      // ISSUE: reference to a compiler-generated field
      cDisplayClassed.cp.LinkMap.Add(305, new UILinkPoint(305, true, 306, -4, 308, -2));
      // ISSUE: reference to a compiler-generated field
      cDisplayClassed.cp.LinkMap.Add(306, new UILinkPoint(306, true, 307, 305, 308, -2));
      // ISSUE: reference to a compiler-generated field
      cDisplayClassed.cp.LinkMap.Add(307, new UILinkPoint(307, true, -3, 306, 308, -2));
      // ISSUE: reference to a compiler-generated field
      cDisplayClassed.cp.LinkMap.Add(308, new UILinkPoint(308, true, -3, -4, -1, 305));
      // ISSUE: reference to a compiler-generated field
      cDisplayClassed.cp.LinkMap[305].OnSpecialInteracts += methodDelegate7a;
      // ISSUE: reference to a compiler-generated field
      cDisplayClassed.cp.LinkMap[306].OnSpecialInteracts += methodDelegate7a;
      // ISSUE: reference to a compiler-generated field
      cDisplayClassed.cp.LinkMap[307].OnSpecialInteracts += methodDelegate7a;
      // ISSUE: reference to a compiler-generated field
      cDisplayClassed.cp.LinkMap[308].OnSpecialInteracts += methodDelegate7a;
      // ISSUE: reference to a compiler-generated field
      // ISSUE: method pointer
      cDisplayClassed.cp.UpdateEvent += new Action((object) cDisplayClassed, __methodptr(\u003CLoad\u003Eb__35));
      // ISSUE: reference to a compiler-generated field
      UILinkPage cp20 = cDisplayClassed.cp;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatea7 == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatea7 = new Func<bool>((object) null, __methodptr(\u003CLoad\u003Eb__36));
      }
      // ISSUE: reference to a compiler-generated field
      Func<bool> methodDelegatea7 = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatea7;
      cp20.IsValidEvent += methodDelegatea7;
      // ISSUE: reference to a compiler-generated field
      cDisplayClassed.cp.PageOnLeft = 0;
      // ISSUE: reference to a compiler-generated field
      cDisplayClassed.cp.PageOnRight = 0;
      // ISSUE: reference to a compiler-generated field
      UILinkPointNavigator.RegisterPage(cDisplayClassed.cp, 8, true);
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      UILinksInitializer.\u003C\u003Ec__DisplayClassef cDisplayClassef = new UILinksInitializer.\u003C\u003Ec__DisplayClassef();
      // ISSUE: reference to a compiler-generated field
      cDisplayClassef.cp = new UILinkPage();
      // ISSUE: reference to a compiler-generated field
      UILinkPage cp21 = cDisplayClassef.cp;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatea8 == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatea8 = new Func<string>((object) null, __methodptr(\u003CLoad\u003Eb__37));
      }
      // ISSUE: reference to a compiler-generated field
      Func<string> methodDelegatea8 = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatea8;
      cp21.OnSpecialInteracts += methodDelegatea8;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatea9 == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatea9 = new Func<string>((object) null, __methodptr(\u003CLoad\u003Eb__38));
      }
      // ISSUE: reference to a compiler-generated field
      Func<string> methodDelegatea9 = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatea9;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegateaa == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegateaa = new Func<string>((object) null, __methodptr(\u003CLoad\u003Eb__39));
      }
      // ISSUE: reference to a compiler-generated field
      Func<string> methodDelegateaa = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegateaa;
      // ISSUE: reference to a compiler-generated field
      cDisplayClassef.HandleItem2 = methodDelegateaa;
      for (int index = 1500; index < 1550; ++index)
      {
        UILinkPoint uiLinkPoint = new UILinkPoint(index, true, index, index, -1, -2);
        if (index != 1500)
        {
          // ISSUE: reference to a compiler-generated field
          uiLinkPoint.OnSpecialInteracts += cDisplayClassef.HandleItem2;
        }
        // ISSUE: reference to a compiler-generated field
        cDisplayClassef.cp.LinkMap.Add(index, uiLinkPoint);
      }
      // ISSUE: reference to a compiler-generated field
      cDisplayClassef.cp.LinkMap[1500].OnSpecialInteracts += methodDelegatea9;
      // ISSUE: reference to a compiler-generated field
      // ISSUE: method pointer
      cDisplayClassef.cp.UpdateEvent += new Action((object) cDisplayClassef, __methodptr(\u003CLoad\u003Eb__3a));
      // ISSUE: reference to a compiler-generated field
      // ISSUE: method pointer
      cDisplayClassef.cp.LinkMap[1501].OnSpecialInteracts += new Func<string>((object) cDisplayClassef, __methodptr(\u003CLoad\u003Eb__3b));
      // ISSUE: reference to a compiler-generated field
      UILinkPage cp22 = cDisplayClassef.cp;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegateab == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegateab = new Action<int, int>((object) null, __methodptr(\u003CLoad\u003Eb__3c));
      }
      // ISSUE: reference to a compiler-generated field
      Action<int, int> methodDelegateab = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegateab;
      cp22.ReachEndEvent += methodDelegateab;
      // ISSUE: reference to a compiler-generated field
      UILinkPage cp23 = cDisplayClassef.cp;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegateac == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegateac = new Action((object) null, __methodptr(\u003CLoad\u003Eb__3d));
      }
      // ISSUE: reference to a compiler-generated field
      Action methodDelegateac = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegateac;
      cp23.EnterEvent += methodDelegateac;
      // ISSUE: reference to a compiler-generated field
      UILinkPage cp24 = cDisplayClassef.cp;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatead == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatead = new Func<bool>((object) null, __methodptr(\u003CLoad\u003Eb__3e));
      }
      // ISSUE: reference to a compiler-generated field
      Func<bool> methodDelegatead = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatead;
      cp24.CanEnterEvent += methodDelegatead;
      // ISSUE: reference to a compiler-generated field
      UILinkPage cp25 = cDisplayClassef.cp;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegateae == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegateae = new Func<bool>((object) null, __methodptr(\u003CLoad\u003Eb__3f));
      }
      // ISSUE: reference to a compiler-generated field
      Func<bool> methodDelegateae = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegateae;
      cp25.IsValidEvent += methodDelegateae;
      // ISSUE: reference to a compiler-generated field
      cDisplayClassef.cp.PageOnLeft = 10;
      // ISSUE: reference to a compiler-generated field
      cDisplayClassef.cp.PageOnRight = 0;
      // ISSUE: reference to a compiler-generated field
      UILinkPointNavigator.RegisterPage(cDisplayClassef.cp, 9, true);
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      UILinksInitializer.\u003C\u003Ec__DisplayClassf1 cDisplayClassf1 = new UILinksInitializer.\u003C\u003Ec__DisplayClassf1();
      // ISSUE: reference to a compiler-generated field
      cDisplayClassf1.cp = new UILinkPage();
      // ISSUE: reference to a compiler-generated field
      UILinkPage cp26 = cDisplayClassf1.cp;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegateaf == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegateaf = new Func<string>((object) null, __methodptr(\u003CLoad\u003Eb__40));
      }
      // ISSUE: reference to a compiler-generated field
      Func<string> methodDelegateaf = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegateaf;
      cp26.OnSpecialInteracts += methodDelegateaf;
      for (int index = 700; index < 1500; ++index)
      {
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: variable of a compiler-generated type
        UILinksInitializer.\u003C\u003Ec__DisplayClassf3 cDisplayClassf3 = new UILinksInitializer.\u003C\u003Ec__DisplayClassf3();
        // ISSUE: reference to a compiler-generated field
        cDisplayClassf3.CS\u0024\u003C\u003E8__localsf2 = cDisplayClassf1;
        UILinkPoint uiLinkPoint = new UILinkPoint(index, true, index, index, index, index);
        // ISSUE: reference to a compiler-generated field
        cDisplayClassf3.IHateLambda = index;
        // ISSUE: method pointer
        uiLinkPoint.OnSpecialInteracts += new Func<string>((object) cDisplayClassf3, __methodptr(\u003CLoad\u003Eb__41));
        // ISSUE: reference to a compiler-generated field
        cDisplayClassf1.cp.LinkMap.Add(index, uiLinkPoint);
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: method pointer
      cDisplayClassf1.cp.UpdateEvent += new Action((object) cDisplayClassf1, __methodptr(\u003CLoad\u003Eb__42));
      // ISSUE: reference to a compiler-generated field
      UILinkPage cp27 = cDisplayClassf1.cp;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegateb0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegateb0 = new Action<int, int>((object) null, __methodptr(\u003CLoad\u003Eb__43));
      }
      // ISSUE: reference to a compiler-generated field
      Action<int, int> methodDelegateb0 = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegateb0;
      cp27.ReachEndEvent += methodDelegateb0;
      // ISSUE: reference to a compiler-generated field
      UILinkPage cp28 = cDisplayClassf1.cp;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegateb1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegateb1 = new Action((object) null, __methodptr(\u003CLoad\u003Eb__44));
      }
      // ISSUE: reference to a compiler-generated field
      Action methodDelegateb1 = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegateb1;
      cp28.EnterEvent += methodDelegateb1;
      // ISSUE: reference to a compiler-generated field
      UILinkPage cp29 = cDisplayClassf1.cp;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegateb2 == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegateb2 = new Action((object) null, __methodptr(\u003CLoad\u003Eb__45));
      }
      // ISSUE: reference to a compiler-generated field
      Action methodDelegateb2 = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegateb2;
      cp29.LeaveEvent += methodDelegateb2;
      // ISSUE: reference to a compiler-generated field
      UILinkPage cp30 = cDisplayClassf1.cp;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegateb3 == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegateb3 = new Func<bool>((object) null, __methodptr(\u003CLoad\u003Eb__46));
      }
      // ISSUE: reference to a compiler-generated field
      Func<bool> methodDelegateb3 = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegateb3;
      cp30.CanEnterEvent += methodDelegateb3;
      // ISSUE: reference to a compiler-generated field
      UILinkPage cp31 = cDisplayClassf1.cp;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegateb4 == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegateb4 = new Func<bool>((object) null, __methodptr(\u003CLoad\u003Eb__47));
      }
      // ISSUE: reference to a compiler-generated field
      Func<bool> methodDelegateb4 = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegateb4;
      cp31.IsValidEvent += methodDelegateb4;
      // ISSUE: reference to a compiler-generated field
      cDisplayClassf1.cp.PageOnLeft = 0;
      // ISSUE: reference to a compiler-generated field
      cDisplayClassf1.cp.PageOnRight = 9;
      // ISSUE: reference to a compiler-generated field
      UILinkPointNavigator.RegisterPage(cDisplayClassf1.cp, 10, true);
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      UILinksInitializer.\u003C\u003Ec__DisplayClassf5 cDisplayClassf5 = new UILinksInitializer.\u003C\u003Ec__DisplayClassf5();
      // ISSUE: reference to a compiler-generated field
      cDisplayClassf5.cp = new UILinkPage();
      // ISSUE: reference to a compiler-generated field
      UILinkPage cp32 = cDisplayClassf5.cp;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegateb5 == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegateb5 = new Func<string>((object) null, __methodptr(\u003CLoad\u003Eb__48));
      }
      // ISSUE: reference to a compiler-generated field
      Func<string> methodDelegateb5 = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegateb5;
      cp32.OnSpecialInteracts += methodDelegateb5;
      for (int index = 2605; index < 2620; ++index)
      {
        UILinkPoint uiLinkPoint1 = new UILinkPoint(index, true, index, index, index, index);
        UILinkPoint uiLinkPoint2 = uiLinkPoint1;
        // ISSUE: reference to a compiler-generated field
        if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegateb6 == null)
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: method pointer
          UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegateb6 = new Func<string>((object) null, __methodptr(\u003CLoad\u003Eb__49));
        }
        // ISSUE: reference to a compiler-generated field
        Func<string> methodDelegateb6 = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegateb6;
        uiLinkPoint2.OnSpecialInteracts += methodDelegateb6;
        // ISSUE: reference to a compiler-generated field
        cDisplayClassf5.cp.LinkMap.Add(index, uiLinkPoint1);
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: method pointer
      cDisplayClassf5.cp.UpdateEvent += new Action((object) cDisplayClassf5, __methodptr(\u003CLoad\u003Eb__4a));
      // ISSUE: reference to a compiler-generated field
      UILinkPage cp33 = cDisplayClassf5.cp;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegateb7 == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegateb7 = new Action<int, int>((object) null, __methodptr(\u003CLoad\u003Eb__4b));
      }
      // ISSUE: reference to a compiler-generated field
      Action<int, int> methodDelegateb7 = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegateb7;
      cp33.ReachEndEvent += methodDelegateb7;
      // ISSUE: reference to a compiler-generated field
      UILinkPage cp34 = cDisplayClassf5.cp;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegateb8 == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegateb8 = new Func<bool>((object) null, __methodptr(\u003CLoad\u003Eb__4c));
      }
      // ISSUE: reference to a compiler-generated field
      Func<bool> methodDelegateb8 = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegateb8;
      cp34.CanEnterEvent += methodDelegateb8;
      // ISSUE: reference to a compiler-generated field
      UILinkPage cp35 = cDisplayClassf5.cp;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegateb9 == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegateb9 = new Func<bool>((object) null, __methodptr(\u003CLoad\u003Eb__4d));
      }
      // ISSUE: reference to a compiler-generated field
      Func<bool> methodDelegateb9 = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegateb9;
      cp35.IsValidEvent += methodDelegateb9;
      // ISSUE: reference to a compiler-generated field
      cDisplayClassf5.cp.PageOnLeft = 12;
      // ISSUE: reference to a compiler-generated field
      cDisplayClassf5.cp.PageOnRight = 12;
      // ISSUE: reference to a compiler-generated field
      UILinkPointNavigator.RegisterPage(cDisplayClassf5.cp, 11, true);
      UILinkPage page4 = new UILinkPage();
      UILinkPage uiLinkPage10 = page4;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegateba == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegateba = new Func<string>((object) null, __methodptr(\u003CLoad\u003Eb__4e));
      }
      // ISSUE: reference to a compiler-generated field
      Func<string> methodDelegateba = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegateba;
      uiLinkPage10.OnSpecialInteracts += methodDelegateba;
      page4.LinkMap.Add(2600, new UILinkPoint(2600, true, -3, -4, -1, 2601));
      page4.LinkMap.Add(2601, new UILinkPoint(2601, true, -3, -4, 2600, 2602));
      page4.LinkMap.Add(2602, new UILinkPoint(2602, true, -3, -4, 2601, 2603));
      page4.LinkMap.Add(2603, new UILinkPoint(2603, true, -3, 2604, 2602, -2));
      page4.LinkMap.Add(2604, new UILinkPoint(2604, true, 2603, -4, 2602, -2));
      UILinkPage uiLinkPage11 = page4;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatebb == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatebb = new Action((object) null, __methodptr(\u003CLoad\u003Eb__4f));
      }
      // ISSUE: reference to a compiler-generated field
      Action methodDelegatebb = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatebb;
      uiLinkPage11.UpdateEvent += methodDelegatebb;
      UILinkPage uiLinkPage12 = page4;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatebc == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatebc = new Func<bool>((object) null, __methodptr(\u003CLoad\u003Eb__50));
      }
      // ISSUE: reference to a compiler-generated field
      Func<bool> methodDelegatebc = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatebc;
      uiLinkPage12.CanEnterEvent += methodDelegatebc;
      UILinkPage uiLinkPage13 = page4;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatebd == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatebd = new Func<bool>((object) null, __methodptr(\u003CLoad\u003Eb__51));
      }
      // ISSUE: reference to a compiler-generated field
      Func<bool> methodDelegatebd = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatebd;
      uiLinkPage13.IsValidEvent += methodDelegatebd;
      page4.PageOnLeft = 11;
      page4.PageOnRight = 11;
      UILinkPointNavigator.RegisterPage(page4, 12, true);
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      UILinksInitializer.\u003C\u003Ec__DisplayClassf7 cDisplayClassf7 = new UILinksInitializer.\u003C\u003Ec__DisplayClassf7();
      // ISSUE: reference to a compiler-generated field
      cDisplayClassf7.cp = new UILinkPage();
      for (int index = 0; index < 30; ++index)
      {
        // ISSUE: reference to a compiler-generated field
        cDisplayClassf7.cp.LinkMap.Add(2900 + index, new UILinkPoint(2900 + index, true, -3, -4, -1, -2));
        // ISSUE: reference to a compiler-generated field
        cDisplayClassf7.cp.LinkMap[2900 + index].OnSpecialInteracts += methodDelegate7a;
      }
      // ISSUE: reference to a compiler-generated field
      UILinkPage cp36 = cDisplayClassf7.cp;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatebe == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatebe = new Func<string>((object) null, __methodptr(\u003CLoad\u003Eb__52));
      }
      // ISSUE: reference to a compiler-generated field
      Func<string> methodDelegatebe = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatebe;
      cp36.OnSpecialInteracts += methodDelegatebe;
      // ISSUE: reference to a compiler-generated field
      // ISSUE: method pointer
      cDisplayClassf7.cp.TravelEvent += new Action((object) cDisplayClassf7, __methodptr(\u003CLoad\u003Eb__53));
      // ISSUE: reference to a compiler-generated field
      // ISSUE: method pointer
      cDisplayClassf7.cp.UpdateEvent += new Action((object) cDisplayClassf7, __methodptr(\u003CLoad\u003Eb__54));
      // ISSUE: reference to a compiler-generated field
      // ISSUE: method pointer
      cDisplayClassf7.cp.EnterEvent += new Action((object) cDisplayClassf7, __methodptr(\u003CLoad\u003Eb__55));
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      cDisplayClassf7.cp.PageOnLeft = cDisplayClassf7.cp.PageOnRight = 1002;
      // ISSUE: reference to a compiler-generated field
      UILinkPage cp37 = cDisplayClassf7.cp;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatebf == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatebf = new Func<bool>((object) null, __methodptr(\u003CLoad\u003Eb__56));
      }
      // ISSUE: reference to a compiler-generated field
      Func<bool> methodDelegatebf = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatebf;
      cp37.IsValidEvent += methodDelegatebf;
      // ISSUE: reference to a compiler-generated field
      UILinkPage cp38 = cDisplayClassf7.cp;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatec0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatec0 = new Func<bool>((object) null, __methodptr(\u003CLoad\u003Eb__57));
      }
      // ISSUE: reference to a compiler-generated field
      Func<bool> methodDelegatec0 = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatec0;
      cp38.CanEnterEvent += methodDelegatec0;
      // ISSUE: reference to a compiler-generated field
      UILinkPointNavigator.RegisterPage(cDisplayClassf7.cp, 1001, true);
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      UILinksInitializer.\u003C\u003Ec__DisplayClassf9 cDisplayClassf9 = new UILinksInitializer.\u003C\u003Ec__DisplayClassf9();
      // ISSUE: reference to a compiler-generated field
      cDisplayClassf9.cp = new UILinkPage();
      for (int index = 0; index < 30; ++index)
      {
        // ISSUE: reference to a compiler-generated field
        cDisplayClassf9.cp.LinkMap.Add(2930 + index, new UILinkPoint(2930 + index, true, -3, -4, -1, -2));
        // ISSUE: reference to a compiler-generated field
        cDisplayClassf9.cp.LinkMap[2930 + index].OnSpecialInteracts += methodDelegate7a;
      }
      // ISSUE: reference to a compiler-generated field
      UILinkPage cp39 = cDisplayClassf9.cp;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatec1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatec1 = new Func<string>((object) null, __methodptr(\u003CLoad\u003Eb__58));
      }
      // ISSUE: reference to a compiler-generated field
      Func<string> methodDelegatec1 = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatec1;
      cp39.OnSpecialInteracts += methodDelegatec1;
      // ISSUE: reference to a compiler-generated field
      // ISSUE: method pointer
      cDisplayClassf9.cp.UpdateEvent += new Action((object) cDisplayClassf9, __methodptr(\u003CLoad\u003Eb__59));
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      cDisplayClassf9.cp.PageOnLeft = cDisplayClassf9.cp.PageOnRight = 1001;
      // ISSUE: reference to a compiler-generated field
      UILinkPage cp40 = cDisplayClassf9.cp;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatec2 == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatec2 = new Func<bool>((object) null, __methodptr(\u003CLoad\u003Eb__5a));
      }
      // ISSUE: reference to a compiler-generated field
      Func<bool> methodDelegatec2 = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatec2;
      cp40.IsValidEvent += methodDelegatec2;
      // ISSUE: reference to a compiler-generated field
      UILinkPage cp41 = cDisplayClassf9.cp;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatec3 == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatec3 = new Func<bool>((object) null, __methodptr(\u003CLoad\u003Eb__5b));
      }
      // ISSUE: reference to a compiler-generated field
      Func<bool> methodDelegatec3 = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatec3;
      cp41.CanEnterEvent += methodDelegatec3;
      // ISSUE: reference to a compiler-generated field
      UILinkPointNavigator.RegisterPage(cDisplayClassf9.cp, 1002, true);
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      UILinksInitializer.\u003C\u003Ec__DisplayClassfb cDisplayClassfb = new UILinksInitializer.\u003C\u003Ec__DisplayClassfb();
      // ISSUE: reference to a compiler-generated field
      cDisplayClassfb.cp = new UILinkPage();
      // ISSUE: reference to a compiler-generated field
      UILinkPage cp42 = cDisplayClassfb.cp;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatec4 == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatec4 = new Func<string>((object) null, __methodptr(\u003CLoad\u003Eb__5c));
      }
      // ISSUE: reference to a compiler-generated field
      Func<string> methodDelegatec4 = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatec4;
      cp42.OnSpecialInteracts += methodDelegatec4;
      for (int index = 1550; index < 1558; ++index)
      {
        UILinkPoint uiLinkPoint = new UILinkPoint(index, true, -3, -4, -1, -2);
        switch (index - 1550)
        {
          case 1:
          case 3:
          case 5:
            uiLinkPoint.Up = uiLinkPoint.ID - 2;
            uiLinkPoint.Down = uiLinkPoint.ID + 2;
            uiLinkPoint.Right = uiLinkPoint.ID + 1;
            break;
          case 2:
          case 4:
          case 6:
            uiLinkPoint.Up = uiLinkPoint.ID - 2;
            uiLinkPoint.Down = uiLinkPoint.ID + 2;
            uiLinkPoint.Left = uiLinkPoint.ID - 1;
            break;
        }
        // ISSUE: reference to a compiler-generated field
        cDisplayClassfb.cp.LinkMap.Add(index, uiLinkPoint);
      }
      // ISSUE: reference to a compiler-generated field
      cDisplayClassfb.cp.LinkMap[1550].Down = 1551;
      // ISSUE: reference to a compiler-generated field
      cDisplayClassfb.cp.LinkMap[1550].Right = 120;
      // ISSUE: reference to a compiler-generated field
      cDisplayClassfb.cp.LinkMap[1550].Up = 307;
      // ISSUE: reference to a compiler-generated field
      cDisplayClassfb.cp.LinkMap[1551].Up = 1550;
      // ISSUE: reference to a compiler-generated field
      cDisplayClassfb.cp.LinkMap[1552].Up = 1550;
      // ISSUE: reference to a compiler-generated field
      cDisplayClassfb.cp.LinkMap[1552].Right = 121;
      // ISSUE: reference to a compiler-generated field
      cDisplayClassfb.cp.LinkMap[1554].Right = 121;
      // ISSUE: reference to a compiler-generated field
      cDisplayClassfb.cp.LinkMap[1555].Down = 1557;
      // ISSUE: reference to a compiler-generated field
      cDisplayClassfb.cp.LinkMap[1556].Down = 1557;
      // ISSUE: reference to a compiler-generated field
      cDisplayClassfb.cp.LinkMap[1556].Right = 122;
      // ISSUE: reference to a compiler-generated field
      cDisplayClassfb.cp.LinkMap[1557].Up = 1555;
      // ISSUE: reference to a compiler-generated field
      cDisplayClassfb.cp.LinkMap[1557].Down = 308;
      // ISSUE: reference to a compiler-generated field
      cDisplayClassfb.cp.LinkMap[1557].Right = (int) sbyte.MaxValue;
      for (int index = 0; index < 7; ++index)
      {
        // ISSUE: reference to a compiler-generated field
        cDisplayClassfb.cp.LinkMap[1550 + index].OnSpecialInteracts += methodDelegate7a;
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: method pointer
      cDisplayClassfb.cp.UpdateEvent += new Action((object) cDisplayClassfb, __methodptr(\u003CLoad\u003Eb__5d));
      // ISSUE: reference to a compiler-generated field
      UILinkPage cp43 = cDisplayClassfb.cp;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatec5 == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatec5 = new Func<bool>((object) null, __methodptr(\u003CLoad\u003Eb__5e));
      }
      // ISSUE: reference to a compiler-generated field
      Func<bool> methodDelegatec5 = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatec5;
      cp43.IsValidEvent += methodDelegatec5;
      // ISSUE: reference to a compiler-generated field
      cDisplayClassfb.cp.PageOnLeft = 8;
      // ISSUE: reference to a compiler-generated field
      cDisplayClassfb.cp.PageOnRight = 8;
      // ISSUE: reference to a compiler-generated field
      UILinkPointNavigator.RegisterPage(cDisplayClassfb.cp, 16, true);
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      UILinksInitializer.\u003C\u003Ec__DisplayClassfd cDisplayClassfd = new UILinksInitializer.\u003C\u003Ec__DisplayClassfd();
      // ISSUE: reference to a compiler-generated field
      cDisplayClassfd.cp = new UILinkPage();
      // ISSUE: reference to a compiler-generated field
      UILinkPage cp44 = cDisplayClassfd.cp;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatec6 == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatec6 = new Func<string>((object) null, __methodptr(\u003CLoad\u003Eb__5f));
      }
      // ISSUE: reference to a compiler-generated field
      Func<string> methodDelegatec6 = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatec6;
      cp44.OnSpecialInteracts += methodDelegatec6;
      for (int index = 1558; index < 1570; ++index)
      {
        UILinkPoint uiLinkPoint = new UILinkPoint(index, true, -3, -4, -1, -2);
        uiLinkPoint.OnSpecialInteracts += methodDelegate7a;
        switch (index - 1558)
        {
          case 1:
          case 3:
          case 5:
            uiLinkPoint.Up = uiLinkPoint.ID - 2;
            uiLinkPoint.Down = uiLinkPoint.ID + 2;
            uiLinkPoint.Right = uiLinkPoint.ID + 1;
            break;
          case 2:
          case 4:
          case 6:
            uiLinkPoint.Up = uiLinkPoint.ID - 2;
            uiLinkPoint.Down = uiLinkPoint.ID + 2;
            uiLinkPoint.Left = uiLinkPoint.ID - 1;
            break;
        }
        // ISSUE: reference to a compiler-generated field
        cDisplayClassfd.cp.LinkMap.Add(index, uiLinkPoint);
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: method pointer
      cDisplayClassfd.cp.UpdateEvent += new Action((object) cDisplayClassfd, __methodptr(\u003CLoad\u003Eb__60));
      // ISSUE: reference to a compiler-generated field
      UILinkPage cp45 = cDisplayClassfd.cp;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatec7 == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatec7 = new Func<bool>((object) null, __methodptr(\u003CLoad\u003Eb__61));
      }
      // ISSUE: reference to a compiler-generated field
      Func<bool> methodDelegatec7 = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatec7;
      cp45.IsValidEvent += methodDelegatec7;
      // ISSUE: reference to a compiler-generated field
      cDisplayClassfd.cp.PageOnLeft = 8;
      // ISSUE: reference to a compiler-generated field
      cDisplayClassfd.cp.PageOnRight = 8;
      // ISSUE: reference to a compiler-generated field
      UILinkPointNavigator.RegisterPage(cDisplayClassfd.cp, 17, true);
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      UILinksInitializer.\u003C\u003Ec__DisplayClassff cDisplayClassff = new UILinksInitializer.\u003C\u003Ec__DisplayClassff();
      // ISSUE: reference to a compiler-generated field
      cDisplayClassff.cp = new UILinkPage();
      // ISSUE: reference to a compiler-generated field
      UILinkPage cp46 = cDisplayClassff.cp;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatec8 == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatec8 = new Func<string>((object) null, __methodptr(\u003CLoad\u003Eb__62));
      }
      // ISSUE: reference to a compiler-generated field
      Func<string> methodDelegatec8 = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatec8;
      cp46.OnSpecialInteracts += methodDelegatec8;
      for (int index = 4000; index < 4010; ++index)
      {
        UILinkPoint uiLinkPoint = new UILinkPoint(index, true, -3, -4, -1, -2);
        switch (index - 4000)
        {
          case 0:
          case 1:
            uiLinkPoint.Right = 0;
            break;
          case 2:
          case 3:
            uiLinkPoint.Right = 10;
            break;
          case 4:
          case 5:
            uiLinkPoint.Right = 20;
            break;
          case 6:
          case 7:
            uiLinkPoint.Right = 30;
            break;
          case 8:
          case 9:
            uiLinkPoint.Right = 40;
            break;
        }
        // ISSUE: reference to a compiler-generated field
        cDisplayClassff.cp.LinkMap.Add(index, uiLinkPoint);
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: method pointer
      cDisplayClassff.cp.UpdateEvent += new Action((object) cDisplayClassff, __methodptr(\u003CLoad\u003Eb__63));
      // ISSUE: reference to a compiler-generated field
      UILinkPage cp47 = cDisplayClassff.cp;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatec9 == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatec9 = new Func<bool>((object) null, __methodptr(\u003CLoad\u003Eb__64));
      }
      // ISSUE: reference to a compiler-generated field
      Func<bool> methodDelegatec9 = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatec9;
      cp47.IsValidEvent += methodDelegatec9;
      // ISSUE: reference to a compiler-generated field
      cDisplayClassff.cp.PageOnLeft = 8;
      // ISSUE: reference to a compiler-generated field
      cDisplayClassff.cp.PageOnRight = 8;
      // ISSUE: reference to a compiler-generated field
      UILinkPointNavigator.RegisterPage(cDisplayClassff.cp, 18, true);
      UILinkPage page5 = new UILinkPage();
      UILinkPage uiLinkPage14 = page5;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegateca == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegateca = new Func<string>((object) null, __methodptr(\u003CLoad\u003Eb__65));
      }
      // ISSUE: reference to a compiler-generated field
      Func<string> methodDelegateca = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegateca;
      uiLinkPage14.OnSpecialInteracts += methodDelegateca;
      page5.LinkMap.Add(2806, new UILinkPoint(2806, true, 2805, 2807, -1, 2808));
      page5.LinkMap.Add(2807, new UILinkPoint(2807, true, 2806, -4, -1, 2809));
      page5.LinkMap.Add(2808, new UILinkPoint(2808, true, 2805, 2809, 2806, -2));
      page5.LinkMap.Add(2809, new UILinkPoint(2809, true, 2808, -4, 2807, -2));
      page5.LinkMap.Add(2805, new UILinkPoint(2805, true, -3, 2806, -1, -2));
      page5.LinkMap[2806].OnSpecialInteracts += methodDelegate7a;
      page5.LinkMap[2807].OnSpecialInteracts += methodDelegate7a;
      page5.LinkMap[2808].OnSpecialInteracts += methodDelegate7a;
      page5.LinkMap[2809].OnSpecialInteracts += methodDelegate7a;
      page5.LinkMap[2805].OnSpecialInteracts += methodDelegate7a;
      UILinkPage uiLinkPage15 = page5;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatecb == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatecb = new Func<bool>((object) null, __methodptr(\u003CLoad\u003Eb__66));
      }
      // ISSUE: reference to a compiler-generated field
      Func<bool> methodDelegatecb = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatecb;
      uiLinkPage15.CanEnterEvent += methodDelegatecb;
      UILinkPage uiLinkPage16 = page5;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatecc == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatecc = new Func<bool>((object) null, __methodptr(\u003CLoad\u003Eb__67));
      }
      // ISSUE: reference to a compiler-generated field
      Func<bool> methodDelegatecc = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatecc;
      uiLinkPage16.IsValidEvent += methodDelegatecc;
      UILinkPage uiLinkPage17 = page5;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatecd == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatecd = new Action((object) null, __methodptr(\u003CLoad\u003Eb__68));
      }
      // ISSUE: reference to a compiler-generated field
      Action methodDelegatecd = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatecd;
      uiLinkPage17.EnterEvent += methodDelegatecd;
      UILinkPage uiLinkPage18 = page5;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatece == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatece = new Action((object) null, __methodptr(\u003CLoad\u003Eb__69));
      }
      // ISSUE: reference to a compiler-generated field
      Action methodDelegatece = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatece;
      uiLinkPage18.LeaveEvent += methodDelegatece;
      page5.PageOnLeft = 15;
      page5.PageOnRight = 15;
      UILinkPointNavigator.RegisterPage(page5, 14, true);
      UILinkPage page6 = new UILinkPage();
      UILinkPage uiLinkPage19 = page6;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatecf == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatecf = new Func<string>((object) null, __methodptr(\u003CLoad\u003Eb__6a));
      }
      // ISSUE: reference to a compiler-generated field
      Func<string> methodDelegatecf = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatecf;
      uiLinkPage19.OnSpecialInteracts += methodDelegatecf;
      page6.LinkMap.Add(2800, new UILinkPoint(2800, true, -3, -4, -1, 2801));
      page6.LinkMap.Add(2801, new UILinkPoint(2801, true, -3, -4, 2800, 2802));
      page6.LinkMap.Add(2802, new UILinkPoint(2802, true, -3, -4, 2801, 2803));
      page6.LinkMap.Add(2803, new UILinkPoint(2803, true, -3, 2804, 2802, -2));
      page6.LinkMap.Add(2804, new UILinkPoint(2804, true, 2803, -4, 2802, -2));
      page6.LinkMap[2800].OnSpecialInteracts += methodDelegate7a;
      page6.LinkMap[2801].OnSpecialInteracts += methodDelegate7a;
      page6.LinkMap[2802].OnSpecialInteracts += methodDelegate7a;
      page6.LinkMap[2803].OnSpecialInteracts += methodDelegate7a;
      page6.LinkMap[2804].OnSpecialInteracts += methodDelegate7a;
      UILinkPage uiLinkPage20 = page6;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegated0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegated0 = new Action((object) null, __methodptr(\u003CLoad\u003Eb__6b));
      }
      // ISSUE: reference to a compiler-generated field
      Action methodDelegated0 = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegated0;
      uiLinkPage20.UpdateEvent += methodDelegated0;
      UILinkPage uiLinkPage21 = page6;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegated1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegated1 = new Func<bool>((object) null, __methodptr(\u003CLoad\u003Eb__6c));
      }
      // ISSUE: reference to a compiler-generated field
      Func<bool> methodDelegated1 = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegated1;
      uiLinkPage21.CanEnterEvent += methodDelegated1;
      UILinkPage uiLinkPage22 = page6;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegated2 == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegated2 = new Func<bool>((object) null, __methodptr(\u003CLoad\u003Eb__6d));
      }
      // ISSUE: reference to a compiler-generated field
      Func<bool> methodDelegated2 = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegated2;
      uiLinkPage22.IsValidEvent += methodDelegated2;
      UILinkPage uiLinkPage23 = page6;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegated3 == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegated3 = new Action((object) null, __methodptr(\u003CLoad\u003Eb__6e));
      }
      // ISSUE: reference to a compiler-generated field
      Action methodDelegated3 = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegated3;
      uiLinkPage23.EnterEvent += methodDelegated3;
      UILinkPage uiLinkPage24 = page6;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegated4 == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegated4 = new Action((object) null, __methodptr(\u003CLoad\u003Eb__6f));
      }
      // ISSUE: reference to a compiler-generated field
      Action methodDelegated4 = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegated4;
      uiLinkPage24.LeaveEvent += methodDelegated4;
      page6.PageOnLeft = 14;
      page6.PageOnRight = 14;
      UILinkPointNavigator.RegisterPage(page6, 15, true);
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      UILinksInitializer.\u003C\u003Ec__DisplayClass101 cDisplayClass101 = new UILinksInitializer.\u003C\u003Ec__DisplayClass101();
      // ISSUE: reference to a compiler-generated field
      cDisplayClass101.cp = new UILinkPage();
      // ISSUE: reference to a compiler-generated field
      UILinkPage cp48 = cDisplayClass101.cp;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegated5 == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegated5 = new Action((object) null, __methodptr(\u003CLoad\u003Eb__70));
      }
      // ISSUE: reference to a compiler-generated field
      Action methodDelegated5 = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegated5;
      cp48.UpdateEvent += methodDelegated5;
      for (int index = 0; index < 200; ++index)
      {
        // ISSUE: reference to a compiler-generated field
        cDisplayClass101.cp.LinkMap.Add(3000 + index, new UILinkPoint(3000 + index, true, -3, -4, -1, -2));
      }
      // ISSUE: reference to a compiler-generated field
      UILinkPage cp49 = cDisplayClass101.cp;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegated6 == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegated6 = new Func<string>((object) null, __methodptr(\u003CLoad\u003Eb__71));
      }
      // ISSUE: reference to a compiler-generated field
      Func<string> methodDelegated6 = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegated6;
      cp49.OnSpecialInteracts += methodDelegated6;
      // ISSUE: reference to a compiler-generated field
      UILinkPage cp50 = cDisplayClass101.cp;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegated7 == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegated7 = new Action((object) null, __methodptr(\u003CLoad\u003Eb__72));
      }
      // ISSUE: reference to a compiler-generated field
      Action methodDelegated7 = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegated7;
      cp50.UpdateEvent += methodDelegated7;
      // ISSUE: reference to a compiler-generated field
      // ISSUE: method pointer
      cDisplayClass101.cp.EnterEvent += new Action((object) cDisplayClass101, __methodptr(\u003CLoad\u003Eb__73));
      // ISSUE: reference to a compiler-generated field
      UILinkPage cp51 = cDisplayClass101.cp;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegated8 == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegated8 = new Func<bool>((object) null, __methodptr(\u003CLoad\u003Eb__74));
      }
      // ISSUE: reference to a compiler-generated field
      Func<bool> methodDelegated8 = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegated8;
      cp51.CanEnterEvent += methodDelegated8;
      // ISSUE: reference to a compiler-generated field
      UILinkPage cp52 = cDisplayClass101.cp;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegated9 == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegated9 = new Func<bool>((object) null, __methodptr(\u003CLoad\u003Eb__75));
      }
      // ISSUE: reference to a compiler-generated field
      Func<bool> methodDelegated9 = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegated9;
      cp52.IsValidEvent += methodDelegated9;
      // ISSUE: reference to a compiler-generated field
      UILinkPointNavigator.RegisterPage(cDisplayClass101.cp, 1004, true);
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      UILinksInitializer.\u003C\u003Ec__DisplayClass103 cDisplayClass103 = new UILinksInitializer.\u003C\u003Ec__DisplayClass103();
      // ISSUE: reference to a compiler-generated field
      cDisplayClass103.cp = new UILinkPage();
      // ISSUE: reference to a compiler-generated field
      UILinkPage cp53 = cDisplayClass103.cp;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegateda == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegateda = new Func<string>((object) null, __methodptr(\u003CLoad\u003Eb__76));
      }
      // ISSUE: reference to a compiler-generated field
      Func<string> methodDelegateda = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegateda;
      cp53.OnSpecialInteracts += methodDelegateda;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatedb == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatedb = new Func<string>((object) null, __methodptr(\u003CLoad\u003Eb__77));
      }
      // ISSUE: reference to a compiler-generated field
      Func<string> methodDelegatedb = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatedb;
      for (int index = 9000; index <= 9050; ++index)
      {
        UILinkPoint uiLinkPoint = new UILinkPoint(index, true, index + 10, index - 10, index - 1, index + 1);
        // ISSUE: reference to a compiler-generated field
        cDisplayClass103.cp.LinkMap.Add(index, uiLinkPoint);
        uiLinkPoint.OnSpecialInteracts += methodDelegatedb;
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: method pointer
      cDisplayClass103.cp.UpdateEvent += new Action((object) cDisplayClass103, __methodptr(\u003CLoad\u003Eb__78));
      // ISSUE: reference to a compiler-generated field
      UILinkPage cp54 = cDisplayClass103.cp;
      // ISSUE: reference to a compiler-generated field
      if (UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatedc == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatedc = new Func<bool>((object) null, __methodptr(\u003CLoad\u003Eb__79));
      }
      // ISSUE: reference to a compiler-generated field
      Func<bool> methodDelegatedc = UILinksInitializer.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatedc;
      cp54.IsValidEvent += methodDelegatedc;
      // ISSUE: reference to a compiler-generated field
      cDisplayClass103.cp.PageOnLeft = 8;
      // ISSUE: reference to a compiler-generated field
      cDisplayClass103.cp.PageOnRight = 8;
      // ISSUE: reference to a compiler-generated field
      UILinkPointNavigator.RegisterPage(cDisplayClass103.cp, 19, true);
      UILinkPage page7 = UILinkPointNavigator.Pages[UILinkPointNavigator.CurrentPage];
      page7.CurrentPoint = page7.DefaultPoint;
      page7.Enter();
    }

    public static void FancyExit()
    {
      switch (UILinkPointNavigator.Shortcuts.BackButtonCommand)
      {
        case 1:
          Main.PlaySound(11, -1, -1, 1, 1f, 0.0f);
          Main.menuMode = 0;
          break;
        case 2:
          Main.PlaySound(11, -1, -1, 1, 1f, 0.0f);
          Main.menuMode = Main.menuMultiplayer ? 12 : 1;
          break;
        case 3:
          Main.menuMode = 0;
          IngameFancyUI.Close();
          break;
        case 4:
          Main.PlaySound(11, -1, -1, 1, 1f, 0.0f);
          Main.menuMode = 11;
          break;
        case 5:
          Main.PlaySound(11, -1, -1, 1, 1f, 0.0f);
          Main.menuMode = 11;
          break;
        case 6:
          UIVirtualKeyboard.Cancel();
          break;
      }
    }

    public static string FancyUISpecialInstructions()
    {
      string str1 = "";
      if (UILinkPointNavigator.Shortcuts.FANCYUI_SPECIAL_INSTRUCTIONS == 1)
      {
        if (PlayerInput.Triggers.JustPressed.HotbarMinus)
          UIVirtualKeyboard.CycleSymbols();
        string str2 = str1 + PlayerInput.BuildCommand(Lang.menu[235].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["HotbarMinus"]);
        if (PlayerInput.Triggers.JustPressed.MouseRight)
          UIVirtualKeyboard.BackSpace();
        string str3 = str2 + PlayerInput.BuildCommand(Lang.menu[236].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["MouseRight"]);
        if (PlayerInput.Triggers.JustPressed.SmartCursor)
          UIVirtualKeyboard.Write(" ");
        str1 = str3 + PlayerInput.BuildCommand(Lang.menu[238].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["SmartCursor"]);
        if (UIVirtualKeyboard.CanSubmit)
        {
          if (PlayerInput.Triggers.JustPressed.HotbarPlus)
            UIVirtualKeyboard.Submit();
          str1 += PlayerInput.BuildCommand(Lang.menu[237].Value, false, PlayerInput.ProfileGamepadUI.KeyStatus["HotbarPlus"]);
        }
      }
      return str1;
    }

    public static void HandleOptionsSpecials()
    {
      switch (UILinkPointNavigator.Shortcuts.OPTIONS_BUTTON_SPECIALFEATURE)
      {
        case 1:
          Main.bgScroll = (int) UILinksInitializer.HandleSlider((float) Main.bgScroll, 0.0f, 100f, PlayerInput.CurrentProfile.InterfaceDeadzoneX, 1f);
          Main.caveParallax = (float) (1.0 - (double) Main.bgScroll / 500.0);
          break;
        case 2:
          Main.musicVolume = UILinksInitializer.HandleSlider(Main.musicVolume, 0.0f, 1f, PlayerInput.CurrentProfile.InterfaceDeadzoneX, 0.35f);
          break;
        case 3:
          Main.soundVolume = UILinksInitializer.HandleSlider(Main.soundVolume, 0.0f, 1f, PlayerInput.CurrentProfile.InterfaceDeadzoneX, 0.35f);
          break;
        case 4:
          Main.ambientVolume = UILinksInitializer.HandleSlider(Main.ambientVolume, 0.0f, 1f, PlayerInput.CurrentProfile.InterfaceDeadzoneX, 0.35f);
          break;
        case 5:
          float hBar = Main.hBar;
          float num1 = Main.hBar = UILinksInitializer.HandleSlider(hBar, 0.0f, 1f, 0.2f, 0.5f);
          if ((double) hBar == (double) num1)
            break;
          switch (Main.menuMode)
          {
            case 17:
              Main.player[Main.myPlayer].hairColor = Main.selColor = Main.hslToRgb(Main.hBar, Main.sBar, Main.lBar);
              break;
            case 18:
              Main.player[Main.myPlayer].eyeColor = Main.selColor = Main.hslToRgb(Main.hBar, Main.sBar, Main.lBar);
              break;
            case 19:
              Main.player[Main.myPlayer].skinColor = Main.selColor = Main.hslToRgb(Main.hBar, Main.sBar, Main.lBar);
              break;
            case 21:
              Main.player[Main.myPlayer].shirtColor = Main.selColor = Main.hslToRgb(Main.hBar, Main.sBar, Main.lBar);
              break;
            case 22:
              Main.player[Main.myPlayer].underShirtColor = Main.selColor = Main.hslToRgb(Main.hBar, Main.sBar, Main.lBar);
              break;
            case 23:
              Main.player[Main.myPlayer].pantsColor = Main.selColor = Main.hslToRgb(Main.hBar, Main.sBar, Main.lBar);
              break;
            case 24:
              Main.player[Main.myPlayer].shoeColor = Main.selColor = Main.hslToRgb(Main.hBar, Main.sBar, Main.lBar);
              break;
            case 25:
              Main.mouseColorSlider.Hue = num1;
              break;
            case 252:
              Main.mouseBorderColorSlider.Hue = num1;
              break;
          }
          Main.PlaySound(12, -1, -1, 1, 1f, 0.0f);
          break;
        case 6:
          float sBar = Main.sBar;
          float num2 = Main.sBar = UILinksInitializer.HandleSlider(sBar, 0.0f, 1f, PlayerInput.CurrentProfile.InterfaceDeadzoneX, 0.5f);
          if ((double) sBar == (double) num2)
            break;
          switch (Main.menuMode)
          {
            case 17:
              Main.player[Main.myPlayer].hairColor = Main.selColor = Main.hslToRgb(Main.hBar, Main.sBar, Main.lBar);
              break;
            case 18:
              Main.player[Main.myPlayer].eyeColor = Main.selColor = Main.hslToRgb(Main.hBar, Main.sBar, Main.lBar);
              break;
            case 19:
              Main.player[Main.myPlayer].skinColor = Main.selColor = Main.hslToRgb(Main.hBar, Main.sBar, Main.lBar);
              break;
            case 21:
              Main.player[Main.myPlayer].shirtColor = Main.selColor = Main.hslToRgb(Main.hBar, Main.sBar, Main.lBar);
              break;
            case 22:
              Main.player[Main.myPlayer].underShirtColor = Main.selColor = Main.hslToRgb(Main.hBar, Main.sBar, Main.lBar);
              break;
            case 23:
              Main.player[Main.myPlayer].pantsColor = Main.selColor = Main.hslToRgb(Main.hBar, Main.sBar, Main.lBar);
              break;
            case 24:
              Main.player[Main.myPlayer].shoeColor = Main.selColor = Main.hslToRgb(Main.hBar, Main.sBar, Main.lBar);
              break;
            case 25:
              Main.mouseColorSlider.Saturation = num2;
              break;
            case 252:
              Main.mouseBorderColorSlider.Saturation = num2;
              break;
          }
          Main.PlaySound(12, -1, -1, 1, 1f, 0.0f);
          break;
        case 7:
          float lBar = Main.lBar;
          float min = 0.15f;
          if (Main.menuMode == 252)
            min = 0.0f;
          float num3 = Main.lBar = UILinksInitializer.HandleSlider(lBar, min, 1f, PlayerInput.CurrentProfile.InterfaceDeadzoneX, 0.5f);
          if ((double) lBar == (double) num3)
            break;
          switch (Main.menuMode)
          {
            case 17:
              Main.player[Main.myPlayer].hairColor = Main.selColor = Main.hslToRgb(Main.hBar, Main.sBar, Main.lBar);
              break;
            case 18:
              Main.player[Main.myPlayer].eyeColor = Main.selColor = Main.hslToRgb(Main.hBar, Main.sBar, Main.lBar);
              break;
            case 19:
              Main.player[Main.myPlayer].skinColor = Main.selColor = Main.hslToRgb(Main.hBar, Main.sBar, Main.lBar);
              break;
            case 21:
              Main.player[Main.myPlayer].shirtColor = Main.selColor = Main.hslToRgb(Main.hBar, Main.sBar, Main.lBar);
              break;
            case 22:
              Main.player[Main.myPlayer].underShirtColor = Main.selColor = Main.hslToRgb(Main.hBar, Main.sBar, Main.lBar);
              break;
            case 23:
              Main.player[Main.myPlayer].pantsColor = Main.selColor = Main.hslToRgb(Main.hBar, Main.sBar, Main.lBar);
              break;
            case 24:
              Main.player[Main.myPlayer].shoeColor = Main.selColor = Main.hslToRgb(Main.hBar, Main.sBar, Main.lBar);
              break;
            case 25:
              Main.mouseColorSlider.Luminance = num3;
              break;
            case 252:
              Main.mouseBorderColorSlider.Luminance = num3;
              break;
          }
          Main.PlaySound(12, -1, -1, 1, 1f, 0.0f);
          break;
        case 8:
          float aBar = Main.aBar;
          float num4 = Main.aBar = UILinksInitializer.HandleSlider(aBar, 0.0f, 1f, PlayerInput.CurrentProfile.InterfaceDeadzoneX, 0.5f);
          if ((double) aBar == (double) num4)
            break;
          if (Main.menuMode == 252)
            Main.mouseBorderColorSlider.Alpha = num4;
          Main.PlaySound(12, -1, -1, 1, 1f, 0.0f);
          break;
        case 9:
          bool left = PlayerInput.Triggers.Current.Left;
          bool right = PlayerInput.Triggers.Current.Right;
          if (PlayerInput.Triggers.JustPressed.Left || PlayerInput.Triggers.JustPressed.Right)
            UILinksInitializer.SomeVarsForUILinkers.HairMoveCD = 0;
          else if (UILinksInitializer.SomeVarsForUILinkers.HairMoveCD > 0)
            --UILinksInitializer.SomeVarsForUILinkers.HairMoveCD;
          if (UILinksInitializer.SomeVarsForUILinkers.HairMoveCD == 0 && (left || right))
          {
            if (left)
              --Main.PendingPlayer.hair;
            if (right)
              ++Main.PendingPlayer.hair;
            UILinksInitializer.SomeVarsForUILinkers.HairMoveCD = 12;
          }
          int num5 = 51;
          if (Main.PendingPlayer.hair >= num5)
            Main.PendingPlayer.hair = 0;
          if (Main.PendingPlayer.hair >= 0)
            break;
          Main.PendingPlayer.hair = num5 - 1;
          break;
        case 10:
          Main.GameZoomTarget = UILinksInitializer.HandleSlider(Main.GameZoomTarget, 1f, 2f, PlayerInput.CurrentProfile.InterfaceDeadzoneX, 0.35f);
          break;
        case 11:
          Main.UIScale = UILinksInitializer.HandleSlider(Main.UIScaleWanted, 1f, 2f, PlayerInput.CurrentProfile.InterfaceDeadzoneX, 0.35f);
          Main.temporaryGUIScaleSlider = Main.UIScaleWanted;
          break;
      }
    }

    public class SomeVarsForUILinkers
    {
      public static Recipe SequencedCraftingCurrent;
      public static int HairMoveCD;
    }
  }
}
