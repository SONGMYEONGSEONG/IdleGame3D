using System;
using UnityEngine;

[System.Serializable]
public class PlayerAnimationData
{
    //ĳ���Ͱ� ���� �������� ����
    [SerializeField] private string groundParameterName = "@Ground";//@ �� �ش� �ִϸ��̼� ���̾�� ���ٴ� �ǹ̸� ����
    [SerializeField] private string idleParameterName = "Idle";
    [SerializeField] private string walkParameterName = "Walk";
    [SerializeField] private string runParameterName = "Run";
    public int GroundParameterHash { get; private set; }
    public int IdleParameterHash { get; private set; }
    public int WalkParameterHash { get; private set; }
    public int RunParameterHash { get; private set; }

    //ĳ���Ͱ� ���߿� ������ ����
    [SerializeField] private string airParameterName = "@Air";
    [SerializeField] private string jumpParameterName = "Jump";
    [SerializeField] private string fallParameterName = "Fall";
    public int AirParameterHash { get; private set; }
    public int JumpParameterHash { get; private set; }
    public int FallParameterHash { get; private set; }

    //ĳ���Ͱ� ���� �Ҷ� ����
    [SerializeField] private string attackParameterName = "@Attack";
    [SerializeField] private string comboAttackParameterName = "ComboAttack";
    public int AttackParameterHash { get; private set; }
    public int ComboAttackParameterHash { get; private set; }

    public void Initialize()
    {
        GroundParameterHash = Animator.StringToHash(groundParameterName);
        IdleParameterHash = Animator.StringToHash(idleParameterName);
        WalkParameterHash = Animator.StringToHash(walkParameterName);
        RunParameterHash = Animator.StringToHash(runParameterName);

        AirParameterHash = Animator.StringToHash(airParameterName);
        JumpParameterHash = Animator.StringToHash(jumpParameterName);
        FallParameterHash = Animator.StringToHash(fallParameterName);

        AttackParameterHash = Animator.StringToHash(attackParameterName);
        ComboAttackParameterHash = Animator.StringToHash(comboAttackParameterName);
    }
}