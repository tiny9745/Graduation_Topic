using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Setting_menu : MonoBehaviour
{
    public GameObject _Setting_menu;
    public Slider BGM_control;
    public Slider SE_control;

    public AudioSource BGM_sound;
    public AudioSource SE_sound;

    public Image Music_icon_on, Teach_icon_on, Back_icon_on;
    public Image Music_icon_off, Teach_icon_off, Back_icon_off;

    public Image BGM_image_on, SE_image_on;
    public Image BGM_image_off, SE_image_off;

    private int key_count = 1;
    private const int key_count_max = 3;

    void Start()
    {
        OnPointerEnter_Music(); // 預設選擇第一個選項
        BGM_control.onValueChanged.AddListener(delegate { Setting_BGM(); });
        SE_control.onValueChanged.AddListener(delegate { Setting_SE(); });
    }

    void Update()
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
                case 3: Setting_back(); break; // 返回選項
            }
        }
    }

    private void key_change()
    {
        switch (key_count)
        {
            case 1: OnPointerEnter_Music(); break;
            case 2: OnPointerEnter_Teach(); break;
            case 3: OnPointerEnter_Back(); break;
        }
    }

    public void Setting_back()
    {
        SE_sound.Play();
        key_count = 1;
        _Setting_menu.SetActive(false);
    }

    public void Setting_SE()
    {
        SE_sound.volume = SE_control.value;
        static_parameters._SE_volue = SE_sound.volume;

        SE_image_off.gameObject.SetActive(SE_control.value == 0);
        SE_image_on.gameObject.SetActive(SE_control.value > 0);
    }

    public void Setting_BGM()
    {
        BGM_sound.volume = BGM_control.value;
        static_parameters._BGM_volue = BGM_sound.volume;

        BGM_image_off.gameObject.SetActive(BGM_control.value == 0);
        BGM_image_on.gameObject.SetActive(BGM_control.value > 0);
    }

    private void UpdateIcons(bool music, bool teach, bool back)
    {
        Music_icon_on.gameObject.SetActive(music);
        Music_icon_off.gameObject.SetActive(!music);

        Teach_icon_on.gameObject.SetActive(teach);
        Teach_icon_off.gameObject.SetActive(!teach);

        Back_icon_on.gameObject.SetActive(back);
        Back_icon_off.gameObject.SetActive(!back);
    }

    // 方法供 EventTrigger 使用
    public void OnPointerEnter_Music()
    {
        key_count = 1;
        UpdateIcons(true, false, false);
    }

    public void OnPointerEnter_Teach()
    {
        key_count = 2;
        UpdateIcons(false, true, false);
    }

    public void OnPointerEnter_Back()
    {
        key_count = 3;
        UpdateIcons(false, false, true);
    }
}
