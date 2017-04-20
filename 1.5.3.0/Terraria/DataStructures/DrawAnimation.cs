// Decompiled with JetBrains decompiler
// Type: Terraria.DataStructures.DrawAnimation
// Assembly: TerrariaServer, Version=1.3.5.0, Culture=neutral, PublicKeyToken=null
// MVID: 13381DB9-8FD8-4EBB-8CED-9CF82DC89291
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Terraria\TerrariaServer.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Terraria.DataStructures
{
  public class DrawAnimation
  {
    public int Frame;
    public int FrameCount;
    public int TicksPerFrame;
    public int FrameCounter;

    public virtual void Update()
    {
    }

    public virtual Rectangle GetFrame(Texture2D texture)
    {
      return texture.Frame(1, 1, 0, 0);
    }
  }
}
