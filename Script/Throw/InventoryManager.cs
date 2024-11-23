using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryManager : MonoBehaviour
{
    #region Singleton
    public static InventoryManager Instance;

    int bullet_quantity = 0;
    public GameObject bullet;
    public Transform Firepoint;
    public ItemSlot _slot;

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
    public List<Item> ItemList;
    public delegate void onInventoryChange();
    public onInventoryChange onInventoryCallBack;

    private void Update()
    {
        if (bullet_quantity > 0)
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                bullet_fire();
            }
        }
    }
    public void Add(Item newItem)
    {
        ItemList.Add(newItem);
        bullet_quantity++;
    }
    public void Remove(Item oldItem)
    {
        ItemList.Remove(oldItem);
    }

    public void bullet_fire()
    {
        if(static_parameters.MC_HP > 0)
        {
            Instantiate(bullet, Firepoint.position, Firepoint.rotation);
            bullet_quantity--;
            _slot.UseItem();
        }
    }
}