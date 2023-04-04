using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class ParentControllerScrpit : MonoBehaviour
{
        //We call to the PawnScript and label it as pawn. 
        //This will all for inputs to connect to the actions made with pawn and its children.
    public PawnScript pawn;
    //This creates a list for the amount of ParentControllers.
    public virtual void Start()
    {
             if(GameManager.manager != null){
            if(GameManager.manager.CurrentControllers != null){
                GameManager.manager.CurrentControllers.Add(this);
            }
        }
    }

    public void OnDestroy(){
        if (GameManager.manager != null){
            if (GameManager.manager.CurrentControllers != null){
                GameManager.manager.CurrentControllers.Remove(this);
            }
        }
    }

    public virtual void Update()
    {
        
    }
        //Inputs are made abstract in case we need to override it for a different purpose 
        //such as a second player or an AI.
    public abstract void ProcessInputs();
}
