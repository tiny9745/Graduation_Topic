using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemSlot : MonoBehaviour
{
    Item item;
    public Image ItemImage;
    public Text ItemName;
    public Sprite emptySprite;
    public void AddItem(Item thisItem)
    {
        item = thisItem;
        ItemImage.sprite = item.ItemImage;
        ItemName.text = item.ItemName;
    }
    public void RemoveItem()
    {
        InventoryManager.Instance.Remove(item);
        InventoryManager.Instance.onInventoryCallBack();
    }
    public void Clean()
    {
        item = null;
        ItemImage.sprite = emptySprite;
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