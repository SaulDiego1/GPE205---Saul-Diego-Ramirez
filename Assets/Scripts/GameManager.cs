using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //To access the diffent menus we made GameObjects to place the menu screens.
    public GameObject TitleScreenStateObject;
    public GameObject MainMenuStateObject;
    public GameObject OptionsScreenStateObject;
    public GameObject CreditsScreenStateObject;
    public GameObject GameplayStateObject;
    public GameObject GameOverScreenStateObject;
    public GameObject WinScreenStateObject;
    //Allows for a spawnpoint that the developers can use.
    public GameObject[] allSpawnPoints;
    //Game instance uses instance to decribe itself when deciding if it is active.
    public static GameManager instance;
    //Creates a list for different controllers and pawns.
    public List<PlayerController> players;
    public List<AiController> AiController;
    public List<Controller> CurrentControllers;
    public List<Pawn> CurrentPawns;
    public List<ScorePickup> scorePickups;
    public bool isMapOfTheDay;
    public bool isMultiPlayer;
    public int rows;
    public int cols;
    public MapGenerator map;

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
        map = GetComponent<MapGenerator>();
        MapGenerator.rows = rows;
        MapGenerator.cols = cols;
        MapGenerator.isMapOfTheDay = isMapOfTheDay;
        WinScreenStateObject.SetActive(false);
    }

    //On start we will spawn the player
    void Start()
    {
        if (TitleScreenStateObject != null)
        {
            ActivateTitleScreen();
        }        
        if (TitleScreenStateObject == null)
        {
            ActivateGameplay();
        }
    }
    void Update()
    {
        //If the game is in the GameScene and all the scorePickups are collected, then we will win the game.
        if (TitleScreenStateObject == null)
        {
            if (scorePickups.Count == 0)
            {
                WinScreenStateObject.SetActive(true);
            }
        }
    }
    //This will call out to the prefabs created from the PlayerController and PlayerPawn
    public PlayerController playerControllerPrefab;
    public PlayerController player1ControllerPrefab;
    public PlayerController player2ControllerPrefab;
    public PlayerPawn playerPrefab;
    public PlayerPawn AIPawnPrefab;
    public AiController AIControllerPrefab;
    public PlayerPawn player1Prefab;
    public PlayerPawn player2Prefab;

    //This function describes the process we use to spawn the player.
    public void SpawnSinglePlayer(){
        int spawn = Random.Range(0, allSpawnPoints.Length);
    //On spawn we will create a new controller that will spawn randomly. This isn't important to the player pawn.
    PlayerController newPlayerObj = Instantiate(playerControllerPrefab, Vector3.zero, Quaternion.identity) as PlayerController;


    //This creates the PlayerPawn that will be used to spawn the Player. We use the variable playerSpawnTransform as the spawn point.
    PlayerPawn newPawnObj = Instantiate(playerPrefab, allSpawnPoints[spawn].transform.position, Quaternion.identity) as PlayerPawn;

    //Here we are making a new controller and pawn to spawn the Player. This can also be used to clone the Player.
    PlayerController newController = newPlayerObj.GetComponent<PlayerController>();
    PlayerPawn newPawn = newPawnObj.GetComponent<PlayerPawn>();
    
    //We take the pawn and give it a new controller to set this as a new pawn. With this process we create the Player on start.
    newController.pawn = newPawn;
    }

    public void SpawnAI(){
        int spawn = Random.Range(0, allSpawnPoints.Length);
    //On spawn we will create a new controller that will spawn randomly. This isn't important to the player pawn.
    AiController newAIObj = Instantiate(AIControllerPrefab, Vector3.zero, Quaternion.identity) as AiController;


    //This creates the PlayerPawn that will be used to spawn the AIEnemy. We use the variable playerSpawnTransform as the spawn point.
    PlayerPawn newPawnObj = Instantiate(AIPawnPrefab, allSpawnPoints[spawn].transform.position, Quaternion.identity) as PlayerPawn;

    //Here we are making a new controller and pawn to spawn the AIEnemy. This can also be used to clone the AIEnemy.
    AiController newAIController = newAIObj.GetComponent<AiController>();
    PlayerPawn newPawn = newPawnObj.GetComponent<PlayerPawn>();
    
    //We take the pawn and give it a new controller to set this as a new pawn. With this process we create the AIEnemy on start.
    newAIController.pawn = newPawn;
    }
    
    public void SpawnPlayer1(){
        int spawn = Random.Range(0, allSpawnPoints.Length);
    //On spawn we will create a new controller that will spawn randomly. This isn't important to the player pawn.
    PlayerController newPlayerObj = Instantiate(player1ControllerPrefab, Vector3.zero, Quaternion.identity) as PlayerController;


    //This creates the PlayerPawn that will be used to spawn the Player. We use the variable playerSpawnTransform as the spawn point.
    PlayerPawn newPawnObj = Instantiate(player1Prefab, allSpawnPoints[spawn].transform.position, Quaternion.identity) as PlayerPawn;

    //Here we are making a new controller and pawn to spawn the Player. This can also be used to clone the Player.
    PlayerController newController = newPlayerObj.GetComponent<PlayerController>();
    PlayerPawn newPawn = newPawnObj.GetComponent<PlayerPawn>();
    
    //We take the pawn and give it a new controller to set this as a new pawn. With this process we create the Player on start.
    newController.pawn = newPawn;
    }
    public void SpawnPlayer2(){
        int spawn = Random.Range(0, allSpawnPoints.Length);
    //On spawn we will create a new controller that will spawn randomly. This isn't important to the player pawn.
    PlayerController newPlayerObj = Instantiate(player2ControllerPrefab, Vector3.zero, Quaternion.identity) as PlayerController;


    //This creates the PlayerPawn that will be used to spawn the Player. We use the variable playerSpawnTransform as the spawn point.
    PlayerPawn newPawnObj = Instantiate(player2Prefab, allSpawnPoints[spawn].transform.position, Quaternion.identity) as PlayerPawn;

    //Here we are making a new controller and pawn to spawn the Player. This can also be used to clone the Player.
    PlayerController newController = newPlayerObj.GetComponent<PlayerController>();
    PlayerPawn newPawn = newPawnObj.GetComponent<PlayerPawn>();
    
    //We take the pawn and give it a new controller to set this as a new pawn. With this process we create the Player on start.
    newController.pawn = newPawn;
    }
    public void ActivateGameplay()
    {
        //To prevent our gamemode being stuck on one setting we added a boolean to determine if we want multiplayer or singleplayer.
        if (isMultiPlayer){
        SpawnPlayer1();
        SpawnPlayer2();
        } else {

        SpawnSinglePlayer();
        SpawnAI();
        }

    }
    //To prevent all the menus from being open at the same time we can close them off in one function.
        private void DeactivateAllStates()
    {
        TitleScreenStateObject.SetActive(false);
        MainMenuStateObject.SetActive(false);
        OptionsScreenStateObject.SetActive(false);
        CreditsScreenStateObject.SetActive(false);
        GameplayStateObject.SetActive(false);
    }
    //All of the Activate functions below open the menu we want open.
        public void ActivateTitleScreen()
    {
        DeactivateAllStates();
        TitleScreenStateObject.SetActive(true);
    }
        public void ActivateMainMenuScreen()
    {
        DeactivateAllStates();
        MainMenuStateObject.SetActive(true);
    }
        public void ActivateOptionsStateScreen()
    {
        DeactivateAllStates();
        OptionsScreenStateObject.SetActive(true);
    }
        public void ActivateCreditsStateScreen()
    {
        DeactivateAllStates();
        CreditsScreenStateObject.SetActive(true);
    }
        public void ActivateGameplayStateScreen()
    {
        DeactivateAllStates();
        GameplayStateObject.SetActive(true);
        SceneManager.LoadScene("GameScene");
    }
        public void ActivateGameOverStateScreen()
    {
        DeactivateAllStates();
        GameOverScreenStateObject.SetActive(true);
    }
    //The GameOver Main menu will open back to the main menu since we have these two menus in different screens.
            public void ActivateGameOverMainMenuStateScreen()
    {
        SceneManager.LoadScene("Main");
    }
    //When we want the game to end we can define the conditions for a game over here.
}
