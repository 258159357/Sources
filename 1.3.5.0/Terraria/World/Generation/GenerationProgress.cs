﻿// Decompiled with JetBrains decompiler
// Type: Terraria.World.Generation.GenerationProgress
// Assembly: TerrariaServer, Version=1.3.5.0, Culture=neutral, PublicKeyToken=null
// MVID: 13381DB9-8FD8-4EBB-8CED-9CF82DC89291
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Terraria\TerrariaServer.exe

namespace Terraria.World.Generation
{
  public class GenerationProgress
  {
    private string _message = "";
    public float CurrentPassWeight = 1f;
    private float _value;
    private float _totalProgress;
    public float TotalWeight;

    public string Message
    {
      get
      {
        return string.Format(this._message, (object) this.Value);
      }
      set
      {
        this._message = value.Replace("%", "{0:0.0%}");
      }
    }

    public float Value
    {
      get
      {
        return this._value;
      }
      set
      {
        this._value = Utils.Clamp<float>(value, 0.0f, 1f);
      }
    }

    public float TotalProgress
    {
      get
      {
        if ((double) this.TotalWeight == 0.0)
          return 0.0f;
        return (this.Value * this.CurrentPassWeight + this._totalProgress) / this.TotalWeight;
      }
    }

    public void Set(float value)
    {
      this.Value = value;
    }

    public void Start(float weight)
    {
      this.CurrentPassWeight = weight;
      this._value = 0.0f;
    }

    public void End()
    {
      this._totalProgress += this.CurrentPassWeight;
    }
  }
}
