﻿// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Achievements.TileDestroyedCondition
// Assembly: TerrariaServer, Version=1.3.5.1, Culture=neutral, PublicKeyToken=null
// MVID: C2103E81-0935-4BEA-9E98-4159FC80C2BB
// Assembly location: C:\Program Files (x86)\Steam\steamapps\common\Terraria\TerrariaServer.exe

using System.Collections.Generic;
using Terraria.Achievements;

namespace Terraria.GameContent.Achievements
{
  public class TileDestroyedCondition : AchievementCondition
  {
    private static Dictionary<ushort, List<TileDestroyedCondition>> _listeners = new Dictionary<ushort, List<TileDestroyedCondition>>();
    private static bool _isListenerHooked = false;
    private const string Identifier = "TILE_DESTROYED";
    private ushort[] _tileIds;

    private TileDestroyedCondition(ushort[] tileIds)
      : base("TILE_DESTROYED_" + (object) tileIds[0])
    {
      this._tileIds = tileIds;
      TileDestroyedCondition.ListenForDestruction(this);
    }

    private static void ListenForDestruction(TileDestroyedCondition condition)
    {
      if (!TileDestroyedCondition._isListenerHooked)
      {
        AchievementsHelper.OnTileDestroyed += new AchievementsHelper.TileDestroyedEvent(TileDestroyedCondition.TileDestroyedListener);
        TileDestroyedCondition._isListenerHooked = true;
      }
      for (int index = 0; index < condition._tileIds.Length; ++index)
      {
        if (!TileDestroyedCondition._listeners.ContainsKey(condition._tileIds[index]))
          TileDestroyedCondition._listeners[condition._tileIds[index]] = new List<TileDestroyedCondition>();
        TileDestroyedCondition._listeners[condition._tileIds[index]].Add(condition);
      }
    }

    private static void TileDestroyedListener(Player player, ushort tileId)
    {
      if (player.whoAmI != Main.myPlayer || !TileDestroyedCondition._listeners.ContainsKey(tileId))
        return;
      foreach (AchievementCondition achievementCondition in TileDestroyedCondition._listeners[tileId])
        achievementCondition.Complete();
    }

    public static AchievementCondition Create(params ushort[] tileIds)
    {
      return (AchievementCondition) new TileDestroyedCondition(tileIds);
    }
  }
}
