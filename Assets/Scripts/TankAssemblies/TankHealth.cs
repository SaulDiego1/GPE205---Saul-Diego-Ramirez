using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TankHealth : MonoBehaviour
{
    //We can track the amount of health we currently have and compare it to the max health.
    public float currentHealth;
    public float maxHealth;
    public float lives;
    public float scoreToAdd;
    public HealthUI healthBar;
    public GameManager gameover;
    public Transform playerRespawn;
    // Start is called before the first frame update
    void Start()
    {
        //On start we will open with our current health at max health.
        currentHealth = maxHealth;
        gameover = GetComponent<GameManager>();
    }
    //Our take damage will decrease only the current health until it is below zero where the pawn will die.
    public void TakeDamage (float amount, Pawn Source)
    {
        currentHealth = currentHealth - amount;
        Debug.Log(Source.name + "Did " + amount + " damage.");
        currentHealth = Mathf.Clamp (currentHealth, 0, maxHealth);
        healthBar.UpdateHealthBar();
        
        if (currentHealth <= 0){
        Die (Source);
    }             
    }
    //Our health will increase until it is equal or greater than max health where it will go down to the max health.
    public void RegainHealth (float RegenHealth, Pawn Source){
        currentHealth = currentHealth + RegenHealth;
        Debug.Log(Source.name +"Got "+ RegenHealth + " health back.");
        currentHealth = Mathf.Clamp (currentHealth, 0, maxHealth);
        healthBar.UpdateHealthBar();
        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
    //On die we will destroy the pawn.
    public void Die (Pawn Source)
    {
        if (lives <= 0){
        Destroy(gameObject);
        gameover.GameOver();
        }
        if (lives > 0){
        lives = lives - 1;
        currentHealth = maxHealth;
        healthBar.UpdateHealthBar();
        transform.position = playerRespawn.transform.position;
       
        }
        Score playerScore = Source.GetComponent<Score>();
        playerScore.AddScore(scoreToAdd); 
    }


    // Update is called once per frame
    void Update()
    {

    }

}
