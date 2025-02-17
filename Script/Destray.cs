using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destray : MonoBehaviour
{
    public float time = 3;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, time);
    }
}
