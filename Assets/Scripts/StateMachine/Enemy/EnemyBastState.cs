using UnityEngine;
using Utill;

//Enemy의 FSM의 상태의 부모클래스가가 되는  EnemyBastState 코드
//해당 코드는 BaseState에 Move가 default로 구현되어있음 
public class EnemyBastState : IState
{
    protected EnemyStateMachine stateMachine;
    protected readonly PlayerGroundData groundData;

    public EnemyBastState(EnemyStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
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
        stateMachine.Enemy.Anim.SetBool(animatorHash, true);
    }

    protected void StopAnimation(int animatorHash)
    {
        stateMachine.Enemy.Anim.SetBool(animatorHash, false);
    }


    private void Move()
    {
        Vector3 movementDirection = GetMovementDirection();

        Move(movementDirection);

        Rotate(movementDirection);
    }

    private void Rotate(Vector3 direction)
    {
        if (direction != Vector3.zero)
        {
            Transform playerTransform = stateMachine.Enemy.transform;
            Vector3 Newdirection = new Vector3(direction.x, 0, direction.z);
            Quaternion targetRotation = Quaternion.LookRotation(Newdirection);
            playerTransform.rotation = Quaternion.Slerp(playerTransform.rotation, targetRotation, stateMachine.RotationDamping * Time.deltaTime);
            
        }
    }

    private Vector3 GetMovementDirection()
    {

        if (stateMachine.Enemy.PlayerSearch.ShortEnemyTarget != null)
        {
            Vector3 TargetPos = stateMachine.Enemy.PlayerSearch.ShortEnemyTarget.transform.position;

            Vector3 targetDir = (TargetPos - stateMachine.Enemy.transform.position).normalized;
            return targetDir;
        }
        else
        {
            return stateMachine.Enemy.transform.forward;
        }

    }

    private void Move(Vector3 direction)
    {
        float movementSpeed = GetMovementSpeed();
        //캐릭터컨트롤러 컴포넌트에는 Move라는 내부 메서드가 기본적으로 생성되어있음
        stateMachine.Enemy.CharacterController.Move((direction * movementSpeed) * Time.deltaTime);

        //중력처리
        Vector3 velocity = new Vector3(0, -9.81f, 0);
        stateMachine.Enemy.CharacterController.Move(velocity);
    }

    private float GetMovementSpeed()
    {
        float movementSpeed = stateMachine.MovementSpeed * stateMachine.MovementSpeedModifier;
        return movementSpeed;
    }

    //애니메이션이 어디쯤 진행 되고 있는지 반환하는 함수
    //공격이 가능한 시점 또는 콤보가 가능한지 체크해주는 메서드 
    protected float GetNormalizedTime(Animator animator, string tag)
    {
        AnimatorStateInfo currentInfo = animator.GetCurrentAnimatorStateInfo(0);//현재 애니메이션 인포 ,(0)은 레이어 인덱스를 의미
        AnimatorStateInfo nextInfo = animator.GetNextAnimatorStateInfo(0);

        //전환되고 있을때 && 다음 애니메이션 tag
        if (animator.IsInTransition(0) && nextInfo.IsTag(tag))
        {
            return nextInfo.normalizedTime;
        }
        //전환되고 있지 않을때 && 현재 애니메이션 tag
        else if (!animator.IsInTransition(0) && currentInfo.IsTag(tag))
        {
            return currentInfo.normalizedTime;
        }
        else
        {
            return 0f;
        }


    }
}
