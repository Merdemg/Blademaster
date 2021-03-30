using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawn : MonoBehaviour
{
    [SerializeField] int minNumOfEnemies;
    [SerializeField] int maxNumOfEnemies;

    [SerializeField] int levelOfEnemies;

    [SerializeField] EnemyRandomization enemyRand = null;

    [SerializeField] Transform spawnPos = null;

    private void Start() {
        int numOfEnemies = Random.Range(minNumOfEnemies, maxNumOfEnemies);

        for (int i = 0; i < numOfEnemies; i++) {
            EnemyRandomization newEnemy = Instantiate(enemyRand.gameObject, spawnPos.position, Quaternion.identity).GetComponent<EnemyRandomization>();
            newEnemy.InitEnemy(levelOfEnemies);
        }
    }
}
