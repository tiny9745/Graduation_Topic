using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSS_Atk02_card_col : MonoBehaviour
{
    float speed = 30f;
    private GameObject targetObject;
    void Start()
    {
        targetObject = GameObject.Find("Player_S");
    }

    void Update()
    {
        if (targetObject != null)
        {
            transform.Translate(transform.position * speed * Time.deltaTime, Space.World);
        }
    }
}
