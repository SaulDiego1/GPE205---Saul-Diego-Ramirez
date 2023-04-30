using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPatroller : AiController
{
    //We will get the health of the pawn and make it perform actions based on this.
    Health health;
    PawnSpawnpoint spawn;
    void Start()
    {
        health = GetComponent<Health>();
        spawn = GetComponent<PawnSpawnpoint>();
    }
    void Update()
    {
        MakeDecisions();
    }
    //Will decide how to change states. This is caused by conditions and seperated by breaks.
    public override void MakeDecisions()
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
