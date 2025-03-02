using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes_Change_Magic_house : MonoBehaviour
{
    private void OnCollisionEnter(Collision Hit)
    {
        if (Hit.gameObject.CompareTag("Player") && static_parameters.isTeaching == false && static_parameters.teaching_stop == 1)
        {
            SceneManager.LoadScene("house_outside");
            static_parameters.teaching_stop = 2;
        }
    }
    private void OnTriggerEnter(Collider Hit)
    {
        if (Hit.gameObject.CompareTag("Player") && static_parameters.isTeaching == false && static_parameters.teaching_stop == 1)
        {
            SceneManager.LoadScene("house_outside");
            static_parameters.teaching_stop = 2;
        }
    }
}
