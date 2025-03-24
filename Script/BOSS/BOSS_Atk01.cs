using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSS_Atk01 : MonoBehaviour
{
    private Collider BOSS_Atk01_Tips_Tip;
    float minus, BOSS_Atk = 35;
    private void Start()
    {
        BOSS_Atk01_Tips_Tip = GetComponent<Collider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            static_parameters.MC_HP -= BOSS_Atk;
            BOSS_Atk01_Tips_Tip.enabled = false;
        }
    }
}
