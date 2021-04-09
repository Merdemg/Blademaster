using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "PowerUp", menuName = "ScriptableObjects/PowerUp", order = 0)]
public class PowerUp : ScriptableObject
{
    public Sprite powerUpIcon;

    public virtual void Activate() {}

    public virtual void Deactivate() {}
}
