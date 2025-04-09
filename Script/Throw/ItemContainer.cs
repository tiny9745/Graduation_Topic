using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ItemContainer : MonoBehaviour
{
    public Item thisItem;
    public SphereCollider bomb_hitbox;
    void Start()
    {
        bomb_hitbox = GetComponent<SphereCollider>();
        bomb_hitbox.enabled = true;
    }

    private void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == "Player" && static_parameters.bullet_quantity < 4)
        {
            bomb_hitbox.enabled = false;
            InventoryManager.Instance.Add(thisItem);
            InventoryManager.Instance.onInventoryCallBack();
            Destroy(gameObject);
        }
    }
}