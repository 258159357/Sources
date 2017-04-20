﻿// Decompiled with JetBrains decompiler
// Type: Terraria.Modules.TileObjectAlternatesModule
// Assembly: TerrariaServer, Version=1.3.5.0, Culture=neutral, PublicKeyToken=null
// MVID: 13381DB9-8FD8-4EBB-8CED-9CF82DC89291
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Terraria\TerrariaServer.exe

using System.Collections.Generic;
using Terraria.ObjectData;

namespace Terraria.Modules
{
  public class TileObjectAlternatesModule
  {
    public List<TileObjectData> data;

    public TileObjectAlternatesModule(TileObjectAlternatesModule copyFrom = null)
    {
      if (copyFrom == null)
        this.data = (List<TileObjectData>) null;
      else if (copyFrom.data == null)
      {
        this.data = (List<TileObjectData>) null;
      }
      else
      {
        this.data = new List<TileObjectData>(copyFrom.data.Count);
        for (int index = 0; index < copyFrom.data.Count; ++index)
          this.data.Add(new TileObjectData(copyFrom.data[index]));
      }
    }
  }
}
