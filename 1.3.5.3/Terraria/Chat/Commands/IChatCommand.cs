// Decompiled with JetBrains decompiler
// Type: Terraria.Chat.Commands.IChatCommand
// Assembly: TerrariaServer, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: AA3606A2-F3DB-4481-937B-7295FB97CD3E
// Assembly location: E:\TSHOCK\TerrariaServer.exe

namespace Terraria.Chat.Commands
{
  public interface IChatCommand
  {
    void ProcessMessage(string text, byte clientId);
  }
}
