using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class PlayerController : MonoBehaviour
{
    [Header("General")]
    [Tooltip("In ms^-1")] [SerializeField] float xSpeed = 85f;
    [Tooltip("In ms^-1")] [SerializeField] float ySpeed = 85f;
    [SerializeField] float xClampValue = 22f;
    [SerializeField] float yClampValue = 12.5f;
    [Header("Screen-Position based")]

    [SerializeField] float positionPitchFactor = -3.5f;
    [SerializeField] float positionYawFactor = 2f;

    [Header("Control-Throw based")]

    [SerializeField] float controlPitchFactor = -20f;
    [SerializeField] float controlRollFactor = -20f;

    float xThrow, yThrow;

    bool isControlEnabled = true;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isControlEnabled)
        {
            moveHorizontal();
            moveVertical();
            processRotation();
        }

    }

    private void processRotation()
    {
        float pitch = transform.localPosition.y * positionPitchFactor + yThrow * controlPitchFactor;
        float yaw = transform.localPosition.x * positionYawFactor;

        float roll = xThrow * controlRollFactor;


        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
        // pitch, yaw, roll


    }

    private void moveVertical()
    {
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * ySpeed * Time.deltaTime;
        //take the ships x position
        // - 5 to +5
        //work out a new x position
        float rawNewYPosition = transform.localPosition.y + yOffset;
        float newYPosition = Mathf.Clamp(rawNewYPosition, -yClampValue, yClampValue);
        transform.localPosition = new Vector3(transform.localPosition.x, newYPosition, transform.localPosition.z);
    }

    //order of rotation matters
    //rotate ship 90 deg

    private void moveHorizontal()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * xSpeed * Time.deltaTime;
        //take the ships x position
        // - 5 to +5
        //work out a new x position
        float rawNewXPosition = transform.localPosition.x + xOffset;
        float newXPosition = Mathf.Clamp(rawNewXPosition, -xClampValue, xClampValue);
        transform.localPosition = new Vector3(newXPosition, transform.localPosition.y, transform.localPosition.z);
    }

    void OnPlayerDeath() //called by string
    {
        print("got message, die now...");
        isControlEnabled = false;

    }
}
