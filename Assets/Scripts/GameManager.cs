using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalGameManager : MonoBehaviour
{
    private static GlobalGameManager instance;
    public static List<GameObject> activeWires = new List<GameObject>();
    public static GameObject bomb;

    private string bombWireToDisarm = "PinkWire";

    private void Awake()
    {
        // Ensure there is only one instance of the GlobalGameManager
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scene changes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            checkWireCut();
        }
    }

    private void checkWireCut()
    {
        if (activeWires.Count != 1)
        {
            return;
        }

        if (activeWires[0].name.Contains(bombWireToDisarm))
        {
            Debug.Log("Good wire!");
            Bomb script = bomb.GetComponent<Bomb>();
            if(script != null)
            {
                script.disarmed = true;
            }

        } else
        {
            Debug.Log("Wrong wire!");
            Debug.Log("BOOM!");
        }
    }

    public static void AddWireActive(GameObject wire)
    {
        activeWires.Add(wire);
    }

    public static void RemoveWireActive(GameObject wire)
    {
        activeWires.Remove(wire);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public static void SetBomb(GameObject bo)
    {
        bomb = bo;
    }
}
