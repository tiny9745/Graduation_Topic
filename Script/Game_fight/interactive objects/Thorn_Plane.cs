using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornsController : MonoBehaviour
{
    public GameObject thorn; // 單一刺的物件
    public float targetHeight = 100f; // 上升的目標高度
    public float rise_fall_Time = 0.15f;
    public float delayBeforeRise = 0.5f; // 上升前的延遲時間
    public float delayBeforeFall = 0.5f; // 下降前的延遲時間
    private Vector3 originalPosition; // 刺的原始位置
    private HashSet<Collider> collidersInRange = new HashSet<Collider>(); // 記錄範圍內的碰撞體
    private bool isRaising = false; // 判斷是否正在上升
    private bool isLowering = false; // 判斷是否正在下降

    void Start()
    {
        // 記錄刺的初始位置
        originalPosition = thorn.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("NPC"))
        {
            collidersInRange.Add(other); // 將物件加入集合
        }
        if (collidersInRange.Count == 1 && !isRaising) // 只有一個物件進入且未在上升
        {
            StartCoroutine(RaiseThorn());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("NPC"))
        {
            collidersInRange.Remove(other); // 從集合中移除物件
            if (collidersInRange.Count == 0 && !isLowering) // 沒有物件在範圍內且未在下降
            {
                StartCoroutine(LowerThorn());
            }
        }
    }

    IEnumerator RaiseThorn()
    {
        isRaising = true;
        yield return new WaitForSeconds(delayBeforeRise);

        Vector3 start = thorn.transform.position; // 確保從當前位置開始
        Vector3 target = originalPosition + Vector3.up * targetHeight;
        float elapsedTime = 0f;

        while (elapsedTime < rise_fall_Time)
        {
            elapsedTime += Time.deltaTime;
            thorn.transform.position = Vector3.Lerp(start, target, elapsedTime / rise_fall_Time);
            yield return null;
        }

        thorn.transform.position = target;
        isRaising = false;
    }

    IEnumerator LowerThorn()
    {
        isLowering = true;
        yield return new WaitForSeconds(delayBeforeFall);

        Vector3 start = thorn.transform.position; // 確保從當前位置開始
        Vector3 target = originalPosition;
        float elapsedTime = 0f;

        while (elapsedTime < rise_fall_Time)
        {
            elapsedTime += Time.deltaTime;
            thorn.transform.position = Vector3.Lerp(start, target, elapsedTime / rise_fall_Time);
            yield return null;
        }

        thorn.transform.position = target;
        isLowering = false;
    }
}
