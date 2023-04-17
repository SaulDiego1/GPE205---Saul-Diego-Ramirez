using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{
    //With the float duration we can set a time for the powerups to be active.
    public float duration;
    //If the object is permanent then we will skip the timer.
    public bool isPermanent;
    public void Start()
    {

    }
    //In our powerups we will need these abstract classes to describe how we will remove and add.
    public abstract void Apply(PowerUpManager target);
    public abstract void Remove(PowerUpManager target);
}
