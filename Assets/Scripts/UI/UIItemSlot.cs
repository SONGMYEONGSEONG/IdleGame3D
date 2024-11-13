using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIItemSlot : MonoBehaviour
{
    public bool Test;

    [SerializeField] private Image ItemIcon;
    [SerializeField] private TextMeshProUGUI ItemName;
    [SerializeField] private TextMeshProUGUI ItemDesc;
    [SerializeField] private Button ItemUseBtn;


    private void Start()
    {
        if(Test)
        {
            //Debug
            ItemEquip item = ItemManager.Instance.GetItem<ItemEquip>(2000);
            ItemIcon.sprite = item.ItemData.ItemSprite;
            ItemName.text = item.ItemData.ItemName;
            ItemDesc.text = item.ItemData.ItemDesc;


            ItemUseBtn.onClick.AddListener(() => item.EquipItem());
        }
        else
        {
            //Debug
            ItemConsumable item = ItemManager.Instance.GetItem<ItemConsumable>(1000);
            ItemIcon.sprite = item.ItemData.ItemSprite;
            ItemName.text = item.ItemData.ItemName;
            ItemDesc.text = item.ItemData.ItemDesc;


            ItemUseBtn.onClick.AddListener(() => item.UseItem());
        }
        

    }

}
