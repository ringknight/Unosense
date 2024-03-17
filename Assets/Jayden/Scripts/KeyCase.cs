using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCase : MonoBehaviour
{
    public bool activated, keyPickedUp;
    public GameObject puzzleElement, key;
    void Start()
    {
        
    }
    void Update()
    {
        if(!keyPickedUp)
        {
            if(puzzleElement.name.Contains("Push Button"))
            {
                activated = puzzleElement.GetComponent<PushButton>().pushed;
            }
        }else{
            activated = true;
            puzzleElement.GetComponent<PushButton>().pushed = false;
        }

        if(activated)
        {
            GetComponent<Animator>().SetBool("Open", true);
        }else{
            GetComponent<Animator>().SetBool("Open", false);
        }
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.transform.tag == "Hands" && activated)
        {
            keyPickedUp = true;
            key.SetActive(false);
        }
    }
}
