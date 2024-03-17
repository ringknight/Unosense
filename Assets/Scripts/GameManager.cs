using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GlobalGameManager : MonoBehaviour
{
    public Button newGameButton;
    public Button speedRunButton;
    public Button creditsButton;
    public Button exitButton;

    private static GlobalGameManager instance;
    public Animator fadeAnimator;
    public float transitionTime = 1f;

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
        if (exitButton == null)
        {
            // Find the button by tag, name, or directly assign it in the inspector
            exitButton = GameObject.FindWithTag("ExitButton").GetComponent<Button>();
            Debug.Log(exitButton.name);
        }
        exitButton.onClick.AddListener(instance.QuitGame);


        if (newGameButton == null)
        {
            // Find the button by tag, name, or directly assign it in the inspector
            newGameButton = GameObject.FindWithTag("NewGameButton").GetComponent<Button>();
            Debug.Log(newGameButton.name);
        }
        newGameButton.onClick.AddListener(instance.NewGame);


        if (creditsButton == null)
        {
            // Find the button by tag, name, or directly assign it in the inspector
            creditsButton = GameObject.FindWithTag("CreditButton").GetComponent<Button>();
            Debug.Log(creditsButton.name);
        }
        creditsButton.onClick.AddListener(instance.Credits);


        if (speedRunButton == null)
        {
            // Find the button by tag, name, or directly assign it in the inspector
            speedRunButton = GameObject.FindWithTag("SpeedrunButton").GetComponent<Button>();
            Debug.Log(speedRunButton.name);
        }
        speedRunButton.onClick.AddListener(instance.SpeedRun);

        //StartCoroutine(InitialLoad());
    }

    public void LoadNextScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        StartCoroutine(FadeAndLoadScene(sceneName));
    }

    IEnumerator FadeAndLoadScene(string sceneName)
    {
        // Play the fade-out animation
        //fadeAnimator.SetTrigger("FadeOut");

        // Wait for the animation to finish
        //yield return new WaitForSeconds(transitionTime);

        // Load the next scene
        SceneManager.LoadScene(sceneName);

        // Wait for a frame so the scene loads
        yield return null;

        // Play the fade-in animation
        //fadeAnimator.SetTrigger("FadeIn");
    }

    IEnumerator InitialLoad()
    {
        // Play the fade-out animation
        fadeAnimator.SetTrigger("FadeIn");
        
        // Wait for the animation to finish
        yield return new WaitForSeconds(transitionTime);

        // Wait for a frame so the scene loads
        yield return null;

        // Play the fade-in animation
        fadeAnimator.ResetTrigger("FadeIn");
    }

    IEnumerator UnoPowerrrrr()
    {

        GameObject unopower = GameObject.FindWithTag("UNOPOWER");
        TextMeshPro text = unopower.GetComponent<TextMeshPro>();

        text.color = new Color(255,255,255,255);
        
        // Wait for the animation to finish
        yield return new WaitForSeconds(5);

        text.color = new Color(255, 255, 255, 0);

        // Wait for a frame so the scene loads
        yield return null;
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    public void NewGame()
    {
        Debug.Log("NEW");
        LoadNextScene("FirstLevel");
    }

    public void SpeedRun()
    {
        Debug.Log("SPEED");
        
    }

    public void Credits()
    {
        //StartCoroutine(UnoPowerrrrr());
    }
}
