using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PUP_FasterWalk", menuName = "ScriptableObjects/PowerUp", order = 0)]
public class FasterWalk : PowerUp
{
    const float SPEED_MULTIPLIER = 2f;

    public override void Activate()
    {
        base.Activate();
        PlayerMovement.Instance.SetMovementSpeedMultiplier(SPEED_MULTIPLIER);
    }

    public override void Deactivate()
    {
        base.Deactivate();
        PlayerMovement.Instance.SetMovementSpeedMultiplier(1f);
    }
}
