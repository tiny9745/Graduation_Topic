using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Unity.AI.Navigation;

public class AI_Baking_obstacle : MonoBehaviour
{
    [SerializeField]
    public GameObject[] Scenes_object_obstacle;  // 障礙物物體數組
    public GameObject[] Scenes_object_decorate;  // 裝飾物物體數組
    public NavMeshSurface navMeshSurface;  // 參考NavMeshSurface物體
    float distance_scence = 120f;
    // 障礙物範圍
    private float obstach_postion_minX, obstach_postion_maxX, obstach_postion_minZ, obstach_postion_maxZ;

    // 隨機數量範圍
    private int MinInsideDecorate = 160, MaxInsideDecorate = 250;
    private int MinInsideObstacle = 60, MaxInsideObstacle = 130;

    private bool obstaclesGenerated = false;  // 用來確保障礙物只生成一次

    void Start()
    {
        // 初始化隨機範圍
        obstach_postion_minX = -distance_scence/2;
        obstach_postion_maxX = (static_parameters.stage_number_Boss * 2 + 3) * distance_scence - distance_scence/2;
        obstach_postion_minZ = -distance_scence/2;
        obstach_postion_maxZ = (static_parameters.stage_number_Boss * 2 + 3) * distance_scence - distance_scence/2;

        // 初始化障礙物範圍
        Invoke("InitializeObstacleRanges",1.5f);
    }
    

    void InitializeObstacleRanges()
    {
        // 只有在障礙物尚未生成時才會生成
        if (!obstaclesGenerated)
        {
            obstach_random_inside();
            obstaclesGenerated = true;  // 標記障礙物已經生成
        }

        // 每次NavMeshSurface變化後都重新bake
        BakeNavMesh();
    }

    void obstach_random_inside()
    {
        // 隨機生成障礙物和裝飾物
        GenerateRandomObjects(Scenes_object_obstacle, MinInsideObstacle, MaxInsideObstacle, true);
        GenerateRandomObjects(Scenes_object_decorate, MinInsideDecorate, MaxInsideDecorate, true);
    }

    void GenerateRandomObjects(GameObject[] objects, int minCount, int maxCount, bool isInside)
    {
        int count = Random.Range(minCount, maxCount); // 隨機數量
        List<Vector3> usedPositions = new List<Vector3>(); // 用來記錄已經使用過的位置

        for (int i = 0; i < count; i++)
        {
            int typeIndex = Random.Range(0, objects.Length); // 隨機選擇物體類型
            GameObject selectedObject = objects[typeIndex];

            Vector3 randomPosition = Vector3.zero;  // 初始化位置，避免未賦值錯誤

            // 嘗試隨機生成不重疊的有效位置
            bool validPositionFound = false;
            for (int attempt = 0; attempt < 100; attempt++) // 嘗試最大次數
            {
                randomPosition = GenerateInsidePosition(selectedObject); // 生成隨機位置

                if (!IsPositionUsed(randomPosition, usedPositions)) // 檢查位置是否有效
                {
                    usedPositions.Add(randomPosition); // 如果有效，則記錄位置
                    validPositionFound = true;
                    break; // 成功找到有效位置，跳出循環
                }
            }

            if (validPositionFound)
            {
                // 在有效位置生成物體
                Instantiate(selectedObject, randomPosition, Quaternion.identity);
            }
        }
    }

    bool IsPositionUsed(Vector3 position, List<Vector3> usedPositions, float minDistance = 1.0f)
    {
        foreach (Vector3 usedPosition in usedPositions)
        {
            if (Vector3.Distance(position, usedPosition) < minDistance)
            {
                return true; // 位置已經使用過
            }
        }
        return false; // 位置未被使用過
    }

    Vector3 GenerateInsidePosition(GameObject obj)
    {
        // 隨機生成位置
        float randomX = Random.Range(obstach_postion_minX, obstach_postion_maxX);
        float randomZ = Random.Range(obstach_postion_minZ, obstach_postion_maxZ);
        float randomY = obj.transform.position.y;  // 確保Y軸位置可以根據物體的實際位置設定

        Vector3 newPosition = new Vector3(randomX, randomY, randomZ);
        return newPosition; // 返回生成的隨機位置
    }

    // 重新計算（bake）NavMesh
    void BakeNavMesh()
    {
        if (navMeshSurface != null)
        {
            navMeshSurface.BuildNavMesh();  // 重新建構NavMesh
        }
    }
}
