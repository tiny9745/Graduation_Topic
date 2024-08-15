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
    public GameObject[] Scenes_object_obstacle_outside_small;
    public GameObject[] Scenes_object_obstacle_outside_big;

    public GameObject block_fog;

    public RandomTileGround randomTileGround;

    float obstach_postion_minX, obstach_postion_maxX;
    float obstach_postion_minZ, obstach_postion_maxZ;

    bool randomTileGround_found = false;

    int MinInsideDecorate = 16, MaxInsideDecorate = 25;
    int MinInsideObstacle = 6, MaxInsideObstacle = 13;
    int MinOutsideSmall = 90, MaxOutsideSmall = 115;
    int MinOutsideBig = 60, MaxOutsideBig = 85;

    void Update()
    {
        if (!randomTileGround_found)
        {
            InitializeObstacleRanges();
        }
    }

    void InitializeObstacleRanges()
    {
        if (randomTileGround != null)
        {
            obstach_postion_minX = randomTileGround.minBoundary.x + randomTileGround.padding_X_min;
            obstach_postion_maxX = randomTileGround.maxBoundary.x - randomTileGround.padding_X_max;
            obstach_postion_minZ = randomTileGround.minBoundary.z + randomTileGround.padding_Z_min;
            obstach_postion_maxZ = randomTileGround.maxBoundary.z - randomTileGround.padding_Z_max;
            randomTileGround_found = true;

            obstach_random_inside();
            obstach_random_outside();

            GenerateShaderAppliedObjects();
            GenerateShaderAppliedObjects2();
            GenerateShaderAppliedObjects3();
        }
        else
        {
            Debug.LogError("RandomTileGround reference is not assigned.");
        }
    }

    void obstach_random_inside()
    {
        GenerateRandomObjects(Scenes_object_obstacle, MinInsideObstacle, MaxInsideObstacle, true);
        GenerateRandomObjects(Scenes_object_decorate, MinInsideDecorate, MaxInsideDecorate, true);
        Invoke("BuildNavMesh", 0.2f);
    }

    void obstach_random_outside()
    {
        GenerateRandomObjects(Scenes_object_obstacle_outside_small, MinOutsideSmall, MaxOutsideSmall, false);
        GenerateRandomObjects(Scenes_object_obstacle_outside_big, MinOutsideBig, MaxOutsideBig, false);
    }

    void GenerateRandomObjects(GameObject[] objects, int minCount, int maxCount, bool isInside)
    {
        int count = Random.Range(minCount, maxCount);
        List<Vector3> usedPositions = new List<Vector3>(); // Record used location

        for (int i = 0; i < count; i++)
        {
            int typeIndex = Random.Range(0, objects.Length);
            Vector3 position;

            // Try generating locations until you find a non-overlapping location
            do
            {
                position = isInside ? GenerateInsidePosition(objects[typeIndex]) : GenerateOutsidePosition(objects[typeIndex]);
            }
            while (IsPositionUsed(position, usedPositions));

            usedPositions.Add(position);
            Instantiate(objects[typeIndex], position, Quaternion.identity);
        }
    }

    bool IsPositionUsed(Vector3 position, List<Vector3> usedPositions, float minDistance = 1.0f)
    {
        foreach (Vector3 usedPosition in usedPositions)
        {
            if (Vector3.Distance(position, usedPosition) < minDistance)
            {
                return true;
            }
        }
        return false;
    }


    Vector3 GenerateInsidePosition(GameObject obj)
    {
        float randomX = Random.Range(obstach_postion_minX, obstach_postion_maxX);
        float randomZ = Random.Range(obstach_postion_minZ, obstach_postion_maxZ);
        return new Vector3(randomX, obj.transform.position.y, randomZ);
    }

    Vector3 GenerateOutsidePosition(GameObject obj)
    {
        float randomX = 0;
        float randomZ = 0;
        int region = Random.Range(0, 3);

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
        }

        return new Vector3(randomX, obj.transform.position.y, randomZ);
    }

void GenerateShaderAppliedObjects()
{
    float lengthX = obstach_postion_maxX - obstach_postion_minX;
    float lengthZ = randomTileGround.maxBoundary.z - obstach_postion_maxZ;

    Vector3 scale = block_fog.transform.localScale;

    scale.x = lengthX;
    scale.z = lengthZ;

    block_fog.transform.localScale = scale;

    float centerX = obstach_postion_minX + (lengthX / 2);

    GameObject blockFogInstance = Instantiate(
        block_fog, 
        new Vector3(centerX, 0, randomTileGround.maxBoundary.z - lengthZ / 2), 
        Quaternion.identity
    );
}
void GenerateShaderAppliedObjects2()
{
    float lengthX = obstach_postion_maxX - randomTileGround.maxBoundary.x;
    float lengthZ = randomTileGround.maxBoundary.z - obstach_postion_minZ; 

    Vector3 scale = block_fog.transform.localScale;
    scale.x = lengthX;
    scale.z = lengthZ;
    block_fog.transform.localScale = scale;

    float centerZ = randomTileGround.maxBoundary.z - (lengthZ / 2);

    GameObject blockFogInstance = Instantiate(
        block_fog, 
        new Vector3(randomTileGround.maxBoundary.x + (lengthX / 2), 0, centerZ), 
        Quaternion.identity
    );
}

void GenerateShaderAppliedObjects3()
{
    float lengthX = randomTileGround.maxBoundary.x + obstach_postion_minX;
    float lengthZ = randomTileGround.maxBoundary.z - obstach_postion_minZ; 

    Vector3 scale = block_fog.transform.localScale;
    scale.x = lengthX;
    scale.z = lengthZ;
    block_fog.transform.localScale = scale;

    float centerZ = randomTileGround.maxBoundary.z - (lengthZ / 2);

    GameObject blockFogInstance = Instantiate(
        block_fog, 
        new Vector3(randomTileGround.minBoundary.x + (lengthX / 2), 0, centerZ), 
        Quaternion.identity
    );
}

    void BuildNavMesh()
    {
        surface.BuildNavMesh();
    }
}
