using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    Vector3 startPos;

    const float MAX_TRAVEL_RANGE = 5f;

    bool isCharging = false;

    Coroutine movementCheckCoroutine;

    const float MIN_CHECK_TIME = 0.01f;
    const float MAX_CHECK_TIME = 0.05f;

    NavMeshAgent navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        navMeshAgent = GetComponent<NavMeshAgent>();
        movementCheckCoroutine = StartCoroutine(MovementCheck());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator MovementCheck() {
        while (true) {
            if (!isCharging) {
                if (Vector3.Distance(PlayerMovement.Instance.transform.position, startPos) <= MAX_TRAVEL_RANGE) {
                    isCharging = true;
                    navMeshAgent.SetDestination(PlayerMovement.Instance.transform.position);
                }
            }
            else {
                if (Vector3.Distance(PlayerMovement.Instance.transform.position, startPos) > MAX_TRAVEL_RANGE) {
                    isCharging = false;
                    navMeshAgent.SetDestination(startPos);
                }
                else {
                    navMeshAgent.SetDestination(PlayerMovement.Instance.transform.position);
                }
            }
            //yield return new WaitForSeconds(Random.Range(MIN_CHECK_TIME, MAX_CHECK_TIME));
            yield return new WaitForEndOfFrame();
        }
    }
}
