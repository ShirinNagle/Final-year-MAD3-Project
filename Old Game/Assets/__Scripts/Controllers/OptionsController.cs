using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsController : MonoBehaviour
{
   // OnClick methods
   public void Back_OnClick()
    {
        //mode is additive, just unload the current scene
        SceneManager.UnloadSceneAsync("OptionsMenu");
    }
}
