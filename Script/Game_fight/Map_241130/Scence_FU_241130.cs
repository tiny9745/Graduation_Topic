using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scence_FU_241130 : MonoBehaviour
{
    public GameObject[] FU;
    int scence_random;

    void Start()
    {
        // switch (static_parameters.stage_number_Boss){}
        Fight_FU();
    }

    public void Fight_FU()
    {
        scence_random = Random.Range(0, 2);
        // static_parameters.Map_start = scence_random;
        Generatescence(FU[scence_random], new Vector3(0, 0, 0));        
    }

    void Generatescence(GameObject scence, Vector3 position)
    {
        GameObject fight_scence = Instantiate(scence, position, Quaternion.identity, transform); 
    }
}
