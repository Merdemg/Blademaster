using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    static PowerUpManager instance;

    public static PowerUpManager Instance {
        get { if (instance == null) instance = FindObjectOfType<PowerUpManager>(); return instance; }
    }


    [SerializeField] List<PowerUp> powerUps = new List<PowerUp>();
    PowerUp activePowerUp = null;

    public PowerUp GetRandomPowerUp() {
        return powerUps[Random.Range(0, powerUps.Count)];
    }

    public void ActivatePowerUp(PowerUp PowerUp) {
        Debug.Log("Activating power up");

        if (activePowerUp != null) {
            activePowerUp.Deactivate();
        }

        activePowerUp = PowerUp;
        PowerUp.Activate();
    }
}
