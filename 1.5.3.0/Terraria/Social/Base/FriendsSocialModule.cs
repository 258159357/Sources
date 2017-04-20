// Decompiled with JetBrains decompiler
// Type: Terraria.Social.Base.FriendsSocialModule
// Assembly: TerrariaServer, Version=1.3.5.0, Culture=neutral, PublicKeyToken=null
// MVID: 13381DB9-8FD8-4EBB-8CED-9CF82DC89291
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Terraria\TerrariaServer.exe

namespace Terraria.Social.Base
{
  public abstract class FriendsSocialModule : ISocialModule
  {
    public abstract string GetUsername();

    public abstract void OpenJoinInterface();

    public abstract void Initialize();

    public abstract void Shutdown();
  }
}
