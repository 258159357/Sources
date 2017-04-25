// Decompiled with JetBrains decompiler
// Type: Terraria.UI.ItemSorting
// Assembly: TerrariaServer, Version=1.3.5.3, Culture=neutral, PublicKeyToken=null
// MVID: AA3606A2-F3DB-4481-937B-7295FB97CD3E
// Assembly location: E:\TSHOCK\TerrariaServer.exe

using System;
using System.Collections.Generic;
using System.Linq;
using Terraria.Localization;

namespace Terraria.UI
{
  public class ItemSorting
  {
    private static List<ItemSorting.ItemSortingLayer> _layerList = new List<ItemSorting.ItemSortingLayer>();
    private static Dictionary<string, List<int>> _layerWhiteLists = new Dictionary<string, List<int>>();

    public static void SetupWhiteLists()
    {
      ItemSorting._layerWhiteLists.Clear();
      List<ItemSorting.ItemSortingLayer> itemSortingLayerList = new List<ItemSorting.ItemSortingLayer>();
      List<Item> objList = new List<Item>();
      List<int> intList1 = new List<int>();
      itemSortingLayerList.Add(ItemSorting.ItemSortingLayers.WeaponsMelee);
      itemSortingLayerList.Add(ItemSorting.ItemSortingLayers.WeaponsRanged);
      itemSortingLayerList.Add(ItemSorting.ItemSortingLayers.WeaponsMagic);
      itemSortingLayerList.Add(ItemSorting.ItemSortingLayers.WeaponsMinions);
      itemSortingLayerList.Add(ItemSorting.ItemSortingLayers.WeaponsThrown);
      itemSortingLayerList.Add(ItemSorting.ItemSortingLayers.WeaponsAssorted);
      itemSortingLayerList.Add(ItemSorting.ItemSortingLayers.WeaponsAmmo);
      itemSortingLayerList.Add(ItemSorting.ItemSortingLayers.ToolsPicksaws);
      itemSortingLayerList.Add(ItemSorting.ItemSortingLayers.ToolsHamaxes);
      itemSortingLayerList.Add(ItemSorting.ItemSortingLayers.ToolsPickaxes);
      itemSortingLayerList.Add(ItemSorting.ItemSortingLayers.ToolsAxes);
      itemSortingLayerList.Add(ItemSorting.ItemSortingLayers.ToolsHammers);
      itemSortingLayerList.Add(ItemSorting.ItemSortingLayers.ToolsTerraforming);
      itemSortingLayerList.Add(ItemSorting.ItemSortingLayers.ToolsAmmoLeftovers);
      itemSortingLayerList.Add(ItemSorting.ItemSortingLayers.ArmorCombat);
      itemSortingLayerList.Add(ItemSorting.ItemSortingLayers.ArmorVanity);
      itemSortingLayerList.Add(ItemSorting.ItemSortingLayers.ArmorAccessories);
      itemSortingLayerList.Add(ItemSorting.ItemSortingLayers.EquipGrapple);
      itemSortingLayerList.Add(ItemSorting.ItemSortingLayers.EquipMount);
      itemSortingLayerList.Add(ItemSorting.ItemSortingLayers.EquipCart);
      itemSortingLayerList.Add(ItemSorting.ItemSortingLayers.EquipLightPet);
      itemSortingLayerList.Add(ItemSorting.ItemSortingLayers.EquipVanityPet);
      itemSortingLayerList.Add(ItemSorting.ItemSortingLayers.PotionsDyes);
      itemSortingLayerList.Add(ItemSorting.ItemSortingLayers.PotionsHairDyes);
      itemSortingLayerList.Add(ItemSorting.ItemSortingLayers.PotionsLife);
      itemSortingLayerList.Add(ItemSorting.ItemSortingLayers.PotionsMana);
      itemSortingLayerList.Add(ItemSorting.ItemSortingLayers.PotionsElixirs);
      itemSortingLayerList.Add(ItemSorting.ItemSortingLayers.PotionsBuffs);
      itemSortingLayerList.Add(ItemSorting.ItemSortingLayers.MiscValuables);
      itemSortingLayerList.Add(ItemSorting.ItemSortingLayers.MiscPainting);
      itemSortingLayerList.Add(ItemSorting.ItemSortingLayers.MiscWiring);
      itemSortingLayerList.Add(ItemSorting.ItemSortingLayers.MiscMaterials);
      itemSortingLayerList.Add(ItemSorting.ItemSortingLayers.MiscRopes);
      itemSortingLayerList.Add(ItemSorting.ItemSortingLayers.MiscExtractinator);
      itemSortingLayerList.Add(ItemSorting.ItemSortingLayers.LastMaterials);
      itemSortingLayerList.Add(ItemSorting.ItemSortingLayers.LastTilesImportant);
      itemSortingLayerList.Add(ItemSorting.ItemSortingLayers.LastTilesCommon);
      itemSortingLayerList.Add(ItemSorting.ItemSortingLayers.LastNotTrash);
      itemSortingLayerList.Add(ItemSorting.ItemSortingLayers.LastTrash);
      for (int type = -48; type < 3930; ++type)
      {
        Item obj = new Item();
        obj.netDefaults(type);
        objList.Add(obj);
        intList1.Add(type + 48);
      }
      Item[] array = objList.ToArray();
      foreach (ItemSorting.ItemSortingLayer itemSortingLayer in itemSortingLayerList)
      {
        List<int> intList2 = itemSortingLayer.SortingMethod(itemSortingLayer, array, intList1);
        List<int> intList3 = new List<int>();
        for (int index = 0; index < intList2.Count; ++index)
          intList3.Add(array[intList2[index]].netID);
        ItemSorting._layerWhiteLists.Add(itemSortingLayer.Name, intList3);
      }
    }

    private static void SetupSortingPriorities()
    {
      Player player = Main.player[Main.myPlayer];
      ItemSorting._layerList.Clear();
      List<float> floatList = new List<float>()
      {
        player.meleeDamage,
        player.rangedDamage,
        player.magicDamage,
        player.minionDamage,
        player.thrownDamage
      };
      floatList.Sort((Comparison<float>) ((x, y) => y.CompareTo(x)));
      for (int index = 0; index < 5; ++index)
      {
        if (!ItemSorting._layerList.Contains(ItemSorting.ItemSortingLayers.WeaponsMelee) && (double) player.meleeDamage == (double) floatList[0])
        {
          floatList.RemoveAt(0);
          ItemSorting._layerList.Add(ItemSorting.ItemSortingLayers.WeaponsMelee);
        }
        if (!ItemSorting._layerList.Contains(ItemSorting.ItemSortingLayers.WeaponsRanged) && (double) player.rangedDamage == (double) floatList[0])
        {
          floatList.RemoveAt(0);
          ItemSorting._layerList.Add(ItemSorting.ItemSortingLayers.WeaponsRanged);
        }
        if (!ItemSorting._layerList.Contains(ItemSorting.ItemSortingLayers.WeaponsMagic) && (double) player.magicDamage == (double) floatList[0])
        {
          floatList.RemoveAt(0);
          ItemSorting._layerList.Add(ItemSorting.ItemSortingLayers.WeaponsMagic);
        }
        if (!ItemSorting._layerList.Contains(ItemSorting.ItemSortingLayers.WeaponsMinions) && (double) player.minionDamage == (double) floatList[0])
        {
          floatList.RemoveAt(0);
          ItemSorting._layerList.Add(ItemSorting.ItemSortingLayers.WeaponsMinions);
        }
        if (!ItemSorting._layerList.Contains(ItemSorting.ItemSortingLayers.WeaponsThrown) && (double) player.thrownDamage == (double) floatList[0])
        {
          floatList.RemoveAt(0);
          ItemSorting._layerList.Add(ItemSorting.ItemSortingLayers.WeaponsThrown);
        }
      }
      ItemSorting._layerList.Add(ItemSorting.ItemSortingLayers.WeaponsAssorted);
      ItemSorting._layerList.Add(ItemSorting.ItemSortingLayers.WeaponsAmmo);
      ItemSorting._layerList.Add(ItemSorting.ItemSortingLayers.ToolsPicksaws);
      ItemSorting._layerList.Add(ItemSorting.ItemSortingLayers.ToolsHamaxes);
      ItemSorting._layerList.Add(ItemSorting.ItemSortingLayers.ToolsPickaxes);
      ItemSorting._layerList.Add(ItemSorting.ItemSortingLayers.ToolsAxes);
      ItemSorting._layerList.Add(ItemSorting.ItemSortingLayers.ToolsHammers);
      ItemSorting._layerList.Add(ItemSorting.ItemSortingLayers.ToolsTerraforming);
      ItemSorting._layerList.Add(ItemSorting.ItemSortingLayers.ToolsAmmoLeftovers);
      ItemSorting._layerList.Add(ItemSorting.ItemSortingLayers.ArmorCombat);
      ItemSorting._layerList.Add(ItemSorting.ItemSortingLayers.ArmorVanity);
      ItemSorting._layerList.Add(ItemSorting.ItemSortingLayers.ArmorAccessories);
      ItemSorting._layerList.Add(ItemSorting.ItemSortingLayers.EquipGrapple);
      ItemSorting._layerList.Add(ItemSorting.ItemSortingLayers.EquipMount);
      ItemSorting._layerList.Add(ItemSorting.ItemSortingLayers.EquipCart);
      ItemSorting._layerList.Add(ItemSorting.ItemSortingLayers.EquipLightPet);
      ItemSorting._layerList.Add(ItemSorting.ItemSortingLayers.EquipVanityPet);
      ItemSorting._layerList.Add(ItemSorting.ItemSortingLayers.PotionsDyes);
      ItemSorting._layerList.Add(ItemSorting.ItemSortingLayers.PotionsHairDyes);
      ItemSorting._layerList.Add(ItemSorting.ItemSortingLayers.PotionsLife);
      ItemSorting._layerList.Add(ItemSorting.ItemSortingLayers.PotionsMana);
      ItemSorting._layerList.Add(ItemSorting.ItemSortingLayers.PotionsElixirs);
      ItemSorting._layerList.Add(ItemSorting.ItemSortingLayers.PotionsBuffs);
      ItemSorting._layerList.Add(ItemSorting.ItemSortingLayers.MiscValuables);
      ItemSorting._layerList.Add(ItemSorting.ItemSortingLayers.MiscPainting);
      ItemSorting._layerList.Add(ItemSorting.ItemSortingLayers.MiscWiring);
      ItemSorting._layerList.Add(ItemSorting.ItemSortingLayers.MiscMaterials);
      ItemSorting._layerList.Add(ItemSorting.ItemSortingLayers.MiscRopes);
      ItemSorting._layerList.Add(ItemSorting.ItemSortingLayers.MiscExtractinator);
      ItemSorting._layerList.Add(ItemSorting.ItemSortingLayers.LastMaterials);
      ItemSorting._layerList.Add(ItemSorting.ItemSortingLayers.LastTilesImportant);
      ItemSorting._layerList.Add(ItemSorting.ItemSortingLayers.LastTilesCommon);
      ItemSorting._layerList.Add(ItemSorting.ItemSortingLayers.LastNotTrash);
      ItemSorting._layerList.Add(ItemSorting.ItemSortingLayers.LastTrash);
    }

    private static void Sort(Item[] inv, params int[] ignoreSlots)
    {
      ItemSorting.SetupSortingPriorities();
      List<int> intList1 = new List<int>();
      for (int index = 0; index < inv.Length; ++index)
      {
        if (!((IEnumerable<int>) ignoreSlots).Contains<int>(index))
        {
          Item obj = inv[index];
          if (obj != null && obj.stack != 0 && (obj.type != 0 && !obj.favorited))
            intList1.Add(index);
        }
      }
      for (int index1 = 0; index1 < intList1.Count; ++index1)
      {
        Item obj1 = inv[intList1[index1]];
        if (obj1.stack < obj1.maxStack)
        {
          int num1 = obj1.maxStack - obj1.stack;
          for (int index2 = index1; index2 < intList1.Count; ++index2)
          {
            if (index1 != index2)
            {
              Item obj2 = inv[intList1[index2]];
              if (obj1.type == obj2.type && obj2.stack != obj2.maxStack)
              {
                int num2 = obj2.stack;
                if (num1 < num2)
                  num2 = num1;
                obj1.stack += num2;
                obj2.stack -= num2;
                num1 -= num2;
                if (obj2.stack == 0)
                {
                  inv[intList1[index2]] = new Item();
                  intList1.Remove(intList1[index2]);
                  --index1;
                  int num3 = index2 - 1;
                  break;
                }
                if (num1 == 0)
                  break;
              }
            }
          }
        }
      }
      List<int> intList2 = new List<int>((IEnumerable<int>) intList1);
      for (int index = 0; index < inv.Length; ++index)
      {
        if (!((IEnumerable<int>) ignoreSlots).Contains<int>(index) && !intList2.Contains(index))
        {
          Item obj = inv[index];
          if (obj == null || obj.stack == 0 || obj.type == 0)
            intList2.Add(index);
        }
      }
      intList2.Sort();
      List<int> intList3 = new List<int>();
      List<int> intList4 = new List<int>();
      foreach (ItemSorting.ItemSortingLayer layer in ItemSorting._layerList)
      {
        List<int> intList5 = layer.SortingMethod(layer, inv, intList1);
        if (intList5.Count > 0)
          intList4.Add(intList5.Count);
        intList3.AddRange((IEnumerable<int>) intList5);
      }
      intList3.AddRange((IEnumerable<int>) intList1);
      List<Item> objList = new List<Item>();
      foreach (int index in intList3)
      {
        objList.Add(inv[index]);
        inv[index] = new Item();
      }
      float num4 = 1f / (float) intList4.Count;
      float hue = num4 / 2f;
      for (int index1 = 0; index1 < objList.Count; ++index1)
      {
        int index2 = intList2[0];
        ItemSlot.SetGlow(index2, hue, Main.player[Main.myPlayer].chest != -1);
        List<int> intList5 = intList4;
        int index3 = 0;
        int num1 = intList5[index3];
        int index4 = 0;
        int num2 = num1 - 1;
        intList5[index4] = num2;
        if (intList4[0] == 0)
        {
          intList4.RemoveAt(0);
          hue += num4;
        }
        inv[index2] = objList[index1];
        intList2.Remove(index2);
      }
    }

    public static void SortInventory()
    {
      ItemSorting.Sort(Main.player[Main.myPlayer].inventory, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 50, 51, 52, 53, 54, 55, 56, 57, 58);
    }

    public static void SortChest()
    {
      int chest = Main.player[Main.myPlayer].chest;
      if (chest == -1)
        return;
      Item[] inv = Main.player[Main.myPlayer].bank.item;
      if (chest == -3)
        inv = Main.player[Main.myPlayer].bank2.item;
      if (chest == -4)
        inv = Main.player[Main.myPlayer].bank3.item;
      if (chest > -1)
        inv = Main.chest[chest].item;
      Tuple<int, int, int>[] tupleArray1 = new Tuple<int, int, int>[40];
      for (int index = 0; index < 40; ++index)
        tupleArray1[index] = Tuple.Create<int, int, int>(inv[index].netID, inv[index].stack, (int) inv[index].prefix);
      ItemSorting.Sort(inv);
      Tuple<int, int, int>[] tupleArray2 = new Tuple<int, int, int>[40];
      for (int index = 0; index < 40; ++index)
        tupleArray2[index] = Tuple.Create<int, int, int>(inv[index].netID, inv[index].stack, (int) inv[index].prefix);
      if (Main.netMode != 1 || Main.player[Main.myPlayer].chest <= -1)
        return;
      for (int index = 0; index < 40; ++index)
      {
        if (tupleArray2[index] != tupleArray1[index])
          NetMessage.SendData(32, -1, -1, (NetworkText) null, Main.player[Main.myPlayer].chest, (float) index, 0.0f, 0.0f, 0, 0, 0);
      }
    }

    private class ItemSortingLayer
    {
      public readonly string Name;
      public readonly Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>> SortingMethod;

      public ItemSortingLayer(string name, Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>> method)
      {
        this.Name = name;
        this.SortingMethod = method;
      }

      public void Validate(ref List<int> indexesSortable, Item[] inv)
      {
        List<int> list;
        if (!ItemSorting._layerWhiteLists.TryGetValue(this.Name, out list))
          return;
        indexesSortable = indexesSortable.Where<int>((Func<int, bool>) (i => list.Contains(inv[i].netID))).ToList<int>();
      }

      public override string ToString()
      {
        return this.Name;
      }
    }

    private class ItemSortingLayers
    {
      public static ItemSorting.ItemSortingLayer WeaponsMelee = new ItemSorting.ItemSortingLayer("Weapons - Melee", new Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>(ItemSorting.ItemSortingLayers.\u003C\u003Ec.\u003C\u003E9.\u003C\u002Ecctor\u003Eb__40_0));
      public static ItemSorting.ItemSortingLayer WeaponsRanged = new ItemSorting.ItemSortingLayer("Weapons - Ranged", new Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>(ItemSorting.ItemSortingLayers.\u003C\u003Ec.\u003C\u003E9.\u003C\u002Ecctor\u003Eb__40_3));
      public static ItemSorting.ItemSortingLayer WeaponsMagic = new ItemSorting.ItemSortingLayer("Weapons - Magic", new Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>(ItemSorting.ItemSortingLayers.\u003C\u003Ec.\u003C\u003E9.\u003C\u002Ecctor\u003Eb__40_6));
      public static ItemSorting.ItemSortingLayer WeaponsMinions = new ItemSorting.ItemSortingLayer("Weapons - Minions", new Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>(ItemSorting.ItemSortingLayers.\u003C\u003Ec.\u003C\u003E9.\u003C\u002Ecctor\u003Eb__40_9));
      public static ItemSorting.ItemSortingLayer WeaponsThrown = new ItemSorting.ItemSortingLayer("Weapons - Thrown", new Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>(ItemSorting.ItemSortingLayers.\u003C\u003Ec.\u003C\u003E9.\u003C\u002Ecctor\u003Eb__40_12));
      public static ItemSorting.ItemSortingLayer WeaponsAssorted = new ItemSorting.ItemSortingLayer("Weapons - Assorted", new Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>(ItemSorting.ItemSortingLayers.\u003C\u003Ec.\u003C\u003E9.\u003C\u002Ecctor\u003Eb__40_15));
      public static ItemSorting.ItemSortingLayer WeaponsAmmo = new ItemSorting.ItemSortingLayer("Weapons - Ammo", new Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>(ItemSorting.ItemSortingLayers.\u003C\u003Ec.\u003C\u003E9.\u003C\u002Ecctor\u003Eb__40_18));
      public static ItemSorting.ItemSortingLayer ToolsPicksaws = new ItemSorting.ItemSortingLayer("Tools - Picksaws", new Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>(ItemSorting.ItemSortingLayers.\u003C\u003Ec.\u003C\u003E9.\u003C\u002Ecctor\u003Eb__40_21));
      public static ItemSorting.ItemSortingLayer ToolsHamaxes = new ItemSorting.ItemSortingLayer("Tools - Hamaxes", new Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>(ItemSorting.ItemSortingLayers.\u003C\u003Ec.\u003C\u003E9.\u003C\u002Ecctor\u003Eb__40_24));
      public static ItemSorting.ItemSortingLayer ToolsPickaxes = new ItemSorting.ItemSortingLayer("Tools - Pickaxes", new Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>(ItemSorting.ItemSortingLayers.\u003C\u003Ec.\u003C\u003E9.\u003C\u002Ecctor\u003Eb__40_27));
      public static ItemSorting.ItemSortingLayer ToolsAxes = new ItemSorting.ItemSortingLayer("Tools - Axes", new Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>(ItemSorting.ItemSortingLayers.\u003C\u003Ec.\u003C\u003E9.\u003C\u002Ecctor\u003Eb__40_30));
      public static ItemSorting.ItemSortingLayer ToolsHammers = new ItemSorting.ItemSortingLayer("Tools - Hammers", new Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>(ItemSorting.ItemSortingLayers.\u003C\u003Ec.\u003C\u003E9.\u003C\u002Ecctor\u003Eb__40_33));
      public static ItemSorting.ItemSortingLayer ToolsTerraforming = new ItemSorting.ItemSortingLayer("Tools - Terraforming", new Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>(ItemSorting.ItemSortingLayers.\u003C\u003Ec.\u003C\u003E9.\u003C\u002Ecctor\u003Eb__40_36));
      public static ItemSorting.ItemSortingLayer ToolsAmmoLeftovers = new ItemSorting.ItemSortingLayer("Weapons - Ammo Leftovers", new Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>(ItemSorting.ItemSortingLayers.\u003C\u003Ec.\u003C\u003E9.\u003C\u002Ecctor\u003Eb__40_39));
      public static ItemSorting.ItemSortingLayer ArmorCombat = new ItemSorting.ItemSortingLayer("Armor - Combat", new Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>(ItemSorting.ItemSortingLayers.\u003C\u003Ec.\u003C\u003E9.\u003C\u002Ecctor\u003Eb__40_42));
      public static ItemSorting.ItemSortingLayer ArmorVanity = new ItemSorting.ItemSortingLayer("Armor - Vanity", new Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>(ItemSorting.ItemSortingLayers.\u003C\u003Ec.\u003C\u003E9.\u003C\u002Ecctor\u003Eb__40_45));
      public static ItemSorting.ItemSortingLayer ArmorAccessories = new ItemSorting.ItemSortingLayer("Armor - Accessories", new Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>(ItemSorting.ItemSortingLayers.\u003C\u003Ec.\u003C\u003E9.\u003C\u002Ecctor\u003Eb__40_48));
      public static ItemSorting.ItemSortingLayer EquipGrapple = new ItemSorting.ItemSortingLayer("Equip - Grapple", new Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>(ItemSorting.ItemSortingLayers.\u003C\u003Ec.\u003C\u003E9.\u003C\u002Ecctor\u003Eb__40_51));
      public static ItemSorting.ItemSortingLayer EquipMount = new ItemSorting.ItemSortingLayer("Equip - Mount", new Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>(ItemSorting.ItemSortingLayers.\u003C\u003Ec.\u003C\u003E9.\u003C\u002Ecctor\u003Eb__40_54));
      public static ItemSorting.ItemSortingLayer EquipCart = new ItemSorting.ItemSortingLayer("Equip - Cart", new Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>(ItemSorting.ItemSortingLayers.\u003C\u003Ec.\u003C\u003E9.\u003C\u002Ecctor\u003Eb__40_57));
      public static ItemSorting.ItemSortingLayer EquipLightPet = new ItemSorting.ItemSortingLayer("Equip - Light Pet", new Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>(ItemSorting.ItemSortingLayers.\u003C\u003Ec.\u003C\u003E9.\u003C\u002Ecctor\u003Eb__40_60));
      public static ItemSorting.ItemSortingLayer EquipVanityPet = new ItemSorting.ItemSortingLayer("Equip - Vanity Pet", new Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>(ItemSorting.ItemSortingLayers.\u003C\u003Ec.\u003C\u003E9.\u003C\u002Ecctor\u003Eb__40_63));
      public static ItemSorting.ItemSortingLayer PotionsLife = new ItemSorting.ItemSortingLayer("Potions - Life", new Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>(ItemSorting.ItemSortingLayers.\u003C\u003Ec.\u003C\u003E9.\u003C\u002Ecctor\u003Eb__40_66));
      public static ItemSorting.ItemSortingLayer PotionsMana = new ItemSorting.ItemSortingLayer("Potions - Mana", new Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>(ItemSorting.ItemSortingLayers.\u003C\u003Ec.\u003C\u003E9.\u003C\u002Ecctor\u003Eb__40_69));
      public static ItemSorting.ItemSortingLayer PotionsElixirs = new ItemSorting.ItemSortingLayer("Potions - Elixirs", new Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>(ItemSorting.ItemSortingLayers.\u003C\u003Ec.\u003C\u003E9.\u003C\u002Ecctor\u003Eb__40_72));
      public static ItemSorting.ItemSortingLayer PotionsBuffs = new ItemSorting.ItemSortingLayer("Potions - Buffs", new Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>(ItemSorting.ItemSortingLayers.\u003C\u003Ec.\u003C\u003E9.\u003C\u002Ecctor\u003Eb__40_75));
      public static ItemSorting.ItemSortingLayer PotionsDyes = new ItemSorting.ItemSortingLayer("Potions - Dyes", new Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>(ItemSorting.ItemSortingLayers.\u003C\u003Ec.\u003C\u003E9.\u003C\u002Ecctor\u003Eb__40_78));
      public static ItemSorting.ItemSortingLayer PotionsHairDyes = new ItemSorting.ItemSortingLayer("Potions - Hair Dyes", new Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>(ItemSorting.ItemSortingLayers.\u003C\u003Ec.\u003C\u003E9.\u003C\u002Ecctor\u003Eb__40_81));
      public static ItemSorting.ItemSortingLayer MiscValuables = new ItemSorting.ItemSortingLayer("Misc - Importants", new Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>(ItemSorting.ItemSortingLayers.\u003C\u003Ec.\u003C\u003E9.\u003C\u002Ecctor\u003Eb__40_84));
      public static ItemSorting.ItemSortingLayer MiscWiring = new ItemSorting.ItemSortingLayer("Misc - Wiring", new Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>(ItemSorting.ItemSortingLayers.\u003C\u003Ec.\u003C\u003E9.\u003C\u002Ecctor\u003Eb__40_87));
      public static ItemSorting.ItemSortingLayer MiscMaterials = new ItemSorting.ItemSortingLayer("Misc - Materials", new Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>(ItemSorting.ItemSortingLayers.\u003C\u003Ec.\u003C\u003E9.\u003C\u002Ecctor\u003Eb__40_90));
      public static ItemSorting.ItemSortingLayer MiscExtractinator = new ItemSorting.ItemSortingLayer("Misc - Extractinator", new Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>(ItemSorting.ItemSortingLayers.\u003C\u003Ec.\u003C\u003E9.\u003C\u002Ecctor\u003Eb__40_93));
      public static ItemSorting.ItemSortingLayer MiscPainting = new ItemSorting.ItemSortingLayer("Misc - Painting", new Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>(ItemSorting.ItemSortingLayers.\u003C\u003Ec.\u003C\u003E9.\u003C\u002Ecctor\u003Eb__40_96));
      public static ItemSorting.ItemSortingLayer MiscRopes = new ItemSorting.ItemSortingLayer("Misc - Ropes", new Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>(ItemSorting.ItemSortingLayers.\u003C\u003Ec.\u003C\u003E9.\u003C\u002Ecctor\u003Eb__40_99));
      public static ItemSorting.ItemSortingLayer LastMaterials = new ItemSorting.ItemSortingLayer("Last - Materials", new Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>(ItemSorting.ItemSortingLayers.\u003C\u003Ec.\u003C\u003E9.\u003C\u002Ecctor\u003Eb__40_102));
      public static ItemSorting.ItemSortingLayer LastTilesImportant = new ItemSorting.ItemSortingLayer("Last - Tiles (Frame Important)", new Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>(ItemSorting.ItemSortingLayers.\u003C\u003Ec.\u003C\u003E9.\u003C\u002Ecctor\u003Eb__40_105));
      public static ItemSorting.ItemSortingLayer LastTilesCommon = new ItemSorting.ItemSortingLayer("Last - Tiles (Common), Walls", new Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>(ItemSorting.ItemSortingLayers.\u003C\u003Ec.\u003C\u003E9.\u003C\u002Ecctor\u003Eb__40_108));
      public static ItemSorting.ItemSortingLayer LastNotTrash = new ItemSorting.ItemSortingLayer("Last - Not Trash", new Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>(ItemSorting.ItemSortingLayers.\u003C\u003Ec.\u003C\u003E9.\u003C\u002Ecctor\u003Eb__40_111));
      public static ItemSorting.ItemSortingLayer LastTrash = new ItemSorting.ItemSortingLayer("Last - Trash", new Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>(ItemSorting.ItemSortingLayers.\u003C\u003Ec.\u003C\u003E9.\u003C\u002Ecctor\u003Eb__40_114));
    }
  }
}
