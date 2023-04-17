using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidFirePowerup : PowerUp
{
    //We will use this to enter the amount we need added.
    public float fireRateAmount;
    //We will subtract from our current fireRate by the fireRateAmount to make rapid fire possible.
    public override void Apply(PowerUpManager target)
    {
        TankPawn targetFireRate = target.GetComponent<TankPawn>();
        if(targetFireRate != null)
        {
            targetFireRate.fireRate = targetFireRate.fireRate - fireRateAmount;
        }
    }
    public override void Remove(PowerUpManager target)
    {
        TankPawn targetFireRate = target.GetComponent<TankPawn>();
        if(targetFireRate != null)
        {
            targetFireRate.fireRate = fireRateAmount;
        }
    }
}
