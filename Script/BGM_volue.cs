using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM_volue : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = static_parameters._BGM_volue;
    }

    void Update()
    {
        if (audioSource.volume != static_parameters._BGM_volue)
        {
            audioSource.volume = static_parameters._BGM_volue;
        }
    }
}
