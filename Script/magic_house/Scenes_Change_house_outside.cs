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

            switch (Random.Range(0, 1))
            {
                case 0:
                    SceneManager.LoadScene("Fight_FU01");
                    break;
                case 1:
                    SceneManager.LoadScene("Fight_FU02");
                    break;
                case 2:
                    SceneManager.LoadScene("Fight_FU03");
                    break;
                case 3:
                    SceneManager.LoadScene("Fight_FU04");
                    break;
                case 4:
                    SceneManager.LoadScene("Fight_FU05");
                    break;
                case 5:
                    SceneManager.LoadScene("Fight_FU06");
                    break;
                case 6:
                    SceneManager.LoadScene("Fight_FU07");
                    break;
                case 7:
                    SceneManager.LoadScene("Fight_FU08");
                    break;
            }
        }
    }
}
