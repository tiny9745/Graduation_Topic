using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ItemContainer : MonoBehaviour
{
    public Item thisItem;

    private void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.name == "Player")
        {
            InventoryManager.Instance.Add(thisItem);
            InventoryManager.Instance.onInventoryCallBack();
            Destroy(gameObject);
        }
    }
}