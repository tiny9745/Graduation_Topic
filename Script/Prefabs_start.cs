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
    bool enemy_open = false;//Control the portal
    void Start()
    {
        Debug.Log(enemy_open);
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
            enemy_open =true;
        }
    }

    private void OnCollisionEnter(Collision Go_next_stage)
    {
        if (Go_next_stage.gameObject.CompareTag("Player") && enemy_open)
        {
            SceneManager.LoadScene("Game_fight");
        }
    }

    void GenerateNPC(Vector3 position)
    {
        // Generate the prefab and place it at the generated location
        GameObject npc = Instantiate(prefabToSpawn, position, Quaternion.identity);
    }
}
