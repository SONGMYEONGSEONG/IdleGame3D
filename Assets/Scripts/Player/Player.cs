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
    public PlayerEnemySearch EnemySearch { get; private set; }
    private PlayerStateMachine stateMachine;

    private void Awake()
    {
        AnimationData.Initialize();
        Anim = GetComponentInChildren<Animator>();
        CharacterController = GetComponent<CharacterController>();
        EnemySearch = GetComponent<PlayerEnemySearch>();

        stateMachine = new PlayerStateMachine(this);
        stateMachine.ChangeState(stateMachine.IdleState);
    }

    private void Update()
    {
        //stateMachine.HandleInput();
        stateMachine.Update();
       
        //Debug
        if (Input.GetKeyDown(KeyCode.Q))
        {
            stateMachine.ChangeState(stateMachine.WalkState);
            Debug.Log($"WalkState 변경완료");
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            stateMachine.ChangeState(stateMachine.RunState);
            Debug.Log($"RunState 변경완료");
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            stateMachine.ChangeState(stateMachine.IdleState);
            Debug.Log($"IdleState 변경완료");
        }
    }

    private void FixedUpdate()
    {
        stateMachine.PhysicsUpdate();
    }

    private void LateUpdate()
    {
        Data.Target = EnemySearch.EnemySearch();
    }
}
