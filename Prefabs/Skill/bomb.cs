using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour
{
    private SphereCollider sphereCollider;
    float sradius_size;
    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.enabled = false;
        }
        sphereCollider = GetComponent<SphereCollider>();
        if (sphereCollider != null)
        {
            sradius_size = sphereCollider.radius;
        }
    }

    void Update()
    {
        // Gradually expand the SphereCollider radius every second until sradius_size*2.5f
        if (sphereCollider != null)
        {
            if (sphereCollider.radius <= sradius_size * 20f)
            {
                sphereCollider.radius += 0.1f;
            }
            else if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
        }
    }
}
