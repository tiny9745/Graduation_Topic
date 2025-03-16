using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_col : MonoBehaviour
{
    public Animator Boss_Animator;
    float Atk_time = 0;
    bool Atk_bool = false;
    int Atk_state = 1;
    void Start()
    {

    }

    void Update()
    {
        if (Atk_time <= 3 && Atk_bool == false)
        {
            Atk_time += Time.deltaTime;
        }
        else
        {
            Atk_time = 0;
            switch (Atk_state)
            {
                case 1:
                    Boss_Atk01();
                    break;
                case 2:
                    Boss_Atk02();
                    break;
                case 3:
                    Boss_Atk03();
                    break;
            }
        }
    }
    private void Boss_Atk01()
    {
        Atk_state = 2;
    }

    private void Boss_Atk02()
    {
        Atk_state = 3;
    }

    private void Boss_Atk03()
    {
        Atk_state = 1;
    }

    private void Atk_End()
    {
        Atk_bool = false;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "MC_Att")
        {
            Boss_Animator.SetTrigger("Hit");
            Invoke("Atk_End", 1f);
        }
    }
}
