﻿// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.Chat.PlainTagHandler
// Assembly: TerrariaServer, Version=1.3.5.1, Culture=neutral, PublicKeyToken=null
// MVID: C2103E81-0935-4BEA-9E98-4159FC80C2BB
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Terraria\TerrariaServer.exe

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
