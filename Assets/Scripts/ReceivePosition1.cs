using UnityEngine;
using System.Collections;

public class ReceivePosition1 : MonoBehaviour {
    
   	public OSC osc;
    public GameObject body;
    public string adressPrefix;
    public float scaleFactor = 1000f;

	// Use this for initialization
	void Start () {
	   osc.SetAddressHandler(adressPrefix + "/x", SetBodyX);
       osc.SetAddressHandler(adressPrefix + "/y", SetBodyY);
       osc.SetAddressHandler(adressPrefix + "/z", SetBodyZ);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

	void SetBodyX(OscMessage message){
        Debug.Log(message);
		float x = message.GetFloat(0);



        Vector3 position = body.transform.position;

        position.x = x / scaleFactor;

        body.transform.position = position;
	}
    void SetBodyY(OscMessage message){
		float y = message.GetFloat(0);

        Vector3 position = body.transform.position;

        position.y = y / scaleFactor;

        body.transform.position = position;
	}
    void SetBodyZ(OscMessage message){
		float z = message.GetFloat(0);

        Vector3 position = body.transform.position;

        position.z = z / scaleFactor;

        body.transform.position = position;
	}
}
