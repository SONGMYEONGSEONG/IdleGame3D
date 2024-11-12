using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utill
{
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
    public class PlayerAttackData //캐릭터가 공격시 사용되는 데이터
    {
        [field: SerializeField] public float AttackDist { get; private set; } // 타겟과의 공격 거리가 해당 데이터보다 작으면 공격시도
        [field: SerializeField] public List<AttackInfoData> AttackInfoDatas { get; private set; } //공격시 적용되는 콤보 데이터
        public int GetAttackInfoCount() { return AttackInfoDatas.Count; } //콤보 공격 리스트에 들어있는 총 공격 콤보 갯수
        public AttackInfoData GetAttackInfo(int index) { return AttackInfoDatas[index]; } //인자값으로 요청한 콤보공격을 Get하는 메서드
    }

    [Serializable]
    public class AttackInfoData //캐릭터가 콤보공격시 사용되는 데이터
    {
        [field: SerializeField] public string AttackName { get; private set; }
        [field: SerializeField] public int ComboStateIndex { get; private set; } //콤보 순서

        [field: SerializeField] public int Damage;
    }

    [Serializable]
    public class TargetSearchData //캐릭터가 공격할 타겟을 찾을떄 사용되는 데이터 
    {
        [field: SerializeField] public LayerMask TargetLayer; //타겟 대상 레이어
        //[field: SerializeField] public GameObject Target = null; //타겟 대상
        [field: SerializeField] public float Distance; // 타겟 탐색 범위
    }

    [Serializable]
    public class TargetAttackData //캐릭터가 공격시 사용되는 데이터
    {
        [field: SerializeField] public float AttackDist { get; private set; } // 타겟과의 공격 거리가 해당 데이터보다 작으면 공격시도
        [field: SerializeField] public List<AttackInfoData> AttackInfoDatas { get; private set; } //공격시 적용되는 콤보 데이터

    }

}
