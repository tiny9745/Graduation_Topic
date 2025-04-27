using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blood_col : MonoBehaviour
{
    public MC_col MC_col;
    private RectTransform HPimg_White, HPimg_Green;
    float blood_base = 1;
    float blood_tmp = 1040;
    float previous_MC_HP_Max;

    void Start()
    {
        FindHPImage();
        previous_MC_HP_Max = static_parameters.MC_HP_Max; // 初始化 previous_MC_HP_Max
    }

    public void Update()
    {
        if (static_parameters.MC_HP_Max != previous_MC_HP_Max)
        {
            AdjustHPForNewMax();
            previous_MC_HP_Max = static_parameters.MC_HP_Max;
        }

        if (static_parameters.MC_HP == static_parameters.MC_HP_Max)
        {
            FindHPImage();
        }

        if (static_parameters.MC_HP_tmp != static_parameters.MC_HP)
        {
            if (HPimg_Green != null)
            {
                HPimg_Green.sizeDelta = new Vector2(static_parameters.MC_HP * blood_base, HPimg_Green.sizeDelta.y);
            }
            if(static_parameters.MC_HP_tmp > static_parameters.MC_HP) MC_col.red();
            static_parameters.MC_HP_tmp = static_parameters.MC_HP;
        }

        MC_HP_effects();
    }

    public void FindHPImage()
    {
        RectTransform[] foundRectTransforms = FindObjectsOfType<RectTransform>();
        foreach (RectTransform rectTransform in foundRectTransforms)
        {
            if (rectTransform.name == "HP_change")
            {
                HPimg_White = rectTransform;
            }
            if (rectTransform.name == "HP_change_after")
            {
                HPimg_Green = rectTransform;
                break;
            }
        }

        blood_base = blood_tmp / static_parameters.MC_HP_Max;

        if (HPimg_White != null && HPimg_Green != null)
        {
            HPimg_White.sizeDelta = new Vector2(static_parameters.MC_HP_Max * blood_base, HPimg_White.sizeDelta.y);
            HPimg_Green.sizeDelta = new Vector2(static_parameters.MC_HP * blood_base, HPimg_White.sizeDelta.y);
        }
    }

    private void AdjustHPForNewMax()
    {
        float hpRatio = static_parameters.MC_HP / previous_MC_HP_Max;
        static_parameters.MC_HP = Mathf.Min(static_parameters.MC_HP * (static_parameters.MC_HP_Max / previous_MC_HP_Max), static_parameters.MC_HP_Max);
        static_parameters.MC_HP_tmp = static_parameters.MC_HP;

        UpdateHPMax();
    }

    private void UpdateHPMax()
    {
        blood_base = blood_tmp / static_parameters.MC_HP_Max;
        HPimg_White.sizeDelta = new Vector2(static_parameters.MC_HP_Max * blood_base, HPimg_White.sizeDelta.y);
        HPimg_Green.sizeDelta = new Vector2(static_parameters.MC_HP * blood_base, HPimg_Green.sizeDelta.y);
    }

    public void MC_HP_effects()
    {
        if (HPimg_White != null && HPimg_Green != null && HPimg_White.sizeDelta.x > HPimg_Green.sizeDelta.x)
        {
            float baseSpeed = 6f;
            float difference = HPimg_White.sizeDelta.x - HPimg_Green.sizeDelta.x;
            float speed = baseSpeed + (difference * 0.1f);
            HPimg_White.sizeDelta -= new Vector2(1, 0) * Time.deltaTime * speed;

            if (HPimg_White.sizeDelta.x < HPimg_Green.sizeDelta.x)
            {
                HPimg_White.sizeDelta = new Vector2(HPimg_Green.sizeDelta.x, HPimg_White.sizeDelta.y);
            }
        }
    }
}
