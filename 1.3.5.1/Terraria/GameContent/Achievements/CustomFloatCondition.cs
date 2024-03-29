﻿// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Achievements.CustomFloatCondition
// Assembly: TerrariaServer, Version=1.3.5.1, Culture=neutral, PublicKeyToken=null
// MVID: 5CBA2320-074B-43F7-8CDC-BF1E2B81EE4B
// Assembly location: C:\Users\kevzhao\Downloads\TerrariaServer.exe

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Terraria.Achievements;

namespace Terraria.GameContent.Achievements
{
  public class CustomFloatCondition : AchievementCondition
  {
    [JsonProperty("Value")]
    private float _value;
    private float _maxValue;

    public float Value
    {
      get
      {
        return this._value;
      }
      set
      {
        float newValue = Utils.Clamp<float>(value, 0.0f, this._maxValue);
        if (this._tracker != null)
          ((AchievementTracker<float>) this._tracker).SetValue(newValue, true);
        this._value = newValue;
        if ((double) this._value != (double) this._maxValue)
          return;
        this.Complete();
      }
    }

    private CustomFloatCondition(string name, float maxValue)
      : base(name)
    {
      this._maxValue = maxValue;
      this._value = 0.0f;
    }

    public override void Clear()
    {
      this._value = 0.0f;
      base.Clear();
    }

    public override void Load(JObject state)
    {
      base.Load(state);
      this._value = JToken.op_Explicit(state.get_Item("Value"));
      if (this._tracker == null)
        return;
      ((AchievementTracker<float>) this._tracker).SetValue(this._value, false);
    }

    protected override IAchievementTracker CreateAchievementTracker()
    {
      return (IAchievementTracker) new ConditionFloatTracker(this._maxValue);
    }

    public static AchievementCondition Create(string name, float maxValue)
    {
      return (AchievementCondition) new CustomFloatCondition(name, maxValue);
    }
  }
}
