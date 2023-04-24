using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapOptions : MonoBehaviour
{
    //This toggle will turn the isMapOfTheDay boolean to be true.
    public void OnMapOfTheDayToggle()
    {
        bool onOffSwitch = gameObject.GetComponent<Toggle>().isOn;
        if (GameManager.instance != null){
            GameManager.instance.isMapOfTheDay = true;
        }
        else{
            GameManager.instance.isMapOfTheDay = false;
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
