using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPatroller : AIController
{
    //We will get the health of the pawn and make it perform actions based on this.
    TankHealth health;
    void Start()
    {
        health = GetComponent<TankHealth>();
    }
    void Update()
    {
        makeDecisions();
    }
    //Will decide how to change states. This is caused by conditions and seperated by breaks.
    public override void makeDecisions()
    {
        switch (currentState) {
            case AIState.DoPatrolState:
            Debug.Log("Changed State");
            DoPatrolState();
            if (IsDistanceLessThan(target, 10)){
                Debug.Log("Changed State");
                ChangeState(AIState.DoAttackState);
            }
            if (health.currentHealth <= 30)
            {
                ChangeState(AIState.DoFleeState);
            }
            break;
            case AIState.DoFleeState:
            DoFleeState();
            break;
            case AIState.DoAttackState:
            DoAttackState();
            if (!IsDistanceLessThan(target, 10)){
                ChangeState(AIState.DoSeekState);
            }
            break;
        }
    }
}
