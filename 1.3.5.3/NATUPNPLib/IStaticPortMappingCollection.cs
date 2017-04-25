// Decompiled with JetBrains decompiler
// Type: NATUPNPLib.IStaticPortMappingCollection
// Assembly: TerrariaServer, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: AA3606A2-F3DB-4481-937B-7295FB97CD3E
// Assembly location: E:\TSHOCK\TerrariaServer.exe

using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.CustomMarshalers;

namespace NATUPNPLib
{
  [CompilerGenerated]
  [Guid("CD1F3E77-66D6-4664-82C7-36DBB641D0F1")]
  [TypeIdentifier]
  [ComImport]
  public interface IStaticPortMappingCollection : IEnumerable
  {
    [DispId(-4)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (EnumeratorToEnumVariantMarshaler))]
    IEnumerator GetEnumerator();

    [SpecialName]
    [MethodImpl(MethodCodeType = MethodCodeType.Runtime)]
    void _VtblGap1_2();

    [DispId(2)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    void Remove([In] int lExternalPort, [MarshalAs(UnmanagedType.BStr), In] string bstrProtocol);

    [DispId(3)]
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
    [return: MarshalAs(UnmanagedType.Interface)]
    IStaticPortMapping Add([In] int lExternalPort, [MarshalAs(UnmanagedType.BStr), In] string bstrProtocol, [In] int lInternalPort, [MarshalAs(UnmanagedType.BStr), In] string bstrInternalClient, [In] bool bEnabled, [MarshalAs(UnmanagedType.BStr), In] string bstrDescription);
  }
}
