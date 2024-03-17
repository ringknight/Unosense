using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    [SerializeField] public GameObject[] lasers;
    public bool activated;
    private bool activatedDiff;
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

        if(activated && !activatedDiff)
        {
            activatedDiff = true;
            GetComponent<AudioSource>().Play();
        }

        if(lasers.Length != 0)
        {
            foreach(GameObject laser in lasers)
            {
                if(activated && laser.activeInHierarchy == false)
                {
                    laser.SetActive(true);
                    laser.GetComponent<LaserManager>().ActivateLaser();
                }
            }
        }

        //if(activated && laser.activeInHierarchy)
        //{
        //    foreach(GameObject laser in lasers)
        //    {
        //        laser.SetActive(true);
        //        laser.GetComponent<LaserManager>().ActivateLaser();
        //    }
        //}else{
        //    //foreach(GameObject laser in lasers)
        //    //{
        //    //    if(laser.GetComponent<LaserManager>().laserActive)
        //    //    {
        //    //        laser.GetComponent<LaserManager>().DeactivateLaser();
        //    //    }
        //    //}
        //}
        foreach(GameObject laser in lasers)
        {
            if((laser.GetComponent<LaserManager>().laserActive == false && laser.activeInHierarchy) || activated == false)
            {
                activated = false;
                activatedDiff = false;
                if(puzzleElement.name.Contains("Push Button"))
                {
                    puzzleElement.GetComponent<PushButton>().pushed = false;
                }
                //laser.GetComponent<LaserManager>().StartCoroutine("WaitForSound");
                laser.SetActive(false);
            }
        }
        
    }
}
