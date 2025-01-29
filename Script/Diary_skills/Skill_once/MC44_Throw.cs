using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MC44_Throw : MonoBehaviour
{
    // Start is called before the first frame update
    public int re_blood = 20;
    void Start()
    {
        static_parameters.MC_HP += re_blood;
        if (static_parameters.MC_HP > static_parameters.MC_HP_Max)
        {
            static_parameters.MC_HP = static_parameters.MC_HP_Max;
        }
        Destroy(this);
    }
}
