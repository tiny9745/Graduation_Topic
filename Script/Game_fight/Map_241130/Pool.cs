using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Player")
        {
            static_parameters.MC_Wspeed /= 2;
        }
        if (other.name == "請改成在NPC方面程式碼_Pool")
        {
            
        }
    }
        private void OnTriggerExit (Collider other)
    {
        if (other.tag == "Player")
        {
            static_parameters.MC_Wspeed *= 2;
        }
        if (other.name == "請改成在NPC方面程式碼_Pool")
        {
            
        }
    }
}
