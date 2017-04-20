// Decompiled with JetBrains decompiler
// Type: Terraria.ID.MountID
// Assembly: TerrariaServer, Version=1.3.5.0, Culture=neutral, PublicKeyToken=null
// MVID: 13381DB9-8FD8-4EBB-8CED-9CF82DC89291
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Terraria\TerrariaServer.exe

namespace Terraria.ID
{
  public static class MountID
  {
    public static int Count = 15;

    public static class Sets
    {
      public static SetFactory Factory = new SetFactory(MountID.Count);
      public static bool[] Cart = MountID.Sets.Factory.CreateBoolSet(6, 11, 13);
    }
  }
}
