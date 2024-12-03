using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_interactive : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

        float npc_timmer = 0;
    public void NPC_Thorns(Collider other ,float _NPC_HP)
    {
        if (other.tag == "Thorns")
        {
            npc_timmer += Time.deltaTime;
            if (npc_timmer >= Thorns.damage_time)
            {
                npc_timmer = 0;
                _NPC_HP -= 1;
            }     
        }
    }
}
