using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MC_atk : MonoBehaviour
{
    private Collider MC_Collider;
    int T1, T2 = -9;
    float attackDamage;
    public AudioSource audioSource; // 音效播放元件
    public AudioClip[] meleeSwingSounds; // 揮擊音效陣列

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume=static_parameters._SE_volue;
        Transform hitboxTransform = transform.Find("Hitbox");
        if (hitboxTransform != null)
        {
            MC_Collider = hitboxTransform.GetComponent<Collider>();
        }
    }
    // Update is called once per frame
    void Update()
    {
        attackDamage = static_parameters.MC_ATK;
        MC_Collider = GetComponent<Collider>();
        T1 = static_parameters.Ani_state;
        if (T2 == -9)
        {
            CloseCollider();
            T2 = -1;
        }
        if (T1 != T2)
        {
            skill();
            T2 = T1;
        }
    }
    void skill()
    {
        if (Input.GetKey(KeyCode.J))
        {
            switch (static_parameters.Ani_state)
            {
                case 2:
                    MC_Collider.enabled = true;
                    PlaySoundAtIndex(0);
                    melee1();
                    break;
                case 3:
                    MC_Collider.enabled = true;
                    PlaySoundAtIndex(1);
                    melee1();
                    break;
                case 4:
                    MC_Collider.enabled = true;
                    PlaySoundAtIndex(2);
                    melee2();
                    break;
            }
        }
    }
    void melee1()
    {
        Skill_public_funtion.ATK_count++;
        OpenCollider();
        Invoke("CloseCollider", 0.5f);
    }
    void melee2()
    {
        Skill_public_funtion.ATK_count++;
        CloseCollider();
        Invoke("OpenCollider", 0.3f);
        Invoke("CloseCollider", 0.7f);
    }
    public void OpenCollider()
    {
        MC_Collider.enabled = true;
    }
    public void CloseCollider()
    {
        MC_Collider.enabled = false;
    }
    private void PlaySoundAtIndex(int index)
    {
        if (meleeSwingSounds.Length > index && audioSource != null)
        {
            audioSource.PlayOneShot(meleeSwingSounds[index]);
        }
        else
        {
            Debug.LogWarning($"音效序號 {index} 超出範圍或 AudioSource 未指定");
        }
    }
}
