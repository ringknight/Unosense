using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSignal : MonoBehaviour
{
    public bool activated;
    public GameObject puzzleElement;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(puzzleElement.name.Contains("Push Button"))
        {
            activated = puzzleElement.GetComponent<PushButton>().pushed;
        }
        if(puzzleElement.name.Contains("Combination"))
        {
            activated = puzzleElement.GetComponent<CombinationLock>().unlocked;
        }
        if(puzzleElement.name.Contains("Key"))
        {
            activated = puzzleElement.GetComponent<KeyHole>().keyIn;
        }
    }
}
