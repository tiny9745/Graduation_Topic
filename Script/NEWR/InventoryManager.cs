using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InventoryManager : MonoBehaviour
{
    #region Singleton
    public static InventoryManager Instance;
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
    int tmp;

    private void Update()
    {
        if(PlayerCtrl.bullet_quantity != tmp)
        {
            
        }
    }
    public void Add(Item newItem)
    {
        ItemList.Add(newItem);
        PlayerCtrl.bullet_quantity++;
    }
    public void Remove(Item oldItem)
    {
        ItemList.Remove(oldItem);
    }
}