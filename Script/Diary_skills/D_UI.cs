using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class D_UI : MonoBehaviour
{
    static public Icon_slot[] DSlot;
    public Transform iconSlotPoint;
    public Text Diary_title, Diary_content;
    int chooseIcon;
    void Start()
    {
        IconManager.Instance.IconInventoryCallBack += UpdateIcon;
        DSlot = iconSlotPoint.GetComponentsInChildren<Icon_slot>();
    }

    // Update is called once per frame
    void UpdateIcon()
    {
        for (int i = 0; i < DSlot.Length; i++)
        {
            if (i < IconManager.Instance.IconList.Count)
            {
                DSlot[i].AddIcon(IconManager.Instance.IconList[i]);
            }
            else
            {
                DSlot[i].Clean();
            }
        }
    }
    public void ChooseIcon()
    {
    }
    void ShowSkill()
    {

    }
}
