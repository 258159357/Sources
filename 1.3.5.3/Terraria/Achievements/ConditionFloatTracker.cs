// Decompiled with JetBrains decompiler
// Type: Terraria.Achievements.ConditionFloatTracker
// Assembly: TerrariaServer, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: AA3606A2-F3DB-4481-937B-7295FB97CD3E
// Assembly location: E:\TSHOCK\TerrariaServer.exe

using Terraria.Social;

namespace Terraria.Achievements
{
  public class ConditionFloatTracker : AchievementTracker<float>
  {
    public ConditionFloatTracker(float maxValue)
      : base(TrackerType.Float)
    {
      this._maxValue = maxValue;
    }

    public ConditionFloatTracker()
      : base(TrackerType.Float)
    {
    }

    public override void ReportUpdate()
    {
      if (SocialAPI.Achievements == null || this._name == null)
        return;
      SocialAPI.Achievements.UpdateFloatStat(this._name, this._value);
    }

    protected override void Load()
    {
    }
  }
}
