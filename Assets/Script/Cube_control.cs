using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cube_control : MonoBehaviour
{
    private Vector3 move_xz;
    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        move_xz = new Vector3(0f, 0f, moveZ);
        move_xz = transform.TransformDirection(move_xz);
        move_xz *= speed;
    }
}
