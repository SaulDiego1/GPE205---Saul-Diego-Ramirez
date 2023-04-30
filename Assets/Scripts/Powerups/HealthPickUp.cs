using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HealthPickUp : MonoBehaviour
{
    //For the pickup we will take from the powerup script to act out when we collide with this pickup.
    public HealthPowerup powerup;
    //OnTriggerEnter will only activate when we have a PowerUpManager attached to us or another object.
    public void OnTriggerEnter(Collider other)
    {
        PowerupManager powerupManager = other.gameObject.GetComponent<PowerupManager>();
        if (powerupManager != null)
        {
            powerupManager.Add(powerup);
            Destroy(gameObject);
        }
        
    }
}