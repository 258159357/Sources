// Decompiled with JetBrains decompiler
// Type: Terraria.Achievements.ConditionsCompletedTracker
// Assembly: TerrariaServer, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: AA3606A2-F3DB-4481-937B-7295FB97CD3E
// Assembly location: E:\TSHOCK\TerrariaServer.exe

using System;
using System.Collections.Generic;

namespace Terraria.Achievements
{
  public class ConditionsCompletedTracker : ConditionIntTracker
  {
    private List<AchievementCondition> _conditions = new List<AchievementCondition>();

    public void AddCondition(AchievementCondition condition)
    {
      this._maxValue = this._maxValue + 1;
      condition.OnComplete += new AchievementCondition.AchievementUpdate(this.OnConditionCompleted);
      this._conditions.Add(condition);
    }

    private void OnConditionCompleted(AchievementCondition condition)
    {
      this.SetValue(Math.Min(this._value + 1, this._maxValue), true);
    }

    protected override void Load()
    {
      for (int index = 0; index < this._conditions.Count; ++index)
      {
        if (this._conditions[index].IsCompleted)
          this._value = this._value + 1;
      }
    }
  }
}
