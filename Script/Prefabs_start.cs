using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prefabs_start : MonoBehaviour
{
    public GameObject prefabToSpawn; // 要生成的預製體
    public float NPC_postion_minX = -5f; // 範圍最小X值
    public float NPC_postion_maxX = 5f; // 範圍最大X值
    public float NPC_postion_minZ = -5f; // 範圍最小Z值
    public float NPC_postion_maxZ = 5f; // 範圍最大Z值
    float randomX;
    float randomZ;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < static_parameters.numberOfPrefabs; i++)
        {
            // 在範圍內隨機生成位置
            randomX = Random.Range(NPC_postion_minX, NPC_postion_maxX);
            randomZ = Random.Range(NPC_postion_minZ, NPC_postion_maxZ);
            GenerateNPC(new Vector3(randomX, 0f, randomZ));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void GenerateNPC(Vector3 position)
    {
        // 生成預製體並放置在生成的位置
        GameObject npc = Instantiate(prefabToSpawn, position, Quaternion.identity);
    }
}
