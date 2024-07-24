using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Prefabs_start : MonoBehaviour
{
    // Prefab to generate
    public GameObject prefabNPC01_1;
    public GameObject prefabNPC01;
    public GameObject prefabNPC02;
    public GameObject prefabNPC03;
    public GameObject prefabNPC04;
    float NPC_postion_minX = -50f;
    float NPC_postion_maxX = 50f;
    float NPC_postion_minZ = -50f;
    float NPC_postion_maxZ = 50f;
    float randomX;
    float randomZ;
    int Number_NPC01;
    int Number_NPC02;
    int Number_NPC03;
    int Number_NPC04;

    void Start()
    {
        // Randomly generate positions within range
        if (static_parameters.stage_number == 1)
        {
            Number_NPC04 = 1;
            Number_NPC03 = 1;
            Number_NPC02 = 1;
            //Number_NPC01 = 1;
            NPC_into();
        }
        else if (static_parameters.stage_number == 2)
        {
            Number_NPC01 = 4;
            Number_NPC02 = 3;
            NPC_into();
        }
        else if (static_parameters.stage_number == 3)
        {
            Number_NPC01 = 8;
            Number_NPC02 = 4;
            NPC_into();
        }
        else if (static_parameters.stage_number == 4)
        {

        }
        else
        {
            NPC_into();
        }
    }

    void NPC_into()
    {
        for (int i = 0; i < Number_NPC01; i++)
        {
            randomX = Random.Range(NPC_postion_minX, NPC_postion_maxX);
            randomZ = Random.Range(NPC_postion_minZ, NPC_postion_maxZ);
            GenerateNPC01(new Vector3(randomX, transform.position.y, randomZ));
        }
        for (int i = 0; i < Number_NPC02; i++)
        {
            randomX = Random.Range(NPC_postion_minX, NPC_postion_maxX);
            randomZ = Random.Range(NPC_postion_minZ, NPC_postion_maxZ);
            GenerateNPC02(new Vector3(randomX, transform.position.y, randomZ));
        }
        for (int i = 0; i < Number_NPC03; i++)
        {
            randomX = Random.Range(NPC_postion_minX, NPC_postion_maxX);
            randomZ = Random.Range(NPC_postion_minZ, NPC_postion_maxZ);
            GenerateNPC03(new Vector3(randomX, transform.position.y, randomZ));
        }
        for (int i = 0; i < Number_NPC04; i++)
        {
            randomX = Random.Range(NPC_postion_minX, NPC_postion_maxX);
            randomZ = Random.Range(NPC_postion_minZ, NPC_postion_maxZ);
            GenerateNPC04(new Vector3(randomX, transform.position.y, randomZ));
        }
    }
    void GenerateNPC01(Vector3 position)
    {
        // Generate the prefab and place it at the generated location
        GameObject npc = Instantiate(prefabNPC01, position, Quaternion.identity);
    }

    void GenerateNPC02(Vector3 position)
    {
        GameObject npc = Instantiate(prefabNPC02, position, Quaternion.identity);
    }

    void GenerateNPC03(Vector3 position)
    {
        GameObject npc = Instantiate(prefabNPC03, position, Quaternion.identity);
    }
    void GenerateNPC04(Vector3 position)
    {
        GameObject npc = Instantiate(prefabNPC04, position, Quaternion.identity);
    }
}
