using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectShooter : Shooter
{
    public Transform firepointTransform;
    public GameObject bulletPrefab;
    public float fireRate;
    public float fireForce;


    public override void Start()
    {

    }
    public override void Update()
    {
        
    }
    //On shoot we will from the bulletprefab that will simulate bullets. 
    //We will also create damage and force with this function.
    public override void Shoot(GameObject bulletPrefab, float fireForce, float damageDone, float lifespan)
    {
        GameObject newShell = Instantiate(bulletPrefab, firepointTransform.position, firepointTransform.rotation) as GameObject;
        DamageOnHit doh = newShell.GetComponent<DamageOnHit>();
        if (doh != null){
            doh.damageDone = damageDone;
            doh.owner = GetComponent<Pawn>();
        }
        Rigidbody rb = newShell.GetComponent<Rigidbody>();
        if(rb != null){
            rb.AddForce(firepointTransform.forward * fireForce);
        }
        Destroy(newShell, lifespan);

    }
}
