using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinationButton : MonoBehaviour
{
    public GameObject combinationLock;
    public int n = 1, factor = 1;
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
            if(n == 1)
            {
                combinationLock.GetComponent<CombinationLock>().n1 += factor;
            }
            if(n == 2)
            {
                combinationLock.GetComponent<CombinationLock>().n2 += factor;
            }
            if(n == 3)
            {
                combinationLock.GetComponent<CombinationLock>().n3 += factor;
            }
        }
    }
}
