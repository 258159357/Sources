// Decompiled with JetBrains decompiler
// Type: Terraria.Initializers.ChatInitializer
// Assembly: TerrariaServer, Version=1.3.5.1, Culture=neutral, PublicKeyToken=null
// MVID: 5CBA2320-074B-43F7-8CDC-BF1E2B81EE4B
// Assembly location: C:\Users\kevzhao\Downloads\TerrariaServer.exe

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
