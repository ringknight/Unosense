using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class LaserManager : MonoBehaviour
{
    public bool laserActive;
    private AudioSource audioSource;
    MeshRenderer[] renderers;
    CapsuleCollider[] colliders;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Make the object and its children invisible
        renderers = GetComponents<MeshRenderer>();

        // Disable the collider(s)
        colliders = GetComponents<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        // Play the sound effect
        audioSource.Play();
        StartCoroutine(WaitForSound());

        // Call the LaserDisappear function
        //LaserDisappear();
    }

    public void ActivateLaser()
    {
        Debug.Log("WOOOOOOOOOOOT...");
        laserActive = true; 
        foreach (CapsuleCollider collider in colliders)
        {
            collider.enabled = true;
        }

        foreach (MeshRenderer renderer in renderers)
        {
            renderer.enabled = true;
        }
    }

    public void DeactivateLaser()
    {
        Debug.Log("WESHHHHHHHHHHH...");
        laserActive = false;

        foreach (CapsuleCollider collider in colliders)
        {
            collider.enabled = false;
        }

        foreach (MeshRenderer renderer in renderers)
        {
            renderer.enabled = false;
        }
    }

    IEnumerator WaitForSound()
    {
        //Wait Until Sound has finished playing
        while (audioSource.isPlaying)
        {
            yield return null;
        }

        //Auidio has finished playing, disable GameObject
        DeactivateLaser();
    }
}
