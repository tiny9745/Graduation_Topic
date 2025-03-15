using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Deno_back : MonoBehaviour
{
    public GameObject image_complete;
    public GameObject UI, Player_S, Camera;
    // Start is called before the first frame update
    void Start()
    {
        UI = GameObject.Find("UI");
        Player_S = GameObject.Find("Player_S");
        Camera = GameObject.Find("Camera");
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void End_Back_menu()
    {
        Destroy(UI);
        Destroy(Player_S);
        Destroy(Camera);
        SceneManager.LoadScene("menu");
        image_complete.SetActive(false);
    }
}
