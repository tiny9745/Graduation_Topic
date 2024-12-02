using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornsController : MonoBehaviour
{
    public GameObject[] thorns; // 刺的陣列
    public float targetHeight = 5f; // 上升的目標高度
    public float riseTime = 1f; // 上升所需的時間
    public float fallTime = 1f; // 下降所需的時間

    private Vector3[] originalPositions; // 記錄刺的原始位置
    private HashSet<Collider> collidersInRange = new HashSet<Collider>(); // 記錄範圍內的碰撞體

    void Start()
    {
        // 記錄每個刺的初始位置
        originalPositions = new Vector3[thorns.Length];
        for (int i = 0; i < thorns.Length; i++)
        {
            originalPositions[i] = thorns[i].transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("NPC"))
        {
            collidersInRange.Add(other); // 將物件加入集合
        }
        if (collidersInRange.Count == 1)
        {
            StartCoroutine(RaiseThorns()); // 如果範圍內只有一個符合條件的物件，執行上升
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("NPC"))
        {
            collidersInRange.Remove(other); // 從集合中移除物件
            if (collidersInRange.Count == 0)
            {
                StartCoroutine(LowerThorns()); // 如果範圍內已無符合條件的物件，執行下降
            }
        }
    }

    IEnumerator RaiseThorns()
    {
        foreach (var thorn in thorns)
        {
            Vector3 originalPosition = thorn.transform.position;
            Vector3 targetPosition = originalPosition + Vector3.up * targetHeight;

            float elapsedTime = 0f;
            while (elapsedTime < riseTime)
            {
                elapsedTime += Time.deltaTime;
                thorn.transform.position = Vector3.Lerp(originalPosition, targetPosition, elapsedTime / riseTime);
                yield return null;
            }

            thorn.transform.position = targetPosition; // 確保最終位置精準
        }
    }

    IEnumerator LowerThorns()
    {
        foreach (var thorn in thorns)
        {
            Vector3 targetPosition = thorn.transform.position - Vector3.up * targetHeight;
            Vector3 originalPosition = thorn.transform.position;

            float elapsedTime = 0f;
            while (elapsedTime < fallTime)
            {
                elapsedTime += Time.deltaTime;
                thorn.transform.position = Vector3.Lerp(originalPosition, targetPosition, elapsedTime / fallTime);
                yield return null;
            }
            thorn.transform.position = targetPosition; // 確保最終位置精準
        }
    }
}
