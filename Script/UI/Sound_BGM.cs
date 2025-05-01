using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sound_BGM : MonoBehaviour
{
    public AudioSource BGM_sound;
    public AudioClip[] BGM_clip;

    // public AudioClip[] SE_clip;
    // public AudioSource SE_sound;

    void Start()
    {
        BGM_sound.clip = BGM_clip[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (static_parameters._BGM_volue != BGM_sound.volume)
        {
            BGM_sound.volume = static_parameters._BGM_volue;
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        BGM_Play_change();
    }

    private void BGM_Play_change()
    {
        BGM_sound.volume = static_parameters._BGM_volue;
        if (SceneManager.GetActiveScene().name == "magic_house" || SceneManager.GetActiveScene().name == "house_outside")
        {
            BGM_sound.clip = BGM_clip[0];
        }
        else if (static_parameters.into_gameFight_Levels == 5)
        {
            BGM_sound.clip = BGM_clip[2];
        }
        else if (static_parameters.into_gameFight_Levels == 6)
        {
            BGM_sound.clip = BGM_clip[3];
        }
        else
        {
            BGM_sound.clip = BGM_clip[1];
        }
        if (!Boss_col.BOSS_live)BGM_sound.clip = BGM_clip[2];
        BGM_sound.Play();
    }
}
