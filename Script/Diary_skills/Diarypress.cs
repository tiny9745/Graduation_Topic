using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Diarypress : MonoBehaviour
{
    public GameObject number,Slots,DText;
    int Choose_diary,DiaryNumber;
    public Text Diary_title, Diary_content;
    public void Dpress()
    {
        int.TryParse(number.name, out DiaryNumber);
        Choose_diary = DiaryNumber;
        if(Choose_diary>IconManager.Instance.IconList.Count){
            Diary_title.text=" ";
            Diary_content.text=" ";
        }else{
            Slots.SetActive(false);DText.SetActive(true);
            Skill_public_funtion.Reading = true;
            Diary_title.text = IconManager.Instance.IconList[Choose_diary-1].diary_title;
            Diary_content.text = IconManager.Instance.IconList[Choose_diary-1].diary_content;
        }
    }
    public void Dclose()
    {
        Slots.SetActive(true);DText.SetActive(false);
        Skill_public_funtion.Reading = false;
    }
}
