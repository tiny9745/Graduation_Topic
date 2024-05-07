using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_to_2D : MonoBehaviour
{
    public GameObject cube;
    // Start is called before the first frame update
    void Start()
    {
        cube = GameObject.Find("NPC");
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
