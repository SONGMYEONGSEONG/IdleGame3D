using Cinemachine;
using System;
using System.Collections.Generic;
using UnityEngine;
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
    public DamageIndicator DamageIndicator { get; private set; }
    private PlayerStateMachine stateMachine;

    public event Action OnEventDie;
    public HealthSystem Health;

    public Inventory _Inventory;
    

    private void Awake()
    {
        GameManager.Instance.Player = this;

        AnimationData.Initialize();
        Anim = GetComponentInChildren<Animator>();
        CharacterController = GetComponent<CharacterController>();
        EnemySearch = GetComponent<TargetSearch>();
        AttackArea = GetComponentInChildren<AttackArea>();
        DamageIndicator = GetComponentInChildren<DamageIndicator>();
        _Inventory = GetComponent<Inventory>();

        stateMachine = new PlayerStateMachine(this);
        stateMachine.ChangeState(stateMachine.RunState);

        AttackArea.OnEventTakeDamage += TakeDamage;
        OnDisAbleAttackArea();

        Health = new HealthSystem(Data.Health, Data.MaxHealth, Data.MaxHealth, Data.MaxMana);
        Health.OnDie += OnDie;

        if (Data.InventoryData.Count > 0)
        {
            _Inventory.Initialize(Data.InventoryData);
        }
        
    }

    private void Start()
    {
        // Player의 자식 버추얼 카메라 찾기
        CinemachineVirtualCamera virtualCamera = GetComponentInChildren<CinemachineVirtualCamera>();
        if (virtualCamera == null)
        {
            Debug.LogError("Player에 Cinemachine Virtual Camera가 없습니다!");
            return;
        }
        // 버추얼 카메라의 활성화 상태를 조절하여 강제로 연결을 업데이트
        virtualCamera.gameObject.SetActive(false);
        virtualCamera.gameObject.SetActive(true);

        Debug.Log("Player와 Virtual Camera가 메인 카메라와 연결되었습니다.");

        EnemySearch.Radius = Data.TargetSearchData.Distance;

    }

    private void OnDestroy()
    {
        //플레이어 객체가 파괴될시 인벤토리를 SO에 저장
        Data.InventoryData = _Inventory.CurItemList;
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

    public void TakeDamage(int damage)
    {
        Health.OnDamage(damage);
        DamageIndicator.PrintDamage(damage);
    }


    public int GetCurrentAttackDamage()
    {
        return stateMachine.ComboAttackState.AttackInfoData.Damage + Data.ExtraDamage;
    }

    void OnDie()
    {
        Anim.SetTrigger("Die");
        enabled = false;
    }
}
