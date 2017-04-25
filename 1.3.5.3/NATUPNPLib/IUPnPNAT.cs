// Decompiled with JetBrains decompiler
// Type: NATUPNPLib.IUPnPNAT
// Assembly: TerrariaServer, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: AA3606A2-F3DB-4481-937B-7295FB97CD3E
// Assembly location: E:\TSHOCK\TerrariaServer.exe

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NATUPNPLib
{
  [CompilerGenerated]
  [Guid("B171C812-CC76-485A-94D8-B6B3A2794E99")]
  [TypeIdentifier]
  [ComImport]
  public interface IUPnPNAT
  {
    [DispId(1)]
    IStaticPortMappingCollection StaticPortMappingCollection { [DispId(1), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)] get; }
  }
}
