using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teaching_TextF : MonoBehaviour
{
    public GameObject Main_character_object, Magician_object;
    public Image Main_character, Magician;
    public Sprite[] Main_character_face;
    public Sprite[] Magician_face;
    public Text name_text, talk_text;
    uint talk_number = 0;

    void Start()
    {
        static_parameters.teaching_stop = -1;
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && static_parameters.teaching_stop < 5)
        {
            switch (talk_number)
            {
                case 0:
                    static_parameters.teaching_stop = -1;
                    Main_character.sprite = Main_character_face[0];
                    name_text.text = "主角";
                    talk_text.text = "這是什麼地方？";
                    break;
                case 1:
                    Magician.sprite = Magician_face[1];
                    name_text.text = "魔法師";
                    talk_text.text = "這裡是魔法學院，你是新生嗎？";
                    break;
            }
            talk_number++;
        }
    }
}
