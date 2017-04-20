// Decompiled with JetBrains decompiler
// Type: Terraria.Chat.ChatCommandProcessor
// Assembly: TerrariaServer, Version=1.3.5.1, Culture=neutral, PublicKeyToken=null
// MVID: 5CBA2320-074B-43F7-8CDC-BF1E2B81EE4B
// Assembly location: C:\Users\kevzhao\Downloads\TerrariaServer.exe

using ReLogic.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria.Chat.Commands;
using Terraria.Localization;

namespace Terraria.Chat
{
  public class ChatCommandProcessor : IChatProcessor
  {
    private Dictionary<LocalizedText, ChatCommandId> _localizedCommands = new Dictionary<LocalizedText, ChatCommandId>();
    private Dictionary<ChatCommandId, IChatCommand> _commands = new Dictionary<ChatCommandId, IChatCommand>();
    private IChatCommand _defaultCommand;

    public ChatCommandProcessor AddCommand<T>() where T : IChatCommand, new()
    {
      string commandKey = "ChatCommand." + ((ChatCommandAttribute) AttributeUtilities.GetCacheableAttribute<T, ChatCommandAttribute>()).Name;
      ChatCommandId index = ChatCommandId.FromType<T>();
      this._commands[index] = (IChatCommand) new T();
      if (Language.Exists(commandKey))
      {
        this._localizedCommands.Add(Language.GetText(commandKey), index);
      }
      else
      {
        commandKey += "_";
        foreach (LocalizedText key in Language.FindAll((LanguageSearchFilter) ((key, text) => key.StartsWith(commandKey))))
          this._localizedCommands.Add(key, index);
      }
      return this;
    }

    public ChatCommandProcessor AddDefaultCommand<T>() where T : IChatCommand, new()
    {
      this.AddCommand<T>();
      this._defaultCommand = this._commands[ChatCommandId.FromType<T>()];
      return this;
    }

    private static bool HasLocalizedCommand(ChatMessage message, LocalizedText command)
    {
      string lower = message.Text.ToLower();
      string str = command.Value;
      if (!lower.StartsWith(str))
        return false;
      if (lower.Length == str.Length)
        return true;
      return (int) lower[str.Length] == 32;
    }

    private static string RemoveCommandPrefix(string messageText, LocalizedText command)
    {
      string str = command.Value;
      if (!messageText.StartsWith(str) || messageText.Length == str.Length || (int) messageText[str.Length] != 32)
        return "";
      return messageText.Substring(str.Length + 1);
    }

    public bool ProcessOutgoingMessage(ChatMessage message)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      ChatCommandProcessor.\u003C\u003Ec__DisplayClass5 cDisplayClass5 = new ChatCommandProcessor.\u003C\u003Ec__DisplayClass5();
      // ISSUE: reference to a compiler-generated field
      cDisplayClass5.message = message;
      // ISSUE: reference to a compiler-generated field
      cDisplayClass5.\u003C\u003E4__this = this;
      // ISSUE: method pointer
      KeyValuePair<LocalizedText, ChatCommandId> keyValuePair = (KeyValuePair<LocalizedText, ChatCommandId>) Enumerable.FirstOrDefault<KeyValuePair<LocalizedText, ChatCommandId>>((IEnumerable<M0>) this._localizedCommands, (Func<M0, bool>) new Func<KeyValuePair<LocalizedText, ChatCommandId>, bool>((object) cDisplayClass5, __methodptr(\u003CProcessOutgoingMessage\u003Eb__4)));
      ChatCommandId commandId = keyValuePair.Value;
      if (keyValuePair.Key == null)
        return false;
      // ISSUE: reference to a compiler-generated field
      cDisplayClass5.message.SetCommand(commandId);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      cDisplayClass5.message.Text = ChatCommandProcessor.RemoveCommandPrefix(cDisplayClass5.message.Text, keyValuePair.Key);
      return true;
    }

    public bool ProcessReceivedMessage(ChatMessage message, int clientId)
    {
      IChatCommand chatCommand;
      if (this._commands.TryGetValue(message.CommandId, out chatCommand))
      {
        chatCommand.ProcessMessage(message.Text, (byte) clientId);
        return true;
      }
      if (this._defaultCommand == null)
        return false;
      this._defaultCommand.ProcessMessage(message.Text, (byte) clientId);
      return true;
    }
  }
}
