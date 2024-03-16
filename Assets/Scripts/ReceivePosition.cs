using UnityEngine;
using System.Collections;

public class ReceivePosition : MonoBehaviour {
    
   	public OSC osc;
    public GameObject sphere;


	// Use this for initialization
	void Start () {
	   osc.SetAddressHandler("/position/head/x", OnReceiveXYZ );
       osc.SetAddressHandler("/CubeX", OnReceiveX);
       osc.SetAddressHandler("/CubeY", OnReceiveY);
       osc.SetAddressHandler("/CubeZ", OnReceiveZ);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnReceiveXYZ(OscMessage message){
		float x = message.GetFloat(0);
        //float y = message.GetInt(1);
		//float z = message.GetInt(2);

		//transform.position = new Vector3(x,y,z);
        Debug.Log(x);
        Transform t = sphere.GetComponent<Transform>();
        Debug.Log(t.position.x);
        t.position = new Vector3(x / 1000.0f, 0, 0);
	}

    void OnReceiveX(OscMessage message) {
        float x = message.GetFloat(0);

        Vector3 position = transform.position;

        position.x = x;

        transform.position = position;
    }

    void OnReceiveY(OscMessage message) {
        float y = message.GetFloat(0);

        Vector3 position = transform.position;

        position.y = y;

        transform.position = position;
    }

    void OnReceiveZ(OscMessage message) {
        float z = message.GetFloat(0);

        Vector3 position = transform.position;

        position.z = z;

        transform.position = position;
    }


}
