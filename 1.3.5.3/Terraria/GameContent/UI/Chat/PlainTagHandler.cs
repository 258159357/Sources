// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.Chat.PlainTagHandler
// Assembly: TerrariaServer, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: AA3606A2-F3DB-4481-937B-7295FB97CD3E
// Assembly location: E:\TSHOCK\TerrariaServer.exe

using Microsoft.Xna.Framework;
using Terraria.UI.Chat;

namespace Terraria.GameContent.UI.Chat
{
  public class PlainTagHandler : ITagHandler
  {
    TextSnippet ITagHandler.Parse(string text, Color baseColor, string options)
    {
      return (TextSnippet) new PlainTagHandler.PlainSnippet(text);
    }

    public class PlainSnippet : TextSnippet
    {
      public PlainSnippet(string text = "")
        : base(text)
      {
      }

      public PlainSnippet(string text, Color color, float scale = 1f)
        : base(text, color, scale)
      {
      }

      public override Color GetVisibleColor()
      {
        return this.Color;
      }
    }
  }
}
