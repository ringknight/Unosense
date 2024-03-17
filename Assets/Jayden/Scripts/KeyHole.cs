using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHole : MonoBehaviour
{
    public GameObject keyCase;
    public bool keyIn;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.transform.tag == "Hands" && keyCase.GetComponent<KeyCase>().keyPickedUp)
        {
            GetComponent<Animator>().SetBool("KeyIn", true);
        }
    }
    public void KeyTurned()
    {
        keyIn = true;
    }
}
