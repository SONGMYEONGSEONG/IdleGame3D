using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.Playables;
using Utill;

public class Enemy : MonoBehaviour, IDamageAble
{
    [field: SerializeField] public EnemySO Data { get; private set; }

    [field: Header("Animations")]
    //Player와 Enemy의 애니메이션 데이터가 비슷해서 class 재활용 
    [field: SerializeField] public PlayerAnimationData AnimationData { get; private set; }

    public Animator Anim { get; private set; }
    public CharacterController CharacterController { get; private set; }
    public TargetSearch PlayerSearch { get; private set; }
    public AttackArea AttackArea { get; private set; }
    private EnemyStateMachine stateMachine; //Enemy 전용 StateMachine으로 변경 

    public event Action OnEventDie;

    private void Awake()
    {
        AnimationData.Initialize();
        Anim = GetComponentInChildren<Animator>();
        CharacterController = GetComponent<CharacterController>();
        PlayerSearch = GetComponent<TargetSearch>();
        AttackArea = GetComponentInChildren<AttackArea>();

        stateMachine = new EnemyStateMachine(this);
        stateMachine.ChangeState(stateMachine.IdleState);

        AttackArea.OnEventTakeDamage += TakeDamage;
    }

    private void Start()
    {
        PlayerSearch.Radius = Data.TargetSearchData.Distance;
    }

    private void Update()
    {
        stateMachine.Update();

    }

    public void OnEnableAttackArea()
    {
        AttackArea.gameObject.SetActive(true);
    }

    public void OnDisAbleAttackArea()
    {
        AttackArea.gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        stateMachine.PhysicsUpdate();
    }

    private void LateUpdate()
    {

    }

    public float GetCurretnHealth()
    {
        throw new NotImplementedException();
    }

    public float Heal(float value)
    {
        throw new NotImplementedException();
    }

    public void TakeDamage(float damage)
    {
        Debug.Log($"{gameObject.name} : {damage} Hit");
    }
}
