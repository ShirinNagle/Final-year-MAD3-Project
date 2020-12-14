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
        SceneManager.LoadSceneAsync(SceneNames.MULTIPLAYER);
    }
    public void quitGame() 
    {
        SceneManager.LoadScene(0);
        //need to destroy the other scene?? it overlays somehow - possibly game seesion controller script should not be there.
    }
    public void playAgain()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadSettings()
    {
        SceneManager.LoadSceneAsync(SceneNames.SETTINGS);
    }
}
