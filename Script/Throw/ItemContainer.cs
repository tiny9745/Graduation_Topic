using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ItemContainer : MonoBehaviour
{
    public Item thisItem;
    public SphereCollider bomb_hitbox;
    public InventoryManager inventoryManager;
    public GameObject falsh_ani;
    void Start()
    {
        inventoryManager = FindObjectOfType<InventoryManager>();
        bomb_hitbox = GetComponent<SphereCollider>();
        bomb_hitbox.enabled = true;
    }

    private void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == "Player" && InventoryManager.Instance.ItemList.Count < 4)
        {
            if (bomb_hitbox != null) bomb_hitbox.enabled = false;
            InventoryManager.Instance.Add(thisItem);
            InventoryManager.Instance.onInventoryCallBack();
            Destroy(falsh_ani);
            Destroy(gameObject);
        }
    }
}