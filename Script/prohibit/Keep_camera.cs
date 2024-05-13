using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keep_camera : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject Camera;
    void Start()
    {
        Camera = GameObject.Find("Camera");
        DontDestroyOnLoad(Camera);
    }
}
