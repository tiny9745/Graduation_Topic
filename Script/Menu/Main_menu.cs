using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_menu : MonoBehaviour
{
    public GameObject _Setting_menu;
    public GameObject _Main_menu;
    public AudioSource SE_sound;
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
        SE_sound.volume = static_parameters._SE_volue;
        SE_sound.Play();
        SceneManager.LoadScene("prohibit");
    }

    public void Game_Setting()
    {
        SE_sound.volume = static_parameters._SE_volue;
        SE_sound.Play();
        _Setting_menu.SetActive(true);
    }
    public void Game_Exit()
    {
        SE_sound.Play();
        Application.Quit();
    }
}
