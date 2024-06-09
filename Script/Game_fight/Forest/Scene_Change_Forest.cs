using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Change_Forest : MonoBehaviour
{
    public GameObject CloseDoor01;
    public GameObject CloseDoor02;

    // Update is called once per frame

    private void Update()
    {
        if(static_parameters.Change_enemy == 0)
        {
            CloseDoor01.SetActive(false);
            CloseDoor02.SetActive(false);
        }
    }
    private void OnCollisionEnter(Collision Hit)
    {
        if (Hit.gameObject.CompareTag("Player") && static_parameters.Change_enemy == 0)
        {
            static_parameters.stage_number++;
            if (static_parameters.stage_number%4 == 0)
            {
                SceneManager.LoadScene("Game_fight_Boss");
            }
            else
            {
                SceneManager.LoadScene("Game_fight");
            }
        }
    }
}
