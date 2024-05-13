using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prefabs_start : MonoBehaviour
{
    public GameObject prefabToSpawn; //Prefab to generate
    public float NPC_postion_minX = -5f;
    public float NPC_postion_maxX = 5f;
    public float NPC_postion_minZ = -5f;
    public float NPC_postion_maxZ = 5f;
    float randomX;
    float randomZ;
    bool enemy_open = true;
    void Start()
    {
        for (int i = 0; i < static_parameters.Max_enemy; i++)
        {
            // Randomly generate positions within range
            randomX = Random.Range(NPC_postion_minX, NPC_postion_maxX);
            randomZ = Random.Range(NPC_postion_minZ, NPC_postion_maxZ);
            GenerateNPC(new Vector3(randomX, 0f, randomZ));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(static_parameters.Change_enemy == 0 && enemy_open)
        {
            enemy_open = false;
            New_enemy_generate();
        }
    }
    void GenerateNPC(Vector3 position)
    {
        // Generate the prefab and place it at the generated location
        GameObject npc = Instantiate(prefabToSpawn, position, Quaternion.identity);
    }


    void New_enemy_generate()
    {
        for (int i = 0; i < static_parameters.Max_enemy; i++)
        {
            
            // Randomly generate positions within range
            randomX = Random.Range(NPC_postion_minX, NPC_postion_maxX);
            randomZ = Random.Range(NPC_postion_minZ, NPC_postion_maxZ);
            GenerateNPC(new Vector3(randomX, 0f, randomZ));
        }
        enemy_open = true;
    }
}
