using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes_Change_house_outside : MonoBehaviour
{
    private void OnCollisionEnter(Collision Hit)
    {
        if (Hit.gameObject.CompareTag("Player"))
        {
            static_parameters.stage_number++;
            if (static_parameters.stage_number % 4 == 0)
            {
                //SceneManager.LoadScene("Game_fight_Boss");
            }
            else
            {
                SceneManager.LoadScene("Game_fight");
            }
        }
    }
}
