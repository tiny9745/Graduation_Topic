using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb_Berry : MonoBehaviour
{
    int berry = 3;
    bool isExplode = false;
    float explode_time_max = 3, timmer = 0;
    private int lastChildCount, startChildCount; // 上一次檢查時的子物件數量
    public SpriteRenderer[] spriteRenderer;
    private HashSet<GameObject> objectsInRange = new HashSet<GameObject>();
    public SphereCollider bomb_hitbox;
    public Animator animator_ready;
    public Animator animator_bomb;
    void Start()
    {
        // 紀錄初始子物件數量
        startChildCount = transform.childCount;
        lastChildCount = transform.childCount;
        berry = lastChildCount;
    }

    void Update()
    {
        if (isExplode)
        {
            timmer += Time.deltaTime;
            if (berry == 0 && timmer < explode_time_max)
            {
                animator_ready.SetBool("ani_bool_ready", false);
                for (int i = 0; i < lastChildCount; i++)
                {
                    if (spriteRenderer[i] != null)
                    {
                        // 取得當前顏色
                        Color color = spriteRenderer[i].color;
                        // 修改透明度
                        color.r = 1;
                        color.g = 1;
                        color.b = 1;
                        // 將修改後的顏色賦值回去
                        spriteRenderer[i].color = color;
                    }
                }
                isExplode = false;
            }
        }
        // 檢測子物件變化
        CheckChildObjects();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (berry != 0 && (other.tag == "Player") || (other.tag == "NPC"))
        {
            objectsInRange.Add(other.gameObject);
            if (timmer < explode_time_max && objectsInRange.Count == 1)
            {
                animator_ready.SetBool("ani_bool_ready", true);
                Debug.Log("Berry ready to explode");
                isExplode = true;
                for (int i = 0; i < startChildCount - 3; i++)
                {
                    if (spriteRenderer[i] != null)
                    {
                        // 取得當前顏色
                        Color color = spriteRenderer[i].color;

                        // 修改透明度
                        color.r = 1;
                        color.g = 0;
                        color.b = 0;
                        // 將修改後的顏色賦值回去
                        spriteRenderer[i].color = color;
                    }
                }
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (berry != 0 && (other.tag == "Player") || (other.tag == "NPC"))
        {
            if (timmer > explode_time_max && isExplode)
            {
                isExplode = false;
                Bomb_Berry_Explode(other);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (berry != 0 && (other.tag == "Player") || (other.tag == "NPC"))
        {
            objectsInRange.Remove(other.gameObject);
            if (objectsInRange.Count == 0)
            {
                animator_ready.SetBool("ani_bool_ready", false);
                isExplode = false;
                timmer = 0;
                for (int i = 0; i < startChildCount - 3; i++)
                {
                    if (spriteRenderer[i] != null)
                    {
                        // 取得當前顏色
                        Color color = spriteRenderer[i].color;

                        // 修改透明度
                        color.r = 1;
                        color.g = 1;
                        color.b = 1;
                        // 將修改後的顏色賦值回去
                        spriteRenderer[i].color = color;
                    }
                }
            }
        }
    }

    private void Bomb_Berry_Explode(Collider other)
    {
        if (berry != 0)
        {
            animator_bomb.SetBool("BOOMFX_bomb", true);
            NPC_interactive.berry = berry;
            if (bomb_hitbox != null)
            {
                bomb_hitbox.enabled = true;
            }
            if (other.tag == "Player")
            {
                static_parameters.MC_HP -= 10 * berry;
            }
            Destroy(gameObject, 1.1f);
        }
    }

    private void CheckChildObjects()
    {
        int currentChildCount = transform.childCount;

        // 如果子物件數量減少，調整 berry
        if (currentChildCount < lastChildCount)
        {
            berry--;
            // 確保 berry 不低於 0
            berry = Mathf.Max(berry, 0);
            Debug.Log($"當前 berry: {berry}");
        }
        // 更新最後的子物件數量
        lastChildCount = currentChildCount;
    }
}
