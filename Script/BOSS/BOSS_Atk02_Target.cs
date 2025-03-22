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
    public GameObject BOSS_Atk02_Area;
    void Start()
    {
        for (int i = 0; i < BOSS_Atk02_Ani_target.Length; i++)
        {
            triggered[i] = false;
        }
        Invoke("Boss_Atk02", 10f);
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
        int count = 0;
        while (count >= BOSS_Atk02_Ani_target.Length - 1)
        {
            AnimatorStateInfo stateInfo = BOSS_Atk02_Ani_target[0].GetCurrentAnimatorStateInfo(0);

            if (stateInfo.IsName("BOSS_Atk02_Target"))
            {
                float currentTime = stateInfo.normalizedTime * stateInfo.length; // 計算當前秒數
                if (currentTime >= 3.32f && !triggered[0]) // x 秒觸發
                {
                    triggered[0] = true;
                    BOSS_Atk02_ready02(count);
                    count++;
                }
            }
        }
        for (int i = 0; i < BOSS_Atk02_Ani_target.Length; i++)
        {
            triggered[i] = false;
        }
    }
    private void Boss_Atk02()
    {
        StartCoroutine(BOSS_Atk02_ready01(0.67f));
    }
    IEnumerator BOSS_Atk02_ready01(float wait)
    {
        for (int i = 0; i < BOSS_Atk02_Ani_cards.Length; i++)
        {
            Debug.Log("Atk02_ready01: " + i);
            BOSS_Atk02_Ani_cards[i].gameObject.SetActive(true);
            BOSS_Atk02_Ani_cards[i].SetBool($"Atk0{i + 1}", true);
            yield return new WaitForSeconds(wait);
        }
    }

    private void BOSS_Atk02_ready02(int count)
    {
        Instantiate(BOSS_Atk02_Atk_cards[count], BOSS_Atk02_Ani_cards[count].gameObject.transform.position, BOSS_Atk02_Area.transform.rotation);
        BOSS_Atk02_Ani_cards[count].SetBool($"Atk0{count + 1}", false);
        BOSS_Atk02_Ani_cards[count].gameObject.SetActive(false);

        Boss_col.BOSS_Atk_bool = false;
        Boss_col.BOSS_Atk_state = 3;
    }
}
