using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class EnemyStateMachine : StateMachine
{
    public Enemy Enemy { get; }

    // State
    public EnemyIdleState IdleState { get; private set; }
    public EnemyChaseState ChaseState { get; private set; }
    public EnemyAttackState AttackState { get; private set; }
    //public EnemyComboAttackState ComboAttackState { get; private set; }

    public bool IsAttacking { get; set; } //현재 공격중인지 체크하는 필드

    public float MovementSpeed { get; private set; }
    public float RotationDamping { get; private set; }
    public float MovementSpeedModifier { get; set; }
    public float JumpForce { get; set; }


    public EnemyStateMachine(Enemy enemy)
    {
        this.Enemy = enemy;

        IdleState = new EnemyIdleState(this);
        ChaseState = new EnemyChaseState(this);
        AttackState = new EnemyAttackState(this);
        //ComboAttackState = new EnemyComboAttackState(this);

        MovementSpeed = enemy.Data.BaseSpeed;
        RotationDamping = enemy.Data.BaseRotationDamping;
    }

}
