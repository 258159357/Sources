﻿// Decompiled with JetBrains decompiler
// Type: Terraria.DataStructures.DrawAnimationVertical
// Assembly: TerrariaServer, Version=1.3.5.1, Culture=neutral, PublicKeyToken=null
// MVID: 5CBA2320-074B-43F7-8CDC-BF1E2B81EE4B
// Assembly location: C:\Users\kevzhao\Downloads\TerrariaServer.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Terraria.DataStructures
{
  public class DrawAnimationVertical : DrawAnimation
  {
    public DrawAnimationVertical(int ticksperframe, int frameCount)
    {
      this.Frame = 0;
      this.FrameCounter = 0;
      this.FrameCount = frameCount;
      this.TicksPerFrame = ticksperframe;
    }

    public override void Update()
    {
      if (++this.FrameCounter < this.TicksPerFrame)
        return;
      this.FrameCounter = 0;
      if (++this.Frame < this.FrameCount)
        return;
      this.Frame = 0;
    }

    public override Rectangle GetFrame(Texture2D texture)
    {
      return texture.Frame(1, this.FrameCount, 0, this.Frame);
    }
  }
}