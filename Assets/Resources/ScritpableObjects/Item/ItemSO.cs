using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ItemType
{
    Consumable, //소비
    Equip //장착 
}

public enum ItemStatusValue
{
    Health, //체력
    Mana, //마나
    Damage, //데미지
    Speed, //스피드
}

[System.Serializable]
public class ItemData
{
    public ItemStatusValue ItemStatusType; //해당 스테이터스에 적용되는 타입
    public bool IsValuePercent; // 적용되는 수치가 퍼센트로 적용되는지 체크하는 변수
    public int ItemValueAmount; // 적용될시 수치량
}

[CreateAssetMenu(fileName = "Item", menuName = "Item/Default")]
public class ItemSO : ScriptableObject
{
    public int ItemID; // 아이템의 고유번호
    public ItemType ItemType; //아이템의 타입 ex)장착,소비
    public bool IsEquip; // 장착유무 체크
    public string ItemName; //아이템의 이름
    public string ItemDesc; //아이템의 설명
    public Sprite ItemSprite; //아이템의 이미지
    public ItemData[] ItemEffect; //아이템 사용시,장착시 적용되는 효과들
   
}
