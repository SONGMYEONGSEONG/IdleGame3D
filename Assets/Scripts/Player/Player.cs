using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using Utill;

public class Player : MonoBehaviour, IDamageAble
{
    [field: SerializeField] public PlayerSO Data {  get; private set; }

    [field : Header("Animations")]
    [field : SerializeField] public PlayerAnimationData AnimationData { get; private set; }

    public Animator Anim { get; private set; }
    public CharacterController CharacterController { get; private set; }
    public TargetSearch EnemySearch { get; private set; }
    public AttackArea AttackArea { get; private set; }
    private PlayerStateMachine stateMachine;

    public event Action OnEventDie;

    private void Awake()
    {
        AnimationData.Initialize();
        Anim = GetComponentInChildren<Animator>();
        CharacterController = GetComponent<CharacterController>();
        EnemySearch = GetComponent<TargetSearch>();
        AttackArea = GetComponentInChildren<AttackArea>();

        stateMachine = new PlayerStateMachine(this);
        stateMachine.ChangeState(stateMachine.RunState);

        AttackArea.OnEventTakeDamage += TakeDamage;
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

    public void OnEnableAttackArea()
    {
        AttackArea.gameObject.SetActive(true);
    }

    public void OnDisAbleAttackArea()
    {
        AttackArea.gameObject.SetActive(false);
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
