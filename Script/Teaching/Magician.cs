using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magician : MonoBehaviour
{
    public SpriteRenderer magicianSprite;
    public Sprite magicianSprites;
    public Animator magicianAnimator, magicianAnimator2;
    void Start()
    {
        if (static_parameters.teaching_stop >= 100 && static_parameters.isTeaching == false)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (static_parameters.teaching_stop >= 100 && static_parameters.isTeaching == false)
        {
            Destroy(gameObject);
        }
        if (static_parameters.teaching_stop == 5)
        {
            magicianAnimator.SetBool("ntfx", true);
            magicianAnimator2.SetBool("ntfx", true);
        }
        if (static_parameters.teaching_stop == 7)
        {
            magicianAnimator.SetBool("ntfx", false);
            magicianAnimator2.SetBool("ntfx", false);
            magicianSprite.sprite = magicianSprites;
        }
    }
}
