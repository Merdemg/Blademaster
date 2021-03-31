using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawn : MonoBehaviour
{
    [SerializeField] int minNumOfEnemies;
    [SerializeField] int maxNumOfEnemies;

    [SerializeField] int levelOfEnemies;

    [SerializeField] EnemyRandomization enemyRand = null;

    [SerializeField] List<Transform> spawnPositions = new List<Transform>();

    //[SerializeField] float enemyColliderSize = 2f;
    //[SerializeField] LayerMask layerMask;

    private void Start() {
        int numOfEnemies = Random.Range(minNumOfEnemies, maxNumOfEnemies);

        for (int i = 0; i < numOfEnemies; i++) {
            if (i <= spawnPositions.Count) {
                Vector3 spawnPosActual = spawnPositions[i].position;
                EnemyRandomization newEnemy = Instantiate(enemyRand.gameObject, spawnPosActual, Quaternion.identity).GetComponent<EnemyRandomization>();
                newEnemy.InitEnemy(levelOfEnemies);
            }
            else {
                Debug.LogWarning("Not enough spawn positions are assigned.");
            }
        }
    }
}
