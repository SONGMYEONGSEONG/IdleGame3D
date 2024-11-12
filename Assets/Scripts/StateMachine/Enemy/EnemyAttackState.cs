using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utill;

public class EnemyAttackState : EnemyBastState
{
    public EnemyAttackState(EnemyStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.MovementSpeedModifier = 0f;
        base.Enter();
        StartAnimation(stateMachine.Enemy.AnimationData.AttackParameterHash);
        StartAnimation(stateMachine.Enemy.AnimationData.ComboAttackParameterHash);
        stateMachine.Enemy.OnEnableAttackArea();
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Enemy.AnimationData.ComboAttackParameterHash);
        StopAnimation(stateMachine.Enemy.AnimationData.AttackParameterHash);
    }

    public override void Update()
    {
        //To Do Code : 플레이어가 쓰러지거나 , 해당 캐릭터가 죽으면 사라직
        //DieState 만들것 

        float normalizedTime = GetNormalizedTime(stateMachine.Enemy.Anim, "Attack");
        if (normalizedTime >= 1f)
        {
            stateMachine.IsAttacking = false;
            stateMachine.Enemy.OnDisAbleAttackArea();
            stateMachine.ChangeState(stateMachine.IdleState);
        }
        else
        {
            base.Update();
        }
  
    }
}
