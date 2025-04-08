using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; // 為了使用 NavMesh

public class teaching_NPC : MonoBehaviour
{
    public GameObject prefabNPC_gin;
    private Bounds navMeshBounds;
    private float randomX, randomZ;
    private int Number_gin = 5;
    void Start()
    {
        // 計算初始 NavMesh 範圍
        UpdateNavMeshBounds();
        // 在 NavMesh 更新後重新計算範圍
        NavMesh.onPreUpdate += UpdateNavMeshBounds;
    }

    void Update()
    {
        if (static_parameters.teaching_stop == 4)
        {
            static_parameters.teaching_stop = 5;
            NPC_into();
        }
    }

    void OnDestroy()
    {
        // 移除 NavMesh 更新的監聽
        NavMesh.onPreUpdate -= UpdateNavMeshBounds;
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
        for (int i = 0; i < Number_gin; i++)
        {
            GenerateNPC(prefabNPC_gin);
        }
    }

    void GenerateNPC(GameObject prefab)
    {
        randomX = Random.Range(navMeshBounds.min.x, navMeshBounds.max.x);
        randomZ = Random.Range(navMeshBounds.min.z, navMeshBounds.max.z);
        Vector3 position = new Vector3(randomX, transform.position.y, randomZ);

        if (NavMesh.SamplePosition(position, out NavMeshHit hit, 5.0f, NavMesh.AllAreas))
        {
            Instantiate(prefab, hit.position, Quaternion.identity);
        }
    }
}
