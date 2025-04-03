using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class srtting_ESC : MonoBehaviour
{
    public GameObject _Setting_menu;
    public Slider All_sound_control;
    public Slider BGM_control;
    public Slider SE_control;

    public Image Music_icon_on, Teach_icon_on, Back_icon_on;
    public Image Music_icon_off, Teach_icon_off, Back_icon_off;

    public Image All_image_on, All_image_off;
    public Image BGM_image_on, SE_image_on;
    public Image BGM_image_off, SE_image_off;

    public Button BGM_sound_button_on, SE_sound_button_on;
    public Button BGM_sound_button_off, SE_sound_button_off;

    private int key_count = 1;
    private const int key_count_max = 3;

    void Start()
    {
        OnPointerEnter_Music(); // 預設選擇第一個選項
        All_sound_control.value = static_parameters._All_sound;
        BGM_control.value = static_parameters._BGM_volue;
        SE_control.value = static_parameters._SE_volue;
        All_sound_control.onValueChanged.AddListener(delegate { Setting_All_sound(); });
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
        // SE_sound.Play();
        key_count = 1;
        _Setting_menu.SetActive(false);
    }
    public void Setting_All_sound()
    {
        AudioListener.volume = All_sound_control.value;
        static_parameters._All_sound = All_sound_control.value;
        static_parameters._SE_volue = SE_control.value * All_sound_control.value;
        static_parameters._BGM_volue = BGM_control.value * All_sound_control.value;
        Image fillImage_SE = SE_control.GetComponentsInChildren<Image>()[1];
        Image fillImage_BGM = BGM_control.GetComponentsInChildren<Image>()[1];

        if (All_sound_control.value == 0)
        {
            All_image_off.gameObject.SetActive(true);
            All_image_on.gameObject.SetActive(false);
            SE_image_off.gameObject.SetActive(true);
            SE_image_on.gameObject.SetActive(false);
            BGM_image_off.gameObject.SetActive(true);
            BGM_image_on.gameObject.SetActive(false);
            fillImage_SE.color = new Color(252 / 255f, 178 / 255f, 197 / 255f, 0.5f);
            fillImage_BGM.color = new Color(252 / 255f, 178 / 255f, 197 / 255f, 0.5f);
            BGM_control.interactable = false;
            SE_control.interactable = false;
        }
        else
        {
            All_image_off.gameObject.SetActive(false);
            All_image_on.gameObject.SetActive(true);
            fillImage_SE.color = new Color(252 / 255f, 178 / 255f, 197 / 255f, 1);
            fillImage_BGM.color = new Color(252 / 255f, 178 / 255f, 197 / 255f, 1);
            BGM_control.interactable = true;
            SE_control.interactable = true;
            if (SE_control.value > 0)
            {
                SE_image_off.gameObject.SetActive(false);
                SE_image_on.gameObject.SetActive(true);
            }
            if (BGM_control.value > 0)
            {
                BGM_image_off.gameObject.SetActive(false);
                BGM_image_on.gameObject.SetActive(true);
            }
        }
    }

    public void Setting_SE()
    {
        static_parameters._SE_volue = SE_control.value;
        SE_image_off.gameObject.SetActive(SE_control.value == 0);
        SE_image_on.gameObject.SetActive(SE_control.value > 0);
    }

    public void Setting_BGM()
    {
        static_parameters._BGM_volue = BGM_control.value;
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

    public void click_All_sound()
    {
        if (All_sound_control.value == 0)
        {
            BGM_control.enabled = true;
            SE_control.enabled = true;
            BGM_sound_button_on.enabled = true;
            SE_sound_button_on.enabled = true;
            BGM_sound_button_off.enabled = true;
            SE_sound_button_off.enabled = true;
            All_sound_control.value = static_parameters._All_sound_tmp;
            BGM_control.value = static_parameters._BGM_volue;
            SE_control.value = static_parameters._SE_volue;
        }
        else
        {
            BGM_control.enabled = false;
            SE_control.enabled = false;
            BGM_sound_button_on.enabled = false;
            SE_sound_button_on.enabled = false;
            BGM_sound_button_off.enabled = false;
            SE_sound_button_off.enabled = false;
            static_parameters._All_sound_tmp = All_sound_control.value;
            All_sound_control.value = 0;
        }
    }
    public void click_BGM_sound()
    {
        if (BGM_control.value == 0)
        {
            BGM_image_off.gameObject.SetActive(false);
            BGM_image_on.gameObject.SetActive(true);
            BGM_control.value = static_parameters._BGM_volue_tmp;
            BGM_control.value = static_parameters._BGM_volue_tmp;
        }
        else
        {
            BGM_image_off.gameObject.SetActive(true);
            BGM_image_on.gameObject.SetActive(false);
            static_parameters._BGM_volue_tmp = BGM_control.value;
            BGM_control.value = 0;
        }
    }
    public void click_SE_sound()
    {
        if (SE_control.value == 0)
        {
            SE_image_off.gameObject.SetActive(false);
            SE_image_on.gameObject.SetActive(true);
            SE_control.value = static_parameters._SE_volue_tmp;
            SE_control.value = static_parameters._SE_volue_tmp;
        }
        else
        {
            SE_image_off.gameObject.SetActive(true);
            SE_image_on.gameObject.SetActive(false);
            static_parameters._SE_volue_tmp = SE_control.value;
            SE_control.value = 0;
        }
    }
}
