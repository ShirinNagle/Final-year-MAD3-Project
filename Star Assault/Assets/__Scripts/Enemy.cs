using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;//container for generated items - possibly not using for now

    [SerializeField] int scorePerHitEnemyL = 50;
    [SerializeField] int scorePerHitEnemyS = 100;
    [SerializeField] int maxEnemyHits = 4;

   
    Score scoreBoard;
    GameSessionController gameSession;
    //public HealthBar1 healthBar;//move to player
    //public int currentHealth;//move to player
    //public int maxHealth = 100;//move to player
    void Start()
    {
        AddBoxCollider();
        //scoreBoard = FindObjectOfType<Score>();
        //ProcessFiring();
        gameSession = FindObjectOfType<GameSessionController>();
        //currentHealth = maxHealth;//move to player
        //healthBar.SetMaxHealth(maxHealth);//move to player
    }

    private void AddBoxCollider()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();//add box collider
        boxCollider.isTrigger = false; //set trigger to not active 
    }

    // Update is called once per frame

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        //may need to add sound fx as per game design
        if (maxEnemyHits <= 1)
        {
            KillEnemy();
        }

    }

    private void ProcessHit()
    {
        //scoreBoard.ScoreHit(scorePerHitEnemy);
        gameSession.addScore(scorePerHitEnemyL);
        maxEnemyHits--;
        
        //TakeDamage(25);//move to player
    }

    private void KillEnemy()
    {
        GameObject enemyFX = Instantiate(deathFX, transform.position, Quaternion.identity);
        enemyFX.transform.parent = parent;
        //print("Particles collided with enemy" + gameObject.name);
        Destroy(gameObject);
    }
    /*private void TakeDamage(int damage)//move to player.
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }*/
}
