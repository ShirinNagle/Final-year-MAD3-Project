using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;    // text mesh pro library
using UnityEngine.SceneManagement;
using Utilities;

public class GameController : MonoBehaviour
{
    // public fields
    public int StartingLives { get { return startingLives; } }

    public int RemainingLives { get { return remainingLives; } }

    public int PlayerScore { get { return playerScore; } }
    bool gameHasEnded = false;
    public bool gamePaused = false;

    // private fields 
    private int playerScore = 0;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI livesText;
    [SerializeField] private int startingLives = 3;
    private int remainingLives = 0;

    // for the enemy waves
    [SerializeField] private List<WaveConfig> waveConfigList;
    private int startingWave = 0;
    //private int waveNumber = 0;//this is not used

    //Enemy info 
    [SerializeField] private TextMeshProUGUI remainingEnemyText;
    private int remainingEnemyCount;

    // audio sound to indicate "between wave" moment
    [SerializeField] private AudioClip waveReadySound;
    private SoundController sc;
    public SceneController sceneController;

    // private methods 

    #region Awake, OnEnable, OnDisable Methods
    private void Awake()
    {
        //may need to remove this - not working as expected - want the level information to carry from one level to the next if player can successfully move to the next level
       //DontDestroyOnLoad(this);
        SetupSingleton();

    }
    private void Start()
    {
        
        UpdateScore();
        //May need to move this or change it.
        remainingLives = startingLives;
        sc = SoundController.FindSoundController();
        sceneController = GetComponent<SceneController>();
        //StartCoroutine(SetupNextWave());
        StartCoroutine(SpawnAllWaves());
    }

    private void SetupSingleton()
    {
        // this method gets called on creation
        // check for any other objects of the same type
        // if there is one, then use that one.
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);    // destroy the current object
        }
        else
        {
            //This DontDestroyOnLoad doesn't persist data across and if you have shot all of the enemies in the wave, no more will spawn. If DontDestroyOnLoad is 
            //removed the enemies will spawn but lives remaning and score from previous scene is lost. The Singleton works for keeping the general state of the scene but
            // I need to figure out how to enable spawning for the next level..will put in SpawmAllWaves() here.
           DontDestroyOnLoad(gameObject);  // persist across scenes
            
            SpawnAllWaves();
        }
    }

    private void OnEnable()
    {
        Enemy.EnemyKilledEvent += OnEnemyKilledEvent;
        PointSpawners.EnemySpawnedEvent += PointSpawners_OnEnemySpawnedEvent;
    }

    private void OnDisable()
    {
        Enemy.EnemyKilledEvent -= OnEnemyKilledEvent;
        PointSpawners.EnemySpawnedEvent -= PointSpawners_OnEnemySpawnedEvent;
    }
    #endregion
    // set up a method to spawn all the waves.
    // make this a coroutine, wait for the SetupNextWave coroutine
    // to run, and then go to the next element in the list.

    private IEnumerator SpawnAllWaves()
    {
        // use a loop through the list.
        for(int waveIndex = startingWave; waveIndex < waveConfigList.Count; waveIndex++)
        {
            var waveConfig = waveConfigList[waveIndex];
            yield return StartCoroutine(SetupNextWave(waveConfig));
        }
    }

    private void UpdateEnemyRemainingText()
    {
        remainingEnemyText.text = remainingEnemyCount.ToString("000");
    }
    private IEnumerator SetupNextWave(WaveConfig currentWave)
    {
        yield return new WaitForSeconds(7.0f);
        sc.PlayOneShot(waveReadySound);
        FindObjectOfType<PointSpawners>().SetWaveConfig(currentWave);
        remainingEnemyCount = currentWave.GetEnemiesPerWave();
        EnableSpawning();
    }

    private void PointSpawners_OnEnemySpawnedEvent()
    {
        remainingEnemyCount--;
        UpdateEnemyRemainingText();
        if (remainingEnemyCount == 0)
        {
            DisableSpawning();
        }
    }

    private void DisableSpawning()
    {
        // find each PointSpawner, call a public method to disable spawning
        foreach(var spawner in FindObjectsOfType<PointSpawners>())
        {
            spawner.DisableSpawning();
        }
    }

    private void EnableSpawning()
    {
        // find each PointSpawner, call a public method to disable spawning
        foreach (var spawner in FindObjectsOfType<PointSpawners>())
        {
            spawner.EnableSpawning();
        }
    }

    private void OnEnemyKilledEvent(Enemy enemy)
    {
        // add the score value for the enemy to the player score
        playerScore += enemy.ScoreValue;
        UpdateScore();
    }

    private void UpdateScore()
    {
        Debug.Log("Score: " + playerScore);
        // display on screen
        scoreText.text = playerScore.ToString();
    }

    private void UpdateLives()
    {
        Debug.Log("Lives: " + remainingLives);
        // display on screen
        livesText.text = remainingLives.ToString();
    }

    // public methods 
    public void GameOver()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("Game Over");
            //Go to Game over menu
            //sceneController.GoToGameOver();
            SceneManager.LoadSceneAsync(SceneNames.GAME_OVER);
            //Restart();
        }

    }
    public void LoseOneLife()
    {
        remainingLives--;
        UpdateLives();
        //if lives == 0, need to tell the game that all lives are lost and game is over
        if(remainingLives == 0)
        {
            //load game over screen? or load a method to display the game over screen
            SceneManager.LoadSceneAsync(SceneNames.GAME_OVER);
            //Restart();

        }
    }
    public void Restart()
    {
        //My intention is for the game to restart when the player lives are lost -have decided to change this to going to the main menu
        //From looking at solutions on line I found the below code advice on https://answers.unity.com/questions/46918/reload-scene-when-dead.html
        //when the game reloads it doesn't relaod the begining spawners etc, sounds, lives , playerhealth etc.
        //I only want the score and lives to persist - look into persisting individual fields. I want the enemies to respawn but at the end of the level, the spawning has finished.
        //By moving to the next level it I need to trigger the enemyWave config. If the level is played on it's own the enemyWaves work but not when moving from a level.
        //Probably need to write a method to stop the wiping of info but ran out of time.
        //gamePaused = false;
       // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //SceneManager.LoadSceneAsync(SceneNames.MAIN_MENU);

        //This may be incorrect
        //SceneManager.LoadScene(SceneManager.GetSceneByName("Main Menu").ToString());
    }
}
