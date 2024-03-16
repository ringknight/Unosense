using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushButton : MonoBehaviour
{
    public bool pushed, toggle;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.transform.tag == "Hands")
        {
            if(toggle)
            {
                pushed = !pushed;
            }
            else
            {
                pushed = true;
            }
            
        }
    }
}
