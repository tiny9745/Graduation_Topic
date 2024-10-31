using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sound_BGM : MonoBehaviour
{
    public AudioSource BGM_sound;
    public AudioSource SE_sound;
    public AudioClip[] BGM_clip;
    public AudioClip[] SE_clip;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
        BGM_sound.volume=static_parameters._BGM_volue;
        if (SceneManager.GetActiveScene().name == "magic_house")
        {
            BGM_sound.clip = BGM_clip[0];
        }
        else if (SceneManager.GetActiveScene().buildIndex >= 7 && SceneManager.GetActiveScene().buildIndex <= 26)
        {
            BGM_sound.clip = BGM_clip[1];
        }
        BGM_sound.Play();
    }
}
