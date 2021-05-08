using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PUP_Phase", menuName = "ScriptableObjects/PowerUpPhase", order = 3)]
public class Phase : PowerUp
{
    public override void Activate() {
        base.Activate();
        Debug.Log("Phase activated");
        PlayerColliderController.Instance.SetWallCollider(false);
    }

    public override void Deactivate() {
        base.Deactivate();
        PlayerColliderController.Instance.SetWallCollider(true);
    }
}
