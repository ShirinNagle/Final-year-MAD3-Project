using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
   
    int score = 0;
    Text scoreText;

    void Start()
    {
        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();
    }

    public void ScoreHit(int scorePerHitEnemy)
    {
        //need to tag enemies and use if statement to allocate correct score for different enemy hit
        score = score + scorePerHitEnemy;
        scoreText.text = score.ToString();
    }
}
