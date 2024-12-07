using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swam : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player_Swam_enter");
            static_parameters.MC_Wspeed/=2;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player_Swam_exit");
            static_parameters.MC_Wspeed*=2;
        }
    }
}
