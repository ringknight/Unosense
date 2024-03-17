using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public GameObject[] signals;
    public bool open;
    public string nextScene;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int i = 0;

        if(signals.Length != 0)
        {
            foreach(GameObject signal in signals)
            {
                if (signal.GetComponent<DoorSignal>().activated)
                {
                    i += 1;
                }
            }
        }

        if(i == signals.Length)
        {
            open = true;
        }
        if(open)
        {
            GetComponent<Animator>().SetBool("Opened", true);
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player" && open)
        {
            GoToNextScene();
        }
    }

    void GoToNextScene()
    {
        
        SceneManager.LoadScene(nextScene);
    }
    public void PlaySound()
    {
        GetComponent<AudioSource>().Play();
    }
}
