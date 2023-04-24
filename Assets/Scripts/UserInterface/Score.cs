using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    //This will connect the text UI to our player score.
    public Text ScoreText;
    //We made the score static as a way to send the value of the score to our PlayerController.
    public static float score;
    //AddScore is very simple and will add the score to the amount we want added to it.
    public void AddScore(float newScore)
    {
        score = score + newScore;
    }
    //On start we will set our score to 0.
    void Start()
    {
        score = 0;
    }
    //To make sure our score is updating we created a function that will increase the score and cast it to the UI.
    public void UpdateScore()
    {
        ScoreText.text = "Score: " + score;
    }
    // Update is called once per frame
    void Update()
    {
        UpdateScore();
    }
}
