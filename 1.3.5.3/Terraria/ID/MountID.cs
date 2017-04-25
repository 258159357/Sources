// Decompiled with JetBrains decompiler
// Type: Terraria.ID.MountID
// Assembly: TerrariaServer, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: AA3606A2-F3DB-4481-937B-7295FB97CD3E
// Assembly location: E:\TSHOCK\TerrariaServer.exe

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
