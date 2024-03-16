using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kickable : MonoBehaviour
{
    [SerializeField] float bump_speed = 3;
    [SerializeField] float torque_speed = 150;
    Rigidbody rb;
    bool can_kick = true;

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
                rb.velocity = (Vector3.up + new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)) * bump_speed);
                rb.AddTorque((Vector3.forward * 0.5f + Vector3.up) * torque_speed);
            }
        }
    }
}
