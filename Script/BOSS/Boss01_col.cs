using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Boss_col : MonoBehaviour
{
    public Animator Boss_Animator;
    static public float BOSS_Atk_time = -5;
    static public bool BOSS_Atk_bool = false;
    static public int BOSS_Atk_state = 1;

    void Start()
    {
        // Invoke("Boss_Atk03", 5f);
        BOSS_Atk_state = 3;
    }

    void Update()
    {
        if (BOSS_Atk_time < 3 && BOSS_Atk_bool == false)
        {
            BOSS_Atk_time += Time.deltaTime;
        }
        if (BOSS_Atk_time >= 3 && BOSS_Atk_bool == false)
        {
            BOSS_Atk_bool = true;
            BOSS_Atk_time = 0;
            Boss_Animator.SetTrigger("aup");
            Boss_Animator.SetBool("atk_end", true);
            switch (BOSS_Atk_state)
            {
                case 1:
                    Boss_Atk01();
                    break;
                case 2:
                    break;
                case 3:
                    Boss_Atk03();
                    break;
            }
        }

        if (BOSS_Atk_bool && BOSS_Atk_state == 2)
        {
            Boss_Atk02();
        }
        // if (BOSS_Atk_bool && BOSS_Atk_state == 3)
        // {
        //     StartCoroutine(BOSS_Atk03_ready02());
        // }
    }
    public Collider[] BOSS_Atk01_Tips_Tip;
    public Animator[] BOSS_Atk01_clockwise;
    public Animator[] BOSS_Atk01_clockwise_cards;
    public Animator[] BOSS_Atk01_inOutside;
    private int random; private float BOSS_Atk01_delay = 0.167f;

    private void Boss_Atk01()
    {
        random = Random.Range(0, 4);
        StartCoroutine(BOSS_Atk01_ready01());
        StartCoroutine(BOSS_Atk01_ready02(3f));
    }

    IEnumerator BOSS_Atk01_ready01()
    {
        random = Random.Range(0, 3);
        switch (random)
        {
            case 0://逆時針
                Debug.Log("逆時針");
                for (int i = 0; i < BOSS_Atk01_Tips_Tip.Length; i++)
                {
                    BOSS_Atk01_Tips_Tip[i].gameObject.SetActive(true);
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
                for (int i = BOSS_Atk01_Tips_Tip.Length - 1; i >= 0; i--)
                {
                    BOSS_Atk01_Tips_Tip[i].gameObject.SetActive(true);
                    yield return new WaitForSeconds(BOSS_Atk01_delay);
                }
                for (int i = BOSS_Atk01_clockwise.Length - 1; i >= 0; i--)
                {
                    BOSS_Atk01_clockwise[i].SetTrigger("ready_area");
                    BOSS_Atk01_clockwise[i].SetBool("ready_area_wait", true);
                    switch (i)
                    {
                        case 3:
                        case 6:
                        case 10:
                        case 13:
                            yield return new WaitForSeconds(BOSS_Atk01_delay);
                            break;
                    }
                }
                break;
            case 2://由內向外
                for (int i = 0; i < (BOSS_Atk01_Tips_Tip.Length - 1) / 2 + 1 + 1; i++)
                {
                    BOSS_Atk01_Tips_Tip[i].gameObject.SetActive(true);
                    BOSS_Atk01_Tips_Tip[BOSS_Atk01_Tips_Tip.Length - 1 - i].gameObject.SetActive(true);
                    yield return new WaitForSeconds(BOSS_Atk01_delay);
                }
                for (int i = 0; i < (BOSS_Atk01_clockwise.Length - 1) / 2 + 1; i++)
                {
                    BOSS_Atk01_clockwise[i].SetTrigger("ready_area");
                    BOSS_Atk01_clockwise[i].SetBool("ready_area_wait", true);
                    BOSS_Atk01_clockwise[BOSS_Atk01_clockwise.Length - 1 - i].SetTrigger("ready_area");
                    BOSS_Atk01_clockwise[BOSS_Atk01_clockwise.Length - 1 - i].SetBool("ready_area_wait", true);
                    switch (i)
                    {
                        case 2:
                        case 5:
                            yield return new WaitForSeconds(BOSS_Atk01_delay);
                            break;
                    }
                }
                break;
        }
    }
    IEnumerator BOSS_Atk01_ready02(float wait)
    {
        yield return new WaitForSeconds(wait);
        Boss_Animator.SetBool("atk_end", false);
        yield return new WaitForSeconds(0.2f);
        int j = 0;
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
                            BOSS_Atk01_Tips_Tip[j].enabled = true;
                            j++;
                            yield return new WaitForSeconds(BOSS_Atk01_delay);
                            break;
                    }
                }
                yield return new WaitForSeconds(1.8f - BOSS_Atk01_delay * 4);
                j = 0;
                for (int i = 0; i < BOSS_Atk01_clockwise.Length; i++)
                {
                    BOSS_Atk01_clockwise[i].SetBool("ready_area_wait", false);

                    switch (i)
                    {
                        case 0:
                        case 2:
                        case 5:
                        case 9:
                        case 12:
                            BOSS_Atk01_Tips_Tip[j].enabled = false;
                            BOSS_Atk01_Tips_Tip[j].gameObject.SetActive(false);
                            j++;
                            yield return new WaitForSeconds(BOSS_Atk01_delay);
                            break;
                    }
                }
                break;
            case 1://順時針
                for (int i = BOSS_Atk01_clockwise_cards.Length - 1; i >= 0; i--)
                {
                    int card_style = Random.Range(0, 6);
                    BOSS_Atk01_clockwise_cards[i].SetTrigger($"Atk{card_style}");

                    switch (i)
                    {
                        case 3:
                        case 6:
                        case 10:
                        case 13:
                            BOSS_Atk01_Tips_Tip[j].enabled = true;
                            j++;
                            yield return new WaitForSeconds(BOSS_Atk01_delay);
                            break;
                    }
                }
                yield return new WaitForSeconds(1.8f - BOSS_Atk01_delay * 4);
                j = 0;
                for (int i = BOSS_Atk01_clockwise_cards.Length - 1; i >= 0; i--)
                {
                    BOSS_Atk01_clockwise[i].SetBool("ready_area_wait", false);

                    switch (i)
                    {
                        case 0:
                        case 3:
                        case 6:
                        case 10:
                        case 13:
                            BOSS_Atk01_Tips_Tip[j].enabled = false;
                            BOSS_Atk01_Tips_Tip[j].gameObject.SetActive(false);
                            j++;
                            yield return new WaitForSeconds(BOSS_Atk01_delay);
                            break;
                    }
                }
                break;
            case 2://由內向外
                for (int i = 0; i < (BOSS_Atk01_clockwise.Length - 1) / 2 + 1; i++)
                {
                    int card_style = Random.Range(0, 6);
                    BOSS_Atk01_clockwise_cards[i].SetTrigger($"Atk{card_style}");
                    card_style = Random.Range(0, 6);
                    BOSS_Atk01_clockwise_cards[BOSS_Atk01_clockwise_cards.Length - 1 - i].SetTrigger($"Atk{card_style}");
                    switch (i)
                    {
                        case 2:
                        case 5:
                            BOSS_Atk01_Tips_Tip[j].enabled = true;
                            BOSS_Atk01_Tips_Tip[BOSS_Atk01_Tips_Tip.Length - 1 - j].enabled = true;
                            j++;
                            yield return new WaitForSeconds(BOSS_Atk01_delay);
                            break;
                    }
                }
                yield return new WaitForSeconds(1.8f - BOSS_Atk01_delay * 4);
                j = 0;
                for (int i = 0; i < (BOSS_Atk01_clockwise.Length - 1) / 2 + 1; i++)
                {
                    BOSS_Atk01_clockwise[i].SetBool("ready_area_wait", false);
                    BOSS_Atk01_clockwise[BOSS_Atk01_clockwise.Length - 1 - i].SetBool("ready_area_wait", false);
                    switch (i)
                    {
                        case 0:
                        case 2:
                        case 5:
                            BOSS_Atk01_Tips_Tip[j].enabled = false;
                            BOSS_Atk01_Tips_Tip[BOSS_Atk01_Tips_Tip.Length - 1 - j].enabled = false;
                            BOSS_Atk01_Tips_Tip[j].gameObject.SetActive(false);
                            BOSS_Atk01_Tips_Tip[BOSS_Atk01_Tips_Tip.Length - 1 - j].gameObject.SetActive(false);
                            j++;
                            yield return new WaitForSeconds(BOSS_Atk01_delay);
                            break;
                    }
                }
                break;
        }
        BOSS_Atk_state = 2;
        BOSS_Atk_bool = false;
        //由內向外、由外向內、由近向遠、由遠向近
    }

    static public bool BOSS_Atk02_ready_bool = false;
    private void Boss_Atk02()
    {
        if (BOSS_Atk02_ready_bool)
        {
            BOSS_Atk02_ready_bool = false;
            Boss_Animator.SetBool("atk_end", false);
        }
    }

    public GameObject[] BOSS_Atk03_Tips;
    public Collider[] BOSS_Atk03_GC;
    public Animator[] BOSS_Atk03_Ani_ground;
    public Animator[] BOSS_Atk03_Ani_cards;
    private bool BOSS_Atk03_isFacingRight = true;
    int BOSS_Atk03_random = 0;
    private void Boss_Atk03()
    {
        StartCoroutine(BOSS_Atk03_ready01(0.167f));
        StartCoroutine(BOSS_Atk03_ready02());
    }
    IEnumerator BOSS_Atk03_ready01(float wait)
    {
        BOSS_Atk03_random = Random.Range(0, 2);
        BOSS_Atk03_random = 0;
        switch (BOSS_Atk03_random)
        {
            case 0:
                if (!BOSS_Atk03_isFacingRight)
                {
                    Flip();
                }
                for (int i = 0; i < BOSS_Atk03_Tips.Length - 1; i++)
                {
                    BOSS_Atk03_Tips[i].SetActive(true);
                    yield return new WaitForSeconds(wait);
                }
                yield return new WaitForSeconds(7f);
                for (int i = 0; i < BOSS_Atk03_Tips.Length - 1; i++)
                {
                    BOSS_Atk03_Tips[i].SetActive(false);
                    yield return new WaitForSeconds(wait);
                }
                Boss_Animator.SetBool("atk_end", false);
                Debug.Log("BOSS_Atk03_Tips.Length - 1 = " + (BOSS_Atk03_Tips.Length - 1));
                for (int i = 0; i < BOSS_Atk03_Ani_cards.Length - 4; i++)
                {
                    for (int j = i; i < j + 3; i++)
                    {
                        BOSS_Atk03_Ani_ground[i].SetTrigger("BOSS_Atk03_Ground");
                        BOSS_Atk03_Ani_cards[i].SetTrigger("BOSS_Atk03_Card");
                        Debug.Log("BOSS Atk i = " + i + ",j = " + j);
                    }
                    i--;
                    yield return new WaitForSeconds(wait);
                }
                break;
            case 1:
                if (BOSS_Atk03_isFacingRight)
                {
                    Flip();
                }
                for (int i = BOSS_Atk03_Tips.Length - 1; i > 0; i--)
                {
                    BOSS_Atk03_Tips[i].SetActive(true);
                    yield return new WaitForSeconds(wait);
                }
                yield return new WaitForSeconds(7f);
                for (int i = BOSS_Atk03_Tips.Length - 1; i > 0; i--)
                {
                    BOSS_Atk03_Tips[i].SetActive(false);
                    yield return new WaitForSeconds(wait);
                }
                Boss_Animator.SetBool("atk_end", false);
                for (int i = BOSS_Atk03_Ani_cards.Length - 1; i > 3; i--)
                {
                    for (int j = i; i > j - 3; i--)
                    {
                        BOSS_Atk03_Ani_ground[i].SetTrigger("BOSS_Atk03_Ground");
                        BOSS_Atk03_Ani_cards[i].SetTrigger("BOSS_Atk03_Card");
                    }
                    yield return new WaitForSeconds(wait);
                }
                break;
        }
    }
    IEnumerator BOSS_Atk03_ready02()
    {
        switch (BOSS_Atk03_random)
        {
            case 0:
                for (int i = 0; i < BOSS_Atk03_GC.Length - 1; i++)
                {
                    yield return new WaitUntil(() =>
                    {
                        AnimatorStateInfo stateInfo = BOSS_Atk03_Ani_cards[i * 3].GetCurrentAnimatorStateInfo(0);
                        return stateInfo.IsName("BOSS_Atk03_Card") && stateInfo.normalizedTime >= 0.98f;
                    });
                    BOSS_Atk03_GC[i].enabled = false;
                }
                BOSS_Atk_state = 1;
                BOSS_Atk_bool = false;
                break;
            case 1:
                for (int i = BOSS_Atk03_GC.Length - 1; i > 0; i--)
                {
                    yield return new WaitUntil(() =>
                    {
                        AnimatorStateInfo stateInfo = BOSS_Atk03_Ani_cards[i * 3].GetCurrentAnimatorStateInfo(0);
                        return stateInfo.IsName("BOSS_Atk03_Card") && stateInfo.normalizedTime >= 0.98f;
                    });
                    BOSS_Atk03_GC[i].enabled = false;
                }
                BOSS_Atk_state = 1;
                BOSS_Atk_bool = false;
                Debug.Log("BOSS_Atk_state = " + BOSS_Atk_state + ",BOSS_Atk_bool = " + BOSS_Atk_bool);
                break;
        }

    }

    void Flip()
    {
        for (int i = 0; i < BOSS_Atk03_Ani_cards.Length; i++)
        {
            BOSS_Atk03_isFacingRight = !BOSS_Atk03_isFacingRight;
            Vector3 theScale = BOSS_Atk03_Ani_cards[i].transform.localScale;
            theScale.x *= -1;
            BOSS_Atk03_Ani_cards[i].transform.localScale = theScale;
        }
    }

    private void MC_Atk_End()
    {
        BOSS_Atk_bool = false;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "MC_Att")
        {
            Boss_Animator.SetTrigger("Hit");
            Invoke("MC_Atk_End", 1f);
        }
    }
}
