using UnityEngine;
using System.Collections;

public class AnimatePilot : MonoBehaviour {
    
   	public OSC osc;
    public GameObject head, rightHand, leftHand, rightAnkle, leftAnkle;
    public float scaleFactor = 1000f;

	// Use this for initialization
    void Start () {
	    osc.SetAddressHandler("/position/head/x", SetHeadX);
        osc.SetAddressHandler("/position/head/y", SetHeadY);
        osc.SetAddressHandler("/position/head/z", SetHeadZ);
        osc.SetAddressHandler("/position/hand/right/x", SetRightHandX);
        osc.SetAddressHandler("/position/hand/right/y", SetRightHandY);
        osc.SetAddressHandler("/position/hand/right/z", SetRightHandZ);
        osc.SetAddressHandler("/position/hand/left/x", SetLeftHandX);
        osc.SetAddressHandler("/position/hand/left/y", SetLeftHandY);
        osc.SetAddressHandler("/position/hand/left/z", SetLeftHandZ);
        osc.SetAddressHandler("/position/ankle/right/x", SetRightAnkleX);
        osc.SetAddressHandler("/position/ankle/right/y", SetRightAnkleY);
        osc.SetAddressHandler("/position/ankle/right/z", SetRightAnkleZ);
        osc.SetAddressHandler("/position/ankle/left/x", SetLeftAnkleX);
        osc.SetAddressHandler("/position/ankle/left/y", SetLeftAnkleY);
        osc.SetAddressHandler("/position/ankle/left/z", SetLeftAnkleZ);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void SetLeftHandX(OscMessage message)
    {
        float x = message.GetFloat(0);
        Vector3 position = leftHand.transform.localPosition;
        position.x = x / scaleFactor;
        leftHand.transform.localPosition = position;
    }
    void SetLeftHandY(OscMessage message)
    {
        float y = message.GetFloat(0);
        Vector3 position = leftHand.transform.localPosition;
        position.y = y / scaleFactor;
        leftHand.transform.localPosition = position;
    }
    void SetLeftHandZ(OscMessage message)
    {
        float z = message.GetFloat(0);
        Vector3 position = leftHand.transform.localPosition;
        position.z = z / scaleFactor;
        leftHand.transform.localPosition = position;
    }
    void SetRightHandX(OscMessage message)
    {
        float x = message.GetFloat(0);
        Vector3 position = rightHand.transform.localPosition;
        position.x = x / scaleFactor;
        rightHand.transform.localPosition = position;
    }
    void SetRightHandY(OscMessage message)
    {
        float y = message.GetFloat(0);
        Vector3 position = rightHand.transform.localPosition;
        position.y = y / scaleFactor;
        rightHand.transform.localPosition = position;
    }
    void SetRightHandZ(OscMessage message)
    {
        float z = message.GetFloat(0);
        Vector3 position = rightHand.transform.localPosition;
        position.z = z / scaleFactor;
        rightHand.transform.localPosition = position;
    }
    void SetLeftAnkleX(OscMessage message)
    {
        float x = message.GetFloat(0);
        Vector3 position = leftAnkle.transform.localPosition;
        position.x = x / scaleFactor;
        leftAnkle.transform.localPosition = position;
    }
    void SetLeftAnkleY(OscMessage message)
    {
        float y = message.GetFloat(0);
        Vector3 position = leftAnkle.transform.localPosition;
        position.y = y / scaleFactor;
        leftAnkle.transform.localPosition = position;
    }
    void SetLeftAnkleZ(OscMessage message)
    {
        float z = message.GetFloat(0);
        Vector3 position = leftAnkle.transform.localPosition;
        position.z = z / scaleFactor;
        leftAnkle.transform.localPosition = position;
    }
    void SetRightAnkleX(OscMessage message)
    {
        float x = message.GetFloat(0);
        Vector3 position = rightAnkle.transform.localPosition;
        position.x = x / scaleFactor;
        rightAnkle.transform.localPosition = position;
    }
    void SetRightAnkleY(OscMessage message)
    {
        float y = message.GetFloat(0);
        Vector3 position = rightAnkle.transform.localPosition;
        position.y = y / scaleFactor;
        rightAnkle.transform.localPosition = position;
    }
    void SetRightAnkleZ(OscMessage message)
    {
        float z = message.GetFloat(0);
        Vector3 position = rightAnkle.transform.localPosition;
        position.z = z / scaleFactor;
        rightAnkle.transform.localPosition = position;
    }
    void SetHeadX(OscMessage message){
		float x = message.GetFloat(0);
        Vector3 position = head.transform.localPosition;
        position.x = x / scaleFactor;
        head.transform.localPosition = position;
	}
    void SetHeadY(OscMessage message){
		float y = message.GetFloat(0);
        Vector3 position = head.transform.localPosition;
        position.y = y / scaleFactor;
        head.transform.localPosition = position;
	}
    void SetHeadZ(OscMessage message){
		float z = message.GetFloat(0);
        Vector3 position = head.transform.localPosition;
        position.z = z / scaleFactor;
        head.transform.localPosition = position;
	}
}
