using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSS_Atk02_card_col : MonoBehaviour
{
    float speed = 30f;
    float Timer = 0;
    void Update()
    {
        // 根據物件的朝向向前移動
        transform.Translate(Vector3.down * speed * Time.deltaTime, Space.Self);
        Timer += Time.deltaTime;
        if (Timer > 5 || static_parameters.stage_number == 0 || Boss_col.BOSS_live == false)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !static_parameters.invincible && static_parameters.stage_number != 0)
        {
            static_parameters.MC_HP -= static_parameters.MC_HP_Max * 0.1f;
            Destroy(gameObject);
        }
    }
}
