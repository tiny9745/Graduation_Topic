using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class AI_Baking_obstacle : MonoBehaviour
{
    [SerializeField]
    public NavMeshSurface surface;
    public GameObject[] Scenes_object_obstacle;
    public GameObject[] Scenes_object_decorate;
    public GameObject[] Scenes_object_obstacle_outside_big;
    public GameObject[] Scenes_object_obstacle_outside_small;
    // Reference to the RandomTileGround component
    public RandomTileGround randomTileGround;

    // Variables to hold range values based on RandomTileGround
    float obstach_postion_minX = -50f;
    float obstach_postion_maxX = 50f;
    float obstach_postion_minZ = -50f;
    float obstach_postion_maxZ = 50f;

    float randomX;
    float randomZ;
    int types_random_inside_obstacle;
    int types_random_inside_decorate;
    int types_random_outside_small;
    int types_random_outside_big;
    int obstach_random;

    bool randomTileGround_found = false;

    void Start()
    {
        
    }
    void Update()
    {
        if (randomTileGround_found == false)InitializeObstacleRanges();
    }

    void InitializeObstacleRanges()
    {
        // Ensure randomTileGround is assigned
        if (randomTileGround != null)
        {
            obstach_postion_minX = randomTileGround.minBoundary.x + randomTileGround.padding_X_min;
            obstach_postion_maxX = randomTileGround.maxBoundary.x - randomTileGround.padding_X_max;
            obstach_postion_minZ = randomTileGround.minBoundary.z + randomTileGround.padding_Z_min;
            obstach_postion_maxZ = randomTileGround.maxBoundary.z - randomTileGround.padding_Z_max;
            randomTileGround_found = true;
            obstach_random_inside();
            obstach_random_outside();
        }
        else
        {
            print("RandomTileGround reference is not assigned.");
        }
    }

    void obstach_random_inside()
    {
        int i;
        obstach_random = Random.Range(6, 13);
        for (i = 0; i < obstach_random; i++)
        {
            types_random_inside_obstacle = Random.Range(0, Scenes_object_obstacle.Length);
            // Randomly generate positions within range
            randomX = Random.Range(obstach_postion_minX, obstach_postion_maxX);
            randomZ = Random.Range(obstach_postion_minZ, obstach_postion_maxZ);
            Generateobstach(new Vector3(randomX, Scenes_object_obstacle[types_random_inside_obstacle].transform.position.y, randomZ));
        }

        obstach_random = Random.Range(16, 25);
        for (i = 0; i < obstach_random; i++)
        {
            types_random_inside_decorate = Random.Range(0, Scenes_object_decorate.Length);
            randomX = Random.Range(obstach_postion_minX, obstach_postion_maxX);
            randomZ = Random.Range(obstach_postion_minZ, obstach_postion_maxZ);
            Generateobstach(new Vector3(randomX, Scenes_object_decorate[types_random_inside_decorate].transform.position.y, randomZ));
        }

        Invoke("wait_build", .2f);
    }
    void obstach_random_outside()
    {
        int i;

        obstach_random = Random.Range(90, 115);
        for (i = 0; i < obstach_random; i++)
        {
            types_random_outside_small = Random.Range(0, Scenes_object_obstacle_outside_small.Length);
            float randomX, randomZ;

            // Randomly select the generated area
            int region = Random.Range(0, 4);
            switch (region)
            {
                case 0:
                    randomX = Random.Range(randomTileGround.minBoundary.x, obstach_postion_minX);
                    randomZ = Random.Range(randomTileGround.minBoundary.z, randomTileGround.maxBoundary.z);
                    break;
                case 1:
                    randomX = Random.Range(obstach_postion_maxX, randomTileGround.maxBoundary.x);
                    randomZ = Random.Range(randomTileGround.minBoundary.z, randomTileGround.maxBoundary.z);
                    break;
                case 2:
                    randomX = Random.Range(obstach_postion_minX, obstach_postion_maxX);
                    randomZ = Random.Range(obstach_postion_maxZ, randomTileGround.maxBoundary.z);
                    break;
                case 3:
                    randomX = Random.Range(obstach_postion_minX, obstach_postion_maxX);
                    randomZ = Random.Range(randomTileGround.minBoundary.z, obstach_postion_minZ);
                    break;

                default:
                    randomX = 0;
                    randomZ = 0;
                    break;
            }
            Generateobstach3(new Vector3(randomX, Scenes_object_obstacle_outside_small[types_random_outside_small].transform.position.y, randomZ));
        }

        obstach_random = Random.Range(30, 55);
        for (i = 0; i < obstach_random; i++)
        {
            types_random_outside_big = Random.Range(0, Scenes_object_obstacle_outside_big.Length);
            float randomX, randomZ;

            // Randomly select the generated area
            int region = Random.Range(0, 4);
            switch (region)
            {
                case 0:
                    randomX = Random.Range(randomTileGround.minBoundary.x, obstach_postion_minX);
                    randomZ = Random.Range(randomTileGround.minBoundary.z, randomTileGround.maxBoundary.z);
                    break;
                case 1:
                    randomX = Random.Range(obstach_postion_maxX, randomTileGround.maxBoundary.x);
                    randomZ = Random.Range(randomTileGround.minBoundary.z, randomTileGround.maxBoundary.z);
                    break;
                case 2:
                    randomX = Random.Range(obstach_postion_minX, obstach_postion_maxX);
                    randomZ = Random.Range(obstach_postion_maxZ, randomTileGround.maxBoundary.z);
                    break;
                case 3:
                    randomX = Random.Range(obstach_postion_minX, obstach_postion_maxX);
                    randomZ = Random.Range(randomTileGround.minBoundary.z, obstach_postion_minZ);
                    break;

                default:
                    randomX = 0;
                    randomZ = 0;
                    break;
            }
            Generateobstach4(new Vector3(randomX, Scenes_object_obstacle_outside_big[types_random_outside_big].transform.position.y, randomZ));
        }
    }


    void wait_build()
    {
        // Ensure the NavMeshSurface is ready to build the NavMesh
        surface.BuildNavMesh();
    }

    void Generateobstach(Vector3 position)
    {
        // Generate the prefab and place it at the generated location
        Instantiate(Scenes_object_obstacle[Random.Range(0, Scenes_object_obstacle.Length)], position, Quaternion.identity);
    }

    void Generateobstach2(Vector3 position)
    {
        Instantiate(Scenes_object_decorate[Random.Range(0, Scenes_object_decorate.Length)], position, Quaternion.identity);
    }

    void Generateobstach3(Vector3 position)
    {
        Instantiate(Scenes_object_obstacle_outside_small[Random.Range(0, Scenes_object_obstacle_outside_small.Length)], position, Quaternion.identity);
    }

    void Generateobstach4(Vector3 position)
    {
        Instantiate(Scenes_object_obstacle_outside_big[Random.Range(0, Scenes_object_obstacle_outside_big.Length)], position, Quaternion.identity);
    }
}
