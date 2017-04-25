// Decompiled with JetBrains decompiler
// Type: Terraria.Initializers.ChatInitializer
// Assembly: TerrariaServer, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: AA3606A2-F3DB-4481-937B-7295FB97CD3E
// Assembly location: E:\TSHOCK\TerrariaServer.exe

using Terraria.Chat.Commands;
using Terraria.GameContent.UI.Chat;
using Terraria.UI.Chat;

namespace Terraria.Initializers
{
  public static class ChatInitializer
  {
    public static void Load()
    {
      ChatManager.Register<ColorTagHandler>("c", "color");
      ChatManager.Register<ItemTagHandler>("i", "item");
      ChatManager.Register<NameTagHandler>("n", "name");
      ChatManager.Register<AchievementTagHandler>("a", "achievement");
      ChatManager.Register<GlyphTagHandler>("g", "glyph");
      ChatManager.Commands.AddCommand<PartyChatCommand>().AddCommand<RollCommand>().AddCommand<EmoteCommand>().AddCommand<ListPlayersCommand>().AddDefaultCommand<SayChatCommand>();
    }
  }
}
