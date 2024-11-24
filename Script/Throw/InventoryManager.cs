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
        if (static_parameters.MC_HP > 0)
        {
            float angle_NPC = FindNearestNPCAngle();

            if (angle_NPC != -1) // 如果找到 NPC
            {
                Quaternion rotation_MC = Quaternion.Euler(0, angle_NPC, 0);
                Instantiate(bullet, Firepoint.position, rotation_MC);

                Debug.Log($"發射子彈，角度為: {angle_NPC} 度");
                bullet_quantity--;
                _slot.UseItem();
            }
        }
    }

    public float FindNearestNPCAngle()
    {
        GameObject[] npcs = GameObject.FindGameObjectsWithTag("NPC");
        GameObject nearestNPC = null;
        float shortestDistance = Mathf.Infinity;

        foreach (GameObject npc in npcs)
        {
            float distance = Vector3.Distance(transform.position, npc.transform.position);
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                nearestNPC = npc;
            }
        }

        if (nearestNPC != null)
        {
            Vector3 directionToNPC = (nearestNPC.transform.position - transform.position).normalized;
            float angle = Vector3.SignedAngle(transform.forward, directionToNPC, Vector3.up);

            Debug.Log($"最近的 NPC 是: {nearestNPC.name}，距離為: {shortestDistance}，與 MC 的角度為: {angle} 度");
            return angle;
        }

        Debug.LogWarning("未找到任何 NPC");
        return -1;
    }
}
