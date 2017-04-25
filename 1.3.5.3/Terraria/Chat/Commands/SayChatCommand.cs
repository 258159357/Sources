// Decompiled with JetBrains decompiler
// Type: Terraria.Chat.Commands.SayChatCommand
// Assembly: TerrariaServer, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: AA3606A2-F3DB-4481-937B-7295FB97CD3E
// Assembly location: E:\TSHOCK\TerrariaServer.exe

using System;
using Terraria.GameContent.NetModules;
using Terraria.Localization;
using Terraria.Net;

namespace Terraria.Chat.Commands
{
  [ChatCommand("Say")]
  public class SayChatCommand : IChatCommand
  {
    public void ProcessMessage(string text, byte clientId)
    {
      NetPacket packet = NetTextModule.SerializeServerMessage(NetworkText.FromLiteral(text), Main.player[(int) clientId].ChatColor(), clientId);
      NetManager.Instance.Broadcast(packet, -1);
      Console.WriteLine("<{0}> {1}", (object) Main.player[(int) clientId].name, (object) text);
    }
  }
}
