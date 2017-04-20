// Decompiled with JetBrains decompiler
// Type: Terraria.UI.Gamepad.UILinkPoint
// Assembly: TerrariaServer, Version=1.3.5.1, Culture=neutral, PublicKeyToken=null
// MVID: 5CBA2320-074B-43F7-8CDC-BF1E2B81EE4B
// Assembly location: C:\Users\kevzhao\Downloads\TerrariaServer.exe

using Microsoft.Xna.Framework;
using System;
using System.Threading;

namespace Terraria.UI.Gamepad
{
  public class UILinkPoint
  {
    public int ID;
    public bool Enabled;
    public Vector2 Position;
    public int Left;
    public int Right;
    public int Up;
    public int Down;
    private Func<string> OnSpecialInteracts;

    public int Page { get; private set; }

    public event Func<string> OnSpecialInteracts
    {
      add
      {
        Func<string> func = this.OnSpecialInteracts;
        Func<string> comparand;
        do
        {
          comparand = func;
          func = Interlocked.CompareExchange<Func<string>>(ref this.OnSpecialInteracts, (Func<string>) Delegate.Combine((Delegate) comparand, (Delegate) value), comparand);
        }
        while (func != comparand);
      }
      remove
      {
        Func<string> func = this.OnSpecialInteracts;
        Func<string> comparand;
        do
        {
          comparand = func;
          func = Interlocked.CompareExchange<Func<string>>(ref this.OnSpecialInteracts, (Func<string>) Delegate.Remove((Delegate) comparand, (Delegate) value), comparand);
        }
        while (func != comparand);
      }
    }

    public UILinkPoint(int id, bool enabled, int left, int right, int up, int down)
    {
      this.ID = id;
      this.Enabled = enabled;
      this.Left = left;
      this.Right = right;
      this.Up = up;
      this.Down = down;
    }

    public void SetPage(int page)
    {
      this.Page = page;
    }

    public void Unlink()
    {
      this.Left = -3;
      this.Right = -4;
      this.Up = -1;
      this.Down = -2;
    }

    public string SpecialInteractions()
    {
      if (this.OnSpecialInteracts != null)
        return this.OnSpecialInteracts.Invoke();
      return string.Empty;
    }
  }
}
