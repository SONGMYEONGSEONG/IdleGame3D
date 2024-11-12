using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyBastState
{
    public EnemyIdleState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine)
    {

    }
    public override void Enter()
    {
        stateMachine.MovementSpeedModifier = 0f;
        base.Enter();
        StartAnimation(stateMachine.Enemy.AnimationData.IdleParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Enemy.AnimationData.IdleParameterHash);
    }

    public override void Update()
    {
        stateMachine.Enemy.PlayerSearch.OnTargetSearch();

        //플레이어를 발견했을경우 추격 모드로 변경 
        if (stateMachine.Enemy.PlayerSearch.ShortEnemyTarget != null)
        {
            //stateMachine.IsAttacking = true;
            stateMachine.ChangeState(stateMachine.ChaseState);
        }
        else//타겟이 없으면 idle 상태로 유지 
        {
            base.Update();
            //stateMachine.IsAttacking = false;  
            //stateMachine.ChangeState(stateMachine.IdleState);
        }

       
    }
}
