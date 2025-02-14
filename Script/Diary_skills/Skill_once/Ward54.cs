using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ward54 : MonoBehaviour
{
    // Start is called before the first frame update
    public Collider plane;
    float timmer = 0;
    void Start()
    {
        Destroy(gameObject, 4.9f);
    }
    void Update()
    {
        if(timmer < 0.5f)
        {
            timmer += Time.deltaTime;
        }
        else
        {
            plane.enabled = true;
        }
    }
}
