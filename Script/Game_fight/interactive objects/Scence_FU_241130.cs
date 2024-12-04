using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scence_FU_241130 : MonoBehaviour
{
    public GameObject[] FU;
    private GameObject player_S;
    private Vector3 startPos = new Vector3(0, 0, -8);
    int scence_random;

    void Start()
    {
        player_S = GameObject.Find("Player_S");
        startPos = player_S.transform.position;
        // switch (static_parameters.stage_number_Boss){}
        Fight_FU();
    }

    public void Fight_FU()
    {
        scence_random = Random.Range(0, 1);
        // static_parameters.Map_start = scence_random;
        Generatescence(FU[scence_random], new Vector3(0, 0, 0));
        switch (scence_random)
        {
            case 0:
                startPos.z = -138;
                break;
            case 1:
                startPos.z = -138;
                break;
            case 2:
                startPos.z = -138;
                break;
            case 3:
                startPos.z = -138;
                break;
            case 4:
                startPos.z = -138;
                break;
            default:
                break;
        }
        player_S.transform.position = startPos;
    }

    void Generatescence(GameObject scence, Vector3 position)
    {
        GameObject fight_scence = Instantiate(scence, position, Quaternion.identity, transform);
    }
}
