using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        new WaitForSeconds(10);
        SceneManager.LoadScene("MainMenu");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
