// Decompiled with JetBrains decompiler
// Type: Terraria.World.Generation.GenModShape
// Assembly: TerrariaServer, Version=1.3.5.1, Culture=neutral, PublicKeyToken=null
// MVID: 5CBA2320-074B-43F7-8CDC-BF1E2B81EE4B
// Assembly location: C:\Users\kevzhao\Downloads\TerrariaServer.exe

namespace Terraria.World.Generation
{
  public abstract class GenModShape : GenShape
  {
    protected ShapeData _data;

    public GenModShape(ShapeData data)
    {
      this._data = data;
    }
  }
}
