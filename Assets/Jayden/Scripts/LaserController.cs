using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    [SerializeField] public GameObject[] lasers;
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

        if(activated)
        {
            foreach(GameObject laser in lasers)
            {
                laser.GetComponent<LaserManager>().ActivateLaser();
            }
        }else{
            foreach(GameObject laser in lasers)
            {
                laser.GetComponent<LaserManager>().DeactivateLaser();
            }
        }
        
    }
}
