using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealOnTouch : MonoBehaviour
{
    //Here we can control the amount of health we regain and use a transform location to assign the healer object to a spawnpoint.
    private float HealthRegained;
    public Pawn owner;
    public float RegenHealth;
    public GameObject healerPrefab;
    public Transform healerTransform;

    //On trigger we will regain health to the player and destroy the healer object
    public void OnTriggerEnter(Collider other){
        TankHealth otherHealth = other.gameObject.GetComponent<TankHealth>();
        if (otherHealth != null){
            otherHealth.RegainHealth(HealthRegained, owner);
        }
        Destroy(healerPrefab);
    }
    void Start()
    {

    }
}
