using UnityEngine;

public interface IDamagable
{
    void TakeDamage(float Damage);
    void Die();
    void SetHealth(float Health);
    void SetXPReward(int _XP);

    void SpawnDamageCanvas(Vector3 Pos, string Text);
}