using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thorns : MonoBehaviour
{
    float timmer = 0;
    static public float damage_time = 1;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            timmer += Time.deltaTime;
            if (timmer >= damage_time && static_parameters.Change_enemy != 0)
            {
                timmer = 0;
                static_parameters.MC_HP -= 3;
            }     
        }
    }
}
