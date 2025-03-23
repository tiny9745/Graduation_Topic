using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; // 為了使用 NavMesh
using Unity.AI.Navigation; // 為了使用 NavMeshSurface

public class Prefabs_start_241130 : MonoBehaviour
{
    public GameObject prefabNPC01, prefabNPC02, prefabNPC03, prefabNPC04, prefabNPC05;
    public NavMeshSurface navMeshSurface;
    private Bounds navMeshBounds;
    private float randomX, randomZ;
    private int Number_NPC01, Number_NPC02, Number_NPC03, Number_NPC04, Number_NPC05;
    void Start()
    {
        // 計算初始 NavMesh 範圍
        UpdateNavMeshBounds();

        // 設定 NPC 數量
        SetNPCNumbers();

        // 在 NavMesh 更新後重新計算範圍
        NavMesh.onPreUpdate += UpdateNavMeshBounds;
        static_parameters.into_gameFight = true;
        // 延遲生成確保範圍正確
        Invoke("BakeNavMesh", 1.5f);
        Invoke("NPC_into", 3.1f);
    }

    void OnDestroy()
    {
        // 移除 NavMesh 更新的監聽
        NavMesh.onPreUpdate -= UpdateNavMeshBounds;
    }

    void SetNPCNumbers()
    {
        switch (static_parameters.stage_number)
        {
            case 1:
                // Number_NPC01 = 8;
                // Number_NPC03 = 5;
                break;
            case 2:
                // Number_NPC03 = 12;
                Number_NPC01 = 10;
                Number_NPC02 = 6;
                break;
            case 3:
                // Number_NPC03 = 16;
                Number_NPC01 = 16;
                Number_NPC02 = 8;
                break;
            case 4:
                // Number_NPC03 = 22;
                Number_NPC01 = 7;
                Number_NPC03 = 10;
                Number_NPC05 = 6;
                break;
            case 5:
                // Number_NPC03 = 30;
                Number_NPC01 = 15;
                Number_NPC02 = 12;
                Number_NPC03 = 12;
                break;
            case 6:
                // Number_NPC03 = 42;
                Number_NPC01 = 10;
                Number_NPC02 = 13;
                Number_NPC03 = 11;
                Number_NPC05 = 11;
                break;
            default:
                break;
        }
    }

    void UpdateNavMeshBounds()
    {
        NavMeshTriangulation triangulation = NavMesh.CalculateTriangulation();
        if (triangulation.vertices.Length > 0)
        {
            Vector3 min = triangulation.vertices[0];
            Vector3 max = triangulation.vertices[0];

            foreach (Vector3 vertex in triangulation.vertices)
            {
                min = Vector3.Min(min, vertex);
                max = Vector3.Max(max, vertex);
            }
            navMeshBounds = new Bounds();
            navMeshBounds.SetMinMax(min, max);
        }
    }

    void NPC_into()
    {
        for (int i = 0; i < Number_NPC01; i++)
        {
            GenerateNPC(prefabNPC01);
        }
        for (int i = 0; i < Number_NPC02; i++)
        {
            GenerateNPC(prefabNPC02);
        }
        for (int i = 0; i < Number_NPC03; i++)
        {
            GenerateNPC(prefabNPC03);
        }
        for (int i = 0; i < Number_NPC04; i++)
        {
            GenerateNPC(prefabNPC04);
        }
        for (int i = 0; i < Number_NPC05; i++)
        {
            GenerateNPC(prefabNPC05);
        }
    }

    void GenerateNPC(GameObject prefab)
    {
        randomX = Random.Range(navMeshBounds.min.x, navMeshBounds.max.x);
        randomZ = Random.Range(navMeshBounds.min.z, navMeshBounds.max.z);
        Vector3 position = new Vector3(randomX, transform.position.y, randomZ);

        if (NavMesh.SamplePosition(position, out NavMeshHit hit, 5.0f, NavMesh.AllAreas))
        {
            // 檢查是否落在 tag 為 "Thorns" 的區域內
            Collider[] colliders = Physics.OverlapSphere(hit.position, 0.5f); // 0.5f 可調整為半徑大小
            bool isInThorns = false;

            foreach (Collider collider in colliders)
            {
                // 確認是否為 Trigger 並且 tag 為 "Thorns"
                if (collider.CompareTag("Thorns"))
                {
                    isInThorns = true;
                    break;
                }
            }

            // 如果不在 "Thorns" 區域內，生成物件
            if (!isInThorns)
            {
                Instantiate(prefab, hit.position, Quaternion.identity);
            }
        }
        else
        {
        }
    }
    void GenerateDecorate(GameObject prefab)
    {
        randomX = Random.Range(navMeshBounds.min.x, navMeshBounds.max.x);
        randomZ = Random.Range(navMeshBounds.min.z, navMeshBounds.max.z);
        Vector3 position = new Vector3(randomX, transform.position.y, randomZ);

        if (NavMesh.SamplePosition(position, out NavMeshHit hit, 2.0f, NavMesh.AllAreas))
        {
            Instantiate(prefab, hit.position, Quaternion.identity);
        }
    }
    void BakeNavMesh()
    {
        if (navMeshSurface != null)
        {
            navMeshSurface.BuildNavMesh();  // 重新建構NavMesh
        }
        else
        {
            Debug.LogWarning("NavMeshSurface is not assigned.");
        }
    }
}
