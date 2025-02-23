using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC01_Hit_box : MonoBehaviour
{
    public NPC01_control npcCtrl;
    public NPC01_effect effect;
    public GameObject Player;
    float NPC_ATK = 0; float minus;
    void Start()
    {
        if (Player == null)
        {
            Player = GameObject.Find("Player");
        }
        if (npcCtrl == null)
        {
            npcCtrl = GetComponentInParent<NPC01_control>();
        }
    }

    void Update()
    {
        if (npcCtrl != null) NPC_ATK = npcCtrl.GetNPC01_ATK();
        if (Player != null)
        {
            transform.LookAt(Player.transform.position);
        }
    }
    private void OnTriggerEnter(Collider Hit)
    {
        if (Hit.gameObject.CompareTag("Player"))
        {
            Damage();
            gameObject.SetActive(false);
        }
    }
    void Damage()
    {
        if (!static_parameters.invincible)
        {
            effect.fight_instinct_MC();
            minus = (int)(NPC_ATK * NPC_ATK / (static_parameters.MC_DEF + NPC_ATK));
            if (minus < 5) minus = 5.0f;
            static_parameters.MC_HP -= minus;
        }
    }
}
