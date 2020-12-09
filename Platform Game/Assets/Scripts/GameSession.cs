using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    [SerializeField] int playerScore = 0;
    [SerializeField] Text livesText;
    [SerializeField] Text scoreText;
   //set up singleton
   private void Awake()
    {
        int numGameSession = FindObjectsOfType<GameSession>().Length;
        if(numGameSession >1)
        {
            Destroy(gameObject);
        }
        else
        {
             DontDestroyOnLoad(gameObject);
        }

    }

    private void Start()
    {
        livesText.text = playerLives.ToString();
        scoreText.text = playerScore.ToString();
    }
    public void ProcessPlayerDeath()
    {
        if (playerLives > 1)
        {
            TakeLife();// respawn player in the current level.
        }
        else
        {
            ResetGameSession();//send back to main menu(Start)
        }
    }
    
    public void AddScore(int addScoreValue)
    {
        playerScore += addScoreValue;
        scoreText.text = playerScore.ToString();
    }
    private void TakeLife()
    {
        playerLives--;
        var currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
        livesText.text = playerLives.ToString();
    }
    private void ResetGameSession()
    {
        SceneManager.LoadScene(0);//go back to start
        Destroy(gameObject);
    }
}
