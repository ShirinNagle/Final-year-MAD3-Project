using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSessionController : MonoBehaviour
{
    //[SerializeField] int playerHealthBar = 4;
    [SerializeField] int playerScore = 0;
    [SerializeField] Text scoreText;
    [SerializeField] Text finalScore;
   // [SerializeField] Text healthText;//need to possibly change this t healthbar

    //Health Bar variables
   // public HealthBarPlayer healthBar;//moved from  player
   // public int currentHealth;//moved to player
    //public int maxHealth = 100;//moved to player

    private void Awake()
    {
        //set up as singleton
        int numGameSession = FindObjectsOfType<GameSessionController>().Length;
        if(numGameSession < 1)
        {
            Destroy(gameObject);//destroy gameobject assoc with this class
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    //double check how the player loses health in single palyer game v's mutliplayer game
    private void Start()
    {
        scoreText.text = playerScore.ToString();
        //finalScore.text = playerScore.ToString();
        // healthText.text = playerHealthBar.ToString();
        //currentHealth = maxHealth;//moved from player
        //healthBar.SetMaxHealth(maxHealth);//moved from player
        
    }
    /*public void processPlayerDeath()//void because this method will process player death for other classes in the system.
    {
        if(currentHealth > 1)//if player still has some health 
        {
            reduceHealth();
        }
        else
        {
            resetGameSession();//send back to main menu
        }
    }*/

    private void resetGameSession()
    {
        SceneManager.LoadScene(1);//tidier way of doing this, this loads the player back to the select single/multiplayer scene.
        Destroy(gameObject);
    }

    /*public void reduceHealth()
    {
        TakeDamage(25);
        //playerHealthBar--;
        //code below only for multiplayer??  
        //var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        //SceneManager.LoadScene(currentSceneIndex);
        // healthText.text = playerHealthBar.ToString();
    }*/
    public void addScore(int addScoreValue)
    {
        playerScore += addScoreValue;
        scoreText.text = playerScore.ToString();
    }
    public void FinalScore()
    {
        finalScore.text = playerScore.ToString();
    }
    
   /* private void TakeDamage(int damage)//move to player.
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }*/
}
