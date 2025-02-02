using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class D_UI : MonoBehaviour
{
    static public Icon_slot[] DSlot;
    public Transform iconSlotPoint;
    public Text Diary_title, Diary_content;
    public int page = 0;int itemsPerPage = 8;
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
        }
    }
    public void NextPage()
    {
        // Check if the next page exists
        if ((page + 1) * itemsPerPage < IconManager.Instance.IconList.Count)
        {
            page++;
        }
    }
    public void PreviousPage()
    {
        if (page > 0) page--;
    }
    void ShowDiary()
    {
        int startIndex = page * itemsPerPage;
        int endIndex = Mathf.Min(startIndex + itemsPerPage, IconManager.Instance.IconList.Count);
        for (int i = 0; i < DSlot.Length; i++)
        {
            if (i < endIndex - startIndex)
            {
                DSlot[i].AddIcon(IconManager.Instance.IconList[i + startIndex]);
            }
            else
            {
                DSlot[i].Clean();
            }
        }
    }
}
