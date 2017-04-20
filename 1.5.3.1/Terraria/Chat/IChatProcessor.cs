// Decompiled with JetBrains decompiler
// Type: Terraria.Chat.IChatProcessor
// Assembly: TerrariaServer, Version=1.3.5.1, Culture=neutral, PublicKeyToken=null
// MVID: 5CBA2320-074B-43F7-8CDC-BF1E2B81EE4B
// Assembly location: C:\Users\kevzhao\Downloads\TerrariaServer.exe

namespace Terraria.Chat
{
  public interface IChatProcessor
  {
    bool ProcessReceivedMessage(ChatMessage message, int clientId);

    bool ProcessOutgoingMessage(ChatMessage message);
  }
}
