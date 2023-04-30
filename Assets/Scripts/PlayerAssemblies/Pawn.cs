using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Pawn : MonoBehaviour
{
        //This was left publicly open for designers to change the movement speed without ruining the script.
    public float movementSpeed;

        //This is also left open for designers to change the rotation speed.
    public float turnSpeed;

    public float jumpforce;
    public float groundDistance;

    public float dashForce;
    public float dashUpwardForce;
    public float dashDuration;
    public Transform orientation;
        //fire force is the float the allows for the bullet to travel faster.
    public float fireForce;
    public float damageDone;
    public float RegenHealth;
        //bullets have lifespan to avoid it from continuing on.
    public float shelllifespan;
        //With this we can control the rate we fire bullets.
    public float fireRate;

    public AudioClip gunShot;
    public AudioSource audioSource;
        //Coupled with the noiseMaker we can simulate sound and have AI hear us.
    public float volumeDistance;
    public GameObject target;
    public NoiseMaker noiseMaker;
    public abstract void RotateTowards(Vector3 targetPosition);


    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
        //We have defined the MoverChild as mover to pull the overrided functions into our pawn's actions.
    public PlayerMover mover;
    public Shooter shooter;

        //On start we pull from the MoverChild to use the component in the children of this script.
    public virtual void Start()
    {
        if(GameManager.instance != null){
            if(GameManager.instance.CurrentPawns != null){
                GameManager.instance.CurrentPawns.Add(this);
            }
        }        
        //This will call to our MoverChild script to be used to pull code we created there.
        mover = GetComponent<PlayerMover>();
        //We call out to the Cannon script to connect it to the TankPawn
        shooter = GetComponent<Shooter>();

        audioSource = GetComponent<AudioSource>();

        //This creates a list for the GameManger that counts the number of pawns.

    }

    public void OnDestroy()
    {
        if (GameManager.instance != null){
            if (GameManager.instance.CurrentPawns != null){
                GameManager.instance.CurrentPawns.Remove(this);
            }
        }
    }

        //We rotate in the update to have it update every frame.
    public virtual void Update()
    {

    }
        //These abstract voids will be the foundation of our movements. 
        //This will be use to define what each action does and could then be connected to the inputs.
    public abstract void MoveForward();
    public abstract void MoveBackward();
    public abstract void RotateClockwise();
    public abstract void RotateCounterClockwise();
    public abstract void Shoot();
    public abstract void JumpUp();
    public abstract void DashAction();
}
