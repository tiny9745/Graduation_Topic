using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MC_atk : MonoBehaviour
{
    private Collider MC_Collider;
    short T1, T2 = -9;
    float attackDamage;

    // Start is called before the first frame update
    void Start()
    {
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
                    melee1();
                    break;
                case 3:
                    MC_Collider.enabled = true;
                    melee1();
                    break;
                case 4:
                    ;
                    MC_Collider.enabled = true;
                    melee2();
                    break;
            }
        }
        if (Input.GetKeyDown(KeyCode.K))
        {

        }
    }
    void melee1()
    {
        Skill_public_funtion.ATK_count++;//skill
        // Debug.Log("ATK_count:" + Skill_public_funtion.ATK_count);
        // Debug.Log("blood_deduction_NPC_count" + Skill_public_funtion.blood_deduction_NPC_count);
        OpenCollider();
        Invoke("CloseCollider", 0.6f);
    }
    void melee2()
    {
        Skill_public_funtion.ATK_count++;//skill
        // Debug.Log("ATK_count:" + Skill_public_funtion.ATK_count);
        // Debug.Log("blood_deduction_NPC_count" + Skill_public_funtion.blood_deduction_NPC_count);
        CloseCollider();
        Invoke("OpenCollider", 0.2f);
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

}
