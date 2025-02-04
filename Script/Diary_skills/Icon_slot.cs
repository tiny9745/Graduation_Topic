using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Icon_slot : MonoBehaviour
{
    Diary_icon icon;
    public Image IconImage;
    public Sprite emptySprite;
    
    public void AddIcon(Diary_icon thisItem)
    {
        icon = thisItem;
        IconImage.sprite = icon.iconImage;
    }
    public void Clean()
    {
        icon = null;
        IconImage.sprite = emptySprite;
    }
}
