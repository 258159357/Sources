﻿// Decompiled with JetBrains decompiler
// Type: Terraria.DataStructures.NPCAimedTarget
// Assembly: TerrariaServer, Version=1.3.5.0, Culture=neutral, PublicKeyToken=null
// MVID: 13381DB9-8FD8-4EBB-8CED-9CF82DC89291
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Terraria\TerrariaServer.exe

using Microsoft.Xna.Framework;
using Terraria.Enums;

namespace Terraria.DataStructures
{
  public struct NPCAimedTarget
  {
    public NPCTargetType Type;
    public Rectangle Hitbox;
    public int Width;
    public int Height;
    public Vector2 Position;
    public Vector2 Velocity;

    public bool Invalid
    {
      get
      {
        return this.Type == NPCTargetType.None;
      }
    }

    public Vector2 Center
    {
      get
      {
        return this.Position + this.Size / 2f;
      }
    }

    public Vector2 Size
    {
      get
      {
        return new Vector2((float) this.Width, (float) this.Height);
      }
    }

    public NPCAimedTarget(NPC npc)
    {
      this.Type = NPCTargetType.NPC;
      this.Hitbox = npc.Hitbox;
      this.Width = npc.width;
      this.Height = npc.height;
      this.Position = npc.position;
      this.Velocity = npc.velocity;
    }

    public NPCAimedTarget(Player player, bool ignoreTank = true)
    {
      this.Type = NPCTargetType.Player;
      this.Hitbox = player.Hitbox;
      this.Width = player.width;
      this.Height = player.height;
      this.Position = player.position;
      this.Velocity = player.velocity;
      if (ignoreTank || player.tankPet <= -1)
        return;
      Projectile projectile = Main.projectile[player.tankPet];
      this.Type = NPCTargetType.PlayerTankPet;
      this.Hitbox = projectile.Hitbox;
      this.Width = projectile.width;
      this.Height = projectile.height;
      this.Position = projectile.position;
      this.Velocity = projectile.velocity;
    }
  }
}
