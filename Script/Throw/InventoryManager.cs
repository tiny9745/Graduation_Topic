using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    #region Singleton
    public static InventoryManager Instance;
    public GameObject bullet01, bullet43, bullet44;
    public Transform Firepoint;
    public ItemSlot _slot;
    public List<Item> ItemList;
    public delegate void onInventoryChange();
    public onInventoryChange onInventoryCallBack;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(this);
    }
    #endregion

    private void Update()
    {
        if (static_parameters.bullet_quantity > 0)
        {
            if (Input.GetKeyDown(KeyCode.B) && static_parameters.Ani_state < 3)
            {
                bullet_fire();
            }
        }
    }

    public void Add(Item newItem)
    {
        if (static_parameters.bullet_quantity < 4)
        {
            ItemList.Add(newItem);
            static_parameters.bullet_quantity++;
            Debug.Log("bullet_quantity: " + static_parameters.bullet_quantity);
        }
    }

    public void Remove(Item oldItem)
    {
        ItemList.Remove(oldItem);
    }

    public void bullet_fire()
    {
        if (static_parameters.MC_HP > 0)
        {
            Debug.Log("_slot.slotID: " + _slot.slotID);
            if (_slot.slotID == 1)
            {
                Instantiate(bullet01, Firepoint.position, transform.rotation);
            }
            else if (_slot.slotID == 43)
            {
                Instantiate(bullet43, Firepoint.position, transform.rotation);
            }
            else if (_slot.slotID == 44)
            {
                Instantiate(bullet44, Firepoint.position, transform.rotation);
            }
            static_parameters.bullet_quantity--;
            _slot.UseItem();
        }
    }
}
