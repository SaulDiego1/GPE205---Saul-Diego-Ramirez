using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    //A life was created for the bullet so that it can die after its job is complete.
    public float life = 3;

    //The bullet will destroy any game object and itself.
    void Awake(){
        Destroy(gameObject, life);
    }
    //Any game object that the bullet collides with will be destroyed.
    void OnCollisionEnter(Collision collision){
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }

}
