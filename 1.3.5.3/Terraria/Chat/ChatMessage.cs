// Decompiled with JetBrains decompiler
// Type: Terraria.Chat.ChatMessage
// Assembly: TerrariaServer, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: AA3606A2-F3DB-4481-937B-7295FB97CD3E
// Assembly location: E:\TSHOCK\TerrariaServer.exe

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
