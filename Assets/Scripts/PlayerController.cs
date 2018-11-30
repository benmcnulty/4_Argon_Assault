using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

    [Header("General")]
    [Tooltip("In ms^-1")] [SerializeField] float controlSpeed = 15f;
    [Tooltip("In m")][SerializeField] float xRange = 10f;
    [Tooltip("In m")] [SerializeField] float yRange = 7f;

    [Header("Screen-position Based")]
    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float positionYawFactor = 6f;

    [Header("Control-throw Based")]
    [SerializeField] float controlPitchFactor = -5f;
    [SerializeField] float controlRollFactor = -30f;

    float xThrow, yThrow;

    bool playerCrashed = false;

	// Update is called once per frame
	void Update () {
        if (!playerCrashed)
        {
            ProcessTranslation();
            ProcessRotation();
        }
    }

    private void ProcessTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = xThrow * controlSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        float yOffset = yThrow * controlSpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    private void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;

        float pitch = pitchDueToPosition + pitchDueToControlThrow;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void PlayerCrashed()
    {
        playerCrashed = true;
    }
}
