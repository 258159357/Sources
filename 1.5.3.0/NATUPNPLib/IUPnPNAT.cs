// Decompiled with JetBrains decompiler
// Type: NATUPNPLib.IUPnPNAT
// Assembly: TerrariaServer, Version=1.3.5.0, Culture=neutral, PublicKeyToken=null
// MVID: 13381DB9-8FD8-4EBB-8CED-9CF82DC89291
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Terraria\TerrariaServer.exe

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NATUPNPLib
{
  [Guid("B171C812-CC76-485A-94D8-B6B3A2794E99")]
  [TypeIdentifier]
  [CompilerGenerated]
  [ComImport]
  public interface IUPnPNAT
  {
    IStaticPortMappingCollection StaticPortMappingCollection { [DispId(1)] get; }
  }
}
