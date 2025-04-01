using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class Scence_FU_241130 : MonoBehaviour
{
    public GameObject[] FU;
    private GameObject player_S;
    private NavMeshAgent playerAgent;
    void Start()
    {
        player_S = GameObject.Find("Player_S");
        playerAgent = player_S.GetComponent<NavMeshAgent>();
        player_S.transform.localPosition = new Vector3(0, 0, -140);
        Debug.Log("transform.localPosition: " + player_S.transform.localPosition);
        playerAgent.enabled = true;
        Fight_FU();
    }

    public void Fight_FU()
    {
        if (static_parameters.into_gameFight_Levels >= 3) Generatescence(FU[static_parameters.into_gameFight_Levels], new Vector3(0, 0, -45));
        else Generatescence(FU[static_parameters.into_gameFight_Levels], new Vector3(0, 0, -45));
        // else Generatescence(FU[static_parameters.into_gameFight_Levels], new Vector3(0, 0, 0));
    }

    void Generatescence(GameObject scence, Vector3 position)
    {
        GameObject fight_scence = Instantiate(scence, position, Quaternion.identity, transform);
    }
}
