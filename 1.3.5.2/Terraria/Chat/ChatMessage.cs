﻿// Decompiled with JetBrains decompiler
// Type: Terraria.Chat.ChatMessage
// Assembly: TerrariaServer, Version=1.3.5.1, Culture=neutral, PublicKeyToken=null
// MVID: C2103E81-0935-4BEA-9E98-4159FC80C2BB
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Terraria\TerrariaServer.exe

using System.IO;
using System.Text;
using Terraria.Chat.Commands;

namespace Terraria.Chat
{
  public class ChatMessage
  {
    public ChatCommandId CommandId { get; private set; }

    public string Text { get; set; }

    public ChatMessage(string message)
    {
      this.CommandId = ChatCommandId.FromType<SayChatCommand>();
      this.Text = message;
    }

    private ChatMessage(string message, ChatCommandId commandId)
    {
      this.CommandId = commandId;
      this.Text = message;
    }

    public void Serialize(BinaryWriter writer)
    {
      this.CommandId.Serialize(writer);
      writer.Write(this.Text);
    }

    public int GetMaxSerializedSize()
    {
      return 0 + this.CommandId.GetMaxSerializedSize() + (4 + Encoding.UTF8.GetByteCount(this.Text));
    }

    public static ChatMessage Deserialize(BinaryReader reader)
    {
      ChatCommandId commandId = ChatCommandId.Deserialize(reader);
      return new ChatMessage(reader.ReadString(), commandId);
    }

    public void SetCommand(ChatCommandId commandId)
    {
      this.CommandId = commandId;
    }

    public void SetCommand<T>() where T : IChatCommand
    {
      this.CommandId = ChatCommandId.FromType<T>();
    }
  }
}
