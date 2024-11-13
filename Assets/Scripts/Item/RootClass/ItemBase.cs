using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBase 
{
    public ItemSO ItemData { get; set; }

    public ItemBase (ItemSO data)
    {
        ItemData = data;
    }

    public virtual void UseItem() { }
    public virtual void EquipItem() { }
}
