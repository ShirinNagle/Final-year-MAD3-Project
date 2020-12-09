using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2.0f;
    Rigidbody2D myRB;
    // Start is called before the first frame update
    void Start()
    {

            myRB = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsFacingRight())
        {
            myRB.velocity = new Vector2(moveSpeed, 0f);
        }
        else
        {
            myRB.velocity = new Vector2(-moveSpeed, 0f);
        }
    }

    private bool IsFacingRight()
    {
        return transform.localScale.x > 0;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //triggered when the dragon stops colliding with the ground.#
        //set the scale X value - localScale on the transform
        transform.localScale = new Vector2(-Mathf.Sign(myRB.velocity.x), 1f);
    }
}
