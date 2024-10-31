using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_menu : MonoBehaviour
{
    public GameObject _Setting_menu;
    public GameObject _Main_menu;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Game_Play()
    {
        SceneManager.LoadScene("prohibit");
    }

    public void Game_Setting()
    {
        _Setting_menu.SetActive(true);
    }
    public void Game_Exit()
    {
        Application.Quit();
    }
}
