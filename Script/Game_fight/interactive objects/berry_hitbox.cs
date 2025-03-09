using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class berry_hitbox : MonoBehaviour
{
    public Bomb_Berry bomb_berry;
    bool isExplode = false;
    float explode_time_max = 3, timmer = 0;
    public SpriteRenderer[] spriteRenderer;
    private HashSet<GameObject> objectsInRange = new HashSet<GameObject>();
    public SphereCollider bomb_hitbox;
    public Animator animator_ready;
    public GameObject berry_bomb;
    private bool isExplode_start = false;

    void Update()
    {
        if (spriteRenderer == null || spriteRenderer.Length == 0)
        {
            Debug.LogError("spriteRenderer 陣列未初始化或為空！");
            return;
        }
        if (isExplode)
        {
            timmer += Time.deltaTime;

            if (bomb_berry.berry == 0 && timmer < explode_time_max)
            {
                animator_ready.SetBool("ani_bool_ready", false);
                for (int i = 0; i < bomb_berry.lastChildCount; i++)
                {
                    if (spriteRenderer[i] != null)
                    {
                        Color color = spriteRenderer[i].color;
                        color.r = 1;
                        color.g = 1;
                        color.b = 1;
                        spriteRenderer[i].color = color;
                    }
                }
                isExplode = false;
            }

            // **檢查是否達到爆炸時間**
            if (timmer >= explode_time_max)
            {
                Debug.Log("Berry explode00");
                isExplode = false;

                // **觸發爆炸（即使 Player 已經離開範圍，仍會爆炸）**
                Bomb_Berry_Explode();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (bomb_berry.berry != 0 && (other.CompareTag("Player") || other.CompareTag("NPC")))
        {
            Debug.Log("Berry in range: " + bomb_berry.berry);

            // 確保不重複加入
            if (!objectsInRange.Contains(other.gameObject))
            {
                objectsInRange.Add(other.gameObject);
            }

            if (timmer < explode_time_max && objectsInRange.Count == 1)
            {
                animator_ready.SetBool("ani_bool_ready", true);
                Debug.Log("Berry ready to explode");
                isExplode = true;
                timmer = 0;

                for (int i = 0; i < bomb_berry.startChildCount - 3; i++)
                {
                    if (spriteRenderer[i] != null)
                    {
                        Color color = spriteRenderer[i].color;
                        color.r = 1;
                        color.g = 0;
                        color.b = 0;
                        spriteRenderer[i].color = color;
                    }
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // 記錄離開範圍的物件
        if (objectsInRange.Contains(other.gameObject))
        {
            Debug.Log(other.name + " 離開範圍");
            objectsInRange.Remove(other.gameObject);
        }
    }

    private void Bomb_Berry_Explode()
    {
        if (bomb_berry.berry != 0)
        {
            Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
            Debug.Log("Berry Explode");
            Instantiate(berry_bomb, pos, transform.rotation);
            NPC_interactive.berry = bomb_berry.berry;

            GameObject playerInRange = null;
            foreach (GameObject obj in objectsInRange)
            {
                if (obj.CompareTag("Player"))
                {
                    playerInRange = obj;
                    break;  // 找到 Player 後就中斷迴圈
                }
            }

            if (playerInRange != null)
            {
                Debug.Log("爆炸傷害觸發 Player：" + playerInRange.name);
                static_parameters.MC_HP -= 10 * bomb_berry.berry;
            }

            bomb_berry.Destroy_Berry();
        }
    }
}
