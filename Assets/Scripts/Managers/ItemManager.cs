using System;
using System.Collections.Generic;
using UnityEngine;
using Utill;

public class ItemManager : Singleton<ItemManager>
{
    [SerializeField] private List<ItemSO> Items;

    private Dictionary<int, ItemBase> ItemDict = new Dictionary<int, ItemBase>();

    protected override void Awake()
    {
        base.Awake();

        for (int i =0; i < Items.Count; i++)
        {
            ItemBase item = null;
            switch (Items[i].ItemType)
            {
                case ItemType.Consumable:
                    item = new ItemConsumable(Items[i]);
                    break;

                case ItemType.Equip:
                    item = new ItemEquip(Items[i]);
                    break;
            }

            ItemDict.Add(item.ItemData.ItemID, item);
        }
    }

    public T GetItem<T>(int ItemID) where T : ItemBase
    {
        if (ItemDict.ContainsKey(ItemID))
        {
            return ItemDict[ItemID] as T;
        }

        return null;
    }
}

