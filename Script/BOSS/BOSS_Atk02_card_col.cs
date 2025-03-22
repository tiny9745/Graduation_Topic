using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSS_Atk02_card_col : MonoBehaviour
{
    float speed = 30f;
    float Timer = 0;
    void Start()
    {

    }

    void Update()
    {
        // 根據物件的朝向向前移動
        transform.Translate(Vector3.down * speed * Time.deltaTime, Space.Self);
        Timer += Time.deltaTime;
        if (Timer > 6)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            static_parameters.MC_HP -= 20;
            Destroy(gameObject);
        }
    }
}
