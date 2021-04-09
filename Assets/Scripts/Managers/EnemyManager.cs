using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    static EnemyManager instance;
    public static EnemyManager Instance {
        get { if (instance == null) instance = FindObjectOfType<EnemyManager>(); return instance; }
    }

    [SerializeField] List<EnemyLevel> enemyLevels = new List<EnemyLevel>();

    public EnemyLevel GetEnemyInfo(int _Level) {
        foreach (EnemyLevel e in enemyLevels) {
            if (e.level == _Level) {
                return e;
            }
        }

        return null;
    }
}

[System.Serializable]
public class EnemyLevel {
    public int level;
    public float hitPoints;
    public float sizeMultiplier;
    public Color color;
    public int xpReward;
}