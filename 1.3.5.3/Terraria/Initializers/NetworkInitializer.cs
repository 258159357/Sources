// Decompiled with JetBrains decompiler
// Type: Terraria.Initializers.NetworkInitializer
// Assembly: TerrariaServer, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: AA3606A2-F3DB-4481-937B-7295FB97CD3E
// Assembly location: E:\TSHOCK\TerrariaServer.exe

using Terraria.GameContent.NetModules;
using Terraria.Net;

namespace Terraria.Initializers
{
  public static class NetworkInitializer
  {
    public static void Load()
    {
      NetManager.Instance.Register<NetLiquidModule>();
      NetManager.Instance.Register<NetTextModule>();
    }
  }
}
