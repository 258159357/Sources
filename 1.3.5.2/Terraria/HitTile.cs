﻿// Decompiled with JetBrains decompiler
// Type: Terraria.HitTile
// Assembly: TerrariaServer, Version=1.3.5.1, Culture=neutral, PublicKeyToken=null
// MVID: C2103E81-0935-4BEA-9E98-4159FC80C2BB
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Terraria\TerrariaServer.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria.Utilities;

namespace Terraria
{
  public class HitTile
  {
    private static int lastCrack = -1;
    internal const int UNUSED = 0;
    internal const int TILE = 1;
    internal const int WALL = 2;
    internal const int MAX_HITTILES = 20;
    internal const int TIMETOLIVE = 60;
    private static UnifiedRandom rand;
    public HitTile.HitTileObject[] data;
    private int[] order;
    private int bufferLocation;

    public HitTile()
    {
      HitTile.rand = new UnifiedRandom();
      this.data = new HitTile.HitTileObject[21];
      this.order = new int[21];
      for (int index = 0; index <= 20; ++index)
      {
        this.data[index] = new HitTile.HitTileObject();
        this.order[index] = index;
      }
      this.bufferLocation = 0;
    }

    public int HitObject(int x, int y, int hitType)
    {
      for (int index1 = 0; index1 <= 20; ++index1)
      {
        int index2 = this.order[index1];
        HitTile.HitTileObject hitTileObject = this.data[index2];
        if (hitTileObject.type == hitType)
        {
          if (hitTileObject.X == x && hitTileObject.Y == y)
            return index2;
        }
        else if (index1 != 0 && hitTileObject.type == 0)
          break;
      }
      HitTile.HitTileObject hitTileObject1 = this.data[this.bufferLocation];
      hitTileObject1.X = x;
      hitTileObject1.Y = y;
      hitTileObject1.type = hitType;
      return this.bufferLocation;
    }

    public void UpdatePosition(int tileId, int x, int y)
    {
      if (tileId < 0 || tileId > 20)
        return;
      HitTile.HitTileObject hitTileObject = this.data[tileId];
      hitTileObject.X = x;
      hitTileObject.Y = y;
    }

    public int AddDamage(int tileId, int damageAmount, bool updateAmount = true)
    {
      if (tileId < 0 || tileId > 20 || tileId == this.bufferLocation && damageAmount == 0)
        return 0;
      HitTile.HitTileObject hitTileObject = this.data[tileId];
      if (!updateAmount)
        return hitTileObject.damage + damageAmount;
      hitTileObject.damage += damageAmount;
      hitTileObject.timeToLive = 60;
      hitTileObject.animationTimeElapsed = 0;
      hitTileObject.animationDirection = (Main.rand.NextFloat() * 6.283185f).ToRotationVector2() * 2f;
      if (tileId == this.bufferLocation)
      {
        this.bufferLocation = this.order[20];
        this.data[this.bufferLocation].Clear();
        for (int index = 20; index > 0; --index)
          this.order[index] = this.order[index - 1];
        this.order[0] = this.bufferLocation;
      }
      else
      {
        int index = 0;
        while (index <= 20 && this.order[index] != tileId)
          ++index;
        for (; index > 1; --index)
        {
          int num = this.order[index - 1];
          this.order[index - 1] = this.order[index];
          this.order[index] = num;
        }
        this.order[1] = tileId;
      }
      return hitTileObject.damage;
    }

    public void Clear(int tileId)
    {
      if (tileId < 0 || tileId > 20)
        return;
      this.data[tileId].Clear();
      int index = 0;
      while (index < 20 && this.order[index] != tileId)
        ++index;
      for (; index < 20; ++index)
        this.order[index] = this.order[index + 1];
      this.order[20] = tileId;
    }

    public void Prune()
    {
      bool flag = false;
      for (int index = 0; index <= 20; ++index)
      {
        HitTile.HitTileObject hitTileObject = this.data[index];
        if (hitTileObject.type != 0)
        {
          Tile tile = Main.tile[hitTileObject.X, hitTileObject.Y];
          if (hitTileObject.timeToLive <= 1)
          {
            hitTileObject.Clear();
            flag = true;
          }
          else
          {
            --hitTileObject.timeToLive;
            if ((double) hitTileObject.timeToLive < 12.0)
              hitTileObject.damage -= 10;
            else if ((double) hitTileObject.timeToLive < 24.0)
              hitTileObject.damage -= 7;
            else if ((double) hitTileObject.timeToLive < 36.0)
              hitTileObject.damage -= 5;
            else if ((double) hitTileObject.timeToLive < 48.0)
              hitTileObject.damage -= 2;
            if (hitTileObject.damage < 0)
            {
              hitTileObject.Clear();
              flag = true;
            }
            else if (hitTileObject.type == 1)
            {
              if (!tile.active())
              {
                hitTileObject.Clear();
                flag = true;
              }
            }
            else if ((int) tile.wall == 0)
            {
              hitTileObject.Clear();
              flag = true;
            }
          }
        }
      }
      if (!flag)
        return;
      int num1 = 1;
      while (flag)
      {
        flag = false;
        for (int index = num1; index < 20; ++index)
        {
          if (this.data[this.order[index]].type == 0 && this.data[this.order[index + 1]].type != 0)
          {
            int num2 = this.order[index];
            this.order[index] = this.order[index + 1];
            this.order[index + 1] = num2;
            flag = true;
          }
        }
      }
    }

    public void DrawFreshAnimations(SpriteBatch spriteBatch)
    {
      for (int index = 0; index < this.data.Length; ++index)
        ++this.data[index].animationTimeElapsed;
      if (!Main.SettingsEnabled_MinersWobble)
        return;
      int num1 = 1;
      Vector2 vector2_1 = new Vector2((float) Main.offScreenRange);
      if (Main.drawToScreen)
        vector2_1 = Vector2.Zero;
      vector2_1 = Vector2.Zero;
      for (int index = 0; index < this.data.Length; ++index)
      {
        if (this.data[index].type == num1)
        {
          int damage = this.data[index].damage;
          if (damage >= 20)
          {
            int x = this.data[index].X;
            int y = this.data[index].Y;
            if (WorldGen.InWorld(x, y, 0))
            {
              bool flag1 = Main.tile[x, y] != null;
              if (flag1 && num1 == 1)
                flag1 = flag1 && Main.tile[x, y].active() && Main.tileSolid[(int) Main.tile[x, y].type];
              if (flag1 && num1 == 2)
                flag1 = flag1 && (int) Main.tile[x, y].wall != 0;
              if (flag1)
              {
                bool flag2 = false;
                bool flag3 = false;
                if ((int) Main.tile[x, y].type == 10)
                  flag2 = false;
                else if (Main.tileSolid[(int) Main.tile[x, y].type] && !Main.tileSolidTop[(int) Main.tile[x, y].type])
                  flag2 = true;
                else if ((int) Main.tile[x, y].type == 5)
                {
                  flag3 = true;
                  int num2 = (int) Main.tile[x, y].frameX / 22;
                  int num3 = (int) Main.tile[x, y].frameY / 22;
                  if (num3 < 9)
                    flag2 = (num2 != 1 && num2 != 2 || (num3 < 6 || num3 > 8)) && ((num2 != 3 || num3 > 2) && ((num2 != 4 || num3 < 3 || num3 > 5) && (num2 != 5 || num3 < 6 || num3 > 8)));
                }
                else if ((int) Main.tile[x, y].type == 72)
                {
                  flag3 = true;
                  if ((int) Main.tile[x, y].frameX <= 34)
                    flag2 = true;
                }
                if (flag2 && (int) Main.tile[x, y].slope() == 0 && !Main.tile[x, y].halfBrick())
                {
                  int num2 = 0;
                  if (damage >= 80)
                    num2 = 3;
                  else if (damage >= 60)
                    num2 = 2;
                  else if (damage >= 40)
                    num2 = 1;
                  else if (damage >= 20)
                    num2 = 0;
                  Rectangle rectangle = new Rectangle(this.data[index].crackStyle * 18, num2 * 18, 16, 16);
                  rectangle.Inflate(-2, -2);
                  if (flag3)
                    rectangle.X = (4 + this.data[index].crackStyle / 2) * 18;
                  int animationTimeElapsed = this.data[index].animationTimeElapsed;
                  if ((double) animationTimeElapsed < 10.0)
                  {
                    float num3 = (float) animationTimeElapsed / 10f;
                    float num4 = 1f;
                    Color color1 = Lighting.GetColor(x, y);
                    float rotation = 0.0f;
                    Vector2 zero = Vector2.Zero;
                    float num5 = num3;
                    float num6 = 0.5f;
                    float num7 = num5 % num6 * (1f / num6);
                    if ((int) ((double) num5 / (double) num6) % 2 == 1)
                      num7 = 1f - num7;
                    num4 = (float) ((double) num7 * 0.449999988079071 + 1.0);
                    Tile tileSafely = Framing.GetTileSafely(x, y);
                    Tile tile = tileSafely;
                    Texture2D texture = !Main.canDrawColorTile(tileSafely.type, (int) tileSafely.color()) ? Main.tileTexture[(int) tileSafely.type] : (Texture2D) Main.tileAltTexture[(int) tileSafely.type, (int) tileSafely.color()];
                    Vector2 origin = new Vector2(8f);
                    Vector2 vector2_2 = new Vector2(1f);
                    float num8 = (float) ((double) num7 * 0.200000002980232 + 1.0);
                    float num9 = 1f - num7;
                    float num10 = 1f;
                    Color color2 = color1 * (float) ((double) num10 * (double) num10 * 0.800000011920929);
                    Vector2 scale = num8 * vector2_2;
                    Vector2 position = (new Vector2((float) (x * 16 - (int) Main.screenPosition.X), (float) (y * 16 - (int) Main.screenPosition.Y)) + vector2_1 + origin + zero).Floor();
                    spriteBatch.Draw(texture, position, new Rectangle?(new Rectangle((int) tile.frameX, (int) tile.frameY, 16, 16)), color2, rotation, origin, scale, SpriteEffects.None, 0.0f);
                    color2.A = (byte) 180;
                    spriteBatch.Draw(Main.tileCrackTexture, position, new Rectangle?(rectangle), color2, rotation, origin, scale, SpriteEffects.None, 0.0f);
                  }
                }
              }
            }
          }
        }
      }
    }

    public class HitTileObject
    {
      public int X;
      public int Y;
      public int damage;
      public int type;
      public int timeToLive;
      public int crackStyle;
      public int animationTimeElapsed;
      public Vector2 animationDirection;

      public HitTileObject()
      {
        this.Clear();
      }

      public void Clear()
      {
        this.X = 0;
        this.Y = 0;
        this.damage = 0;
        this.type = 0;
        this.timeToLive = 0;
        if (HitTile.rand == null)
          HitTile.rand = new UnifiedRandom((int) DateTime.Now.Ticks);
        this.crackStyle = HitTile.rand.Next(4);
        while (this.crackStyle == HitTile.lastCrack)
          this.crackStyle = HitTile.rand.Next(4);
        HitTile.lastCrack = this.crackStyle;
      }
    }
  }
}
