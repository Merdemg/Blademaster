using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRandomization : MonoBehaviour
{
    [SerializeField] int Level = 1;
    EnemyLevel enemyLevel = null;
    [SerializeField] Renderer renderer = null;

    // Start is called before the first frame update
    void Start()
    {
        enemyLevel = EnemyManager.Instance.GetEnemyInfo(Level);

        if (enemyLevel != null) {
            if (renderer) {
                renderer.material.color = enemyLevel.color;
            }
        }
        else {
            Debug.LogWarning("Enemy level info could not be recieved");
        }
    }
}
