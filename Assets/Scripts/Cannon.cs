using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed;
 //Shoot function used to give a velocity to the bullets.
    public void Shoot()
    {
        Update();        
            void Update(){
            //Calls for the bullets when the Shoot() function is used.
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            //Creates a direction and is multiplied by the float speed and runs in seconds.
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed * Time.deltaTime;
            }
            
    }
    public void Start(){

    }
}
