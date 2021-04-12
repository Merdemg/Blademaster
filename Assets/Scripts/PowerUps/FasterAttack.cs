using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PUP_FasterAttack", menuName = "ScriptableObjects/PowerUpFasterAttack", order = 1)]
public class FasterAttack : PowerUp
{
    const float SPEED_MULTIPLIER = 1.66f;

    public override void Activate()
    {
        base.Activate();
        Debug.Log("Faster attack activated");
        PlayerDamage.Instance.MultiplyAttackSpeed(SPEED_MULTIPLIER);
    }

    public override void Deactivate()
    {
        base.Deactivate();
        PlayerDamage.Instance.MultiplyAttackSpeed(1f);
    }
}
