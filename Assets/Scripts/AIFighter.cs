using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFighter : AIController
{
    //We will get the health of the pawn and make it perform actions based on this.
    TankHealth health;
    // Start is called before the first frame update
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
            case AIState.DoChaseState:
            Debug.Log("Changed State");
            DoChaseState();
            if (IsDistanceLessThan(target, 10)){
                Debug.Log("Changed State");
                ChangeState(AIState.DoAttackState);
            }
            break;
            case AIState.DoAttackState:
            DoAttackState();
            if (!IsDistanceLessThan(target, 10)){
                ChangeState(AIState.DoChaseState);
            }
            break;
        }
    }
}
