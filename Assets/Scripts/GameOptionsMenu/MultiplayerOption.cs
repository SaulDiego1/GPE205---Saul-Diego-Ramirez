using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiplayerOption : MonoBehaviour
{
    //This toggle will turn the isMultiPlayer boolean to be true.
    public void OnMultiplayerToggle()
    {
        bool onOffSwitch = gameObject.GetComponent<Toggle>().isOn;
        if (GameManager.instance != null){
            GameManager.instance.isMultiPlayer = true;
        }
        else{
            GameManager.instance.isMultiPlayer = false;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
