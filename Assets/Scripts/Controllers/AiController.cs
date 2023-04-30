using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class AiController : Controller
{
    //We make current state for our AI in order to play out the states we create.
    public AIState currentState;
    public float fieldOfView;
    public float fleeDistance;
    public float hearingDistance;
    private float lastStateChangeTime;
    public GameObject target;
    public Transform[] waypoints;
    int current;
    public float movementSpeed;
    //We created an enum to have a list of states created here. This is made publc to allow us to change state on run time.
    public enum AIState {DoChaseState, DoFleeState, DoAttackState, DoIdleState, DoSeekState, DoPatrolState}

//---------------------------------------------------------------------------------------------
    //We will create a list for AI Controllers on Start
    public override void Start()
    {
        base.Start();

        if(GameManager.instance != null){
            if(GameManager.instance.AiController != null){
                GameManager.instance.AiController.Add(this);
            }
        }
    }

        public void OnDestroy(){
        if (GameManager.instance != null){
            if (GameManager.instance.AiController != null){
                GameManager.instance.AiController.Remove(this);
            }
        }
    }

    public override void Update()
    {
        MakeDecisions();
        base.Start();
    }

//---------------------------------------------------------------------------------------------
    //DoSeekState will look for the target that we have assigned. In this case the player tank
    public void DoSeekState()
    {
        Seek(target);
    }
    //We have overloaded our Seek to play out function that makes sense. Depending on what we pass in we will play one of these.
    public void Seek(GameObject target){
        pawn.RotateTowards(target.transform.position);
        pawn.MoveForward();
    }
    public void Seek(Vector3 targetPosition)
    {
        pawn.RotateTowards(targetPosition);
        pawn.MoveForward();
    }
    public void Seek(Transform targetTransform)
    {
        Seek(targetTransform.position);
    }
    public void Seek(Pawn targetPawn)
    {
        Seek(targetPawn.transform);
    }

//---------------------------------------------------------------------------------------------
    public bool CanHear(GameObject target){
        //Using our noiseMaker we can track the players actions by adding a volume to it. 
        //We can then have the AI detect it using their own hearing distance.
        NoiseMaker noiseMaker = target.GetComponent<NoiseMaker>();
        if (noiseMaker == null)
        {
            return false;
        }
        if (noiseMaker.volumeDistance <= 0)
        {
            return false;
        }
        float totalDistance = noiseMaker.volumeDistance + hearingDistance;
        if (Vector3.Distance(pawn.transform.position, target.transform.position) <= totalDistance)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

//---------------------------------------------------------------------------------------------
    //This will determine if the AI should do something based on the condition. 
    //If the condition is less then x amount then the AI will perform an action.
    protected bool IsDistanceLessThan(GameObject target, float distance){
        if (Vector3.Distance (pawn.transform.position, target.transform.position) < distance)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    protected bool IsDistanceMoreThan(GameObject target, float distance){
        if (Vector3.Distance (pawn.transform.position, target.transform.position) > distance)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

//---------------------------------------------------------------------------------------------
    //By making a line of sight we can make the AI detect objects and players.
    public bool CanSee(GameObject target)
    {
        Vector3 agentToTargetVector = target.transform.position - transform.position;
        float angleToTarget = Vector3.Angle(agentToTargetVector, pawn.transform.forward);
        if (angleToTarget < fieldOfView)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
//---------------------------------------------------------------------------------------------

    public abstract void MakeDecisions();
    //ChangeState will set a new state for the AI and allow for that new state to run uninterrupted.
    public virtual void ChangeState(AIState newState)
    {
        currentState = newState;
        lastStateChangeTime = Time.time;
    }
//---------------------------------------------------------------------------------------------
    public void TargetPlayerOne()
    {
        //This will track the amount of players in the instance and follow the first which according to the system is 0.
        if (GameManager.instance != null) 
        {
            if (GameManager.instance.players != null) 
            {
                if (GameManager.instance.players.Count > 0) 
                {
                    target = GameManager.instance.players[0].pawn.gameObject;
                }
            }
        }
    }
//---------------------------------------------------------------------------------------------
    //If a target is set then we will perform this boolean to determine what to do.
    protected bool IsHasTarget()
    {
        // return true if we have a target, false if we don't
        return (target != null);
    }
//---------------------------------------------------------------------------------------------
    protected void TargetNearestTank()
    {
        //We will create a list of our pawns to track the nearest pawn.
        Pawn[] allTanks = FindObjectsOfType<Pawn>();
        //With this we can order our tanks by closest.
        Pawn closestTank = allTanks[0];
        float closestTankDistance = Vector3.Distance(pawn.transform.position, closestTank.transform.position);
        foreach (Pawn tank in allTanks) {
            //If our closest tank stops being the current closest then we will redefine what the closest tank is.
            if (Vector3.Distance(pawn.transform.position, tank.transform.position) <= closestTankDistance ) {
                closestTank = tank;
                closestTankDistance = Vector3.Distance(pawn.transform.position, closestTank.transform.position);
            } 
        }

        // Target the closest tank
        target = closestTank.gameObject;
    }
//---------------------------------------------------------------------------------------------
    //Flee will create a vector away from the player. This is done by geting the players position and making a vector towards it. 
    //An inverse vector is created from this.
    protected void DoFleeState()
    {
    Vector3 vectorToTarget = target.transform.position - pawn.transform.position;
    Vector3 vectorAwayFromTarget = -vectorToTarget;
    float targetDistance = Vector3.Distance(target.transform.position, pawn.transform.position);
    float percentOfFleeDistance = targetDistance / fleeDistance;
    float flippedPercentOfFleeDistance = 1 - percentOfFleeDistance;

    Vector3 fleeVector = vectorAwayFromTarget.normalized * fleeDistance;
    Seek(pawn.transform.position + fleeVector);
    percentOfFleeDistance = Mathf.Clamp01(percentOfFleeDistance);
    }




    public override void ProcessInputs()
    {

    }
//---------------------------------------------------------------------------------------------
    public virtual void DoPatrolState()
    //In order to patrol, we will pass in waypoints to create a set path.
    {
        if (transform.position != waypoints[current].position)
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoints[current].position, movementSpeed * Time.deltaTime);
        }
        else
            current = (current + 1) % waypoints.Length;
    }

//---------------------------------------------------------------------------------------------
    //Chase will simply seek for the target.
    public virtual void DoChaseState()
    {
        Seek(target);
    }

//---------------------------------------------------------------------------------------------
    //The AI will try to seek the set target and attack
    public virtual void DoAttackState()
    {
        Seek(target);
        pawn.Shoot();
    }
//---------------------------------------------------------------------------------------------
    //An idle state means to do nothing, thus the AI will run nothing and remain still
    public virtual void DoIdleState()
    {

    }
}
