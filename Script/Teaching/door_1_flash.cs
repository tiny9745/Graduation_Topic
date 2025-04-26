using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door_1_flash : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(1, 1, 1, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (static_parameters.teaching_stop == 1)
        {
            spriteRenderer.color = new Color(1, 1, 1, 1f);
        }
        else
        {
            spriteRenderer.color = new Color(1, 1, 1, 0f);
        }
    }
}
