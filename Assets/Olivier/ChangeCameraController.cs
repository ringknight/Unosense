using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ChangeCameraController : MonoBehaviour
{

    public Camera[] cameras;
    private int currentCameraIndex;
    private bool canSwitch = true; // Debounce flag

    // Start is called before the first frame update
    void Start()
    {
        if (cameras.Length > 0)
        {
            // Activate the first camera and deactivate the rest at the start
            ActivateCamera(currentCameraIndex);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check if B button is pressed
        if (Input.GetButtonDown("Fire2") && canSwitch)
        {
            currentCameraIndex++;
            if (currentCameraIndex >= cameras.Length)
            {
                currentCameraIndex = 0;
            }
            ActivateCamera(currentCameraIndex);
            canSwitch = false; // Prevent further switches until button is released
        }
        else if (Input.GetButtonDown("Fire3") && canSwitch)
        {
            currentCameraIndex--;
            if (currentCameraIndex < 0)
            {
                currentCameraIndex = cameras.Length - 1;
            }
            ActivateCamera(currentCameraIndex);
            canSwitch = false; // Prevent further switches until button is released
        }

        // Reset the debounce flag if either button is released
        if (Input.GetButtonUp("Fire2") || Input.GetButtonUp("Fire3"))
        {
            canSwitch = true;
        }
    }

    void ActivateCamera(int index)
    {
        foreach (var cam in cameras)
        {
            cam.gameObject.SetActive(false);
        }
        cameras[index].gameObject.SetActive(true);
    }
}
