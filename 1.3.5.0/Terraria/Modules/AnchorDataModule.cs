// Decompiled with JetBrains decompiler
// Type: Terraria.Modules.AnchorDataModule
// Assembly: TerrariaServer, Version=1.3.5.0, Culture=neutral, PublicKeyToken=null
// MVID: 13381DB9-8FD8-4EBB-8CED-9CF82DC89291
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Terraria\TerrariaServer.exe

using Terraria.DataStructures;

namespace Terraria.Modules
{
  public class AnchorDataModule
  {
    public AnchorData top;
    public AnchorData bottom;
    public AnchorData left;
    public AnchorData right;
    public bool wall;

    public AnchorDataModule(AnchorDataModule copyFrom = null)
    {
      if (copyFrom == null)
      {
        this.top = new AnchorData();
        this.bottom = new AnchorData();
        this.left = new AnchorData();
        this.right = new AnchorData();
        this.wall = false;
      }
      else
      {
        this.top = copyFrom.top;
        this.bottom = copyFrom.bottom;
        this.left = copyFrom.left;
        this.right = copyFrom.right;
        this.wall = copyFrom.wall;
      }
    }
  }
}
