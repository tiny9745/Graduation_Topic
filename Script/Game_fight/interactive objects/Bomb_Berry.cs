using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb_Berry : MonoBehaviour
{
    public int berry = 1;
    public int lastChildCount, startChildCount; // 上一次檢查時的子物件數量
    public AudioSource berry_take_sound;
    void Start()
    {
        // 紀錄初始子物件數量
        startChildCount = 1;
        lastChildCount = 1;
        berry = lastChildCount;
    }

    void Update()
    {
        // 檢測子物件變化
        CheckChildObjects();
    }

    private void CheckChildObjects()
    {
        int currentChildCount = transform.childCount;

        // 如果子物件數量減少，調整 berry
        if (currentChildCount < lastChildCount)
        {
            berry_take_sound.PlayOneShot(berry_take_sound.clip);
            berry--;
            // 確保 berry 不低於 0
            berry = Mathf.Max(berry, 0);
            Debug.Log($"當前 berry: {berry}");
        }
        // 更新最後的子物件數量
        lastChildCount = currentChildCount;
    }

    public void Destroy_Berry()
    {
        gameObject.SetActive(false);
        Destroy(gameObject, 1.1f);
    }
}
