using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class AI_Baking_obstacle : MonoBehaviour
{
    [SerializeField]
    public NavMeshSurface surface;
    public GameObject prefabToSpawn;
    float obstach_postion_minX = -25f;
    float obstach_postion_maxX = 25f;
    float obstach_postion_minZ = -25f;
    float obstach_postion_maxZ = 25f;
    float randomX;
    float randomZ;
    int obstach_ramdom;
    int i;

    void Start()
    {
        obstach_ramdom = Random.Range(4, 9);
        Debug.Log("obstach_ramdom:" + obstach_ramdom);
        for (i = 0; i < obstach_ramdom; i++)
        {
            // Randomly generate positions within range
            randomX = Random.Range(obstach_postion_minX, obstach_postion_maxX);
            randomZ = Random.Range(obstach_postion_minZ, obstach_postion_maxZ);
            Generateobstach(new Vector3(randomX, 0f, randomZ));
        }
        // Ensure the NavMeshSurface is ready to build the NavMesh
        surface.BuildNavMesh();
    }

    void Generateobstach(Vector3 position)
    {
        // Generate the prefab and place it at the generated location
        Instantiate(prefabToSpawn, position, Quaternion.identity);
    }
}
