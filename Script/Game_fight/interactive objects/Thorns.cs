using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thorns : MonoBehaviour
{
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
            static_parameters.MC_HP -= 1;
        }
        if (other.name == "請改成在NPC方面程式碼_Thorns")
        {
            
        }
    }
}
