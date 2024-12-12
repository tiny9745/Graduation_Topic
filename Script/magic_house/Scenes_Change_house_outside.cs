using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes_Change_house_outside : MonoBehaviour
{
    private GameObject player_S;
    private Vector3 startPos = new Vector3(0, 0, 0);
    private void Start()
    {
        Debug.Log("Start_ouside");
        player_S = GameObject.Find("Player_S");
        startPos = player_S.transform.position;
        startPos.z = -16;
        player_S.transform.position = startPos;
        Debug.Log("startPos.z = " + startPos.z);
        Debug.Log("player_S.transform.position = " + player_S.transform.position);
        Invoke("ChangeScene", 1f);
    }
    public void ChangeScene()
    {
        startPos.z = -16;
        startPos.x = 0;
        player_S.transform.position = startPos;
        Debug.Log("player_S.transform.position2 = " + player_S.transform.position);
    }
    private void OnCollisionEnter(Collision Hit)
    {
        if (Hit.gameObject.CompareTag("Player"))
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
        if (Hit.gameObject.CompareTag("Player"))
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
