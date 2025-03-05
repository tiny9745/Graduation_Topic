using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC03_Hit_box : MonoBehaviour
{
    public NPC03_control npcCtrl;
    public NPC_effect_03 effect;
    public GameObject Player;
    float NPC_ATK = 0, minus;
    void Start()
    {
        if (Player == null)
        {
            Player = GameObject.Find("Player_S");
        }
        if (npcCtrl == null)
        {
            npcCtrl = GetComponentInParent<NPC03_control>();
        }
    }
    
    void Update()
    {
        if (npcCtrl != null) NPC_ATK = npcCtrl.GetNPC03_ATK();
        if (Player != null)
        {
            transform.LookAt(Player.transform.position);
        }
    }
    private void OnTriggerEnter(Collider Hit)
    {
        if (Hit.gameObject.CompareTag("Player"))
        {
            if (!static_parameters.invincible)
            {
                effect.fight_instinct_MC();
                minus = (float)(NPC_ATK * NPC_ATK / (static_parameters.MC_DEF + NPC_ATK));
                if (minus < 5) minus = 5.0f;
                static_parameters.MC_HP -= minus;
                gameObject.SetActive(false);
            }
        }
    }
}
