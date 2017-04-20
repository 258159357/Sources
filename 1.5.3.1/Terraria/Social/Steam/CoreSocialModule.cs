// Decompiled with JetBrains decompiler
// Type: Terraria.Social.Steam.CoreSocialModule
// Assembly: TerrariaServer, Version=1.3.5.1, Culture=neutral, PublicKeyToken=null
// MVID: 5CBA2320-074B-43F7-8CDC-BF1E2B81EE4B
// Assembly location: C:\Users\kevzhao\Downloads\TerrariaServer.exe

using Steamworks;
using System;
using System.Threading;
using System.Windows.Forms;
using Terraria.Localization;

namespace Terraria.Social.Steam
{
  public class CoreSocialModule : ISocialModule
  {
    private object _steamTickLock = new object();
    private object _steamCallbackLock = new object();
    public const int SteamAppId = 105600;
    private static CoreSocialModule _instance;
    private bool IsSteamValid;
    private static Action OnTick;
    private Callback<GameOverlayActivated_t> _onOverlayActivated;

    public static event Action OnTick
    {
      add
      {
        Action action1 = CoreSocialModule.OnTick;
        Action comparand;
        do
        {
          comparand = action1;
          Action action2 = (Action) Delegate.Combine((Delegate) comparand, (Delegate) value);
          action1 = Interlocked.CompareExchange<Action>(ref CoreSocialModule.OnTick, action2, comparand);
        }
        while (action1 != comparand);
      }
      remove
      {
        Action action1 = CoreSocialModule.OnTick;
        Action comparand;
        do
        {
          comparand = action1;
          Action action2 = (Action) Delegate.Remove((Delegate) comparand, (Delegate) value);
          action1 = Interlocked.CompareExchange<Action>(ref CoreSocialModule.OnTick, action2, comparand);
        }
        while (action1 != comparand);
      }
    }

    public void Initialize()
    {
      CoreSocialModule._instance = this;
      if (!SteamAPI.Init())
      {
        int num = (int) MessageBox.Show(Language.GetTextValue("Error.LaunchFromSteam"), Language.GetTextValue("Error.Error"));
        Environment.Exit(1);
      }
      this.IsSteamValid = true;
      ThreadPool.QueueUserWorkItem(new WaitCallback(this.SteamCallbackLoop), (object) null);
      ThreadPool.QueueUserWorkItem(new WaitCallback(this.SteamTickLoop), (object) null);
      // ISSUE: method pointer
      Main.OnTick += new Action((object) this, __methodptr(PulseSteamTick));
      // ISSUE: method pointer
      Main.OnTick += new Action((object) this, __methodptr(PulseSteamCallback));
    }

    public void PulseSteamTick()
    {
      if (!Monitor.TryEnter(this._steamTickLock))
        return;
      Monitor.Pulse(this._steamTickLock);
      Monitor.Exit(this._steamTickLock);
    }

    public void PulseSteamCallback()
    {
      if (!Monitor.TryEnter(this._steamCallbackLock))
        return;
      Monitor.Pulse(this._steamCallbackLock);
      Monitor.Exit(this._steamCallbackLock);
    }

    public static void Pulse()
    {
      CoreSocialModule._instance.PulseSteamTick();
      CoreSocialModule._instance.PulseSteamCallback();
    }

    private void SteamTickLoop(object context)
    {
      Monitor.Enter(this._steamTickLock);
      while (this.IsSteamValid)
      {
        if (CoreSocialModule.OnTick != null)
          CoreSocialModule.OnTick.Invoke();
        Monitor.Wait(this._steamTickLock);
      }
      Monitor.Exit(this._steamTickLock);
    }

    private void SteamCallbackLoop(object context)
    {
      Monitor.Enter(this._steamCallbackLock);
      while (this.IsSteamValid)
      {
        SteamAPI.RunCallbacks();
        Monitor.Wait(this._steamCallbackLock);
      }
      Monitor.Exit(this._steamCallbackLock);
      SteamAPI.Shutdown();
    }

    public void Shutdown()
    {
      Application.ApplicationExit += (EventHandler) ((obj, evt) => this.IsSteamValid = false);
    }

    public void OnOverlayActivated(GameOverlayActivated_t result)
    {
      Main.instance.IsMouseVisible = result.m_bActive == 1;
    }
  }
}
