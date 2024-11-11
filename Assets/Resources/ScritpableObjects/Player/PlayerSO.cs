using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerGroundData // ĳ���Ͱ� ���� ������
{
    [field: SerializeField][field: Range(0f, 25f)] public float BaseSpeed { get; private set; } = 5f; // ĳ������ �ӵ� ���� , �ش簪�� ���������� ĳ������ ���۽� �ӵ��� ������� �� 
    [field: SerializeField][field: Range(0f, 25f)] public float BaseRotationDamping { get; private set; } = 1f; // ȸ�� �ӵ�

    [field: Header("IdleData")]

    [field: Header("WalkData")]
    [field: SerializeField][field: Range(0f, 2f)] public float WalkSpeedModifier { get; private set; } = 0.225f; //�̵��� �ӵ� ���� ,  baseSpeed�� ������ ��

    [field: Header("RunData")]
    [field: SerializeField][field: Range(0f, 2f)] public float RunSpeedModifier { get; private set; } = 1f; //�޸���� �ӵ� ���� ,  baseSpeed�� ������ ��
}

[Serializable]
public class PlayerAirData // ĳ���Ͱ� ���߿� ������
{
    [field: Header("JumpData")]
    [field: SerializeField][field: Range(0f, 25f)] public float JumpForce { get; private set; } = 4f; // ������ ����Ǵ� �Ŀ�

}

[Serializable]
public class PlayerAttackData //ĳ���Ͱ� ���ݽ� ���Ǵ� ������
{
    [field: SerializeField] public List<AttackInfoData> AttackInfoDatas { get; private set; } //���ݽ� ����Ǵ� �޺� ������
    public int GetAttackInfoCount() { return AttackInfoDatas.Count; } //�޺� ���� ����Ʈ�� ����ִ� �� ���� �޺� ����
    public AttackInfoData GetAttackInfo(int index) { return AttackInfoDatas[index]; } //���ڰ����� ��û�� �޺������� Get�ϴ� �޼���
}


[Serializable]
public class AttackInfoData //ĳ���Ͱ� �޺����ݽ� ���Ǵ� ������
{
 
    [field: SerializeField] public string AttackName { get; private set; }
    [field: SerializeField] public string ComboStateIndex { get; private set; } //�޺� ����
    [field: SerializeField][field: Range(0f, 1f)] public float ComboTransitiontTime { get; private set; } //�޺� ���� �ð�
    [field: SerializeField][field: Range(0f, 1f)] public float ForceTransitiontTime { get; private set; } //���ݿ� ���� ���� ��¦ �ڷ� �и��� ������ �ð������� üũ�ϴ� ����
    [field: SerializeField][field: Range(-10f, 10f)] public float Force { get; private set; } //�и��� ����Ǵ� ��
    [field: SerializeField] public int Damage;
    [field: SerializeField][field: Range(0f, 1f)] public float Dealing_Start_TransitionTime { get; private set; }
    [field: SerializeField][field: Range(0f, 1f)] public float Dealing_End_TransitionTime { get; private set; }

}

[CreateAssetMenu(fileName = "Player", menuName = "Characters/Player")]
public class PlayerSO : ScriptableObject
{
    //Debug : EnemySerach�� ���Ǵ� Target �ʵ�
    [field: SerializeField]
    public Collider Target = null;
    [field: SerializeField] public PlayerGroundData GroundData { get; private set; }
    [field: SerializeField] public PlayerAirData AirData { get; private set; }

    [field: SerializeField] public PlayerAttackData AttackData { get; private set; }


}
