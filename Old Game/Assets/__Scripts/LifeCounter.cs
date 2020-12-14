using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// get the number of lives at the start from the GameController
// use this to set up the icons for lives in a loop? - Can't decrement the lives in this loop. Need to investigate further
// NB will need a prefab to use for the icons

public class LifeCounter : MonoBehaviour
{
    //private fields
    [SerializeField] private LifeIcon lifeIconPrefab; // using a banana for now, may change this class for something else while I figure out how to decreemnt the lives

    private int startingLives;  // read from the Game Controller
    private int remainingLives; // read from the Game Controller
    private GameController gc;
    private PlayerHealth ph;

    void Start()
    {
        // get the GameController object
        gc = FindObjectOfType<GameController>();
        if(gc)
        {
            // retrieve the starting lives value
            // set up a read only public property to return
            // the number of starting lives
            startingLives = gc.StartingLives;
            remainingLives = gc.RemainingLives;
            //startingLives = remainingLives;
            CreateIcons();
        }
    }

    private void CreateIcons()
    {
        // show the number of life icons
        // use a loop
        for(int i = 0; i < startingLives; i++)
        {
            LifeIcon icon = Instantiate(lifeIconPrefab, transform);
        }
        //get PlayerHealth object
        

    }
    //contents of Update may need to move back to create Icons - wan tthe player health when it gets to 0 to decrement the no. of lives
    public void Update()
    {
        //get PlayerHealth object
        ph = FindObjectOfType<PlayerHealth>();
        //if Player health is less than 0, then lose one life.
        if (ph.PlayerCurrentHealth < 0)
        {
            Debug.Log("Lost a life");// this was displaying on the console - not now!!
            LoseOneLife();
        }

    }

    //public methods
    public void LoseOneLife()
    {
        
        startingLives--;

        //may need to move this
        // for (int i = 0; i < startingLives; i++)
        // {
        //    LifeIcon icon = Instantiate(lifeIconPrefab, transform);
        //}
        CreateIcons();

    }

}
