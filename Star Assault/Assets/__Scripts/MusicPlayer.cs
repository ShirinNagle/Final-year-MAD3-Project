using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MusicPlayer : MonoBehaviour
{
    //may add a singleton

    private void Awake()
    {
        int numMusicPlayer = FindObjectsOfType<MusicPlayer>().Length;
        //if more than 1 music player in a scene - then need to destroy this music player
        if(numMusicPlayer > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);//don't destroy music player
        }
        
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
