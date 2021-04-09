using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpHolder : MonoBehaviour
{
    [SerializeField] EnemyHealth enemyHealth = null;
    [SerializeField] Canvas canvas = null;
    [SerializeField] Image powerUpImage = null;

    bool isHoldingPowerUp = false;
    PowerUp powerUp = null;

    public void HoldPowerUp(PowerUp powerUpToHold) {
        isHoldingPowerUp = true;
        powerUp = powerUpToHold;
        powerUpImage.sprite = powerUpToHold.powerUpIcon;
        canvas.enabled = true;
        enemyHealth.onEnemyDeath += OnDeath;
    }

    public void OnDeath() {
        PowerUpManager.Instance.ActivatePowerUp(powerUp);
    }
}
