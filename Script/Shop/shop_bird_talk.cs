using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shop_bird_talk : MonoBehaviour
{
    // Start is called before the first frame update

    int talk_count = 0;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && !Setting_keybroad.ESC_col)
        {
            shop_bird_Talk();
        }
    }

    void shop_bird_Talk()
    {

    }
}
