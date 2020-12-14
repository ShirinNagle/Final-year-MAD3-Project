using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    

    // private fields
    private Rigidbody2D rb;

    private Camera gameCamera;
    
    [SerializeField] private float speed = 5.0f;
    //private methods
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // add hMovement
        // if the player presses the up arrow, then move
        float vMovement = Input.GetAxis("Vertical");
        float hMovement = Input.GetAxis("Horizontal");
        // apply a force, get the player moving.
        rb.velocity = new Vector2(hMovement * speed, vMovement * speed);
        // keep the player on the screen
        float posYMinValue = -6.0f;
        float posYMaxValue = 6.0f;
        float posXMinValue = -11.0f;
        float posXMaxValue = 11.0f;
        float yValue = Mathf.Clamp(rb.position.y, posYMinValue, posYMaxValue);
        float xValue = Mathf.Clamp(rb.position.x, posXMinValue, posXMaxValue);

        rb.position = new Vector2(xValue, yValue);
    }
}
