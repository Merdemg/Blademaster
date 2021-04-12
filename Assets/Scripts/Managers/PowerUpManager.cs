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

    const float POWER_UP_DURATION = 6f;

    Coroutine powerUpCoRoutine = null;

    public PowerUp GetRandomPowerUp() {
        return powerUps[Random.Range(0, powerUps.Count)];
    }

    public void ActivatePowerUp(PowerUp PowerUp) {
        Debug.Log("Activating power up");

        DeactivatePowerUp();

        activePowerUp = PowerUp;
        PowerUp.Activate();
        PlayerCanvas.Instance.SetImage(PowerUp.powerUpIcon);
        powerUpCoRoutine = StartCoroutine(PowerUpCoroutine());
    }

    void DeactivatePowerUp() {
        if (activePowerUp != null) {
            activePowerUp.Deactivate();
        }

        if (powerUpCoRoutine != null) {
            StopCoroutine(powerUpCoRoutine);
            powerUpCoRoutine = null;
        }
    }

    IEnumerator PowerUpCoroutine() {
        float counter = 0;

        while (counter < POWER_UP_DURATION) {
            counter += Time.deltaTime;
            PlayerCanvas.Instance.SetImagePerc((POWER_UP_DURATION - counter) / POWER_UP_DURATION);
            yield return new WaitForEndOfFrame();
        }

        DeactivatePowerUp();
    }
}
