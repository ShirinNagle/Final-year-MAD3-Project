using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Utilities;    // scene names

// sceneManageent library - load, unload scenes
using UnityEngine.SceneManagement;



public class SceneController : MonoBehaviour
{
    // onclick Events
    public void Start_OnClick()
    {
        SceneManager.LoadSceneAsync(SceneNames.GAME_LEVEL);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadSceneAsync(SceneNames.MAIN_MENU);
    }
    public void GoToLevel2()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadSceneAsync(SceneNames.GAME_LEVEL2);
    }
    public void GoToSettingsMenu()
    {
        SceneManager.LoadSceneAsync(SceneNames.SETTINGS);
    }
    public void GoToLevelFinished()
    {
        SceneManager.LoadSceneAsync(SceneNames.LEVEL_FINISHED);

    }
    public void GoToGameOver()
    {
        SceneManager.LoadSceneAsync(SceneNames.GAME_OVER);
    }
    public void Options_OnClick()
    {
        //trying to keep the game at the same state - when I hit pause
        //Doesn't work here!! - 
        //DontDestroyOnLoad(gameObject);
        //May change this
        SceneManager.LoadSceneAsync(SceneNames.OPTIONS_MENU,
        LoadSceneMode.Additive);//SceneManager loads your new Scene as an extra Scene (overlapping the other). This is Additive mode.
        //SceneManager.LoadSceneAsync(SceneNames.OPTIONS_MENU);
    }

    public void GoToPause()
    {
        //trying to keep the game at the same state - when I hit pause
        //Doesn't work here!!
       //DontDestroyOnLoad(this);
        //May change this
        SceneManager.LoadSceneAsync(SceneNames.OPTIONS_MENU,
        LoadSceneMode.Additive);//SceneManager loads your new Scene as an extra Scene (overlapping the other). This is Additive mode.
        //SceneManager.LoadSceneAsync(SceneNames.OPTIONS_MENU);
    }
    public void ResumeGame()
    {
        GameController gc = FindObjectOfType<GameController>();
        gc.gamePaused = false;
        //DontDestroyOnLoad(gameObject);
        SceneManager.UnloadSceneAsync(SceneNames.OPTIONS_MENU);

    }
    public void GoToIntroduction()
    {
        SceneManager.LoadSceneAsync(SceneNames.LEVEL_FINISHED);

    }
    public void GoToTutorial()
    {
        SceneManager.LoadSceneAsync(SceneNames.TUTORIAL);

    }

    public void OptionsBack_OnClick()
    {
        //DontDestroyOnLoad(this);
        // this unloads the options menu
        SceneManager.UnloadSceneAsync(SceneNames.OPTIONS_MENU);
    }



}
