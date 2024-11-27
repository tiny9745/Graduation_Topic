using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_function : MonoBehaviour
{
    public NPC_HP_03 nPC_hP;
    float minus;


    void Start()
    {
        if (nPC_hP == null)
        {
            nPC_hP = GetComponent<NPC_HP_03>();
        }
    }
    public void atk_To_MC_Throw(int number,float _npc_def)
    {
        switch (static_parameters._ItemID)
        {
            case 1:
                nPC_hP.TakeDamage(4, _npc_def);
                break;
            case 2:
                nPC_hP.TakeDamage(3, _npc_def);
                break;
            case 3:
                nPC_hP.TakeDamage(5, _npc_def);
                break;
            case 4:
                nPC_hP.TakeDamage(1, _npc_def);
                break;
        }
    }
}

