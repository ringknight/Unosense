using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public bool disarmed = false;
    public GameObject bomb;

    // Start is called before the first frame update
    void Start()
    {
        GlobalGameManager.SetBomb(bomb);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
