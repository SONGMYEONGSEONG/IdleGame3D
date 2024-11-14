using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utill;

public class Stage : MonoBehaviour
{
    [SerializeField] private List<ObjectPoolData<Enemy>> prefabes;

   
    public float SpawnTime = 4.0f;
    public float StageNum = 1.0f;

    public GameObject SpawnAreaObject;
    public Collider SpawnArea;

    private void Awake()
    {
        ObjectPoolManager.Instance.EnemyObjectPools.Initialize(prefabes);
    }

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private Vector3 RandomSpawn()
    {
        Vector3 originPosition = SpawnAreaObject.transform.position;
        // 콜라이더의 사이즈를 가져오는 bound.size 사용
        float range_X = SpawnArea.bounds.size.x;
        float range_Z = SpawnArea.bounds.size.z;

        range_X = UnityEngine.Random.Range((range_X / 2) * -1, range_X / 2);
        range_Z = UnityEngine.Random.Range((range_Z / 2) * -1, range_Z / 2);
        Vector3 RandomPostion = new Vector3(range_X, 0f, range_Z);

        Vector3 respawnPosition = originPosition + RandomPostion;
        return respawnPosition;
    }

    IEnumerator SpawnEnemy()
    {
        while(true)
        {
            ObjectPoolManager.Instance.EnemyObjectPools.PoolObject("Enemy", RandomSpawn());

            yield return new WaitForSeconds(SpawnTime);
        }
        
    }
}

