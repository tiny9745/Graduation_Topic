using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemSlot : MonoBehaviour
{
    Item item; public Change_mood C_mood;
    public Image ItemImage;
    public Text ItemName;
    public Sprite emptySprite,Ewow,Eanger,Esad,Ehappy;
    public int slotID;
    public void AddItem(Item thisItem)
    {
        item = thisItem;
        ItemImage.sprite = item.ItemImage;
        ItemName.text = item.ItemName;
        slotID = item.ItemID;
    }
    public void RemoveItem()
    {
        InventoryManager.Instance.Remove(item);
        InventoryManager.Instance.onInventoryCallBack();
    }
    public void Clean()
    {
        item = null;
        switch (C_mood.mood)
        {
            case 0:
                ItemImage.sprite = Ewow;
                break;
            case 1:
                ItemImage.sprite = Eanger;
                break;
            case 2:
                ItemImage.sprite = Esad;
                break;
            /*case 3:
                ItemImage.sprite = emptySprite;
                break;*/
            case 4:
                ItemImage.sprite = Ehappy;
                break;
            default:
                ItemImage.sprite = emptySprite;
                break;
        }
        ItemName.text = "Empty";
    }
    public void UseItem()
    {
        if (item != null)
        {
            item.UseItem();
            RemoveItem();
        }
        else
        {
            return;
        }
    }
}