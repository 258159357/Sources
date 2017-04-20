// Decompiled with JetBrains decompiler
// Type: Terraria.UI.StyleDimension
// Assembly: TerrariaServer, Version=1.3.5.1, Culture=neutral, PublicKeyToken=null
// MVID: 5CBA2320-074B-43F7-8CDC-BF1E2B81EE4B
// Assembly location: C:\Users\kevzhao\Downloads\TerrariaServer.exe

namespace Terraria.UI
{
  public struct StyleDimension
  {
    public static StyleDimension Fill = new StyleDimension(0.0f, 1f);
    public static StyleDimension Empty = new StyleDimension(0.0f, 0.0f);
    public float Pixels;
    public float Precent;

    public StyleDimension(float pixels, float precent)
    {
      this.Pixels = pixels;
      this.Precent = precent;
    }

    public void Set(float pixels, float precent)
    {
      this.Pixels = pixels;
      this.Precent = precent;
    }

    public float GetValue(float containerSize)
    {
      return this.Pixels + this.Precent * containerSize;
    }
  }
}
