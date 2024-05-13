using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_to_2D : MonoBehaviour
{
    public GameObject cube;
    void Start()
    {
        Renderer renderer = cube.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}