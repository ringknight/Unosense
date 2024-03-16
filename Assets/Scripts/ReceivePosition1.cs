using UnityEngine;
using System.Collections;

public class ReceivePosition1 : MonoBehaviour {
    
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
        Vector3 position = leftHand.transform.position;
        position.x = x / scaleFactor;
        leftHand.transform.position = position;
    }
    void SetLeftHandY(OscMessage message)
    {
        float y = message.GetFloat(0);
        Vector3 position = leftHand.transform.position;
        position.y = y / scaleFactor;
        leftHand.transform.position = position;
    }
    void SetLeftHandZ(OscMessage message)
    {
        float z = message.GetFloat(0);
        Vector3 position = leftHand.transform.position;
        position.z = z / scaleFactor;
        leftHand.transform.position = position;
    }
    void SetRightHandX(OscMessage message)
    {
        float x = message.GetFloat(0);
        Vector3 position = rightHand.transform.position;
        position.x = x / scaleFactor;
        rightHand.transform.position = position;
    }
    void SetRightHandY(OscMessage message)
    {
        float y = message.GetFloat(0);
        Vector3 position = rightHand.transform.position;
        position.y = y / scaleFactor;
        rightHand.transform.position = position;
    }
    void SetRightHandZ(OscMessage message)
    {
        float z = message.GetFloat(0);
        Vector3 position = rightHand.transform.position;
        position.z = z / scaleFactor;
        rightHand.transform.position = position;
    }
    void SetLeftAnkleX(OscMessage message)
    {
        float x = message.GetFloat(0);
        Vector3 position = leftAnkle.transform.position;
        position.x = x / scaleFactor;
        leftAnkle.transform.position = position;
    }
    void SetLeftAnkleY(OscMessage message)
    {
        float y = message.GetFloat(0);
        Vector3 position = leftAnkle.transform.position;
        position.y = y / scaleFactor;
        leftAnkle.transform.position = position;
    }
    void SetLeftAnkleZ(OscMessage message)
    {
        float z = message.GetFloat(0);
        Vector3 position = leftAnkle.transform.position;
        position.z = z / scaleFactor;
        leftAnkle.transform.position = position;
    }
    void SetRightAnkleX(OscMessage message)
    {
        float x = message.GetFloat(0);
        Vector3 position = rightAnkle.transform.position;
        position.x = x / scaleFactor;
        rightAnkle.transform.position = position;
    }
    void SetRightAnkleY(OscMessage message)
    {
        float y = message.GetFloat(0);
        Vector3 position = rightAnkle.transform.position;
        position.y = y / scaleFactor;
        rightAnkle.transform.position = position;
    }
    void SetRightAnkleZ(OscMessage message)
    {
        float z = message.GetFloat(0);
        Vector3 position = rightAnkle.transform.position;
        position.z = z / scaleFactor;
        rightAnkle.transform.position = position;
    }
    void SetHeadX(OscMessage message){
		float x = message.GetFloat(0);
        Vector3 position = head.transform.position;
        position.x = x / scaleFactor;
        head.transform.position = position;
	}
    void SetHeadY(OscMessage message){
		float y = message.GetFloat(0);
        Vector3 position = head.transform.position;
        position.y = y / scaleFactor;
        head.transform.position = position;
	}
    void SetHeadZ(OscMessage message){
		float z = message.GetFloat(0);
        Vector3 position = head.transform.position;
        position.z = z / scaleFactor;
        head.transform.position = position;
	}
}
