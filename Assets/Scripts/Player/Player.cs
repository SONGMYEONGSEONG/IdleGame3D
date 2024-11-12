using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class Player : MonoBehaviour
{
    [field: SerializeField] public PlayerSO Data {  get; private set; }

    [field : Header("Animations")]
    [field : SerializeField] public PlayerAnimationData AnimationData { get; private set; }

    public Animator Anim { get; private set; }
    public CharacterController CharacterController { get; private set; }
    public TargetSearch EnemySearch { get; private set; }
    private PlayerStateMachine stateMachine;

    private void Awake()
    {
        AnimationData.Initialize();
        Anim = GetComponentInChildren<Animator>();
        CharacterController = GetComponent<CharacterController>();
        EnemySearch = GetComponent<TargetSearch>();

        stateMachine = new PlayerStateMachine(this);
        stateMachine.ChangeState(stateMachine.RunState);
    }

    private void Start()
    {
        EnemySearch.Radius = Data.TargetSearchData.Distance;
    }

    private void Update()
    {
        stateMachine.Update();      
    }

    private void FixedUpdate()
    {
        stateMachine.PhysicsUpdate();
    }

    private void LateUpdate()
    {
        stateMachine.Player.EnemySearch.OnTargetSearch();

        if (stateMachine.Player.EnemySearch.ShortEnemyTarget != null && Data.AttackData.AttackDist >= Vector3.Distance(stateMachine.Player.EnemySearch.ShortEnemyTarget.transform.position,transform.position))
        {
            stateMachine.IsAttacking = true;
        }
        else
        {
            stateMachine.IsAttacking = false;
            stateMachine.ChangeState(stateMachine.RunState);
        }
    }
}
