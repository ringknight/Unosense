using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CombinationLock : MonoBehaviour
{
    public int n1, n2, n3, combination;
    public bool unlocked;
    public TMP_Text n1Display, n2Display, n3Display;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        n1Display.text = n1 + "";
        n2Display.text = n2 + "";
        n3Display.text = n3 + "";

        
        if(combination == n1 * 100 + n2 * 10 + n3)
        {
            unlocked = true;
        }

        if(n1 > 9)
        {
            n1 = 0;
        }
        if(n2 > 9)
        {
            n2 = 0;
        }
        if(n3 > 9)
        {
            n3 = 0;
        }
        if(n1 < 0)
        {
            n1 = 9;
        }
        if(n1 < 0)
        {
            n2 = 9;
        }
        if(n1 < 0)
        {
            n3 = 9;
        }
    }
}
