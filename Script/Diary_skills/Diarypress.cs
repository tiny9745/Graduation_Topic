using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Diarypress : MonoBehaviour
{
    public D_UI d_UI;
    public GameObject number, Slots, DText;
    int Choose_diary, DiaryNumber;
    public Text Diary_title, Diary_content;
    public void Dpress()
    {
        Slots.SetActive(false); DText.SetActive(true);
        int.TryParse(number.name, out DiaryNumber);
        Choose_diary = DiaryNumber;
        if (Choose_diary > IconManager.Instance.IconList.Count)
        {
            return;
        }
        else
        {
            Slots.SetActive(false); DText.SetActive(true);
            Skill_public_funtion.Reading = true;
            Diary_title.text = IconManager.Instance.IconList[d_UI.page * 8 + Choose_diary - 1].diary_title;
            Diary_content.text = IconManager.Instance.IconList[d_UI.page * 8 + Choose_diary - 1].diary_content;
            d_UI.overflow_text(Diary_content.text);
        }
    }
    public void Dclose()
    {
        Slots.SetActive(true); DText.SetActive(false);
        Skill_public_funtion.Reading = false;
    }
}
