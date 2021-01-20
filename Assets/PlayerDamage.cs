using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    float damageFrequency = 0.25f;
    float baseDamage = 1f;

    float counter = 0;

    bool isSomethingHit = false;

    float timeMark = 0;

    float critChance = 0.1f;
    float critMultiplier = 3f;

    private void Awake() {
        
    }

    private void Update() {
        
    }

    private void FixedUpdate() {
        if (Time.timeScale <= 0) {
            return;
        }


        float deltaTime = Time.time - timeMark;
        deltaTime *= Time.timeScale;
        timeMark = Time.time;


        if (counter >= damageFrequency) {
            if (isSomethingHit) {
                isSomethingHit = false;
                counter = 0;
            }
        }
        else {
            counter += deltaTime;
        }
    }

    private void OnTriggerStay(Collider other) {
        if (Time.timeScale <= 0) {
            return;
        }


        if (counter >= damageFrequency) {
            if (other.gameObject.GetComponentInParent<IDamagable>() != null) {
                isSomethingHit = true;

                float damage = baseDamage;
                if (Random.value < critChance) { // Crit
                    damage *= critMultiplier;
                }
                Debug.Log("Hitting for " + damage + " damage");
                other.GetComponentInParent<IDamagable>().TakeDamage(damage);
            }
        }
    }

    public void MultiplyBaseDamage(float _Multiplier) {
        baseDamage *= _Multiplier;
        Debug.Log("Base damage is now: " + baseDamage);
    }
}
