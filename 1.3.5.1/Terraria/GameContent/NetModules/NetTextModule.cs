﻿// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.NetModules.NetTextModule
// Assembly: TerrariaServer, Version=1.3.5.1, Culture=neutral, PublicKeyToken=null
// MVID: 5CBA2320-074B-43F7-8CDC-BF1E2B81EE4B
// Assembly location: C:\Users\kevzhao\Downloads\TerrariaServer.exe

using Microsoft.Xna.Framework;
using System.IO;
using Terraria.Chat;
using Terraria.GameContent.UI.Chat;
using Terraria.Localization;
using Terraria.Net;
using Terraria.UI.Chat;

namespace Terraria.GameContent.NetModules
{
  public class NetTextModule : NetModule
  {
    public static NetPacket SerializeClientMessage(ChatMessage message)
    {
      NetPacket packet = NetModule.CreatePacket<NetTextModule>(message.GetMaxSerializedSize());
      message.Serialize(packet.Writer);
      return packet;
    }

    public static NetPacket SerializeServerMessage(NetworkText text, Color color)
    {
      return NetTextModule.SerializeServerMessage(text, color, byte.MaxValue);
    }

    public static NetPacket SerializeServerMessage(NetworkText text, Color color, byte authorId)
    {
      NetPacket packet = NetModule.CreatePacket<NetTextModule>(1 + text.GetMaxSerializedSize() + 3);
      packet.Writer.Write(authorId);
      text.Serialize(packet.Writer);
      packet.Writer.WriteRGB(color);
      return packet;
    }

    private bool DeserializeAsClient(BinaryReader reader, int senderPlayerId)
    {
      byte num = reader.ReadByte();
      string str = NetworkText.Deserialize(reader).ToString();
      Color c = reader.ReadRGB();
      if ((int) num < (int) byte.MaxValue)
      {
        Main.player[(int) num].chatOverhead.NewMessage(str, Main.chatLength / 2);
        str = NameTagHandler.GenerateTag(Main.player[(int) num].name) + " " + str;
      }
      Main.NewTextMultiline(str, false, c, -1);
      return true;
    }

    private bool DeserializeAsServer(BinaryReader reader, int senderPlayerId)
    {
      ChatMessage message = ChatMessage.Deserialize(reader);
      ChatManager.Commands.ProcessReceivedMessage(message, senderPlayerId);
      return true;
    }

    private void BroadcastRawMessage(ChatMessage message, byte author, Color messageColor)
    {
      NetManager.Instance.Broadcast(NetTextModule.SerializeServerMessage(NetworkText.FromLiteral(message.Text), messageColor), -1);
    }

    public override bool Deserialize(BinaryReader reader, int senderPlayerId)
    {
      return this.DeserializeAsServer(reader, senderPlayerId);
    }
  }
}
