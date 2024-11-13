using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<ItemSO> curItemList = new List<ItemSO>();

    public List<ItemSO> CurItemList { get => curItemList; }

    public void Initialize(List<ItemSO> itemList)
    {
        curItemList = itemList;
    }

    public void DeleteInventoryItem(int ItemID)
    {
        CurItemList.Remove(CurItemList.Find(x => ItemID == x.ItemID));
    }
}

