// Decompiled with JetBrains decompiler
// Type: Terraria.Chat.Commands.ListPlayersCommand
// Assembly: TerrariaServer, Version=1.3.5.1, Culture=neutral, PublicKeyToken=null
// MVID: 5CBA2320-074B-43F7-8CDC-BF1E2B81EE4B
// Assembly location: C:\Users\kevzhao\Downloads\TerrariaServer.exe

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria.Localization;

namespace Terraria.Chat.Commands
{
  [ChatCommand("Playing")]
  public class ListPlayersCommand : IChatCommand
  {
    private static readonly Color RESPONSE_COLOR = new Color((int) byte.MaxValue, 240, 20);

    public void ProcessMessage(string text, byte clientId)
    {
      string str = ", ";
      Player[] player = Main.player;
      // ISSUE: reference to a compiler-generated field
      if (ListPlayersCommand.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate2 == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        ListPlayersCommand.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate2 = new Func<Player, bool>((object) null, __methodptr(\u003CProcessMessage\u003Eb__0));
      }
      // ISSUE: reference to a compiler-generated field
      Func<Player, bool> anonymousMethodDelegate2 = ListPlayersCommand.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate2;
      IEnumerable<M0> m0s = Enumerable.Where<Player>((IEnumerable<M0>) player, (Func<M0, bool>) anonymousMethodDelegate2);
      // ISSUE: reference to a compiler-generated field
      if (ListPlayersCommand.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate3 == null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: method pointer
        ListPlayersCommand.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate3 = new Func<Player, string>((object) null, __methodptr(\u003CProcessMessage\u003Eb__1));
      }
      // ISSUE: reference to a compiler-generated field
      Func<Player, string> anonymousMethodDelegate3 = ListPlayersCommand.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate3;
      IEnumerable<M1> m1s = Enumerable.Select<Player, string>(m0s, (Func<M0, M1>) anonymousMethodDelegate3);
      NetMessage.SendChatMessageToClient(NetworkText.FromLiteral(string.Join(str, (IEnumerable<string>) m1s)), ListPlayersCommand.RESPONSE_COLOR, (int) clientId);
    }
  }
}
