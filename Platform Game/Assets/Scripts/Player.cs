using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * set gravity to 0 on the ladder - in the ClimbLadder()
 * get the gravityscale of the rigidbody at the start
 * when the player is on the ladder, set the  gravityscale 0
 * reset when the player is not on the ladder
 * 
 * 
 */

public class Player : MonoBehaviour
{
    [SerializeField] float runSpeed = 5.0f;
    [SerializeField] float jumpSpeed = 28.0f;
    [SerializeField] float climbSpeed = 5.0f;
    [SerializeField] Vector2 deathRoll = new Vector2(15.0f,15.0f);
    float gravityScaleAtStart; //the gravity scale set to 1
    bool IsAlive;

    Rigidbody2D myRigidBody;
    CapsuleCollider2D myBodyCollider;
    BoxCollider2D myFeetCollider;
    Animator myAnimator;
    

    // Start is called before the first frame update
    void Start()
    {
        IsAlive = true;
        myRigidBody = GetComponent<Rigidbody2D>();
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        myFeetCollider = GetComponent<BoxCollider2D>();
        myAnimator = GetComponent<Animator>();
        gravityScaleAtStart = myRigidBody.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsAlive)//takes away player functionality
        {
            return;
        }
        //Calling methods
        Die();
        Run();
        Jump();
        ClimbLadder();
        

    }

    private void Die()
    {
        //Checks is the player touching the enmey layer - if yes then die.
        if (myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemy", "Hazards")))
        {
            
            //set off animation
            myAnimator.SetTrigger("TriggerDying");
            //Make player move 
            myRigidBody.velocity = deathRoll;//vector 2 fpr x,y. Velocity to be set
            //Player is now dead
            IsAlive = false;
            //call the session manager
            FindObjectOfType<GameSession>().ProcessPlayerDeath();
            
        }
    }

    private void Run()
    {
        //use input mgr to get the horizontal movement
        float xDir = Input.GetAxis("Horizontal");
        Vector2 playerVelocity = new Vector2(xDir * runSpeed, myRigidBody.velocity.y);
        myRigidBody.velocity = playerVelocity;

        //Math.Epsilon smaller value > 0 that unity records
        //math.abs value of movement
        //flip sprite using a bool value for speed
        bool playerHasHorizontalMovement = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalMovement) 
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x), 1.0f);
            myAnimator.SetBool("IsRunning", playerHasHorizontalMovement);
        }
        else
        {
            myAnimator.SetBool("IsRunning", false);
        }

    }

    private void Jump()
    {
        //player jump based on the input mgr only when on Ground(layer called layer in game)
        //IsTouchingLayers
        //uses a LayerMask
        //use to test if the player is not in contact with the ground -> exit method
       

        if (!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) //player can jump but only on the ground
        {
            return;
        }

        if (Input.GetButtonDown("Jump"))
        {
            //change velocity in y direction
            Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed);
            myRigidBody.velocity += jumpVelocityToAdd;
        }
    }

    private void ClimbLadder()
    {
        
        if (!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ladder")))
        {
           myAnimator.SetBool("IsClimbing", false);
           myRigidBody.gravityScale = gravityScaleAtStart;//setting the gravity scale to 1 if no longer climbing
            return;
        }
        float yDir = Input.GetAxis("Vertical");
        Vector2 climbVelocity = new Vector2(myRigidBody.velocity.x, yDir * climbSpeed);
        myRigidBody.velocity = climbVelocity;
        myRigidBody.gravityScale = 0f;

        //If there is vertical movement, change boolean
        bool playerHasVerticalSPeed = Mathf.Abs(myRigidBody.velocity.y) > Mathf.Epsilon;
        myAnimator.SetBool("IsClimbing", playerHasVerticalSPeed);
    }
}
