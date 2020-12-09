using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Portal : MonoBehaviour
{
    [SerializeField] float exitTime = 2.0f;//may not use this way of moving from scene to scene
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        //start a co routine
        StartCoroutine("LoadNextLevel");
    }
    
    IEnumerator LoadNextLevel()
    {
        //change the time scale. Timescale can speed up or slow down world - consider speeding up like warp speed on exit level
        Time.timeScale = 0.2f;
        yield return new WaitForSecondsRealtime(exitTime);
        //get the current scene index, then load the next one = currentScene +1
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
