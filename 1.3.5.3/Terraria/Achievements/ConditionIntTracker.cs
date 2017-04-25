// Decompiled with JetBrains decompiler
// Type: Terraria.Achievements.ConditionIntTracker
// Assembly: TerrariaServer, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: AA3606A2-F3DB-4481-937B-7295FB97CD3E
// Assembly location: E:\TSHOCK\TerrariaServer.exe

using Terraria.Social;

namespace Terraria.Achievements
{
  public class ConditionIntTracker : AchievementTracker<int>
  {
    public ConditionIntTracker()
      : base(TrackerType.Int)
    {
    }

    public ConditionIntTracker(int maxValue)
      : base(TrackerType.Int)
    {
      this._maxValue = maxValue;
    }

    public override void ReportUpdate()
    {
      if (SocialAPI.Achievements == null || this._name == null)
        return;
      SocialAPI.Achievements.UpdateIntStat(this._name, this._value);
    }

    protected override void Load()
    {
    }
  }
}
