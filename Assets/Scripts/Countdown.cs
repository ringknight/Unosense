using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public float totalTime = 60f; // Total time for the countdown in seconds
    private float currentTime; // Current time left in the countdown

    public TextMeshProUGUI countdownText; // Reference to the TextMeshPro text field

    void Start()
    {
        currentTime = totalTime;
        StartCoroutine(StartCountdown());
    }

    IEnumerator StartCountdown()
    {
        while (currentTime > 0)
        {
            // Update the countdown text
            string textDisplay = currentTime <= 60f ? (currentTime <= 9f ? "0:0" + currentTime.ToString("F0") : "0:" + currentTime.ToString("F0")) : currentTime.ToString("F0");
            countdownText.text = textDisplay;
               
            // Wait for one second
            yield return new WaitForSeconds(1f);

            // Decrease the current time
            currentTime -= 1f;
        }

        // Countdown finished
        Explode();
    }

    void Explode()
    {
        countdownText.text = "BOOM";
        GlobalGameManager.instance.BombExplode();
        Debug.Log("EXPLODE!!!");
    }
}
