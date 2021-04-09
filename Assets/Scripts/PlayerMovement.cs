using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    static PlayerMovement instance;
    public static PlayerMovement Instance {
        get { if (instance == null) instance = FindObjectOfType<PlayerMovement>(); return instance; }
    }

    [SerializeField] float movementSpeed = 1f;
    float movementSpeedMultiplier = 1f;

    [SerializeField] LayerMask planeLayer = 1 << 5;

    [SerializeField] Camera mainCamera = null;

    // Start is called before the first frame update
    void Start()
    {
        if (mainCamera == null) {
            mainCamera = Camera.main;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)) {
            RaycastHit Hit;
            Ray Ray = mainCamera.ScreenPointToRay(Input.mousePosition); //This works as touches[0] on mobile. Right? RIGHT?

            if (Physics.Raycast(Ray, out Hit, Mathf.Infinity, planeLayer)) {
                Vector3 HitPos = Hit.point;
                HitPos.y = 0;
                Vector3 PlayerPos = transform.position;
                PlayerPos.y = 0;

                Vector3 Dir = HitPos - PlayerPos;
                Dir.Normalize();

                transform.position += Dir * movementSpeed * movementSpeedMultiplier * Time.deltaTime;
            }
        }
    }

    public void SetMovementSpeedMultiplier(float Multiplier){
        movementSpeedMultiplier = Multiplier;
    }
}
