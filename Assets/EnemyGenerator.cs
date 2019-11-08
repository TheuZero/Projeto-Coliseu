using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject[] enemy;
    public GameObject boss;
    int maxEnemy = 4;
    float spawnTimer = 8f;
    public Vector2[] spawnPositions;
    public Vector2[] projectileEnemySpawn;
    public bool bossSpawned;

    bool SpawnCooldown = false;

    void Update(){
        if(!SpawnCooldown)
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy(){
        spawnTimer = 8f;
        while(spawnTimer > 0){
            SpawnCooldown = true;
            spawnTimer -= Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
        SpawnCooldown = false;
        Spawn(Random.Range(0, enemy.Length));
        yield break;
    }

    void Spawn(int enemyNum){
        if(enemyNum == 0)
            Instantiate(enemy[0], spawnPositions[RandomIndex(spawnPositions.Length)], Quaternion.identity, this.gameObject.transform);
        else if(enemyNum == 1){
            Instantiate(enemy[1], spawnPositions[RandomIndex(projectileEnemySpawn.Length)], Quaternion.identity, this.gameObject.transform);
        }
    }
    int RandomIndex(int length){
        return Random.Range(0, length);
    }

}
