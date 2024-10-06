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
            if (static_parameters.stage_number % 4 == 0)
            {
                //SceneManager.LoadScene("Game_fight_Boss");
                SceneManager.LoadScene("magic_house");
                static_parameters.stage_number = 0;
            }
            else
            {
                switch (Random.Range(0, 1))
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
                    case 8:
                        SceneManager.LoadScene("Fight_FB01");
                        break;
                    case 9:
                        SceneManager.LoadScene("Fight_FB02");
                        break;
                    case 10:
                        SceneManager.LoadScene("Fight_FB03");
                        break;
                    case 11:
                        SceneManager.LoadScene("Fight_FB04");
                        break;
                    case 12:
                        SceneManager.LoadScene("Fight_FB05");
                        break;
                    case 13:
                        SceneManager.LoadScene("Fight_FB06");
                        break;
                    case 14:
                        SceneManager.LoadScene("Fight_FB07");
                        break;
                    case 15:
                        SceneManager.LoadScene("Fight_FB08");
                        break;
                    case 16:
                        SceneManager.LoadScene("Fight_FC01");
                        break;
                    case 17:
                        SceneManager.LoadScene("Fight_FC02");
                        break;
                    case 18:
                        SceneManager.LoadScene("Fight_FC03");
                        break;
                    case 19:
                        SceneManager.LoadScene("Fight_FC04");
                        break;
                    case 20:
                        SceneManager.LoadScene("Fight_FC05");
                        break;
                    case 21:
                        SceneManager.LoadScene("Fight_FC06");
                        break;
                    case 22:
                        SceneManager.LoadScene("Fight_FC07");
                        break;
                    case 23:
                        SceneManager.LoadScene("Fight_FC08");
                        break;
                    case 24:
                        SceneManager.LoadScene("Fight_FD01");
                        break;
                    case 25:
                        SceneManager.LoadScene("Fight_FD02");
                        break;
                    case 26:
                        SceneManager.LoadScene("Fight_FD03");
                        break;
                    case 27:
                        SceneManager.LoadScene("Fight_FD04");
                        break;
                    case 28:
                        SceneManager.LoadScene("Fight_FD05");
                        break;
                    case 29:
                        SceneManager.LoadScene("Fight_FD06");
                        break;
                    case 30:
                        SceneManager.LoadScene("Fight_FD07");
                        break;
                    case 31:
                        SceneManager.LoadScene("Fight_FD08");
                        break;
                }
            }
        }
    }
}
