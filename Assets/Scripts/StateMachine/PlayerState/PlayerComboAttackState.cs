using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utill;
public class PlayerComboAttackState : PlayerAttackState
{
    private bool alreadyApplyCombo;

    AttackInfoData attackInfoData;

    public PlayerComboAttackState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(stateMachine.Player.AnimationData.ComboAttackParameterHash);

        alreadyApplyCombo = false;

        int comboindex = stateMachine.ComboIndex;
        attackInfoData = stateMachine.Player.Data.AttackData.GetAttackInfo(comboindex);
        stateMachine.Player.Anim.SetInteger("Combo", comboindex);

        stateMachine.Player.OnEnableAttackArea();
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Player.AnimationData.ComboAttackParameterHash);

        if (!alreadyApplyCombo)
        {
            stateMachine.ComboIndex = 0; //콤보 초기화
        }

    }

    public override void PhysicsUpdate()
    {

    }
    private void TryComboAttack()
    {
        if (alreadyApplyCombo) return;

        if (attackInfoData.ComboStateIndex == -1) return;

        if (!stateMachine.IsAttacking) return;

        alreadyApplyCombo = true;
    }


    public override void Update()
    {
        base.Update();

        float normalizedTime = GetNormalizedTime(stateMachine.Player.Anim, "Attack");
        if (normalizedTime < 1f)
        {
            TryComboAttack();
        }
        else
        {
            stateMachine.Player.OnDisAbleAttackArea();

            if (alreadyApplyCombo)
            {
                stateMachine.Player.OnEnableAttackArea();
                stateMachine.ComboIndex = attackInfoData.ComboStateIndex;
                stateMachine.ChangeState(stateMachine.ComboAttackState);
            }
            else
            {
                stateMachine.ChangeState(stateMachine.IdleState);
            }
        }
    }

}

