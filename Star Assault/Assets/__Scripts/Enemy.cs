using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;

    [SerializeField] int scorePerHitEnemy = 50;
    // [SerializeField] int scorePerHitEnemySmall = 100;

    Score scoreBoard;
    void Start()
    {
        AddBoxCollider();
        scoreBoard = FindObjectOfType<Score>();
    }

    private void AddBoxCollider()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();//add box collider
        boxCollider.isTrigger = false; //set trigger to not active 
    }

    // Update is called once per frame

    private void OnParticleCollision(GameObject other)
    {
        scoreBoard.ScoreHit(scorePerHitEnemy);
        GameObject enemyFX = Instantiate(deathFX, transform.position, Quaternion.identity);
        enemyFX.transform.parent = parent;
        //print("Particles collided with enemy" + gameObject.name);
        Destroy(gameObject);
    }
}
