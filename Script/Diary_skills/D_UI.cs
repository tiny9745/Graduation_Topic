using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class D_UI : MonoBehaviour
{
    static public Icon_slot[] DSlot;
    public Transform iconSlotPoint;
    public Text Diary_title, Diary_content;
    int itemsPerPage = 8,startIndex,endIndex;
    public int page = 0;
    void Start()
    {
        IconManager.Instance.IconInventoryCallBack += UpdateIcon;
        DSlot = iconSlotPoint.GetComponentsInChildren<Icon_slot>();
    }

    // Update is called once per frame
    void UpdateIcon()
    {
        Debug.Log("UpdateIcon");
        startIndex = page * itemsPerPage;
        endIndex = Mathf.Min(startIndex + itemsPerPage, IconManager.Instance.IconList.Count);
        for (int i = startIndex; i <endIndex + 8; i++)
        {
            if (i < IconManager.Instance.IconList.Count)
            {
                Debug.Log("i"+i);
                DSlot[i].AddIcon(IconManager.Instance.IconList[i]);
            }else
            {
                Debug.Log("clean");
                DSlot[i].Clean();
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
}
