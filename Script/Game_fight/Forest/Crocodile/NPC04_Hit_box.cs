using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC04_Hit_box : MonoBehaviour
{
    public NPC04_control npcCtrl;
    public GameObject Player;
    float NPC_ATK = 0, minus;
    void Update()
    {
        if (Player == null)
        {
            Player = GameObject.Find("Player");
        }
        if (npcCtrl == null)
        {
            npcCtrl = GetComponentInParent<NPC04_control>();
        }
        if (npcCtrl != null) NPC_ATK = npcCtrl.GetNPC04_ATK();
        if (Player != null)
        {
            transform.LookAt(Player.transform.position);
            Debug.Log("Look at player");
            // Vector3 direction = Player.transform.position - transform.position;
            // direction.y = 0;
            // if (direction != Vector3.zero)
            // {
            //     Quaternion targetRotation = Quaternion.LookRotation(direction);
            //     transform.rotation = targetRotation;
            // }
        }
        else
        {
            Debug.Log("Player is null");
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
                Debug.Log("HP: " + static_parameters.MC_HP);
                gameObject.SetActive(false);
            }
        }
    }
}
