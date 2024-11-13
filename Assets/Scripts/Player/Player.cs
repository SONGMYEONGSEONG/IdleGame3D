using System;
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



    private void Awake()
    {
        GameManager.Instance.Player = this;

        AnimationData.Initialize();
        Anim = GetComponentInChildren<Animator>();
        CharacterController = GetComponent<CharacterController>();
        EnemySearch = GetComponent<TargetSearch>();
        AttackArea = GetComponentInChildren<AttackArea>();
        DamageIndicator = GetComponentInChildren<DamageIndicator>();

        stateMachine = new PlayerStateMachine(this);
        stateMachine.ChangeState(stateMachine.RunState);

        AttackArea.OnEventTakeDamage += TakeDamage;
        OnDisAbleAttackArea();

        Health = new HealthSystem(Data.Health, Data.MaxHealth, Data.MaxHealth, Data.MaxMana);
        Health.OnDie += OnDie;
    }

    private void Start()
    {
        EnemySearch.Radius = Data.TargetSearchData.Distance;

        //TestCode 
        Data.Inventory.Add(ItemManager.Instance.GetItem<ItemEquip>(2000).ItemData);

        Debug.Log("ItemSet");
        //
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

    public float Heal(int value)
    {
        throw new NotImplementedException();
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
