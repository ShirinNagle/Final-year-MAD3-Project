using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utilities;

public class moveScene : MonoBehaviour
{
    //private fields
    [SerializeField] private string loadLevel;
    private GameController gc;
    private PlayerHealth ph;
    private LifeCounter lc;
    private SceneNames sc;

    private void Start()
    {
        ph = FindObjectOfType<PlayerHealth>();
        lc = FindObjectOfType<LifeCounter>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //want to check if player has points and has enough lives to continue
       //if (gc.PlayerScore > 0 && gc.RemainingLives > 0)
        //{
            //Debug.Log("Hit the pipe");
            if (other.CompareTag("Player"))
            {
                SceneManager.LoadScene(loadLevel);

            }
           // else
           // {
               // SceneManager.LoadSceneAsync(SceneNames.GAME_OVER);
           // }
      // }
    }
    
}

//https://www.youtube.com/watch?v=izl5VUm2Frk
