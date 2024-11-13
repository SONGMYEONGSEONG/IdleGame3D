using System;
using UnityEngine;

//유니티 컴포넌트로 사용하지 않아도 될것같아 Monobehaviour를 상속해지하였음
public class HealthSystem
{ 
    [SerializeField] private int maxHealth;
    private int curHealth;
    public int CurHealth { get => curHealth; }

    public event Action OnDie;
    public bool IsDead => curHealth == 0;

    public HealthSystem(int maxHealth)
    {
        this.maxHealth = maxHealth;
        curHealth = this.maxHealth;
    }

    public void OnDamage(int damage)
    {
        if (curHealth == 0) return;

        curHealth = Mathf.Max(curHealth - damage, 0);

        if (curHealth == 0) OnDie?.Invoke();
    }


}