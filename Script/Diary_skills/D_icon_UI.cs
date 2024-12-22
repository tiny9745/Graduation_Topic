using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D_icon_UI : MonoBehaviour
{
    public Icon_slot[] iconSlot;
    public Transform iconSlotPoint;
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
}
