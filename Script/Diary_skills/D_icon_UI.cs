using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class D_icon_UI : MonoBehaviour
{
    static public Icon_slot[] iconSlot;
    public Transform iconSlotPoint;
    public Text skill_title, skill_content;
    public string Skill_title, Skill_content;
    int chooseIcon;
    void Start()
    {
        IconManager.Instance.IconInventoryCallBack += UpdateIcon;
        iconSlot = iconSlotPoint.GetComponentsInChildren<Icon_slot>();
    }

    // Update is called once per frame
    void UpdateIcon()
    {
        for (int i = 0; i < iconSlot.Length; i++)
        {
            if (i < IconManager.Instance.IconList.Count)
            {
                iconSlot[i].AddIcon(IconManager.Instance.IconList[i]);
            }
            else
            {
                iconSlot[i].Clean();
            }
        }
    }
    public void ChooseIcon()
    {
        chooseIcon = Iconpress.itemNumber;
        ShowSkill();
    }
    void ShowSkill()
    {
        if(chooseIcon>IconManager.Instance.IconList.Count){
            skill_title.text="選擇要查看的技能";
            skill_content.text=" ";
        }else{
            skill_title.text = IconManager.Instance.IconList[chooseIcon-1].skill_title;
            skill_content.text = IconManager.Instance.IconList[chooseIcon-1].skill_content;
        }
        
    }
}
