using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utill;

public class Stage : Singleton<Stage>
{
    [SerializeField] private List<ObjectPoolData<Enemy>> prefabes;

    public int EnemyCount = 0; //해당 스테이지에서 잡은 적의 갯수 
    public int StageClearCount; //스테이지 클리어를 위한 잡은적의 목표 갯수
    public int StageClearCountModifier = 10; //스테이지 클리어를 위한 적갯수배율
    public float SpawnTime = 4.0f;
    public int StageNum = 1;

    public GameObject SpawnAreaObject;
    public Collider SpawnArea;

    protected override void Awake()
    {
        base.Awake();
        ObjectPoolManager.Instance.EnemyObjectPools.Initialize(prefabes);
    }

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
        StageClearCount = StageNum * StageClearCountModifier;
        GameManager.Instance.Player.Data.curStageLevel = StageNum;
        UIManager.Instance.GetUI<UIMain>("UIMain").StageNumberUpadte(StageNum);
    }

    private void LateUpdate()
    {
        if (EnemyCount >= StageClearCount)
        {
            StageNum++;
            StageClearCount = StageNum * StageClearCountModifier + EnemyCount;
            GameManager.Instance.Player.Data.curStageLevel = StageNum;
            UIManager.Instance.GetUI<UIMain>("UIMain").StageNumberUpadte(StageNum);
        }
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
            Enemy newEnemy = ObjectPoolManager.Instance.EnemyObjectPools.PoolObject("Enemy", RandomSpawn());

            float StausModifier = StageNum * 0.1f;
            newEnemy.StageModifier = StausModifier;

            yield return new WaitForSeconds(SpawnTime);
        }
        
    }
}

