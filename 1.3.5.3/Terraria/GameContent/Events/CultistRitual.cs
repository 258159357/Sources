// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Events.CultistRitual
// Assembly: TerrariaServer, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: AA3606A2-F3DB-4481-937B-7295FB97CD3E
// Assembly location: E:\TSHOCK\TerrariaServer.exe

using Microsoft.Xna.Framework;

namespace Terraria.GameContent.Events
{
  public class CultistRitual
  {
    public const int delayStart = 86400;
    public const int respawnDelay = 43200;
    private const int timePerCultist = 3600;
    private const int recheckStart = 600;
    public static int delay;
    public static int recheck;

    public static void UpdateTime()
    {
      if (Main.netMode == 1)
        return;
      CultistRitual.delay -= Main.dayRate;
      if (CultistRitual.delay < 0)
        CultistRitual.delay = 0;
      CultistRitual.recheck -= Main.dayRate;
      if (CultistRitual.recheck < 0)
        CultistRitual.recheck = 0;
      if (CultistRitual.delay != 0 || CultistRitual.recheck != 0)
        return;
      CultistRitual.recheck = 600;
      if (NPC.AnyDanger())
        CultistRitual.recheck *= 6;
      else
        CultistRitual.TrySpawning(Main.dungeonX, Main.dungeonY);
    }

    public static void CultistSlain()
    {
      CultistRitual.delay -= 3600;
    }

    public static void TabletDestroyed()
    {
      CultistRitual.delay = 43200;
    }

    public static void TrySpawning(int x, int y)
    {
      if (WorldGen.PlayerLOS(x - 6, y) || WorldGen.PlayerLOS(x + 6, y) || !CultistRitual.CheckRitual(x, y))
        return;
      NPC.NewNPC(x * 16 + 8, (y - 4) * 16 - 8, 437, 0, 0.0f, 0.0f, 0.0f, 0.0f, (int) byte.MaxValue);
    }

    private static bool CheckRitual(int x, int y)
    {
      if (CultistRitual.delay != 0 || !Main.hardMode || (!NPC.downedGolemBoss || !NPC.downedBoss3) || (y < 7 || WorldGen.SolidTile(Main.tile[x, y - 7]) || NPC.AnyNPCs(437)))
        return false;
      Vector2 Center = new Vector2((float) (x * 16 + 8), (float) (y * 16 - 64 - 8 - 27));
      Point[] pointArray = (Point[]) null;
      // ISSUE: explicit reference operation
      // ISSUE: variable of a reference type
      Point[]& spawnPoints = @pointArray;
      return CultistRitual.CheckFloor(Center, spawnPoints);
    }

    public static bool CheckFloor(Vector2 Center, out Point[] spawnPoints)
    {
      Point[] pointArray = new Point[4];
      int num1 = 0;
      Point tileCoordinates = Center.ToTileCoordinates();
      int num2 = -5;
      while (num2 <= 5)
      {
        if (num2 != -1 && num2 != 1)
        {
          for (int index = -5; index < 12; ++index)
          {
            int num3 = tileCoordinates.X + num2 * 2;
            int num4 = tileCoordinates.Y + index;
            if (WorldGen.SolidTile(num3, num4) && !Collision.SolidTiles(num3 - 1, num3 + 1, num4 - 3, num4 - 1))
            {
              pointArray[num1++] = new Point(num3, num4);
              break;
            }
          }
        }
        num2 += 2;
      }
      if (num1 != 4)
      {
        spawnPoints = (Point[]) null;
        return false;
      }
      spawnPoints = pointArray;
      return true;
    }
  }
}
