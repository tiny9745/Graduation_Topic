using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Change_Forest : MonoBehaviour
{
    public GameObject CloseDoor01;
    public GameObject CloseDoor02;
    int i;
    // Update is called once per frame

    private void Update()
    {
        if (static_parameters.Change_enemy == 0)
        {
            CloseDoor01.SetActive(false);
            CloseDoor02.SetActive(false);
        }
        else
        {
            CloseDoor01.SetActive(true);
            CloseDoor02.SetActive(true);
        }
    }
    private void OnCollisionEnter(Collision Hit)
    {
        if (Hit.gameObject.CompareTag("Player") && static_parameters.Change_enemy == 0)
        {
            static_parameters.stage_number++;

            if (static_parameters.stage_number < 3)
            {
                i = 3;
            }
            else if (static_parameters.stage_number < 6)
            {
                i = static_parameters.stage_number;
            }
            else
            {
                i = 5;
            }
            if (static_parameters.stage_number >= i)
            {
                //SceneManager.LoadScene("Game_fight_Boss");
                SceneManager.LoadScene("magic_house");
                static_parameters.stage_number = 0;
                static_parameters.stage_number_Boss ++;
            }
            else
            {
                SceneManager.LoadScene("Fight_FU01");
            }
        }
    }
}
