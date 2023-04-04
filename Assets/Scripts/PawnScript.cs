using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PawnScript : MonoBehaviour
{
        //This was left publicly open for designers to change the movement speed without ruining the script.
    public float movementSpeed;

        //This is also left open for designers to change the rotation speed.
    public float turnSpeed;

    public float bulletSpeed;

    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
        //We have defined the MoverChild as mover to pull the overrided functions into our pawn's actions.
    public MoverChild mover;
    public Cannon shooter;

        //On start we pull from the MoverChild to use the component in the children of this script.
    public virtual void Start()
    {
        //This will call to our MoverChild script to be used to pull code we created there.
        mover = GetComponent<MoverChild>();
        //We call out to the Cannon script to connect it to the TankPawn
        shooter = GetComponent<Cannon>();
        //This creates a list for the GameManger that counts the number of pawns.
        if(GameManager.manager != null){
            if(GameManager.manager.CurrentPawns != null){
                GameManager.manager.CurrentPawns.Add(this);
            }
        }
    }

        public void OnDestroy(){
        if (GameManager.manager != null){
            if (GameManager.manager.CurrentPawns != null){
                GameManager.manager.CurrentPawns.Remove(this);
            }
        }
    }

        //We rotate in the update to have it update every frame.
    public virtual void Update()
    {
        transform.Rotate(0, turnSpeed * Time.deltaTime, 0);

    }
        //These abstract voids will be the foundation of our movements. 
        //This will be use to define what each action does and could then be connected to the inputs.
    public abstract void MoveForward();
    public abstract void MoveBackward();
    public abstract void RotateClockwise();
    public abstract void RotateCounterClockwise();
    public abstract void Shooter();
}
