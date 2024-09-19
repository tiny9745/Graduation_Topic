using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Dummy_ctrl : MonoBehaviour
{
    //public Animator animator;
    public int DetectDistance = 15; public float Dummy_ATK = 15; public float Dummy_DEF = 15;
    public float NPC_HP_Max = 150;// public float npcSpeed = 6f;
    public float NPC_HP;
    //float dist;
    private float damageCooldown = 1.0f, nextDamageTime = 0.0f;
    bool hit_Ani, hit = false, hitbox = true;
    //private Vector3 lastPosition;
    //private Quaternion initialRotation;
    public GameObject Dummy;
    public GameObject Hitbox;
    //public GameObject Drop;
    //bool dead_open = true;
    bool MC_to_Att = true;
    public Dummy_HP nPC_hP;
    //public GameObject Img_npc;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (NPC_HP > 0 && Time.time >= nextDamageTime)
        {
            if (NPC_HP > 0)
            {
                if (other.gameObject.tag == "Player")
                {
                    if (hitbox)
                    {
                        hit_Ani = true;
                        Invoke("EnableHitbox", 1.1f);
                        hitbox = false;
                    }
                }
                if (other.gameObject.CompareTag("MC_Att") && MC_to_Att)
                {
                    if (nPC_hP == null)
                    {
                        Debug.LogError("nPC_hP is not assigned.");
                        return;
                    }
                    nPC_hP.TakeDamage(static_parameters.MC_ATK, Dummy_DEF);
                    MC_to_Att = false;
                    Invoke("wait_MC_att", 0.2f);
                    nextDamageTime = Time.time + damageCooldown;
                }
            }
        }
    }

    void EnableHitbox()
    {
        Hitbox.SetActive(true);
        Invoke("closeHitbox", 0.5f);//atk time
        hit = false;
    }
    void closeHitbox()
    {
        Hitbox.SetActive(false);
        hitbox = true;
    }
}
