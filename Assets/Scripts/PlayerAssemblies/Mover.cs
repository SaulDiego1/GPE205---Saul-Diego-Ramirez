using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mover : MonoBehaviour
{
    //Start is made abstract to allow us to pull from it in a child class.
    public abstract void Start();
    
    //Move is made abstract to allow us to pull from it in a child class. 
    //This is important to allowing us to define what kind of movement we will make.(Ex:Boats, planes, cars.)
    public abstract void Move(Vector3 direction, float speed);

    public abstract void Jump(float jumpforce);
    
    public abstract void Dash(Transform orientation,float dashForce, float dashUpwardForce, float dashDuration);
}
