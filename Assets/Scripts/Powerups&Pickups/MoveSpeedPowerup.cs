using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpeedPowerup : PowerUp
{
    //We will use this to enter the amount we need added.
    public float SpeedAmount;
    //We will add to our current speed to increase movement. We use SpeedAmount to change however much we want.
    public override void Apply(PowerUpManager target)
    {
        TankPawn targetMoveSpeed = target.GetComponent<TankPawn>();
        if(targetMoveSpeed != null)
        {
            targetMoveSpeed.movementSpeed = targetMoveSpeed.movementSpeed + SpeedAmount;
        }
    }
    public override void Remove(PowerUpManager target)
    {
        TankPawn targetMoveSpeed = target.GetComponent<TankPawn>();
        if(targetMoveSpeed != null)
        {
            targetMoveSpeed.movementSpeed = SpeedAmount;
        }
    }
}
