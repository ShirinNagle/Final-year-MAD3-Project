using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUP : MonoBehaviour
{
    [SerializeField] int scorePerPowerUP = 1;
    [SerializeField] AudioClip powerUpCollected;
    void Start()
    {
        AddBoxCollider();
        //scoreBoard = FindObjectOfType<Score>();
        //ProcessFiring();
    }

    private void AddBoxCollider()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();//add box collider
        boxCollider.isTrigger = false; //set trigger to not active
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();

    }

    private void ProcessHit()
    {
        //need to get playerhealth amount and increment if not already full
        // if(FindObjectOfType<GameSessionController>().)
        AudioSource.PlayClipAtPoint(powerUpCollected,Camera.main.transform.position);
        Destroy(gameObject);
    }
}
