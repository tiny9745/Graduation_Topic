using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Prefabs_start : MonoBehaviour
{
    // Prefab to generate
    public GameObject prefabNPC01_1;
    public GameObject prefabNPC01, prefabNPC02, prefabNPC03, prefabNPC04, prefabNPC05;
    float NPC_postion_minX = -50f, NPC_postion_maxX = 50f;
    float NPC_postion_minZ = -50f, NPC_postion_maxZ = 50f;
    float randomX;
    float randomZ;
    int Number_NPC01, Number_NPC02, Number_NPC03, Number_NPC04, Number_NPC05;

    void Start()
    {
        // Randomly generate positions within range
        switch (static_parameters.stage_number)
        {
            case 1:
                Number_NPC01 = 2;
                Number_NPC02 = 2;
                Number_NPC03 = 2;
                Number_NPC04 = 2;
                Number_NPC05 = 2;
                break;
            case 2:
                Number_NPC01 = 4;
                Number_NPC02 = 3;
                break;
            case 3:
                Number_NPC01 = 8;
                Number_NPC02 = 4;
                break;
            case 4:
                Number_NPC01 = 3;
                Number_NPC03 = 4;
                Number_NPC05 = 3;
                break;
            case 5:
                Number_NPC01 = 6;
                Number_NPC02 = 4;
                Number_NPC03 = 4;
                break;
            case 6:
                Number_NPC01 = 4;
                Number_NPC02 = 6;
                Number_NPC03 = 5;
                Number_NPC05 = 5;
                break;
            case 7:
                Number_NPC02 = 5;
                Number_NPC04 = 10;
                break;
            case 8:
                Number_NPC01 = 8;
                Number_NPC02 = 6;
                Number_NPC05 = 6;
                break;
            case 9:
                Number_NPC01 = 4;
                Number_NPC02 = 4;
                Number_NPC03 = 4;
                Number_NPC04 = 4;
                Number_NPC05 = 4;
                break;
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

        NPC_into();
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
        for (int i = 0; i < Number_NPC05; i++)
        {
            randomX = Random.Range(NPC_postion_minX, NPC_postion_maxX);
            randomZ = Random.Range(NPC_postion_minZ, NPC_postion_maxZ);
            GenerateNPC05(new Vector3(randomX, transform.position.y, randomZ));
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
    void GenerateNPC05(Vector3 position)
    {
        GameObject npc = Instantiate(prefabNPC05, position, Quaternion.identity);
    }
}
