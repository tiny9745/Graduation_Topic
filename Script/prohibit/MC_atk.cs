using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MC_atk : MonoBehaviour
{
    private Collider MC_Collider;
    public TakeHit NPChit;
    short T1,T2=-1;
    int attackDamage;

    // Start is called before the first frame update
    void Start()
    {
        Transform hitboxTransform = transform.Find("Hitbox");
        if (hitboxTransform != null){
            MC_Collider = hitboxTransform.GetComponent<Collider>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        attackDamage = static_parameters.MC_ATK;
        MC_Collider = GetComponent<Collider>();
        T1 = static_parameters.Attactstate;
        if (T1!=T2){
            skill();
            T2 = T1;
        }
    }
    void skill(){
        if (Input.GetKey(KeyCode.J)){
            switch (static_parameters.Attactstate){
                case 1:
                    MC_Collider.enabled = true;
                    melee1();
                    break;
                case 2:
                    MC_Collider.enabled = true;
                    melee1();
                    break;
                case 3:;
                    MC_Collider.enabled = true;
                    melee2();
                    break;
            }
        }
        if (Input.GetKeyDown(KeyCode.K)){

        }
    }
    private void OnTriggerEnter(Collider hit)
    {
        if (hit.CompareTag("NPC")){
            NPChit = hit.GetComponent<TakeHit>();
                if (NPChit != null){
                    print(NPChit);
                    NPChit.TakeDamage(attackDamage);
                }
        }
    }
    void melee1(){
        OpenCollider();
        Invoke("CloseCollider", 0.5f);
    }
    void melee2(){
        CloseCollider();
        Invoke("OpenCollider", 0.2f);
        Invoke("CloseCollider", 0.7f);
    }
    public void OpenCollider(){
        MC_Collider.enabled = true;
    }
    public void CloseCollider(){
        MC_Collider.enabled = false;
    }
    
}
