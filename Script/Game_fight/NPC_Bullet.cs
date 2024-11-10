using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    float NPC_ATK = 0, minus;
    public Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        NPC_ATK = GetComponentInParent<NPC03_control>().GetNPC03_ATK();
        rb.velocity = transform.forward * 10;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider Hit)
    {
        if (Hit.gameObject.CompareTag("Player"))
        {
            if (!static_parameters.invincible)
            {
                minus = (float)(NPC_ATK * NPC_ATK / (static_parameters.MC_DEF + NPC_ATK));
                if (minus < 5) minus = 5.0f;
                static_parameters.MC_HP -= minus;
                this.enabled = false;
            }
        }
    }
}
