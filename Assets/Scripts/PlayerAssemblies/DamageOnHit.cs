using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnHit : MonoBehaviour
{
    public float damageDone;
    public Pawn owner;
    public float scoreToAdd;
    public Score playerScore;

    //When the bullet collides with the pawn it will return an owner and the damage done.
    public void OnTriggerEnter(Collider other){
        Health otherHealth = other.gameObject.GetComponent<Health>();
        if (otherHealth != null){
            otherHealth.TakeDamage(damageDone, owner);
        }
        Destroy(gameObject);
    }
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

