using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliderController : MonoBehaviour
{
    static PlayerColliderController instance;

    public static PlayerColliderController Instance { get { if (instance == null) instance = FindObjectOfType<PlayerColliderController>(); return instance; } }
    

    [SerializeField] Collider wallCollider = null;


    public void SetWallCollider(bool IsEnabled){
        wallCollider.enabled = IsEnabled;
    }
}
