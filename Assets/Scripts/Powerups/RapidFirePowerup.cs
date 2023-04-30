using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidFirePowerup : Powerup
{
    //We will use this to enter the amount we need added.
    public float fireRateAmount;
    //We will subtract from our current fireRate by the fireRateAmount to make rapid fire possible.
    public override void Apply(PowerupManager target)
    {
        PlayerPawn targetFireRate = target.GetComponent<PlayerPawn>();
        if(targetFireRate != null)
        {
            targetFireRate.fireRate = targetFireRate.fireRate - fireRateAmount;
        }
    }
    public override void Remove(PowerupManager target)
    {      
        PlayerPawn targetFireRate = target.GetComponent<PlayerPawn>();
        if(targetFireRate != null)
        {
            targetFireRate.fireRate = fireRateAmount;
            
        }

    }
}
