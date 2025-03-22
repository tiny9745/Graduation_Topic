using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSS_Atk02_card_col : MonoBehaviour
{
    float speed = 30f;

    void Start()
    {

    }

    void Update()
    {
        // 根據物件的朝向向前移動
        transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
    }
}
