using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ItemContainer : MonoBehaviour
{
    public Item thisItem;
    public AudioSource audioSource;
    private void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == "Player" && static_parameters.bullet_quantity < 4)
        {
            audioSource.Play();
            InventoryManager.Instance.Add(thisItem);
            InventoryManager.Instance.onInventoryCallBack();
            Destroy(gameObject);
        }
    }
}