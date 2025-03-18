using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class Scence_FU_241130 : MonoBehaviour
{
    public GameObject[] FU;
    private GameObject player_S;
    int scence_random;
    private NavMeshAgent playerAgent;
    void Start()
    {
        player_S = GameObject.Find("Player_S");
        playerAgent = player_S.GetComponent<NavMeshAgent>();
        player_S.transform.localPosition = new Vector3(0, 0, -138);
        Debug.Log("transform.localPosition: " + player_S.transform.localPosition);
        playerAgent.enabled = true;
        // switch (static_parameters.stage_number_Boss){}
        Fight_FU();
    }

    public void Fight_FU()
    {
        // scence_random = Random.Range(0, 5);
        // Generatescence(FU[scence_random], new Vector3(0, 0, 0));
        if (static_parameters.stage_number < 5) Generatescence(FU[static_parameters.stage_number - 1], new Vector3(0, 0, 0));
        else Generatescence(FU[static_parameters.stage_number - 1], new Vector3(0, 0, -40));
        // Generatescence(FU[3], new Vector3(0, 0, 0));
    }

    void Generatescence(GameObject scence, Vector3 position)
    {
        GameObject fight_scence = Instantiate(scence, position, Quaternion.identity, transform);
    }
}
