using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shop_Fortune_Teller_talk : MonoBehaviour
{

    int talk_count = 0, talk_number = 0;
    public Text name_text, talk_text;
    public GameObject Fortune_Teller_talk;
    public Image Main_character_face;
    public Image Main_character_body, fortune_Teller_body;
    public Sprite[] Main_character_face_change;
    public Sprite[] fortune_Teller_face_change;
    public SpriteRenderer F_button_object;
    public Sprite F_button;
    bool P1 = false;
    int originalSize, smallerSize;

    void Start()
    {
        originalSize = talk_text.fontSize;
        smallerSize = originalSize / 2;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && P1 && !Setting_keybroad.ESC_col && static_parameters.isUpgrade_tmp == false)
        {
            static_parameters.isUpgrade_tmp = true;
            Fortune_Teller_talk.SetActive(true);
            if (talk_count != 0) talk_count = Random.Range(1, 3);
            shop_fortune_Teller_Talk();
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space))
        {
            talk_number++;
            shop_fortune_Teller_Talk();
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
            if (talk_count != 0) P1 = true;
        }
    }

    void shop_fortune_Teller_Talk()
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
        }

        void talk_count00()
        {
            switch (talk_number)
            {
                case 0:
                    fortune_Teller_talk();
                    Main_character_face.sprite = Main_character_face_change[0];
                    fortune_Teller_body.sprite = fortune_Teller_face_change[0];
                    name_text.text = "算命師";
                    talk_text.text = "那邊那個小朋友～要不要吃來自東方的甜點啊～？";
                    break;
                case 1:
                    main_talk();
                    Main_character_face.sprite = Main_character_face_change[3];
                    name_text.text = "曦然";
                    talk_text.text = "……？";
                    break;
                case 2:
                    fortune_Teller_talk();
                    name_text.text = "算命師";
                    talk_text.text = "哎呀別跑！我不是什麼壞人啦！";
                    break;
                case 3:
                    talk_text.text = "要不這樣，我給妳算個命吧？破格免費喔！";
                    break;
                case 4:
                    talk_text.text = "掐鹹蛋糕一算……妳的命格……嗯？竟然是一團迷霧？";
                    break;
                case 5:
                    not_talk();
                    name_text.text = "";
                    talk_text.text = "算命師撕了一塊鹹蛋糕塞進嘴裡嚼後，神色凝重。";
                    break;
                case 6:
                    fortune_Teller_talk();
                    name_text.text = "算命師";
                    talk_text.text = "缺失記憶、心有強願，以至於脫離軌道……妳似乎找不到歸屬。";
                    break;
                case 7:
                    name_text.text = "算命師";
                    talk_text.text = "雖然目前看來是前途坎坷、命途多舛。";
                    break;
                case 8:
                    talk_text.text = "但只要向著光芒，還是能夠得到救贖。";
                    break;
                case 9:
                    talk_text.text = "所以不用太擔心啦小朋友！開心一點！";
                    break;
                case 10:
                    main_talk();
                    Main_character_face.sprite = Main_character_face_change[0];
                    name_text.text = "曦然";
                    talk_text.text = "……";
                    break;
                case 11:
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
                    fortune_Teller_talk();
                    Main_character_face.sprite = Main_character_face_change[0];
                    fortune_Teller_body.sprite = fortune_Teller_face_change[0];
                    name_text.text = "算命師";
                    talk_text.text = "來，這個鳳梨酥給妳吃，別愁眉苦臉了。";
                    break;
                case 1:
                    main_talk();
                    Main_character_face.sprite = Main_character_face_change[3];
                    name_text.text = "曦然";
                    talk_text.text = "通常不該隨便收陌生人的食物。";
                    break;
                case 2:
                    fortune_Teller_talk();
                    name_text.text = "算命師";
                    talk_text.text = "觀念很好！但我真的不是壞人啊！";
                    break;
                case 3:
                    talk_text.text = "不吃就算了，剩下的我拿去給外甥女。";
                    break;
                case 4:
                    talk_text.text = "好久沒見到莓莓了～";
                    break;
                case 5:
                    main_talk();
                    Main_character_face.sprite = Main_character_face_change[4];
                    name_text.text = "曦然";
                    talk_text.text = "原來妳就是莓莓的阿姨？";
                    break;
                case 7:
                    fortune_Teller_talk();
                    name_text.text = "算命師";
                    talk_text.text = "妳認識我們家莓莓喔？那就不是什麼陌生人啦～";
                    break;
                case 8:
                    talk_text.text = "好！那這些甜點伴手禮就交給妳帶給莓莓啦！";
                    break;
                case 9:
                    not_talk();
                    name_text.text = "";
                    talk_text.text = "算命師將一大堆的禮盒塞到曦然手上。";
                    break;
                case 10:
                    main_talk();
                    Main_character_face.sprite = Main_character_face_change[4];
                    name_text.text = "曦然";
                    talk_text.text = "太……太多了，好重……。";
                    break;
                case 11:
                    End_talk();
                    break;
            }
        }
        void talk_count02()
        {
            switch (talk_number)
            {
                case 0:
                    fortune_Teller_talk();
                    Main_character_face.sprite = Main_character_face_change[0];
                    fortune_Teller_body.sprite = fortune_Teller_face_change[0];
                    name_text.text = "算命師";
                    talk_text.text = "我只不過是幾年沒回來，國度怎麼就不如以往歡樂啊？";
                    break;
                case 1:
                    talk_text.text = "而且一直覺得好想睡。";
                    break;
                case 2:
                    main_talk();
                    Main_character_face.sprite = Main_character_face_change[0];
                    name_text.text = "曦然";
                    talk_text.text = "因為黑暗詛咒侵蝕的關係，一直待在外面的話就會漸漸無法行動。";
                    break;
                case 3:
                    fortune_Teller_talk();
                    name_text.text = "算命師";
                    talk_text.text = "啊？真危險，我得趕緊找個地方避難去了……";
                    break;
                case 4:
                    main_talk();
                    Main_character_face.sprite = Main_character_face_change[0];
                    name_text.text = "曦然";
                    talk_text.text = "妳沒算到這步嗎？";
                    break;
                case 5:
                    fortune_Teller_talk();
                    name_text.text = "算命師";
                    talk_text.text = "唉呀～我都收錢才會看別人的命運，甜蜜夢之國又沒給我錢！";
                    break;
                case 6:
                    main_talk();
                    Main_character_face.sprite = Main_character_face_change[0];
                    name_text.text = "曦然";
                    talk_text.text = "我也沒給妳錢。";
                    break;
                case 7:
                    fortune_Teller_talk();
                    name_text.text = "算命師";
                    talk_text.text = "那就說明我們很有緣份啊！";
                    break;
                case 8:
                    talk_text.text = "妳看，妳還認識我家莓莓！這不巧嗎？";
                    break;
                case 9:
                    main_talk();
                    Main_character_face.sprite = Main_character_face_change[0];
                    name_text.text = "曦然";
                    talk_text.text = "……好吧，是挺巧合的。";
                    break;
                case 10:
                    End_talk();
                    break;
            }
        }
    }

    void End_talk()
    {
        if (F_button_object.sprite == null) P1 = false;
        talk_number = 0;
        Fortune_Teller_talk.SetActive(false);
        static_parameters.isUpgrade_tmp = false;
    }

    void fortune_Teller_talk()
    {
        Main_character_face.color = new Color(0.5f, 0.5f, 0.5f, 1);
        Main_character_body.color = new Color(0.5f, 0.5f, 0.5f, 1);
        fortune_Teller_body.color = new Color(1, 1, 1, 1);
    }
    void main_talk()
    {
        Main_character_face.color = new Color(1, 1, 1, 1);
        Main_character_body.color = new Color(1, 1, 1, 1);
        fortune_Teller_body.color = new Color(0.5f, 0.5f, 0.5f, 1);
    }
    void not_talk()
    {
        Main_character_face.color = new Color(0.5f, 0.5f, 0.5f, 1);
        Main_character_body.color = new Color(0.5f, 0.5f, 0.5f, 1);
        fortune_Teller_body.color = new Color(0.5f, 0.5f, 0.5f, 1);
    }
}
