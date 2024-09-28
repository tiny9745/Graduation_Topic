using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI.Navigation;

public class Updata_Baking_Nav : MonoBehaviour
{
    public NavMeshSurface surface;
    bool BuildNavMesh_open = true;
    // Start is called before the first frame update
    void Start()
    {

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
