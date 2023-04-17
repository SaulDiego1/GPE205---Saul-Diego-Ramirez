using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpeedPickup : MonoBehaviour
{
    //For the pickup we will take from the powerup script to act out when we collide with this pickup.
    public MoveSpeedPowerup powerup;
    //OnTriggerEnter will only activate when we have a PowerUpManager attached to us or another object.
    public void OnTriggerEnter(Collider other)
    {
        PowerUpManager powerupManager = other.gameObject.GetComponent<PowerUpManager>();
        if (powerupManager != null)
        {
            powerupManager.Add(powerup);
            Destroy(gameObject);
        }
        
    }
}
