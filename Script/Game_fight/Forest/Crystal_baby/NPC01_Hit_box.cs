using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC01_Hit_box : MonoBehaviour
{
    public NPC01_control npcCtrl;
    public GameObject Player;
    float NPC_ATK = 0; int minus;
    void Start()
    {
        Player = GameObject.Find("Player");
        if (Player == null)
        {
            Debug.LogError("Player object not found!");
        }
        if (npcCtrl == null){
            npcCtrl = GetComponentInParent<NPC01_control>();
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (npcCtrl != null) NPC_ATK = npcCtrl.GetNPC01_ATK();
        if (Player != null)
        {
            // Get target direction
            Vector3 direction = Player.transform.position - transform.position;
            direction.y = 0;
            if (direction != Vector3.zero)
            {
                // target rotation
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = targetRotation;
            }
        }
    }
    private void OnTriggerEnter(Collider Hit)
    {
        //NPC attack determination
        if (Hit.gameObject.CompareTag("Player"))
        {
            Damage();
            this.enabled = false;
        }
    }
    void Damage()
    {
        minus = (int)(NPC_ATK*NPC_ATK-(static_parameters.MC_DEF+NPC_ATK));
        if (minus < 5) minus = 5;
        static_parameters.MC_HP -= minus;
    }
}
