using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI.Navigation;
using UnityEngine.SceneManagement;

public class Updata_Baking_Nav : MonoBehaviour
{
    public NavMeshSurface surface;
    bool BuildNavMesh_open = true;
    public GameObject player_S;
    // Start is called before the first frame update

    void Start()
    {
        player_S = GameObject.Find("Player_S");
        MC_Start_position();
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
    

    private void MC_Start_position()
    {
        // Vector3 startPos = new Vector3(0, 0, -65);
        // if (SceneManager.GetActiveScene().name == "Fight_FA02")
        // {
        //     startPos = new Vector3(55, 0, -65);
        // }
        // else if (SceneManager.GetActiveScene().name == "Fight_FA04")
        // {
        //     startPos = new Vector3(-55, 0, -65);
        // }
        // else if (SceneManager.GetActiveScene().name == "Fight_FA05")
        // {
        //     startPos = new Vector3(-44, 0, -65);
        // }
        // else if (SceneManager.GetActiveScene().name == "Fight_FB03")
        // {
        //     startPos = new Vector3(-55, 0, -65);
        // }
        // else if (SceneManager.GetActiveScene().name == "Fight_FB04")
        // {
        //     startPos = new Vector3(55, 0, -65);
        // }
        // else if (SceneManager.GetActiveScene().name == "Fight_FC01")
        // {
        //     startPos = new Vector3(-36, 0, -65);
        // }
        // else if (SceneManager.GetActiveScene().name == "Fight_FC04")
        // {
        //     startPos = new Vector3(21, 0, -65);
        // }
        // player_S.transform.position = startPos;
    }
}
