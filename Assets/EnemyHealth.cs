using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamagable
{
    float Health = 100;


    public void TakeDamage(float Damage) {
        Health -= Damage;
        Debug.Log("Enemy took " + Damage + " damage! Health is now: " + Health);

        if (Health <= 0) {
            Die();
        }
    }
    public void Die() {
        Destroy(gameObject);
    }

    public void SetHealth(float Health) {
        this.Health = Health;
    }

}
