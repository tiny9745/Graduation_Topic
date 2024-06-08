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
    float NPC_postion_minX = -25f;
    float NPC_postion_maxX = 25f;
    float NPC_postion_minZ = -25f;
    float NPC_postion_maxZ = 25f;
    float randomX;
    float randomZ;
    int Number_NPC01;
    int Number_NPC02;
    //bool enemy_open = false; // Control the portal

    void Start()
    {
        static_parameters.Change_enemy = Number_NPC01 + Number_NPC02;

        // Randomly generate positions within range
        if (static_parameters.stage_number == 1)
        {
            Number_NPC01 = 5;
            Number_NPC02 = 1;
            for (int i = 0; i < Number_NPC01-2; i++)
            {
                randomX = Random.Range(NPC_postion_minX, NPC_postion_maxX);
                randomZ = Random.Range(NPC_postion_minZ, NPC_postion_maxZ);
                GenerateNPC01_1(new Vector3(randomX, transform.position.y, randomZ));
            }
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
        }
        else if (static_parameters.stage_number == 2)
        {
            Number_NPC01 = 4;
            Number_NPC02 = 3;
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
        }
        else if (static_parameters.stage_number == 3)
        {
            Number_NPC01 = 8;
            Number_NPC02 = 4;
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
        }
        else if (static_parameters.stage_number == 4)
        {

        }
        else
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
        }

        //static_parameters.Change_enemy = 0;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (static_parameters.Change_enemy == 0)
        {
            enemy_open = true;
        }*/
    }

    /*private void OnCollisionEnter(Collision Go_next_stage)
    {
        if (Go_next_stage.gameObject.CompareTag("Player") && enemy_open)
        {
            SceneManager.LoadScene("Game_fight");
        }
    }*/

    void GenerateNPC01_1(Vector3 position)
    {
        // Generate the prefab and place it at the generated location
        GameObject npc = Instantiate(prefabNPC01_1, position, Quaternion.identity);
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
}
