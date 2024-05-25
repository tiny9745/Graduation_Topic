using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Hit_box : MonoBehaviour
{
    public GameObject Player;
    void Start()
    {
        // 在 Start 方法中找到 Player 遊戲對象
        Player = GameObject.Find("Player");
        if (Player == null)
        {
            Debug.LogError("Player object not found!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Player != null)
        {
            // 獲取目標方向
            Vector3 direction = Player.transform.position - transform.position;
            direction.y = 0; // 保持Y軸不變

            if (direction != Vector3.zero)
            {
                // 計算目標旋轉
                Quaternion targetRotation = Quaternion.LookRotation(direction);

                // 設置當前物體的旋轉
                transform.rotation = targetRotation;
            }
        }
    }
}
