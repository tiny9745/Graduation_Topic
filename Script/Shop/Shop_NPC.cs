using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop_NPC : MonoBehaviour
{
    ushort npc_random_number = 0;
    public GameObject[] npc_talks;
    void Start()
    {
        npc_random_number = (ushort)Random.Range(0, 2);
        npc_talks[npc_random_number].SetActive(true);
    }
}
