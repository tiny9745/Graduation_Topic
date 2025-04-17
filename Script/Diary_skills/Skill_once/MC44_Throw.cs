using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MC44_Throw : MonoBehaviour
{
    public GameObject throw_obj;
    // Start is called before the first frame update
    private float re_blood = static_parameters.MC_HP_Max / 12;
    void Start()
    {
        static_parameters.MC_HP += re_blood;
        if (static_parameters.MC_HP > static_parameters.MC_HP_Max)
        {
            static_parameters.MC_HP = static_parameters.MC_HP_Max;
        }
        Destroy(throw_obj);
    }
}
