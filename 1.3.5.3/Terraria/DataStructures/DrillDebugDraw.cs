// Decompiled with JetBrains decompiler
// Type: Terraria.DataStructures.DrillDebugDraw
// Assembly: TerrariaServer, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: AA3606A2-F3DB-4481-937B-7295FB97CD3E
// Assembly location: E:\TSHOCK\TerrariaServer.exe

using Microsoft.Xna.Framework;

namespace Terraria.DataStructures
{
  public struct DrillDebugDraw
  {
    public Vector2 point;
    public Color color;

    public DrillDebugDraw(Vector2 p, Color c)
    {
      this.point = p;
      this.color = c;
    }
  }
}
