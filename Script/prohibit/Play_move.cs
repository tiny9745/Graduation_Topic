using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play_move : MonoBehaviour
{
    public float horizontalInput, verticalInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        Doge();
    }
    void Doge()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("Doge");
        }
    }
}
