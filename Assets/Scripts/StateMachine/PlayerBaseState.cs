using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

//플레이어의 FSM의 상태의 부모클래스가가 되는  PlayerBaseState 코드
//해당 코드는 BaseState에 Move가 default로 구현되어있음 
public class PlayerBaseState : IState
{
    protected PlayerStateMachine stateMachine;
    protected readonly PlayerGroundData groundData;

    public PlayerBaseState(PlayerStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
        groundData = stateMachine.Player.Data.GroundData;
    }

    public virtual void Enter()
    {

    }

    public virtual void Exit()
    {

    }

    public virtual void PhysicsUpdate()
    {

    }

    public virtual void Update()
    {
        Move();
    }

    //애니메이션은 다 사용하기에 시작,정지 메서드 생성
    protected void StartAnimation(int animatorHash)
    {
        stateMachine.Player.Anim.SetBool(animatorHash, true);
    }

    protected void StopAnimation( int  animatorHash)
    {
        stateMachine.Player.Anim.SetBool(animatorHash, false);
    }


    private void Move()
    {
        Vector3 movementDirection = GetMovementDirection();

        Move(movementDirection);

        Rotate(movementDirection);
    }

    private void Rotate(Vector3 direction)
    {
       if(direction != Vector3.zero)
        {
            Transform playerTransform = stateMachine.Player.transform;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            playerTransform.rotation = Quaternion.Slerp(playerTransform.rotation, targetRotation, stateMachine.RotationDamping * Time.deltaTime);
        }
    }

    //private Vector3 GetMovementDirection()
    //{
    //    //Vector3 forward = stateMachine.MainCamTransform.forward;
    //    //Vector3 right = stateMachine.MainCamTransform.right;
    //    Vector3 forward = stateMachine.Player.transform.forward;
    //    Vector3 right = stateMachine.Player.transform.right;

    //    forward.y = 0;
    //    right.y = 0;

    //    forward.Normalize();
    //    right.Normalize();

    //    return forward + right ;
    //}

    private Vector3 GetMovementDirection()
    {

        if (stateMachine.Player.Data.Target != null)
        {
            Vector3 TargetPos = stateMachine.Player.Data.Target.transform.position;

            Vector3 targetDir = (TargetPos - stateMachine.Player.transform.position).normalized;
            return targetDir;
        }
        else
        {
            return stateMachine.Player.transform.forward;
        }
        
    }

    private void Move(Vector3 direction)
    {
        float movementSpeed = GetMovementSpeed();
        //캐릭터컨트롤러 컴포넌트에는 Move라는 내부 메서드가 기본적으로 생성되어있음
        stateMachine.Player.CharacterController.Move((direction * movementSpeed) * Time.deltaTime);
    }

    private float GetMovementSpeed()
    {
        float movementSpeed = stateMachine.MovementSpeed * stateMachine.MovementSpeedModifier;
        return movementSpeed;
    }

}
