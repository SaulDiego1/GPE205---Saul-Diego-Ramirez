using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPressToStart : MonoBehaviour
{
    //The main purpose of these functions is to define the actions that the button will take.
    //Since buttons to pick and choose diffent functions we don't have to call for them in the script and just assign it to a button.
    public void ChangeToMainMenu()
    {
        if (GameManager.instance != null) {
            GameManager.instance.ActivateMainMenuScreen();
        }
    }
        public void ChangeToOptions()
    {
        if (GameManager.instance != null) {
            GameManager.instance.ActivateOptionsStateScreen();
        }
    }
        public void ChangeToCredits()
    {
        if (GameManager.instance != null) {
            GameManager.instance.ActivateCreditsStateScreen();
        }
    }
        public void ChangeToGameplay()
    {
        if (GameManager.instance != null) {
            GameManager.instance.ActivateGameplayStateScreen();
        }
    }
        public void ChangeToTitle()
    {
        if (GameManager.instance != null) {
            GameManager.instance.ActivateTitleScreen();
        }
    }
        public void ChangeToGameOver()
    {
        if (GameManager.instance != null) {
            GameManager.instance.ActivateGameOverStateScreen();
        }
    }
        public void ChangeToQuitGame()
    {
        Application.Quit();
    }
        public void ChangeToGameOverMainMenu()
    {
        if (GameManager.instance != null) {
            GameManager.instance.ActivateGameOverMainMenuStateScreen();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
