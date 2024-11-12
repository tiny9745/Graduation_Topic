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
            }
        }
    }
}
