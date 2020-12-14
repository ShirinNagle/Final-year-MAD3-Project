using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    //Health Bar variables
    public HealthBarPlayer healthBar;//move to player
    public int currentHealth;//move to player
    public int maxHealth = 100;//move to player

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;//move to player
        healthBar.SetMaxHealth(maxHealth);//move to player
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void TakeDamage(int damage)//move to player.
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.tag != "health")
        {
            playerHit();
            print("Player hit obstacle!!");
        }
        else
            addPowerUP();//not sure this will work need to test
    }
    private void playerHit()
    {
       reduceHealth();
    }
    public void reduceHealth()
    {
        TakeDamage(25);//need to change this to a named public variable/serialized field, but for testing just hard coded.
        //playerHealthBar--;
        //code below only for multiplayer??  
        //var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        //SceneManager.LoadScene(currentSceneIndex);
        // healthText.text = playerHealthBar.ToString();
    }
    //player hit power up - gains health
    private void HealthPowerUP(int health)//when method is working need to add check if health <=75, no point adding to more than 100
    {
        currentHealth = +health;
        healthBar.SetHealth(currentHealth);
    }
    public void addPowerUP()
    {
        HealthPowerUP(25);
    }
}
