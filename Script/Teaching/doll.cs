using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doll : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision Hit)
    {
        if (Hit.gameObject.CompareTag("Player") && static_parameters.isTeaching == false && static_parameters.teaching_stop == 0)
        {
            Debug.Log("doll");
            Debug.Log("doll:"+static_parameters.teaching_stop);
        }
    }
    private void OnTriggerEnter(Collider Hit)
    {
        if (Hit.gameObject.CompareTag("Player") && static_parameters.isTeaching == false && static_parameters.teaching_stop == 0)
        {
            static_parameters.teaching_stop = 1;
            Debug.Log("doll:"+static_parameters.teaching_stop);
        }
    }
}
