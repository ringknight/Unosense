using UnityEngine.InputSystem;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Camera Limits")]
    [Tooltip("This defines the rotation limit of the camera on the Y Axis at the top")][SerializeField] private float CameraMoveLimitVertical;    
    [Tooltip("This defines the rotation limit of the camera on the X Axis on the left")][SerializeField] private float CameraMoveLimitHorizontal;
    [Tooltip("This defines the Zoom (FieldOfView) limit of the camera when zooming out")][SerializeField] private float CameraZoomLimitOut;
    [Tooltip("This defines the Zoom (FieldOfView) limit of the camera when zooming in")][SerializeField] private float CameraZoomLimitIn;

    [Header("Camera Speed settings")]
    [Tooltip("This defines the speed of the camera movement")][SerializeField] private float CameraMoveSpeed;
    [Tooltip("This defines the speed of the camera zoom")][SerializeField] private float CameraZoomSpeed;

    [Header("Other variables")]
    [SerializeField] public float joystickSensitivity = 0.1f;
    [SerializeField] public float bumperSensitivity = 0.1f;

    // Initial values
    private Quaternion InitialCameraRotation;
    private float InitialCameraRotationX = 0;
    private float InitialCameraRotationY = 0;
    
    private float InitialFieldOfView = 0;
    private float currentRotationX = 0f;
    private float currentRotationY = 0f;

    private float initialZoom;

    private Transform trans;
    private Camera cam;

    private float pitch = 0f; // Used for up-down rotation
    private float yaw = 0f; // Used for left-right rotation

    // TEST
    public float rotationLimit = 30f; // Define your rotation limit here
    private Quaternion difference;

    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<Transform>();
        cam = GetComponent<Camera>();

        Vector3 angles = trans.localEulerAngles;
        pitch = angles.x;
        yaw = angles.y;

        // Adjust pitch to work within a -180 to 180 range
        if (pitch > 180) pitch -= 360;

        InitialCameraRotationX = trans.rotation.eulerAngles.x;
        InitialCameraRotationY = trans.rotation.eulerAngles.y;
        InitialFieldOfView = cam.fieldOfView;

        //currentRotationX = trans.rotation.eulerAngles.x;
        //currentRotationY = trans.rotation.eulerAngles.y;

        initialZoom = cam.fieldOfView;
    }

    // Update is called once per frame
    void Update()
    {

        // Get the input value of the left joystick
        // X POSITIVE = MOVE RIGHT
        // X NEGATIVE = MOVE LEFT
        // Y POSITIVE = MOVE UP
        // Y NEGATIVE = MOVE DOWN

        //float adjustedInitialXRotation = (InitialCameraRotationX > 180) ? InitialCameraRotationX - 360 : InitialCameraRotationX;

        // Get input from the joystick
        float inputY = Input.GetAxis("Vertical") * CameraMoveSpeed * Time.deltaTime;
        float inputX = Input.GetAxis("Horizontal") * CameraMoveSpeed * Time.deltaTime;

        // Calculate new X (pitch) rotation, ensuring it doesn't exceed the vertical limits
        currentRotationX += inputY;
        currentRotationX = Mathf.Clamp(currentRotationX, -CameraMoveLimitVertical, CameraMoveLimitVertical);

        currentRotationY += inputX;
        currentRotationY = Mathf.Clamp(currentRotationY, -CameraMoveLimitHorizontal, CameraMoveLimitHorizontal);

        // Apply the rotations to the camera
        trans.localEulerAngles = new Vector3(InitialCameraRotationX - currentRotationX, InitialCameraRotationY + currentRotationY, 0f);

        float triggerRight = 0;
        float triggerLeft = 0;
        if (Gamepad.current != null)
        {
            triggerRight = Gamepad.current.rightTrigger.ReadValue();
            triggerLeft = Gamepad.current.leftTrigger.ReadValue();
        }


        if(triggerRight > bumperSensitivity && triggerLeft > bumperSensitivity)
        {
            //DO NOTHING
        } else if (triggerRight > bumperSensitivity)
        {
            // Zoom in
            cam.fieldOfView -= CameraZoomSpeed * Time.deltaTime * triggerRight;
        }
        else if (triggerLeft > bumperSensitivity)
        {
            // Zoom out
            cam.fieldOfView += CameraZoomSpeed * Time.deltaTime * triggerLeft;
        }

        cam.fieldOfView = Mathf.Clamp(cam.fieldOfView, getCameraZoomInLimit(), getCameraZoomOutLimit());

        /*
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
        */


        /*
         * if (leftBumperInput != 0) { Debug.Log(leftBumperInput.ToString()); }
         * if (rightBumperInput != 0) { Debug.Log(rightBumperInput.ToString()); }
        */

        /*
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
        */
    }

    void zoomCamera (float change)
    {

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


