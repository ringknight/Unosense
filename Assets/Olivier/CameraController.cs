using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine.InputSystem;
using UnityEngine;
using System.Xml.Schema;
using System.Runtime.CompilerServices;
using System.Threading;

public class CameraController : MonoBehaviour
{
    [Header("Camera Limits")]
    [Tooltip("This defines the rotation limit of the camera on the Y Axis at the top")][SerializeField] private float CameraMoveLimitUp;
    [Tooltip("This defines the rotation limit of the camera on the Y Axis at the bottom")][SerializeField] private float CameraMoveLimitDown;
    [Tooltip("This defines the rotation limit of the camera on the X Axis on the left")][SerializeField] private float CameraMoveLimitLeft;
    [Tooltip("This defines the rotation limit of the camera on the X Axis on the right")][SerializeField] private float CameraMoveLimitRight;
    [Tooltip("This defines the Zoom (FieldOfView) limit of the camera when zooming out")][SerializeField] private float CameraZoomLimitOut;
    [Tooltip("This defines the Zoom (FieldOfView) limit of the camera when zooming in")][SerializeField] private float CameraZoomLimitIn;

    [Header("Camera Speed settings")]
    [Tooltip("This defines the speed of the camera movement")][SerializeField] private float CameraMoveSpeed;
    [Tooltip("This defines the speed of the camera zoom")][SerializeField] private float CameraZoomSpeed;

    [Header("Other variables")]
    [SerializeField] public float joystickSensitivity = 0.1f;
    [SerializeField] public float bumperSensitivity = 0.1f;

    // Initial values
    private float InitialCameraRotationX = 0;
    private float InitialCameraRotationY = 0;
    
    private float InitialFieldOfView = 0;

    private Transform trans;
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<Transform>();
        cam = GetComponent<Camera>();

        if(trans)
        {
            InitialCameraRotationX = trans.localRotation.x;
            InitialCameraRotationY = trans.localRotation.y;
        } else
        {
            Debug.Log("There was an error getting the transform of a camera");
        }

        if (cam)
        {
            InitialFieldOfView = cam.fieldOfView;
        } else
        {
            Debug.Log("There was an error getting the camera settings of a camera");
        }

        Debug.Log("Initial Camera X " + InitialCameraRotationX.ToString());
        Debug.Log("Initial Camera Y " + InitialCameraRotationY.ToString());
        Debug.Log("Initial FOV " + InitialFieldOfView.ToString());

        Debug.Log("Max Camera Rotation UP X is " + getCameraUpLimit().ToString()); //Should be lower
        Debug.Log("Min Camera Rotation DOWN X is " + getCameraDownLimit().ToString()); //Should be higher
        Debug.Log("Leftest Camera Rotation LEFT Y is " + getCameraLeftLimit().ToString()); //Should be lower
        Debug.Log("Rightest Camera Rotation RIGHT Y is " + getCameraRightLimit().ToString()); //Should be higher

        Debug.Log("Zoom In Camera limit is " + getCameraZoomInLimit().ToString()); //Should be lower
        Debug.Log("Zoom Out Camera limit is " + getCameraZoomOutLimit().ToString()); //Should be higher


    }

    // Update is called once per frame
    void Update()
    {

        // Get the input value of the left joystick

        // X POSITIVE = MOVE RIGHT
        // X NEGATIVE = MOVE LEFT
        // Y POSITIVE = MOVE UP
        // Y NEGATIVE = MOVE DOWN

        Vector2 leftStickInput = Gamepad.current.leftStick.ReadValue();
        if (leftStickInput != null)
        {
            if(leftStickInput.magnitude > joystickSensitivity)
            {
                moveCamera(leftStickInput);
                
                //float leftStickX = leftStickInput.x;
                //float leftStickY = leftStickInput.y;
                //if (leftStickX != 0 && leftStickY != 0) { Debug.Log( "X:" + leftStickX.ToString() + " - Y:" + leftStickY.ToString()); }
                
            }
        }

        //Get the input value of the Triggers
        float leftBumperInput = Gamepad.current.leftTrigger.ReadValue();
        float rightBumperInput = Gamepad.current.rightTrigger.ReadValue();

        /*
         * if (leftBumperInput != 0) { Debug.Log(leftBumperInput.ToString()); }
         * if (rightBumperInput != 0) { Debug.Log(rightBumperInput.ToString()); }
        */

        if (leftBumperInput != 0 && rightBumperInput != 0)
        {
            //Do Nothing
        } else
        {
            if(leftBumperInput > 0 && leftBumperInput > bumperSensitivity)
            {
                zoomCamera(leftBumperInput);
            } else if (rightBumperInput > 0 & rightBumperInput > bumperSensitivity)
            {
                zoomCamera(rightBumperInput);
            }
        }
    }

    void moveCamera (Vector2 input)
    {
        
        //Get the current rotation status
        float currentXRotation = trans.rotation.x;
        float currentYRotation = trans.rotation.y;

        //Handle the Y axis which rotates the X axis of the camera
        float YValue = input.y;
        if (YValue < 0 && canMoveDown())
        {

            //Quaternion newRotation = Quaternion.Euler(Mathf.Clamp(transform.rotation.eulerAngles.x - YValue, CameraMoveLimitUp, CameraMoveLimitDown), 0f, 0f);
            //trans.rotation = newRotation;
            float rotationAmout = YValue * CameraMoveSpeed * Time.deltaTime;
            trans.Rotate(-rotationAmout, 0f, 0f, Space.Self);
            fixZAxis();
        } else if (YValue > 0 && canMoveUp())
        {
            //Quaternion newRotation = Quaternion.Euler(Mathf.Clamp(transform.rotation.eulerAngles.x + YValue, CameraMoveLimitDown, CameraMoveLimitUp), 0f, 0f);
            //trans.rotation = newRotation;
            float rotationAmout = YValue * CameraMoveSpeed * Time.deltaTime;
            trans.Rotate(-rotationAmout, 0f, 0f, Space.Self);
            fixZAxis();
        }

        //Handle the X axis which rotates the Y axis of the camera
        float XValue = input.x;

        if (XValue > 0 && canMoveRight())
        {
            float rotationAmout = XValue * CameraMoveSpeed * Time.deltaTime;
            trans.Rotate(0f, rotationAmout, 0f, Space.Self);
            fixZAxis();
        }
        else if (XValue < 0 && canMoveLeft())
        {
            float rotationAmout = XValue * CameraMoveSpeed * Time.deltaTime;
            trans.Rotate(0f, rotationAmout, 0f, Space.Self);
            fixZAxis();
        }
    }

    void zoomCamera (float change)
    {

    }

    private bool canMoveUp()
    {
        //Assuming limit of 25
        //If current X euler + limit > 360, Can move up = Current - 360 + Limit
        //If current X + Limit < 0, Can move

        if(trans.rotation.x > getCameraUpLimit())
        {
            return true;
        } else
        {
            return false;
        }
    }

    private bool canMoveDown()
    {
        if (trans.rotation.x < getCameraDownLimit())
        {
            Debug.Log("Transform Rotation X " + trans.rotation.x.ToString());
            Debug.Log("Transform Rotation Euler Angles X " + trans.rotation.eulerAngles.x.ToString());
            Debug.Log("Transform Local Rotation X " + trans.localRotation.x.ToString());
            Debug.Log("MAX X is " + getCameraDownLimit().ToString());
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool canMoveLeft()
    {
        if (trans.rotation.y > getCameraLeftLimit())
        {
            Debug.Log("Current Y is " + trans.rotation.y.ToString());
            Debug.Log("MAX Y is " + getCameraLeftLimit().ToString());
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool canMoveRight()
    {
        if (trans.rotation.y < getCameraRightLimit())
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool canZoomOut()
    {
        if (cam.fieldOfView < getCameraZoomOutLimit())
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool canMoveIn()
    {
        if (cam.fieldOfView > getCameraZoomInLimit())
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private float getCameraUpLimit()
    {
        return InitialCameraRotationX - CameraMoveLimitUp;
    }

    private float getCameraDownLimit()
    {
        return InitialCameraRotationX + CameraMoveLimitDown;
    }

    private float getCameraLeftLimit()
    {
        return InitialCameraRotationY - CameraMoveLimitLeft;
    }

    private float getCameraRightLimit()
    {
        return InitialCameraRotationY + CameraMoveLimitRight;
    }

    private float getCameraZoomOutLimit()
    {
        return InitialFieldOfView + CameraZoomLimitOut;
    }

    private float getCameraZoomInLimit()
    {
        return InitialFieldOfView - CameraZoomLimitIn;
    }

    private void fixZAxis()
    {
        Vector3 currentRotation = trans.eulerAngles;
        currentRotation.z = 0f;
        trans.eulerAngles = currentRotation;
    }
}


