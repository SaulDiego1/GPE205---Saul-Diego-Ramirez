using System.Collections;
using System.Collections.Generic;
using UnityEngine;
        //This class is inherting from our MoverScript making it a child of that script.
        //This will allow us to override the original code to make movement specific to the object we want to use.
public class TankMover : Mover
{
        //This will allow us to change how we describe Rigidbody and activate it when rb is being called
    private Rigidbody rb;

        //Our start is overrided to create an action on start.
    public override void Start()
    {
        //This calls to the Rigidbody component of the Object.
        rb = GetComponent<Rigidbody>();
    }

        //We override the move created in the Parent to describe what the movement will look like.
    public override void Move(Vector3 direction, float speed)
    {
        //We use Vector3 to create a vector in a 3D space. 
        //This is then defined by our speed being constant and action running on seconds rather than time.
        Vector3 moveVector = direction.normalized * speed * Time.deltaTime;
        
        //This will move our position by taking our current space and adding the vector we defined.
        rb.MovePosition(rb.position + moveVector);
    }
}
