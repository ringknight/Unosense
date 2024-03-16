using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    public GameObject head;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (head.transform.localPosition.y < transform.parent.localPosition.y)
        {
            GetComponent<Light>().enabled = true;
        } else
        {
            GetComponent<Light>().enabled = false;
        }
    }
}
