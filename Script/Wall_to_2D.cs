using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_to_2D : MonoBehaviour
{
    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.enabled = false;
        }
    }
}