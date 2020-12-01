using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MusicPlayer : MonoBehaviour
{
    //may add a singleton

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);//don't destroy music player
    }

    void Start()
    {
        Invoke("LoadScene", 7f);

    }

    void LoadScene()
    {
        SceneManager.LoadScene(1);
    }
}
