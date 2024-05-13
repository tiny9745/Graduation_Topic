using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    public GameObject door;
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
        if(static_parameters.Change_enemy == 0)
        {
            door.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision Go_next_stage)
    {
        Renderer renderer = door.GetComponent<Renderer>();
        Debug.Log("inter");
        if (Go_next_stage.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("magic_house");
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
        static_parameters.Change_enemy = static_parameters.Max_enemy;
        enemy_open = true;
    }
}
