// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Biomes.CaveHouseBiome
// Assembly: TerrariaServer, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: AA3606A2-F3DB-4481-937B-7295FB97CD3E
// Assembly location: E:\TSHOCK\TerrariaServer.exe

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.World.Generation;

namespace Terraria.GameContent.Biomes
{
  public class CaveHouseBiome : MicroBiome
  {
    private static readonly bool[] _blacklistedTiles = TileID.Sets.Factory.CreateBoolSet(1 != 0, 225, 41, 43, 44, 226, 203, 112, 25, 151);
    private const int VERTICAL_EXIT_WIDTH = 3;
    private int _sharpenerCount;
    private int _extractinatorCount;

    private Microsoft.Xna.Framework.Rectangle GetRoom(Point origin)
    {
      Point result1;
      bool flag1 = WorldUtils.Find(origin, Searches.Chain((GenSearch) new Searches.Left(25), (GenCondition) new Conditions.IsSolid()), out result1);
      Point result2;
      int num1 = WorldUtils.Find(origin, Searches.Chain((GenSearch) new Searches.Right(25), (GenCondition) new Conditions.IsSolid()), out result2) ? 1 : 0;
      if (!flag1)
        result1 = new Point(origin.X - 25, origin.Y);
      if (num1 == 0)
        result2 = new Point(origin.X + 25, origin.Y);
      Microsoft.Xna.Framework.Rectangle rectangle = new Microsoft.Xna.Framework.Rectangle(origin.X, origin.Y, 0, 0);
      if (origin.X - result1.X > result2.X - origin.X)
      {
        rectangle.X = result1.X;
        rectangle.Width = Utils.Clamp<int>(result2.X - result1.X, 15, 30);
      }
      else
      {
        rectangle.Width = Utils.Clamp<int>(result2.X - result1.X, 15, 30);
        rectangle.X = result2.X - rectangle.Width;
      }
      Point result3;
      bool flag2 = WorldUtils.Find(result1, Searches.Chain((GenSearch) new Searches.Up(10), (GenCondition) new Conditions.IsSolid()), out result3);
      Point result4;
      int num2 = WorldUtils.Find(result2, Searches.Chain((GenSearch) new Searches.Up(10), (GenCondition) new Conditions.IsSolid()), out result4) ? 1 : 0;
      if (!flag2)
        result3 = new Point(origin.X, origin.Y - 10);
      if (num2 == 0)
        result4 = new Point(origin.X, origin.Y - 10);
      rectangle.Height = Utils.Clamp<int>(Math.Max(origin.Y - result3.Y, origin.Y - result4.Y), 8, 12);
      rectangle.Y -= rectangle.Height;
      return rectangle;
    }

    private float RoomSolidPrecentage(Microsoft.Xna.Framework.Rectangle room)
    {
      float num = (float) (room.Width * room.Height);
      Ref<int> count = new Ref<int>(0);
      WorldUtils.Gen(new Point(room.X, room.Y), (GenShape) new Shapes.Rectangle(room.Width, room.Height), Actions.Chain((GenAction) new Modifiers.IsSolid(), (GenAction) new Actions.Count(count)));
      return (float) count.Value / num;
    }

    private bool FindVerticalExit(Microsoft.Xna.Framework.Rectangle wall, bool isUp, out int exitX)
    {
      Point result;
      int num = WorldUtils.Find(new Point(wall.X + wall.Width - 3, wall.Y + (isUp ? -5 : 0)), Searches.Chain((GenSearch) new Searches.Left(wall.Width - 3), new Conditions.IsSolid().Not().AreaOr(3, 5)), out result) ? 1 : 0;
      exitX = result.X;
      return num != 0;
    }

    private bool FindSideExit(Microsoft.Xna.Framework.Rectangle wall, bool isLeft, out int exitY)
    {
      Point result;
      int num = WorldUtils.Find(new Point(wall.X + (isLeft ? -4 : 0), wall.Y + wall.Height - 3), Searches.Chain((GenSearch) new Searches.Up(wall.Height - 3), new Conditions.IsSolid().Not().AreaOr(4, 3)), out result) ? 1 : 0;
      exitY = result.Y;
      return num != 0;
    }

    private int SortBiomeResults(Tuple<CaveHouseBiome.BuildData, int> item1, Tuple<CaveHouseBiome.BuildData, int> item2)
    {
      return item2.Item2.CompareTo(item1.Item2);
    }

    public override bool Place(Point origin, StructureMap structures)
    {
      Point result1;
      if (!WorldUtils.Find(origin, Searches.Chain((GenSearch) new Searches.Down(200), (GenCondition) new Conditions.IsSolid()), out result1) || result1 == origin)
        return false;
      Microsoft.Xna.Framework.Rectangle room1 = this.GetRoom(result1);
      Microsoft.Xna.Framework.Rectangle room2 = this.GetRoom(new Point(room1.Center.X, room1.Y + 1));
      Microsoft.Xna.Framework.Rectangle room3 = this.GetRoom(new Point(room1.Center.X, room1.Y + room1.Height + 10));
      room3.Y = room1.Y + room1.Height - 1;
      float num1 = this.RoomSolidPrecentage(room2);
      float num2 = this.RoomSolidPrecentage(room3);
      room1.Y += 3;
      room2.Y += 3;
      room3.Y += 3;
      List<Microsoft.Xna.Framework.Rectangle> rectangleList1 = new List<Microsoft.Xna.Framework.Rectangle>();
      if ((double) GenBase._random.NextFloat() > (double) num1 + 0.200000002980232)
        rectangleList1.Add(room2);
      else
        room2 = room1;
      rectangleList1.Add(room1);
      if ((double) GenBase._random.NextFloat() > (double) num2 + 0.200000002980232)
        rectangleList1.Add(room3);
      else
        room3 = room1;
      foreach (Microsoft.Xna.Framework.Rectangle rectangle in rectangleList1)
      {
        if (rectangle.Y + rectangle.Height > Main.maxTilesY - 220)
          return false;
      }
      Dictionary<ushort, int> resultsOutput = new Dictionary<ushort, int>();
      foreach (Microsoft.Xna.Framework.Rectangle rectangle in rectangleList1)
        WorldUtils.Gen(new Point(rectangle.X - 10, rectangle.Y - 10), (GenShape) new Shapes.Rectangle(rectangle.Width + 20, rectangle.Height + 20), (GenAction) new Actions.TileScanner(new ushort[12]
        {
          (ushort) 0,
          (ushort) 59,
          (ushort) 147,
          (ushort) 1,
          (ushort) 161,
          (ushort) 53,
          (ushort) 396,
          (ushort) 397,
          (ushort) 368,
          (ushort) 367,
          (ushort) 60,
          (ushort) 70
        }).Output(resultsOutput));
      List<Tuple<CaveHouseBiome.BuildData, int>> tupleList1 = new List<Tuple<CaveHouseBiome.BuildData, int>>();
      tupleList1.Add(Tuple.Create<CaveHouseBiome.BuildData, int>(CaveHouseBiome.BuildData.Default, resultsOutput[(ushort) 0] + resultsOutput[(ushort) 1]));
      tupleList1.Add(Tuple.Create<CaveHouseBiome.BuildData, int>(CaveHouseBiome.BuildData.Jungle, resultsOutput[(ushort) 59] + resultsOutput[(ushort) 60] * 10));
      tupleList1.Add(Tuple.Create<CaveHouseBiome.BuildData, int>(CaveHouseBiome.BuildData.Mushroom, resultsOutput[(ushort) 59] + resultsOutput[(ushort) 70] * 10));
      tupleList1.Add(Tuple.Create<CaveHouseBiome.BuildData, int>(CaveHouseBiome.BuildData.Snow, resultsOutput[(ushort) 147] + resultsOutput[(ushort) 161]));
      tupleList1.Add(Tuple.Create<CaveHouseBiome.BuildData, int>(CaveHouseBiome.BuildData.Desert, resultsOutput[(ushort) 397] + resultsOutput[(ushort) 396] + resultsOutput[(ushort) 53]));
      tupleList1.Add(Tuple.Create<CaveHouseBiome.BuildData, int>(CaveHouseBiome.BuildData.Granite, resultsOutput[(ushort) 368]));
      tupleList1.Add(Tuple.Create<CaveHouseBiome.BuildData, int>(CaveHouseBiome.BuildData.Marble, resultsOutput[(ushort) 367]));
      Comparison<Tuple<CaveHouseBiome.BuildData, int>> comparison = new Comparison<Tuple<CaveHouseBiome.BuildData, int>>(this.SortBiomeResults);
      tupleList1.Sort(comparison);
      int index1 = 0;
      CaveHouseBiome.BuildData buildData = tupleList1[index1].Item1;
      foreach (Microsoft.Xna.Framework.Rectangle area in rectangleList1)
      {
        if (buildData != CaveHouseBiome.BuildData.Granite)
        {
          Point result2;
          if (WorldUtils.Find(new Point(area.X - 2, area.Y - 2), Searches.Chain(new Searches.Rectangle(area.Width + 4, area.Height + 4).RequireAll(false), (GenCondition) new Conditions.HasLava()), out result2))
            return false;
        }
        if (!structures.CanPlace(area, CaveHouseBiome._blacklistedTiles, 5))
          return false;
      }
      int val1_1 = room1.X;
      int val1_2 = room1.X + room1.Width - 1;
      List<Microsoft.Xna.Framework.Rectangle> rectangleList2 = new List<Microsoft.Xna.Framework.Rectangle>();
      foreach (Microsoft.Xna.Framework.Rectangle rectangle in rectangleList1)
      {
        val1_1 = Math.Min(val1_1, rectangle.X);
        val1_2 = Math.Max(val1_2, rectangle.X + rectangle.Width - 1);
      }
      int num3 = 6;
      while (num3 > 4 && (val1_2 - val1_1) % num3 != 0)
        --num3;
      int x1 = val1_1;
      while (x1 <= val1_2)
      {
        for (int index2 = 0; index2 < rectangleList1.Count; ++index2)
        {
          Microsoft.Xna.Framework.Rectangle rectangle = rectangleList1[index2];
          if (x1 >= rectangle.X && x1 < rectangle.X + rectangle.Width)
          {
            int y = rectangle.Y + rectangle.Height;
            int num4 = 50;
            for (int index3 = index2 + 1; index3 < rectangleList1.Count; ++index3)
            {
              if (x1 >= rectangleList1[index3].X && x1 < rectangleList1[index3].X + rectangleList1[index3].Width)
                num4 = Math.Min(num4, rectangleList1[index3].Y - y);
            }
            if (num4 > 0)
            {
              Point result2;
              bool flag = WorldUtils.Find(new Point(x1, y), Searches.Chain((GenSearch) new Searches.Down(num4), (GenCondition) new Conditions.IsSolid()), out result2);
              if (num4 < 50)
              {
                flag = true;
                result2 = new Point(x1, y + num4);
              }
              if (flag)
                rectangleList2.Add(new Microsoft.Xna.Framework.Rectangle(x1, y, 1, result2.Y - y));
            }
          }
        }
        x1 += num3;
      }
      List<Point> pointList1 = new List<Point>();
      foreach (Microsoft.Xna.Framework.Rectangle rectangle in rectangleList1)
      {
        int exitY;
        if (this.FindSideExit(new Microsoft.Xna.Framework.Rectangle(rectangle.X + rectangle.Width, rectangle.Y + 1, 1, rectangle.Height - 2), false, out exitY))
          pointList1.Add(new Point(rectangle.X + rectangle.Width - 1, exitY));
        if (this.FindSideExit(new Microsoft.Xna.Framework.Rectangle(rectangle.X, rectangle.Y + 1, 1, rectangle.Height - 2), true, out exitY))
          pointList1.Add(new Point(rectangle.X, exitY));
      }
      List<Tuple<Point, Point>> tupleList2 = new List<Tuple<Point, Point>>();
      for (int index2 = 1; index2 < rectangleList1.Count; ++index2)
      {
        Microsoft.Xna.Framework.Rectangle rectangle1 = rectangleList1[index2];
        Microsoft.Xna.Framework.Rectangle rectangle2 = rectangleList1[index2 - 1];
        if (rectangle2.X - rectangle1.X > rectangle1.X + rectangle1.Width - (rectangle2.X + rectangle2.Width))
          tupleList2.Add(new Tuple<Point, Point>(new Point(rectangle1.X + rectangle1.Width - 1, rectangle1.Y + 1), new Point(rectangle1.X + rectangle1.Width - rectangle1.Height + 1, rectangle1.Y + rectangle1.Height - 1)));
        else
          tupleList2.Add(new Tuple<Point, Point>(new Point(rectangle1.X, rectangle1.Y + 1), new Point(rectangle1.X + rectangle1.Height - 1, rectangle1.Y + rectangle1.Height - 1)));
      }
      List<Point> pointList2 = new List<Point>();
      int exitX;
      if (this.FindVerticalExit(new Microsoft.Xna.Framework.Rectangle(room2.X + 2, room2.Y, room2.Width - 4, 1), true, out exitX))
        pointList2.Add(new Point(exitX, room2.Y));
      if (this.FindVerticalExit(new Microsoft.Xna.Framework.Rectangle(room3.X + 2, room3.Y + room3.Height - 1, room3.Width - 4, 1), false, out exitX))
        pointList2.Add(new Point(exitX, room3.Y + room3.Height - 1));
      foreach (Microsoft.Xna.Framework.Rectangle area in rectangleList1)
      {
        WorldUtils.Gen(new Point(area.X, area.Y), (GenShape) new Shapes.Rectangle(area.Width, area.Height), Actions.Chain((GenAction) new Actions.SetTile(buildData.Tile, false, true), (GenAction) new Actions.SetFrames(true)));
        WorldUtils.Gen(new Point(area.X + 1, area.Y + 1), (GenShape) new Shapes.Rectangle(area.Width - 2, area.Height - 2), Actions.Chain((GenAction) new Actions.ClearTile(true), (GenAction) new Actions.PlaceWall(buildData.Wall, true)));
        structures.AddStructure(area, 8);
      }
      foreach (Tuple<Point, Point> tuple in tupleList2)
      {
        Point origin1 = tuple.Item1;
        Point point = tuple.Item2;
        int num4 = point.X > origin1.X ? 1 : -1;
        ShapeData data = new ShapeData();
        for (int y = 0; y < point.Y - origin1.Y; ++y)
          data.Add(num4 * (y + 1), y);
        WorldUtils.Gen(origin1, (GenShape) new ModShapes.All(data), Actions.Chain((GenAction) new Actions.PlaceTile((ushort) 19, buildData.PlatformStyle), (GenAction) new Actions.SetSlope(num4 == 1 ? 1 : 2), (GenAction) new Actions.SetFrames(true)));
        WorldUtils.Gen(new Point(origin1.X + (num4 == 1 ? 1 : -4), origin1.Y - 1), (GenShape) new Shapes.Rectangle(4, 1), Actions.Chain((GenAction) new Actions.Clear(), (GenAction) new Actions.PlaceWall(buildData.Wall, true), (GenAction) new Actions.PlaceTile((ushort) 19, buildData.PlatformStyle), (GenAction) new Actions.SetFrames(true)));
      }
      foreach (Point origin1 in pointList1)
      {
        WorldUtils.Gen(origin1, (GenShape) new Shapes.Rectangle(1, 3), (GenAction) new Actions.ClearTile(true));
        WorldGen.PlaceTile(origin1.X, origin1.Y, 10, true, true, -1, buildData.DoorStyle);
      }
      foreach (Point origin1 in pointList2)
      {
        Shapes.Rectangle rectangle = new Shapes.Rectangle(3, 1);
        GenAction action = Actions.Chain((GenAction) new Actions.ClearMetadata(), (GenAction) new Actions.PlaceTile((ushort) 19, buildData.PlatformStyle), (GenAction) new Actions.SetFrames(true));
        WorldUtils.Gen(origin1, (GenShape) rectangle, action);
      }
      foreach (Microsoft.Xna.Framework.Rectangle rectangle in rectangleList2)
      {
        if (rectangle.Height > 1 && (int) GenBase._tiles[rectangle.X, rectangle.Y - 1].type != 19)
        {
          WorldUtils.Gen(new Point(rectangle.X, rectangle.Y), (GenShape) new Shapes.Rectangle(rectangle.Width, rectangle.Height), Actions.Chain((GenAction) new Actions.SetTile((ushort) 124, false, true), (GenAction) new Actions.SetFrames(true)));
          Tile tile = GenBase._tiles[rectangle.X, rectangle.Y + rectangle.Height];
          int num4 = 0;
          tile.slope((byte) num4);
          int num5 = 0;
          tile.halfBrick(num5 != 0);
        }
      }
      Point[] pointArray = new Point[7]
      {
        new Point(14, buildData.TableStyle),
        new Point(16, 0),
        new Point(18, buildData.WorkbenchStyle),
        new Point(86, 0),
        new Point(87, buildData.PianoStyle),
        new Point(94, 0),
        new Point(101, buildData.BookcaseStyle)
      };
      foreach (Microsoft.Xna.Framework.Rectangle rectangle in rectangleList1)
      {
        int num4 = rectangle.Width / 8;
        int num5 = rectangle.Width / (num4 + 1);
        int num6 = GenBase._random.Next(2);
        for (int index2 = 0; index2 < num4; ++index2)
        {
          int num7 = (index2 + 1) * num5 + rectangle.X;
          switch (index2 + num6 % 2)
          {
            case 0:
              int num8 = rectangle.Y + Math.Min(rectangle.Height / 2, rectangle.Height - 5);
              Vector2 vector2 = WorldGen.randHousePicture();
              int x2 = (int) vector2.X;
              int y = (int) vector2.Y;
              if (!WorldGen.nearPicture(num7, num8))
              {
                WorldGen.PlaceTile(num7, num8, x2, true, false, -1, y);
                break;
              }
              break;
            case 1:
              int j = rectangle.Y + 1;
              WorldGen.PlaceTile(num7, j, 34, true, false, -1, GenBase._random.Next(6));
              for (int index3 = -1; index3 < 2; ++index3)
              {
                for (int index4 = 0; index4 < 3; ++index4)
                  GenBase._tiles[index3 + num7, index4 + j].frameX += (short) 54;
              }
              break;
          }
        }
        int num9 = rectangle.Width / 8 + 3;
        WorldGen.SetupStatueList();
        for (; num9 > 0; --num9)
        {
          int num7 = GenBase._random.Next(rectangle.Width - 3) + 1 + rectangle.X;
          int num8 = rectangle.Y + rectangle.Height - 2;
          switch (GenBase._random.Next(4))
          {
            case 0:
              WorldGen.PlaceSmallPile(num7, num8, GenBase._random.Next(31, 34), 1, (ushort) 185);
              break;
            case 1:
              WorldGen.PlaceTile(num7, num8, 186, true, false, -1, GenBase._random.Next(22, 26));
              break;
            case 2:
              int index2 = GenBase._random.Next(2, WorldGen.statueList.Length);
              WorldGen.PlaceTile(num7, num8, (int) WorldGen.statueList[index2].X, true, false, -1, (int) WorldGen.statueList[index2].Y);
              if (WorldGen.StatuesWithTraps.Contains(index2))
              {
                WorldGen.PlaceStatueTrap(num7, num8);
                break;
              }
              break;
            case 3:
              Point point = Utils.SelectRandom<Point>(GenBase._random, pointArray);
              WorldGen.PlaceTile(num7, num8, point.X, true, false, -1, point.Y);
              break;
          }
        }
      }
      foreach (Microsoft.Xna.Framework.Rectangle room4 in rectangleList1)
        buildData.ProcessRoom(room4);
      bool flag1 = false;
      foreach (Microsoft.Xna.Framework.Rectangle rectangle in rectangleList1)
      {
        int j = rectangle.Height - 1 + rectangle.Y;
        int Style = j > (int) Main.worldSurface ? buildData.ChestStyle : 0;
        int num4 = 0;
        while (num4 < 10 && !(flag1 = WorldGen.AddBuriedChest(GenBase._random.Next(2, rectangle.Width - 2) + rectangle.X, j, 0, false, Style)))
          ++num4;
        if (!flag1)
        {
          int i = rectangle.X + 2;
          while (i <= rectangle.X + rectangle.Width - 2 && !(flag1 = WorldGen.AddBuriedChest(i, j, 0, false, Style)))
            ++i;
          if (flag1)
            break;
        }
        else
          break;
      }
      if (!flag1)
      {
        foreach (Microsoft.Xna.Framework.Rectangle rectangle in rectangleList1)
        {
          int j = rectangle.Y - 1;
          int Style = j > (int) Main.worldSurface ? buildData.ChestStyle : 0;
          int num4 = 0;
          while (num4 < 10 && !(flag1 = WorldGen.AddBuriedChest(GenBase._random.Next(2, rectangle.Width - 2) + rectangle.X, j, 0, false, Style)))
            ++num4;
          if (!flag1)
          {
            int i = rectangle.X + 2;
            while (i <= rectangle.X + rectangle.Width - 2 && !(flag1 = WorldGen.AddBuriedChest(i, j, 0, false, Style)))
              ++i;
            if (flag1)
              break;
          }
          else
            break;
        }
      }
      if (!flag1)
      {
        for (int index2 = 0; index2 < 1000; ++index2)
        {
          int i = GenBase._random.Next(rectangleList1[0].X - 30, rectangleList1[0].X + 30);
          int num4 = GenBase._random.Next(rectangleList1[0].Y - 30, rectangleList1[0].Y + 30);
          int num5 = num4 > (int) Main.worldSurface ? buildData.ChestStyle : 0;
          int j = num4;
          int contain = 0;
          int num6 = 0;
          int Style = num5;
          if (WorldGen.AddBuriedChest(i, j, contain, num6 != 0, Style))
            break;
        }
      }
      if (buildData == CaveHouseBiome.BuildData.Jungle && this._sharpenerCount < GenBase._random.Next(2, 5))
      {
        bool flag2 = false;
        foreach (Microsoft.Xna.Framework.Rectangle rectangle in rectangleList1)
        {
          int j = rectangle.Height - 2 + rectangle.Y;
          for (int index2 = 0; index2 < 10; ++index2)
          {
            int i = GenBase._random.Next(2, rectangle.Width - 2) + rectangle.X;
            WorldGen.PlaceTile(i, j, 377, true, true, -1, 0);
            if (flag2 = GenBase._tiles[i, j].active() && (int) GenBase._tiles[i, j].type == 377)
              break;
          }
          if (!flag2)
          {
            int i = rectangle.X + 2;
            while (i <= rectangle.X + rectangle.Width - 2 && !(flag2 = WorldGen.PlaceTile(i, j, 377, true, true, -1, 0)))
              ++i;
            if (flag2)
              break;
          }
          else
            break;
        }
        if (flag2)
          this._sharpenerCount = this._sharpenerCount + 1;
      }
      if (buildData == CaveHouseBiome.BuildData.Desert && this._extractinatorCount < GenBase._random.Next(2, 5))
      {
        bool flag2 = false;
        foreach (Microsoft.Xna.Framework.Rectangle rectangle in rectangleList1)
        {
          int j = rectangle.Height - 2 + rectangle.Y;
          for (int index2 = 0; index2 < 10; ++index2)
          {
            int i = GenBase._random.Next(2, rectangle.Width - 2) + rectangle.X;
            WorldGen.PlaceTile(i, j, 219, true, true, -1, 0);
            if (flag2 = GenBase._tiles[i, j].active() && (int) GenBase._tiles[i, j].type == 219)
              break;
          }
          if (!flag2)
          {
            int i = rectangle.X + 2;
            while (i <= rectangle.X + rectangle.Width - 2 && !(flag2 = WorldGen.PlaceTile(i, j, 219, true, true, -1, 0)))
              ++i;
            if (flag2)
              break;
          }
          else
            break;
        }
        if (flag2)
          this._extractinatorCount = this._extractinatorCount + 1;
      }
      return true;
    }

    public override void Reset()
    {
      this._sharpenerCount = 0;
      this._extractinatorCount = 0;
    }

    internal static void AgeDefaultRoom(Microsoft.Xna.Framework.Rectangle room)
    {
      for (int index = 0; index < room.Width * room.Height / 16; ++index)
        WorldUtils.Gen(new Point(GenBase._random.Next(1, room.Width - 1) + room.X, GenBase._random.Next(1, room.Height - 1) + room.Y), (GenShape) new Shapes.Rectangle(2, 2), Actions.Chain((GenAction) new Modifiers.Dither(0.5), (GenAction) new Modifiers.Blotches(2, 2.0), (GenAction) new Modifiers.IsEmpty(), (GenAction) new Actions.SetTile((ushort) 51, true, true)));
      WorldUtils.Gen(new Point(room.X, room.Y), (GenShape) new Shapes.Rectangle(room.Width, room.Height), Actions.Chain((GenAction) new Modifiers.Dither(0.850000023841858), (GenAction) new Modifiers.Blotches(2, 0.3), (GenAction) new Modifiers.OnlyWalls(new byte[1]
      {
        CaveHouseBiome.BuildData.Default.Wall
      }), (double) room.Y > Main.worldSurface ? (GenAction) new Actions.ClearWall(true) : (GenAction) new Actions.PlaceWall((byte) 2, true)));
      WorldUtils.Gen(new Point(room.X, room.Y), (GenShape) new Shapes.Rectangle(room.Width, room.Height), Actions.Chain((GenAction) new Modifiers.Dither(0.949999988079071), (GenAction) new Modifiers.OnlyTiles(new ushort[3]
      {
        (ushort) 30,
        (ushort) 321,
        (ushort) 158
      }), (GenAction) new Actions.ClearTile(true)));
    }

    internal static void AgeSnowRoom(Microsoft.Xna.Framework.Rectangle room)
    {
      WorldUtils.Gen(new Point(room.X, room.Y), (GenShape) new Shapes.Rectangle(room.Width, room.Height), Actions.Chain((GenAction) new Modifiers.Dither(0.600000023841858), (GenAction) new Modifiers.Blotches(2, 0.600000023841858), (GenAction) new Modifiers.OnlyTiles(new ushort[1]
      {
        CaveHouseBiome.BuildData.Snow.Tile
      }), (GenAction) new Actions.SetTile((ushort) 161, true, true), (GenAction) new Modifiers.Dither(0.8), (GenAction) new Actions.SetTile((ushort) 147, true, true)));
      WorldUtils.Gen(new Point(room.X + 1, room.Y), (GenShape) new Shapes.Rectangle(room.Width - 2, 1), Actions.Chain((GenAction) new Modifiers.Dither(0.5), (GenAction) new Modifiers.OnlyTiles(new ushort[1]
      {
        (ushort) 161
      }), (GenAction) new Modifiers.Offset(0, 1), (GenAction) new ActionStalagtite()));
      WorldUtils.Gen(new Point(room.X + 1, room.Y + room.Height - 1), (GenShape) new Shapes.Rectangle(room.Width - 2, 1), Actions.Chain((GenAction) new Modifiers.Dither(0.5), (GenAction) new Modifiers.OnlyTiles(new ushort[1]
      {
        (ushort) 161
      }), (GenAction) new Modifiers.Offset(0, 1), (GenAction) new ActionStalagtite()));
      WorldUtils.Gen(new Point(room.X, room.Y), (GenShape) new Shapes.Rectangle(room.Width, room.Height), Actions.Chain((GenAction) new Modifiers.Dither(0.850000023841858), (GenAction) new Modifiers.Blotches(2, 0.8), (double) room.Y > Main.worldSurface ? (GenAction) new Actions.ClearWall(true) : (GenAction) new Actions.PlaceWall((byte) 40, true)));
    }

    internal static void AgeDesertRoom(Microsoft.Xna.Framework.Rectangle room)
    {
      WorldUtils.Gen(new Point(room.X, room.Y), (GenShape) new Shapes.Rectangle(room.Width, room.Height), Actions.Chain((GenAction) new Modifiers.Dither(0.800000011920929), (GenAction) new Modifiers.Blotches(2, 0.200000002980232), (GenAction) new Modifiers.OnlyTiles(new ushort[1]
      {
        CaveHouseBiome.BuildData.Desert.Tile
      }), (GenAction) new Actions.SetTile((ushort) 396, true, true), (GenAction) new Modifiers.Dither(0.5), (GenAction) new Actions.SetTile((ushort) 397, true, true)));
      WorldUtils.Gen(new Point(room.X + 1, room.Y), (GenShape) new Shapes.Rectangle(room.Width - 2, 1), Actions.Chain((GenAction) new Modifiers.Dither(0.5), (GenAction) new Modifiers.OnlyTiles(new ushort[2]
      {
        (ushort) 397,
        (ushort) 396
      }), (GenAction) new Modifiers.Offset(0, 1), (GenAction) new ActionStalagtite()));
      WorldUtils.Gen(new Point(room.X + 1, room.Y + room.Height - 1), (GenShape) new Shapes.Rectangle(room.Width - 2, 1), Actions.Chain((GenAction) new Modifiers.Dither(0.5), (GenAction) new Modifiers.OnlyTiles(new ushort[2]
      {
        (ushort) 397,
        (ushort) 396
      }), (GenAction) new Modifiers.Offset(0, 1), (GenAction) new ActionStalagtite()));
      WorldUtils.Gen(new Point(room.X, room.Y), (GenShape) new Shapes.Rectangle(room.Width, room.Height), Actions.Chain((GenAction) new Modifiers.Dither(0.800000011920929), (GenAction) new Modifiers.Blotches(2, 0.3), (GenAction) new Modifiers.OnlyWalls(new byte[1]
      {
        CaveHouseBiome.BuildData.Desert.Wall
      }), (GenAction) new Actions.PlaceWall((byte) 216, true)));
    }

    internal static void AgeGraniteRoom(Microsoft.Xna.Framework.Rectangle room)
    {
      WorldUtils.Gen(new Point(room.X, room.Y), (GenShape) new Shapes.Rectangle(room.Width, room.Height), Actions.Chain((GenAction) new Modifiers.Dither(0.600000023841858), (GenAction) new Modifiers.Blotches(2, 0.600000023841858), (GenAction) new Modifiers.OnlyTiles(new ushort[1]
      {
        CaveHouseBiome.BuildData.Granite.Tile
      }), (GenAction) new Actions.SetTile((ushort) 368, true, true)));
      WorldUtils.Gen(new Point(room.X + 1, room.Y), (GenShape) new Shapes.Rectangle(room.Width - 2, 1), Actions.Chain((GenAction) new Modifiers.Dither(0.800000011920929), (GenAction) new Modifiers.OnlyTiles(new ushort[1]
      {
        (ushort) 368
      }), (GenAction) new Modifiers.Offset(0, 1), (GenAction) new ActionStalagtite()));
      WorldUtils.Gen(new Point(room.X + 1, room.Y + room.Height - 1), (GenShape) new Shapes.Rectangle(room.Width - 2, 1), Actions.Chain((GenAction) new Modifiers.Dither(0.800000011920929), (GenAction) new Modifiers.OnlyTiles(new ushort[1]
      {
        (ushort) 368
      }), (GenAction) new Modifiers.Offset(0, 1), (GenAction) new ActionStalagtite()));
      WorldUtils.Gen(new Point(room.X, room.Y), (GenShape) new Shapes.Rectangle(room.Width, room.Height), Actions.Chain((GenAction) new Modifiers.Dither(0.850000023841858), (GenAction) new Modifiers.Blotches(2, 0.3), (GenAction) new Actions.PlaceWall((byte) 180, true)));
    }

    internal static void AgeMarbleRoom(Microsoft.Xna.Framework.Rectangle room)
    {
      WorldUtils.Gen(new Point(room.X, room.Y), (GenShape) new Shapes.Rectangle(room.Width, room.Height), Actions.Chain((GenAction) new Modifiers.Dither(0.600000023841858), (GenAction) new Modifiers.Blotches(2, 0.600000023841858), (GenAction) new Modifiers.OnlyTiles(new ushort[1]
      {
        CaveHouseBiome.BuildData.Marble.Tile
      }), (GenAction) new Actions.SetTile((ushort) 367, true, true)));
      WorldUtils.Gen(new Point(room.X + 1, room.Y), (GenShape) new Shapes.Rectangle(room.Width - 2, 1), Actions.Chain((GenAction) new Modifiers.Dither(0.800000011920929), (GenAction) new Modifiers.OnlyTiles(new ushort[1]
      {
        (ushort) 367
      }), (GenAction) new Modifiers.Offset(0, 1), (GenAction) new ActionStalagtite()));
      WorldUtils.Gen(new Point(room.X + 1, room.Y + room.Height - 1), (GenShape) new Shapes.Rectangle(room.Width - 2, 1), Actions.Chain((GenAction) new Modifiers.Dither(0.800000011920929), (GenAction) new Modifiers.OnlyTiles(new ushort[1]
      {
        (ushort) 367
      }), (GenAction) new Modifiers.Offset(0, 1), (GenAction) new ActionStalagtite()));
      WorldUtils.Gen(new Point(room.X, room.Y), (GenShape) new Shapes.Rectangle(room.Width, room.Height), Actions.Chain((GenAction) new Modifiers.Dither(0.850000023841858), (GenAction) new Modifiers.Blotches(2, 0.3), (GenAction) new Actions.PlaceWall((byte) 178, true)));
    }

    internal static void AgeMushroomRoom(Microsoft.Xna.Framework.Rectangle room)
    {
      WorldUtils.Gen(new Point(room.X, room.Y), (GenShape) new Shapes.Rectangle(room.Width, room.Height), Actions.Chain((GenAction) new Modifiers.Dither(0.699999988079071), (GenAction) new Modifiers.Blotches(2, 0.5), (GenAction) new Modifiers.OnlyTiles(new ushort[1]
      {
        CaveHouseBiome.BuildData.Mushroom.Tile
      }), (GenAction) new Actions.SetTile((ushort) 70, true, true)));
      WorldUtils.Gen(new Point(room.X + 1, room.Y), (GenShape) new Shapes.Rectangle(room.Width - 2, 1), Actions.Chain((GenAction) new Modifiers.Dither(0.600000023841858), (GenAction) new Modifiers.OnlyTiles(new ushort[1]
      {
        (ushort) 70
      }), (GenAction) new Modifiers.Offset(0, -1), (GenAction) new Actions.SetTile((ushort) 71, false, true)));
      WorldUtils.Gen(new Point(room.X + 1, room.Y + room.Height - 1), (GenShape) new Shapes.Rectangle(room.Width - 2, 1), Actions.Chain((GenAction) new Modifiers.Dither(0.600000023841858), (GenAction) new Modifiers.OnlyTiles(new ushort[1]
      {
        (ushort) 70
      }), (GenAction) new Modifiers.Offset(0, -1), (GenAction) new Actions.SetTile((ushort) 71, false, true)));
      WorldUtils.Gen(new Point(room.X, room.Y), (GenShape) new Shapes.Rectangle(room.Width, room.Height), Actions.Chain((GenAction) new Modifiers.Dither(0.850000023841858), (GenAction) new Modifiers.Blotches(2, 0.3), (GenAction) new Actions.ClearWall(false)));
    }

    internal static void AgeJungleRoom(Microsoft.Xna.Framework.Rectangle room)
    {
      WorldUtils.Gen(new Point(room.X, room.Y), (GenShape) new Shapes.Rectangle(room.Width, room.Height), Actions.Chain((GenAction) new Modifiers.Dither(0.600000023841858), (GenAction) new Modifiers.Blotches(2, 0.600000023841858), (GenAction) new Modifiers.OnlyTiles(new ushort[1]
      {
        CaveHouseBiome.BuildData.Jungle.Tile
      }), (GenAction) new Actions.SetTile((ushort) 60, true, true), (GenAction) new Modifiers.Dither(0.800000011920929), (GenAction) new Actions.SetTile((ushort) 59, true, true)));
      WorldUtils.Gen(new Point(room.X + 1, room.Y), (GenShape) new Shapes.Rectangle(room.Width - 2, 1), Actions.Chain((GenAction) new Modifiers.Dither(0.5), (GenAction) new Modifiers.OnlyTiles(new ushort[1]
      {
        (ushort) 60
      }), (GenAction) new Modifiers.Offset(0, 1), (GenAction) new ActionVines(3, room.Height, 62)));
      WorldUtils.Gen(new Point(room.X + 1, room.Y + room.Height - 1), (GenShape) new Shapes.Rectangle(room.Width - 2, 1), Actions.Chain((GenAction) new Modifiers.Dither(0.5), (GenAction) new Modifiers.OnlyTiles(new ushort[1]
      {
        (ushort) 60
      }), (GenAction) new Modifiers.Offset(0, 1), (GenAction) new ActionVines(3, room.Height, 62)));
      WorldUtils.Gen(new Point(room.X, room.Y), (GenShape) new Shapes.Rectangle(room.Width, room.Height), Actions.Chain((GenAction) new Modifiers.Dither(0.850000023841858), (GenAction) new Modifiers.Blotches(2, 0.3), (GenAction) new Actions.PlaceWall((byte) 64, true)));
    }

    private class BuildData
    {
      public static CaveHouseBiome.BuildData Snow = CaveHouseBiome.BuildData.CreateSnowData();
      public static CaveHouseBiome.BuildData Jungle = CaveHouseBiome.BuildData.CreateJungleData();
      public static CaveHouseBiome.BuildData Default = CaveHouseBiome.BuildData.CreateDefaultData();
      public static CaveHouseBiome.BuildData Granite = CaveHouseBiome.BuildData.CreateGraniteData();
      public static CaveHouseBiome.BuildData Marble = CaveHouseBiome.BuildData.CreateMarbleData();
      public static CaveHouseBiome.BuildData Mushroom = CaveHouseBiome.BuildData.CreateMushroomData();
      public static CaveHouseBiome.BuildData Desert = CaveHouseBiome.BuildData.CreateDesertData();
      public ushort Tile;
      public byte Wall;
      public int PlatformStyle;
      public int DoorStyle;
      public int TableStyle;
      public int WorkbenchStyle;
      public int PianoStyle;
      public int BookcaseStyle;
      public int ChairStyle;
      public int ChestStyle;
      public CaveHouseBiome.BuildData.ProcessRoomMethod ProcessRoom;

      public static CaveHouseBiome.BuildData CreateSnowData()
      {
        CaveHouseBiome.BuildData buildData = new CaveHouseBiome.BuildData();
        buildData.Tile = (ushort) 321;
        buildData.Wall = (byte) 149;
        buildData.DoorStyle = 30;
        buildData.PlatformStyle = 19;
        buildData.TableStyle = 28;
        buildData.WorkbenchStyle = 23;
        buildData.PianoStyle = 23;
        buildData.BookcaseStyle = 25;
        buildData.ChairStyle = 30;
        buildData.ChestStyle = 11;
        CaveHouseBiome.BuildData.ProcessRoomMethod processRoomMethod = new CaveHouseBiome.BuildData.ProcessRoomMethod(CaveHouseBiome.AgeSnowRoom);
        buildData.ProcessRoom = processRoomMethod;
        return buildData;
      }

      public static CaveHouseBiome.BuildData CreateDesertData()
      {
        CaveHouseBiome.BuildData buildData = new CaveHouseBiome.BuildData();
        buildData.Tile = (ushort) 396;
        buildData.Wall = (byte) 187;
        buildData.PlatformStyle = 0;
        buildData.DoorStyle = 0;
        buildData.TableStyle = 0;
        buildData.WorkbenchStyle = 0;
        buildData.PianoStyle = 0;
        buildData.BookcaseStyle = 0;
        buildData.ChairStyle = 0;
        buildData.ChestStyle = 1;
        CaveHouseBiome.BuildData.ProcessRoomMethod processRoomMethod = new CaveHouseBiome.BuildData.ProcessRoomMethod(CaveHouseBiome.AgeDesertRoom);
        buildData.ProcessRoom = processRoomMethod;
        return buildData;
      }

      public static CaveHouseBiome.BuildData CreateJungleData()
      {
        CaveHouseBiome.BuildData buildData = new CaveHouseBiome.BuildData();
        buildData.Tile = (ushort) 158;
        buildData.Wall = (byte) 42;
        buildData.PlatformStyle = 2;
        buildData.DoorStyle = 2;
        buildData.TableStyle = 2;
        buildData.WorkbenchStyle = 2;
        buildData.PianoStyle = 2;
        buildData.BookcaseStyle = 12;
        buildData.ChairStyle = 3;
        buildData.ChestStyle = 8;
        CaveHouseBiome.BuildData.ProcessRoomMethod processRoomMethod = new CaveHouseBiome.BuildData.ProcessRoomMethod(CaveHouseBiome.AgeJungleRoom);
        buildData.ProcessRoom = processRoomMethod;
        return buildData;
      }

      public static CaveHouseBiome.BuildData CreateGraniteData()
      {
        CaveHouseBiome.BuildData buildData = new CaveHouseBiome.BuildData();
        buildData.Tile = (ushort) 369;
        buildData.Wall = (byte) 181;
        buildData.PlatformStyle = 28;
        buildData.DoorStyle = 34;
        buildData.TableStyle = 33;
        buildData.WorkbenchStyle = 29;
        buildData.PianoStyle = 28;
        buildData.BookcaseStyle = 30;
        buildData.ChairStyle = 34;
        buildData.ChestStyle = 50;
        CaveHouseBiome.BuildData.ProcessRoomMethod processRoomMethod = new CaveHouseBiome.BuildData.ProcessRoomMethod(CaveHouseBiome.AgeGraniteRoom);
        buildData.ProcessRoom = processRoomMethod;
        return buildData;
      }

      public static CaveHouseBiome.BuildData CreateMarbleData()
      {
        CaveHouseBiome.BuildData buildData = new CaveHouseBiome.BuildData();
        buildData.Tile = (ushort) 357;
        buildData.Wall = (byte) 179;
        buildData.PlatformStyle = 29;
        buildData.DoorStyle = 35;
        buildData.TableStyle = 34;
        buildData.WorkbenchStyle = 30;
        buildData.PianoStyle = 29;
        buildData.BookcaseStyle = 31;
        buildData.ChairStyle = 35;
        buildData.ChestStyle = 51;
        CaveHouseBiome.BuildData.ProcessRoomMethod processRoomMethod = new CaveHouseBiome.BuildData.ProcessRoomMethod(CaveHouseBiome.AgeMarbleRoom);
        buildData.ProcessRoom = processRoomMethod;
        return buildData;
      }

      public static CaveHouseBiome.BuildData CreateMushroomData()
      {
        CaveHouseBiome.BuildData buildData = new CaveHouseBiome.BuildData();
        buildData.Tile = (ushort) 190;
        buildData.Wall = (byte) 74;
        buildData.PlatformStyle = 18;
        buildData.DoorStyle = 6;
        buildData.TableStyle = 27;
        buildData.WorkbenchStyle = 7;
        buildData.PianoStyle = 22;
        buildData.BookcaseStyle = 24;
        buildData.ChairStyle = 9;
        buildData.ChestStyle = 32;
        CaveHouseBiome.BuildData.ProcessRoomMethod processRoomMethod = new CaveHouseBiome.BuildData.ProcessRoomMethod(CaveHouseBiome.AgeMushroomRoom);
        buildData.ProcessRoom = processRoomMethod;
        return buildData;
      }

      public static CaveHouseBiome.BuildData CreateDefaultData()
      {
        CaveHouseBiome.BuildData buildData = new CaveHouseBiome.BuildData();
        buildData.Tile = (ushort) 30;
        buildData.Wall = (byte) 27;
        buildData.PlatformStyle = 0;
        buildData.DoorStyle = 0;
        buildData.TableStyle = 0;
        buildData.WorkbenchStyle = 0;
        buildData.PianoStyle = 0;
        buildData.BookcaseStyle = 0;
        buildData.ChairStyle = 0;
        buildData.ChestStyle = 1;
        CaveHouseBiome.BuildData.ProcessRoomMethod processRoomMethod = new CaveHouseBiome.BuildData.ProcessRoomMethod(CaveHouseBiome.AgeDefaultRoom);
        buildData.ProcessRoom = processRoomMethod;
        return buildData;
      }

      public delegate void ProcessRoomMethod(Microsoft.Xna.Framework.Rectangle room);
    }
  }
}
