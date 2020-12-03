using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//if using more than 1 script to load scenes may need to move everything into a single scenemanager script 

public class CollisionHandler : MonoBehaviour
{
    [Tooltip("measured in secs")][SerializeField] float loadLevelDelay = 1.5f;//see how this timing works, may need to +/- the time.G
    [Tooltip("Explosion fx prefab on player goes here")] [SerializeField] GameObject deathFX;
    private void OnTriggerEnter(Collider other)
    {
        //print("Player triggered something");//left in for testing purposes
        StartPlayerDeath();
        deathFX.SetActive(true);
        Invoke("ReloadScene", loadLevelDelay);
    }
    private void StartPlayerDeath()
    {
        //print("player took a hit!");
        SendMessage("OnPlayerDeath");//string reference collisionHandler

    }

    private void ReloadScene()//String ref in OnTriggerEnter
    {
        SceneManager.LoadScene(1);
    }
}
