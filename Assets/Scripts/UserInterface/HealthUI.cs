using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    //We added an Image to the HealthUI to represent our Health Bar.
    public Image healthBarImage;
    public TankHealth pawnHealth;
    //This UpdateHealthBar function will change the fill amount of the image to represent our overall health.
    public void UpdateHealthBar()
    {
        healthBarImage.fillAmount = Mathf.Clamp(pawnHealth.currentHealth / pawnHealth.maxHealth, 0, 1f);
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
