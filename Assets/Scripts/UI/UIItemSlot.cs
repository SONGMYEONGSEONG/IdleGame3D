using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class UIItemSlot : MonoBehaviour
{
    public int ItemID;
    [SerializeField] private Image ItemIcon;
    [SerializeField] private TextMeshProUGUI ItemName;
    [SerializeField] private TextMeshProUGUI ItemDesc;
    [SerializeField] private Button ItemUseBtn;
    [SerializeField] private TextMeshProUGUI ItemUseBtnText;

    public void Initialize<T>(T ItemData) where T : ItemBase
    {
        ItemID = ItemData.ItemData.ItemID;

        ItemIcon.sprite = ItemData.ItemData.ItemSprite;
        ItemName.text = ItemData.ItemData.ItemName;
        ItemDesc.text = ItemData.ItemData.ItemDesc;

        switch (ItemData.ItemData.ItemType)
        {
            case ItemType.Consumable:
                ItemUseBtn.onClick.AddListener(() => ItemData.UseItem());
                ItemUseBtn.onClick.AddListener(() => GameManager.Instance.Player._Inventory.DeleteInventoryItem(ItemData.ItemData.ItemID));
                ItemUseBtn.onClick.AddListener(() => UIManager.Instance.GetUI<UIInventory>("UIInventory").DeleteInventoryItem(ItemData.ItemData.ItemID));
                ItemUseBtn.onClick.AddListener(() => Destroy(gameObject));
                break;
            case ItemType.Equip:
                IsEquipItemBtnChange(ItemData.ItemData.IsEquip);
                ItemUseBtn.onClick.AddListener(() => ItemData.EquipItem());
                ItemUseBtn.onClick.AddListener(() => IsEquipItemBtnChange(ItemData.ItemData.IsEquip));
                break;
        }
    }

    private void IsEquipItemBtnChange(bool isEquip)
    {
        if(isEquip)
        {
            ItemUseBtnText.text = "장착해제";
        }
        else
        {
            ItemUseBtnText.text = "장착하기";
        }
    }

}
