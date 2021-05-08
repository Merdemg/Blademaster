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

    [SerializeField] [RangeAttribute(0, 1f)] float powerUpChance = 0f;

    //[SerializeField] float enemyColliderSize = 2f;
    //[SerializeField] LayerMask layerMask;

    private void Start() {
        int numOfEnemies = Random.Range(minNumOfEnemies, maxNumOfEnemies);

        bool isPowerUp = Random.Range(0f, 1f) < powerUpChance;

        for (int i = 0; i < numOfEnemies; i++) {
            if (i <= spawnPositions.Count) {
                Vector3 spawnPosActual = spawnPositions[i].position;
                EnemyRandomization newEnemy = Instantiate(enemyRand.gameObject, spawnPosActual, Quaternion.identity).GetComponent<EnemyRandomization>();
                newEnemy.InitEnemy(levelOfEnemies);

                if (isPowerUp && i == 0) {
                    newEnemy.GetComponent<PowerUpHolder>().HoldPowerUp(PowerUpManager.Instance.GetRandomPowerUp());
                }
            }
            else {
                Debug.LogWarning("Not enough spawn positions are assigned.");
            }
        }
    }
}
