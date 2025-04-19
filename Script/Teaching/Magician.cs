using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magician : MonoBehaviour
{
    private SpriteRenderer magicianSprite;
    public Sprite magicianSprites03;
    public Animator magicianAnimator, magicianAnimator2;
    void Start()
    {
        magicianSprite = GetComponent<SpriteRenderer>();
        // magicianSprites03 = Resources.Load<Sprite>("Sprites/Teaching/Magician/Magician03");
    }

    void Update()
    {
        Debug.Log("magicianSprite.sprite.name:" + magicianSprite.sprite.name);
        if (static_parameters.teaching_stop == 5)
        {
            magicianAnimator.SetBool("ntfx", true);
            magicianAnimator2.SetBool("ntfx", true);
        }
        if (static_parameters.teaching_stop == 7)
        {
            magicianAnimator.SetBool("ntfx", false);
            magicianAnimator2.SetBool("ntfx", false);
            magicianAnimator.enabled = false;
            magicianAnimator2.enabled = false;
            magicianSprite.sprite = magicianSprites03;
        }
    }
}
