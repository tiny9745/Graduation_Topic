using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teaching_MC_ani : MonoBehaviour
{
    public Animator magicianAnimator;

    // Update is called once per frame
    void Update()
    {
        if (static_parameters.teaching_stop == 5)
        {
            magicianAnimator.SetBool("ntfx", true);
        }
        if (static_parameters.teaching_stop >= 7)
        {
            magicianAnimator.SetBool("ntfx", false);
        }
    }
}
