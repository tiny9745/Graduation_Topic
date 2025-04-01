using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSS_Atk02_Target : MonoBehaviour
{
    public GameObject targetObject;
    public Animator[] BOSS_Atk02_Ani_cards;
    public Animator[] BOSS_Atk02_Ani_target;
    private bool[] triggered = new bool[7];
    public GameObject[] BOSS_Atk02_Atk_cards;
    public GameObject[] BOSS_Atk02_hints;
    public AudioClip[] BOSS_Atk02_waring;
    public AudioSource BOSS_Atk02_AudioSource;
    void Start()
    {
        for (int i = 0; i < BOSS_Atk02_Ani_target.Length; i++)
        {
            triggered[i] = false;
        }
    }

    void Update()
    {
        if (Boss_col.BOSS_Atk_time >= 3)
        {
            switch (Boss_col.BOSS_Atk_state)
            {
                case 2:
                    Boss_col.BOSS_Atk_bool = true;
                    Boss_col.BOSS_Atk_time = 0;
                    Boss_Atk02();
                    break;
            }
        }
    }
    private void Boss_Atk02()
    {
        StartCoroutine(BOSS_Atk02_ready00(0.75f));
        StartCoroutine(BOSS_Atk02_ready02());
    }
    IEnumerator BOSS_Atk02_ready00(float wait)
    {
        for (int i = 0; i < BOSS_Atk02_Ani_cards.Length; i++)
        {
            StartCoroutine(BOSS_Atk02_ready01(i));
            yield return new WaitForSeconds(wait);
        }
    }

    IEnumerator BOSS_Atk02_ready01(int i)
    {
        BOSS_Atk02_Ani_cards[i].gameObject.SetActive(true);
        BOSS_Atk02_Ani_cards[i].SetBool($"Atk0{i + 1}", true);

        yield return new WaitUntil(() =>
        {
            AnimatorStateInfo stateInfo = BOSS_Atk02_Ani_cards[i].GetCurrentAnimatorStateInfo(0);
            return stateInfo.IsName($"BOSS_Atk02_0{i + 1}");
        });

        yield return new WaitUntil(() =>
        {
            AnimatorStateInfo stateInfo = BOSS_Atk02_Ani_cards[i].GetCurrentAnimatorStateInfo(0);
            return stateInfo.normalizedTime >= 0.95f;
        });
        BOSS_Atk02_hints[i].SetActive(true);
        BOSS_Atk02_Ani_target[i].SetTrigger("BOSS_Atk02_Target");
    }

    IEnumerator BOSS_Atk02_ready02()
    {
        for (int i = 0; i < BOSS_Atk02_Ani_cards.Length; i++)
        {
            yield return new WaitUntil(() =>
            {
                AnimatorStateInfo stateInfo = BOSS_Atk02_Ani_target[i].GetCurrentAnimatorStateInfo(0);
                return stateInfo.IsName("BOSS_Atk02_Target") && stateInfo.normalizedTime >= 0.9f;
            });
            BOSS_Atk02_ready03(i);
            if (i == 0)
            {
                Boss_col.BOSS_Atk02_ready_bool = true;
            }
        }
        Boss_col.BOSS_Atk_state = 3;
        Boss_col.BOSS_Atk_bool = false;
    }

    private void BOSS_Atk02_ready03(int count)
    {
        Boss_col.BOSS_Atk02_ready03 = true;
        Instantiate(BOSS_Atk02_Atk_cards[count], BOSS_Atk02_Ani_cards[count].gameObject.transform.position, BOSS_Atk02_Ani_cards[count].gameObject.transform.rotation);
        BOSS_Atk02_Ani_cards[count].SetBool($"Atk0{count + 1}", false);
        BOSS_Atk02_Ani_cards[count].gameObject.SetActive(false);
    }
}
