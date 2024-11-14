using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class UIInventory : UIBase
{
    [SerializeField] private Transform ScroolViewTransform;
    private List<UIItemSlot> uIItemSlots = new List<UIItemSlot>();

    private void Awake()
    {
        UIManager.Instance.UISet(this);
    }

    private void OnEnable()
    {
        List<ItemSO> inventory = GameManager.Instance.Player._Inventory.CurItemList;

        UIItemSlot prefeb = Resources.Load<UIItemSlot>("Prefebs/UI/UIItemSlot");

        foreach (ItemSO item in inventory)
        {
            uIItemSlots.Add(Instantiate(prefeb, ScroolViewTransform));

            switch (item.ItemType)
            {
                case ItemType.Consumable:
                    uIItemSlots[uIItemSlots.Count - 1].Initialize(ItemManager.Instance.GetItem<ItemConsumable>(item.ItemID));
                    break;
                case ItemType.Equip:
                    uIItemSlots[uIItemSlots.Count - 1].Initialize(ItemManager.Instance.GetItem<ItemEquip>(item.ItemID));
                    break;
            }

        }
    }

    public void DeleteInventoryItem(int ItemID)
    {
        uIItemSlots.Remove(uIItemSlots.Find(x => ItemID == x.ItemID));
    }

    private void OnDisable()
    {
        //코드 비효유ㅜㄹ적임 고쳐야함 
        foreach (UIItemSlot item in uIItemSlots)
        {
            Destroy(item.gameObject);
        }
        uIItemSlots.Clear();
    }
}
