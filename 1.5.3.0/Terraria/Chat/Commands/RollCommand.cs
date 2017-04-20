// Decompiled with JetBrains decompiler
// Type: Terraria.Chat.Commands.RollCommand
// Assembly: TerrariaServer, Version=1.3.5.0, Culture=neutral, PublicKeyToken=null
// MVID: 13381DB9-8FD8-4EBB-8CED-9CF82DC89291
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Terraria\TerrariaServer.exe

using Microsoft.Xna.Framework;
using Terraria.Localization;

namespace Terraria.Chat.Commands
{
  [ChatCommand("Roll")]
  public class RollCommand : IChatCommand
  {
    private static readonly Color RESPONSE_COLOR = new Color((int) byte.MaxValue, 240, 20);

    public string InternalName
    {
      get
      {
        return "roll";
      }
    }

    public void ProcessMessage(string text, byte clientId)
    {
      int num = Main.rand.Next(1, 101);
      NetMessage.BroadcastChatMessage(NetworkText.FromFormattable("*{0} {1} {2}", (object) Main.player[(int) clientId].name, (object) Lang.mp[9].ToNetworkText(), (object) num), RollCommand.RESPONSE_COLOR, -1);
    }
  }
}
