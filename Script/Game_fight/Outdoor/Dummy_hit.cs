using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy_hit : MonoBehaviour
{
    
    public Dummy_ctrl npcCtrl;
    public GameObject Player;
    float NPC_ATK = 0, minus;
    void Start()
    {
        Player = GameObject.Find("Player_S");
        if (npcCtrl == null)
        {
            npcCtrl = GetComponentInParent<Dummy_ctrl>();
        }
    }

    void Update()
    {
        if (npcCtrl != null) NPC_ATK = npcCtrl.GetDummy_ATK();
        if (Player != null)
        {
            Vector3 direction = Player.transform.position - transform.position;
            direction.y = 0;
            if (direction != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = targetRotation;
            }
        }
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
