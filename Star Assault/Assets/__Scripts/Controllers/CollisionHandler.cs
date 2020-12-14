using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//if using more than 1 script to load scenes may need to move everything into a single scenemanager script 

//https://www.udemy.com/course/unitycourse2/learn/lecture/8314012#overview
public class CollisionHandler : MonoBehaviour
{
    [Tooltip("measured in secs")][SerializeField] float loadLevelDelay = 1.5f;//see how this timing works, may need to +/- the time.G
    [Tooltip("Explosion fx prefab on player goes here")] [SerializeField] GameObject deathFX;

    //Health Bar variables
    public HealthBarPlayer healthBar;//move to player
    public int currentHealth;//move to player
    public int maxHealth = 100;//move to player

    void Start()
    {
        currentHealth = maxHealth;//move to player
        healthBar.SetMaxHealth(maxHealth);//move to player
    }
  
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "portal")
        {
            if(currentHealth > 1)
            {
                reduceHealth();
                print("player health reduced");
            }
            else
            //print("Player triggered something");//left in for testing purposes
            StartPlayerDeath();
        }
        else
        {
            LoadNextLevel();
            //print("player went through box");//left in for testing
        }
       
    }
    
    private void StartPlayerDeath()
    {
        if (currentHealth == 0)
        {
            deathFX.SetActive(true);
            Invoke("ReloadScene", loadLevelDelay);
        }

    }

    private void ReloadScene()//String ref in OnTriggerEnter
    {
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        //need to check what happens when the player dies in game design doc

        /*if (currentSceneIndex != 1)
        {
            SceneManager.LoadScene(currentSceneIndex);
        }
        else
        {
            SceneManager.LoadScene(1);
        }*/
    }

    
    
    private void LoadNextLevel()
    {
        //change the time scale. Timescale can speed up or slow down world - consider speeding up like warp speed on exit level
       // Time.timeScale = 0.2f;
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    private void TakeDamage(int damage)//move to player.
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
    /*private void OnParticleCollision(GameObject other)//if player is hit by enemy particle
    {
        //reduceHealth();
        print("Player hit by particle!!");
        if (currentHealth < 1)
        {
            //StartPlayerDeath();//if player gets hit by particle, reduce health
        }          
    }*/

    private void playerHit()
    {
        reduceHealth();
    }
    public void reduceHealth()
    {
        TakeDamage(25);//need to change this to a named public variable/serialized field, but for testing just hard coded.
        
    }
}
