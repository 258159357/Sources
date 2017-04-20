// Decompiled with JetBrains decompiler
// Type: Terraria.Modules.TileObjectDrawModule
// Assembly: TerrariaServer, Version=1.3.5.1, Culture=neutral, PublicKeyToken=null
// MVID: 5CBA2320-074B-43F7-8CDC-BF1E2B81EE4B
// Assembly location: C:\Users\kevzhao\Downloads\TerrariaServer.exe

namespace Terraria.Modules
{
  public class TileObjectDrawModule
  {
    public int yOffset;
    public bool flipHorizontal;
    public bool flipVertical;
    public int stepDown;

    public TileObjectDrawModule(TileObjectDrawModule copyFrom = null)
    {
      if (copyFrom == null)
      {
        this.yOffset = 0;
        this.flipHorizontal = false;
        this.flipVertical = false;
        this.stepDown = 0;
      }
      else
      {
        this.yOffset = copyFrom.yOffset;
        this.flipHorizontal = copyFrom.flipHorizontal;
        this.flipVertical = copyFrom.flipVertical;
        this.stepDown = copyFrom.stepDown;
      }
    }
  }
}
