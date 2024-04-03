using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnInterval = 2f;
    private float nextSpawnTime;
    private Transform helm;
    public float spawnRadius = 10f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time < nextSpawnTime){

            return;
        }
        SpawnEnemy();
    }

    private void SpawnEnemy(){
        if(helm == null){
            getPlayer();

        }
        Vector2 spawnPos = helm.position;
        spawnPos += Random.insideUnitCircle.normalized *spawnRadius;

        GameObject enemy = EnemyPoolManager.Instance.GetEnemy();
        enemy.transform.position = spawnPos;
        nextSpawnTime = Time.time + spawnInterval;
    }
    void getPlayer(){
        helm = GameManager.Instance.getPlayer.transform;
    }
}
