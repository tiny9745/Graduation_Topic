using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Hit_box : MonoBehaviour
{
    public GameObject Player;
    void Start()
    {
        Player = GameObject.Find("Player");
        if (Player == null)
        {
            Debug.LogError("Player object not found!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Player != null)
        {
            // Get target direction
            Vector3 direction = Player.transform.position - transform.position;
            direction.y = 0;

            if (direction != Vector3.zero)
            {
                // target rotation
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = targetRotation;
            }
        }
    }
}
