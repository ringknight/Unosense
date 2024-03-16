using UnityEngine;
using System.Collections;

public class ReceivePosition1 : MonoBehaviour {
    
   	public OSC osc;
    public GameObject body;
    public string adressPrefix;


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
		float x = message.GetFloat(0);

        Vector3 position = transform.position;

        position.x = x / 100.0f;

        transform.position = position;
	}
    void SetBodyY(OscMessage message){
		float y = message.GetFloat(0);

        Vector3 position = transform.position;

        position.y = y / 100.0f;

        transform.position = position;
	}
    void SetBodyZ(OscMessage message){
		float z = message.GetFloat(0);

        Vector3 position = transform.position;

        position.z = z / 100.0f;

        transform.position = position;
	}
}
