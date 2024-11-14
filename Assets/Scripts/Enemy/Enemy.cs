using System;
using UnityEngine;
using Utill;

public class Enemy : MonoBehaviour, IDamageAble , IObjectPoolAble<Enemy>
{
    [field: SerializeField] public EnemySO Data { get; private set; }

    [field: Header("Animations")]
    //Player와 Enemy의 애니메이션 데이터가 비슷해서 class 재활용 
    [field: SerializeField] public PlayerAnimationData AnimationData { get; private set; }

    public Animator Anim { get; private set; }
    public CharacterController CharacterController { get; private set; }
    public TargetSearch PlayerSearch { get; private set; }
    public AttackArea AttackArea { get; private set; }
    public DamageIndicator DamageIndicator { get; private set; }
    private EnemyStateMachine stateMachine; //Enemy 전용 StateMachine으로 변경 

    public event Action OnEventDie;
    public event Action<Enemy> ReturnToPoolObject;

    public HealthSystem Health;
    public float StageModifier = 1.0f;

    private void Awake()
    {
        AnimationData.Initialize();
        Anim = GetComponentInChildren<Animator>();
        CharacterController = GetComponent<CharacterController>();
        PlayerSearch = GetComponent<TargetSearch>();
        AttackArea = GetComponentInChildren<AttackArea>();
        DamageIndicator = GetComponentInChildren<DamageIndicator>();

        stateMachine = new EnemyStateMachine(this);
        stateMachine.ChangeState(stateMachine.IdleState);

        AttackArea.OnEventTakeDamage += TakeDamage;
        OnDisAbleAttackArea();

        Health = new HealthSystem(Data.Health,Data.MaxHealth,Data.MaxHealth,Data.MaxMana);
        Health.OnDie += OnDie;
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

    public void TakeDamage(int damage)
    {
        Health.OnDamage(damage);
        DamageIndicator.PrintDamage(damage);
    }

    public int GetCurrentAttackDamage()
    {
        float damageResult = stateMachine.AttackState.AttackInfoData.Damage * StageModifier;
        return (int)(stateMachine.AttackState.AttackInfoData.Damage + damageResult);
    }

    void OnDie()
    {
        Anim.SetTrigger("Die");
        enabled = false;

        //Enemy가 죽음으로써 플레이어의 재화를 증가시켜줌
        GameManager.Instance.Player.Data.curCoin += Data.DropGold;
        GameManager.Instance.Player.PlayerGainExp(Data.DropExp);
        DropItem();

        Stage.Instance.EnemyCount++;

        Invoke("ObjectDestroy", 0.3f);
    }

    private void DropItem()
    {
        int dropItemIndex = UnityEngine.Random.Range(0,Data.DropItemList.Length);
        GameManager.Instance.Player._Inventory.GainItem(Data.DropItemList[dropItemIndex]);
    }

    private void ObjectDestroy()
    {
        ReturnToPoolObject?.Invoke(this);

        Anim.SetTrigger("Respawn");
        stateMachine.ChangeState(stateMachine.IdleState);
        Health.Respawn();
        enabled = true;

    }
}
