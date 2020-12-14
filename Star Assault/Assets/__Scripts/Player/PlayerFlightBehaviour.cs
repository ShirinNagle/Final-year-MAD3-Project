using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerFlightBehaviour : MonoBehaviour
{
    [Header("General")]
    [SerializeField] float xSpeed = 4.0f;   // default is in ms^-1
    [SerializeField] float ySpeed = 4.0f;   // default is in ms^-1
    [SerializeField] GameObject[] bullets;
    [Header("Clamp range")]
    [SerializeField] float hClamp = 25.0f;//10.0f
    [SerializeField] float vClamp = 10.0f;//7.0f
    [Header("Control throw")]
    [SerializeField] float controlPitchFactor = -20.0f;//-30
    [SerializeField] float controlRollFactor = -30.0f;
    [Header("Screen Position")]
    [SerializeField] float positionPitchFactor = -1.0f;//-1.0f;
    [SerializeField] float positionYawFactor = 1.0f;//-2.0f


    float horizontalThrow, verticalThrow;
    bool controlsActive;

    //Health Bar variables
   // public HealthBarPlayer healthBar;//move to player
    //public int currentHealth;//move to player
    //public int maxHealth = 100;//move to player

    GameSessionController gameSession;
    // Start is called before the first frame update
    void Start()
    {
        controlsActive = true;
        //currentHealth = maxHealth;//move to player
        //healthBar.SetMaxHealth(maxHealth);//move to player

    }
    // Update is called once per frame
    void Update()
    {
        if (controlsActive)
        {
            ProcessTranslation();//L,R, U, D
            ProcessRotation();
            ProcessFiring();
        }

    }

    private void OnPlayerDeath()  // call by string reference
    {
        controlsActive = false;
        //print("controls frozen");
        //need to add more code here for the dying part

        //player is dying somewhere else ...likethe collisionhandler, need to see where is best place for killing player

        //call the sessionController to kill the player
        //FindObjectOfType<GameSessionController>().processPlayerDeath();
    }
    private void OnPlayerReset()//not sure about this method, may need to move it.
    {
        controlsActive = true;
    }

    private void ProcessRotation()
    {
        float pitch = transform.localPosition.y * positionPitchFactor + controlPitchFactor * verticalThrow; ;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = controlRollFactor * horizontalThrow;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);

    }

    private void ProcessTranslation()
    {
        horizontalThrow = Input.GetAxis("Horizontal");
        verticalThrow = Input.GetAxis("Vertical");
        float xOffset = horizontalThrow * xSpeed * Time.deltaTime;
        float yOffset = verticalThrow * ySpeed * Time.deltaTime;

        float xPos = Mathf.Clamp(transform.localPosition.x + xOffset, -hClamp, hClamp);
        float yPos = Mathf.Clamp(transform.localPosition.y + yOffset, -vClamp, vClamp);

        transform.localPosition = new Vector3(xPos,
                                              yPos,
                                              transform.localPosition.z);
    }

    private void ProcessFiring()
    {
        if (Input.GetButton("Fire"))
        {
           // print("fire button working");
            //print(bullets.Length);
            ActivateBullets(true);
        }
        else
        {
            ActivateBullets(false);
        }
    }
    void ActivateBullets(bool isActive)
    {
        foreach(GameObject bullet in bullets)//fix code for active and inactive, may effect explosion which is a child of GameObject
        {
            //bullet.SetActive(true);
            var emissionElement = bullet.GetComponent<ParticleSystem>().emission;
            emissionElement.enabled = isActive;
        }
    }

    /*private void TakeDamage(int damage)//move to player.
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }*/

    /*private void OnParticleCollision(GameObject other)
    {
        playerHit();
        

    }*/

    /*private void playerHit()
    {
        gameSession.reduceHealth();
    }*/
}
