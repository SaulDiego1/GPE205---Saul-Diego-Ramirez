using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Allows for a spawnpoint that the developers can use.
    public Transform playerSpawnTransform;    
    public GameObject[] allSpawnPoints;
    //Game instance uses instance to decribe itself when deciding if it is active.
    public static GameManager instance;
    //Creates a list for different controllers and pawns.
    public List<PlayerController> players;  
    public List<AIController> AIControllers;
    public List<Controller> CurrentControllers;      
    public List<Pawn> CurrentPawns; 

    //This will identify what the game instance does. In this case we tell the game to not destroy on load unless the manager is not active
    public void Awake()
    {
        if (instance == null)
        {
            //This prevents the scene from being destroyed.
            instance = this;
            DontDestroyOnLoad(this);
        } else if(instance != this)
        {
            //Without the instance the game object will be destroyed. In this case it would be the scene.
            Destroy(instance);
        }
    }

    //On start we will spawn the player
    void Start()
    {
        SpawnPlayer();
    }
    void Update()
    {
    }
    //This will call out to the prefabs created from the PlayerController and TankPawn
    public PlayerController playerControllerPrefab;
    public TankPawn tankPawnPrefab;
    public AIController AIControllerPrefab;

    //This function describes the process we use to spawn the player.
    public void SpawnPlayer(){
        int spawn = Random.Range(0, allSpawnPoints.Length);
    //On spawn we will create a new controller that will spawn randomly. This isn't important to the player pawn.
    PlayerController newPlayerObj = Instantiate(playerControllerPrefab, Vector3.zero, Quaternion.identity) as PlayerController;


    //This creates the TankPawn that will be used to spawn the PlayerTank. We use the variable playerSpawnTransform as the spawn point.
    TankPawn newPawnObj = Instantiate(tankPawnPrefab, allSpawnPoints[spawn].transform.position, Quaternion.identity) as TankPawn;

    //Here we are making a new controller and pawn to spawn the tank. This can also be used to clone the tank.
    PlayerController newController = newPlayerObj.GetComponent<PlayerController>();
    TankPawn newPawn = newPawnObj.GetComponent<TankPawn>();
    
    //We take the pawn and give it a new controller to set this as a new pawn. With this process we create the tank on start.
    newController.pawn = newPawn;
    }

    public void SpawnAI(){
        int spawn = Random.Range(0, allSpawnPoints.Length);
    //On spawn we will create a new controller that will spawn randomly. This isn't important to the player pawn.
    AIController newAIObj = Instantiate(AIControllerPrefab, Vector3.zero, Quaternion.identity) as AIController;


    //This creates the TankPawn that will be used to spawn the PlayerTank. We use the variable playerSpawnTransform as the spawn point.
    TankPawn newPawnObj = Instantiate(tankPawnPrefab, allSpawnPoints[spawn].transform.position, Quaternion.identity) as TankPawn;

    //Here we are making a new controller and pawn to spawn the tank. This can also be used to clone the tank.
    AIController newAIController = newAIObj.GetComponent<AIController>();
    TankPawn newPawn = newPawnObj.GetComponent<TankPawn>();
    
    //We take the pawn and give it a new controller to set this as a new pawn. With this process we create the tank on start.
    newAIController.pawn = newPawn;
    }
}
