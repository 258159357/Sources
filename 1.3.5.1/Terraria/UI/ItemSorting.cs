// Decompiled with JetBrains decompiler
// Type: Terraria.UI.ItemSorting
// Assembly: TerrariaServer, Version=1.3.5.1, Culture=neutral, PublicKeyToken=null
// MVID: 5CBA2320-074B-43F7-8CDC-BF1E2B81EE4B
// Assembly location: C:\Users\kevzhao\Downloads\TerrariaServer.exe

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
        List<int> intList2 = itemSortingLayer.SortingMethod.Invoke(itemSortingLayer, array, intList1);
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
        List<int> intList5 = layer.SortingMethod.Invoke(layer, inv, intList1);
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
      float num = 1f / (float) intList4.Count;
      float hue = num / 2f;
      for (int index1 = 0; index1 < objList.Count; ++index1)
      {
        int index2 = intList2[0];
        ItemSlot.SetGlow(index2, hue, Main.player[Main.myPlayer].chest != -1);
        List<int> intList5;
        (intList5 = intList4)[0] = intList5[0] - 1;
        if (intList4[0] == 0)
        {
          intList4.RemoveAt(0);
          hue += num;
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
        tupleArray1[index] = (Tuple<int, int, int>) Tuple.Create<int, int, int>((M0) inv[index].netID, (M1) inv[index].stack, (M2) (int) inv[index].prefix);
      ItemSorting.Sort(inv);
      Tuple<int, int, int>[] tupleArray2 = new Tuple<int, int, int>[40];
      for (int index = 0; index < 40; ++index)
        tupleArray2[index] = (Tuple<int, int, int>) Tuple.Create<int, int, int>((M0) inv[index].netID, (M1) inv[index].stack, (M2) (int) inv[index].prefix);
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
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: variable of a compiler-generated type
        ItemSorting.ItemSortingLayer.\u003C\u003Ec__DisplayClass4 cDisplayClass4 = new ItemSorting.ItemSortingLayer.\u003C\u003Ec__DisplayClass4();
        // ISSUE: reference to a compiler-generated field
        cDisplayClass4.inv = inv;
        // ISSUE: reference to a compiler-generated field
        if (!ItemSorting._layerWhiteLists.TryGetValue(this.Name, out cDisplayClass4.list))
          return;
        // ISSUE: method pointer
        indexesSortable = ((IEnumerable<int>) Enumerable.Where<int>((IEnumerable<M0>) indexesSortable, (Func<M0, bool>) new Func<int, bool>((object) cDisplayClass4, __methodptr(\u003CValidate\u003Eb__3)))).ToList<int>();
      }

      public override string ToString()
      {
        return this.Name;
      }
    }

    private class ItemSortingLayers
    {
      public static ItemSorting.ItemSortingLayer WeaponsMelee;
      public static ItemSorting.ItemSortingLayer WeaponsRanged;
      public static ItemSorting.ItemSortingLayer WeaponsMagic;
      public static ItemSorting.ItemSortingLayer WeaponsMinions;
      public static ItemSorting.ItemSortingLayer WeaponsThrown;
      public static ItemSorting.ItemSortingLayer WeaponsAssorted;
      public static ItemSorting.ItemSortingLayer WeaponsAmmo;
      public static ItemSorting.ItemSortingLayer ToolsPicksaws;
      public static ItemSorting.ItemSortingLayer ToolsHamaxes;
      public static ItemSorting.ItemSortingLayer ToolsPickaxes;
      public static ItemSorting.ItemSortingLayer ToolsAxes;
      public static ItemSorting.ItemSortingLayer ToolsHammers;
      public static ItemSorting.ItemSortingLayer ToolsTerraforming;
      public static ItemSorting.ItemSortingLayer ToolsAmmoLeftovers;
      public static ItemSorting.ItemSortingLayer ArmorCombat;
      public static ItemSorting.ItemSortingLayer ArmorVanity;
      public static ItemSorting.ItemSortingLayer ArmorAccessories;
      public static ItemSorting.ItemSortingLayer EquipGrapple;
      public static ItemSorting.ItemSortingLayer EquipMount;
      public static ItemSorting.ItemSortingLayer EquipCart;
      public static ItemSorting.ItemSortingLayer EquipLightPet;
      public static ItemSorting.ItemSortingLayer EquipVanityPet;
      public static ItemSorting.ItemSortingLayer PotionsLife;
      public static ItemSorting.ItemSortingLayer PotionsMana;
      public static ItemSorting.ItemSortingLayer PotionsElixirs;
      public static ItemSorting.ItemSortingLayer PotionsBuffs;
      public static ItemSorting.ItemSortingLayer PotionsDyes;
      public static ItemSorting.ItemSortingLayer PotionsHairDyes;
      public static ItemSorting.ItemSortingLayer MiscValuables;
      public static ItemSorting.ItemSortingLayer MiscWiring;
      public static ItemSorting.ItemSortingLayer MiscMaterials;
      public static ItemSorting.ItemSortingLayer MiscExtractinator;
      public static ItemSorting.ItemSortingLayer MiscPainting;
      public static ItemSorting.ItemSortingLayer MiscRopes;
      public static ItemSorting.ItemSortingLayer LastMaterials;
      public static ItemSorting.ItemSortingLayer LastTilesImportant;
      public static ItemSorting.ItemSortingLayer LastTilesCommon;
      public static ItemSorting.ItemSortingLayer LastNotTrash;
      public static ItemSorting.ItemSortingLayer LastTrash;

      static ItemSortingLayers()
      {
        string name1 = "Weapons - Melee";
        // ISSUE: reference to a compiler-generated field
        if (ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate7a == null)
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: method pointer
          ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate7a = new Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>((object) null, __methodptr(\u003C\u002Ecctor\u003Eb__6));
        }
        // ISSUE: reference to a compiler-generated field
        Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>> methodDelegate7a = ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate7a;
        ItemSorting.ItemSortingLayers.WeaponsMelee = new ItemSorting.ItemSortingLayer(name1, methodDelegate7a);
        string name2 = "Weapons - Ranged";
        // ISSUE: reference to a compiler-generated field
        if (ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate7b == null)
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: method pointer
          ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate7b = new Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>((object) null, __methodptr(\u003C\u002Ecctor\u003Eb__9));
        }
        // ISSUE: reference to a compiler-generated field
        Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>> methodDelegate7b = ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate7b;
        ItemSorting.ItemSortingLayers.WeaponsRanged = new ItemSorting.ItemSortingLayer(name2, methodDelegate7b);
        string name3 = "Weapons - Magic";
        // ISSUE: reference to a compiler-generated field
        if (ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate7c == null)
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: method pointer
          ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate7c = new Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>((object) null, __methodptr(\u003C\u002Ecctor\u003Eb__c));
        }
        // ISSUE: reference to a compiler-generated field
        Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>> methodDelegate7c = ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate7c;
        ItemSorting.ItemSortingLayers.WeaponsMagic = new ItemSorting.ItemSortingLayer(name3, methodDelegate7c);
        string name4 = "Weapons - Minions";
        // ISSUE: reference to a compiler-generated field
        if (ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate7d == null)
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: method pointer
          ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate7d = new Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>((object) null, __methodptr(\u003C\u002Ecctor\u003Eb__f));
        }
        // ISSUE: reference to a compiler-generated field
        Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>> methodDelegate7d = ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate7d;
        ItemSorting.ItemSortingLayers.WeaponsMinions = new ItemSorting.ItemSortingLayer(name4, methodDelegate7d);
        string name5 = "Weapons - Thrown";
        // ISSUE: reference to a compiler-generated field
        if (ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate7e == null)
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: method pointer
          ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate7e = new Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>((object) null, __methodptr(\u003C\u002Ecctor\u003Eb__12));
        }
        // ISSUE: reference to a compiler-generated field
        Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>> methodDelegate7e = ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate7e;
        ItemSorting.ItemSortingLayers.WeaponsThrown = new ItemSorting.ItemSortingLayer(name5, methodDelegate7e);
        string name6 = "Weapons - Assorted";
        // ISSUE: reference to a compiler-generated field
        if (ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate7f == null)
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: method pointer
          ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate7f = new Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>((object) null, __methodptr(\u003C\u002Ecctor\u003Eb__15));
        }
        // ISSUE: reference to a compiler-generated field
        Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>> methodDelegate7f = ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate7f;
        ItemSorting.ItemSortingLayers.WeaponsAssorted = new ItemSorting.ItemSortingLayer(name6, methodDelegate7f);
        string name7 = "Weapons - Ammo";
        // ISSUE: reference to a compiler-generated field
        if (ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate80 == null)
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: method pointer
          ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate80 = new Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>((object) null, __methodptr(\u003C\u002Ecctor\u003Eb__18));
        }
        // ISSUE: reference to a compiler-generated field
        Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>> methodDelegate80 = ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate80;
        ItemSorting.ItemSortingLayers.WeaponsAmmo = new ItemSorting.ItemSortingLayer(name7, methodDelegate80);
        string name8 = "Tools - Picksaws";
        // ISSUE: reference to a compiler-generated field
        if (ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate81 == null)
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: method pointer
          ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate81 = new Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>((object) null, __methodptr(\u003C\u002Ecctor\u003Eb__1b));
        }
        // ISSUE: reference to a compiler-generated field
        Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>> methodDelegate81 = ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate81;
        ItemSorting.ItemSortingLayers.ToolsPicksaws = new ItemSorting.ItemSortingLayer(name8, methodDelegate81);
        string name9 = "Tools - Hamaxes";
        // ISSUE: reference to a compiler-generated field
        if (ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate82 == null)
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: method pointer
          ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate82 = new Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>((object) null, __methodptr(\u003C\u002Ecctor\u003Eb__1e));
        }
        // ISSUE: reference to a compiler-generated field
        Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>> methodDelegate82 = ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate82;
        ItemSorting.ItemSortingLayers.ToolsHamaxes = new ItemSorting.ItemSortingLayer(name9, methodDelegate82);
        string name10 = "Tools - Pickaxes";
        // ISSUE: reference to a compiler-generated field
        if (ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate83 == null)
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: method pointer
          ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate83 = new Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>((object) null, __methodptr(\u003C\u002Ecctor\u003Eb__21));
        }
        // ISSUE: reference to a compiler-generated field
        Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>> methodDelegate83 = ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate83;
        ItemSorting.ItemSortingLayers.ToolsPickaxes = new ItemSorting.ItemSortingLayer(name10, methodDelegate83);
        string name11 = "Tools - Axes";
        // ISSUE: reference to a compiler-generated field
        if (ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate84 == null)
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: method pointer
          ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate84 = new Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>((object) null, __methodptr(\u003C\u002Ecctor\u003Eb__24));
        }
        // ISSUE: reference to a compiler-generated field
        Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>> methodDelegate84 = ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate84;
        ItemSorting.ItemSortingLayers.ToolsAxes = new ItemSorting.ItemSortingLayer(name11, methodDelegate84);
        string name12 = "Tools - Hammers";
        // ISSUE: reference to a compiler-generated field
        if (ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate85 == null)
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: method pointer
          ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate85 = new Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>((object) null, __methodptr(\u003C\u002Ecctor\u003Eb__27));
        }
        // ISSUE: reference to a compiler-generated field
        Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>> methodDelegate85 = ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate85;
        ItemSorting.ItemSortingLayers.ToolsHammers = new ItemSorting.ItemSortingLayer(name12, methodDelegate85);
        string name13 = "Tools - Terraforming";
        // ISSUE: reference to a compiler-generated field
        if (ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate86 == null)
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: method pointer
          ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate86 = new Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>((object) null, __methodptr(\u003C\u002Ecctor\u003Eb__2a));
        }
        // ISSUE: reference to a compiler-generated field
        Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>> methodDelegate86 = ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate86;
        ItemSorting.ItemSortingLayers.ToolsTerraforming = new ItemSorting.ItemSortingLayer(name13, methodDelegate86);
        string name14 = "Weapons - Ammo Leftovers";
        // ISSUE: reference to a compiler-generated field
        if (ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate87 == null)
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: method pointer
          ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate87 = new Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>((object) null, __methodptr(\u003C\u002Ecctor\u003Eb__2d));
        }
        // ISSUE: reference to a compiler-generated field
        Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>> methodDelegate87 = ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate87;
        ItemSorting.ItemSortingLayers.ToolsAmmoLeftovers = new ItemSorting.ItemSortingLayer(name14, methodDelegate87);
        string name15 = "Armor - Combat";
        // ISSUE: reference to a compiler-generated field
        if (ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate88 == null)
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: method pointer
          ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate88 = new Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>((object) null, __methodptr(\u003C\u002Ecctor\u003Eb__30));
        }
        // ISSUE: reference to a compiler-generated field
        Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>> methodDelegate88 = ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate88;
        ItemSorting.ItemSortingLayers.ArmorCombat = new ItemSorting.ItemSortingLayer(name15, methodDelegate88);
        string name16 = "Armor - Vanity";
        // ISSUE: reference to a compiler-generated field
        if (ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate89 == null)
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: method pointer
          ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate89 = new Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>((object) null, __methodptr(\u003C\u002Ecctor\u003Eb__33));
        }
        // ISSUE: reference to a compiler-generated field
        Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>> methodDelegate89 = ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate89;
        ItemSorting.ItemSortingLayers.ArmorVanity = new ItemSorting.ItemSortingLayer(name16, methodDelegate89);
        string name17 = "Armor - Accessories";
        // ISSUE: reference to a compiler-generated field
        if (ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate8a == null)
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: method pointer
          ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate8a = new Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>((object) null, __methodptr(\u003C\u002Ecctor\u003Eb__36));
        }
        // ISSUE: reference to a compiler-generated field
        Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>> methodDelegate8a = ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate8a;
        ItemSorting.ItemSortingLayers.ArmorAccessories = new ItemSorting.ItemSortingLayer(name17, methodDelegate8a);
        string name18 = "Equip - Grapple";
        // ISSUE: reference to a compiler-generated field
        if (ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate8b == null)
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: method pointer
          ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate8b = new Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>((object) null, __methodptr(\u003C\u002Ecctor\u003Eb__39));
        }
        // ISSUE: reference to a compiler-generated field
        Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>> methodDelegate8b = ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate8b;
        ItemSorting.ItemSortingLayers.EquipGrapple = new ItemSorting.ItemSortingLayer(name18, methodDelegate8b);
        string name19 = "Equip - Mount";
        // ISSUE: reference to a compiler-generated field
        if (ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate8c == null)
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: method pointer
          ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate8c = new Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>((object) null, __methodptr(\u003C\u002Ecctor\u003Eb__3c));
        }
        // ISSUE: reference to a compiler-generated field
        Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>> methodDelegate8c = ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate8c;
        ItemSorting.ItemSortingLayers.EquipMount = new ItemSorting.ItemSortingLayer(name19, methodDelegate8c);
        string name20 = "Equip - Cart";
        // ISSUE: reference to a compiler-generated field
        if (ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate8d == null)
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: method pointer
          ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate8d = new Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>((object) null, __methodptr(\u003C\u002Ecctor\u003Eb__3f));
        }
        // ISSUE: reference to a compiler-generated field
        Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>> methodDelegate8d = ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate8d;
        ItemSorting.ItemSortingLayers.EquipCart = new ItemSorting.ItemSortingLayer(name20, methodDelegate8d);
        string name21 = "Equip - Light Pet";
        // ISSUE: reference to a compiler-generated field
        if (ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate8e == null)
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: method pointer
          ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate8e = new Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>((object) null, __methodptr(\u003C\u002Ecctor\u003Eb__42));
        }
        // ISSUE: reference to a compiler-generated field
        Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>> methodDelegate8e = ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate8e;
        ItemSorting.ItemSortingLayers.EquipLightPet = new ItemSorting.ItemSortingLayer(name21, methodDelegate8e);
        string name22 = "Equip - Vanity Pet";
        // ISSUE: reference to a compiler-generated field
        if (ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate8f == null)
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: method pointer
          ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate8f = new Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>((object) null, __methodptr(\u003C\u002Ecctor\u003Eb__45));
        }
        // ISSUE: reference to a compiler-generated field
        Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>> methodDelegate8f = ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate8f;
        ItemSorting.ItemSortingLayers.EquipVanityPet = new ItemSorting.ItemSortingLayer(name22, methodDelegate8f);
        string name23 = "Potions - Life";
        // ISSUE: reference to a compiler-generated field
        if (ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate90 == null)
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: method pointer
          ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate90 = new Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>((object) null, __methodptr(\u003C\u002Ecctor\u003Eb__48));
        }
        // ISSUE: reference to a compiler-generated field
        Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>> methodDelegate90 = ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate90;
        ItemSorting.ItemSortingLayers.PotionsLife = new ItemSorting.ItemSortingLayer(name23, methodDelegate90);
        string name24 = "Potions - Mana";
        // ISSUE: reference to a compiler-generated field
        if (ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate91 == null)
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: method pointer
          ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate91 = new Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>((object) null, __methodptr(\u003C\u002Ecctor\u003Eb__4b));
        }
        // ISSUE: reference to a compiler-generated field
        Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>> methodDelegate91 = ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate91;
        ItemSorting.ItemSortingLayers.PotionsMana = new ItemSorting.ItemSortingLayer(name24, methodDelegate91);
        string name25 = "Potions - Elixirs";
        // ISSUE: reference to a compiler-generated field
        if (ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate92 == null)
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: method pointer
          ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate92 = new Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>((object) null, __methodptr(\u003C\u002Ecctor\u003Eb__4e));
        }
        // ISSUE: reference to a compiler-generated field
        Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>> methodDelegate92 = ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate92;
        ItemSorting.ItemSortingLayers.PotionsElixirs = new ItemSorting.ItemSortingLayer(name25, methodDelegate92);
        string name26 = "Potions - Buffs";
        // ISSUE: reference to a compiler-generated field
        if (ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate93 == null)
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: method pointer
          ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate93 = new Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>((object) null, __methodptr(\u003C\u002Ecctor\u003Eb__51));
        }
        // ISSUE: reference to a compiler-generated field
        Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>> methodDelegate93 = ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate93;
        ItemSorting.ItemSortingLayers.PotionsBuffs = new ItemSorting.ItemSortingLayer(name26, methodDelegate93);
        string name27 = "Potions - Dyes";
        // ISSUE: reference to a compiler-generated field
        if (ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate94 == null)
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: method pointer
          ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate94 = new Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>((object) null, __methodptr(\u003C\u002Ecctor\u003Eb__54));
        }
        // ISSUE: reference to a compiler-generated field
        Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>> methodDelegate94 = ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate94;
        ItemSorting.ItemSortingLayers.PotionsDyes = new ItemSorting.ItemSortingLayer(name27, methodDelegate94);
        string name28 = "Potions - Hair Dyes";
        // ISSUE: reference to a compiler-generated field
        if (ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate95 == null)
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: method pointer
          ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate95 = new Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>((object) null, __methodptr(\u003C\u002Ecctor\u003Eb__57));
        }
        // ISSUE: reference to a compiler-generated field
        Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>> methodDelegate95 = ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate95;
        ItemSorting.ItemSortingLayers.PotionsHairDyes = new ItemSorting.ItemSortingLayer(name28, methodDelegate95);
        string name29 = "Misc - Importants";
        // ISSUE: reference to a compiler-generated field
        if (ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate96 == null)
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: method pointer
          ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate96 = new Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>((object) null, __methodptr(\u003C\u002Ecctor\u003Eb__5a));
        }
        // ISSUE: reference to a compiler-generated field
        Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>> methodDelegate96 = ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate96;
        ItemSorting.ItemSortingLayers.MiscValuables = new ItemSorting.ItemSortingLayer(name29, methodDelegate96);
        string name30 = "Misc - Wiring";
        // ISSUE: reference to a compiler-generated field
        if (ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate97 == null)
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: method pointer
          ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate97 = new Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>((object) null, __methodptr(\u003C\u002Ecctor\u003Eb__5d));
        }
        // ISSUE: reference to a compiler-generated field
        Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>> methodDelegate97 = ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate97;
        ItemSorting.ItemSortingLayers.MiscWiring = new ItemSorting.ItemSortingLayer(name30, methodDelegate97);
        string name31 = "Misc - Materials";
        // ISSUE: reference to a compiler-generated field
        if (ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate98 == null)
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: method pointer
          ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate98 = new Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>((object) null, __methodptr(\u003C\u002Ecctor\u003Eb__60));
        }
        // ISSUE: reference to a compiler-generated field
        Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>> methodDelegate98 = ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate98;
        ItemSorting.ItemSortingLayers.MiscMaterials = new ItemSorting.ItemSortingLayer(name31, methodDelegate98);
        string name32 = "Misc - Extractinator";
        // ISSUE: reference to a compiler-generated field
        if (ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate99 == null)
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: method pointer
          ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate99 = new Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>((object) null, __methodptr(\u003C\u002Ecctor\u003Eb__63));
        }
        // ISSUE: reference to a compiler-generated field
        Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>> methodDelegate99 = ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate99;
        ItemSorting.ItemSortingLayers.MiscExtractinator = new ItemSorting.ItemSortingLayer(name32, methodDelegate99);
        string name33 = "Misc - Painting";
        // ISSUE: reference to a compiler-generated field
        if (ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate9a == null)
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: method pointer
          ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate9a = new Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>((object) null, __methodptr(\u003C\u002Ecctor\u003Eb__66));
        }
        // ISSUE: reference to a compiler-generated field
        Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>> methodDelegate9a = ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate9a;
        ItemSorting.ItemSortingLayers.MiscPainting = new ItemSorting.ItemSortingLayer(name33, methodDelegate9a);
        string name34 = "Misc - Ropes";
        // ISSUE: reference to a compiler-generated field
        if (ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate9b == null)
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: method pointer
          ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate9b = new Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>((object) null, __methodptr(\u003C\u002Ecctor\u003Eb__69));
        }
        // ISSUE: reference to a compiler-generated field
        Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>> methodDelegate9b = ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate9b;
        ItemSorting.ItemSortingLayers.MiscRopes = new ItemSorting.ItemSortingLayer(name34, methodDelegate9b);
        string name35 = "Last - Materials";
        // ISSUE: reference to a compiler-generated field
        if (ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate9c == null)
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: method pointer
          ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate9c = new Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>((object) null, __methodptr(\u003C\u002Ecctor\u003Eb__6c));
        }
        // ISSUE: reference to a compiler-generated field
        Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>> methodDelegate9c = ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate9c;
        ItemSorting.ItemSortingLayers.LastMaterials = new ItemSorting.ItemSortingLayer(name35, methodDelegate9c);
        string name36 = "Last - Tiles (Frame Important)";
        // ISSUE: reference to a compiler-generated field
        if (ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate9d == null)
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: method pointer
          ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate9d = new Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>((object) null, __methodptr(\u003C\u002Ecctor\u003Eb__6f));
        }
        // ISSUE: reference to a compiler-generated field
        Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>> methodDelegate9d = ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate9d;
        ItemSorting.ItemSortingLayers.LastTilesImportant = new ItemSorting.ItemSortingLayer(name36, methodDelegate9d);
        string name37 = "Last - Tiles (Common), Walls";
        // ISSUE: reference to a compiler-generated field
        if (ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate9e == null)
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: method pointer
          ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate9e = new Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>((object) null, __methodptr(\u003C\u002Ecctor\u003Eb__72));
        }
        // ISSUE: reference to a compiler-generated field
        Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>> methodDelegate9e = ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate9e;
        ItemSorting.ItemSortingLayers.LastTilesCommon = new ItemSorting.ItemSortingLayer(name37, methodDelegate9e);
        string name38 = "Last - Not Trash";
        // ISSUE: reference to a compiler-generated field
        if (ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate9f == null)
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: method pointer
          ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate9f = new Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>((object) null, __methodptr(\u003C\u002Ecctor\u003Eb__75));
        }
        // ISSUE: reference to a compiler-generated field
        Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>> methodDelegate9f = ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegate9f;
        ItemSorting.ItemSortingLayers.LastNotTrash = new ItemSorting.ItemSortingLayer(name38, methodDelegate9f);
        string name39 = "Last - Trash";
        // ISSUE: reference to a compiler-generated field
        if (ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatea0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: method pointer
          ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatea0 = new Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>>((object) null, __methodptr(\u003C\u002Ecctor\u003Eb__78));
        }
        // ISSUE: reference to a compiler-generated field
        Func<ItemSorting.ItemSortingLayer, Item[], List<int>, List<int>> methodDelegatea0 = ItemSorting.ItemSortingLayers.CS\u0024\u003C\u003E9__CachedAnonymousMethodDelegatea0;
        ItemSorting.ItemSortingLayers.LastTrash = new ItemSorting.ItemSortingLayer(name39, methodDelegatea0);
      }
    }
  }
}
