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

            if (static_parameters.stage_number < 5)
            {
                i = 5;
            }
            else if (static_parameters.stage_number < 11)
            {
                i = static_parameters.stage_number;
            }
            else
            {
                i = 10;
            }
            if (static_parameters.stage_number >= i)
            {
                //SceneManager.LoadScene("Game_fight_Boss");
                SceneManager.LoadScene("magic_house");
                static_parameters.stage_number = 0;
            }
            else
            {
                switch (Random.Range(0, 8))
                {
                    case 0:
                        SceneManager.LoadScene("Fight_FA01");
                        break;
                    case 1:
                        SceneManager.LoadScene("Fight_FA02");
                        break;
                    case 2:
                        SceneManager.LoadScene("Fight_FA03");
                        break;
                    case 3:
                        SceneManager.LoadScene("Fight_FA04");
                        break;
                    case 4:
                        SceneManager.LoadScene("Fight_FA05");
                        break;
                    case 5:
                        SceneManager.LoadScene("Fight_FA06");
                        break;
                    case 6:
                        SceneManager.LoadScene("Fight_FA07");
                        break;
                    case 7:
                        SceneManager.LoadScene("Fight_FA08");
                        break;
                }
            }
        }
    }
}
