using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SE_volue : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = static_parameters._SE_volue;
    }
}
