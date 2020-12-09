using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePersists : MonoBehaviour
{
    private int startUpScene = 0;
    private void Awake()
    {
        int numScenePersists = FindObjectsOfType<ScenePersists>().Length;
        if(numScenePersists > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        startUpScene = SceneManager.GetActiveScene().buildIndex;
    }

    private void Update()
    {
        int currScene = SceneManager.GetActiveScene().buildIndex;
        if(currScene != startUpScene)
        {
            Destroy(gameObject);
        }
    }


}
