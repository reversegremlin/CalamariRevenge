using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class Player : MonoBehaviour
{

    [Tooltip("In ms^-1")] [SerializeField] float xSpeed = 10f;
    [Tooltip("In ms^-1")] [SerializeField] float ySpeed = 10f;
    [SerializeField] float xClampValue = 5f;
    [SerializeField] float yClampValue = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal();
        moveVertical();

    }

    private void moveVertical()
    {
        float yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * ySpeed * Time.deltaTime;
        //take the ships x position
        // - 5 to +5
        //work out a new x position
        float rawNewYPosition = transform.localPosition.y + yOffset;
        float newYPosition = Mathf.Clamp(rawNewYPosition, -yClampValue, yClampValue);
        transform.localPosition = new Vector3(transform.localPosition.x, newYPosition, transform.localPosition.z);
    }

    private void moveHorizontal()
    {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * xSpeed * Time.deltaTime;
        //take the ships x position
        // - 5 to +5
        //work out a new x position
        float rawNewXPosition = transform.localPosition.x + xOffset;
        float newXPosition = Mathf.Clamp(rawNewXPosition, -xClampValue, xClampValue);
        transform.localPosition = new Vector3(newXPosition, transform.localPosition.y, transform.localPosition.z);
    }
}
