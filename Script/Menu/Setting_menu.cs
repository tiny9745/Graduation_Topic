using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Setting_menu : MonoBehaviour
{
    public GameObject _Setting_menu;
    public Slider BGM_control;
    public Slider SE_control;

    public AudioClip SE_slip;
    public AudioSource BGM_sound;
    public AudioSource SE_sound;
    // Start is called before the first frame update
    void Start()
    {
        BGM_control.onValueChanged.AddListener(delegate { Setting_BGM(); });
        SE_control.onValueChanged.AddListener(delegate { Setting_SE(); });
    }

    // Update is called once per frame
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
        Debug.Log("SE_sound.volume:" + SE_sound.volume);
    }

    public void Setting_BGM()
    {
        BGM_sound.volume = BGM_control.value;
        static_parameters._BGM_volue = BGM_sound.volume;
    }
}
