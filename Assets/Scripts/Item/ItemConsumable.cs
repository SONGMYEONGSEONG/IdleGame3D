using System;
using UnityEngine;
using Utill;

public class ItemConsumable : ItemBase
{
    public ItemConsumable(ItemSO data) : base(data)
    {
    }

    public override void EquipItem()
    {
        Debug.Log($"{ItemData.ItemType} 입니다.");
        Debug.Log($"{ItemData.ItemName} 입니다.");
    }

    public override void UseItem()
    {
        Debug.Log($"{ItemData.ItemType} 입니다.");
        Debug.Log($"{ItemData.ItemName} 입니다.");
    }
}
