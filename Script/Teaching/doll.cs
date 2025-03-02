using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doll : MonoBehaviour
{
    public Teaching_TextF teaching_TextF;
    void Start()
    {
        
    }
    private void OnCollisionEnter(Collision Hit)
    {
        if (Hit.gameObject.CompareTag("Player") && static_parameters.isTeaching == false && static_parameters.teaching_stop == 0)
        {
            static_parameters.teaching_stop = 1;
            teaching_TextF.reading();
        }
    }
    private void OnTriggerEnter(Collider Hit)
    {
        if (Hit.gameObject.CompareTag("Player") && static_parameters.isTeaching == false && static_parameters.teaching_stop == 0)
        {
            static_parameters.teaching_stop = 1;
            teaching_TextF.reading();
        }
    }
}
