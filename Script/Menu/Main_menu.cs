using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Main_menu : MonoBehaviour
{
    public GameObject _Setting_menu;
    public GameObject _Main_menu;
    public AudioSource SE_sound;
    public Image Play_icon_on, Setting_icon_on, Information_icon_on, Exit_icon_on;
    public Image Play_icon_off, Setting_icon_off, Information_icon_off, Exit_icon_off;
    int key_count = 1, key_count_max = 4; bool isSetting = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isSetting == false)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (key_count == 1)
                {
                    key_count = key_count_max;
                }
                else
                {
                    key_count--;
                }
                key_change();
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (key_count == key_count_max)
                {
                    key_count = 1;
                }
                else
                {
                    key_count++;
                }
                key_change();
            }
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                switch (key_count)
                {
                    case 1:
                        Game_Play();
                        break;
                    case 2:
                        Game_Setting();
                        break;
                    case 3:
                        Game_Information();
                        break;
                    case 4:
                        Game_Exit();
                        break;
                }
            }
        }
        if (_Setting_menu.activeSelf == true)
        {
            isSetting = true;
        }
        else
        {
            isSetting = false;
        }
    }
    private void key_change()
    {
        switch (key_count)
        {
            case 1:
                Play_icon_on_click();
                break;
            case 2:
                Setting_icon_on_click();
                break;
            case 3:
                Information_icon_on_click();
                break;
            case 4:
                Exit_icon_on_click();
                break;
        }
    }

    public void Game_Play()
    {
        SE_sound.volume = static_parameters._SE_volue;
        SE_sound.Play();
        SceneManager.LoadScene("prohibit");
    }

    public void Game_Setting()
    {
        _Setting_menu.SetActive(true);
    }
    private void Game_Information()
    {
        SceneManager.LoadScene("Information");
    }

    public void Game_Exit()
    {
        Application.Quit();
    }
    public void Play_icon_on_click()
    {
        key_count = 1;
        Play_icon_on.gameObject.SetActive(true);
        Play_icon_off.gameObject.SetActive(false);
        Setting_icon_on.gameObject.SetActive(false);
        Setting_icon_off.gameObject.SetActive(true);
        Information_icon_on.gameObject.SetActive(false);
        Information_icon_off.gameObject.SetActive(true);
        Exit_icon_on.gameObject.SetActive(false);
        Exit_icon_off.gameObject.SetActive(true);
    }

    public void Setting_icon_on_click()
    {
        key_count = 2;
        Play_icon_on.gameObject.SetActive(false);
        Play_icon_off.gameObject.SetActive(true);
        Setting_icon_on.gameObject.SetActive(true);
        Setting_icon_off.gameObject.SetActive(false);
        Information_icon_on.gameObject.SetActive(false);
        Information_icon_off.gameObject.SetActive(true);
        Exit_icon_on.gameObject.SetActive(false);
        Exit_icon_off.gameObject.SetActive(true);
    }

    public void Information_icon_on_click()
    {
        key_count = 3;
        Play_icon_on.gameObject.SetActive(false);
        Play_icon_off.gameObject.SetActive(true);
        Setting_icon_on.gameObject.SetActive(false);
        Setting_icon_off.gameObject.SetActive(true);
        Information_icon_on.gameObject.SetActive(true);
        Information_icon_off.gameObject.SetActive(false);
        Exit_icon_on.gameObject.SetActive(false);
        Exit_icon_off.gameObject.SetActive(true);
    }
    public void Exit_icon_on_click()
    {
        key_count = 4;
        Play_icon_on.gameObject.SetActive(false);
        Play_icon_off.gameObject.SetActive(true);
        Setting_icon_on.gameObject.SetActive(false);
        Setting_icon_off.gameObject.SetActive(true);
        Information_icon_on.gameObject.SetActive(false);
        Information_icon_off.gameObject.SetActive(true);
        Exit_icon_on.gameObject.SetActive(true);
        Exit_icon_off.gameObject.SetActive(false);
    }
}
