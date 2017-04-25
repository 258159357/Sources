// Decompiled with JetBrains decompiler
// Type: Terraria.Social.Base.OverlaySocialModule
// Assembly: TerrariaServer, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: AA3606A2-F3DB-4481-937B-7295FB97CD3E
// Assembly location: E:\TSHOCK\TerrariaServer.exe

namespace Terraria.Social.Base
{
  public abstract class OverlaySocialModule : ISocialModule
  {
    public abstract void Initialize();

    public abstract void Shutdown();

    public abstract bool IsGamepadTextInputActive();

    public abstract bool ShowGamepadTextInput(string description, uint maxLength, bool multiLine = false, string existingText = "", bool password = false);

    public abstract string GetGamepadText();
  }
}
