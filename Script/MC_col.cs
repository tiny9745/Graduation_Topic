using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MC_col : MonoBehaviour
{
    public GameObject MC;
    void Start()
    {
        MC = GameObject.Find("Player");
        Renderer renderer = MC.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.enabled = false;
        }
    }
    void Update()
    {
        // 獲取玩家的輸入
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // 計算移動方向
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // 將移動方向轉換成世界空間
        movement = transform.TransformDirection(movement);

        // 移動角色
        transform.position += movement * static_parameters.MC_Wspeed * Time.deltaTime;
    }
    //被攻擊判定
    private void OnCollisionEnter(Collision Hit)
    {
        if (Hit.gameObject.CompareTag("NPC"))
        {
            print("Player_HP=" + static_parameters.MC_HP);
            if (static_parameters.MC_HP <= 0)
            {
                static_parameters.MC_HP = 0;
                Destroy(gameObject);
            }
        }
        else
        {
            Debug.LogWarning("找不到對應組件");
        }
        //攻擊的判定位於武器類別的tag偵測上
    }
}
