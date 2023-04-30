using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICoward : AiController
{
    //We will get the health of the pawn and make it perform actions based on this.
    Health health;
    PawnSpawnpoint spawn;
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<Health>();
        spawn = GetComponent<PawnSpawnpoint>();
    }
    // Update is called once per frame
    void Update()
    {
        MakeDecisions();
    }
    //Will decide how to change states. This is caused by conditions and seperated by breaks.
    public override void MakeDecisions()
    {
        switch (currentState) {
            case AIState.DoFleeState:
            Debug.Log("Changed State");
            DoFleeState();
            if (!IsDistanceLessThan(target, 10)){
                Debug.Log("Changed State");
                ChangeState(AIState.DoIdleState);
            }
            if (health.currentHealth <= 30)
            {
                ChangeState(AIState.DoAttackState);
            }
            break;
            case AIState.DoIdleState:
            DoIdleState();
            if (health.currentHealth <= 30){
                ChangeState(AIState.DoAttackState);
            }
            break;
            case AIState.DoAttackState:
            DoAttackState();
            break;
        }
    }
}
