using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; // 為了使用 NavMesh

public class Prefabs_start : MonoBehaviour
{
    public GameObject prefabNPC01, prefabNPC02, prefabNPC03, prefabNPC04, prefabNPC05;

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

        // 延遲生成 NPC，確保範圍正確
        Invoke("NPC_into", 0.18f);
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
                Number_NPC01 = 8;
                Number_NPC02 = 8;
                Number_NPC03 = 8;
                Number_NPC04 = 8;
                Number_NPC05 = 8;
                break;
            case 2:
                Number_NPC01 = 4;
                Number_NPC02 = 3;
                break;
            // 其他 stage 設定...
            case 10:
                Number_NPC01 = 10;
                Number_NPC02 = 6;
                Number_NPC03 = 6;
                Number_NPC04 = 6;
                Number_NPC05 = 6;
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

        if (NavMesh.SamplePosition(position, out NavMeshHit hit, 2.0f, NavMesh.AllAreas))
        {
            Instantiate(prefab, hit.position, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning($"無法在範圍內找到有效 NavMesh 位置，跳過此生成 {prefab.name}。");
        }
    }
}
