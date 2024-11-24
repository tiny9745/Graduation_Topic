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
    float angle_NPC=0;
    Quaternion rotation_MC;

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
    void Start()
    {

    }
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
            angle_NPC = FindNearestNPCAngle();
            rotation_MC = Quaternion.Euler(0, angle_NPC, 0);
            Instantiate(bullet, Firepoint.position, rotation_MC);
            bullet_quantity--;
            _slot.UseItem();
        }
    }

    public float FindNearestNPCAngle()
    {
        GameObject[] npcs = GameObject.FindGameObjectsWithTag("NPC"); // 獲取所有 Tag 為 "NPC" 的物件
        GameObject nearestNPC = null;
        float shortestDistance = Mathf.Infinity;

        // 遍歷所有 NPC
        foreach (GameObject npc in npcs)
        {
            float distance = Vector3.Distance(transform.position, npc.transform.position); // 計算距離
            if (distance < shortestDistance)
            {
                shortestDistance = distance; // 更新最短距離
                nearestNPC = npc;           // 更新最近 NPC
            }
        }

        // 如果找到最近的 NPC，計算角度
        if (nearestNPC != null)
        {
            // 計算目標方向向量
            Vector3 directionToNPC = (nearestNPC.transform.position - transform.position).normalized;

            // 計算與 MC 前方的角度
            float angle = Vector3.Angle(transform.forward, directionToNPC);

            // Debug 輸出最近 NPC 的名字與角度
            Debug.Log($"最近的 NPC 是: {nearestNPC.name}，與 MC 的角度為: {angle} 度");

            return angle; // 回傳角度
        }

        // 如果未找到 NPC，回傳 -1 表示無結果
        Debug.LogWarning("未找到任何 NPC");
        return -1;
    }
}