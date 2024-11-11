using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    public Player Player { get; }

    // States
    public PlayerIdleState IdleState { get; private set; }
    public PlayerWalkState WalkState { get; private set; }
    public PlayerRunState RunState { get; private set; }
    public PlayerComboAttackState ComboAttackState { get; private set; }

    public bool IsAttacking { get; set; } //현재 공격중인지 체크하는 필드
    public bool ComboIndex { get; set; } //현재 콤보공격의 인덱스

    //public Vector2 MovementInput { get; set; } // 플레이어 인풋을 사용할경우 동작하는 필드
    public float MovementSpeed { get; private set; }
    public float RotationDamping { get; private set; }
    public float MovementSpeedModifier { get; set; }
    public float JumpForce { get; set; }

    //public Transform MainCamTransform { get; set; }

    public PlayerStateMachine(Player player)
    {
        this.Player = player;

        IdleState = new PlayerIdleState(this);
        WalkState = new PlayerWalkState(this);
        RunState = new PlayerRunState(this);
        ComboAttackState = new PlayerComboAttackState(this);

        //MainCamTransform = Camera.main.transform;
        MovementSpeed = player.Data.GroundData.BaseSpeed;
        RotationDamping = player.Data.GroundData.BaseRotationDamping;
    }

}
