using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton: MonoBehaviour
{
   //event handler
   public void startGame()
    {
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    public void startMultiPlayerGame()
    {
        //code to go here which triggers the multiplayer element of the game...not sure how best to implement yet.
    }
}
