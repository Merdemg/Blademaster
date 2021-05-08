using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRandomization : MonoBehaviour
{
    [SerializeField] bool isSolo = true;
    [SerializeField] int level = 1;
    EnemyLevel enemyLevel = null;
    [SerializeField] Renderer renderer = null;
    [SerializeField] IDamagable damagable = null;

    // Start is called before the first frame update
    void Start()
    {
        if (isSolo) {
            InitEnemy(level);
        }
    }

    public void InitEnemy(int Level) {
        this.level = Level;

        enemyLevel = EnemyManager.Instance.GetEnemyInfo(this.level);

        if (enemyLevel != null) {
            if (renderer) {
                renderer.material.color = enemyLevel.color;
            }

            if (damagable == null) {
                damagable = GetComponent<IDamagable>();
            }
            damagable.SetHealth(enemyLevel.hitPoints);
            damagable.SetXPReward(enemyLevel.xpReward);

        }
        else {
            Debug.LogWarning("Enemy level info could not be recieved");
        }
    }
}
