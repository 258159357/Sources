// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.Chat.ColorTagHandler
// Assembly: TerrariaServer, Version=1.3.5.1, Culture=neutral, PublicKeyToken=null
// MVID: 5CBA2320-074B-43F7-8CDC-BF1E2B81EE4B
// Assembly location: C:\Users\kevzhao\Downloads\TerrariaServer.exe

using Microsoft.Xna.Framework;
using System;
using System.Globalization;
using Terraria.UI.Chat;

namespace Terraria.GameContent.UI.Chat
{
  public class ColorTagHandler : ITagHandler
  {
    TextSnippet ITagHandler.Parse(string text, Color baseColor, string options)
    {
      TextSnippet textSnippet = new TextSnippet(text);
      int result;
      if (!int.TryParse(options, NumberStyles.AllowHexSpecifier, (IFormatProvider) CultureInfo.InvariantCulture, out result))
        return textSnippet;
      textSnippet.Color = new Color(result >> 16 & (int) byte.MaxValue, result >> 8 & (int) byte.MaxValue, result & (int) byte.MaxValue);
      return textSnippet;
    }
  }
}
