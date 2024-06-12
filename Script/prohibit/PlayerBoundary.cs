using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoundary : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 minBoundary= new Vector3(-30,2.5f,-30); // Define the minimum boundary
    public Vector3 maxBoundary= new Vector3(30,3f,30); // Define the maximum boundary
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, minBoundary.x, maxBoundary.x);
        position.y = Mathf.Clamp(position.y, minBoundary.y, maxBoundary.y);
        position.z = Mathf.Clamp(position.z, minBoundary.z, maxBoundary.z);
        transform.position = position;
        
    }
}
