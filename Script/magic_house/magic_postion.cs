using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magic_postion : MonoBehaviour
{
    public GameObject player;
    public GameObject player_S;

    public Vector3 minBoundary; // Define the minimum boundary
    public Vector3 maxBoundary; // Define the maximum boundary
    public Vector3 startPos = new Vector3(0, 0, -8);
    public float padding_X_min = -29f, padding_X_max = 29f;
    public float padding_Z_min = 0f, padding_Z_max = 49f;

    void Start()
    {
        ResetPlayerPosition();
    }
    void Update()
    {
        if (player.transform.position.x > padding_X_max || player.transform.position.x < padding_X_min || player.transform.position.z > padding_Z_max || player.transform.position.z < padding_Z_min)
        {
            ClampPlayerPosition();
        }
    }

    void ResetPlayerPosition()
    {
        player = GameObject.Find("Player");
        player_S = GameObject.Find("Player_S");
        player_S.transform.position = startPos;
        player.transform.position = startPos;
    }
    void ClampPlayerPosition()
    {
        player.transform.position = new Vector3(
            Mathf.Clamp(player.transform.position.x, padding_X_min, padding_X_max),
            Mathf.Clamp(player.transform.position.y, minBoundary.y, maxBoundary.y),
            Mathf.Clamp(player.transform.position.z, padding_Z_min, padding_Z_max)
        );
    }
}
