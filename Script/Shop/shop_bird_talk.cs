using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shop_bird_talk : MonoBehaviour
{
    // Start is called before the first frame update

    int talk_count = 0, talk_number = 0;
    public Text name_text, talk_text;
    public GameObject bird_talk;
    public Image Main_character_face;
    public Image Main_character_body, bird_body;
    public Sprite[] Main_character_face_change;
    public Sprite[] bird_face_change;
    // bool talk_flag = true;
    public SpriteRenderer F_button_object;
    public Sprite F_button;
    bool P1 = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && P1 && !Setting_keybroad.ESC_col && static_parameters.isUpgrade_tmp == false)
        {
            static_parameters.isUpgrade_tmp = true;
            bird_talk.SetActive(true);
            if (talk_count != 0) talk_count = Random.Range(1, 5);
            shop_bird_Talk();
        }
        else if ((Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space)) && P1)
        {
            talk_number++;
            shop_bird_Talk();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            P1 = true;
            F_button_object.sprite = F_button;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            F_button_object.sprite = null;
            P1 = false;
        }
    }

    void shop_bird_Talk()
    {
        switch (talk_count)
        {
            case 0:
                talk_count00();
                break;
            case 1:
                talk_count01();
                break;
            case 2:
                talk_count02();
                break;
            case 3:
                talk_count03();
                break;
            case 4:
                talk_count04();
                break;
        }

        void talk_count00()
        {
            switch (talk_number)
            {
                case 0:
                    main_talk();
                    Main_character_face.sprite = Main_character_face_change[0];
                    bird_body.sprite = bird_face_change[0];
                    name_text.text = "曦然";
                    talk_text.text = "這是什麼攤位？";
                    break;
                case 1:
                    Grma_bird_talk();
                    name_text.text = "婆婆";
                    talk_text.text = "就是賣一些……ZZzzz……";
                    break;
                case 2:
                    bird_body.sprite = bird_face_change[1];
                    name_text.text = "鸚鵡";
                    talk_text.text = "走過路過千萬不要錯過嘎，全國最豐富最優秀的商品都在這～裡嘎！";
                    break;
                case 3:
                    name_text.text = "鸚鵡";
                    talk_text.text = "唉唷可愛的小孩嘎～這裡有賣好吃的糖果餅乾～嘎！";
                    break;
                case 4:
                    name_text.text = "鸚鵡";
                    talk_text.text = "都是熱銷款，要買要快嘎！";
                    break;
                case 5:
                    talk_count = 1;
                    End_talk();
                    break;
            }
        }
        void talk_count01()
        {
            switch (talk_number)
            {
                case 0:
                    Grma_bird_talk();
                    Main_character_face.sprite = Main_character_face_change[0];
                    bird_body.sprite = bird_face_change[1];
                    name_text.text = "鸚鵡";
                    talk_text.text = "這可是今天新鮮製成的蛋糕嘎！";
                    break;
                case 1:
                    talk_text.text = "要趕快買來吃嘎！";
                    break;
                case 2:
                    talk_text.text = "吃了保證妳元氣滿滿嘎！";
                    break;
                case 3:
                    End_talk();
                    break;
            }
        }
        void talk_count02()
        {
            switch (talk_number)
            {
                case 0:
                    Grma_bird_talk();
                    Main_character_face.sprite = Main_character_face_change[0];
                    bird_body.sprite = bird_face_change[2];
                    name_text.text = "鸚鵡";
                    talk_text.text = "馬卡龍要烤得好可是需要很多功夫的嘎！";
                    break;
                case 1:
                    talk_text.text = "賣妳這樣已經很便宜了嘎！";
                    break;
                case 2:
                    End_talk();
                    break;
            }
        }
        void talk_count03()
        {
            switch (talk_number)
            {
                case 0:
                    Grma_bird_talk();
                    Main_character_face.sprite = Main_character_face_change[0];
                    bird_body.sprite = bird_face_change[0];
                    name_text.text = "鸚鵡";
                    talk_text.text = "手工餅乾酥脆爽口嘎，絕對不會嗑斷牙嘎！";
                    break;
                case 1:
                    talk_text.text = "如何嘎，要再多買一包嗎嘎？";
                    break;
                case 2:
                    End_talk();
                    break;
            }
        }
        void talk_count04()
        {
            switch (talk_number)
            {
                case 0:
                    Grma_bird_talk();
                    Main_character_face.sprite = Main_character_face_change[0];
                    bird_body.sprite = bird_face_change[0];
                    name_text.text = "鸚鵡";
                    talk_text.text = "甘甜不膩的糖果大人小孩鸚鵡都愛嘎！";
                    break;
                case 1:
                    talk_text.text = "小孩，快買幾十幾包回去吃吧嘎！";
                    break;
                case 2:
                    End_talk();
                    break;
            }
        }
    }

    void End_talk()
    {
        bird_talk.SetActive(false);
        static_parameters.isUpgrade_tmp = false;
        talk_number = 0;
    }

    void Grma_bird_talk()
    {
        Main_character_face.color = new Color(0.5f, 0.5f, 0.5f, 1);

        Main_character_body.color = new Color(0.5f, 0.5f, 0.5f, 1);
        bird_body.color = new Color(1, 1, 1, 1);
    }
    void main_talk()
    {
        Main_character_face.color = new Color(1, 1, 1, 1);

        Main_character_body.color = new Color(1, 1, 1, 1);
        bird_body.color = new Color(0.5f, 0.5f, 0.5f, 1);
    }
}
