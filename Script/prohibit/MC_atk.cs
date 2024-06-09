using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MC_atk : MonoBehaviour
{
    private Collider MC_Collider;
    public TakeHit NPChit;
    int attackDamage;

    // Start is called before the first frame update
    void Start()
    {
        Transform Collider = transform.Find("Hitbox");
        MC_Collider = Collider.GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        attackDamage=static_parameters.MC_ATK;
        MC_Collider = GetComponent<Collider>();
        skill();
    }
    void skill(){
        if (Input.GetKeyDown(KeyCode.J)){

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
    public void OpenCollider(){
        MC_Collider.enabled = true;
    }
    public void CloseCollider(){
        MC_Collider.enabled = false;
    }
}
