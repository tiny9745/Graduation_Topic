using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ItemContainer : MonoBehaviour
{
    public Item thisItem;
    public SphereCollider bomb_hitbox;

    private void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == "Player" && static_parameters.bullet_quantity < 4)
        {
            InventoryManager.Instance.Add(thisItem);
            InventoryManager.Instance.onInventoryCallBack();
            bomb_hitbox.enabled = false;
            Destroy(gameObject);
        }
    }
}