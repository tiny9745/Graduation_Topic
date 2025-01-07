using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornsController : MonoBehaviour
{
    private HashSet<Collider> collidersInRange = new HashSet<Collider>(); // 記錄範圍內的碰撞體
    private int colliderCount = 0; // 手動管理的碰撞體數量

    public Animator[] anim;

    void Start()
    {
        StartCoroutine(CheckCollidersRoutine());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("NPC"))
        {
            if (collidersInRange.Add(other)) // 確保不重複添加
            {
                colliderCount++;
                Debug.Log("Collider entered: " + other.name + ". Current count: " + colliderCount);
            }
        }

        if (colliderCount == 1) // 只有一個物件進入時觸發
        {
            Rise_Animation();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (collidersInRange.Remove(other)) // 確保只移除存在於集合中的物件
            {
                colliderCount--;
                Debug.Log("Collider exited: " + other.name + ". Current count: " + colliderCount);
            }
        }

        if (colliderCount == 0) // 沒有物件時觸發
        {
            Lower_Animation();
        }
    }

    private IEnumerator CheckCollidersRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f); // 調整檢查頻率
            CheckColliders();
        }
    }

    private void CheckColliders()
    {
        List<Collider> toRemove = new List<Collider>();

        // 找出已被刪除的物件
        foreach (var collider in collidersInRange)
        {
            if (collider == null)
            {
                toRemove.Add(collider);
                colliderCount--; // 減少計數
            }
        }

        // 從集合中移除已刪除的物件
        foreach (var collider in toRemove)
        {
            collidersInRange.Remove(collider);
        }

        if (colliderCount == 0) // 檢查是否需要觸發動畫
        {
            Lower_Animation();
        }
    }

    private void Rise_Animation()
    {
        // Debug.Log("Rise");
        foreach (var animator in anim)
        {
            animator.SetBool("Rise", true);
        }
        Invoke("Rise_wait", 0.05f);
    }

    private void Rise_wait()
    {
        foreach (var animator in anim)
        {
            animator.SetBool("Rise", false);
        }
    }

    private void Lower_Animation()
    {
        // Debug.Log("Lower");
        foreach (var animator in anim)
        {
            animator.SetBool("Lower", true);
        }
        Invoke("Lower_wait", 0.05f);
    }

    private void Lower_wait()
    {
        foreach (var animator in anim)
        {
            animator.SetBool("Lower", false);
        }
    }
}
