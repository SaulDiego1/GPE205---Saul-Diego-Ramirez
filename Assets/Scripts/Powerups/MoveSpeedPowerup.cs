using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpeedPowerup : Powerup
{
    //We will use this to enter the amount we need added.
    public float SpeedAmount;
    //We will add to our current speed to increase movement. We use SpeedAmount to change however much we want.
    public override void Apply(PowerupManager target)
    {
        PlayerPawn targetMoveSpeed = target.GetComponent<PlayerPawn>();
        if(targetMoveSpeed != null)
        {
            targetMoveSpeed.movementSpeed = targetMoveSpeed.movementSpeed + SpeedAmount;
        }
    }
    public override void Remove(PowerupManager target)
    {
        PlayerPawn targetMoveSpeed = target.GetComponent<PlayerPawn>();
        if(targetMoveSpeed != null)
        {
            targetMoveSpeed.movementSpeed = SpeedAmount;
        }
    }
}
