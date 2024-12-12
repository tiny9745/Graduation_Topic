using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anti_crossing : MonoBehaviour
{
    void FixedUpdate()
    {
        // Example of applying force with Rigidbody
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(Vector3.forward * 10); 
        }
    }
}
