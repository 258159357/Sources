// Decompiled with JetBrains decompiler
// Type: Terraria.Achievements.IAchievementTracker
// Assembly: TerrariaServer, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: AA3606A2-F3DB-4481-937B-7295FB97CD3E
// Assembly location: E:\TSHOCK\TerrariaServer.exe

namespace Terraria.Achievements
{
  public interface IAchievementTracker
  {
    void ReportAs(string name);

    TrackerType GetTrackerType();

    void Load();

    void Clear();
  }
}
