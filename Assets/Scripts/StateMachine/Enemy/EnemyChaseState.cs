using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseState : EnemyBastState
{
    public EnemyChaseState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine)
    {

    }
    public override void Enter()
    {
        stateMachine.MovementSpeedModifier = stateMachine.Enemy.Data.ChaseSpeedModifier;
        base.Enter();
        StartAnimation(stateMachine.Enemy.AnimationData.RunParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Enemy.AnimationData.RunParameterHash);
    }

    public override void Update()
    {
        //추격하는 대상이 사라지면 Idle 대기로 변경 
        if(stateMachine.Enemy.PlayerSearch.ShortEnemyTarget == null)
        {
            stateMachine.IsAttacking = false;
            stateMachine.ChangeState(stateMachine.IdleState);
        }
        else if (stateMachine.Enemy.Data.AttackData.AttackDist >= Vector3.Distance(stateMachine.Enemy.PlayerSearch.ShortEnemyTarget.transform.position, stateMachine.Enemy.transform.position))
        {
            stateMachine.IsAttacking = true;
            stateMachine.ChangeState(stateMachine.AttackState);
        }
        else
        {
            base.Update();
        }
    }
}
