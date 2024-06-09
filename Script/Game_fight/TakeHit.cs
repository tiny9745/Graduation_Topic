using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeHit : MonoBehaviour
{
    public NPC01_control NPC01;
    public NPC02_control NPC02;
    int npc_health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int damage){
        npc_health -= damage;
        print(npc_health);
    }
}
