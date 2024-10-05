using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI.Navigation;

public class Updata_Baking_Nav : MonoBehaviour
{
    public NavMeshSurface surface;
    bool BuildNavMesh_open = true;
    public GameObject player_S;
    // Start is called before the first frame update
    void Start()
    {
        player_S = GameObject.Find("Player_S");
        Vector3 startPos = new Vector3(0, 0, -65);
        player_S.transform.position = startPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (BuildNavMesh_open)
        {
            BuildNavMesh_open = false;
            Invoke("BuildNavMesh", 0.15f);
        }
    }

    void BuildNavMesh()
    {
        surface.BuildNavMesh();
    }
}
