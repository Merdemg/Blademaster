using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PUP_FasterWalk", menuName = "ScriptableObjects/PowerUpFasterWalk", order = 2)]
public class FasterWalk : PowerUp
{
    const float SPEED_MULTIPLIER = 2f;

    public override void Activate()
    {
        base.Activate();
        Debug.Log("Faster walk activated");
        PlayerMovement.Instance.SetMovementSpeedMultiplier(SPEED_MULTIPLIER);
    }

    public override void Deactivate()
    {
        base.Deactivate();
        PlayerMovement.Instance.SetMovementSpeedMultiplier(1f);
    }
}
