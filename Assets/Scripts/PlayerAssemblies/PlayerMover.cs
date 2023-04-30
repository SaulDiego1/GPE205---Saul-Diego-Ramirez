using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : Mover
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
    //To jump we create a vector going up and apply a float to determine how high it is that we can jump.
    public override void Jump(float jumpforce)
    {
        rb.velocity = Vector3.up * jumpforce;
    }
    //Dashing is made possible by incorporating AddForce.
    //Using the forceToApply Vector3 that we made it is possible to get our direction and apply force to that direction.
    //We also use the dashUpwardForce to limit the height of the dash.
    public override void Dash(Transform orientation,float dashForce, float dashUpwardForce, float dashDuration)
    {
        Vector3 forceToApply = orientation.forward * dashForce + orientation.up * dashUpwardForce;
        rb.AddForce(forceToApply, ForceMode.Impulse);
        Invoke(nameof(ResetDash), dashDuration);
    }
    public void ResetDash()
    {

    }
    //Since dashing on it's own is already fast, we made a speed control to avoid going faster than intended.
    public void SpeedControl(float speed)
    {
        Vector3 flatSpeed = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        if(flatSpeed.magnitude > speed)
        {
            Vector3 limitedSpeed = flatSpeed.normalized * speed;
            rb.velocity = new Vector3(limitedSpeed.x, rb.velocity.y, limitedSpeed.z);
        }
    }
}