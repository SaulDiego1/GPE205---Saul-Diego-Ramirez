using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
[System.Serializable]
public class PlayerController : Controller
{
    PawnSpawnpoint spawn;

        //Using KeyCode we are able to reassign inputs to keys dictated by the player
    public KeyCode moveForwardKey;
    public KeyCode moveBackwardKey;
    public KeyCode rotateClockwiseKey;
    public KeyCode rotateCounterClockwiseKey;
    public KeyCode shootKey;
    public KeyCode escapeButton;
    public Score pawnScore;
    public float controllerScore;

    //With this we create a list for our GameManager that will list the amount of player controllers
    public override void Start()
    {
        if(GameManager.instance != null){
            if(GameManager.instance.players != null){
                GameManager.instance.players.Add(this);
            }
        }
        spawn = GetComponent<PawnSpawnpoint>();
        base.Start();
    }
    //On destroy we will eliminate from the list based on if the player controller is no longer present.
    public void OnDestroy(){
        if (GameManager.instance != null){
            if (GameManager.instance.players != null){
                GameManager.instance.players.Remove(this);
            }
        }
    }

    public override void Update()
    {
        //Inputs are placed in Update to continusly process the inputs whenever we trigger the override.
        ProcessInputs();
        base.Update();
        controllerScore = Score.score;
    }
        //This is the override that will grab the key inputs and act out the actions taken from the pawn.
    public override void ProcessInputs()
    {
        if (Input.GetKey(moveForwardKey))
        {
            pawn.MoveForward();
        }
        if (Input.GetKey(moveBackwardKey))
        {
            pawn.MoveBackward();
        }
        if (Input.GetKey(rotateClockwiseKey))
        {
            pawn.RotateClockwise();
        }
        if (Input.GetKey(rotateCounterClockwiseKey))
        {
            pawn.RotateCounterClockwise();
        }
        if (Input.GetKey(shootKey))
        {
            pawn.Shoot();
        }
        if (Input.GetKey(escapeButton))
        {
            SceneManager.LoadScene("Main");
        }
    }
}
