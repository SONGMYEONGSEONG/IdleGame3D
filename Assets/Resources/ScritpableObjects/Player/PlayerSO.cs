using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utill;



[CreateAssetMenu(fileName = "Player", menuName = "Characters/Player")]
public class PlayerSO : ScriptableObject
{
    public int Health;
    public int MaxHealth;
    public int Mana;
    public int MaxMana;
    public int Level;
    public int Exp;
    public int MaxExp;
    public int curCoin;

    [field: SerializeField] public TargetSearchData TargetSearchData { get; private set; }
    [field: SerializeField] public PlayerGroundData GroundData { get; private set; }
    [field: SerializeField] public PlayerAttackData AttackData { get; private set; }


}
