using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//전투 중에는 <일점 벙위 안에 적을 찾는 기능>이 켜지면 안됨
//이동중에만 동작해야함 
public class PlayerEnemySearch : MonoBehaviour
{
    public float radius = 0f;
    public LayerMask layer;
    public Collider[] colliders;
    public Collider short_enemy;


    public Collider EnemySearch()
    {
        colliders = Physics.OverlapSphere(transform.position, radius, layer);

        if (colliders.Length > 0)
        {
            float short_distance = Vector3.Distance(transform.position, colliders[0].transform.position);
            foreach (Collider col in colliders)
            {
                float short_distance2 = Vector3.Distance(transform.position, col.transform.position);
                if (short_distance >= short_distance2)
                {
                    short_distance = short_distance2;
                    short_enemy = col;
                }
            }

            return short_enemy;
        }

        return null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}