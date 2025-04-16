using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSS_Atk03_ground_col : MonoBehaviour
{
    public Collider[] BOSS_Atk03_GC;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !static_parameters.invincible)
        {
            static_parameters.MC_HP -= static_parameters.MC_HP_Max * 0.2f + 15;
            for (int i = 0; i < BOSS_Atk03_GC.Length; i++)
            {
                BOSS_Atk03_GC[i].enabled = false;
            }
        }
    }
}
