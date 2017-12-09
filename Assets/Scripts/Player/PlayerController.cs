using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {


    [Header("General")]
    [Tooltip("In ms^-1")] [SerializeField] private float xControlSpeed = 6.0f;
    [SerializeField] private float xAxisClamp = 4.75f;    // Left/Right limits
    [SerializeField] private float yAxisClamp = 2.5f;    // Up/Down limits
    [SerializeField] private GameObject[] guns;


    [Header("Screen Position")]
    [SerializeField] private float positionPitchFactor = -5.0f;
    [SerializeField] private float positionYawFactor = 5.0f;

    [Header("Control Throw")]
    [SerializeField] private float controlPitchFactor = -25.0f;
    [SerializeField] private float controlYawFactor = 25.0f;
    [SerializeField] private float controlRollFactor = -20.0f;


    private float xThrow, yThrow;


    private bool isPlayerAlive = true;

    // Use this for initialization
    void Start () {
		

	}
	
	// Update is called once per frame
	void Update ()
    {

        if(isPlayerAlive)
        {
            ProcessTranslation();
            ProcessRotation();

            // Press space bar to fire
            ProcessFiring();

        }

    }

    private void ProcessTranslation()
    {
        // Pushing the movement in X
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        // Calculate the increment of how far the player should move
        float xOffset = xThrow * xControlSpeed * Time.deltaTime;
        float yOffset = yThrow * xControlSpeed * Time.deltaTime;

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

    /// <summary>
    /// Kill player controls when the player dies
    /// CALLED BY STRING REFERENCE
    /// </summary>
    public void KillPlayerControls()
    {
        print("KillPlayerControls() called");
        isPlayerAlive = false;

    }


    private void ProcessFiring()
    {
        if(CrossPlatformInputManager.GetButton("Fire"))
        {

            ActivateGuns();

        } else
        {
            DeactivateGuns();
        }

    }

    private void ActivateGuns()
    {
        foreach (GameObject gun in guns)
        {
            gun.SetActive(true);
        }
    }

    private void DeactivateGuns()
    {
        foreach (GameObject gun in guns)
        {
            gun.SetActive(false);
        }
    }

}
