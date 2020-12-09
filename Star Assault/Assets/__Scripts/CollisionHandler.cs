using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//if using more than 1 script to load scenes may need to move everything into a single scenemanager script 

//https://www.udemy.com/course/unitycourse2/learn/lecture/8314012#overview
public class CollisionHandler : MonoBehaviour
{
    [Tooltip("measured in secs")][SerializeField] float loadLevelDelay = 1.5f;//see how this timing works, may need to +/- the time.G
    [Tooltip("Explosion fx prefab on player goes here")] [SerializeField] GameObject deathFX;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "portal")
        {
            print("Player triggered something");//left in for testing purposes
            StartPlayerDeath();
            deathFX.SetActive(true);
            Invoke("ReloadScene", loadLevelDelay);
        }
        else
        {
            LoadNextLevel();
            print("player went through box");
        }
       
    }
    
    private void StartPlayerDeath()
    {
        print("player took a hit!");
        //consider changing names to something more generic for reuse of code ie enemy could die ... 
        //SendMessage("OnPlayerDeath");//string reference collisionHandler -not sure where this refers to!!
        //need to add explosion and stuff here

    }

    private void ReloadScene()//String ref in OnTriggerEnter
    {
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        
        /*if (currentSceneIndex != 1)
        {
            SceneManager.LoadScene(currentSceneIndex);
        }
        else
        {
            SceneManager.LoadScene(1);
        }*/
    }

    
    //IEnumerator LoadNextLevel()//possibly change this method back to yield return
    private void LoadNextLevel()
    {
        //change the time scale. Timescale can speed up or slow down world - consider speeding up like warp speed on exit level
        //Time.timeScale = 0.2f;
       // yield return new WaitForSecondsRealtime(loadLevelDelay);//change to a serialized field - possibly
        //get the current scene index, then load the next one = currentScene +1
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
