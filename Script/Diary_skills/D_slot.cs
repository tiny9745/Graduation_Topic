using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class D_slot : MonoBehaviour
{
    Diary_icon icon;
    public Image IconImage;
    public Sprite emptySprite;
    public Text diary_title,diary_date;
    
    public void AddIcon(Diary_icon thisItem)
    {
        icon = thisItem;
        IconImage.sprite = icon.iconImage;
        diary_title.text = icon.diary_title;
        diary_date.text = icon.date;
    }
    public void RemoveItem()
    {
        IconManager.Instance.Remove(icon);
        IconManager.Instance.IconInventoryCallBack();
    }
    public void Clean()
    {
        Debug.Log("Clean");
        icon = null;
        IconImage.sprite = emptySprite;
        diary_title.text = ""; diary_date.text = "";
    }
}
