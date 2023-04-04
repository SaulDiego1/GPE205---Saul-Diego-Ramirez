using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPawn : PawnScript
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Start();
    }
        //Movement actions are overrided to make the actions specific to the input. 
        //The code used here will be pulled into the PlayerController.
    public override void MoveForward()
    {
        Debug.Log("Move Forward");
        //Movement will occur if it is not defined as null. This will allow the code to run with a warning being displayed.
        if (mover != null) 
        {
            mover.Move(transform.forward, movementSpeed);
        } else 
        {
            Debug.LogWarning("Warning: No Mover in TankPawn.MoveForward()!");
        }
    }
        //Backwards movement is made to be the inverse of forward movement. 
        //This means that movement turns the vector negative and thus backward motion!
    public override void MoveBackward()
    {
        Debug.Log("Move Backward");
        if (mover != null) 
        {
            mover.Move(transform.forward, -movementSpeed);
        } else 
        {
            Debug.LogWarning("Warning: No Mover in TankPawn.MoveBackward()!");
        }
    }
        //Rotations work similar to the other movement options but instead change the turnspeed.
        //This is beacuse it changes the direction of the rotation to working counter-clockwise.
    public override void RotateClockwise()
    {
        Debug.Log("Rotate Clockwise");
        transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
    }
    public override void RotateCounterClockwise()
    {
        Debug.Log("Rotate Counter-Clockwise");
        transform.Rotate(0, -turnSpeed * Time.deltaTime, 0);
    }
    // We call onto the shooter and preform the action which is dictated on the key this is assigned to.
    public override void Shooter(){
        shooter.Shoot();        
        Debug.Log("Shooter");
    }
}
