using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class outside_back : MonoBehaviour
{
    private GameObject player_S;
    void Start()
    {
        if (static_parameters.teaching_stop < 100 || static_parameters.isTeaching == true)
        {
            Destroy(gameObject);
        }
        player_S = GameObject.Find("Player_S");
    }

    private void OnTriggerEnter(Collider other)
    {
        // player_S.transform.localPosition = new Vector3(0, 0, 40);
        SceneManager.LoadScene("magic_house");
    }
}
