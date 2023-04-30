using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    //By creating a list we can track the powerups we currently have.
    private List<Powerup> removedPowerUpQueue;
    public List<Powerup> powerups;
    void Start()
    {
        powerups = new List<Powerup>();
    }
    //We will decrease the timer on every update to have our times function correctly.
    void Update()
    {
        DecrementPowerupTimers();
    }
    private void LateUpdate()
    {
        ApplyRemovePowerUpsQueue();
    }

    //Add will apply the power up and list it.
    public void Add(Powerup powerupToAdd)
    {
        powerupToAdd.Apply(this);
        powerups.Add(powerupToAdd);
    }
    //Of course we can remove the power from the object easily.
    //However, we need a seperate queue to remove from our list without removing the wrong powerup.
    public void Remove(Powerup powerupToRemove)
    {
        powerupToRemove.Remove(this);
        removedPowerUpQueue.Add(powerupToRemove);
    }
    //If the powerup is not permanent then we will remove the powerup after the timer ends.
    public void DecrementPowerupTimers()
    {
        foreach (Powerup powerup in powerups)
        {
            
            powerup.duration -= Time.deltaTime;
            if (powerup.duration <= 0)
            {
                Remove(powerup);
            }
        }
    }
    //This queue allows for the powerups in our list to be removed properly.
    private void ApplyRemovePowerUpsQueue()
    {
        foreach (Powerup powerup in removedPowerUpQueue)
        {
            powerups.Remove(powerup);
        }
        removedPowerUpQueue.Clear();
    }

}
