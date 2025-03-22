using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSS_Atk02_Target : MonoBehaviour
{
    // Start is called before the first frame update
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
    }

    // Update is called once per frame
    void Update()
    {
        if (Boss_col.BOSS_Atk_time > 3 && Boss_col.BOSS_Atk_bool == true)
        {
            switch (Boss_col.BOSS_Atk_state)
            {
                case 2:
                    Boss_col.BOSS_Atk_time = 0;
                    Boss_Atk02();
                    break;
            }
        }


        AnimatorStateInfo stateInfo = BOSS_Atk02_Ani_target[0].GetCurrentAnimatorStateInfo(0);

        if (stateInfo.IsName("BOSS_Atk02_Target"))
        {
            float currentTime = stateInfo.normalizedTime * stateInfo.length; // 計算當前秒數

            if (currentTime >= 3.32f && !triggered[0]) // x 秒觸發
            {
                triggered[0] = true;
                Debug.Log("動畫播放到 x 秒，觸發事件！");
            }
        }
    }
    private void Boss_Atk02()
    {
        Boss_col.BOSS_Atk_bool = true;
        StartCoroutine(BOSS_Atk02_ready01(0.67f));
    }
    IEnumerator BOSS_Atk02_ready01(float wait)
    {
        for (int i = 0; i < BOSS_Atk02_Ani_cards.Length; i++)
        {
            BOSS_Atk02_Ani_cards[i].gameObject.SetActive(true);
            BOSS_Atk02_Ani_cards[i].SetTrigger($"Atk0{i + 1}");
            yield return new WaitForSeconds(wait);
        }
        for (int i = 0; i < BOSS_Atk02_Atk_cards.Length; i++)
        {
            Instantiate(BOSS_Atk02_Atk_cards[i], BOSS_Atk02_Ani_cards[i].gameObject.transform.position, BOSS_Atk02_Area.transform.rotation);
            BOSS_Atk02_Ani_cards[i].gameObject.SetActive(false);
            yield return new WaitForSeconds(wait);
        }
        Boss_col.BOSS_Atk_bool = false;
        Boss_col.BOSS_Atk_state = 3;
    }
}
