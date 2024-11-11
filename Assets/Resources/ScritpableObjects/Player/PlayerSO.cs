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

[CreateAssetMenu(fileName = "Player", menuName = "Characters/Player")]
public class PlayerSO : ScriptableObject
{
    [field: SerializeField] public PlayerGroundData GroundData { get; private set; }
    [field: SerializeField] public PlayerAirData AirData { get; private set; }
}