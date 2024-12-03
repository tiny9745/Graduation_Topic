using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thorns : MonoBehaviour
{
    float timmer = 0;
    float damage_time = 1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            timmer += Time.deltaTime;
            if (timmer >= damage_time)
            {
                timmer = 0;
                static_parameters.MC_HP -= 1;
            }     
        }
        if (other.name == "請改成在NPC方面程式碼_Thorns")
        {

        }
    }
}
