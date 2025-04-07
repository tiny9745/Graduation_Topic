using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Main_menu : MonoBehaviour
{
    public GameObject _Setting_menu;
    public GameObject _Main_menu;
    public AudioSource SE_sound;
    public AudioClip click, move;
    public Image Play_icon_on, Setting_icon_on, Information_icon_on, Exit_icon_on;
    public Image Play_icon_off, Setting_icon_off, Information_icon_off, Exit_icon_off;
    int key_count = 1, key_count_max = 3;
    bool isSetting = false;

    void Start()
    {
        AudioListener.volume = static_parameters._All_sound;
        OnPointerEnter_Play(); // 預設選擇第一個選項
    }

    void Update()
    {
        if (!isSetting)
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
                    case 1: Game_Play(); break;
                    case 2: Game_Setting(); break;
                    // case 3: Game_Information(); break;
                    case 3: Game_Exit(); break;
                }
            }
        }
        isSetting = _Setting_menu.activeSelf;
    }

    private void key_change()
    {
        switch (key_count)
        {
            case 1: OnPointerEnter_Play(); break;
            case 2: OnPointerEnter_Setting(); break;
            // case 3: OnPointerEnter_Information(); break;
            case 3: OnPointerEnter_Exit(); break;
        }
    }

    public void Game_Play(){
        SE_sound.PlayOneShot(click);
        SceneManager.LoadScene("Comic");
    } 
    public void Game_Setting(){
        SE_sound.PlayOneShot(click);
       _Setting_menu.SetActive(true); 
    }  
    public void Game_Information(){
        SE_sound.PlayOneShot(click);
        SceneManager.LoadScene("Information");
    }
    public void Game_Exit(){
        SE_sound.PlayOneShot(click);
        Application.Quit();
    }

    private void UpdateIcons(bool play, bool setting, bool information, bool exit)
    {
        Play_icon_on.gameObject.SetActive(play);
        Play_icon_off.gameObject.SetActive(!play);
        Setting_icon_on.gameObject.SetActive(setting);
        Setting_icon_off.gameObject.SetActive(!setting);
        // Information_icon_on.gameObject.SetActive(information);
        // Information_icon_off.gameObject.SetActive(!information);
        Exit_icon_on.gameObject.SetActive(exit);
        Exit_icon_off.gameObject.SetActive(!exit);
    }

    // 方法供 EventTrigger 使用
    public void OnPointerEnter_Play()
    {
        key_count = 1;
        SE_sound.PlayOneShot(move);
        UpdateIcons(true, false, false, false);
    }

    public void OnPointerEnter_Setting()
    {
        key_count = 2;
        UpdateIcons(false, true, false, false);
    }

    // public void OnPointerEnter_Information()
    // {
    //     key_count = 3;
    //     UpdateIcons(false, false, true, false);
    // }

    public void OnPointerEnter_Exit()
    {
        key_count = 3;
        UpdateIcons(false, false, false, true);
    }
}
