using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // set up an initial health value,
    // set an amount of damage per enemy
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private int playerStartHealth = 20;
    private int playerCurrentHealth;
    private GameController gc;
    private Vector3 startPosition;
    private SpriteRenderer sr;
    private PolygonCollider2D pc2d;
    private WeaponsController wc;
    private PlayerMovement pm;
    //may not use this
    private ParticleSystem ps;

     //want to make this value public as I want the lives to decrement, depending on this value
    public int PlayerCurrentHealth
    {
        set { playerCurrentHealth = value; }
        get { return playerCurrentHealth; }
    }

   // public float PlayerSize
    //{
       // set { playerSize = value; }
       // get { return playerSize;  }
  //  }
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        pc2d = GetComponent<PolygonCollider2D>();
        wc = GetComponent<WeaponsController>();
        pm = GetComponent<PlayerMovement>();
        //may not use this - it looks ok on the player..
        ps = GetComponentInChildren<ParticleSystem>();

        playerCurrentHealth = playerStartHealth;
        gc = FindObjectOfType<GameController>();
        startPosition = new Vector3(transform.position.x,
                                     transform.position.y,
                                     transform.position.z);
    }

    // use the triggerEnter method to see if it gets hit by enemy
    private void OnTriggerEnter2D(Collider2D whatHitMe)
    {
        var enemy = whatHitMe.GetComponent<Enemy>();
        if(enemy)
        {
            playerCurrentHealth -= enemy.DamageValue;
            //may need to move this or rename it
            transform.localScale += new Vector3(.25f, .25f, .25f);
           
            // this field is for comparison - but in a private method 
            //playerSize = transform.localScale;

            Debug.Log($"Player Health: = {playerCurrentHealth}");
        }
        if(playerCurrentHealth <= 0)
        {
            // player should die
            Die();
        }
    }

    private void Die()
    {
        // need to stop the player interacting - disable weapons
        // make the player disappear
        // need to play an explosion
        // hide the object, then make it reappear at the start - DieCoroutine handles all of this...maybe useful for retart/continue to next level ..
        StartCoroutine(DieCoroutine());
    }

    private IEnumerator DieCoroutine()
    {
        // disable components - makes the player disappear
        DisableComponents();
        GameObject explosion = Instantiate(explosionPrefab);
        explosion.transform.position = transform.position;
        // tell the game controller lost one life
        gc.LoseOneLife();

        yield return new WaitForSeconds(1.5f);
        if(gc.RemainingLives > 0)
        {
            Respawn();
        }
        //if no lives left game finishes
        else
        {

            FindObjectOfType<GameController>().GameOver();
        }
    }

    private void DisableComponents()
    {
        // SpriteREnderer, PolygonCollider2d, Weaspons, Movement
        SetComponentsEnabled(false);
    }

    private void EnableComponents()
    {
        SetComponentsEnabled(true);
    }

    private void SetComponentsEnabled(bool status)
    {
        sr.enabled = status;
        pc2d.enabled = status;
        wc.enabled = status;
        pm.enabled = status;
        if(status == true)
        {
            ps.Play();
        }
        else
        {
            ps.Stop();
        }
        
    }

    private void Respawn()
    {
        // set the player back to the start position
        // reset the player health
        // re-enable all the components to make the player visible.
        transform.position = startPosition;
        //transform.localScale = new Vector3(1, 1, 1);
        playerCurrentHealth = playerStartHealth;
        EnableComponents();
    }
}
//https://answers.unity.com/questions/1110170/increase-size-after-collision.html
//used the above to find out how to scale the players size.