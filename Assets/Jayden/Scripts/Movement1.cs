using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement1 : MonoBehaviour
{
    public float speed = 1f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gameObject.transform.position += new Vector3(Input.GetAxis("Horizontal") * speed/10, 0, Input.GetAxis("Vertical") * speed/10);
        //if(Input.GetKey("q"))
        //{
        //    gameObject.transform.rotation
        //    //gameObject.transform.rotation = Quaternion.Euler(gameObject.transform.rotation.x + 1,0,0);
        //}
        //if(Input.GetKey("e"))
        //{
        //   //gameObject.transform.rotation.x += -1; 
        //}
    }
}
