﻿// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Generation.ShapeFloodFill
// Assembly: TerrariaServer, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: AA3606A2-F3DB-4481-937B-7295FB97CD3E
// Assembly location: E:\TSHOCK\TerrariaServer.exe

using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.DataStructures;
using Terraria.World.Generation;

namespace Terraria.GameContent.Generation
{
  public class ShapeFloodFill : GenShape
  {
    private int _maximumActions;

    public ShapeFloodFill(int maximumActions = 100)
    {
      this._maximumActions = maximumActions;
    }

    public override bool Perform(Point origin, GenAction action)
    {
      Queue<Point> pointQueue = new Queue<Point>();
      HashSet<Point16> point16Set = new HashSet<Point16>();
      pointQueue.Enqueue(origin);
      int maximumActions = this._maximumActions;
      while (pointQueue.Count > 0 && maximumActions > 0)
      {
        Point point = pointQueue.Dequeue();
        if (!point16Set.Contains(new Point16(point.X, point.Y)) && this.UnitApply(action, origin, point.X, point.Y))
        {
          point16Set.Add(new Point16(point));
          --maximumActions;
          if (point.X + 1 < Main.maxTilesX - 1)
            pointQueue.Enqueue(new Point(point.X + 1, point.Y));
          if (point.X - 1 >= 1)
            pointQueue.Enqueue(new Point(point.X - 1, point.Y));
          if (point.Y + 1 < Main.maxTilesY - 1)
            pointQueue.Enqueue(new Point(point.X, point.Y + 1));
          if (point.Y - 1 >= 1)
            pointQueue.Enqueue(new Point(point.X, point.Y - 1));
        }
      }
      while (pointQueue.Count > 0)
      {
        Point point = pointQueue.Dequeue();
        if (!point16Set.Contains(new Point16(point.X, point.Y)))
        {
          pointQueue.Enqueue(point);
          break;
        }
      }
      return pointQueue.Count == 0;
    }
  }
}
