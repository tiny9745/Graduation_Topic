using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy_hit : MonoBehaviour
{
    public Dummy_ctrl npcCtrl;
    public GameObject Player;
    float NPC_ATK = 0, minus;
    // Start is called before the first frame update
    void Start()
    {
     if (npcCtrl == null)
        {
            npcCtrl = GetComponentInParent<Dummy_ctrl>();
        }   
    }

    // Update is called once per frame
    void Update()
    {
        //if (npcCtrl != null) NPC_ATK = npcCtrl.GetNPC03_ATK();

    }

    private void OnTriggerEnter(Collider Hit)
    {
        if (Hit.gameObject.CompareTag("Player"))
        {
            if (!static_parameters.invincible)
            {
                minus = (float)(NPC_ATK * NPC_ATK / (static_parameters.MC_DEF + NPC_ATK));
                if (minus < 5) minus = 5.0f;
                static_parameters.MC_HP -= 1.0f;
                this.enabled = false;
            }
        }
    }
}
