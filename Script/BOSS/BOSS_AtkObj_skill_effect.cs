using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSS_AtkObj_skill_effect : MonoBehaviour
{
    // Start is called before the first frame update
    public BOSS01_effect effect;

    private void Start()
    {
        if (effect == null)
        {
            GameObject boss = GameObject.Find("Boss01");
            if (boss != null)
            {
                effect = boss.GetComponent<BOSS01_effect>();
            }
        }
    }
    private void OnTriggerEnter(Collider Hit)
    {
        if (Hit.gameObject.CompareTag("Player") && static_parameters.MC_HP > 0)
        {
            if (effect != null)
            {
                effect.fight_instinct_MC();
            }
        }
    }
}
