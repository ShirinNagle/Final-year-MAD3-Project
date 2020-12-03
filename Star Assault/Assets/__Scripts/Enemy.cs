using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();//add box collider
        boxCollider.isTrigger = false; //set trigger to not active 
    }

    // Update is called once per frame
    
    private void OnParticleCollision(GameObject other)
    {
        //print("Particles collided with enemy" + gameObject.name);
        Destroy(gameObject);
    }
}
