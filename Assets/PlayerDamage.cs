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

    private void Awake() {
        
    }

    private void Update() {
        
    }

    private void FixedUpdate() {
        float deltaTime = Time.time - timeMark;
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
        if (counter >= damageFrequency) {
            if (other.gameObject.GetComponentInParent<IDamagable>() != null) {
                isSomethingHit = true;
                other.GetComponentInParent<IDamagable>().TakeDamage(baseDamage);
            }
        }
    }

    public void MultiplyBaseDamage(float _Multiplier) {
        baseDamage *= _Multiplier;
        Debug.Log("Base damage is now: " + baseDamage);
    }
}
