﻿// Decompiled with JetBrains decompiler
// Type: Terraria.Localization.Language
// Assembly: TerrariaServer, Version=1.3.5.0, Culture=neutral, PublicKeyToken=null
// MVID: 13381DB9-8FD8-4EBB-8CED-9CF82DC89291
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Terraria\TerrariaServer.exe

using System.Text.RegularExpressions;
using Terraria.Utilities;

namespace Terraria.Localization
{
  public static class Language
  {
    public static GameCulture ActiveCulture
    {
      get
      {
        return LanguageManager.Instance.ActiveCulture;
      }
    }

    public static LocalizedText GetText(string key)
    {
      return LanguageManager.Instance.GetText(key);
    }

    public static string GetTextValue(string key)
    {
      return LanguageManager.Instance.GetTextValue(key);
    }

    public static string GetTextValue(string key, object arg0)
    {
      return LanguageManager.Instance.GetTextValue(key, arg0);
    }

    public static string GetTextValue(string key, object arg0, object arg1)
    {
      return LanguageManager.Instance.GetTextValue(key, arg0, arg1);
    }

    public static string GetTextValue(string key, object arg0, object arg1, object arg2)
    {
      return LanguageManager.Instance.GetTextValue(key, arg0, arg1, arg2);
    }

    public static string GetTextValue(string key, params object[] args)
    {
      return LanguageManager.Instance.GetTextValue(key, args);
    }

    public static string GetTextValueWith(string key, object obj)
    {
      return LanguageManager.Instance.GetText(key).FormatWith(obj);
    }

    public static bool Exists(string key)
    {
      return LanguageManager.Instance.Exists(key);
    }

    public static int GetCategorySize(string key)
    {
      return LanguageManager.Instance.GetCategorySize(key);
    }

    public static LocalizedText[] FindAll(Regex regex)
    {
      return LanguageManager.Instance.FindAll(regex);
    }

    public static LocalizedText[] FindAll(LanguageSearchFilter filter)
    {
      return LanguageManager.Instance.FindAll(filter);
    }

    public static LocalizedText SelectRandom(LanguageSearchFilter filter, UnifiedRandom random = null)
    {
      return LanguageManager.Instance.SelectRandom(filter, random);
    }

    public static LocalizedText RandomFromCategory(string categoryName, UnifiedRandom random = null)
    {
      return LanguageManager.Instance.RandomFromCategory(categoryName, random);
    }
  }
}
