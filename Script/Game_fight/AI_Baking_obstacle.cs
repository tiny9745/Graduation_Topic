using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using Unity.VisualScripting.Antlr3.Runtime.Tree;

public class AI_Baking_obstacle : MonoBehaviour
{
    [SerializeField]
    public NavMeshSurface surface;
    public GameObject[] Scenes_object_obstacle;
    public GameObject[] Scenes_object_decorate;
    float obstach_postion_minX = -50f;
    float obstach_postion_maxX = 50f;
    float obstach_postion_minZ = -50f;
    float obstach_postion_maxZ = 50f;
    float randomX;
    float randomZ;
    int obstach_random_obstacle;
    int types_random_obstacle;
    int obstach_random_decorate;
    int types_random_decorate;
    int i;

    void Start()
    {
        obstach_random_obstacle = Random.Range(6, 13);
        for (i = 0; i < obstach_random_obstacle; i++)
        {
            types_random_obstacle = Random.Range(0, 10);
            // Randomly generate positions within range
            randomX = Random.Range(obstach_postion_minX, obstach_postion_maxX);
            randomZ = Random.Range(obstach_postion_minZ, obstach_postion_maxZ);
            Generateobstach(new Vector3(randomX, Scenes_object_obstacle[types_random_obstacle].transform.position.y, randomZ));
        }
        obstach_random_decorate = Random.Range(16, 25);
        for (i = 0; i < obstach_random_decorate; i++)
        {
            types_random_decorate = Random.Range(0, 26);
            randomX = Random.Range(obstach_postion_minX, obstach_postion_maxX);
            randomZ = Random.Range(obstach_postion_minZ, obstach_postion_maxZ);
            Generateobstach2(new Vector3(randomX, Scenes_object_decorate[types_random_decorate].transform.position.y, randomZ));
        }
        Invoke("wait_build", .2f);
    }

    void wait_build()
    {
        // Ensure the NavMeshSurface is ready to build the NavMesh
        surface.BuildNavMesh();
    }

    void Generateobstach(Vector3 position)
    {
        // Generate the prefab and place it at the generated location
        Instantiate(Scenes_object_obstacle[types_random_obstacle], position, Quaternion.identity);
    }
    void Generateobstach2(Vector3 position)
    {
        Instantiate(Scenes_object_decorate[types_random_decorate], position, Quaternion.identity);
    }
}