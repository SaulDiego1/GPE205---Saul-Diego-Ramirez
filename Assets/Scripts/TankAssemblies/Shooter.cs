using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shooter : MonoBehaviour
{
    //This parent will allow for shooting to be possible with the tank. We could also change this to be different based on how else we plan to shoot.
    public abstract void Shoot(GameObject Bullet, float fireForce, float damageDone, float lifespan);
    public abstract void Start();
    public abstract void Update();
}
