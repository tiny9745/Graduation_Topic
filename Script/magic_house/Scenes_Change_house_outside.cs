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
            static_parameters.stage_number = 1;

            switch (Random.Range(0, 20))
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
                    SceneManager.LoadScene("Fight_FC01");
                    break;
                case 16:
                    SceneManager.LoadScene("Fight_FC02");
                    break;
                case 17:
                    SceneManager.LoadScene("Fight_FC03");
                    break;
                case 18:
                    SceneManager.LoadScene("Fight_FC04");
                    break;
                case 19:
                    SceneManager.LoadScene("Fight_FC05");
                    break;

            }
        }
    }
}
