﻿// Decompiled with JetBrains decompiler
// Type: Terraria.World.Generation.GenShape
// Assembly: TerrariaServer, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: AA3606A2-F3DB-4481-937B-7295FB97CD3E
// Assembly location: E:\TSHOCK\TerrariaServer.exe

using Microsoft.Xna.Framework;

namespace Terraria.World.Generation
{
  public abstract class GenShape : GenBase
  {
    private ShapeData _outputData;
    protected bool _quitOnFail;

    public abstract bool Perform(Point origin, GenAction action);

    protected bool UnitApply(GenAction action, Point origin, int x, int y, params object[] args)
    {
      if (this._outputData != null)
        this._outputData.Add(x - origin.X, y - origin.Y);
      return action.Apply(origin, x, y, args);
    }

    public GenShape Output(ShapeData outputData)
    {
      this._outputData = outputData;
      return this;
    }

    public GenShape QuitOnFail(bool value = true)
    {
      this._quitOnFail = value;
      return this;
    }
  }
}
