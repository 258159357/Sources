// Decompiled with JetBrains decompiler
// Type: Terraria.ID.MountID
// Assembly: TerrariaServer, Version=1.3.5.1, Culture=neutral, PublicKeyToken=null
// MVID: 5CBA2320-074B-43F7-8CDC-BF1E2B81EE4B
// Assembly location: C:\Users\kevzhao\Downloads\TerrariaServer.exe

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
