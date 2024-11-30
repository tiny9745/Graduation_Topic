using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb_Berry : MonoBehaviour
{
    // Start is called before the first frame update
    int berry = 3;
    bool isExplode = false;
    float explode_time = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isExplode)
        {
            explode_time += Time.deltaTime;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(berry!=0) 
        {
            isExplode = true;
            if (explode_time > 2) Bomb_Berry_Explode(other); 
        }
    }

    private void Bomb_Berry_Explode(Collider other)
    {
        if (other.tag == "Player")
        {
            static_parameters.MC_HP -= 10 * berry;
        }
        if (other.name == "請改成在NPC方面程式碼_Bomb_Berry")
        {
            
        }
    }
}
