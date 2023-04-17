using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RapidFirePickup : MonoBehaviour
{
    //For the pickup we will take from the powerup script to act out when we collide with this pickup.
    public RapidFirePowerup powerup;
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