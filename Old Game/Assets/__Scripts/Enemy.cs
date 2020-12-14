using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// use this class to manage collisions

public class Enemy : MonoBehaviour
{
    //set this  up to publish an event to the system when killed

    // public fields
    // used from GameController enemy.ScoreValue
    public int ScoreValue {
        set { scoreValue = value; }
        get { return scoreValue; } }
    // used in PlayerHealth
    public int DamageValue {
        set { damageValue = value; }
        get { return damageValue; } }
    //need to use this in the right place!!!
    public int EnemyKilledCount
    {
        set { enemyKilledCount = value; }
        get { return enemyKilledCount; }
    }

    // delegate type to use for event
    public delegate void EnemyKilled(Enemy enemy);

    // create static method to be implemented in the listener
    public static EnemyKilled EnemyKilledEvent;

    // private fields
    [SerializeField] private int scoreValue = 10;
    [SerializeField] private int damageValue = 5;
    //want to use this value if the enemy hits the boundary collider and not the player
    [SerializeField] private int damageValueBoundary = 1;

    [SerializeField] private GameObject explosionFX;
    [SerializeField] private AudioClip crashSound;
    // sounds for getting hit by bullet, spawning
    [SerializeField] private AudioClip dieSound;
    [SerializeField] private AudioClip spawnSound;

    private float explosionDuration = 1.0f;
    private int enemyKilledCount = 0;

    private SoundController sc;

    //private methods
    private void Start()
    {
        sc = SoundController.FindSoundController();
        PlaySound(spawnSound);
    }

    private void PlaySound(AudioClip clip)
    {
        if (sc)
        {
            sc.PlayOneShot(clip);
        }
    }

    private void OnTriggerEnter2D(Collider2D whatHitMe)
    {
        // parameter = what ran into me
        // if the player hit, then destroy the player
        // and the current enemy rectangle

        var player = whatHitMe.GetComponent<PlayerMovement>();
        var bullet = whatHitMe.GetComponent<Bullet>();

        if(player)  // if (player != null)
        {
            // play crash sound
            PlaySound(crashSound);
            //Debug.Log("In if player");
            // destroy the player
            Destroy(gameObject);
        }

        if(bullet)
        {
            // play die sound
            PlaySound(dieSound);
            enemyKilledCount++;
            Debug.Log($"Enemy killed count = {enemyKilledCount++}");
            // destroy bullet
            Destroy(bullet.gameObject);
            // publish the event to the system to give the player points
            PublishEnemyKilledEvent();
            // show the explosion
            GameObject explosion = Instantiate(explosionFX,transform.position, transform.rotation);
            Destroy(explosion, explosionDuration);
            // destroy this game object
            Destroy(gameObject);
        }
    }

    private void PublishEnemyKilledEvent()
    {
        // make sure somebody is listening
        if(EnemyKilledEvent != null)   
        {
            EnemyKilledEvent(this);
        }
    }
}
