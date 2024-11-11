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

[Serializable]
public class PlayerAttackData //캐릭터가 공격시 사용되는 데이터
{
    [field: SerializeField] public List<AttackInfoData> AttackInfoDatas { get; private set; } //공격시 적용되는 콤보 데이터
    public int GetAttackInfoCount() { return AttackInfoDatas.Count; } //콤보 공격 리스트에 들어있는 총 공격 콤보 갯수
    public AttackInfoData GetAttackInfo(int index) { return AttackInfoDatas[index]; } //인자값으로 요청한 콤보공격을 Get하는 메서드
}


[Serializable]
public class AttackInfoData //캐릭터가 콤보공격시 사용되는 데이터
{
 
    [field: SerializeField] public string AttackName { get; private set; }
    [field: SerializeField] public string ComboStateIndex { get; private set; } //콤보 순서
    [field: SerializeField][field: Range(0f, 1f)] public float ComboTransitiontTime { get; private set; } //콤보 유지 시간
    [field: SerializeField][field: Range(0f, 1f)] public float ForceTransitiontTime { get; private set; } //공격에 맞은 적은 살짝 뒤로 밀릴때 가능한 시간대인지 체크하는 변수
    [field: SerializeField][field: Range(-10f, 10f)] public float Force { get; private set; } //밀릴때 적용되는 힘
    [field: SerializeField] public int Damage;
    [field: SerializeField][field: Range(0f, 1f)] public float Dealing_Start_TransitionTime { get; private set; }
    [field: SerializeField][field: Range(0f, 1f)] public float Dealing_End_TransitionTime { get; private set; }

}

[CreateAssetMenu(fileName = "Player", menuName = "Characters/Player")]
public class PlayerSO : ScriptableObject
{
    //Debug : EnemySerach에 사용되는 Target 필드
    [field: SerializeField]
    public Collider Target = null;
    [field: SerializeField] public PlayerGroundData GroundData { get; private set; }
    [field: SerializeField] public PlayerAirData AirData { get; private set; }

    [field: SerializeField] public PlayerAttackData AttackData { get; private set; }


}
