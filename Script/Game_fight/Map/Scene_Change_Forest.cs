using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Change_Forest : MonoBehaviour
{
    public GameObject CloseDoor01;
    public GameObject CloseDoor02;
    public GameObject player_S;
    int i;
    // Update is called once per frame

    void Start()
    {
        player_S = GameObject.Find("Player_S");
    }
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
            static_parameters.money += i * 10;
            if (static_parameters.stage_number >= i)
            {
                //SceneManager.LoadScene("Game_fight_Boss");
                SceneManager.LoadScene("magic_house");
                static_parameters.stage_number = 0;
                static_parameters.stage_number_Boss++;
            }
            else
            {
                SceneManager.LoadScene("Fight_FU01");
            }
        }
    }
    private void OnTriggerEnter(Collider Hit)
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
            static_parameters.money += i * 10;
            if (static_parameters.stage_number >= i)
            {
                Debug.Log("Go Back");
                player_S.transform.localPosition = new Vector3(0, 0, -15);
                //SceneManager.LoadScene("Game_fight_Boss");
                SceneManager.LoadScene("magic_house");
                static_parameters.stage_number = 0;
                static_parameters.stage_number_Boss++;
            }
            else
            {
                Debug.Log("Go Next");
                // player_S.transform.localPosition = new Vector3(0, 0, -138);
                Debug.Log("player_S" + player_S.transform.position);
                SceneManager.LoadScene("Fight_241130");
            }
        }
    }
}
