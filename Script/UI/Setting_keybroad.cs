using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Setting_keybroad : MonoBehaviour
{
    public GameObject Player_S, Camera;
    public GameObject ESC;
    public GameObject _Continue, _Setting, _Back_Menu, _Exit;

    public Image Continue_icon_on, Setting_icon_on, Back_Menu_icon_on, Exit_icon_on;
    public Image Continue_icon_off, Setting_icon_off, Back_Menu_icon_off, Exit_icon_off;

    int key_count = 1, key_count_max = 4;
    // Start is called before the first frame update
    static public bool ESC_col = false;
    public Canvas canvas;
    void Start()
    {
        DontDestroyOnLoad(this);
        canvas.sortingOrder = 1000;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (ESC_col)
            {
                ESC_false();
            }
            else
            {
                ESC_col = true;
                Time.timeScale = 0;
                ESC.SetActive(true);
            }
        }

        if (ESC_col)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                key_count = (key_count == 1) ? key_count_max : key_count - 1;
                key_change();
            }

            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                key_count = (key_count == key_count_max) ? 1 : key_count + 1;
                key_change();
            }

            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                switch (key_count)
                {
                    case 1: Game_Continue(); break;
                    case 2: Game_Setting(); break;
                    case 3: Game_Back_Menu(); break;
                    case 4: Game_Exit(); break;
                }
            }
        }
    }

    private void key_change()
    {
        switch (key_count)
        {
            case 1: OnPointerEnter_Continue(); break;
            case 2: OnPointerEnter_Setting(); break;
            case 3: OnPointerEnter_Back_Menu(); break;
            case 4: OnPointerEnter_Exit(); break;
        }
    }

    public void Game_Continue() => ESC_false();
    public void Game_Setting() => _Setting.SetActive(true);
    public void Game_Back_Menu() => Back_Menu();
    public void Game_Exit() => Application.Quit();

    private void UpdateIcons(bool _continue, bool setting, bool back_menu, bool exit)
    {
        Continue_icon_on.gameObject.SetActive(_continue);
        Continue_icon_off.gameObject.SetActive(!_continue);
        Setting_icon_on.gameObject.SetActive(setting);
        Setting_icon_off.gameObject.SetActive(!setting);
        Back_Menu_icon_on.gameObject.SetActive(back_menu);
        Back_Menu_icon_off.gameObject.SetActive(!back_menu);
        Exit_icon_on.gameObject.SetActive(exit);
        Exit_icon_off.gameObject.SetActive(!exit);
    }

    private void ESC_false()
    {
        ESC_col = false;
        Time.timeScale = 1;
        ESC.SetActive(false);
    }

    private void Back_Menu()
    {
        ESC_false();
        SceneManager.LoadScene("menu");
        Destroy(Player_S);
        Destroy(Camera);
        Destroy(gameObject);
    }

    public void OnPointerEnter_Continue()
    {
        key_count = 1;
        UpdateIcons(true, false, false, false);
    }

    public void OnPointerEnter_Setting()
    {
        key_count = 2;
        UpdateIcons(false, true, false, false);
    }

    public void OnPointerEnter_Back_Menu()
    {
        key_count = 3;
        UpdateIcons(false, false, true, false);
    }

    public void OnPointerEnter_Exit()
    {
        key_count = 4;
        UpdateIcons(false, false, false, true);
    }
}
