using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamagable
{
    float Health = 100;
    int xpReward = 0;

    [SerializeField] GameObject popUpCanvas = null;
    [SerializeField] Transform popUpSpawnPos = null;

    public delegate void OnEnemyDeath();
    public OnEnemyDeath onEnemyDeath;

    public void TakeDamage(float Damage) {
        Health -= Damage;
        Debug.Log("Enemy took " + Damage + " damage! Health is now: " + Health);

        SpawnDamageCanvas(popUpSpawnPos.position, Mathf.RoundToInt(Damage).ToString());

        if (Health <= 0) {
            Die();
        }
    }

    public void Die() {
        PlayerLevel.Instance.GetXP(xpReward);
        onEnemyDeath?.Invoke();
        Destroy(gameObject);
    }

    public void SetHealth(float Health) {
        this.Health = Health;
    }

    public void SetXPReward(int _XP) {
        xpReward = _XP;
    }

    public void SpawnDamageCanvas(Vector3 Pos, string Text) {
        GameObject obj = Instantiate(popUpCanvas, Pos, Quaternion.identity);
        obj.GetComponent<PopUpCanvas>().SetText(Text);
    }
}
