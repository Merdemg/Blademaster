using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamagable
{
    float Health = 100;
    int xpReward = 0;


    public void TakeDamage(float Damage) {
        Health -= Damage;
        Debug.Log("Enemy took " + Damage + " damage! Health is now: " + Health);

        if (Health <= 0) {
            Die();
        }
    }
    public void Die() {
        PlayerLevel.Instance.GetXP(xpReward);
        Destroy(gameObject);
    }

    public void SetHealth(float Health) {
        this.Health = Health;
    }

    public void SetXPReward(int _XP) {
        xpReward = _XP;
    }
}
