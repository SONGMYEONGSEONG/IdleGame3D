using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utill;

public class AttackArea : MonoBehaviour
{
    public LayerMask AttackTarget;
    public event Action<int> OnEventTakeDamage; //데미지를 입었을때 동작하는 이벤트 함수입니다.\
    private IDamageAble myAttackinterface; //

    private void Awake()
    {
        myAttackinterface = GetComponentInParent<IDamageAble>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if ( AttackTarget == (1 << other.gameObject.layer | AttackTarget))
        {
            if(other.TryGetComponent(out IDamageAble hitTarget))
            {
                hitTarget.TakeDamage(myAttackinterface.GetCurrentAttackDamage());
            }
        }
    }
}
