using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magic_postion : MonoBehaviour
{
    // public GameObject player;
    public GameObject player_S;

    public Vector3 minBoundary; // Define the minimum boundary
    public Vector3 maxBoundary; // Define the maximum boundary
    public Vector3 startPos = new Vector3(0, 0, -8);
    public float padding_X_min = -29f, padding_X_max = 29f;
    public float padding_Z_min = 0f, padding_Z_max = 49f;

    void Start()
    {
        static_parameters.MC_HP = static_parameters.MC_HP_Max;
        static_parameters.into_gameFight = false;
        ResetPlayerPosition();
    }
    void Update()
    {
        if (player_S.transform.position.x > padding_X_max || player_S.transform.position.x < padding_X_min || player_S.transform.position.z > padding_Z_max || player_S.transform.position.z < padding_Z_min)
        {
            ClampPlayerPosition();
        }
    }

    void ResetPlayerPosition()
    {
        player_S = GameObject.Find("Player_S");
        player_S.transform.position = startPos;
    }
    void ClampPlayerPosition()
    {
        player_S.transform.position = new Vector3(
            Mathf.Clamp(player_S.transform.position.x, padding_X_min, padding_X_max),
            Mathf.Clamp(player_S.transform.position.y, minBoundary.y, maxBoundary.y),
            Mathf.Clamp(player_S.transform.position.z, padding_Z_min, padding_Z_max)
        );
    }
}
