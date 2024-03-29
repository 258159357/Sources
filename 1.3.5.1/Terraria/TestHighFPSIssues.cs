﻿// Decompiled with JetBrains decompiler
// Type: Terraria.TestHighFPSIssues
// Assembly: TerrariaServer, Version=1.3.5.1, Culture=neutral, PublicKeyToken=null
// MVID: 5CBA2320-074B-43F7-8CDC-BF1E2B81EE4B
// Assembly location: C:\Users\kevzhao\Downloads\TerrariaServer.exe

using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.GameInput;

namespace Terraria
{
  public class TestHighFPSIssues
  {
    private static List<double> _tapUpdates = new List<double>();
    private static List<double> _tapUpdateEnds = new List<double>();
    private static List<double> _tapDraws = new List<double>();
    private static int conU = 0;
    private static int conUH = 0;
    private static int conD = 0;
    private static int conDH = 0;
    private static int race = 0;

    public static void TapUpdate(GameTime gt)
    {
      TestHighFPSIssues._tapUpdates.Add(gt.get_TotalGameTime().TotalMilliseconds);
      TestHighFPSIssues.conD = 0;
      --TestHighFPSIssues.race;
      if (++TestHighFPSIssues.conU <= TestHighFPSIssues.conUH)
        return;
      TestHighFPSIssues.conUH = TestHighFPSIssues.conU;
    }

    public static void TapUpdateEnd(GameTime gt)
    {
      TestHighFPSIssues._tapUpdateEnds.Add(gt.get_TotalGameTime().TotalMilliseconds);
    }

    public static void TapDraw(GameTime gt)
    {
      TestHighFPSIssues._tapDraws.Add(gt.get_TotalGameTime().TotalMilliseconds);
      TestHighFPSIssues.conU = 0;
      ++TestHighFPSIssues.race;
      if (++TestHighFPSIssues.conD <= TestHighFPSIssues.conDH)
        return;
      TestHighFPSIssues.conDH = TestHighFPSIssues.conD;
    }

    public static void Update(GameTime gt)
    {
      if (PlayerInput.Triggers.Current.Down)
      {
        int num;
        TestHighFPSIssues.conDH = num = 0;
        TestHighFPSIssues.conUH = num;
        TestHighFPSIssues.race = num;
      }
      double num1 = gt.get_TotalGameTime().TotalMilliseconds - 5000.0;
      while (TestHighFPSIssues._tapUpdates.Count > 0 && TestHighFPSIssues._tapUpdates[0] < num1)
        TestHighFPSIssues._tapUpdates.RemoveAt(0);
      while (TestHighFPSIssues._tapDraws.Count > 0 && TestHighFPSIssues._tapDraws[0] < num1)
        TestHighFPSIssues._tapDraws.RemoveAt(0);
      while (TestHighFPSIssues._tapUpdateEnds.Count > 0 && TestHighFPSIssues._tapUpdateEnds[0] < num1)
        TestHighFPSIssues._tapUpdateEnds.RemoveAt(0);
      Main.versionNumber = "total (u/d)   " + (object) TestHighFPSIssues._tapUpdates.Count + " " + (object) TestHighFPSIssues._tapUpdateEnds.Count + "  " + (object) TestHighFPSIssues.race + " " + (object) TestHighFPSIssues.conUH + " " + (object) TestHighFPSIssues.conDH;
      Main.NewText(Main.versionNumber, byte.MaxValue, byte.MaxValue, byte.MaxValue, false);
    }
  }
}
