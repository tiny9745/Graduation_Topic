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
    }

    private void OnTriggerEnter(Collider other)
    {
        if (bomb_berry.berry != 0 && (other.tag == "Player") || (other.tag == "NPC"))
        {
            Debug.Log("Berry in range: " + bomb_berry.berry);
            objectsInRange.Add(other.gameObject);
            if (timmer < explode_time_max && objectsInRange.Count == 1)
            {
                animator_ready.SetBool("ani_bool_ready", true);
                Debug.Log("Berry ready to explode");
                isExplode = true;
                for (int i = 0; i < bomb_berry.startChildCount - 3; i++)
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

            //移至update
            if (timmer > explode_time_max && isExplode)
            {
                Debug.Log("Berry explode00");
                isExplode = false;
                Bomb_Berry_Explode(other);
            }
        }
    }

    // private void OnTriggerStay(Collider other)
    // {
    //     if (bomb_berry.berry != 0 && (other.tag == "Player") || (other.tag == "NPC"))
    //     {
    //         if (timmer > explode_time_max && isExplode)
    //         {
    //             isExplode = false;
    //             Bomb_Berry_Explode(other);
    //         }
    //     }
    // }

    // private void OnTriggerExit(Collider other)
    // {
    //     if (berry != 0 && (other.tag == "Player") || (other.tag == "NPC"))
    //     {
    //         objectsInRange.Remove(other.gameObject);
    //         if (objectsInRange.Count == 0)
    //         {
    //             animator_ready.SetBool("ani_bool_ready", false);
    //             isExplode = false;
    //             timmer = 0;
    //             for (int i = 0; i < startChildCount - 3; i++)
    //             {
    //                 if (spriteRenderer[i] != null)
    //                 {
    //                     // 取得當前顏色
    //                     Color color = spriteRenderer[i].color;

    //                     // 修改透明度
    //                     color.r = 1;
    //                     color.g = 1;
    //                     color.b = 1;
    //                     // 將修改後的顏色賦值回去
    //                     spriteRenderer[i].color = color;
    //                 }
    //             }
    //         }
    //     }
    // }

    private void Bomb_Berry_Explode(Collider other)
    {
        if (bomb_berry.berry != 0)
        {
            Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
            Debug.Log("Berry Explode");
            Instantiate(berry_bomb, pos, transform.rotation);
            NPC_interactive.berry = bomb_berry.berry;
            // if (bomb_hitbox != null)
            // {
            //     bomb_hitbox.enabled = true;
            // }
            if (other.tag == "Player")
            {
                static_parameters.MC_HP -= 10 * bomb_berry.berry;
            }
            bomb_berry.Destroy_Berry();
        }
    }
}
