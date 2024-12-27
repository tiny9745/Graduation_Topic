using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class Bullet_lookat : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera Camera_main;
    public GameObject buttonImage;
    void Start()
    {
        Camera_main = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        buttonImage.transform.LookAt(Camera_main.transform.position);
    }
}
