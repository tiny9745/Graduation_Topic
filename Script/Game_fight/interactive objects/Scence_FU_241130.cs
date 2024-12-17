using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class Scence_FU_241130 : MonoBehaviour
{
    public GameObject[] FU;
    private GameObject player_S;
    private Vector3 startPos = new Vector3(0, 138, -8);
    int scence_random;
    private NavMeshAgent playerAgent;
    void Start()
    {
        player_S = GameObject.Find("Player_S");
        playerAgent = player_S.GetComponent<NavMeshAgent>();
        startPos = player_S.transform.position;
        playerAgent.enabled = true;
        // switch (static_parameters.stage_number_Boss){}
        Fight_FU();
    }

    public void Fight_FU()
    {
        // static_parameters.Map_start = scence_random;
        Generatescence(FU[scence_random], new Vector3(0, 0, 0));
        startPos.z = -138;
        player_S.transform.position = startPos;
    }

    void Generatescence(GameObject scence, Vector3 position)
    {
        GameObject fight_scence = Instantiate(scence, position, Quaternion.identity, transform);
    }
}
