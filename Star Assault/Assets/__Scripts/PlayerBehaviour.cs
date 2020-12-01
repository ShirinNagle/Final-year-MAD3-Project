using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] float xSpeed = 4.0f;   // default is in ms^-1
    [SerializeField] float ySpeed = 4.0f;   // default is in ms^-1
    [SerializeField] float hClamp = 10.0f;
    [SerializeField] float vClamp = 7.0f;

    [SerializeField] float controlPitchFactor = -30.0f;

    [SerializeField] float positionPitchFactor = -1.0f;
    [SerializeField] float positionYawFactor = -2.0f;
    [SerializeField] float controlRollFactor = -30.0f;

    float horizontalThrow, verticalThrow;
    bool controlsActive;

    // Start is called before the first frame update
    void Start()
    {
        controlsActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (controlsActive)
        {
            ProcessTranslation();
            ProcessRotation();
        }

    }

    private void PlayerHasDied()  // call by string reference
    {
        controlsActive = false;
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
}
