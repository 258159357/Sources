// Decompiled with JetBrains decompiler
// Type: Terraria.Net.Sockets.ISocket
// Assembly: TerrariaServer, Version=1.3.5.0, Culture=neutral, PublicKeyToken=null
// MVID: 13381DB9-8FD8-4EBB-8CED-9CF82DC89291
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Terraria\TerrariaServer.exe

namespace Terraria.Net.Sockets
{
  public interface ISocket
  {
    void Close();

    bool IsConnected();

    void Connect(RemoteAddress address);

    void AsyncSend(byte[] data, int offset, int size, SocketSendCallback callback, object state = null);

    void AsyncReceive(byte[] data, int offset, int size, SocketReceiveCallback callback, object state = null);

    bool IsDataAvailable();

    void SendQueuedPackets();

    bool StartListening(SocketConnectionAccepted callback);

    void StopListening();

    RemoteAddress GetRemoteAddress();
  }
}
