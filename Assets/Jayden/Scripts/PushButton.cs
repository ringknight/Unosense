using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushButton : MonoBehaviour
{
    public bool pushed, toggle, timed;
    private bool pushedDiff;
    public float timer;
    public GameObject button;
    public Material red, green;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(pushed)
        {
            button.transform.localPosition = new Vector3(0,0.475f,0);
            button.GetComponent<MeshRenderer>().material = green;
            if(timed && pushedDiff != pushed)
            {
                pushedDiff = true;
                StopCoroutine("Timer");
                StartCoroutine("Timer");
            }
            if(!timed && pushedDiff != pushed)
            {
                pushedDiff = true;
                GetComponent<AudioSource>().Play();
            }
        }else{
            pushedDiff = false;
            button.transform.localPosition = new Vector3(0,0.55f,0);
            button.GetComponent<MeshRenderer>().material = red;
        }
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
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(timer);
        pushed = false;
    }
}
