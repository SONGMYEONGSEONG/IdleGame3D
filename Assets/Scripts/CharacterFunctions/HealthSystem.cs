using System;
using UnityEngine;

//유니티 컴포넌트로 사용하지 않아도 될것같아 Monobehaviour를 상속해지하였음
public class HealthSystem //Status Handler로 변경하여 사용할 예정 
{ 
    [SerializeField] private int maxHealth;
    [SerializeField] private int maxMana;
    private int curHealth;
    private int curMana;
    public int CurHealth { get => curHealth; }
    public int CurMana { get => curMana; }

    public event Action OnDie;
    public bool IsDead => curHealth == 0;

    public int MaxHealth { get => maxHealth; set => maxHealth = value; }
    public int MaxMana { get => maxMana; set => maxMana = value; }

    public HealthSystem(int health, int maxHealth, int mana, int maxMana)
    {
        this.maxHealth = maxHealth;
        this.curHealth = health;

        this.maxMana = maxMana;
        this.curMana = mana;
    }

    public void OnDamage(int damage)
    {
        if (curHealth == 0) return;

        curHealth = Mathf.Max(curHealth - damage, 0);

        if (curHealth == 0) OnDie?.Invoke();
    }

    public void OnEnableMana(int manaCost)
    {
        if (curMana == 0) return;

        curMana = Mathf.Max(curMana - manaCost, 0);

        if (curMana == 0)
            Debug.Log("마나가 모자릅니다."); //UI에 띄울것 
    }

    public void Heal(int value)
    {
        if (curHealth >= maxHealth) return;

        curHealth = Mathf.Min(curHealth + value, maxHealth);
    }

 
}