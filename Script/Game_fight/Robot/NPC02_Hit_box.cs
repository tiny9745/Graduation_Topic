using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC02_Hit_box : MonoBehaviour
{
    public NPC02_control npcCtrl;
    public GameObject Player;
    int NPC_ATK = 0;
    public float coordinate_X = 0;
    public float coordinate_Z = 0;
    void Start(){
        Player = GameObject.Find("Player");
        if (Player == null){
            Debug.LogError("Player object not found!");
        }
        if (npcCtrl == null){
            npcCtrl = GetComponentInParent<NPC02_control>();
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (npcCtrl != null) NPC_ATK = npcCtrl.getNPC02_ATK();   
        if (Player != null){
            // Get target direction
            Vector3 direction = Player.transform.position - transform.position;
            direction.y = 0;
            if (direction != Vector3.zero){
                // target rotation
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = targetRotation;
            }
            coordinate_X = direction.x;
            coordinate_Z = direction.z;
        }
    }
    private void OnTriggerEnter(Collider Hit){
        //NPC attack determination
        if (Hit.gameObject.CompareTag("Player")){
            static_parameters.MC_HP -= NPC_ATK;
            print("Player_HP=" + static_parameters.MC_HP);
        }      
    }
    
}
