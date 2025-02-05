using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class D_UI : MonoBehaviour
{
    static public D_slot[] DSlot;
    public GameObject Pageup, Pagedown;
    public Transform DSlotPoint;
    public Text Diary_title, Diary_content;
    int itemsPerPage = 8,startIndex;
    public int page = 0;
    void Start()
    {
        IconManager.Instance.IconInventoryCallBack += UpdateIcon;
        DSlot = DSlotPoint.GetComponentsInChildren<D_slot>();
    }

    // Update is called once per frame
    void UpdateIcon()
    {
        startIndex = page * itemsPerPage;
        for (int i = startIndex; i <startIndex+8; i++)
        {
            if (i < IconManager.Instance.IconList.Count)
            {
                DSlot[i].AddIcon(IconManager.Instance.IconList[i]);
            }else
            {
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
