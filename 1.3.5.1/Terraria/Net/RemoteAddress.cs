﻿// Decompiled with JetBrains decompiler
// Type: Terraria.Net.RemoteAddress
// Assembly: TerrariaServer, Version=1.3.5.1, Culture=neutral, PublicKeyToken=null
// MVID: 5CBA2320-074B-43F7-8CDC-BF1E2B81EE4B
// Assembly location: C:\Users\kevzhao\Downloads\TerrariaServer.exe

namespace Terraria.Net
{
  public abstract class RemoteAddress
  {
    public AddressType Type;

    public abstract string GetIdentifier();

    public abstract string GetFriendlyName();

    public abstract bool IsLocalHost();
  }
}
