using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death_MC_BOSS : MonoBehaviour
{
    public Boss_col boss_col;
    void Start()
    {
        if (boss_col == null)
        {
            GameObject boss = GameObject.Find("Boss01");
            if (boss != null)
            {
                boss_col = boss.GetComponent<Boss_col>();
            }
        }
    }
    // Update is called once per frame
    void Update()
    {

        if (boss_col != null)
        {
            if (boss_col.BOSS_HP <= 0 || static_parameters.MC_HP <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
