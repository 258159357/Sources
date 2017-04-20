// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.States.UICharacterSelect
// Assembly: TerrariaServer, Version=1.3.5.1, Culture=neutral, PublicKeyToken=null
// MVID: 5CBA2320-074B-43F7-8CDC-BF1E2B81EE4B
// Assembly location: C:\Users\kevzhao\Downloads\TerrariaServer.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria.GameContent.UI.Elements;
using Terraria.GameInput;
using Terraria.IO;
using Terraria.Localization;
using Terraria.UI;
using Terraria.UI.Gamepad;

namespace Terraria.GameContent.UI.States
{
  public class UICharacterSelect : UIState
  {
    private static string noteToEveryone = "This code is terrible and you will risk cancer reading it --Yoraiz0r";
    private List<Tuple<string, bool>> favoritesCache = new List<Tuple<string, bool>>();
    private UIList _playerList;
    private UITextPanel<LocalizedText> _backPanel;
    private UITextPanel<LocalizedText> _newPanel;
    private UIPanel _containerPanel;
    private bool skipDraw;

    public override void OnInitialize()
    {
      UIElement element = new UIElement();
      element.Width.Set(0.0f, 0.8f);
      element.MaxWidth.Set(650f, 0.0f);
      element.Top.Set(220f, 0.0f);
      element.Height.Set(-220f, 1f);
      element.HAlign = 0.5f;
      UIPanel uiPanel = new UIPanel();
      uiPanel.Width.Set(0.0f, 1f);
      uiPanel.Height.Set(-110f, 1f);
      uiPanel.BackgroundColor = Color.op_Multiply(new Color(33, 43, 79), 0.8f);
      this._containerPanel = uiPanel;
      element.Append((UIElement) uiPanel);
      this._playerList = new UIList();
      this._playerList.Width.Set(-25f, 1f);
      this._playerList.Height.Set(0.0f, 1f);
      this._playerList.ListPadding = 5f;
      uiPanel.Append((UIElement) this._playerList);
      UIScrollbar scrollbar = new UIScrollbar();
      scrollbar.SetView(100f, 1000f);
      scrollbar.Height.Set(0.0f, 1f);
      scrollbar.HAlign = 1f;
      uiPanel.Append((UIElement) scrollbar);
      this._playerList.SetScrollbar(scrollbar);
      UITextPanel<LocalizedText> uiTextPanel1 = new UITextPanel<LocalizedText>(Language.GetText("UI.SelectPlayer"), 0.8f, true);
      uiTextPanel1.HAlign = 0.5f;
      uiTextPanel1.Top.Set(-35f, 0.0f);
      uiTextPanel1.SetPadding(15f);
      uiTextPanel1.BackgroundColor = new Color(73, 94, 171);
      element.Append((UIElement) uiTextPanel1);
      UITextPanel<LocalizedText> uiTextPanel2 = new UITextPanel<LocalizedText>(Language.GetText("UI.Back"), 0.7f, true);
      uiTextPanel2.Width.Set(-10f, 0.5f);
      uiTextPanel2.Height.Set(50f, 0.0f);
      uiTextPanel2.VAlign = 1f;
      uiTextPanel2.Top.Set(-45f, 0.0f);
      uiTextPanel2.OnMouseOver += new UIElement.MouseEvent(this.FadedMouseOver);
      uiTextPanel2.OnMouseOut += new UIElement.MouseEvent(this.FadedMouseOut);
      uiTextPanel2.OnClick += new UIElement.MouseEvent(this.GoBackClick);
      uiTextPanel2.SetSnapPoint("Back", 0, new Vector2?(), new Vector2?());
      element.Append((UIElement) uiTextPanel2);
      this._backPanel = uiTextPanel2;
      UITextPanel<LocalizedText> uiTextPanel3 = new UITextPanel<LocalizedText>(Language.GetText("UI.New"), 0.7f, true);
      uiTextPanel3.CopyStyle((UIElement) uiTextPanel2);
      uiTextPanel3.HAlign = 1f;
      uiTextPanel3.OnMouseOver += new UIElement.MouseEvent(this.FadedMouseOver);
      uiTextPanel3.OnMouseOut += new UIElement.MouseEvent(this.FadedMouseOut);
      uiTextPanel3.OnClick += new UIElement.MouseEvent(this.NewCharacterClick);
      element.Append((UIElement) uiTextPanel3);
      uiTextPanel2.SetSnapPoint("New", 0, new Vector2?(), new Vector2?());
      this._newPanel = uiTextPanel3;
      this.Append(element);
    }

    private void NewCharacterClick(UIMouseEvent evt, UIElement listeningElement)
    {
      Main.PlaySound(10, -1, -1, 1, 1f, 0.0f);
      Player player = new Player();
      player.inventory[0].SetDefaults(3507, false);
      player.inventory[0].Prefix(-1);
      player.inventory[1].SetDefaults(3509, false);
      player.inventory[1].Prefix(-1);
      player.inventory[2].SetDefaults(3506, false);
      player.inventory[2].Prefix(-1);
      Main.PendingPlayer = player;
      Main.menuMode = 2;
    }

    private void GoBackClick(UIMouseEvent evt, UIElement listeningElement)
    {
      Main.PlaySound(11, -1, -1, 1, 1f, 0.0f);
      Main.menuMode = 0;
    }

    private void FadedMouseOver(UIMouseEvent evt, UIElement listeningElement)
    {
      Main.PlaySound(12, -1, -1, 1, 1f, 0.0f);
      ((UIPanel) evt.Target).BackgroundColor = new Color(73, 94, 171);
    }

    private void FadedMouseOut(UIMouseEvent evt, UIElement listeningElement)
    {
      ((UIPanel) evt.Target).BackgroundColor = Color.op_Multiply(new Color(63, 82, 151), 0.7f);
    }

    public override void OnActivate()
    {
      Main.ClearPendingPlayerSelectCallbacks();
      Main.LoadPlayers();
      this.UpdatePlayersList();
      if (!PlayerInput.UsingGamepadUI)
        return;
      UILinkPointNavigator.ChangePoint(3000 + (this._playerList.Count == 0 ? 1 : 2));
    }

    private void UpdatePlayersList()
    {
      this._playerList.Clear();
      List<PlayerFileData> playerFileDataList = new List<PlayerFileData>((IEnumerable<PlayerFileData>) Main.PlayerList);
      playerFileDataList.Sort((Comparison<PlayerFileData>) ((x, y) =>
      {
        if (x.IsFavorite && !y.IsFavorite)
          return -1;
        if (!x.IsFavorite && y.IsFavorite)
          return 1;
        if (x.Name.CompareTo(y.Name) != 0)
          return x.Name.CompareTo(y.Name);
        return x.GetFileName(true).CompareTo(y.GetFileName(true));
      }));
      int num = 0;
      foreach (PlayerFileData data in playerFileDataList)
        this._playerList.Add((UIElement) new UICharacterListItem(data, num++));
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
      if (this.skipDraw)
      {
        this.skipDraw = false;
      }
      else
      {
        if (this.UpdateFavoritesCache())
        {
          this.skipDraw = true;
          Main.MenuUI.Draw(spriteBatch, new GameTime());
        }
        base.Draw(spriteBatch);
        this.SetupGamepadPoints(spriteBatch);
      }
    }

    private bool UpdateFavoritesCache()
    {
      List<PlayerFileData> playerFileDataList = new List<PlayerFileData>((IEnumerable<PlayerFileData>) Main.PlayerList);
      playerFileDataList.Sort((Comparison<PlayerFileData>) ((x, y) =>
      {
        if (x.IsFavorite && !y.IsFavorite)
          return -1;
        if (!x.IsFavorite && y.IsFavorite)
          return 1;
        if (x.Name.CompareTo(y.Name) != 0)
          return x.Name.CompareTo(y.Name);
        return x.GetFileName(true).CompareTo(y.GetFileName(true));
      }));
      bool flag = false;
      if (!flag && playerFileDataList.Count != this.favoritesCache.Count)
        flag = true;
      if (!flag)
      {
        for (int index = 0; index < this.favoritesCache.Count; ++index)
        {
          Tuple<string, bool> tuple = this.favoritesCache[index];
          if (!(playerFileDataList[index].Name == tuple.get_Item1()) || playerFileDataList[index].IsFavorite != tuple.get_Item2())
          {
            flag = true;
            break;
          }
        }
      }
      if (flag)
      {
        this.favoritesCache.Clear();
        foreach (PlayerFileData playerFileData in playerFileDataList)
          this.favoritesCache.Add((Tuple<string, bool>) Tuple.Create<string, bool>((M0) playerFileData.Name, (M1) (playerFileData.IsFavorite ? 1 : 0)));
        this.UpdatePlayersList();
      }
      return flag;
    }

    private void SetupGamepadPoints(SpriteBatch spriteBatch)
    {
      UILinkPointNavigator.Shortcuts.BackButtonCommand = 1;
      int index1 = 3000;
      int ID1 = index1;
      Rectangle rectangle1 = this._backPanel.GetInnerDimensions().ToRectangle();
      // ISSUE: explicit reference operation
      Vector2 vector2_1 = ((Rectangle) @rectangle1).get_Center().ToVector2();
      UILinkPointNavigator.SetPosition(ID1, vector2_1);
      int ID2 = index1 + 1;
      Rectangle rectangle2 = this._newPanel.GetInnerDimensions().ToRectangle();
      // ISSUE: explicit reference operation
      Vector2 vector2_2 = ((Rectangle) @rectangle2).get_Center().ToVector2();
      UILinkPointNavigator.SetPosition(ID2, vector2_2);
      int index2 = index1;
      UILinkPoint point1 = UILinkPointNavigator.Points[index2];
      point1.Unlink();
      point1.Right = index2 + 1;
      int index3 = index1 + 1;
      UILinkPoint point2 = UILinkPointNavigator.Points[index3];
      point2.Unlink();
      point2.Left = index3 - 1;
      Rectangle clippingRectangle = this._containerPanel.GetClippingRectangle(spriteBatch);
      Vector2 minimum = clippingRectangle.TopLeft();
      Vector2 maximum = clippingRectangle.BottomRight();
      List<SnapPoint> snapPoints = this.GetSnapPoints();
      for (int index4 = 0; index4 < snapPoints.Count; ++index4)
      {
        if (!snapPoints[index4].Position.Between(minimum, maximum))
        {
          snapPoints.Remove(snapPoints[index4]);
          --index4;
        }
      }
      SnapPoint[,] snapPointArray = new SnapPoint[this._playerList.Count, 4];
      List<SnapPoint> snapPointList1 = snapPoints;
      // ISSUE: reference to a compiler-generated field
      if (UICharacterSelect.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate8 == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UICharacterSelect.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate8 = new Func<SnapPoint, bool>((object) null, __methodptr(\u003CSetupGamepadPoints\u003Eb__4));
      }
      // ISSUE: reference to a compiler-generated field
      Func<SnapPoint, bool> anonymousMethodDelegate8 = UICharacterSelect.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate8;
      foreach (SnapPoint snapPoint in (IEnumerable<SnapPoint>) Enumerable.Where<SnapPoint>((IEnumerable<M0>) snapPointList1, (Func<M0, bool>) anonymousMethodDelegate8))
        snapPointArray[snapPoint.ID, 0] = snapPoint;
      List<SnapPoint> snapPointList2 = snapPoints;
      // ISSUE: reference to a compiler-generated field
      if (UICharacterSelect.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate9 == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UICharacterSelect.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate9 = new Func<SnapPoint, bool>((object) null, __methodptr(\u003CSetupGamepadPoints\u003Eb__5));
      }
      // ISSUE: reference to a compiler-generated field
      Func<SnapPoint, bool> anonymousMethodDelegate9 = UICharacterSelect.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate9;
      foreach (SnapPoint snapPoint in (IEnumerable<SnapPoint>) Enumerable.Where<SnapPoint>((IEnumerable<M0>) snapPointList2, (Func<M0, bool>) anonymousMethodDelegate9))
        snapPointArray[snapPoint.ID, 1] = snapPoint;
      List<SnapPoint> snapPointList3 = snapPoints;
      // ISSUE: reference to a compiler-generated field
      if (UICharacterSelect.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatea == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UICharacterSelect.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatea = new Func<SnapPoint, bool>((object) null, __methodptr(\u003CSetupGamepadPoints\u003Eb__6));
      }
      // ISSUE: reference to a compiler-generated field
      Func<SnapPoint, bool> anonymousMethodDelegatea = UICharacterSelect.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatea;
      foreach (SnapPoint snapPoint in (IEnumerable<SnapPoint>) Enumerable.Where<SnapPoint>((IEnumerable<M0>) snapPointList3, (Func<M0, bool>) anonymousMethodDelegatea))
        snapPointArray[snapPoint.ID, 2] = snapPoint;
      List<SnapPoint> snapPointList4 = snapPoints;
      // ISSUE: reference to a compiler-generated field
      if (UICharacterSelect.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegateb == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        UICharacterSelect.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegateb = new Func<SnapPoint, bool>((object) null, __methodptr(\u003CSetupGamepadPoints\u003Eb__7));
      }
      // ISSUE: reference to a compiler-generated field
      Func<SnapPoint, bool> anonymousMethodDelegateb = UICharacterSelect.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegateb;
      foreach (SnapPoint snapPoint in (IEnumerable<SnapPoint>) Enumerable.Where<SnapPoint>((IEnumerable<M0>) snapPointList4, (Func<M0, bool>) anonymousMethodDelegateb))
        snapPointArray[snapPoint.ID, 3] = snapPoint;
      int ID3 = index1 + 2;
      int[] numArray = new int[this._playerList.Count];
      for (int index4 = 0; index4 < numArray.Length; ++index4)
        numArray[index4] = -1;
      for (int index4 = 0; index4 < 4; ++index4)
      {
        int index5 = -1;
        for (int index6 = 0; index6 < snapPointArray.GetLength(0); ++index6)
        {
          if (snapPointArray[index6, index4] != null)
          {
            UILinkPoint point3 = UILinkPointNavigator.Points[ID3];
            point3.Unlink();
            UILinkPointNavigator.SetPosition(ID3, snapPointArray[index6, index4].Position);
            if (index5 != -1)
            {
              point3.Up = index5;
              UILinkPointNavigator.Points[index5].Down = ID3;
            }
            if (numArray[index6] != -1)
            {
              point3.Left = numArray[index6];
              UILinkPointNavigator.Points[numArray[index6]].Right = ID3;
            }
            point3.Down = index1;
            if (index4 == 0)
              UILinkPointNavigator.Points[index1].Up = UILinkPointNavigator.Points[index1 + 1].Up = ID3;
            index5 = ID3;
            numArray[index6] = ID3;
            UILinkPointNavigator.Shortcuts.FANCYUI_HIGHEST_INDEX = ID3;
            ++ID3;
          }
        }
      }
      if (!PlayerInput.UsingGamepadUI || this._playerList.Count != 0 || UILinkPointNavigator.CurrentPoint <= 3001)
        return;
      UILinkPointNavigator.ChangePoint(3001);
    }
  }
}
