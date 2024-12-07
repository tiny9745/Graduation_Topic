using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class berry_hitbox : MonoBehaviour
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
            static_parameters.MC_HP -= 10 * NPC_interactive.berry;
        }
    }
}
