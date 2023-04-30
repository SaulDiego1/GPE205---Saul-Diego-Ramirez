using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerup : Powerup
{
    //We will use this to enter the amount we need added.
    public float healthToAdd;
    //When we apply the health we will use the previously made RegainHealth function to get health back.
    public override void Apply(PowerupManager target)
    {
        Health targetHealth = target.GetComponent<Health>();
        if(targetHealth != null)
        {
            targetHealth.RegainHealth(healthToAdd, target.GetComponent<Pawn>());
        }
    }
    //Since this powerup is permanent we don't need to change anything about Remove.
    public override void Remove(PowerupManager target)
    {


    }
}
