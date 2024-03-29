﻿// Decompiled with JetBrains decompiler
// Type: Terraria.Gore
// Assembly: TerrariaServer, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: AA3606A2-F3DB-4481-937B-7295FB97CD3E
// Assembly location: E:\TSHOCK\TerrariaServer.exe

using Microsoft.Xna.Framework;
using System;
using Terraria.GameContent;
using Terraria.GameContent.Shaders;
using Terraria.Graphics.Effects;
using Terraria.ID;
using Terraria.Utilities;

namespace Terraria
{
  public class Gore
  {
    public static int goreTime = 600;
    public bool sticky = true;
    public int timeLeft = Gore.goreTime;
    public byte numFrames = 1;
    public Vector2 position;
    public Vector2 velocity;
    public float rotation;
    public float scale;
    public int alpha;
    public int type;
    public float light;
    public bool active;
    public bool behindTiles;
    public byte frame;
    public byte frameCounter;

    public void Update()
    {
      if (Main.netMode == 2 || !this.active)
        return;
      bool flag = this.type >= 1024 && this.type <= 1026;
      if (this.type >= 276 && this.type <= 282)
      {
        this.velocity.X *= 0.98f;
        this.velocity.Y *= 0.98f;
        if ((double) this.velocity.Y < (double) this.scale)
          this.velocity.Y += 0.05f;
        if ((double) this.velocity.Y > 0.1)
          this.rotation = (double) this.velocity.X <= 0.0 ? this.rotation - 0.01f : this.rotation + 0.01f;
      }
      if (this.type >= 570 && this.type <= 572)
      {
        this.scale = this.scale - 1f / 1000f;
        if ((double) this.scale <= 0.01)
        {
          this.scale = 0.01f;
          Gore.goreTime = 0;
        }
        this.sticky = false;
        this.rotation = this.velocity.X * 0.1f;
      }
      else if (this.type >= 706 && this.type <= 717 || this.type == 943)
      {
        this.alpha = (double) this.position.Y >= Main.worldSurface * 16.0 + 8.0 ? 100 : 0;
        int num1 = 4;
        this.frameCounter = (byte) ((uint) this.frameCounter + 1U);
        if ((int) this.frame <= 4)
        {
          int x = (int) ((double) this.position.X / 16.0);
          int y = (int) ((double) this.position.Y / 16.0) - 1;
          if (WorldGen.InWorld(x, y, 0) && !Main.tile[x, y].active())
            this.active = false;
          if ((int) this.frame == 0)
            num1 = 24 + Main.rand.Next(256);
          if ((int) this.frame == 1)
            num1 = 24 + Main.rand.Next(256);
          if ((int) this.frame == 2)
            num1 = 24 + Main.rand.Next(256);
          if ((int) this.frame == 3)
            num1 = 24 + Main.rand.Next(96);
          if ((int) this.frame == 5)
            num1 = 16 + Main.rand.Next(64);
          if (this.type == 716)
            num1 *= 2;
          if (this.type == 717)
            num1 *= 4;
          if (this.type == 943 && (int) this.frame < 6)
            num1 = 4;
          if ((int) this.frameCounter >= num1)
          {
            this.frameCounter = (byte) 0;
            this.frame = (byte) ((uint) this.frame + 1U);
            if ((int) this.frame == 5)
            {
              int index = Gore.NewGore(this.position, this.velocity, this.type, 1f);
              Main.gore[index].frame = (byte) 9;
              Main.gore[index].velocity *= 0.0f;
            }
            if (this.type == 943 && (int) this.frame > 4)
            {
              if (Main.rand.Next(2) == 0)
              {
                Gore gore = Main.gore[Gore.NewGore(this.position, this.velocity, this.type, this.scale)];
                int num2 = 0;
                gore.frameCounter = (byte) num2;
                int num3 = 7;
                gore.frame = (byte) num3;
                Vector2 vector2 = Vector2.UnitY * 1f;
                gore.velocity = vector2;
              }
              if (Main.rand.Next(2) == 0)
              {
                Gore gore = Main.gore[Gore.NewGore(this.position, this.velocity, this.type, this.scale)];
                int num2 = 0;
                gore.frameCounter = (byte) num2;
                int num3 = 7;
                gore.frame = (byte) num3;
                Vector2 vector2 = Vector2.UnitY * 2f;
                gore.velocity = vector2;
              }
            }
          }
        }
        else if ((int) this.frame <= 6)
        {
          int num2 = 8;
          if (this.type == 716)
            num2 *= 2;
          if (this.type == 717)
            num2 *= 3;
          if ((int) this.frameCounter >= num2)
          {
            this.frameCounter = (byte) 0;
            this.frame = (byte) ((uint) this.frame + 1U);
            if ((int) this.frame == 7)
              this.active = false;
          }
        }
        else if ((int) this.frame <= 9)
        {
          int num2 = 6;
          if (this.type == 716)
          {
            num2 = (int) ((double) num2 * 1.5);
            this.velocity.Y += 0.175f;
          }
          else if (this.type == 717)
          {
            num2 *= 2;
            this.velocity.Y += 0.15f;
          }
          else if (this.type == 943)
          {
            num2 = (int) ((double) num2 * 1.5);
            this.velocity.Y += 0.2f;
          }
          else
            this.velocity.Y += 0.2f;
          if ((double) this.velocity.Y < 0.5)
            this.velocity.Y = 0.5f;
          if ((double) this.velocity.Y > 12.0)
            this.velocity.Y = 12f;
          if ((int) this.frameCounter >= num2)
          {
            this.frameCounter = (byte) 0;
            this.frame = (byte) ((uint) this.frame + 1U);
          }
          if ((int) this.frame > 9)
            this.frame = (byte) 7;
        }
        else
        {
          if (this.type == 716)
            num1 *= 2;
          else if (this.type == 717)
            num1 *= 6;
          this.velocity.Y += 0.1f;
          if ((int) this.frameCounter >= num1)
          {
            this.frameCounter = (byte) 0;
            this.frame = (byte) ((uint) this.frame + 1U);
          }
          this.velocity = this.velocity * 0.0f;
          if ((int) this.frame > 14)
            this.active = false;
        }
      }
      else if (this.type == 11 || this.type == 12 || (this.type == 13 || this.type == 61) || (this.type == 62 || this.type == 63 || (this.type == 99 || this.type == 220)) || (this.type == 221 || this.type == 222 || this.type >= 375 && this.type <= 377 || (this.type >= 435 && this.type <= 437 || this.type >= 861 && this.type <= 862)))
      {
        this.velocity.Y *= 0.98f;
        this.velocity.X *= 0.98f;
        this.scale = this.scale - 0.007f;
        if ((double) this.scale < 0.1)
        {
          this.scale = 0.1f;
          this.alpha = (int) byte.MaxValue;
        }
      }
      else if (this.type == 16 || this.type == 17)
      {
        this.velocity.Y *= 0.98f;
        this.velocity.X *= 0.98f;
        this.scale = this.scale - 0.01f;
        if ((double) this.scale < 0.1)
        {
          this.scale = 0.1f;
          this.alpha = (int) byte.MaxValue;
        }
      }
      else if (this.type == 331)
      {
        this.alpha = this.alpha + 5;
        this.velocity.Y *= 0.95f;
        this.velocity.X *= 0.95f;
        this.rotation = this.velocity.X * 0.1f;
      }
      else if (GoreID.Sets.SpecialAI[this.type] == 3)
      {
        byte num1 = (byte) ((uint) this.frameCounter + 1U);
        this.frameCounter = num1;
        if ((int) num1 >= 8 && (double) this.velocity.Y > 0.200000002980232)
        {
          this.frameCounter = (byte) 0;
          int num2 = (int) this.frame / 4;
          byte num3 = (byte) ((uint) this.frame + 1U);
          this.frame = num3;
          if ((int) num3 >= 4 + num2 * 4)
            this.frame = (byte) (num2 * 4);
        }
      }
      else if (GoreID.Sets.SpecialAI[this.type] != 1 && GoreID.Sets.SpecialAI[this.type] != 2)
      {
        if (this.type >= 907 && this.type <= 909)
        {
          this.rotation = 0.0f;
          this.velocity.X *= 0.98f;
          if ((double) this.velocity.Y > 0.0 && (double) this.velocity.Y < 1.0 / 1000.0)
            this.velocity.Y = (float) ((double) Main.rand.NextFloat() * -3.0 - 0.5);
          if ((double) this.velocity.Y > -1.0)
            this.velocity.Y -= 0.1f;
          if ((double) this.scale < 1.0)
            this.scale = this.scale + 0.1f;
          byte num1 = (byte) ((uint) this.frameCounter + 1U);
          this.frameCounter = num1;
          if ((int) num1 >= 8)
          {
            this.frameCounter = (byte) 0;
            byte num2 = (byte) ((uint) this.frame + 1U);
            this.frame = num2;
            if ((int) num2 >= 3)
              this.frame = (byte) 0;
          }
        }
        else if (this.type < 411 || this.type > 430)
          this.velocity.Y += 0.2f;
      }
      this.rotation = this.rotation + this.velocity.X * 0.1f;
      if (this.type >= 580 && this.type <= 582)
      {
        this.rotation = 0.0f;
        this.velocity.X *= 0.95f;
      }
      if (GoreID.Sets.SpecialAI[this.type] == 2)
      {
        if (this.timeLeft < 60)
          this.alpha = this.alpha + Main.rand.Next(1, 7);
        else if (this.alpha > 100)
          this.alpha = this.alpha - Main.rand.Next(1, 4);
        if (this.alpha < 0)
          this.alpha = 0;
        if (this.alpha > (int) byte.MaxValue)
          this.timeLeft = 0;
        this.velocity.X = (float) (((double) this.velocity.X * 50.0 + (double) Main.windSpeed * 2.0 + (double) Main.rand.Next(-10, 11) * 0.100000001490116) / 51.0);
        float num1 = 0.0f;
        if ((double) this.velocity.X < 0.0)
          num1 = this.velocity.X * 0.2f;
        this.velocity.Y = (float) (((double) this.velocity.Y * 50.0 - 0.349999994039536 + (double) num1 + (double) Main.rand.Next(-10, 11) * 0.200000002980232) / 51.0);
        this.rotation = this.velocity.X * 0.6f;
        float num2 = -1f;
        if (Main.goreLoaded[this.type])
        {
          Rectangle rectangle1 = new Rectangle((int) this.position.X, (int) this.position.Y, (int) ((double) Main.goreTexture[this.type].Width * (double) this.scale), (int) ((double) Main.goreTexture[this.type].Height * (double) this.scale));
          for (int index = 0; index < (int) byte.MaxValue; ++index)
          {
            if (Main.player[index].active && !Main.player[index].dead)
            {
              Rectangle rectangle2 = new Rectangle((int) Main.player[index].position.X, (int) Main.player[index].position.Y, Main.player[index].width, Main.player[index].height);
              if (rectangle1.Intersects(rectangle2))
              {
                this.timeLeft = 0;
                num2 = Main.player[index].velocity.Length();
                break;
              }
            }
          }
        }
        if (this.timeLeft > 0)
        {
          if (Main.rand.Next(2) == 0)
            this.timeLeft = this.timeLeft - 1;
          if (Main.rand.Next(50) == 0)
            this.timeLeft = this.timeLeft - 5;
          if (Main.rand.Next(100) == 0)
            this.timeLeft = this.timeLeft - 10;
        }
        else
        {
          this.alpha = (int) byte.MaxValue;
          if (Main.goreLoaded[this.type] && (double) num2 != -1.0)
          {
            float num3 = (float) ((double) Main.goreTexture[this.type].Width * (double) this.scale * 0.800000011920929);
            float x = this.position.X;
            float y = this.position.Y;
            float num4 = (float) Main.goreTexture[this.type].Width * this.scale;
            float num5 = (float) Main.goreTexture[this.type].Height * this.scale;
            int Type = 31;
            for (int index1 = 0; (double) index1 < (double) num3; ++index1)
            {
              int index2 = Dust.NewDust(new Vector2(x, y), (int) num4, (int) num5, Type, 0.0f, 0.0f, 0, new Color(), 1f);
              Main.dust[index2].velocity *= (float) ((1.0 + (double) num2) / 3.0);
              Main.dust[index2].noGravity = true;
              Main.dust[index2].alpha = 100;
              Main.dust[index2].scale = this.scale;
            }
          }
        }
      }
      if (this.type >= 411 && this.type <= 430)
      {
        this.alpha = 50;
        this.velocity.X = (float) (((double) this.velocity.X * 50.0 + (double) Main.windSpeed * 2.0 + (double) Main.rand.Next(-10, 11) * 0.100000001490116) / 51.0);
        this.velocity.Y = (float) (((double) this.velocity.Y * 50.0 - 0.25 + (double) Main.rand.Next(-10, 11) * 0.200000002980232) / 51.0);
        this.rotation = this.velocity.X * 0.3f;
        if (Main.goreLoaded[this.type])
        {
          Rectangle rectangle1 = new Rectangle((int) this.position.X, (int) this.position.Y, (int) ((double) Main.goreTexture[this.type].Width * (double) this.scale), (int) ((double) Main.goreTexture[this.type].Height * (double) this.scale));
          for (int index = 0; index < (int) byte.MaxValue; ++index)
          {
            if (Main.player[index].active && !Main.player[index].dead)
            {
              Rectangle rectangle2 = new Rectangle((int) Main.player[index].position.X, (int) Main.player[index].position.Y, Main.player[index].width, Main.player[index].height);
              if (rectangle1.Intersects(rectangle2))
                this.timeLeft = 0;
            }
          }
          if (Collision.SolidCollision(this.position, (int) ((double) Main.goreTexture[this.type].Width * (double) this.scale), (int) ((double) Main.goreTexture[this.type].Height * (double) this.scale)))
            this.timeLeft = 0;
        }
        if (this.timeLeft > 0)
        {
          if (Main.rand.Next(2) == 0)
            this.timeLeft = this.timeLeft - 1;
          if (Main.rand.Next(50) == 0)
            this.timeLeft = this.timeLeft - 5;
          if (Main.rand.Next(100) == 0)
            this.timeLeft = this.timeLeft - 10;
        }
        else
        {
          this.alpha = (int) byte.MaxValue;
          if (Main.goreLoaded[this.type])
          {
            float num1 = (float) ((double) Main.goreTexture[this.type].Width * (double) this.scale * 0.800000011920929);
            float x = this.position.X;
            float y = this.position.Y;
            float num2 = (float) Main.goreTexture[this.type].Width * this.scale;
            float num3 = (float) Main.goreTexture[this.type].Height * this.scale;
            int Type = 176;
            if (this.type >= 416 && this.type <= 420)
              Type = 177;
            if (this.type >= 421 && this.type <= 425)
              Type = 178;
            if (this.type >= 426 && this.type <= 430)
              Type = 179;
            for (int index1 = 0; (double) index1 < (double) num1; ++index1)
            {
              int index2 = Dust.NewDust(new Vector2(x, y), (int) num2, (int) num3, Type, 0.0f, 0.0f, 0, new Color(), 1f);
              Main.dust[index2].noGravity = true;
              Main.dust[index2].alpha = 100;
              Main.dust[index2].scale = this.scale;
            }
          }
        }
      }
      else if (GoreID.Sets.SpecialAI[this.type] != 3 && GoreID.Sets.SpecialAI[this.type] != 1)
      {
        if (this.type >= 706 && this.type <= 717 || this.type == 943)
        {
          if (this.type == 716)
          {
            float num1 = 0.6f;
            float num2 = (int) this.frame != 0 ? ((int) this.frame != 1 ? ((int) this.frame != 2 ? ((int) this.frame != 3 ? ((int) this.frame != 4 ? ((int) this.frame != 5 ? ((int) this.frame != 6 ? ((int) this.frame > 9 ? ((int) this.frame != 10 ? ((int) this.frame != 11 ? ((int) this.frame != 12 ? ((int) this.frame != 13 ? ((int) this.frame != 14 ? 0.0f : num1 * 0.1f) : num1 * 0.2f) : num1 * 0.3f) : num1 * 0.4f) : num1 * 0.5f) : num1 * 0.5f) : num1 * 0.2f) : num1 * 0.4f) : num1 * 0.5f) : num1 * 0.4f) : num1 * 0.3f) : num1 * 0.2f) : num1 * 0.1f;
            Lighting.AddLight(this.position + new Vector2(8f, 8f), 1f * num2, 0.5f * num2, 0.1f * num2);
          }
          Vector2 velocity = this.velocity;
          this.velocity = Collision.TileCollision(this.position, this.velocity, 16, 14, false, false, 1);
          if (this.velocity != velocity)
          {
            if ((int) this.frame < 10)
            {
              this.frame = (byte) 10;
              this.frameCounter = (byte) 0;
              if (this.type != 716 && this.type != 717 && this.type != 943)
                Main.PlaySound(39, (int) this.position.X + 8, (int) this.position.Y + 8, Main.rand.Next(2), 1f, 0.0f);
            }
          }
          else if (Collision.WetCollision(this.position + this.velocity, 16, 14))
          {
            if ((int) this.frame < 10)
            {
              this.frame = (byte) 10;
              this.frameCounter = (byte) 0;
              if (this.type != 716 && this.type != 717 && this.type != 943)
                Main.PlaySound(39, (int) this.position.X + 8, (int) this.position.Y + 8, 2, 1f, 0.0f);
              ((WaterShaderData) Filters.Scene["WaterDistortion"].GetShader()).QueueRipple(this.position + new Vector2(8f, 8f), 1f, RippleShape.Square, 0.0f);
            }
            int index1 = (int) ((double) this.position.X + 8.0) / 16;
            int index2 = (int) ((double) this.position.Y + 14.0) / 16;
            if (Main.tile[index1, index2] != null && (int) Main.tile[index1, index2].liquid > 0)
            {
              this.velocity = this.velocity * 0.0f;
              this.position.Y = (float) (index2 * 16 - (int) Main.tile[index1, index2].liquid / 16);
            }
          }
        }
        else if (this.sticky)
        {
          int num1 = 32;
          if (Main.goreLoaded[this.type])
          {
            num1 = Main.goreTexture[this.type].Width;
            if (Main.goreTexture[this.type].Height < num1)
              num1 = Main.goreTexture[this.type].Height;
          }
          if (flag)
            num1 = 4;
          int num2 = (int) ((double) num1 * 0.899999976158142);
          Vector2 velocity = this.velocity;
          this.velocity = Collision.TileCollision(this.position, this.velocity, (int) ((double) num2 * (double) this.scale), (int) ((double) num2 * (double) this.scale), false, false, 1);
          if ((double) this.velocity.Y == 0.0)
          {
            if (flag)
              this.velocity.X *= 0.94f;
            else
              this.velocity.X *= 0.97f;
            if ((double) this.velocity.X > -0.01 && (double) this.velocity.X < 0.01)
              this.velocity.X = 0.0f;
          }
          if (this.timeLeft > 0)
            this.timeLeft = this.timeLeft - GoreID.Sets.DisappearSpeed[this.type];
          else
            this.alpha = this.alpha + GoreID.Sets.DisappearSpeedAlpha[this.type];
        }
        else
          this.alpha = this.alpha + 2 * GoreID.Sets.DisappearSpeedAlpha[this.type];
      }
      if (this.type >= 907 && this.type <= 909)
      {
        int num1 = 32;
        if (Main.goreLoaded[this.type])
        {
          num1 = Main.goreTexture[this.type].Width;
          if (Main.goreTexture[this.type].Height < num1)
            num1 = Main.goreTexture[this.type].Height;
        }
        int num2 = (int) ((double) num1 * 0.899999976158142);
        Vector4 vector4 = Collision.SlopeCollision(this.position, this.velocity, num2, num2, 0.0f, true);
        this.position.X = vector4.X;
        this.position.Y = vector4.Y;
        this.velocity.X = vector4.Z;
        this.velocity.Y = vector4.W;
      }
      if (GoreID.Sets.SpecialAI[this.type] == 1)
      {
        if ((double) this.velocity.Y < 0.0)
        {
          Vector2 Velocity = new Vector2(this.velocity.X, 0.6f);
          int num1 = 32;
          if (Main.goreLoaded[this.type])
          {
            num1 = Main.goreTexture[this.type].Width;
            if (Main.goreTexture[this.type].Height < num1)
              num1 = Main.goreTexture[this.type].Height;
          }
          int num2 = (int) ((double) num1 * 0.899999976158142);
          Vector2 vector2 = Collision.TileCollision(this.position, Velocity, (int) ((double) num2 * (double) this.scale), (int) ((double) num2 * (double) this.scale), false, false, 1);
          vector2.X *= 0.97f;
          if ((double) vector2.X > -0.01 && (double) vector2.X < 0.01)
            vector2.X = 0.0f;
          if (this.timeLeft > 0)
            this.timeLeft = this.timeLeft - 1;
          else
            this.alpha = this.alpha + 1;
          this.velocity.X = vector2.X;
        }
        else
        {
          this.velocity.Y += (float) Math.PI / 60f;
          Vector2 Velocity = new Vector2(Vector2.UnitY.RotatedBy((double) this.velocity.Y, new Vector2()).X * 2f, Math.Abs(Vector2.UnitY.RotatedBy((double) this.velocity.Y, new Vector2()).Y) * 3f) * 2f;
          int num = 32;
          if (Main.goreLoaded[this.type])
          {
            num = Main.goreTexture[this.type].Width;
            if (Main.goreTexture[this.type].Height < num)
              num = Main.goreTexture[this.type].Height;
          }
          Vector2 vector2 = Velocity;
          Vector2 v = Collision.TileCollision(this.position, Velocity, (int) ((double) num * (double) this.scale), (int) ((double) num * (double) this.scale), false, false, 1);
          if (v != vector2)
            this.velocity.Y = -1f;
          this.position = this.position + v;
          this.rotation = v.ToRotation() + 3.141593f;
          if (this.timeLeft > 0)
            this.timeLeft = this.timeLeft - 1;
          else
            this.alpha = this.alpha + 1;
        }
      }
      else if (GoreID.Sets.SpecialAI[this.type] == 3)
      {
        if ((double) this.velocity.Y < 0.0)
        {
          Vector2 Velocity = new Vector2(this.velocity.X, -0.2f);
          int num1 = 8;
          if (Main.goreLoaded[this.type])
          {
            num1 = Main.goreTexture[this.type].Width;
            if (Main.goreTexture[this.type].Height < num1)
              num1 = Main.goreTexture[this.type].Height;
          }
          int num2 = (int) ((double) num1 * 0.899999976158142);
          Vector2 vector2 = Collision.TileCollision(this.position, Velocity, (int) ((double) num2 * (double) this.scale), (int) ((double) num2 * (double) this.scale), false, false, 1);
          vector2.X *= 0.94f;
          if ((double) vector2.X > -0.01 && (double) vector2.X < 0.01)
            vector2.X = 0.0f;
          if (this.timeLeft > 0)
            this.timeLeft = this.timeLeft - GoreID.Sets.DisappearSpeed[this.type];
          else
            this.alpha = this.alpha + GoreID.Sets.DisappearSpeedAlpha[this.type];
          this.velocity.X = vector2.X;
        }
        else
        {
          this.velocity.Y += (float) Math.PI / 180f;
          Vector2 Velocity = new Vector2(Vector2.UnitY.RotatedBy((double) this.velocity.Y, new Vector2()).X * 1f, Math.Abs(Vector2.UnitY.RotatedBy((double) this.velocity.Y, new Vector2()).Y) * 1f);
          int num = 8;
          if (Main.goreLoaded[this.type])
          {
            num = Main.goreTexture[this.type].Width;
            if (Main.goreTexture[this.type].Height < num)
              num = Main.goreTexture[this.type].Height;
          }
          Vector2 vector2 = Velocity;
          Vector2 v = Collision.TileCollision(this.position, Velocity, (int) ((double) num * (double) this.scale), (int) ((double) num * (double) this.scale), false, false, 1);
          if (v != vector2)
            this.velocity.Y = -1f;
          this.position = this.position + v;
          this.rotation = v.ToRotation() + 1.570796f;
          if (this.timeLeft > 0)
            this.timeLeft = this.timeLeft - GoreID.Sets.DisappearSpeed[this.type];
          else
            this.alpha = this.alpha + GoreID.Sets.DisappearSpeedAlpha[this.type];
        }
      }
      else
        this.position = this.position + this.velocity;
      if (this.alpha >= (int) byte.MaxValue)
        this.active = false;
      if ((double) this.light <= 0.0)
        return;
      float R = this.light * this.scale;
      float G = this.light * this.scale;
      float B = this.light * this.scale;
      if (this.type == 16)
      {
        B *= 0.3f;
        G *= 0.8f;
      }
      else if (this.type == 17)
      {
        G *= 0.6f;
        R *= 0.3f;
      }
      if (Main.goreLoaded[this.type])
        Lighting.AddLight((int) (((double) this.position.X + (double) Main.goreTexture[this.type].Width * (double) this.scale / 2.0) / 16.0), (int) (((double) this.position.Y + (double) Main.goreTexture[this.type].Height * (double) this.scale / 2.0) / 16.0), R, G, B);
      else
        Lighting.AddLight((int) (((double) this.position.X + 32.0 * (double) this.scale / 2.0) / 16.0), (int) (((double) this.position.Y + 32.0 * (double) this.scale / 2.0) / 16.0), R, G, B);
    }

    public static Gore NewGorePerfect(Vector2 Position, Vector2 Velocity, int Type, float Scale = 1f)
    {
      Gore gore = Gore.NewGoreDirect(Position, Velocity, Type, Scale);
      Vector2 vector2_1 = Position;
      gore.position = vector2_1;
      Vector2 vector2_2 = Velocity;
      gore.velocity = vector2_2;
      return gore;
    }

    public static Gore NewGoreDirect(Vector2 Position, Vector2 Velocity, int Type, float Scale = 1f)
    {
      return Main.gore[Gore.NewGore(Position, Velocity, Type, Scale)];
    }

    public static int NewGore(Vector2 Position, Vector2 Velocity, int Type, float Scale = 1f)
    {
      if (Main.netMode == 2 || Main.gamePaused)
        return 500;
      if (Main.rand == null)
        Main.rand = new UnifiedRandom();
      int index1 = 500;
      for (int index2 = 0; index2 < 500; ++index2)
      {
        if (!Main.gore[index2].active)
        {
          index1 = index2;
          break;
        }
      }
      if (index1 == 500)
        return index1;
      Main.gore[index1].numFrames = (byte) 1;
      Main.gore[index1].frame = (byte) 0;
      Main.gore[index1].frameCounter = (byte) 0;
      Main.gore[index1].behindTiles = false;
      Main.gore[index1].light = 0.0f;
      Main.gore[index1].position = Position;
      Main.gore[index1].velocity = Velocity;
      Main.gore[index1].velocity.Y -= (float) Main.rand.Next(10, 31) * 0.1f;
      Main.gore[index1].velocity.X += (float) Main.rand.Next(-20, 21) * 0.1f;
      Main.gore[index1].type = Type;
      Main.gore[index1].active = true;
      Main.gore[index1].alpha = 0;
      Main.gore[index1].rotation = 0.0f;
      Main.gore[index1].scale = Scale;
      if (!ChildSafety.Disabled && ChildSafety.DangerousGore(Type))
      {
        Main.gore[index1].type = Main.rand.Next(11, 14);
        Main.gore[index1].scale = (float) ((double) Main.rand.NextFloat() * 0.5 + 0.5);
        Main.gore[index1].velocity /= 2f;
      }
      if (Gore.goreTime == 0 || Type == 11 || (Type == 12 || Type == 13) || (Type == 16 || Type == 17 || (Type == 61 || Type == 62)) || (Type == 63 || Type == 99 || (Type == 220 || Type == 221) || (Type == 222 || Type == 435 || (Type == 436 || Type == 437))) || Type >= 861 && Type <= 862)
        Main.gore[index1].sticky = false;
      else if (Type >= 375 && Type <= 377)
      {
        Main.gore[index1].sticky = false;
        Main.gore[index1].alpha = 100;
      }
      else
      {
        Main.gore[index1].sticky = true;
        Main.gore[index1].timeLeft = Gore.goreTime;
      }
      if (Type >= 706 && Type <= 717 || Type == 943)
      {
        Main.gore[index1].numFrames = (byte) 15;
        Main.gore[index1].behindTiles = true;
        Main.gore[index1].timeLeft = Gore.goreTime * 3;
      }
      if (Type == 16 || Type == 17)
      {
        Main.gore[index1].alpha = 100;
        Main.gore[index1].scale = 0.7f;
        Main.gore[index1].light = 1f;
      }
      if (Type >= 570 && Type <= 572)
        Main.gore[index1].velocity = Velocity;
      if (GoreID.Sets.SpecialAI[Type] == 3)
      {
        Main.gore[index1].velocity = new Vector2((float) (((double) Main.rand.NextFloat() - 0.5) * 1.0), Main.rand.NextFloat() * 6.283185f);
        Main.gore[index1].numFrames = (byte) 8;
        Main.gore[index1].frame = (byte) Main.rand.Next(8);
        Main.gore[index1].frameCounter = (byte) Main.rand.Next(8);
      }
      if (GoreID.Sets.SpecialAI[Type] == 1)
        Main.gore[index1].velocity = new Vector2((float) (((double) Main.rand.NextFloat() - 0.5) * 3.0), Main.rand.NextFloat() * 6.283185f);
      if (Type >= 411 && Type <= 430 && Main.goreLoaded[Type])
      {
        Main.gore[index1].position.X = Position.X - (float) (Main.goreTexture[Type].Width / 2) * Scale;
        Main.gore[index1].position.Y = Position.Y - (float) Main.goreTexture[Type].Height * Scale;
        Main.gore[index1].velocity.Y *= (float) Main.rand.Next(90, 150) * 0.01f;
        Main.gore[index1].velocity.X *= (float) Main.rand.Next(40, 90) * 0.01f;
        int num = Main.rand.Next(4) * 5;
        Main.gore[index1].type += num;
        Main.gore[index1].timeLeft = Main.rand.Next(Gore.goreTime / 2, Gore.goreTime * 2);
        Main.gore[index1].sticky = true;
        if (Gore.goreTime == 0)
          Main.gore[index1].timeLeft = Main.rand.Next(150, 600);
      }
      if (Type >= 907 && Type <= 909)
      {
        Main.gore[index1].sticky = true;
        Main.gore[index1].numFrames = (byte) 3;
        Main.gore[index1].frame = (byte) Main.rand.Next(3);
        Main.gore[index1].frameCounter = (byte) Main.rand.Next(5);
        Main.gore[index1].rotation = 0.0f;
      }
      if (GoreID.Sets.SpecialAI[Type] == 2)
      {
        Main.gore[index1].sticky = false;
        if (Main.goreLoaded[Type])
        {
          Main.gore[index1].alpha = 150;
          Main.gore[index1].velocity = Velocity;
          Main.gore[index1].position.X = Position.X - (float) (Main.goreTexture[Type].Width / 2) * Scale;
          Main.gore[index1].position.Y = Position.Y - (float) ((double) Main.goreTexture[Type].Height * (double) Scale / 2.0);
          Main.gore[index1].timeLeft = Main.rand.Next(Gore.goreTime / 2, Gore.goreTime + 1);
        }
      }
      return index1;
    }

    public Color GetAlpha(Color newColor)
    {
      float num1 = (float) ((int) byte.MaxValue - this.alpha) / (float) byte.MaxValue;
      int r;
      int g;
      int b;
      if (this.type == 16 || this.type == 17)
      {
        r = (int) newColor.R;
        g = (int) newColor.G;
        b = (int) newColor.B;
      }
      else
      {
        if (this.type == 716)
          return new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 200);
        if (this.type >= 570 && this.type <= 572)
        {
          byte num2 = (byte) ((int) byte.MaxValue - this.alpha);
          return new Color((int) num2, (int) num2, (int) num2, (int) num2 / 2);
        }
        if (this.type == 331)
          return new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 50);
        r = (int) ((double) newColor.R * (double) num1);
        g = (int) ((double) newColor.G * (double) num1);
        b = (int) ((double) newColor.B * (double) num1);
      }
      int a = (int) newColor.A - this.alpha;
      if (a < 0)
        a = 0;
      if (a > (int) byte.MaxValue)
        a = (int) byte.MaxValue;
      return new Color(r, g, b, a);
    }
  }
}
