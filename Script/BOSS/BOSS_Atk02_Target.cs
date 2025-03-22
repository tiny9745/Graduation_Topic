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
    void Start()
    {
        for (int i = 0; i < BOSS_Atk02_Ani_target.Length; i++)
        {
            triggered[i] = false;
        }
        Invoke("Boss_Atk02", 7f);
    }

    void Update()
    {
        if (Boss_col.BOSS_Atk_time > 3)
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
        StartCoroutine(BOSS_Atk02_ready01(1.06f));
    }
    IEnumerator BOSS_Atk02_ready01(float wait)
    {
        for (int i = 0; i < BOSS_Atk02_Ani_cards.Length; i++)
        {
            BOSS_Atk02_Ani_cards[i].gameObject.SetActive(true);
            BOSS_Atk02_Ani_cards[i].SetBool($"Atk0{i + 1}", true);

            // 等待動畫播放到 95% 再繼續
            yield return new WaitUntil(() =>
            {
                AnimatorStateInfo stateInfo = BOSS_Atk02_Ani_cards[i].GetCurrentAnimatorStateInfo(0);
                return stateInfo.IsName($"BOSS_Atk02_0{i + 1}") && stateInfo.normalizedTime >= 0.95f;
            });
            Debug.Log("動畫播放到 95% 觸發條件！");
            BOSS_Atk02_hints[i].SetActive(true);
            BOSS_Atk02_Ani_target[i].SetTrigger("BOSS_Atk02_Target");
        }
        // yield return new WaitForSeconds(wait);
        for (int i = 0; i < BOSS_Atk02_Ani_cards.Length; i++)
        {
            BOSS_Atk02_ready02(i);
            yield return new WaitForSeconds(wait);
        }
        Boss_col.BOSS_Atk_state = 3;
        Boss_col.BOSS_Atk_bool = false;
    }

    private void BOSS_Atk02_ready02(int count)
    {
        Instantiate(BOSS_Atk02_Atk_cards[count], BOSS_Atk02_Ani_cards[count].gameObject.transform.position, BOSS_Atk02_Ani_cards[count].gameObject.transform.rotation);
        BOSS_Atk02_Ani_cards[count].SetBool($"Atk0{count + 1}", false);
        BOSS_Atk02_Ani_cards[count].gameObject.SetActive(false);
    }
}
