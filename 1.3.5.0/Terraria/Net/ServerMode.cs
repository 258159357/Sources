// Decompiled with JetBrains decompiler
// Type: Terraria.Net.ServerMode
// Assembly: TerrariaServer, Version=1.3.5.0, Culture=neutral, PublicKeyToken=null
// MVID: 13381DB9-8FD8-4EBB-8CED-9CF82DC89291
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Terraria\TerrariaServer.exe

using System;

namespace Terraria.Net
{
  [Flags]
  public enum ServerMode : byte
  {
    None = 0,
    Lobby = 1,
    FriendsCanJoin = 2,
    FriendsOfFriends = 4,
  }
}
