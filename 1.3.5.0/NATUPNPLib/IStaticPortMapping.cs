﻿// Decompiled with JetBrains decompiler
// Type: NATUPNPLib.IStaticPortMapping
// Assembly: TerrariaServer, Version=1.3.5.0, Culture=neutral, PublicKeyToken=null
// MVID: 13381DB9-8FD8-4EBB-8CED-9CF82DC89291
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Terraria\TerrariaServer.exe

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NATUPNPLib
{
  [CompilerGenerated]
  [TypeIdentifier]
  [Guid("6F10711F-729B-41E5-93B8-F21D0F818DF1")]
  [ComImport]
  public interface IStaticPortMapping
  {
    int InternalPort { [DispId(3)] get; }

    string Protocol { [DispId(4)] get; }

    string InternalClient { [DispId(5)] get; }

    [SpecialName]
    extern void _VtblGap1_2();
  }
}
