using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utill;



[CreateAssetMenu(fileName = "Enemy", menuName = "Characters/Enemy")]
public class EnemySO : ScriptableObject
{
    public int Health;

    // 캐릭터의 속도 기준 , 해당값에 곱해짐으로 캐릭터의 동작시 속도의 결과값이 됨 
    [field: SerializeField][field: Range(0f, 25f)] public float BaseSpeed { get; private set; } = 5f;

    //타겟 추적시 속도 배율 ,  baseSpeed에 곱해질 값
    [field: SerializeField][field: Range(0f, 2f)] public float ChaseSpeedModifier { get; private set; } = 1.0f;

    // 회전 속도
    [field: SerializeField][field: Range(0f, 25f)] public float BaseRotationDamping { get; private set; } = 1f;
    [field: SerializeField] public TargetSearchData TargetSearchData { get; private set; }
    [field: SerializeField] public PlayerAttackData AttackData { get; private set; }
}
