// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Achievements.CustomFlagCondition
// Assembly: TerrariaServer, Version=1.3.5.0, Culture=neutral, PublicKeyToken=null
// MVID: 13381DB9-8FD8-4EBB-8CED-9CF82DC89291
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Terraria\TerrariaServer.exe

using Terraria.Achievements;

namespace Terraria.GameContent.Achievements
{
  public class CustomFlagCondition : AchievementCondition
  {
    private CustomFlagCondition(string name)
      : base(name)
    {
    }

    public static AchievementCondition Create(string name)
    {
      return (AchievementCondition) new CustomFlagCondition(name);
    }
  }
}
