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
        for (int i = 0; i < ItemData.ItemEffect.Length; i++)
        {
            switch (ItemData.ItemEffect[i].ItemStatusType)
            {
                case ItemStatusValue.Health:
                    if (ItemData.ItemEffect[i].IsValuePercent)
                    {
                        int resultValue = (int)(GameManager.Instance.Player.Health.MaxHealth * (ItemData.ItemEffect[i].ItemValueAmount * 0.01f));
                        GameManager.Instance.Player.Health.Heal(resultValue);
                    }
                    else
                    {
                        GameManager.Instance.Player.Health.Heal(ItemData.ItemEffect[i].ItemValueAmount);
                    }
                    break;
                case ItemStatusValue.Mana:

                    break;
                case ItemStatusValue.Damage:

                    break;
                case ItemStatusValue.Speed:

                    break;
            }
        }
    }
}
