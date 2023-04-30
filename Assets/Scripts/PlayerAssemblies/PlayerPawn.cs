using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPawn : Pawn
{
    PawnSpawnpoint spawn;
    //Allows for fire to be delayed and constant.
    public float nextfire = 0;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        nextfire = 0;
        spawn = GetComponent<PawnSpawnpoint>();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        mover.SpeedControl(movementSpeed);
    }



    public override void RotateTowards(Vector3 targetPosition){
        Vector3 vectorToTarget = targetPosition - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(vectorToTarget, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
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
            volumeDistance = 10;
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
            volumeDistance = 10;
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
        volumeDistance = 10;
    }
    public override void RotateCounterClockwise()
    {
        Debug.Log("Rotate Counter-Clockwise");
        transform.Rotate(0, -turnSpeed * Time.deltaTime, 0);
        volumeDistance = 10;
    }
    // We call onto the shooter and preform the action which is dictated on the key this is assigned to.
    public override void Shoot()
    {
        if (Time.time >= nextfire)
        {
            nextfire = Time.time + fireRate;
            shooter.Shoot(bulletPrefab, fireForce, damageDone, shelllifespan);
            volumeDistance = 10;
            Debug.Log("Shooter");
            audioSource.PlayOneShot(gunShot, 0.7F);
        }

    }
    //In order to stop ourselves from jumping to high we have a boolean to measure our distance to the ground.
    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, groundDistance);
    }
    //Since we put our Jump function in the mover we can call onto it here and add a float value.
    public override void JumpUp()
    {
        if (IsGrounded())
        {
            mover.Jump(jumpforce);
        }
    }
    //Dash is controlled by the direction we are facing and the amount of force we are putting in going forward and upward.
    public override void DashAction()
    {
        mover.Dash(orientation, dashForce, dashUpwardForce, dashDuration);
    }
}