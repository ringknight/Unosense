using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kickable : MonoBehaviour
{
    [SerializeField] float bump_speed = 3;
    [SerializeField] float torque_speed = 200;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Feet")
        {
            if(rb != null)
            {
                rb.velocity = (Vector3.up + Vector3.back) * bump_speed;
                rb.AddTorque(Vector3.forward * torque_speed);
            }
        }
    }
}
