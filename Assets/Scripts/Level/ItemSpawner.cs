using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemSpawner : MonoBehaviour
{
    //We will put our desired Pickup in here to use in the spawner.
    public GameObject pickupPrefab;
    //We create floats for our timer to delay a next spawn and set the next spawn time.
    public float spawnDelay;
    private float nextSpawnTime;
    private Transform tf;
    //This is the pickup that will be redefined to suit the timer.
    private GameObject spawnedPickup;
    //On start we will use our timer to determine the next spawn time.
    public void Start()
    {
        nextSpawnTime = Time.time + spawnDelay;
    }
    // Update is called once per frame
    public void Update()
    {
        if (spawnedPickup == null)
        {
            //We will create the object on the transform position and then set the next spawn time.
            if (Time.time > nextSpawnTime)
            {
                spawnedPickup = Instantiate(pickupPrefab, transform.position, Quaternion.identity) as GameObject;
                nextSpawnTime = Time.time + spawnDelay;
            }
        }
        else
        {
            //if the item is not grabbed then we will continue to delay the next spawn time.
            nextSpawnTime = Time.time + spawnDelay;
        }
    }
}
