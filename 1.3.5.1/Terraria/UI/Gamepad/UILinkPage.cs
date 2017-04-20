// Decompiled with JetBrains decompiler
// Type: Terraria.UI.Gamepad.UILinkPage
// Assembly: TerrariaServer, Version=1.3.5.1, Culture=neutral, PublicKeyToken=null
// MVID: 5CBA2320-074B-43F7-8CDC-BF1E2B81EE4B
// Assembly location: C:\Users\kevzhao\Downloads\TerrariaServer.exe

using System;
using System.Collections.Generic;
using System.Threading;

namespace Terraria.UI.Gamepad
{
  public class UILinkPage
  {
    public int PageOnLeft = -1;
    public int PageOnRight = -1;
    public Dictionary<int, UILinkPoint> LinkMap = new Dictionary<int, UILinkPoint>();
    public int ID;
    public int DefaultPoint;
    public int CurrentPoint;
    private Action<int, int> ReachEndEvent;
    private Action TravelEvent;
    private Action LeaveEvent;
    private Action EnterEvent;
    private Action UpdateEvent;
    private Func<bool> IsValidEvent;
    private Func<bool> CanEnterEvent;
    private Func<string> OnSpecialInteracts;

    public event Action<int, int> ReachEndEvent
    {
      add
      {
        Action<int, int> action = this.ReachEndEvent;
        Action<int, int> comparand;
        do
        {
          comparand = action;
          action = Interlocked.CompareExchange<Action<int, int>>(ref this.ReachEndEvent, (Action<int, int>) Delegate.Combine((Delegate) comparand, (Delegate) value), comparand);
        }
        while (action != comparand);
      }
      remove
      {
        Action<int, int> action = this.ReachEndEvent;
        Action<int, int> comparand;
        do
        {
          comparand = action;
          action = Interlocked.CompareExchange<Action<int, int>>(ref this.ReachEndEvent, (Action<int, int>) Delegate.Remove((Delegate) comparand, (Delegate) value), comparand);
        }
        while (action != comparand);
      }
    }

    public event Action TravelEvent
    {
      add
      {
        Action action = this.TravelEvent;
        Action comparand;
        do
        {
          comparand = action;
          action = Interlocked.CompareExchange<Action>(ref this.TravelEvent, (Action) Delegate.Combine((Delegate) comparand, (Delegate) value), comparand);
        }
        while (action != comparand);
      }
      remove
      {
        Action action = this.TravelEvent;
        Action comparand;
        do
        {
          comparand = action;
          action = Interlocked.CompareExchange<Action>(ref this.TravelEvent, (Action) Delegate.Remove((Delegate) comparand, (Delegate) value), comparand);
        }
        while (action != comparand);
      }
    }

    public event Action LeaveEvent
    {
      add
      {
        Action action = this.LeaveEvent;
        Action comparand;
        do
        {
          comparand = action;
          action = Interlocked.CompareExchange<Action>(ref this.LeaveEvent, (Action) Delegate.Combine((Delegate) comparand, (Delegate) value), comparand);
        }
        while (action != comparand);
      }
      remove
      {
        Action action = this.LeaveEvent;
        Action comparand;
        do
        {
          comparand = action;
          action = Interlocked.CompareExchange<Action>(ref this.LeaveEvent, (Action) Delegate.Remove((Delegate) comparand, (Delegate) value), comparand);
        }
        while (action != comparand);
      }
    }

    public event Action EnterEvent
    {
      add
      {
        Action action = this.EnterEvent;
        Action comparand;
        do
        {
          comparand = action;
          action = Interlocked.CompareExchange<Action>(ref this.EnterEvent, (Action) Delegate.Combine((Delegate) comparand, (Delegate) value), comparand);
        }
        while (action != comparand);
      }
      remove
      {
        Action action = this.EnterEvent;
        Action comparand;
        do
        {
          comparand = action;
          action = Interlocked.CompareExchange<Action>(ref this.EnterEvent, (Action) Delegate.Remove((Delegate) comparand, (Delegate) value), comparand);
        }
        while (action != comparand);
      }
    }

    public event Action UpdateEvent
    {
      add
      {
        Action action = this.UpdateEvent;
        Action comparand;
        do
        {
          comparand = action;
          action = Interlocked.CompareExchange<Action>(ref this.UpdateEvent, (Action) Delegate.Combine((Delegate) comparand, (Delegate) value), comparand);
        }
        while (action != comparand);
      }
      remove
      {
        Action action = this.UpdateEvent;
        Action comparand;
        do
        {
          comparand = action;
          action = Interlocked.CompareExchange<Action>(ref this.UpdateEvent, (Action) Delegate.Remove((Delegate) comparand, (Delegate) value), comparand);
        }
        while (action != comparand);
      }
    }

    public event Func<bool> IsValidEvent
    {
      add
      {
        Func<bool> func = this.IsValidEvent;
        Func<bool> comparand;
        do
        {
          comparand = func;
          func = Interlocked.CompareExchange<Func<bool>>(ref this.IsValidEvent, (Func<bool>) Delegate.Combine((Delegate) comparand, (Delegate) value), comparand);
        }
        while (func != comparand);
      }
      remove
      {
        Func<bool> func = this.IsValidEvent;
        Func<bool> comparand;
        do
        {
          comparand = func;
          func = Interlocked.CompareExchange<Func<bool>>(ref this.IsValidEvent, (Func<bool>) Delegate.Remove((Delegate) comparand, (Delegate) value), comparand);
        }
        while (func != comparand);
      }
    }

    public event Func<bool> CanEnterEvent
    {
      add
      {
        Func<bool> func = this.CanEnterEvent;
        Func<bool> comparand;
        do
        {
          comparand = func;
          func = Interlocked.CompareExchange<Func<bool>>(ref this.CanEnterEvent, (Func<bool>) Delegate.Combine((Delegate) comparand, (Delegate) value), comparand);
        }
        while (func != comparand);
      }
      remove
      {
        Func<bool> func = this.CanEnterEvent;
        Func<bool> comparand;
        do
        {
          comparand = func;
          func = Interlocked.CompareExchange<Func<bool>>(ref this.CanEnterEvent, (Func<bool>) Delegate.Remove((Delegate) comparand, (Delegate) value), comparand);
        }
        while (func != comparand);
      }
    }

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

    public UILinkPage()
    {
    }

    public UILinkPage(int id)
    {
      this.ID = id;
    }

    public void Update()
    {
      if (this.UpdateEvent == null)
        return;
      this.UpdateEvent.Invoke();
    }

    public void Leave()
    {
      if (this.LeaveEvent == null)
        return;
      this.LeaveEvent.Invoke();
    }

    public void Enter()
    {
      if (this.EnterEvent == null)
        return;
      this.EnterEvent.Invoke();
    }

    public bool IsValid()
    {
      if (this.IsValidEvent != null)
        return this.IsValidEvent.Invoke();
      return true;
    }

    public bool CanEnter()
    {
      if (this.CanEnterEvent != null)
        return this.CanEnterEvent.Invoke();
      return true;
    }

    public void TravelUp()
    {
      this.Travel(this.LinkMap[this.CurrentPoint].Up);
    }

    public void TravelDown()
    {
      this.Travel(this.LinkMap[this.CurrentPoint].Down);
    }

    public void TravelLeft()
    {
      this.Travel(this.LinkMap[this.CurrentPoint].Left);
    }

    public void TravelRight()
    {
      this.Travel(this.LinkMap[this.CurrentPoint].Right);
    }

    public void SwapPageLeft()
    {
      UILinkPointNavigator.ChangePage(this.PageOnLeft);
    }

    public void SwapPageRight()
    {
      UILinkPointNavigator.ChangePage(this.PageOnRight);
    }

    private void Travel(int next)
    {
      if (next < 0)
      {
        if (this.ReachEndEvent == null)
          return;
        this.ReachEndEvent.Invoke(this.CurrentPoint, next);
        if (this.TravelEvent == null)
          return;
        this.TravelEvent.Invoke();
      }
      else
      {
        UILinkPointNavigator.ChangePoint(next);
        if (this.TravelEvent == null)
          return;
        this.TravelEvent.Invoke();
      }
    }

    public string SpecialInteractions()
    {
      if (this.OnSpecialInteracts != null)
        return this.OnSpecialInteracts.Invoke();
      return string.Empty;
    }
  }
}
