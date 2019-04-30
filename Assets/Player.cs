using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class Player : MonoBehaviour
{

    [Tooltip("In ms^-1")][SerializeField] float xSpeed = 10f;
    [SerializeField] float xClampValue = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
