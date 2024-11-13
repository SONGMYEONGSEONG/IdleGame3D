using System;
using TreeEditor;
using UnityEngine;
using Utill;
public class ItemEquip : ItemBase
{

    public ItemEquip(ItemSO data) : base(data)
    {
    }


    public override void EquipItem()
    {
        ItemData.IsEquip = !ItemData.IsEquip;

        for(int i = 0; i< ItemData.ItemEffect.Length;i++ )
        {
            switch (ItemData.ItemEffect[i].ItemStatusType)
            {
                case ItemStatusValue.Health:

                    break;
                case ItemStatusValue.Mana:

                    break;
                case ItemStatusValue.Damage:
                    if(ItemData.IsEquip)
                    {
                        GameManager.Instance.Player.Data.ExtraDamage += ItemData.ItemEffect[i].ItemValueAmount;
                    }
                    else
                    {
                        GameManager.Instance.Player.Data.ExtraDamage -= ItemData.ItemEffect[i].ItemValueAmount;
                    }
                    break;
                case ItemStatusValue.Speed:

                    break;
            }
        }
    }

    public override void UseItem()
    {
        Debug.Log($"{ItemData.ItemType} 입니다.");
        Debug.Log($"{ItemData.ItemName} 입니다.");
    }
}
