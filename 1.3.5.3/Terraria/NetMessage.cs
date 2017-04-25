// Decompiled with JetBrains decompiler
// Type: Terraria.NetMessage
// Assembly: TerrariaServer, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: AA3606A2-F3DB-4481-937B-7295FB97CD3E
// Assembly location: E:\TSHOCK\TerrariaServer.exe

using Ionic.Zlib;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics.PackedVector;
using System;
using System.IO;
using Terraria.Chat;
using Terraria.DataStructures;
using Terraria.GameContent.Events;
using Terraria.GameContent.NetModules;
using Terraria.GameContent.Tile_Entities;
using Terraria.ID;
using Terraria.IO;
using Terraria.Localization;
using Terraria.Net;
using Terraria.Net.Sockets;
using Terraria.Social;

namespace Terraria
{
  public class NetMessage
  {
    public static MessageBuffer[] buffer = new MessageBuffer[257];
    private static PlayerDeathReason _currentPlayerDeathReason;

    public static void SendChatMessageToClient(NetworkText text, Color color, int playerId)
    {
      NetPacket packet = NetTextModule.SerializeServerMessage(text, color, byte.MaxValue);
      NetManager.Instance.SendToClient(packet, playerId);
    }

    public static void BroadcastChatMessage(NetworkText text, Color color, int excludedPlayer = -1)
    {
      NetPacket packet = NetTextModule.SerializeServerMessage(text, color, byte.MaxValue);
      NetManager.Instance.Broadcast(packet, excludedPlayer);
    }

    public static void SendChatMessageFromClient(ChatMessage text)
    {
      NetPacket packet = NetTextModule.SerializeClientMessage(text);
      NetManager.Instance.SendToServer(packet);
    }

    public static void SendData(int msgType, int remoteClient = -1, int ignoreClient = -1, NetworkText text = null, int number = 0, float number2 = 0.0f, float number3 = 0.0f, float number4 = 0.0f, int number5 = 0, int number6 = 0, int number7 = 0)
    {
      if (Main.netMode == 0)
        return;
      int whoAmi = 256;
      if (text == null)
        text = NetworkText.Empty;
      if (Main.netMode == 2 && remoteClient >= 0)
        whoAmi = remoteClient;
      lock (NetMessage.buffer[whoAmi])
      {
        BinaryWriter local_3 = NetMessage.buffer[whoAmi].writer;
        if (local_3 == null)
        {
          NetMessage.buffer[whoAmi].ResetWriter();
          local_3 = NetMessage.buffer[whoAmi].writer;
        }
        local_3.BaseStream.Position = 0L;
        long local_4 = local_3.BaseStream.Position;
        local_3.BaseStream.Position += 2L;
        local_3.Write((byte) msgType);
        switch (msgType)
        {
          case 1:
            local_3.Write("Terraria" + (object) 194);
            break;
          case 2:
            text.Serialize(local_3);
            if (Main.dedServ)
            {
              Console.WriteLine(Language.GetTextValue("CLI.ClientWasBooted", (object) Netplay.Clients[whoAmi].Socket.GetRemoteAddress().ToString(), (object) text));
              break;
            }
            break;
          case 3:
            local_3.Write((byte) remoteClient);
            break;
          case 4:
            Player local_6 = Main.player[number];
            local_3.Write((byte) number);
            local_3.Write((byte) local_6.skinVariant);
            local_3.Write((byte) local_6.hair);
            local_3.Write(local_6.name);
            local_3.Write(local_6.hairDye);
            BitsByte local_7 = (BitsByte) (byte) 0;
            for (int local_9 = 0; local_9 < 8; ++local_9)
              local_7[local_9] = local_6.hideVisual[local_9];
            local_3.Write((byte) local_7);
            BitsByte local_7_1 = (BitsByte) (byte) 0;
            for (int local_10 = 0; local_10 < 2; ++local_10)
              local_7_1[local_10] = local_6.hideVisual[local_10 + 8];
            local_3.Write((byte) local_7_1);
            local_3.Write((byte) local_6.hideMisc);
            local_3.WriteRGB(local_6.hairColor);
            local_3.WriteRGB(local_6.skinColor);
            local_3.WriteRGB(local_6.eyeColor);
            local_3.WriteRGB(local_6.shirtColor);
            local_3.WriteRGB(local_6.underShirtColor);
            local_3.WriteRGB(local_6.pantsColor);
            local_3.WriteRGB(local_6.shoeColor);
            BitsByte local_8 = (BitsByte) (byte) 0;
            if ((int) local_6.difficulty == 1)
              local_8[0] = true;
            else if ((int) local_6.difficulty == 2)
              local_8[1] = true;
            local_8[2] = local_6.extraAccessory;
            local_3.Write((byte) local_8);
            break;
          case 5:
            local_3.Write((byte) number);
            local_3.Write((byte) number2);
            Player local_11 = Main.player[number];
            Item local_12_1 = (double) number2 <= (double) (58 + local_11.armor.Length + local_11.dye.Length + local_11.miscEquips.Length + local_11.miscDyes.Length + local_11.bank.item.Length + local_11.bank2.item.Length + 1) ? ((double) number2 <= (double) (58 + local_11.armor.Length + local_11.dye.Length + local_11.miscEquips.Length + local_11.miscDyes.Length + local_11.bank.item.Length + local_11.bank2.item.Length) ? ((double) number2 <= (double) (58 + local_11.armor.Length + local_11.dye.Length + local_11.miscEquips.Length + local_11.miscDyes.Length + local_11.bank.item.Length) ? ((double) number2 <= (double) (58 + local_11.armor.Length + local_11.dye.Length + local_11.miscEquips.Length + local_11.miscDyes.Length) ? ((double) number2 <= (double) (58 + local_11.armor.Length + local_11.dye.Length + local_11.miscEquips.Length) ? ((double) number2 <= (double) (58 + local_11.armor.Length + local_11.dye.Length) ? ((double) number2 <= (double) (58 + local_11.armor.Length) ? ((double) number2 <= 58.0 ? local_11.inventory[(int) number2] : local_11.armor[(int) number2 - 58 - 1]) : local_11.dye[(int) number2 - 58 - local_11.armor.Length - 1]) : local_11.miscEquips[(int) number2 - 58 - (local_11.armor.Length + local_11.dye.Length) - 1]) : local_11.miscDyes[(int) number2 - 58 - (local_11.armor.Length + local_11.dye.Length + local_11.miscEquips.Length) - 1]) : local_11.bank.item[(int) number2 - 58 - (local_11.armor.Length + local_11.dye.Length + local_11.miscEquips.Length + local_11.miscDyes.Length) - 1]) : local_11.bank2.item[(int) number2 - 58 - (local_11.armor.Length + local_11.dye.Length + local_11.miscEquips.Length + local_11.miscDyes.Length + local_11.bank.item.Length) - 1]) : local_11.trashItem) : local_11.bank3.item[(int) number2 - 58 - (local_11.armor.Length + local_11.dye.Length + local_11.miscEquips.Length + local_11.miscDyes.Length + local_11.bank.item.Length + local_11.bank2.item.Length + 1) - 1];
            if (local_12_1.Name == "" || local_12_1.stack == 0 || local_12_1.type == 0)
              local_12_1.SetDefaults(0, false);
            int local_13_1 = local_12_1.stack;
            int local_14_1 = local_12_1.netID;
            if (local_13_1 < 0)
              local_13_1 = 0;
            local_3.Write((short) local_13_1);
            local_3.Write((byte) number3);
            local_3.Write((short) local_14_1);
            break;
          case 7:
            local_3.Write((int) Main.time);
            BitsByte local_15 = (BitsByte) (byte) 0;
            local_15[0] = Main.dayTime;
            local_15[1] = Main.bloodMoon;
            local_15[2] = Main.eclipse;
            local_3.Write((byte) local_15);
            local_3.Write((byte) Main.moonPhase);
            local_3.Write((short) Main.maxTilesX);
            local_3.Write((short) Main.maxTilesY);
            local_3.Write((short) Main.spawnTileX);
            local_3.Write((short) Main.spawnTileY);
            local_3.Write((short) Main.worldSurface);
            local_3.Write((short) Main.rockLayer);
            local_3.Write(Main.worldID);
            local_3.Write(Main.worldName);
            local_3.Write(Main.ActiveWorldFileData.UniqueId.ToByteArray());
            local_3.Write(Main.ActiveWorldFileData.WorldGeneratorVersion);
            local_3.Write((byte) Main.moonType);
            local_3.Write((byte) WorldGen.treeBG);
            local_3.Write((byte) WorldGen.corruptBG);
            local_3.Write((byte) WorldGen.jungleBG);
            local_3.Write((byte) WorldGen.snowBG);
            local_3.Write((byte) WorldGen.hallowBG);
            local_3.Write((byte) WorldGen.crimsonBG);
            local_3.Write((byte) WorldGen.desertBG);
            local_3.Write((byte) WorldGen.oceanBG);
            local_3.Write((byte) Main.iceBackStyle);
            local_3.Write((byte) Main.jungleBackStyle);
            local_3.Write((byte) Main.hellBackStyle);
            local_3.Write(Main.windSpeedSet);
            local_3.Write((byte) Main.numClouds);
            for (int local_21 = 0; local_21 < 3; ++local_21)
              local_3.Write(Main.treeX[local_21]);
            for (int local_22 = 0; local_22 < 4; ++local_22)
              local_3.Write((byte) Main.treeStyle[local_22]);
            for (int local_23 = 0; local_23 < 3; ++local_23)
              local_3.Write(Main.caveBackX[local_23]);
            for (int local_24 = 0; local_24 < 4; ++local_24)
              local_3.Write((byte) Main.caveBackStyle[local_24]);
            if (!Main.raining)
              Main.maxRaining = 0.0f;
            local_3.Write(Main.maxRaining);
            BitsByte local_16 = (BitsByte) (byte) 0;
            local_16[0] = WorldGen.shadowOrbSmashed;
            local_16[1] = NPC.downedBoss1;
            local_16[2] = NPC.downedBoss2;
            local_16[3] = NPC.downedBoss3;
            local_16[4] = Main.hardMode;
            local_16[5] = NPC.downedClown;
            local_16[7] = NPC.downedPlantBoss;
            local_3.Write((byte) local_16);
            BitsByte local_17 = (BitsByte) (byte) 0;
            local_17[0] = NPC.downedMechBoss1;
            local_17[1] = NPC.downedMechBoss2;
            local_17[2] = NPC.downedMechBoss3;
            local_17[3] = NPC.downedMechBossAny;
            local_17[4] = (double) Main.cloudBGActive >= 1.0;
            local_17[5] = WorldGen.crimson;
            local_17[6] = Main.pumpkinMoon;
            local_17[7] = Main.snowMoon;
            local_3.Write((byte) local_17);
            BitsByte local_18 = (BitsByte) (byte) 0;
            local_18[0] = Main.expertMode;
            local_18[1] = Main.fastForwardTime;
            local_18[2] = Main.slimeRain;
            local_18[3] = NPC.downedSlimeKing;
            local_18[4] = NPC.downedQueenBee;
            local_18[5] = NPC.downedFishron;
            local_18[6] = NPC.downedMartians;
            local_18[7] = NPC.downedAncientCultist;
            local_3.Write((byte) local_18);
            BitsByte local_19 = (BitsByte) (byte) 0;
            local_19[0] = NPC.downedMoonlord;
            local_19[1] = NPC.downedHalloweenKing;
            local_19[2] = NPC.downedHalloweenTree;
            local_19[3] = NPC.downedChristmasIceQueen;
            local_19[4] = NPC.downedChristmasSantank;
            local_19[5] = NPC.downedChristmasTree;
            local_19[6] = NPC.downedGolemBoss;
            local_19[7] = BirthdayParty.PartyIsUp;
            local_3.Write((byte) local_19);
            BitsByte local_20 = (BitsByte) (byte) 0;
            local_20[0] = NPC.downedPirates;
            local_20[1] = NPC.downedFrost;
            local_20[2] = NPC.downedGoblins;
            local_20[3] = Sandstorm.Happening;
            local_20[4] = DD2Event.Ongoing;
            local_20[5] = DD2Event.DownedInvasionT1;
            local_20[6] = DD2Event.DownedInvasionT2;
            local_20[7] = DD2Event.DownedInvasionT3;
            local_3.Write((byte) local_20);
            local_3.Write((sbyte) Main.invasionType);
            if (SocialAPI.Network != null)
              local_3.Write(SocialAPI.Network.GetLobbyId());
            else
              local_3.Write(0UL);
            local_3.Write(Sandstorm.IntendedSeverity);
            break;
          case 8:
            local_3.Write(number);
            local_3.Write((int) number2);
            break;
          case 9:
            local_3.Write(number);
            text.Serialize(local_3);
            break;
          case 10:
            int local_25 = NetMessage.CompressTileBlock(number, (int) number2, (short) number3, (short) number4, NetMessage.buffer[whoAmi].writeBuffer, (int) local_3.BaseStream.Position);
            local_3.BaseStream.Position += (long) local_25;
            break;
          case 11:
            local_3.Write((short) number);
            local_3.Write((short) number2);
            local_3.Write((short) number3);
            local_3.Write((short) number4);
            break;
          case 12:
            local_3.Write((byte) number);
            local_3.Write((short) Main.player[number].SpawnX);
            local_3.Write((short) Main.player[number].SpawnY);
            break;
          case 13:
            Player local_26 = Main.player[number];
            local_3.Write((byte) number);
            BitsByte local_27 = (BitsByte) (byte) 0;
            local_27[0] = local_26.controlUp;
            local_27[1] = local_26.controlDown;
            local_27[2] = local_26.controlLeft;
            local_27[3] = local_26.controlRight;
            local_27[4] = local_26.controlJump;
            local_27[5] = local_26.controlUseItem;
            local_27[6] = local_26.direction == 1;
            local_3.Write((byte) local_27);
            BitsByte local_28 = (BitsByte) (byte) 0;
            local_28[0] = local_26.pulley;
            local_28[1] = local_26.pulley && (int) local_26.pulleyDir == 2;
            local_28[2] = local_26.velocity != Vector2.Zero;
            local_28[3] = local_26.vortexStealthActive;
            local_28[4] = (double) local_26.gravDir == 1.0;
            local_28[5] = local_26.shieldRaised;
            local_3.Write((byte) local_28);
            local_3.Write((byte) local_26.selectedItem);
            local_3.WriteVector2(local_26.position);
            if (local_28[2])
            {
              local_3.WriteVector2(local_26.velocity);
              break;
            }
            break;
          case 14:
            local_3.Write((byte) number);
            local_3.Write((byte) number2);
            break;
          case 16:
            local_3.Write((byte) number);
            local_3.Write((short) Main.player[number].statLife);
            local_3.Write((short) Main.player[number].statLifeMax);
            break;
          case 17:
            local_3.Write((byte) number);
            local_3.Write((short) number2);
            local_3.Write((short) number3);
            local_3.Write((short) number4);
            local_3.Write((byte) number5);
            break;
          case 18:
            local_3.Write(Main.dayTime ? (byte) 1 : (byte) 0);
            local_3.Write((int) Main.time);
            local_3.Write(Main.sunModY);
            local_3.Write(Main.moonModY);
            break;
          case 19:
            local_3.Write((byte) number);
            local_3.Write((short) number2);
            local_3.Write((short) number3);
            local_3.Write((double) number4 == 1.0 ? (byte) 1 : (byte) 0);
            break;
          case 20:
            int local_29 = number;
            int local_30 = (int) number2;
            int local_31 = (int) number3;
            if (local_29 < 0)
              local_29 = 0;
            if (local_30 < local_29)
              local_30 = local_29;
            if (local_30 >= Main.maxTilesX + local_29)
              local_30 = Main.maxTilesX - local_29 - 1;
            if (local_31 < local_29)
              local_31 = local_29;
            if (local_31 >= Main.maxTilesY + local_29)
              local_31 = Main.maxTilesY - local_29 - 1;
            if (number5 == 0)
            {
              local_3.Write((ushort) (local_29 & (int) short.MaxValue));
            }
            else
            {
              local_3.Write((ushort) (local_29 & (int) short.MaxValue | 32768));
              local_3.Write((byte) number5);
            }
            local_3.Write((short) local_30);
            local_3.Write((short) local_31);
            for (int local_32 = local_30; local_32 < local_30 + local_29; ++local_32)
            {
              for (int local_33 = local_31; local_33 < local_31 + local_29; ++local_33)
              {
                BitsByte local_34 = (BitsByte) (byte) 0;
                BitsByte local_35 = (BitsByte) (byte) 0;
                byte local_36 = 0;
                byte local_37 = 0;
                Tile local_38 = Main.tile[local_32, local_33];
                local_34[0] = local_38.active();
                local_34[2] = (int) local_38.wall > 0;
                local_34[3] = (int) local_38.liquid > 0 && Main.netMode == 2;
                local_34[4] = local_38.wire();
                local_34[5] = local_38.halfBrick();
                local_34[6] = local_38.actuator();
                local_34[7] = local_38.inActive();
                local_35[0] = local_38.wire2();
                local_35[1] = local_38.wire3();
                if (local_38.active() && (int) local_38.color() > 0)
                {
                  local_35[2] = true;
                  local_36 = local_38.color();
                }
                if ((int) local_38.wall > 0 && (int) local_38.wallColor() > 0)
                {
                  local_35[3] = true;
                  local_37 = local_38.wallColor();
                }
                local_35 = (BitsByte) ((byte) ((uint) (byte) local_35 + (uint) (byte) ((uint) local_38.slope() << 4)));
                local_35[7] = local_38.wire4();
                local_3.Write((byte) local_34);
                local_3.Write((byte) local_35);
                if ((int) local_36 > 0)
                  local_3.Write(local_36);
                if ((int) local_37 > 0)
                  local_3.Write(local_37);
                if (local_38.active())
                {
                  local_3.Write(local_38.type);
                  if (Main.tileFrameImportant[(int) local_38.type])
                  {
                    local_3.Write(local_38.frameX);
                    local_3.Write(local_38.frameY);
                  }
                }
                if ((int) local_38.wall > 0)
                  local_3.Write(local_38.wall);
                if ((int) local_38.liquid > 0 && Main.netMode == 2)
                {
                  local_3.Write(local_38.liquid);
                  local_3.Write(local_38.liquidType());
                }
              }
            }
            break;
          case 21:
          case 90:
            Item local_39 = Main.item[number];
            local_3.Write((short) number);
            local_3.WriteVector2(local_39.position);
            local_3.WriteVector2(local_39.velocity);
            local_3.Write((short) local_39.stack);
            local_3.Write(local_39.prefix);
            local_3.Write((byte) number2);
            short local_40 = 0;
            if (local_39.active && local_39.stack > 0)
              local_40 = (short) local_39.netID;
            local_3.Write(local_40);
            break;
          case 22:
            local_3.Write((short) number);
            local_3.Write((byte) Main.item[number].owner);
            break;
          case 23:
            NPC local_41 = Main.npc[number];
            local_3.Write((short) number);
            local_3.WriteVector2(local_41.position);
            local_3.WriteVector2(local_41.velocity);
            local_3.Write((ushort) local_41.target);
            int local_42 = local_41.life;
            if (!local_41.active)
              local_42 = 0;
            if (!local_41.active || local_41.life <= 0)
              local_41.netSkip = 0;
            short local_43 = (short) local_41.netID;
            bool[] local_44 = new bool[4];
            BitsByte local_45 = (BitsByte) (byte) 0;
            local_45[0] = local_41.direction > 0;
            local_45[1] = local_41.directionY > 0;
            local_45[2] = local_44[0] = (double) local_41.ai[0] != 0.0;
            local_45[3] = local_44[1] = (double) local_41.ai[1] != 0.0;
            local_45[4] = local_44[2] = (double) local_41.ai[2] != 0.0;
            local_45[5] = local_44[3] = (double) local_41.ai[3] != 0.0;
            local_45[6] = local_41.spriteDirection > 0;
            local_45[7] = local_42 == local_41.lifeMax;
            local_3.Write((byte) local_45);
            for (int local_47 = 0; local_47 < NPC.maxAI; ++local_47)
            {
              if (local_44[local_47])
                local_3.Write(local_41.ai[local_47]);
            }
            local_3.Write(local_43);
            if (!local_45[7])
            {
              byte local_48 = Main.npcLifeBytes[local_41.netID];
              local_3.Write(local_48);
              if ((int) local_48 == 2)
                local_3.Write((short) local_42);
              else if ((int) local_48 == 4)
                local_3.Write(local_42);
              else
                local_3.Write((sbyte) local_42);
            }
            if (local_41.type >= 0 && local_41.type < 580 && Main.npcCatchable[local_41.type])
            {
              local_3.Write((byte) local_41.releaseOwner);
              break;
            }
            break;
          case 24:
            local_3.Write((short) number);
            local_3.Write((byte) number2);
            break;
          case 27:
            Projectile local_49 = Main.projectile[number];
            local_3.Write((short) local_49.identity);
            local_3.WriteVector2(local_49.position);
            local_3.WriteVector2(local_49.velocity);
            local_3.Write(local_49.knockBack);
            local_3.Write((short) local_49.damage);
            local_3.Write((byte) local_49.owner);
            local_3.Write((short) local_49.type);
            BitsByte local_50 = (BitsByte) (byte) 0;
            for (int local_51 = 0; local_51 < Projectile.maxAI; ++local_51)
            {
              if ((double) local_49.ai[local_51] != 0.0)
                local_50[local_51] = true;
            }
            if (local_49.type > 0 && local_49.type < 714 && ProjectileID.Sets.NeedsUUID[local_49.type])
              local_50[Projectile.maxAI] = true;
            local_3.Write((byte) local_50);
            for (int local_52 = 0; local_52 < Projectile.maxAI; ++local_52)
            {
              if (local_50[local_52])
                local_3.Write(local_49.ai[local_52]);
            }
            if (local_50[Projectile.maxAI])
            {
              local_3.Write((short) local_49.projUUID);
              break;
            }
            break;
          case 28:
            local_3.Write((short) number);
            local_3.Write((short) number2);
            local_3.Write(number3);
            local_3.Write((byte) ((double) number4 + 1.0));
            local_3.Write((byte) number5);
            break;
          case 29:
            local_3.Write((short) number);
            local_3.Write((byte) number2);
            break;
          case 30:
            local_3.Write((byte) number);
            local_3.Write(Main.player[number].hostile);
            break;
          case 31:
            local_3.Write((short) number);
            local_3.Write((short) number2);
            break;
          case 32:
            Item local_53 = Main.chest[number].item[(int) (byte) number2];
            local_3.Write((short) number);
            local_3.Write((byte) number2);
            short local_54 = (short) local_53.netID;
            if (local_53.Name == null)
              local_54 = (short) 0;
            local_3.Write((short) local_53.stack);
            local_3.Write(local_53.prefix);
            local_3.Write(local_54);
            break;
          case 33:
            int local_55 = 0;
            int local_56 = 0;
            int local_57 = 0;
            string local_58 = (string) null;
            if (number > -1)
            {
              local_55 = Main.chest[number].x;
              local_56 = Main.chest[number].y;
            }
            if ((double) number2 == 1.0)
            {
              string local_59 = text.ToString();
              local_57 = (int) (byte) local_59.Length;
              if (local_57 == 0 || local_57 > 20)
                local_57 = (int) byte.MaxValue;
              else
                local_58 = local_59;
            }
            local_3.Write((short) number);
            local_3.Write((short) local_55);
            local_3.Write((short) local_56);
            local_3.Write((byte) local_57);
            if (local_58 != null)
            {
              local_3.Write(local_58);
              break;
            }
            break;
          case 34:
            local_3.Write((byte) number);
            local_3.Write((short) number2);
            local_3.Write((short) number3);
            local_3.Write((short) number4);
            if (Main.netMode == 2)
            {
              Netplay.GetSectionX((int) number2);
              Netplay.GetSectionY((int) number3);
              local_3.Write((short) number5);
              break;
            }
            local_3.Write((short) 0);
            break;
          case 35:
          case 66:
            local_3.Write((byte) number);
            local_3.Write((short) number2);
            break;
          case 36:
            Player local_60 = Main.player[number];
            local_3.Write((byte) number);
            local_3.Write((byte) local_60.zone1);
            local_3.Write((byte) local_60.zone2);
            local_3.Write((byte) local_60.zone3);
            local_3.Write((byte) local_60.zone4);
            break;
          case 38:
            local_3.Write(Netplay.ServerPassword);
            break;
          case 39:
            local_3.Write((short) number);
            break;
          case 40:
            local_3.Write((byte) number);
            local_3.Write((short) Main.player[number].talkNPC);
            break;
          case 41:
            local_3.Write((byte) number);
            local_3.Write(Main.player[number].itemRotation);
            local_3.Write((short) Main.player[number].itemAnimation);
            break;
          case 42:
            local_3.Write((byte) number);
            local_3.Write((short) Main.player[number].statMana);
            local_3.Write((short) Main.player[number].statManaMax);
            break;
          case 43:
            local_3.Write((byte) number);
            local_3.Write((short) number2);
            break;
          case 45:
            local_3.Write((byte) number);
            local_3.Write((byte) Main.player[number].team);
            break;
          case 46:
            local_3.Write((short) number);
            local_3.Write((short) number2);
            break;
          case 47:
            local_3.Write((short) number);
            local_3.Write((short) Main.sign[number].x);
            local_3.Write((short) Main.sign[number].y);
            local_3.Write(Main.sign[number].text);
            local_3.Write((byte) number2);
            break;
          case 48:
            Tile local_61 = Main.tile[number, (int) number2];
            local_3.Write((short) number);
            local_3.Write((short) number2);
            local_3.Write(local_61.liquid);
            local_3.Write(local_61.liquidType());
            break;
          case 50:
            local_3.Write((byte) number);
            for (int local_62 = 0; local_62 < 22; ++local_62)
              local_3.Write((byte) Main.player[number].buffType[local_62]);
            break;
          case 51:
            local_3.Write((byte) number);
            local_3.Write((byte) number2);
            break;
          case 52:
            local_3.Write((byte) number2);
            local_3.Write((short) number3);
            local_3.Write((short) number4);
            break;
          case 53:
            local_3.Write((short) number);
            local_3.Write((byte) number2);
            local_3.Write((short) number3);
            break;
          case 54:
            local_3.Write((short) number);
            for (int local_63 = 0; local_63 < 5; ++local_63)
            {
              local_3.Write((byte) Main.npc[number].buffType[local_63]);
              local_3.Write((short) Main.npc[number].buffTime[local_63]);
            }
            break;
          case 55:
            local_3.Write((byte) number);
            local_3.Write((byte) number2);
            local_3.Write((int) number3);
            break;
          case 56:
            local_3.Write((short) number);
            if (Main.netMode == 2)
            {
              string local_64 = Main.npc[number].GivenName;
              local_3.Write(local_64);
              break;
            }
            break;
          case 57:
            local_3.Write(WorldGen.tGood);
            local_3.Write(WorldGen.tEvil);
            local_3.Write(WorldGen.tBlood);
            break;
          case 58:
            local_3.Write((byte) number);
            local_3.Write(number2);
            break;
          case 59:
            local_3.Write((short) number);
            local_3.Write((short) number2);
            break;
          case 60:
            local_3.Write((short) number);
            local_3.Write((short) number2);
            local_3.Write((short) number3);
            local_3.Write((byte) number4);
            break;
          case 61:
            local_3.Write((short) number);
            local_3.Write((short) number2);
            break;
          case 62:
            local_3.Write((byte) number);
            local_3.Write((byte) number2);
            break;
          case 63:
          case 64:
            local_3.Write((short) number);
            local_3.Write((short) number2);
            local_3.Write((byte) number3);
            break;
          case 65:
            BitsByte local_65 = (BitsByte) (byte) 0;
            local_65[0] = (number & 1) == 1;
            local_65[1] = (number & 2) == 2;
            local_65[2] = (number5 & 1) == 1;
            local_65[3] = (number5 & 2) == 2;
            local_3.Write((byte) local_65);
            local_3.Write((short) number2);
            local_3.Write(number3);
            local_3.Write(number4);
            break;
          case 68:
            local_3.Write(Main.clientUUID);
            break;
          case 69:
            Netplay.GetSectionX((int) number2);
            Netplay.GetSectionY((int) number3);
            local_3.Write((short) number);
            local_3.Write((short) number2);
            local_3.Write((short) number3);
            local_3.Write(Main.chest[(int) (short) number].name);
            break;
          case 70:
            local_3.Write((short) number);
            local_3.Write((byte) number2);
            break;
          case 71:
            local_3.Write(number);
            local_3.Write((int) number2);
            local_3.Write((short) number3);
            local_3.Write((byte) number4);
            break;
          case 72:
            for (int local_66 = 0; local_66 < 40; ++local_66)
              local_3.Write((short) Main.travelShop[local_66]);
            break;
          case 74:
            local_3.Write((byte) Main.anglerQuest);
            bool local_67 = Main.anglerWhoFinishedToday.Contains(text.ToString());
            local_3.Write(local_67);
            break;
          case 76:
            local_3.Write((byte) number);
            local_3.Write(Main.player[number].anglerQuestsFinished);
            break;
          case 77:
            if (Main.netMode != 2)
              return;
            local_3.Write((short) number);
            local_3.Write((ushort) number2);
            local_3.Write((short) number3);
            local_3.Write((short) number4);
            break;
          case 78:
            local_3.Write(number);
            local_3.Write((int) number2);
            local_3.Write((sbyte) number3);
            local_3.Write((sbyte) number4);
            break;
          case 79:
            local_3.Write((short) number);
            local_3.Write((short) number2);
            local_3.Write((short) number3);
            local_3.Write((short) number4);
            local_3.Write((byte) number5);
            local_3.Write((sbyte) number6);
            local_3.Write(number7 == 1);
            break;
          case 80:
            local_3.Write((byte) number);
            local_3.Write((short) number2);
            break;
          case 81:
            local_3.Write(number2);
            local_3.Write(number3);
            local_3.WriteRGB(new Color()
            {
              PackedValue = (uint) number
            });
            local_3.Write((int) number4);
            break;
          case 83:
            int local_70 = number;
            if (local_70 < 0 && local_70 >= 267)
              local_70 = 1;
            int local_71 = NPC.killCount[local_70];
            local_3.Write((short) local_70);
            local_3.Write(local_71);
            break;
          case 84:
            byte local_72 = (byte) number;
            float local_73 = Main.player[(int) local_72].stealth;
            local_3.Write(local_72);
            local_3.Write(local_73);
            break;
          case 85:
            byte local_74 = (byte) number;
            local_3.Write(local_74);
            break;
          case 86:
            local_3.Write(number);
            bool local_75 = TileEntity.ByID.ContainsKey(number);
            local_3.Write(local_75);
            if (local_75)
            {
              TileEntity.Write(local_3, TileEntity.ByID[number], true);
              break;
            }
            break;
          case 87:
            local_3.Write((short) number);
            local_3.Write((short) number2);
            local_3.Write((byte) number3);
            break;
          case 88:
            BitsByte local_76 = (BitsByte) ((byte) number2);
            BitsByte local_77 = (BitsByte) ((byte) number3);
            local_3.Write((short) number);
            local_3.Write((byte) local_76);
            Item local_78 = Main.item[number];
            if (local_76[0])
              local_3.Write(local_78.color.PackedValue);
            if (local_76[1])
              local_3.Write((ushort) local_78.damage);
            if (local_76[2])
              local_3.Write(local_78.knockBack);
            if (local_76[3])
              local_3.Write((ushort) local_78.useAnimation);
            if (local_76[4])
              local_3.Write((ushort) local_78.useTime);
            if (local_76[5])
              local_3.Write((short) local_78.shoot);
            if (local_76[6])
              local_3.Write(local_78.shootSpeed);
            if (local_76[7])
            {
              local_3.Write((byte) local_77);
              if (local_77[0])
                local_3.Write((ushort) local_78.width);
              if (local_77[1])
                local_3.Write((ushort) local_78.height);
              if (local_77[2])
                local_3.Write(local_78.scale);
              if (local_77[3])
                local_3.Write((short) local_78.ammo);
              if (local_77[4])
                local_3.Write((short) local_78.useAmmo);
              if (local_77[5])
              {
                local_3.Write(local_78.notAmmo);
                break;
              }
              break;
            }
            break;
          case 89:
            local_3.Write((short) number);
            local_3.Write((short) number2);
            Item local_79 = Main.player[(int) number4].inventory[(int) number3];
            local_3.Write((short) local_79.netID);
            local_3.Write(local_79.prefix);
            local_3.Write((short) local_79.stack);
            break;
          case 91:
            local_3.Write(number);
            local_3.Write((byte) number2);
            if ((double) number2 != (double) byte.MaxValue)
            {
              local_3.Write((ushort) number3);
              local_3.Write((byte) number4);
              local_3.Write((byte) number5);
              if (number5 < 0)
              {
                local_3.Write((short) number6);
                break;
              }
              break;
            }
            break;
          case 92:
            local_3.Write((short) number);
            local_3.Write(number2);
            local_3.Write(number3);
            local_3.Write(number4);
            break;
          case 95:
            local_3.Write((ushort) number);
            break;
          case 96:
            local_3.Write((byte) number);
            Player local_80 = Main.player[number];
            local_3.Write((short) number4);
            local_3.Write(number2);
            local_3.Write(number3);
            local_3.WriteVector2(local_80.velocity);
            break;
          case 97:
            local_3.Write((short) number);
            break;
          case 98:
            local_3.Write((short) number);
            break;
          case 99:
            local_3.Write((byte) number);
            local_3.WriteVector2(Main.player[number].MinionRestTargetPoint);
            break;
          case 100:
            local_3.Write((ushort) number);
            NPC local_81 = Main.npc[number];
            local_3.Write((short) number4);
            local_3.Write(number2);
            local_3.Write(number3);
            local_3.WriteVector2(local_81.velocity);
            break;
          case 101:
            local_3.Write((ushort) NPC.ShieldStrengthTowerSolar);
            local_3.Write((ushort) NPC.ShieldStrengthTowerVortex);
            local_3.Write((ushort) NPC.ShieldStrengthTowerNebula);
            local_3.Write((ushort) NPC.ShieldStrengthTowerStardust);
            break;
          case 102:
            local_3.Write((byte) number);
            local_3.Write((byte) number2);
            local_3.Write(number3);
            local_3.Write(number4);
            break;
          case 103:
            local_3.Write(NPC.MoonLordCountdown);
            break;
          case 104:
            local_3.Write((byte) number);
            local_3.Write((short) number2);
            local_3.Write((int) (short) number3 < 0 ? 0.0f : number3);
            local_3.Write((byte) number4);
            local_3.Write(number5);
            local_3.Write((byte) number6);
            break;
          case 105:
            local_3.Write((short) number);
            local_3.Write((short) number2);
            local_3.Write((double) number3 == 1.0);
            break;
          case 106:
            HalfVector2 local_82 = new HalfVector2((float) number, number2);
            local_3.Write(local_82.PackedValue);
            break;
          case 107:
            local_3.Write((byte) number2);
            local_3.Write((byte) number3);
            local_3.Write((byte) number4);
            text.Serialize(local_3);
            local_3.Write((short) number5);
            break;
          case 108:
            local_3.Write((short) number);
            local_3.Write(number2);
            local_3.Write((short) number3);
            local_3.Write((short) number4);
            local_3.Write((short) number5);
            local_3.Write((short) number6);
            local_3.Write((byte) number7);
            break;
          case 109:
            local_3.Write((short) number);
            local_3.Write((short) number2);
            local_3.Write((short) number3);
            local_3.Write((short) number4);
            local_3.Write((byte) number5);
            break;
          case 110:
            local_3.Write((short) number);
            local_3.Write((short) number2);
            local_3.Write((byte) number3);
            break;
          case 112:
            local_3.Write((byte) number);
            local_3.Write((short) number2);
            local_3.Write((short) number3);
            local_3.Write((byte) number4);
            local_3.Write((short) number5);
            break;
          case 113:
            local_3.Write((short) number);
            local_3.Write((short) number2);
            break;
          case 115:
            local_3.Write((byte) number);
            local_3.Write((short) Main.player[number].MinionAttackTargetNPC);
            break;
          case 116:
            local_3.Write(number);
            break;
          case 117:
            local_3.Write((byte) number);
            NetMessage._currentPlayerDeathReason.WriteSelfTo(local_3);
            local_3.Write((short) number2);
            local_3.Write((byte) ((double) number3 + 1.0));
            local_3.Write((byte) number4);
            local_3.Write((sbyte) number5);
            break;
          case 118:
            local_3.Write((byte) number);
            NetMessage._currentPlayerDeathReason.WriteSelfTo(local_3);
            local_3.Write((short) number2);
            local_3.Write((byte) ((double) number3 + 1.0));
            local_3.Write((byte) number4);
            break;
          case 119:
            local_3.Write(number2);
            local_3.Write(number3);
            local_3.WriteRGB(new Color()
            {
              PackedValue = (uint) number
            });
            text.Serialize(local_3);
            break;
        }
        int local_5 = (int) local_3.BaseStream.Position;
        local_3.BaseStream.Position = local_4;
        local_3.Write((short) local_5);
        local_3.BaseStream.Position = (long) local_5;
        if (Main.netMode == 1)
        {
          if (Netplay.Connection.Socket.IsConnected())
          {
            try
            {
              ++NetMessage.buffer[whoAmi].spamCount;
              ++Main.txMsg;
              Main.txData += local_5;
              ++Main.txMsgType[msgType];
              Main.txDataType[msgType] += local_5;
              Netplay.Connection.Socket.AsyncSend(NetMessage.buffer[whoAmi].writeBuffer, 0, local_5, new SocketSendCallback(Netplay.Connection.ClientWriteCallBack), (object) null);
            }
            catch
            {
            }
          }
        }
        else if (remoteClient == -1)
        {
          if (msgType == 34 || msgType == 69)
          {
            for (int local_83 = 0; local_83 < 256; ++local_83)
            {
              if (local_83 != ignoreClient && NetMessage.buffer[local_83].broadcast)
              {
                if (Netplay.Clients[local_83].IsConnected())
                {
                  try
                  {
                    ++NetMessage.buffer[local_83].spamCount;
                    ++Main.txMsg;
                    Main.txData += local_5;
                    ++Main.txMsgType[msgType];
                    Main.txDataType[msgType] += local_5;
                    Netplay.Clients[local_83].Socket.AsyncSend(NetMessage.buffer[whoAmi].writeBuffer, 0, local_5, new SocketSendCallback(Netplay.Clients[local_83].ServerWriteCallBack), (object) null);
                  }
                  catch
                  {
                  }
                }
              }
            }
          }
          else if (msgType == 20)
          {
            for (int local_84 = 0; local_84 < 256; ++local_84)
            {
              if (local_84 != ignoreClient && NetMessage.buffer[local_84].broadcast && Netplay.Clients[local_84].IsConnected())
              {
                if (Netplay.Clients[local_84].SectionRange(number, (int) number2, (int) number3))
                {
                  try
                  {
                    ++NetMessage.buffer[local_84].spamCount;
                    ++Main.txMsg;
                    Main.txData += local_5;
                    ++Main.txMsgType[msgType];
                    Main.txDataType[msgType] += local_5;
                    Netplay.Clients[local_84].Socket.AsyncSend(NetMessage.buffer[whoAmi].writeBuffer, 0, local_5, new SocketSendCallback(Netplay.Clients[local_84].ServerWriteCallBack), (object) null);
                  }
                  catch
                  {
                  }
                }
              }
            }
          }
          else if (msgType == 23)
          {
            NPC local_85 = Main.npc[number];
            for (int local_86 = 0; local_86 < 256; ++local_86)
            {
              if (local_86 != ignoreClient && NetMessage.buffer[local_86].broadcast && Netplay.Clients[local_86].IsConnected())
              {
                bool local_87 = false;
                if (local_85.boss || local_85.netAlways || (local_85.townNPC || !local_85.active))
                  local_87 = true;
                else if (local_85.netSkip <= 0)
                {
                  Rectangle local_88 = Main.player[local_86].getRect();
                  Rectangle local_89 = local_85.getRect();
                  local_89.X -= 2500;
                  local_89.Y -= 2500;
                  local_89.Width += 5000;
                  local_89.Height += 5000;
                  if (local_88.Intersects(local_89))
                    local_87 = true;
                }
                else
                  local_87 = true;
                if (local_87)
                {
                  try
                  {
                    ++NetMessage.buffer[local_86].spamCount;
                    ++Main.txMsg;
                    Main.txData += local_5;
                    ++Main.txMsgType[msgType];
                    Main.txDataType[msgType] += local_5;
                    Netplay.Clients[local_86].Socket.AsyncSend(NetMessage.buffer[whoAmi].writeBuffer, 0, local_5, new SocketSendCallback(Netplay.Clients[local_86].ServerWriteCallBack), (object) null);
                  }
                  catch
                  {
                  }
                }
              }
            }
            ++local_85.netSkip;
            if (local_85.netSkip > 4)
              local_85.netSkip = 0;
          }
          else if (msgType == 28)
          {
            NPC local_90 = Main.npc[number];
            for (int local_91 = 0; local_91 < 256; ++local_91)
            {
              if (local_91 != ignoreClient && NetMessage.buffer[local_91].broadcast && Netplay.Clients[local_91].IsConnected())
              {
                bool local_92 = false;
                if (local_90.life <= 0)
                {
                  local_92 = true;
                }
                else
                {
                  Rectangle local_93 = Main.player[local_91].getRect();
                  Rectangle local_94 = local_90.getRect();
                  local_94.X -= 3000;
                  local_94.Y -= 3000;
                  local_94.Width += 6000;
                  local_94.Height += 6000;
                  if (local_93.Intersects(local_94))
                    local_92 = true;
                }
                if (local_92)
                {
                  try
                  {
                    ++NetMessage.buffer[local_91].spamCount;
                    ++Main.txMsg;
                    Main.txData += local_5;
                    ++Main.txMsgType[msgType];
                    Main.txDataType[msgType] += local_5;
                    Netplay.Clients[local_91].Socket.AsyncSend(NetMessage.buffer[whoAmi].writeBuffer, 0, local_5, new SocketSendCallback(Netplay.Clients[local_91].ServerWriteCallBack), (object) null);
                  }
                  catch
                  {
                  }
                }
              }
            }
          }
          else if (msgType == 13)
          {
            for (int local_95 = 0; local_95 < 256; ++local_95)
            {
              if (local_95 != ignoreClient && NetMessage.buffer[local_95].broadcast)
              {
                if (Netplay.Clients[local_95].IsConnected())
                {
                  try
                  {
                    ++NetMessage.buffer[local_95].spamCount;
                    ++Main.txMsg;
                    Main.txData += local_5;
                    ++Main.txMsgType[msgType];
                    Main.txDataType[msgType] += local_5;
                    Netplay.Clients[local_95].Socket.AsyncSend(NetMessage.buffer[whoAmi].writeBuffer, 0, local_5, new SocketSendCallback(Netplay.Clients[local_95].ServerWriteCallBack), (object) null);
                  }
                  catch
                  {
                  }
                }
              }
            }
            ++Main.player[number].netSkip;
            if (Main.player[number].netSkip > 2)
              Main.player[number].netSkip = 0;
          }
          else if (msgType == 27)
          {
            Projectile local_96 = Main.projectile[number];
            for (int local_97 = 0; local_97 < 256; ++local_97)
            {
              if (local_97 != ignoreClient && NetMessage.buffer[local_97].broadcast && Netplay.Clients[local_97].IsConnected())
              {
                bool local_98 = false;
                if (local_96.type == 12 || Main.projPet[local_96.type] || (local_96.aiStyle == 11 || local_96.netImportant))
                {
                  local_98 = true;
                }
                else
                {
                  Rectangle local_99 = Main.player[local_97].getRect();
                  Rectangle local_100 = local_96.getRect();
                  local_100.X -= 5000;
                  local_100.Y -= 5000;
                  local_100.Width += 10000;
                  local_100.Height += 10000;
                  if (local_99.Intersects(local_100))
                    local_98 = true;
                }
                if (local_98)
                {
                  try
                  {
                    ++NetMessage.buffer[local_97].spamCount;
                    ++Main.txMsg;
                    Main.txData += local_5;
                    ++Main.txMsgType[msgType];
                    Main.txDataType[msgType] += local_5;
                    Netplay.Clients[local_97].Socket.AsyncSend(NetMessage.buffer[whoAmi].writeBuffer, 0, local_5, new SocketSendCallback(Netplay.Clients[local_97].ServerWriteCallBack), (object) null);
                  }
                  catch
                  {
                  }
                }
              }
            }
          }
          else
          {
            for (int local_101 = 0; local_101 < 256; ++local_101)
            {
              if (local_101 != ignoreClient && (NetMessage.buffer[local_101].broadcast || Netplay.Clients[local_101].State >= 3 && msgType == 10))
              {
                if (Netplay.Clients[local_101].IsConnected())
                {
                  try
                  {
                    ++NetMessage.buffer[local_101].spamCount;
                    ++Main.txMsg;
                    Main.txData += local_5;
                    ++Main.txMsgType[msgType];
                    Main.txDataType[msgType] += local_5;
                    Netplay.Clients[local_101].Socket.AsyncSend(NetMessage.buffer[whoAmi].writeBuffer, 0, local_5, new SocketSendCallback(Netplay.Clients[local_101].ServerWriteCallBack), (object) null);
                  }
                  catch
                  {
                  }
                }
              }
            }
          }
        }
        else if (Netplay.Clients[remoteClient].IsConnected())
        {
          try
          {
            ++NetMessage.buffer[remoteClient].spamCount;
            ++Main.txMsg;
            Main.txData += local_5;
            ++Main.txMsgType[msgType];
            Main.txDataType[msgType] += local_5;
            Netplay.Clients[remoteClient].Socket.AsyncSend(NetMessage.buffer[whoAmi].writeBuffer, 0, local_5, new SocketSendCallback(Netplay.Clients[remoteClient].ServerWriteCallBack), (object) null);
          }
          catch
          {
          }
        }
        if (Main.verboseNetplay)
        {
          int local_102 = 0;
          while (local_102 < local_5)
            ++local_102;
          for (int local_103 = 0; local_103 < local_5; ++local_103)
          {
            int temp_102 = (int) NetMessage.buffer[whoAmi].writeBuffer[local_103];
          }
        }
        NetMessage.buffer[whoAmi].writeLocked = false;
        if (msgType == 19 && Main.netMode == 1)
          NetMessage.SendTileSquare(whoAmi, (int) number2, (int) number3, 5, TileChangeType.None);
        if (msgType != 2 || Main.netMode != 2)
          return;
        Netplay.Clients[whoAmi].PendingTermination = true;
      }
    }

    public static int CompressTileBlock(int xStart, int yStart, short width, short height, byte[] buffer, int bufferStart)
    {
      using (MemoryStream memoryStream1 = new MemoryStream())
      {
        using (BinaryWriter writer = new BinaryWriter((Stream) memoryStream1))
        {
          writer.Write(xStart);
          writer.Write(yStart);
          writer.Write(width);
          writer.Write(height);
          NetMessage.CompressTileBlock_Inner(writer, xStart, yStart, (int) width, (int) height);
          int length = buffer.Length;
          if ((long) bufferStart + memoryStream1.Length > (long) length)
            return (int) ((long) (length - bufferStart) + memoryStream1.Length);
          memoryStream1.Position = 0L;
          MemoryStream memoryStream2 = new MemoryStream();
          using (DeflateStream deflateStream = new DeflateStream((Stream) memoryStream2, (CompressionMode) 0, true))
          {
            memoryStream1.CopyTo((Stream) deflateStream);
            ((Stream) deflateStream).Flush();
            ((Stream) deflateStream).Close();
            ((Stream) deflateStream).Dispose();
          }
          if (memoryStream1.Length <= memoryStream2.Length)
          {
            memoryStream1.Position = 0L;
            buffer[bufferStart] = (byte) 0;
            ++bufferStart;
            memoryStream1.Read(buffer, bufferStart, (int) memoryStream1.Length);
            return (int) memoryStream1.Length + 1;
          }
          memoryStream2.Position = 0L;
          buffer[bufferStart] = (byte) 1;
          ++bufferStart;
          memoryStream2.Read(buffer, bufferStart, (int) memoryStream2.Length);
          return (int) memoryStream2.Length + 1;
        }
      }
    }

    public static void CompressTileBlock_Inner(BinaryWriter writer, int xStart, int yStart, int width, int height)
    {
      short[] numArray1 = new short[1000];
      short[] numArray2 = new short[1000];
      short[] numArray3 = new short[1000];
      short num1 = 0;
      short num2 = 0;
      short num3 = 0;
      short num4 = 0;
      int index1 = 0;
      int index2 = 0;
      byte num5 = 0;
      byte[] buffer = new byte[13];
      Tile compTile = (Tile) null;
      for (int index3 = yStart; index3 < yStart + height; ++index3)
      {
        for (int index4 = xStart; index4 < xStart + width; ++index4)
        {
          Tile tile = Main.tile[index4, index3];
          if (tile.isTheSameAs(compTile))
          {
            ++num4;
          }
          else
          {
            if (compTile != null)
            {
              if ((int) num4 > 0)
              {
                buffer[index1] = (byte) ((uint) num4 & (uint) byte.MaxValue);
                ++index1;
                if ((int) num4 > (int) byte.MaxValue)
                {
                  num5 |= (byte) 128;
                  buffer[index1] = (byte) (((int) num4 & 65280) >> 8);
                  ++index1;
                }
                else
                  num5 |= (byte) 64;
              }
              buffer[index2] = num5;
              writer.Write(buffer, index2, index1 - index2);
              num4 = (short) 0;
            }
            index1 = 3;
            int num6;
            byte num7 = (byte) (num6 = 0);
            byte num8 = (byte) num6;
            num5 = (byte) num6;
            if (tile.active())
            {
              num5 |= (byte) 2;
              buffer[index1] = (byte) tile.type;
              ++index1;
              if ((int) tile.type > (int) byte.MaxValue)
              {
                buffer[index1] = (byte) ((uint) tile.type >> 8);
                ++index1;
                num5 |= (byte) 32;
              }
              if (TileID.Sets.BasicChest[(int) tile.type] && (int) tile.frameX % 36 == 0 && (int) tile.frameY % 36 == 0)
              {
                short chest = (short) Chest.FindChest(index4, index3);
                if ((int) chest != -1)
                {
                  numArray1[(int) num1] = chest;
                  ++num1;
                }
              }
              if ((int) tile.type == 88 && (int) tile.frameX % 54 == 0 && (int) tile.frameY % 36 == 0)
              {
                short chest = (short) Chest.FindChest(index4, index3);
                if ((int) chest != -1)
                {
                  numArray1[(int) num1] = chest;
                  ++num1;
                }
              }
              if ((int) tile.type == 85 && (int) tile.frameX % 36 == 0 && (int) tile.frameY % 36 == 0)
              {
                short num9 = (short) Sign.ReadSign(index4, index3, true);
                if ((int) num9 != -1)
                  numArray2[(int) num2++] = num9;
              }
              if ((int) tile.type == 55 && (int) tile.frameX % 36 == 0 && (int) tile.frameY % 36 == 0)
              {
                short num9 = (short) Sign.ReadSign(index4, index3, true);
                if ((int) num9 != -1)
                  numArray2[(int) num2++] = num9;
              }
              if ((int) tile.type == 425 && (int) tile.frameX % 36 == 0 && (int) tile.frameY % 36 == 0)
              {
                short num9 = (short) Sign.ReadSign(index4, index3, true);
                if ((int) num9 != -1)
                  numArray2[(int) num2++] = num9;
              }
              if ((int) tile.type == 378 && (int) tile.frameX % 36 == 0 && (int) tile.frameY == 0)
              {
                int num9 = TETrainingDummy.Find(index4, index3);
                if (num9 != -1)
                  numArray3[(int) num3++] = (short) num9;
              }
              if ((int) tile.type == 395 && (int) tile.frameX % 36 == 0 && (int) tile.frameY == 0)
              {
                int num9 = TEItemFrame.Find(index4, index3);
                if (num9 != -1)
                  numArray3[(int) num3++] = (short) num9;
              }
              if (Main.tileFrameImportant[(int) tile.type])
              {
                buffer[index1] = (byte) ((uint) tile.frameX & (uint) byte.MaxValue);
                int index5 = index1 + 1;
                buffer[index5] = (byte) (((int) tile.frameX & 65280) >> 8);
                int index6 = index5 + 1;
                buffer[index6] = (byte) ((uint) tile.frameY & (uint) byte.MaxValue);
                int index7 = index6 + 1;
                buffer[index7] = (byte) (((int) tile.frameY & 65280) >> 8);
                index1 = index7 + 1;
              }
              if ((int) tile.color() != 0)
              {
                num7 |= (byte) 8;
                buffer[index1] = tile.color();
                ++index1;
              }
            }
            if ((int) tile.wall != 0)
            {
              num5 |= (byte) 4;
              buffer[index1] = tile.wall;
              ++index1;
              if ((int) tile.wallColor() != 0)
              {
                num7 |= (byte) 16;
                buffer[index1] = tile.wallColor();
                ++index1;
              }
            }
            if ((int) tile.liquid != 0)
            {
              if (tile.lava())
                num5 |= (byte) 16;
              else if (tile.honey())
                num5 |= (byte) 24;
              else
                num5 |= (byte) 8;
              buffer[index1] = tile.liquid;
              ++index1;
            }
            if (tile.wire())
              num8 |= (byte) 2;
            if (tile.wire2())
              num8 |= (byte) 4;
            if (tile.wire3())
              num8 |= (byte) 8;
            int num10 = !tile.halfBrick() ? ((int) tile.slope() == 0 ? 0 : (int) tile.slope() + 1 << 4) : 16;
            byte num11 = (byte) ((uint) num8 | (uint) (byte) num10);
            if (tile.actuator())
              num7 |= (byte) 2;
            if (tile.inActive())
              num7 |= (byte) 4;
            if (tile.wire4())
              num7 |= (byte) 32;
            index2 = 2;
            if ((int) num7 != 0)
            {
              num11 |= (byte) 1;
              buffer[index2] = num7;
              --index2;
            }
            if ((int) num11 != 0)
            {
              num5 |= (byte) 1;
              buffer[index2] = num11;
              --index2;
            }
            compTile = tile;
          }
        }
      }
      if ((int) num4 > 0)
      {
        buffer[index1] = (byte) ((uint) num4 & (uint) byte.MaxValue);
        ++index1;
        if ((int) num4 > (int) byte.MaxValue)
        {
          num5 |= (byte) 128;
          buffer[index1] = (byte) (((int) num4 & 65280) >> 8);
          ++index1;
        }
        else
          num5 |= (byte) 64;
      }
      buffer[index2] = num5;
      writer.Write(buffer, index2, index1 - index2);
      writer.Write(num1);
      for (int index3 = 0; index3 < (int) num1; ++index3)
      {
        Chest chest = Main.chest[(int) numArray1[index3]];
        writer.Write(numArray1[index3]);
        writer.Write((short) chest.x);
        writer.Write((short) chest.y);
        writer.Write(chest.name);
      }
      writer.Write(num2);
      for (int index3 = 0; index3 < (int) num2; ++index3)
      {
        Sign sign = Main.sign[(int) numArray2[index3]];
        writer.Write(numArray2[index3]);
        writer.Write((short) sign.x);
        writer.Write((short) sign.y);
        writer.Write(sign.text);
      }
      writer.Write(num3);
      for (int index3 = 0; index3 < (int) num3; ++index3)
        TileEntity.Write(writer, TileEntity.ByID[(int) numArray3[index3]], false);
    }

    public static void DecompressTileBlock(byte[] buffer, int bufferStart, int bufferLength)
    {
      using (MemoryStream memoryStream1 = new MemoryStream())
      {
        memoryStream1.Write(buffer, bufferStart, bufferLength);
        memoryStream1.Position = 0L;
        MemoryStream memoryStream2;
        if ((uint) memoryStream1.ReadByte() > 0U)
        {
          MemoryStream memoryStream3 = new MemoryStream();
          using (DeflateStream deflateStream = new DeflateStream((Stream) memoryStream1, (CompressionMode) 1, true))
          {
            ((Stream) deflateStream).CopyTo((Stream) memoryStream3);
            ((Stream) deflateStream).Close();
          }
          memoryStream2 = memoryStream3;
          memoryStream2.Position = 0L;
        }
        else
        {
          memoryStream2 = memoryStream1;
          memoryStream2.Position = 1L;
        }
        using (BinaryReader reader = new BinaryReader((Stream) memoryStream2))
        {
          int xStart = reader.ReadInt32();
          int yStart = reader.ReadInt32();
          short num1 = reader.ReadInt16();
          short num2 = reader.ReadInt16();
          NetMessage.DecompressTileBlock_Inner(reader, xStart, yStart, (int) num1, (int) num2);
        }
      }
    }

    public static void DecompressTileBlock_Inner(BinaryReader reader, int xStart, int yStart, int width, int height)
    {
      Tile tile = (Tile) null;
      int num1 = 0;
      for (int index1 = yStart; index1 < yStart + height; ++index1)
      {
        for (int index2 = xStart; index2 < xStart + width; ++index2)
        {
          if (num1 != 0)
          {
            --num1;
            if (Main.tile[index2, index1] == null)
              Main.tile[index2, index1] = new Tile(tile);
            else
              Main.tile[index2, index1].CopyFrom(tile);
          }
          else
          {
            byte num2;
            byte num3 = num2 = (byte) 0;
            tile = Main.tile[index2, index1];
            if (tile == null)
            {
              tile = new Tile();
              Main.tile[index2, index1] = tile;
            }
            else
              tile.ClearEverything();
            byte num4 = reader.ReadByte();
            if (((int) num4 & 1) == 1)
            {
              num3 = reader.ReadByte();
              if (((int) num3 & 1) == 1)
                num2 = reader.ReadByte();
            }
            bool flag = tile.active();
            if (((int) num4 & 2) == 2)
            {
              tile.active(true);
              ushort type = tile.type;
              int index3;
              if (((int) num4 & 32) == 32)
              {
                byte num5 = reader.ReadByte();
                index3 = (int) reader.ReadByte() << 8 | (int) num5;
              }
              else
                index3 = (int) reader.ReadByte();
              tile.type = (ushort) index3;
              if (Main.tileFrameImportant[index3])
              {
                tile.frameX = reader.ReadInt16();
                tile.frameY = reader.ReadInt16();
              }
              else if (!flag || (int) tile.type != (int) type)
              {
                tile.frameX = (short) -1;
                tile.frameY = (short) -1;
              }
              if (((int) num2 & 8) == 8)
                tile.color(reader.ReadByte());
            }
            if (((int) num4 & 4) == 4)
            {
              tile.wall = reader.ReadByte();
              if (((int) num2 & 16) == 16)
                tile.wallColor(reader.ReadByte());
            }
            byte num6 = (byte) (((int) num4 & 24) >> 3);
            if ((int) num6 != 0)
            {
              tile.liquid = reader.ReadByte();
              if ((int) num6 > 1)
              {
                if ((int) num6 == 2)
                  tile.lava(true);
                else
                  tile.honey(true);
              }
            }
            if ((int) num3 > 1)
            {
              if (((int) num3 & 2) == 2)
                tile.wire(true);
              if (((int) num3 & 4) == 4)
                tile.wire2(true);
              if (((int) num3 & 8) == 8)
                tile.wire3(true);
              byte num5 = (byte) (((int) num3 & 112) >> 4);
              if ((int) num5 != 0 && Main.tileSolid[(int) tile.type])
              {
                if ((int) num5 == 1)
                  tile.halfBrick(true);
                else
                  tile.slope((byte) ((uint) num5 - 1U));
              }
            }
            if ((int) num2 > 0)
            {
              if (((int) num2 & 2) == 2)
                tile.actuator(true);
              if (((int) num2 & 4) == 4)
                tile.inActive(true);
              if (((int) num2 & 32) == 32)
                tile.wire4(true);
            }
            switch ((byte) (((int) num4 & 192) >> 6))
            {
              case 0:
                num1 = 0;
                continue;
              case 1:
                num1 = (int) reader.ReadByte();
                continue;
              default:
                num1 = (int) reader.ReadInt16();
                continue;
            }
          }
        }
      }
      short num7 = reader.ReadInt16();
      for (int index = 0; index < (int) num7; ++index)
      {
        short num2 = reader.ReadInt16();
        short num3 = reader.ReadInt16();
        short num4 = reader.ReadInt16();
        string str = reader.ReadString();
        if ((int) num2 >= 0 && (int) num2 < 1000)
        {
          if (Main.chest[(int) num2] == null)
            Main.chest[(int) num2] = new Chest(false);
          Main.chest[(int) num2].name = str;
          Main.chest[(int) num2].x = (int) num3;
          Main.chest[(int) num2].y = (int) num4;
        }
      }
      short num8 = reader.ReadInt16();
      for (int index = 0; index < (int) num8; ++index)
      {
        short num2 = reader.ReadInt16();
        short num3 = reader.ReadInt16();
        short num4 = reader.ReadInt16();
        string str = reader.ReadString();
        if ((int) num2 >= 0 && (int) num2 < 1000)
        {
          if (Main.sign[(int) num2] == null)
            Main.sign[(int) num2] = new Sign();
          Main.sign[(int) num2].text = str;
          Main.sign[(int) num2].x = (int) num3;
          Main.sign[(int) num2].y = (int) num4;
        }
      }
      short num9 = reader.ReadInt16();
      for (int index = 0; index < (int) num9; ++index)
      {
        TileEntity tileEntity = TileEntity.Read(reader, false);
        TileEntity.ByID[tileEntity.ID] = tileEntity;
        TileEntity.ByPosition[tileEntity.Position] = tileEntity;
      }
    }

    public static void ReceiveBytes(byte[] bytes, int streamLength, int i = 256)
    {
      lock (NetMessage.buffer[i])
      {
        try
        {
          Buffer.BlockCopy((Array) bytes, 0, (Array) NetMessage.buffer[i].readBuffer, NetMessage.buffer[i].totalData, streamLength);
          NetMessage.buffer[i].totalData += streamLength;
          NetMessage.buffer[i].checkBytes = true;
        }
        catch
        {
          if (Main.netMode == 1)
          {
            Main.menuMode = 15;
            Main.statusText = Language.GetTextValue("Error.BadHeaderBufferOverflow");
            Netplay.disconnect = true;
          }
          else
            Netplay.Clients[i].PendingTermination = true;
        }
      }
    }

    public static void CheckBytes(int bufferIndex = 256)
    {
      lock (NetMessage.buffer[bufferIndex])
      {
        int local_2 = 0;
        int local_3 = NetMessage.buffer[bufferIndex].totalData;
        try
        {
          while (local_3 >= 2)
          {
            int local_4 = (int) BitConverter.ToUInt16(NetMessage.buffer[bufferIndex].readBuffer, local_2);
            if (local_3 >= local_4)
            {
              long local_5 = NetMessage.buffer[bufferIndex].reader.BaseStream.Position;
              int local_6;
              NetMessage.buffer[bufferIndex].GetData(local_2 + 2, local_4 - 2, out local_6);
              NetMessage.buffer[bufferIndex].reader.BaseStream.Position = local_5 + (long) local_4;
              local_3 -= local_4;
              local_2 += local_4;
            }
            else
              break;
          }
        }
        catch
        {
          if (local_2 < NetMessage.buffer.Length - 100)
            Console.WriteLine(Language.GetTextValue("Error.NetMessageError", (object) NetMessage.buffer[local_2 + 2]));
          local_3 = 0;
          local_2 = 0;
        }
        if (local_3 != NetMessage.buffer[bufferIndex].totalData)
        {
          for (int local_7 = 0; local_7 < local_3; ++local_7)
            NetMessage.buffer[bufferIndex].readBuffer[local_7] = NetMessage.buffer[bufferIndex].readBuffer[local_7 + local_2];
          NetMessage.buffer[bufferIndex].totalData = local_3;
        }
        NetMessage.buffer[bufferIndex].checkBytes = false;
      }
    }

    public static void BootPlayer(int plr, NetworkText msg)
    {
      NetMessage.SendData(2, plr, -1, msg, 0, 0.0f, 0.0f, 0.0f, 0, 0, 0);
    }

    public static void SendObjectPlacment(int whoAmi, int x, int y, int type, int style, int alternative, int random, int direction)
    {
      int remoteClient;
      int ignoreClient;
      if (Main.netMode == 2)
      {
        remoteClient = -1;
        ignoreClient = whoAmi;
      }
      else
      {
        remoteClient = whoAmi;
        ignoreClient = -1;
      }
      NetMessage.SendData(79, remoteClient, ignoreClient, (NetworkText) null, x, (float) y, (float) type, (float) style, alternative, random, direction);
    }

    public static void SendTemporaryAnimation(int whoAmi, int animationType, int tileType, int xCoord, int yCoord)
    {
      NetMessage.SendData(77, whoAmi, -1, (NetworkText) null, animationType, (float) tileType, (float) xCoord, (float) yCoord, 0, 0, 0);
    }

    public static void SendPlayerHurt(int playerTargetIndex, PlayerDeathReason reason, int damage, int direction, bool critical, bool pvp, int hitContext, int remoteClient = -1, int ignoreClient = -1)
    {
      NetMessage._currentPlayerDeathReason = reason;
      BitsByte bitsByte = (BitsByte) (byte) 0;
      bitsByte[0] = critical;
      bitsByte[1] = pvp;
      NetMessage.SendData(117, remoteClient, ignoreClient, (NetworkText) null, playerTargetIndex, (float) damage, (float) direction, (float) (byte) bitsByte, hitContext, 0, 0);
    }

    public static void SendPlayerDeath(int playerTargetIndex, PlayerDeathReason reason, int damage, int direction, bool pvp, int remoteClient = -1, int ignoreClient = -1)
    {
      NetMessage._currentPlayerDeathReason = reason;
      BitsByte bitsByte = (BitsByte) (byte) 0;
      bitsByte[0] = pvp;
      NetMessage.SendData(118, remoteClient, ignoreClient, (NetworkText) null, playerTargetIndex, (float) damage, (float) direction, (float) (byte) bitsByte, 0, 0, 0);
    }

    public static void SendTileRange(int whoAmi, int tileX, int tileY, int xSize, int ySize, TileChangeType changeType = TileChangeType.None)
    {
      int number = xSize >= ySize ? xSize : ySize;
      NetMessage.SendData(20, whoAmi, -1, (NetworkText) null, number, (float) tileX, (float) tileY, 0.0f, (int) changeType, 0, 0);
    }

    public static void SendTileSquare(int whoAmi, int tileX, int tileY, int size, TileChangeType changeType = TileChangeType.None)
    {
      int num = (size - 1) / 2;
      NetMessage.SendData(20, whoAmi, -1, (NetworkText) null, size, (float) (tileX - num), (float) (tileY - num), 0.0f, (int) changeType, 0, 0);
    }

    public static void SendTravelShop(int remoteClient)
    {
      if (Main.netMode != 2)
        return;
      NetMessage.SendData(72, remoteClient, -1, (NetworkText) null, 0, 0.0f, 0.0f, 0.0f, 0, 0, 0);
    }

    public static void SendAnglerQuest(int remoteClient)
    {
      if (Main.netMode != 2)
        return;
      if (remoteClient == -1)
      {
        for (int remoteClient1 = 0; remoteClient1 < (int) byte.MaxValue; ++remoteClient1)
        {
          if (Netplay.Clients[remoteClient1].State == 10)
            NetMessage.SendData(74, remoteClient1, -1, NetworkText.FromLiteral(Main.player[remoteClient1].name), Main.anglerQuest, 0.0f, 0.0f, 0.0f, 0, 0, 0);
        }
      }
      else
      {
        if (Netplay.Clients[remoteClient].State != 10)
          return;
        NetMessage.SendData(74, remoteClient, -1, NetworkText.FromLiteral(Main.player[remoteClient].name), Main.anglerQuest, 0.0f, 0.0f, 0.0f, 0, 0, 0);
      }
    }

    public static void SendSection(int whoAmi, int sectionX, int sectionY, bool skipSent = false)
    {
      if (Main.netMode != 2)
        return;
      try
      {
        if (sectionX < 0 || sectionY < 0 || (sectionX >= Main.maxSectionsX || sectionY >= Main.maxSectionsY) || skipSent && Netplay.Clients[whoAmi].TileSections[sectionX, sectionY])
          return;
        Netplay.Clients[whoAmi].TileSections[sectionX, sectionY] = true;
        int number1 = sectionX * 200;
        int num1 = sectionY * 150;
        int num2 = 150;
        int num3 = num1;
        while (num3 < num1 + 150)
        {
          NetMessage.SendData(10, whoAmi, -1, (NetworkText) null, number1, (float) num3, 200f, (float) num2, 0, 0, 0);
          num3 += num2;
        }
        for (int number2 = 0; number2 < 200; ++number2)
        {
          if (Main.npc[number2].active && Main.npc[number2].townNPC)
          {
            int sectionX1 = Netplay.GetSectionX((int) ((double) Main.npc[number2].position.X / 16.0));
            int sectionY1 = Netplay.GetSectionY((int) ((double) Main.npc[number2].position.Y / 16.0));
            int num4 = sectionX;
            if (sectionX1 == num4 && sectionY1 == sectionY)
              NetMessage.SendData(23, whoAmi, -1, (NetworkText) null, number2, 0.0f, 0.0f, 0.0f, 0, 0, 0);
          }
        }
      }
      catch
      {
      }
    }

    public static void greetPlayer(int plr)
    {
      if (Main.motd == "")
        NetMessage.SendChatMessageToClient(NetworkText.FromFormattable("{0} {1}!", (object) Lang.mp[18].ToNetworkText(), (object) Main.worldName), new Color((int) byte.MaxValue, 240, 20), plr);
      else
        NetMessage.SendChatMessageToClient(NetworkText.FromLiteral(Main.motd), new Color((int) byte.MaxValue, 240, 20), plr);
      string str = "";
      for (int index = 0; index < (int) byte.MaxValue; ++index)
      {
        if (Main.player[index].active)
          str = !(str == "") ? str + ", " + Main.player[index].name : str + Main.player[index].name;
      }
      NetMessage.SendChatMessageToClient(NetworkText.FromKey("Game.JoinGreeting", (object) str), new Color((int) byte.MaxValue, 240, 20), plr);
    }

    public static void sendWater(int x, int y)
    {
      if (Main.netMode == 1)
      {
        NetMessage.SendData(48, -1, -1, (NetworkText) null, x, (float) y, 0.0f, 0.0f, 0, 0, 0);
      }
      else
      {
        for (int remoteClient = 0; remoteClient < 256; ++remoteClient)
        {
          if ((NetMessage.buffer[remoteClient].broadcast || Netplay.Clients[remoteClient].State >= 3) && Netplay.Clients[remoteClient].IsConnected())
          {
            int index1 = x / 200;
            int index2 = y / 150;
            if (Netplay.Clients[remoteClient].TileSections[index1, index2])
              NetMessage.SendData(48, remoteClient, -1, (NetworkText) null, x, (float) y, 0.0f, 0.0f, 0, 0, 0);
          }
        }
      }
    }

    public static void SyncDisconnectedPlayer(int plr)
    {
      NetMessage.SyncOnePlayer(plr, -1, plr);
      NetMessage.EnsureLocalPlayerIsPresent();
    }

    public static void SyncConnectedPlayer(int plr)
    {
      NetMessage.SyncOnePlayer(plr, -1, plr);
      for (int plr1 = 0; plr1 < (int) byte.MaxValue; ++plr1)
      {
        if (plr != plr1 && Main.player[plr1].active)
          NetMessage.SyncOnePlayer(plr1, plr, -1);
      }
      NetMessage.SendNPCHousesAndTravelShop(plr);
      NetMessage.SendAnglerQuest(plr);
      NetMessage.EnsureLocalPlayerIsPresent();
    }

    private static void SendNPCHousesAndTravelShop(int plr)
    {
      bool flag = false;
      for (int number = 0; number < 200; ++number)
      {
        if (Main.npc[number].active && Main.npc[number].townNPC && NPC.TypeToHeadIndex(Main.npc[number].type) != -1)
        {
          if (!flag && Main.npc[number].type == 368)
            flag = true;
          byte householdStatus = WorldGen.TownManager.GetHouseholdStatus(Main.npc[number]);
          NetMessage.SendData(60, plr, -1, (NetworkText) null, number, (float) Main.npc[number].homeTileX, (float) Main.npc[number].homeTileY, (float) householdStatus, 0, 0, 0);
        }
      }
      if (!flag)
        return;
      NetMessage.SendTravelShop(plr);
    }

    private static void EnsureLocalPlayerIsPresent()
    {
      if (!Main.autoShutdown)
        return;
      bool flag = false;
      for (int index = 0; index < (int) byte.MaxValue; ++index)
      {
        if (Netplay.Clients[index].State == 10 && Netplay.Clients[index].Socket.GetRemoteAddress().IsLocalHost())
        {
          flag = true;
          break;
        }
      }
      if (flag)
        return;
      Console.WriteLine(Language.GetTextValue("Net.ServerAutoShutdown"));
      WorldFile.saveWorld();
      Netplay.disconnect = true;
    }

    private static void SyncOnePlayer(int plr, int toWho, int fromWho)
    {
      int num1 = 0;
      if (Main.player[plr].active)
        num1 = 1;
      if (Netplay.Clients[plr].State == 10)
      {
        NetMessage.SendData(14, toWho, fromWho, (NetworkText) null, plr, (float) num1, 0.0f, 0.0f, 0, 0, 0);
        NetMessage.SendData(4, toWho, fromWho, (NetworkText) null, plr, 0.0f, 0.0f, 0.0f, 0, 0, 0);
        NetMessage.SendData(13, toWho, fromWho, (NetworkText) null, plr, 0.0f, 0.0f, 0.0f, 0, 0, 0);
        NetMessage.SendData(16, toWho, fromWho, (NetworkText) null, plr, 0.0f, 0.0f, 0.0f, 0, 0, 0);
        NetMessage.SendData(30, toWho, fromWho, (NetworkText) null, plr, 0.0f, 0.0f, 0.0f, 0, 0, 0);
        NetMessage.SendData(45, toWho, fromWho, (NetworkText) null, plr, 0.0f, 0.0f, 0.0f, 0, 0, 0);
        NetMessage.SendData(42, toWho, fromWho, (NetworkText) null, plr, 0.0f, 0.0f, 0.0f, 0, 0, 0);
        NetMessage.SendData(50, toWho, fromWho, (NetworkText) null, plr, 0.0f, 0.0f, 0.0f, 0, 0, 0);
        for (int index = 0; index < 59; ++index)
          NetMessage.SendData(5, toWho, fromWho, (NetworkText) null, plr, (float) index, (float) Main.player[plr].inventory[index].prefix, 0.0f, 0, 0, 0);
        for (int index = 0; index < Main.player[plr].armor.Length; ++index)
          NetMessage.SendData(5, toWho, fromWho, (NetworkText) null, plr, (float) (59 + index), (float) Main.player[plr].armor[index].prefix, 0.0f, 0, 0, 0);
        for (int index = 0; index < Main.player[plr].dye.Length; ++index)
          NetMessage.SendData(5, toWho, fromWho, (NetworkText) null, plr, (float) (58 + Main.player[plr].armor.Length + 1 + index), (float) Main.player[plr].dye[index].prefix, 0.0f, 0, 0, 0);
        for (int index = 0; index < Main.player[plr].miscEquips.Length; ++index)
          NetMessage.SendData(5, toWho, fromWho, (NetworkText) null, plr, (float) (58 + Main.player[plr].armor.Length + Main.player[plr].dye.Length + 1 + index), (float) Main.player[plr].miscEquips[index].prefix, 0.0f, 0, 0, 0);
        for (int index = 0; index < Main.player[plr].miscDyes.Length; ++index)
          NetMessage.SendData(5, toWho, fromWho, (NetworkText) null, plr, (float) (58 + Main.player[plr].armor.Length + Main.player[plr].dye.Length + Main.player[plr].miscEquips.Length + 1 + index), (float) Main.player[plr].miscDyes[index].prefix, 0.0f, 0, 0, 0);
        if (Netplay.Clients[plr].IsAnnouncementCompleted)
          return;
        Netplay.Clients[plr].IsAnnouncementCompleted = true;
        NetMessage.BroadcastChatMessage(NetworkText.FromKey(Lang.mp[19].Key, (object) Main.player[plr].name), new Color((int) byte.MaxValue, 240, 20), plr);
        if (!Main.dedServ)
          return;
        Console.WriteLine(Lang.mp[19].Format((object) Main.player[plr].name));
      }
      else
      {
        int num2 = 0;
        NetMessage.SendData(14, -1, plr, (NetworkText) null, plr, (float) num2, 0.0f, 0.0f, 0, 0, 0);
        if (!Netplay.Clients[plr].IsAnnouncementCompleted)
          return;
        Netplay.Clients[plr].IsAnnouncementCompleted = false;
        NetMessage.BroadcastChatMessage(NetworkText.FromKey(Lang.mp[20].Key, (object) Netplay.Clients[plr].Name), new Color((int) byte.MaxValue, 240, 20), plr);
        if (Main.dedServ)
          Console.WriteLine(Lang.mp[20].Format((object) Netplay.Clients[plr].Name));
        Netplay.Clients[plr].Name = "Anonymous";
      }
    }
  }
}
