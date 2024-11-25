using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ItemContainer : MonoBehaviour
{
    public Item thisItem;
    private void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.name == "Player" &&static_parameters.bullet_quantity < 4)
        {
            InventoryManager.Instance.Add(thisItem);
            InventoryManager.Instance.onInventoryCallBack();
            Destroy(gameObject);
        }
    }
}