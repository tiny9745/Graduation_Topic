using System.Collections;
using UnityEngine;

public class BOSS_Blood : MonoBehaviour
{
    public Boss_col boss_col;
    private RectTransform HPimg_White, HPimg_Green;
    float blood_base = 1;
    float blood_tmp = 950;
    float previous_BOSS_HP_Max;
    public Canvas canvas;

    public float live_HP = static_parameters.MC_HP_Max;

    float minus;
    IEnumerator Start()
    {
        canvas.sortingOrder = -1000;
        yield return null;
        TryFindHPImage();
        previous_BOSS_HP_Max = boss_col.BOSS_HP_Max;
        UpdateHealthBars();
    }

    void Update()
    {
        CheckAndAdjustHPMax();
        if (boss_col.BOSS_HP_tmp != boss_col.BOSS_HP) UpdateGreenHPBar();
        BOSS_HP_effects();
        if (boss_col.BOSS_live == false)
        {
            static_parameters.MC_HP = live_HP;
        }
    }

    public void TakeDamage(float damage, float NPC_DEF)
    {
        boss_col.change_color_red();
        minus = (float)(damage * damage / (damage + NPC_DEF));
        if (minus < 5) minus = 5;
        boss_col.BOSS_HP -= minus;
        boss_col.BOSS_HP = Mathf.Clamp(boss_col.BOSS_HP, 0, previous_BOSS_HP_Max);
    }

    void TryFindHPImage()
    {
        if (HPimg_White == null || HPimg_Green == null)
        {
            RectTransform[] found = FindObjectsOfType<RectTransform>();
            foreach (RectTransform rect in found)
            {
                if (rect.name == "BOSS_HP_change") HPimg_White = rect;
                else if (rect.name == "BOSS_HP_change_after") HPimg_Green = rect;
            }
            UpdateBloodBase();
        }
    }

    void UpdateBloodBase()
    {
        if (boss_col.BOSS_HP_Max > 0)
            blood_base = blood_tmp / boss_col.BOSS_HP_Max;
        else
            blood_base = 0;
    }

    void CheckAndAdjustHPMax()
    {
        if (boss_col.BOSS_HP_Max != previous_BOSS_HP_Max)
        {
            float ratio = boss_col.BOSS_HP / previous_BOSS_HP_Max;
            boss_col.BOSS_HP = Mathf.Clamp(ratio * boss_col.BOSS_HP_Max, 0, boss_col.BOSS_HP_Max);
            boss_col.BOSS_HP_tmp = boss_col.BOSS_HP;
            previous_BOSS_HP_Max = boss_col.BOSS_HP_Max;
            UpdateBloodBase();
            UpdateHealthBars();
        }
    }

    void UpdateHealthBars()
    {
        if (HPimg_White != null)
            HPimg_White.sizeDelta = new Vector2(boss_col.BOSS_HP_Max * blood_base, HPimg_White.sizeDelta.y);

        if (HPimg_Green != null)
            HPimg_Green.sizeDelta = new Vector2(boss_col.BOSS_HP * blood_base, HPimg_Green.sizeDelta.y);
    }

    void UpdateGreenHPBar()
    {
        if (HPimg_Green != null)
        {
            HPimg_Green.sizeDelta = new Vector2(boss_col.BOSS_HP * blood_base, HPimg_Green.sizeDelta.y);
        }
    }

    public void BOSS_HP_effects()
    {
        if (HPimg_White != null && HPimg_Green != null && HPimg_White.sizeDelta.x > HPimg_Green.sizeDelta.x)
        {
            float diff = HPimg_White.sizeDelta.x - HPimg_Green.sizeDelta.x;
            float speed = 20f + diff * 0.25f;

            HPimg_White.sizeDelta -= new Vector2(1, 0) * Time.deltaTime * speed;

            if (HPimg_White.sizeDelta.x < HPimg_Green.sizeDelta.x)
            {
                HPimg_White.sizeDelta = new Vector2(HPimg_Green.sizeDelta.x, HPimg_White.sizeDelta.y);
            }
        }
    }
}