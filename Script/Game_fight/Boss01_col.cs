using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Boss_col : MonoBehaviour
{
    public Animator Boss_Animator;
    float Atk_time = 0;
    bool Atk_bool = false;
    int Atk_state = 1;
    void Start()
    {
        StartCoroutine(BOSS_Atk01(0.167f));
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
                    // StartCoroutine(BOSS_Atk01(0.167f));
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
    public GameObject[] BOSS_Atk01_Tips_Area;
    public Animator[] BOSS_Atk01_clockwise;
    public Animator[] BOSS_Atk01_clockwise_cards;
    public Animator[] BOSS_Atk01_inOutside;
    IEnumerator BOSS_Atk01(float delay)
    {
        int random = Random.Range(0, 4);
        random = 0;
        switch (random)
        {
            case 0://逆時針
                for (int i = 0; i < BOSS_Atk01_Tips_Area.Length; i++)
                {
                    BOSS_Atk01_Tips_Area[i].SetActive(true);
                    yield return new WaitForSeconds(delay);
                }
                for (int i = 0; i < BOSS_Atk01_clockwise.Length; i++)
                {
                    BOSS_Atk01_clockwise[i].SetTrigger("ready_area");
                    BOSS_Atk01_clockwise[i].SetBool("ready_area_wait", true);
                    if (i == 2 || i == 5 || i == 9 || i == 12)
                    {
                       yield return new WaitForSecondsRealtime(delay);
                    }
                }
                // for (int i = 0; i < BOSS_Atk01_clockwise_cards.Length; i++)
                // {
                //     int card_style = Random.Range(0, 6);
                //     BOSS_Atk01_clockwise_cards[i].SetTrigger($"Atk{card_style}");
                //     switch (i)
                //     {
                //         case 2:
                //         case 5:
                //         case 9:
                //         case 12:
                //             yield return new WaitForSeconds(delay);
                //             break;
                //     }
                // }
                break;
            case 1://順時針
                // for (int i = BOSS_Atk01_Tips_Area.Length - 1; i >= 0; i--)
                // {
                //     BOSS_Atk01_Tips_Area[i].SetActive(true);
                //     BOSS_Atk01_clockwise[i].SetTrigger("Atk");
                //     BOSS_Atk01_InOutside[i].SetTrigger("Atk");
                // }
                break;
            case 2:
                break;
            case 3:
                break;
        }
        // yield return new WaitForSeconds(2f);
        // for (int i = 0; i < BOSS_Atk01_inOutside.Length; i++)
        // {
        //     BOSS_Atk01_clockwise[i].SetBool("ready_area_wait", false);
        // }

        Atk_state = 2;
        //逆時針、順時針、由內向外、由外向內
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
