using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject menuPauseUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause(); 
            }
        }
    }

    private void Pause()
    {
        menuPauseUI.SetActive(true);
        //Definitely need to pause timeline too - look at scripts for this ...maybe player
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void Resume()
    {
        menuPauseUI.SetActive(false);
        //May need to pause timeline too - look at scripts for this ...maybe player
        Time.timeScale = 1f;
        gameIsPaused = false;

    }
    public void LoadMenu()//may not use
    {
        //Debug.Log("loading menu");
    }
    public void QuitGame()
    {
        //Debug.Log("quitting game");
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
       // Application.Quit();
    }
}
//https://www.youtube.com/watch?v=JivuXdrIHK0