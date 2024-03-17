using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public bool disarmed = false;
    public GameObject bomb;
    public GameObject EndGame;

    // Start is called before the first frame update
    void Start()
    {
        GlobalGameManager.SetBomb(bomb);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Explode()
    {
        EndGame.SetActive(true);
    }
}
