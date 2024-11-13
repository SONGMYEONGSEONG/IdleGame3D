using System;
using UnityEngine;
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
    public DamageIndicator DamageIndicator { get; private set; }
    private EnemyStateMachine stateMachine; //Enemy 전용 StateMachine으로 변경 

    public event Action OnEventDie;
    public HealthSystem Health;

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

        Health = new HealthSystem(Data.Health,Data.MaxHealth);
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

    private void LateUpdate()
    {

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
        return stateMachine.AttackState.AttackInfoData.Damage;
    }

    void OnDie()
    {
        Anim.SetTrigger("Die");
        enabled = false;

        Invoke("ObjectDestroy", 0.3f);
    }

    private void ObjectDestroy()
    {
        //objectpool로 대체될것 
        Destroy(this.gameObject);
    }
}
