using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeHit : MonoBehaviour
{
    float S1, S2 = -1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(float damage){
        S1 = damage;
        if(S1 != S2){           
            S2 = S1;
        }
    }
}
