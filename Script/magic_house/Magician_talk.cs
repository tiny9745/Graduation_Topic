using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Magician_talk : MonoBehaviour
{
    public GameObject dialog_box;
    public Image Main_character_face, Magician_face;
    public Image Main_character_body, Magician_body;
    public Sprite[] Main_character_face_change;
    public Sprite[] Magician_face_change;
    public Text name_text, talk_text, Narration_text;
    int talk_number = 0, into_talk_step = 0;
    public UI_Place UI_place;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && UI_place.isUpgrade)
        {
            Debug.Log("talk_number = " + talk_number);
            Debug.Log("into_talk_step = " + into_talk_step);
            Magician_Talk();
        }
    }

    public void Magician_Talk()
    {
        dialog_box.SetActive(true);
        if (talk_number == 0)
        {
            talk_number_0();
        }
        else if (talk_number == 1)
        {

        }
        else if (talk_number == 2)
        {

        }
        else
        {
            talk_number = Random.Range(3, 23);
            switch (talk_number)
            {
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
                case 7:
                    break;
                case 8:
                    break;
                case 9:
                    break;
                case 10:
                    break;
                case 11:
                    break;
                case 12:
                    break;
                case 13:
                    break;
                case 14:
                    break;
                case 15:
                    break;
                case 16:
                    break;
                case 17:
                    break;
                case 18:
                    break;
                case 19:
                    break;
                case 20:
                    break;
                case 21:
                    break;
                case 22:
                    break;
            }
        }
        into_talk_step++;
    }

    void magic_talk()
    {
        Main_character_face.color = new Color(0.5f, 0.5f, 0.5f, 1);
        Magician_face.color = new Color(1, 1, 1, 1);
        Main_character_body.color = new Color(0.5f, 0.5f, 0.5f, 1);
        Magician_body.color = new Color(1, 1, 1, 1);
    }
    void main_talk()
    {
        Main_character_face.color = new Color(1, 1, 1, 1);
        Magician_face.color = new Color(0.5f, 0.5f, 0.5f, 1);
        Main_character_body.color = new Color(1, 1, 1, 1);
        Magician_body.color = new Color(0.5f, 0.5f, 0.5f, 1);
    }
    void not_talk()
    {
        Main_character_face.color = new Color(0.5f, 0.5f, 0.5f, 1);
        Magician_face.color = new Color(0.5f, 0.5f, 0.5f, 1);
        Main_character_body.color = new Color(0.5f, 0.5f, 0.5f, 1);
        Magician_body.color = new Color(0.5f, 0.5f, 0.5f, 1);
    }


    void talk_number_0()
    {
        switch (into_talk_step)
        {
            case 0:
                main_talk();
                Main_character_face.sprite = Main_character_face_change[0];
                Magician_face.sprite = Magician_face_change[0];
                name_text.text = "曦然";
                talk_text.text = "城堡怎麼去?";
                break;
            case 1:
                magic_talk();
                Main_character_face.sprite = Main_character_face_change[0];
                Magician_face.sprite = Magician_face_change[0];
                name_text.text = "莓莓";
                talk_text.text = "只要看著城堡的屋頂方向，一直走就會到囉。";
                break;
            default:
                talk_number++;
                open_level_up();
                break;
        }
    }

    void open_level_up()
    {
        UI_place.UI1();
        close_magician_talk();
    }
    public void close_magician_talk()
    {
        into_talk_step = 0;
        this.gameObject.SetActive(false);
    }
}
