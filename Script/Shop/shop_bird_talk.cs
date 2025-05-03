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
    void Start()
    {

    }

    // Update is called once per frame

    void OnTriggerEnter(Collider other)
    {
        F_button_object.sprite = F_button;
    }
    void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("F key pressed");
            bird_talk.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space))
        {
            talk_number++;
            shop_bird_Talk();
        }
    }
    void OnTriggerExit(Collider other)
    {
        F_button_object.sprite = null;
    }

    void shop_bird_Talk()
    {
        if (talk_count != 0) Random.Range(1, 5);
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
                    Main_character_face.sprite = Main_character_face_change[0];
                    bird_body.sprite = bird_face_change[0];
                    name_text.text = "婆婆";
                    talk_text.text = "就是賣一些……ZZzzz……";
                    break;
                case 2:
                    Main_character_face.sprite = Main_character_face_change[0];
                    bird_body.sprite = bird_face_change[1];
                    name_text.text = "鸚鵡";
                    talk_text.text = "走過路過千萬不要錯過嘎，全國最豐富最優秀的商品都在這～裡嘎！";
                    break;
                case 3:
                    Main_character_face.sprite = Main_character_face_change[0];
                    bird_body.sprite = bird_face_change[1];
                    name_text.text = "鸚鵡";
                    talk_text.text = "唉唷可愛的小孩嘎～這裡有賣好吃的糖果餅乾～嘎！";
                    break;
                case 4:
                    Main_character_face.sprite = Main_character_face_change[0];
                    bird_body.sprite = bird_face_change[1];
                    name_text.text = "鸚鵡";
                    talk_text.text = "都是熱銷款，要買要快嘎！";
                    break;
                case 5:
                    talk_number++;
                    talk_count = 0;
                    bird_talk.SetActive(false);
                    break;
            }
        }
        void talk_count01()
        {
            switch (talk_number)
            {
                case 0:
                    Main_character_face.sprite = Main_character_face_change[0];
                    bird_body.sprite = bird_face_change[1];
                    name_text.text = "鸚鵡";
                    talk_text.text = "這可是今天新鮮製成的蛋糕嘎！要趕快買來吃嘎！吃了保證妳元氣滿滿嘎！";
                    break;
                case 1:
                    bird_talk.SetActive(false);
                    talk_count = 0;
                    break;
            }
        }
        void talk_count02()
        {
            switch (talk_number)
            {
                case 0:
                    Main_character_face.sprite = Main_character_face_change[0];
                    bird_body.sprite = bird_face_change[2];
                    name_text.text = "鸚鵡";
                    talk_text.text = "馬卡龍要烤得好可是需要很多功夫的嘎！賣妳這樣已經很便宜了嘎！";
                    break;
                case 1:
                    talk_count = 0;
                    bird_talk.SetActive(false);
                    break;
            }
        }
        void talk_count03()
        {
            switch (talk_number)
            {
                case 0:
                    Main_character_face.sprite = Main_character_face_change[0];
                    bird_body.sprite = bird_face_change[0];
                    name_text.text = "鸚鵡";
                    talk_text.text = "手工餅乾酥脆爽口嘎，絕對不會嗑斷牙嘎！如何嘎，要再多買一包嗎嘎？";
                    break;
                case 1:
                    talk_count = 0;
                    bird_talk.SetActive(false);
                    break;
            }
        }
        void talk_count04()
        {
            switch (talk_number)
            {
                case 0:
                    Main_character_face.sprite = Main_character_face_change[0];
                    bird_body.sprite = bird_face_change[0];
                    name_text.text = "鸚鵡";
                    talk_text.text = "甘甜不膩的糖果大人小孩鸚鵡都愛嘎！小孩，快買幾十幾包回去吃吧嘎！";
                    break;
                case 1:
                    talk_count = 0;
                    bird_talk.SetActive(false);
                    break;
            }
        }
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
