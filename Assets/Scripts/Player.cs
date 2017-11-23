using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {


    [Tooltip("In ms^-1")] [SerializeField] private float xSpeed = 6.0f;


    [SerializeField] private float xAxisClamp = 4.75f;    // Left/Right limits
    [SerializeField] private float yAxisClamp = 2.5f;    // Up/Down limits


    [SerializeField] private float positionPitchFactor = -5.0f;
    [SerializeField] private float controlPitchFactor = -25.0f;

    [SerializeField] private float positionYawFactor = 5.0f;
    [SerializeField] private float controlYawFactor = 25.0f;


    [SerializeField] private float controlRollFactor = -20.0f;


    private float xThrow, yThrow;

    // Use this for initialization
    void Start () {
		

	}
	
	// Update is called once per frame
	void Update ()
    {
        ProcessTranslation();
        ProcessRotation();

    }

    private void ProcessTranslation()
    {
        // Pushing the movement in X
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        // Calculate the increment of how far the player should move
        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float yOffset = yThrow * xSpeed * Time.deltaTime;

        // Calculate new position
        float rawXPos = transform.localPosition.x + xOffset;
        float rawYPos = transform.localPosition.y + yOffset;

        // Clamp positions
        float clampedXPos = Mathf.Clamp(rawXPos, -xAxisClamp, xAxisClamp);
        float clampedYPos = Mathf.Clamp(rawYPos, -yAxisClamp, yAxisClamp);

        // move the ship
        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);

        //Debug.Log(xThrow + ", " + xSpeed  + ", " + xOffset + ", " + rawXPos + ", " + clampedXPos);
    }

    private void ProcessRotation()
    {

        // set local rotation 90 on Y
        // Quaternion.Euler(x, y, z)
        // Quaternion.Euler (pitch, yaw, roll)
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;


        float yawDueToPosition = transform.localPosition.x * positionYawFactor;
        float yawDueToControlThrow = xThrow * controlYawFactor;
        float yaw = yawDueToPosition + yawDueToControlThrow;


        float roll = xThrow * controlRollFactor;


        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);


    }


    private void OnCollisionEnter(Collision collision)
    {

        print("Player collided with: " + collision.gameObject);

    }

    private void OnTriggerEnter(Collider collider)
    {

        print("Player triggered with: " + collider.gameObject);

    }

}
