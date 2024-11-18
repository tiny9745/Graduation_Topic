using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class SceneAndNPCManager : MonoBehaviour
{
    public GameObject[] FU;
    public GameObject Door;
    public GameObject prefabNPC01, prefabNPC02, prefabNPC03, prefabNPC04, prefabNPC05;

    private Bounds navMeshBounds;
    private float randomX, randomZ;
    private int Number_NPC01, Number_NPC02, Number_NPC03, Number_NPC04, Number_NPC05;

    int max_index = 2; // 須為偶數
    int[][] scence_exist = new int[][]
    {
        new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
    };

    int scence_random;
    int scene_type;
    int max_Re = 0;
    float distance_scence = 120f;

    void Start()
    {
        SetMaxIndex();
        StartCoroutine(ExecuteInSequence());
    }

    void SetMaxIndex()
    {
        switch (static_parameters.stage_number_Boss)
        {
            case 0: max_index = 2; break;
            case 1: max_index = 4; break;
            case 2: max_index = 6; break;
        }
    }

    IEnumerator ExecuteInSequence()
    {
        Fight_FU();  // 生成場景部分
        yield return new WaitUntil(() => scence_exist[max_index / 2][max_index] == 1 || scence_exist[0][max_index] == 1 || scence_exist[max_index][max_index] == 1);

        UpdateNavMeshBounds();  // 計算初始 NavMesh 範圍
        NavMesh.onPreUpdate += UpdateNavMeshBounds;

        SetNPCNumbers();  // 設定 NPC 數量
        yield return new WaitForSeconds(1.5f);  // 確保範圍正確後延遲生成 NPC

        NPC_into();  // 生成 NPC
    }

    void Fight_FU()
    {
        scence_random = Random.Range(8, 15);
        static_parameters.Map_start = scence_random;
        Generatescence(FU[scence_random], new Vector3(max_index / 2 * distance_scence, 0, 0));
        scence_exist[max_index / 2][0] = 1;

        while (scence_exist[max_index / 2][max_index] != 1 && scence_exist[0][max_index] != 1 && scence_exist[max_index][max_index] != 1)
        {
            for (int i = 0; i < max_index + 1; i++)
            {
                for (int j = max_index / 2; j < max_index + 1; j++) Scenario_authentication(i, j);
                for (int j = max_index / 2; j >= 0; j--) Scenario_authentication(i, j);
            }
            max_Re++;
        }
    }

    void Scenario_authentication(int i, int j)
    {
        if (condition(i, j))
        {
            scene_type = Random.Range(0, 2);
            if (scene_type == 1 && scence_exist[i][j] == 0)
            {
                scence_random = i == max_index / 2 || j == max_index / 2 ? Random.Range(13, 19) : Random.Range(0, 13);
                Generatescence(FU[scence_random], new Vector3(i * distance_scence, 0, j * distance_scence));
                scence_exist[i][j] = 1;

                if (j == max_index && (i == 0 || i == max_index / 2 || i == max_index)) end_Door(scence_random, i, j);
            }
        }
    }

    bool condition(int a, int b)
    {
        int count = 0;
        if (a > 0 && scence_exist[a - 1][b] == 1) count++;
        if (a < max_index && scence_exist[a + 1][b] == 1) count++;
        if (b > 0 && scence_exist[a][b - 1] == 1) count++;
        if (b < max_index && scence_exist[a][b + 1] == 1) count++;

        return count > 0 && count < 5;
    }

    void end_Door(int scence_number, int a, int b)
    {
        Vector3 position = new Vector3(a * distance_scence, 2.5f, b * distance_scence + 44f);
        switch (scence_number)
        {
            case 0: position.x += 15f; break;
            case 1: position.x += 42f; break;
            case 2: position.x -= 8f; break;
            case 3: position.x -= 30f; break;
            case 4: position.x -= 20f; break;
        }
        GenerateDoor(Door, position);
    }

    void Generatescence(GameObject scence, Vector3 position) => Instantiate(scence, position, Quaternion.identity, transform);
    void GenerateDoor(GameObject scence, Vector3 position) => Instantiate(scence, position, Quaternion.identity);

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

            navMeshBounds.SetMinMax(min, max);
        }
    }

    void SetNPCNumbers()
    {
        switch (static_parameters.stage_number)
        {
            case 1: Number_NPC01 = Number_NPC02 = Number_NPC03 = Number_NPC04 = Number_NPC05 = 6; break;
            case 2: Number_NPC01 = 20; Number_NPC02 = 12; break;
            case 3: Number_NPC01 = 32; Number_NPC02 = 16; break;
            case 4: Number_NPC01 = 15; Number_NPC03 = 20; Number_NPC05 = 12; break;
            case 5: Number_NPC01 = 30; Number_NPC02 = Number_NPC03 = 24; break;
            case 6: Number_NPC01 = 20; Number_NPC02 = 27; Number_NPC03 = Number_NPC05 = 22; break;
            case 7: Number_NPC02 = 32; Number_NPC04 = 60; break;
            case 8: Number_NPC01 = 48; Number_NPC02 = Number_NPC05 = 36; break;
            case 9: Number_NPC01 = Number_NPC02 = Number_NPC03 = Number_NPC04 = Number_NPC05 = 24; break;
            case 10: Number_NPC01 = 50; Number_NPC02 = Number_NPC03 = 38; Number_NPC04 = Number_NPC05 = 36; break;
        }
    }

    void NPC_into()
    {
        for (int i = 0; i < Number_NPC01; i++) GenerateNPC(prefabNPC01);
        for (int i = 0; i < Number_NPC02; i++) GenerateNPC(prefabNPC02);
        for (int i = 0; i < Number_NPC03; i++) GenerateNPC(prefabNPC03);
        for (int i = 0; i < Number_NPC04; i++) GenerateNPC(prefabNPC04);
        for (int i = 0; i < Number_NPC05; i++) GenerateNPC(prefabNPC05);
    }

    void GenerateNPC(GameObject prefab)
    {
        randomX = Random.Range(navMeshBounds.min.x, navMeshBounds.max.x);
        randomZ = Random.Range(navMeshBounds.min.z, navMeshBounds.max.z);
        NavMeshHit hit;

        if (NavMesh.SamplePosition(new Vector3(randomX, 0, randomZ), out hit, 4.5f, NavMesh.AllAreas))
            Instantiate(prefab, hit.position, Quaternion.identity);
    }
}
