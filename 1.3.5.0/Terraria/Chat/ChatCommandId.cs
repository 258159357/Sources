// Decompiled with JetBrains decompiler
// Type: Terraria.Chat.ChatCommandId
// Assembly: TerrariaServer, Version=1.3.5.0, Culture=neutral, PublicKeyToken=null
// MVID: 13381DB9-8FD8-4EBB-8CED-9CF82DC89291
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Terraria\TerrariaServer.exe

using ReLogic.Utilities;
using System.IO;
using System.Text;
using Terraria.Chat.Commands;

namespace Terraria.Chat
{
  public struct ChatCommandId
  {
    private readonly string _name;

    private ChatCommandId(string name)
    {
      this._name = name;
    }

    public static ChatCommandId FromType<T>() where T : IChatCommand
    {
      ChatCommandAttribute cacheableAttribute = (ChatCommandAttribute) AttributeUtilities.GetCacheableAttribute<T, ChatCommandAttribute>();
      if (cacheableAttribute != null)
        return new ChatCommandId(cacheableAttribute.Name);
      return new ChatCommandId((string) null);
    }

    public void Serialize(BinaryWriter writer)
    {
      writer.Write(this._name ?? "");
    }

    public static ChatCommandId Deserialize(BinaryReader reader)
    {
      return new ChatCommandId(reader.ReadString());
    }

    public int GetMaxSerializedSize()
    {
      return 4 + Encoding.UTF8.GetByteCount(this._name ?? "");
    }
  }
}
