using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_interactive : MonoBehaviour
{
    // Start is called before the first frame update
    static public int berry = 3;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    float npc_timmer = 0;
    public void NPC_Thorns(ref float _NPC_HP)
    {
        npc_timmer += Time.deltaTime;
        if (npc_timmer >= Thorns.damage_time)
        {
            npc_timmer = 0;
            _NPC_HP -= 1;
        }
    }
    public void NPC_Bomb_Berry(ref float _NPC_HP)
    {
        _NPC_HP -= 10 * berry;
    }
    public void NPC_Swam_enter(ref float _NPC_Speed)
    {
        Debug.Log("NPC_Swam_enter");
        _NPC_Speed /= 2;
    }
    public void NPC_Swam_exit(ref float _NPC_Speed)
    {
        Debug.Log("NPC_Swam_exit");
        _NPC_Speed *= 2;
    }
}
