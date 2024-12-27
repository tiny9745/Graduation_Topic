using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; // 引入事件系統

public class Setting_menu : MonoBehaviour, IPointerEnterHandler
{
    public GameObject _Setting_menu;
    public Slider BGM_control;
    public Slider SE_control;

    public AudioClip SE_slip;
    public AudioSource BGM_sound;
    public AudioSource SE_sound;
    public Image BGM_image_on, SE_image_on;
    public Image BGM_image_off, SE_image_off;
    public Image Music_icon_on, Teach_icon_on, Back_icon_on;
    public Image Music_icon_off, Teach_icon_off, Back_icon_off;

    void Start()
    {
        BGM_control.onValueChanged.AddListener(delegate { Setting_BGM(); });
        SE_control.onValueChanged.AddListener(delegate { Setting_SE(); });
    }

    void Update()
    {
    }

    public void Setting_back()
    {
        SE_sound.Play();
        _Setting_menu.SetActive(false);
    }

    public void Setting_SE()
    {
        SE_sound.volume = SE_control.value;
        static_parameters._SE_volue = SE_sound.volume;
        if (SE_control.value == 0)
        {
            SE_image_off.gameObject.SetActive(true);
            SE_image_on.gameObject.SetActive(false);
        }
        else
        {
            SE_image_off.gameObject.SetActive(false);
            SE_image_on.gameObject.SetActive(true);
        }
    }

    public void Setting_BGM()
    {
        BGM_sound.volume = BGM_control.value;
        static_parameters._BGM_volue = BGM_sound.volume;
        if (BGM_control.value == 0)
        {
            BGM_image_off.gameObject.SetActive(true);
            BGM_image_on.gameObject.SetActive(false);
        }
        else
        {
            BGM_image_off.gameObject.SetActive(false);
            BGM_image_on.gameObject.SetActive(true);
        }
    }

    public void Music_icon_on_click()
    {
        Music_icon_on.gameObject.SetActive(true);
        Music_icon_off.gameObject.SetActive(false);
        Teach_icon_on.gameObject.SetActive(false);
        Teach_icon_off.gameObject.SetActive(true);
        Back_icon_on.gameObject.SetActive(false);
        Back_icon_off.gameObject.SetActive(true);
    }

    public void Teach_icon_on_click()
    {
        Music_icon_on.gameObject.SetActive(false);
        Music_icon_off.gameObject.SetActive(true);
        Teach_icon_on.gameObject.SetActive(true);
        Teach_icon_off.gameObject.SetActive(false);
        Back_icon_on.gameObject.SetActive(false);
        Back_icon_off.gameObject.SetActive(true);
    }

    public void Back_icon_on_click()
    {
        Music_icon_on.gameObject.SetActive(false);
        Music_icon_off.gameObject.SetActive(true);
        Teach_icon_on.gameObject.SetActive(false);
        Teach_icon_off.gameObject.SetActive(true);
        Back_icon_on.gameObject.SetActive(true);
        Back_icon_off.gameObject.SetActive(false);
    }

    // 懸浮游標觸發的功能
    public void OnPointerEnter(PointerEventData eventData)
    {
        // 根據當前懸浮的物件執行對應方法
        if (eventData.pointerEnter == Music_icon_on.gameObject || eventData.pointerEnter == Music_icon_off.gameObject)
        {
            Music_icon_on_click();
        }
        else if (eventData.pointerEnter == Teach_icon_on.gameObject || eventData.pointerEnter == Teach_icon_off.gameObject)
        {
            Teach_icon_on_click();
        }
        else if (eventData.pointerEnter == Back_icon_on.gameObject || eventData.pointerEnter == Back_icon_off.gameObject)
        {
            Back_icon_on_click();
        }
    }
}
