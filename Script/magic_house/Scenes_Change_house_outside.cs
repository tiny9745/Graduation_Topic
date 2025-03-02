using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes_Change_house_outside : MonoBehaviour
{
    public GameObject player_S;
    public GameObject player;

    void Start()
    {
        player_S = GameObject.Find("Player_S");
        player = GameObject.Find("Player");
        player_S.transform.position = new Vector3(0, 0, -15);
    }
    private void OnCollisionEnter(Collision Hit)
    {
        if (Hit.gameObject.CompareTag("Player") && static_parameters.isTeaching == false && static_parameters.teaching_stop >= 2)
        {
            static_parameters.stage_number = 1;
            switch (Random.Range(0, 1))
            {
                case 0:
                    SceneManager.LoadScene("Fight_241130");
                    break;
            }
        }
    }
    private void OnTriggerEnter(Collider Hit)
    {
        if (Hit.gameObject.CompareTag("Player") && static_parameters.isTeaching == false && static_parameters.teaching_stop >= 2)
        {
            static_parameters.stage_number = 1;
            switch (Random.Range(0, 1))
            {
                case 0:
                    SceneManager.LoadScene("Fight_241130");
                    break;
            }
        }
    }
}
