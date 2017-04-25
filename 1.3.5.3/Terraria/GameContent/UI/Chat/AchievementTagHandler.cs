// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.Chat.AchievementTagHandler
// Assembly: TerrariaServer, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: AA3606A2-F3DB-4481-937B-7295FB97CD3E
// Assembly location: E:\TSHOCK\TerrariaServer.exe

using Microsoft.Xna.Framework;
using Terraria.Achievements;
using Terraria.UI;
using Terraria.UI.Chat;

namespace Terraria.GameContent.UI.Chat
{
  public class AchievementTagHandler : ITagHandler
  {
    TextSnippet ITagHandler.Parse(string text, Color baseColor, string options)
    {
      Achievement achievement = Main.Achievements.GetAchievement(text);
      if (achievement == null)
        return new TextSnippet(text);
      return (TextSnippet) new AchievementTagHandler.AchievementSnippet(achievement);
    }

    public static string GenerateTag(Achievement achievement)
    {
      return "[a:" + achievement.Name + "]";
    }

    private class AchievementSnippet : TextSnippet
    {
      private Achievement _achievement;

      public AchievementSnippet(Achievement achievement)
        : base(achievement.FriendlyName.Value, Color.LightBlue, 1f)
      {
        this.CheckForHover = true;
        this._achievement = achievement;
      }

      public override void OnClick()
      {
        IngameOptions.Close();
        IngameFancyUI.OpenAchievementsAndGoto(this._achievement);
      }
    }
  }
}
