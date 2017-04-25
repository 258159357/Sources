// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.Chat.NameTagHandler
// Assembly: TerrariaServer, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: AA3606A2-F3DB-4481-937B-7295FB97CD3E
// Assembly location: E:\TSHOCK\TerrariaServer.exe

using Microsoft.Xna.Framework;
using Terraria.UI.Chat;

namespace Terraria.GameContent.UI.Chat
{
  public class NameTagHandler : ITagHandler
  {
    TextSnippet ITagHandler.Parse(string text, Color baseColor, string options)
    {
      return new TextSnippet("<" + text.Replace("\\[", "[").Replace("\\]", "]") + ">", baseColor, 1f);
    }

    public static string GenerateTag(string name)
    {
      return "[n:" + name.Replace("[", "\\[").Replace("]", "\\]") + "]";
    }
  }
}
