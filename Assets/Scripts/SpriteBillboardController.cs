using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteBillboardController : MonoBehaviour
{

    Camera activeCamera;

    // Start is called before the first frame update
    void Start()
    {
        activeCamera = Camera.main;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        activeCamera = Camera.main;
        
        transform.LookAt(activeCamera.transform);
        transform.Rotate(-90, 180, 0);
    }
}
