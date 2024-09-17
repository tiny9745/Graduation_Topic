using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC01_effect : MonoBehaviour
{
    public int Pcounter = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("MC_Att"))
        {
            if (Pcounter < 5){
                Pcounter++;
                print(Pcounter);
            }else{
                Pcounter = 0;
            }
        }

    }
    //              
}
