using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    static PlayerLevel instance;

    public static PlayerLevel Instance {
        get { if (instance == null) instance = FindObjectOfType<PlayerLevel>(); return instance; }
    }


    int playerLevel = 1;
    int experience = 0;

    int experienceRequired = 2;

    float xpRequirementMultiplierPerLevel = 1.5f;
    float damageMultiplierPerLevel = 1.5f;

    PlayerDamage playerDamage;

    private void Start() {
        playerDamage = GetComponent<PlayerDamage>();
    }


    public void GetXP(int _XP) {
        experience += _XP;
        Debug.Log("Got " + _XP + " XP!");

        while (experience >= experienceRequired) {
            LevelUp();
        }
    }

    void LevelUp() {
        Debug.Log("Level Up!");
        playerLevel++;
        experience -= experienceRequired;
        if (experience < 0) {
            experience = 0;
        }

        experienceRequired = Mathf.RoundToInt((float)experienceRequired * xpRequirementMultiplierPerLevel);
        playerDamage.MultiplyBaseDamage(damageMultiplierPerLevel);
    }


}
