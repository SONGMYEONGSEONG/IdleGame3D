using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

//�÷��̾��� FSM�� ������ �θ�Ŭ�������� �Ǵ�  PlayerBaseState �ڵ�
//�ش� �ڵ�� BaseState�� Move�� default�� �����Ǿ����� 
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

    }

    //�ִϸ��̼��� �� ����ϱ⿡ ����,���� �޼��� ����
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

    private Vector3 GetMovementDirection()
    {
        Vector3 forward = stateMachine.MainCamTransform.forward;
        Vector3 right = stateMachine.MainCamTransform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        return forward + right ;
    }

    private void Move(Vector3 direction)
    {
        float movementSpeed = GetMovementSpeed();
        //ĳ������Ʈ�ѷ� ������Ʈ���� Move��� ���� �޼��尡 �⺻������ �����Ǿ�����
        stateMachine.Player.CharacterController.Move((direction * movementSpeed) * Time.deltaTime);
    }

    private float GetMovementSpeed()
    {
        float movementSpeed = stateMachine.MovementSpeed * stateMachine.MovementSpeedModifier;
        return movementSpeed;
    }

}
