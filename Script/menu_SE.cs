using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu_SE : MonoBehaviour
{
    public void SE_Play_change(AudioSource clip)
    {
        clip.volume = static_parameters._SE_volue * static_parameters._All_sound;
        clip.Play();
    }
}
