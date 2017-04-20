// Decompiled with JetBrains decompiler
// Type: Terraria.UI.IngameFancyUI
// Assembly: TerrariaServer, Version=1.3.5.1, Culture=neutral, PublicKeyToken=null
// MVID: 5CBA2320-074B-43F7-8CDC-BF1E2B81EE4B
// Assembly location: C:\Users\kevzhao\Downloads\TerrariaServer.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria.Achievements;
using Terraria.GameContent.UI.States;
using Terraria.GameInput;
using Terraria.Localization;
using Terraria.UI.Gamepad;

namespace Terraria.UI
{
  public class IngameFancyUI
  {
    private static bool CoverForOneUIFrame;

    public static void CoverNextFrame()
    {
      IngameFancyUI.CoverForOneUIFrame = true;
    }

    public static bool CanCover()
    {
      if (!IngameFancyUI.CoverForOneUIFrame)
        return false;
      IngameFancyUI.CoverForOneUIFrame = false;
      return true;
    }

    public static void OpenAchievements()
    {
      IngameFancyUI.CoverNextFrame();
      Main.playerInventory = false;
      Main.editChest = false;
      Main.npcChatText = "";
      Main.inFancyUI = true;
      Main.InGameUI.SetState((UIState) Main.AchievementsMenu);
    }

    public static void OpenAchievementsAndGoto(Achievement achievement)
    {
      IngameFancyUI.OpenAchievements();
      Main.AchievementsMenu.GotoAchievement(achievement);
    }

    public static void OpenKeybinds()
    {
      IngameFancyUI.CoverNextFrame();
      Main.playerInventory = false;
      Main.editChest = false;
      Main.npcChatText = "";
      Main.inFancyUI = true;
      Main.InGameUI.SetState((UIState) Main.ManageControlsMenu);
    }

    public static bool CanShowVirtualKeyboard(int context)
    {
      return UIVirtualKeyboard.CanDisplay(context);
    }

    public static void OpenVirtualKeyboard(int keyboardContext)
    {
      IngameFancyUI.CoverNextFrame();
      Main.PlaySound(12, -1, -1, 1, 1f, 0.0f);
      string str = "";
      switch (keyboardContext)
      {
        case 1:
          Main.editSign = true;
          str = Language.GetTextValue("UI.EnterMessage");
          break;
        case 2:
          str = Language.GetTextValue("UI.EnterNewName");
          Player player = Main.player[Main.myPlayer];
          Main.npcChatText = Main.chest[player.chest].name;
          if ((int) Main.tile[player.chestX, player.chestY].type == 21)
            Main.defaultChestName = Lang.chestType[(int) Main.tile[player.chestX, player.chestY].frameX / 36].Value;
          if ((int) Main.tile[player.chestX, player.chestY].type == 467)
            Main.defaultChestName = Lang.chestType2[(int) Main.tile[player.chestX, player.chestY].frameX / 36].Value;
          if ((int) Main.tile[player.chestX, player.chestY].type == 88)
            Main.defaultChestName = Lang.dresserType[(int) Main.tile[player.chestX, player.chestY].frameX / 54].Value;
          if (Main.npcChatText == "")
            Main.npcChatText = Main.defaultChestName;
          Main.editChest = true;
          break;
      }
      Main.clrInput();
      if (!IngameFancyUI.CanShowVirtualKeyboard(keyboardContext))
        return;
      Main.inFancyUI = true;
      switch (keyboardContext)
      {
        case 1:
          UserInterface inGameUi1 = Main.InGameUI;
          string labelText1 = str;
          string npcChatText1 = Main.npcChatText;
          UIVirtualKeyboard.KeyboardSubmitEvent submitAction1 = (UIVirtualKeyboard.KeyboardSubmitEvent) (s =>
          {
            Main.SubmitSignText();
            IngameFancyUI.Close();
          });
          // ISSUE: reference to a compiler-generated field
          if (IngameFancyUI.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate5 == null)
          {
            // ISSUE: reference to a compiler-generated field
            // ISSUE: method pointer
            IngameFancyUI.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate5 = new Action((object) null, __methodptr(\u003COpenVirtualKeyboard\u003Eb__1));
          }
          // ISSUE: reference to a compiler-generated field
          Action anonymousMethodDelegate5 = IngameFancyUI.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate5;
          int inputMode1 = keyboardContext;
          int num1 = 0;
          UIVirtualKeyboard uiVirtualKeyboard1 = new UIVirtualKeyboard(labelText1, npcChatText1, submitAction1, anonymousMethodDelegate5, inputMode1, num1 != 0);
          inGameUi1.SetState((UIState) uiVirtualKeyboard1);
          break;
        case 2:
          UserInterface inGameUi2 = Main.InGameUI;
          string labelText2 = str;
          string npcChatText2 = Main.npcChatText;
          UIVirtualKeyboard.KeyboardSubmitEvent submitAction2 = (UIVirtualKeyboard.KeyboardSubmitEvent) (s =>
          {
            ChestUI.RenameChestSubmit(Main.player[Main.myPlayer]);
            IngameFancyUI.Close();
          });
          // ISSUE: reference to a compiler-generated field
          if (IngameFancyUI.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate7 == null)
          {
            // ISSUE: reference to a compiler-generated field
            // ISSUE: method pointer
            IngameFancyUI.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate7 = new Action((object) null, __methodptr(\u003COpenVirtualKeyboard\u003Eb__3));
          }
          // ISSUE: reference to a compiler-generated field
          Action anonymousMethodDelegate7 = IngameFancyUI.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate7;
          int inputMode2 = keyboardContext;
          int num2 = 0;
          UIVirtualKeyboard uiVirtualKeyboard2 = new UIVirtualKeyboard(labelText2, npcChatText2, submitAction2, anonymousMethodDelegate7, inputMode2, num2 != 0);
          inGameUi2.SetState((UIState) uiVirtualKeyboard2);
          break;
      }
      UILinkPointNavigator.GoToDefaultPage(1);
    }

    public static void Close()
    {
      Main.inFancyUI = false;
      Main.PlaySound(11, -1, -1, 1, 1f, 0.0f);
      if (!Main.gameMenu && (!(Main.InGameUI.CurrentState is UIVirtualKeyboard) || UIVirtualKeyboard.KeyboardContext == 2))
        Main.playerInventory = true;
      Main.InGameUI.SetState((UIState) null);
      UILinkPointNavigator.Shortcuts.FANCYUI_SPECIAL_INSTRUCTIONS = 0;
    }

    public static bool Draw(SpriteBatch spriteBatch, GameTime gameTime)
    {
      if (!Main.gameMenu && Main.player[Main.myPlayer].dead && !Main.player[Main.myPlayer].ghost)
      {
        IngameFancyUI.Close();
        Main.playerInventory = false;
        return false;
      }
      bool flag = false;
      if (Main.InGameUI.CurrentState is UIVirtualKeyboard && UIVirtualKeyboard.KeyboardContext > 0)
      {
        if (!Main.inFancyUI)
          Main.InGameUI.SetState((UIState) null);
        if (Main.screenWidth >= 1705 || !PlayerInput.UsingGamepad)
          flag = true;
      }
      if (!Main.gameMenu)
      {
        Main.mouseText = false;
        if (Main.InGameUI != null && Main.InGameUI.IsElementUnderMouse())
          Main.player[Main.myPlayer].mouseInterface = true;
        Main.instance.GUIBarsDraw();
        if (Main.InGameUI.CurrentState is UIVirtualKeyboard && UIVirtualKeyboard.KeyboardContext > 0)
          Main.instance.GUIChatDraw();
        if (!Main.inFancyUI)
          Main.InGameUI.SetState((UIState) null);
        Main.instance.DrawMouseOver();
        Main.DrawCursor(Main.DrawThickCursor(false), false);
      }
      return flag;
    }

    public static void MouseOver()
    {
      if (!Main.inFancyUI || !Main.InGameUI.IsElementUnderMouse())
        return;
      Main.mouseText = true;
    }
  }
}
