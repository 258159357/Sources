﻿// Decompiled with JetBrains decompiler
// Type: Terraria.Sign
// Assembly: TerrariaServer, Version=1.3.5.0, Culture=neutral, PublicKeyToken=null
// MVID: 13381DB9-8FD8-4EBB-8CED-9CF82DC89291
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Terraria\TerrariaServer.exe

namespace Terraria
{
  public class Sign
  {
    public const int maxSigns = 1000;
    public int x;
    public int y;
    public string text;

    public static void KillSign(int x, int y)
    {
      for (int index = 0; index < 1000; ++index)
      {
        if (Main.sign[index] != null && Main.sign[index].x == x && Main.sign[index].y == y)
          Main.sign[index] = (Sign) null;
      }
    }

    public static int ReadSign(int i, int j, bool CreateIfMissing = true)
    {
      int num1 = (int) Main.tile[i, j].frameX / 18;
      int num2 = (int) Main.tile[i, j].frameY / 18;
      int num3 = num1 % 2;
      int x = i - num3;
      int y = j - num2;
      if (!Main.tileSign[(int) Main.tile[x, y].type])
      {
        Sign.KillSign(x, y);
        return -1;
      }
      int num4 = -1;
      for (int index = 0; index < 1000; ++index)
      {
        if (Main.sign[index] != null && Main.sign[index].x == x && Main.sign[index].y == y)
        {
          num4 = index;
          break;
        }
      }
      if (num4 < 0 && CreateIfMissing)
      {
        for (int index = 0; index < 1000; ++index)
        {
          if (Main.sign[index] == null)
          {
            num4 = index;
            Main.sign[index] = new Sign();
            Main.sign[index].x = x;
            Main.sign[index].y = y;
            Main.sign[index].text = "";
            break;
          }
        }
      }
      return num4;
    }

    public static void TextSign(int i, string text)
    {
      if (Main.tile[Main.sign[i].x, Main.sign[i].y] == null || !Main.tile[Main.sign[i].x, Main.sign[i].y].active() || !Main.tileSign[(int) Main.tile[Main.sign[i].x, Main.sign[i].y].type])
        Main.sign[i] = (Sign) null;
      else
        Main.sign[i].text = text;
    }

    public override string ToString()
    {
      return "x" + (object) this.x + "\ty" + (object) this.y + "\t" + this.text;
    }
  }
}
