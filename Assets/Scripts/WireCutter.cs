using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WireCutter : MonoBehaviour
{

    public GameObject Wire;
    public GameObject WireColor;
    public Color glowColor = Color.red; // Color for the glow effect
    public float glowIntensity = 1.0f; // Intensity of the glow effect
    public GameObject cutLabel; // Intensity of the glow effect

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Hands")
        {
            MeshRenderer meshRenderer = WireColor.GetComponent<MeshRenderer>();

            // Check if a MeshRenderer component is attached
            if (meshRenderer != null)
            {
                // SET GLOW
                meshRenderer.material.EnableKeyword("_EMISSION");
                meshRenderer.material.SetColor("_EmissionColor", glowColor * glowIntensity * 3f);
                

                GlobalGameManager.AddWireActive(Wire);
                // Enable Cutter helper
                if (GlobalGameManager.activeWires.Count == 1)
                {
                    cutLabel.SetActive(true);
                }
                else
                {
                    cutLabel.SetActive(false);
                }
            }
            else
            {
                Debug.LogError("No MeshRenderer component attached to this GameObject.");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Hands")
        {
            MeshRenderer meshRenderer = WireColor.GetComponent<MeshRenderer>();

            // Check if a MeshRenderer component is attached
            if (meshRenderer != null)
            {
                // Disable GLOW
                meshRenderer.material.EnableKeyword("_EMISSION");
                meshRenderer.material.SetColor("_EmissionColor", glowColor * 0);

                GlobalGameManager.RemoveWireActive(Wire);
                // Enable Cutter helper
                if (GlobalGameManager.activeWires.Count == 1)
                {
                    cutLabel.SetActive(true);
                } else
                {
                    cutLabel.SetActive(false);
                }
            }
            else
            {
                Debug.LogError("No MeshRenderer component attached to this GameObject.");
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
         cutLabel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
