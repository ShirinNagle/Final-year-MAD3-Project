using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField] float exitTime = 2.0f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //start a coroutine
        StartCoroutine("LoadNextLevel");
    }
    IEnumerator LoadNextLevel()
    {
        //change the timescale. Timescale can spped up/slow down world
        Time.timeScale = 0.2f;
        yield return new WaitForSecondsRealtime(exitTime);
        Time.timeScale = 1.0f;
        //get current scene index, then load the next one = currentScene +1
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);










    }

}
