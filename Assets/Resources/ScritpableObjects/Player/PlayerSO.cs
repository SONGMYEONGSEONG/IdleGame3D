using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerGroundData // 캐릭터가 지상에 있을때
{
    [field: SerializeField][field: Range(0f, 25f)] public float BaseSpeed { get; private set; } = 5f; // 캐릭터의 속도 기준 , 해당값에 곱해짐으로 캐릭터의 동작시 속도의 결과값이 됨 
    [field: SerializeField][field: Range(0f, 25f)] public float BaseRotationDamping { get; private set; } = 1f; // 회전 속도

    [field: Header("IdleData")]

    [field: Header("WalkData")]
    [field: SerializeField][field: Range(0f, 2f)] public float WalkSpeedModifier { get; private set; } = 0.225f; //이동시 속도 배율 ,  baseSpeed에 곱해질 값

    [field: Header("RunData")]
    [field: SerializeField][field: Range(0f, 2f)] public float RunSpeedModifier { get; private set; } = 1f; //달리기시 속도 배율 ,  baseSpeed에 곱해질 값
}

[Serializable]
public class PlayerAirData // 캐릭터가 공중에 있을때
{
    [field: Header("JumpData")]
    [field: SerializeField][field: Range(0f, 25f)] public float JumpForce { get; private set; } = 4f; // 점프시 적용되는 파워

}

[CreateAssetMenu(fileName = "Player", menuName = "Characters/Player")]
public class PlayerSO : ScriptableObject
{
    [field: SerializeField] public PlayerGroundData GroundData { get; private set; }
    [field: SerializeField] public PlayerAirData AirData { get; private set; }
}
