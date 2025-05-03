using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shop_bird_talk : MonoBehaviour
{
    // Start is called before the first frame update

    int talk_count = 0;
    int talk_number = 0;
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
        if (talk_count == 0)
        {
            talk_count = 1;
            GameObject.Find("shop_bird").GetComponent<Animator>().SetTrigger("talk_1");
            GameObject.Find("shop_bird").GetComponent<Animator>().SetBool("talk", true);
        }
        else if (talk_count == 1)
        {
            talk_count = 2;
            GameObject.Find("shop_bird").GetComponent<Animator>().SetTrigger("talk_2");
            GameObject.Find("shop_bird").GetComponent<Animator>().SetBool("talk", true);
        }
        else if (talk_count == 2)
        {
            talk_count = 3;
            GameObject.Find("shop_bird").GetComponent<Animator>().SetTrigger("talk_3");
            GameObject.Find("shop_bird").GetComponent<Animator>().SetBool("talk", true);
        }
        else if (talk_count == 3)
        {
            talk_count = 0;
            GameObject.Find("shop_bird").GetComponent<Animator>().SetTrigger("talk_4");
            GameObject.Find("shop_bird").GetComponent<Animator>().SetBool("talk", true);
        }
    }
}
