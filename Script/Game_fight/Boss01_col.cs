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
        Invoke("Boss_col_Atk01", 5f);
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
    private int random; private float BOSS_Atk01_delay = 0.167f;

    private void Boss_col_Atk01()
    {
        Atk_bool = true;
        random = Random.Range(0, 4);
        StartCoroutine(BOSS_Atk01_ready01());
        StartCoroutine(BOSS_Atk01_ready02(3f));
    }
    IEnumerator BOSS_Atk01_ready01()
    {
        random = 0;
        Debug.Log("逆時針");
        Boss_Animator.SetTrigger("aup");
        Boss_Animator.SetBool("atk_end", true);
        switch (random)
        {
            case 0://逆時針
                for (int i = 0; i < BOSS_Atk01_Tips_Area.Length; i++)
                {
                    BOSS_Atk01_Tips_Area[i].SetActive(true);
                    yield return new WaitForSeconds(BOSS_Atk01_delay);
                }
                for (int i = 0; i < BOSS_Atk01_clockwise.Length; i++)
                {
                    BOSS_Atk01_clockwise[i].SetTrigger("ready_area");
                    BOSS_Atk01_clockwise[i].SetBool("ready_area_wait", true);
                    switch (i)
                    {
                        case 2:
                        case 5:
                        case 9:
                        case 12:
                            yield return new WaitForSeconds(BOSS_Atk01_delay);
                            break;
                    }
                }
                break;
            case 1://順時針
                // for (int i = BOSS_Atk01_Tips_Area.Length - 1; i >= 0; i--)
                // {
                //     BOSS_Atk01_Tips_Area[i].SetActive(true);
                //     BOSS_Atk01_clockwise[i].SetTrigger("Atk");
                //     BOSS_Atk01_InOutside[i].SetTrigger("Atk");
                // }
                break;
        }
        Atk_state = 2;
        //逆時針、順時針、由內向外、由外向內
    }
    IEnumerator BOSS_Atk01_ready02(float wait)
    {
        yield return new WaitForSeconds(wait);
        Boss_Animator.SetBool("atk_end", false);
        yield return new WaitForSeconds(0.2f);
        switch (random)
        {
            case 0://逆時針
                for (int i = 0; i < BOSS_Atk01_clockwise_cards.Length; i++)
                {
                    int card_style = Random.Range(0, 6);
                    BOSS_Atk01_clockwise_cards[i].SetTrigger($"Atk{card_style}");
                    switch (i)
                    {
                        case 2:
                        case 5:
                        case 9:
                        case 12:
                            yield return new WaitForSeconds(BOSS_Atk01_delay);
                            break;
                    }
                }
                yield return new WaitForSeconds(1.8f - BOSS_Atk01_delay * 4);
                for (int i = 0; i < BOSS_Atk01_clockwise.Length; i++)
                {
                    BOSS_Atk01_clockwise[i].SetBool("ready_area_wait", false);
                    switch (i)
                    {
                        case 0:
                            BOSS_Atk01_Tips_Area[0].SetActive(false);
                            break;
                        case 2:
                            BOSS_Atk01_Tips_Area[1].SetActive(false);
                            break;
                        case 5:
                            BOSS_Atk01_Tips_Area[2].SetActive(false);
                            break;
                        case 9:
                            BOSS_Atk01_Tips_Area[3].SetActive(false);
                            break;
                        case 12:
                            BOSS_Atk01_Tips_Area[4].SetActive(false);
                            yield return new WaitForSeconds(BOSS_Atk01_delay);
                            break;
                    }
                }
                break;
        }
        Atk_state = 2;
        Atk_bool = false;
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
