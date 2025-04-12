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
    static public int talk_number = 0;
    public int into_talk_step = 0;
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
            Magician_Talk();
        }
    }

    public void Magician_Talk()
    {
        Debug.Log("talk_number = " + talk_number);
        Debug.Log("into_talk_step = " + into_talk_step);
        dialog_box.SetActive(true);
        if (talk_number == 0)
        {
            talk_number_0();
        }
        else if (talk_number == 1)
        {
            talk_number_1();
        }
        else if (talk_number == 2)
        {
            talk_number_2();
        }
        else
        {
            switch (talk_number)
            {
                case 3:
                    talk_number_3();
                    break;
                case 4:
                    talk_number_4();
                    break;
                case 5:
                    talk_number_5();
                    break;
                case 6:
                    talk_number_6();
                    break;
                case 7:
                    talk_number_7();
                    break;
                case 8:
                    talk_number_8();
                    break;
                case 9:
                    talk_number_9();
                    break;
                case 10:
                    talk_number_10();
                    break;
                case 11:
                    talk_number_11();
                    break;
                case 12:
                    talk_number_12();
                    break;
                case 13:
                    talk_number_13();
                    break;
                case 14:
                    talk_number_14();
                    break;
                case 15:
                    talk_number_15();
                    break;
                case 16:
                    talk_number_16();
                    break;
                case 17:
                    talk_number_17();
                    break;
                case 18:
                    talk_number_18();
                    break;
                case 19:
                    talk_number_19();
                    break;
                case 20:
                    talk_number_20();
                    break;
                case 21:
                    talk_number_21();
                    break;
                case 22:
                    talk_number_22();
                    break;
            }
        }
        into_talk_step++;
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
    void talk_number_1()
    {
        switch (into_talk_step)
        {
            case 0:
                main_talk();
                Main_character_face.sprite = Main_character_face_change[0];
                Magician_face.sprite = Magician_face_change[0];
                name_text.text = "曦然";
                talk_text.text = "妳剛剛說到了姜米，他是誰？";
                break;
            case 1:
                magic_talk();
                Magician_face.sprite = Magician_face_change[3];
                name_text.text = "莓莓";
                talk_text.text = "嗯……算是我的青梅竹馬吧，他是王宮的士兵長，雖然不善言辭，但對我很好。";
                break;
            case 2:
                main_talk();
                Main_character_face.sprite = Main_character_face_change[0];
                name_text.text = "曦然";
                talk_text.text = "那你的青梅竹馬怎麼會帶一堆士兵來抓你？";
                break;
            case 3:
                magic_talk();
                Magician_face.sprite = Magician_face_change[4];
                name_text.text = "莓莓";
                talk_text.text = "長話短說就是、呃、我不小心……";
                break;
            case 4:
                magic_talk();
                name_text.text = "莓莓";
                talk_text.text = "溜去王宮裡找姜米時炸了牆壁！所以才會被下令追捕吧！嗯！就是這樣！";
                break;
            case 5:
                main_talk();
                Main_character_face.sprite = Main_character_face_change[3];
                name_text.text = "曦然";
                talk_text.text = "呃，原來我剛剛是在幫忙罪犯……";
                break;
            case 6:
                magic_talk();
                Magician_face.sprite = Magician_face_change[2];
                name_text.text = "莓莓";
                talk_text.text = "我才不是罪犯咧！等一切結束，我會去向王后賠罪啦！";
                break;
            default:
                talk_number++;
                open_level_up();
                break;
        }
    }
    void talk_number_2()
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
    void talk_number_3()
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
                open_level_up();
                break;
        }
    }
    void talk_number_4()
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
                open_level_up();
                break;
        }
    }
    void talk_number_5()
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
                open_level_up();
                break;
        }
    }
    void talk_number_6()
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
                open_level_up();
                break;
        }
    }
    void talk_number_7()
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
                open_level_up();
                break;
        }
    }
    void talk_number_8()
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
                open_level_up();
                break;
        }
    }
    void talk_number_9()
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
                open_level_up();
                break;
        }
    }
    void talk_number_10()
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
                open_level_up();
                break;
        }
    }
    void talk_number_11()
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
                open_level_up();
                break;
        }
    }
    void talk_number_12()
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
                open_level_up();
                break;
        }
    }
    void talk_number_13()
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
                open_level_up();
                break;
        }
    }
    void talk_number_14()
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
                open_level_up();
                break;
        }
    }
    void talk_number_15()
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
                open_level_up();
                break;
        }
    }
    void talk_number_16()
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
                open_level_up();
                break;
        }
    }
    void talk_number_17()
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
                open_level_up();
                break;
        }
    }
    void talk_number_18()
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
                open_level_up();
                break;
        }
    }
    void talk_number_19()
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
                open_level_up();
                break;
        }
    }
    void talk_number_20()
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
                open_level_up();
                break;
        }
    }
    void talk_number_21()
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
                open_level_up();
                break;
        }
    }
    void talk_number_22()
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
                open_level_up();
                break;
        }
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
