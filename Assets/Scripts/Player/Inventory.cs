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

    public void GainItem(ItemSO GainItemData)
    {
        //장비아이템인지 체크
        if(GainItemData.ItemType == ItemType.Equip)
        {
            //현재 소유하고있는 아이템 중에 장착아이템 중복유무가 있는경우 함수 종료
            if(curItemList.Find(x => GainItemData.ItemID == x.ItemID))
            {
                return;
            }
        }

        curItemList.Add(GainItemData);
    }
}

