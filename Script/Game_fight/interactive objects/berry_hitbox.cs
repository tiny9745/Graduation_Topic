using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class berry_hitbox : MonoBehaviour
{
    public Bomb_Berry bomb_berry;
    bool isExplode = false;
    float explode_time_max = 3f, timmer = 0f;
    public SpriteRenderer[] spriteRenderer;
    private HashSet<GameObject> objectsInRange = new HashSet<GameObject>();
    public SphereCollider bomb_hitbox;
    public Animator animator_ready;
    public GameObject berry_bomb;
    public AudioSource Ad;
    public AudioClip  berry_waring_sound,berry_bomb_sound;
    void Update()
    {
        // 清除已被銷毀的物件以防止 MissingReferenceException
        objectsInRange.RemoveWhere(obj => obj == null);
        if (isExplode)
        {
            timmer += Time.deltaTime;

            // 如果 bomb_berry 已消失，就中止爆炸
            if (bomb_berry.berry == 0 && timmer < explode_time_max)
            {
                animator_ready.SetBool("ani_bool_ready", false);
                Ad.Stop();
                for (int i = 0; i < Mathf.Min(bomb_berry.lastChildCount, spriteRenderer.Length); i++)
                {
                    if (spriteRenderer[i] != null)
                    {
                        spriteRenderer[i].color = new Color(1, 1, 1, spriteRenderer[i].color.a);
                    }
                }
                isExplode = false;
            }

            // 無論範圍內是否還有物件，只要時間到就爆炸
            if (timmer >= explode_time_max)
            {
                isExplode = false;
                Bomb_Berry_Explode();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (bomb_berry.berry != 0 && (other.CompareTag("Player") || other.CompareTag("NPC")))
        {
            if (!objectsInRange.Contains(other.gameObject))
            {
                objectsInRange.Add(other.gameObject);
            }

            if (!isExplode)
            {
                animator_ready.SetBool("ani_bool_ready", true);
                Ad.clip = berry_waring_sound;
                Ad.loop = false;
                Ad.Play();
                Invoke("play", 2.33f);
                bomb_hitbox.enabled = true;
                isExplode = true;
                timmer = 0;

                for (int i = 0; i < Mathf.Min(bomb_berry.startChildCount - 3, spriteRenderer.Length); i++)
                {
                    if (spriteRenderer[i] != null)
                    {
                        spriteRenderer[i].color = new Color(1, 0, 0, spriteRenderer[i].color.a);
                    }
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (objectsInRange.Contains(other.gameObject))
        {
            objectsInRange.Remove(other.gameObject);
        }
    }

    void play(){
        Ad.PlayOneShot(berry_bomb_sound);
    }
    private void Bomb_Berry_Explode()
    {
        if (bomb_berry.berry == 0) return; // 不爆炸

        Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
        Instantiate(berry_bomb, pos, transform.rotation);
        NPC_interactive.berry = bomb_berry.berry;

        // 找尋仍存在的 Player，扣血
        foreach (GameObject obj in objectsInRange)
        {
            if (obj != null && obj.CompareTag("Player"))
            {
                static_parameters.MC_HP -= 10 * bomb_berry.berry;
                bomb_hitbox.enabled = false;
                break;
            }
        }

        bomb_berry.Destroy_Berry();
    }
}
