using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePowerup : PowerUp
{
    //We will use this to enter the amount we need added.
    public float scoreToAdd;
    //We will use our AddScore function to our Apply to increase our current score.
    public override void Apply(PowerUpManager target)
    {
        Score playerScore = target.GetComponent<Score>();
        if(playerScore != null)
        {
            playerScore.AddScore(scoreToAdd);
        }
    }
    //Since this powerup is permanent we don't need to change anything about Remove.
    public override void Remove(PowerUpManager target)
    {

    }
}
