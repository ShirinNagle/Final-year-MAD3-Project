using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] AudioClip pickupSound;
    [SerializeField] int coinValue = 10;
    
    private void onTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<GameSession>().AddScore(coinValue);
        AudioSource.PlayClipAtPoint(pickupSound, Camera.main.transform.position);
        Destroy(gameObject);
        
    }
}
