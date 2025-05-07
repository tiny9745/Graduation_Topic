using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shop_Caterpillar_talk : MonoBehaviour
{
    // Start is called before the first frame update

    int talk_count = 0, talk_number = 0;
    public Text name_text, talk_text;
    public GameObject Caterpillar_talk;
    public Image Main_character_face;
    public Image Main_character_body, Caterpillar_body;
    public Sprite[] Main_character_face_change;
    public Sprite[] Caterpillar_face_change;
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
            Caterpillar_talk.SetActive(true);
            shop_Caterpillar_Talk();
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space))
        {
            talk_number++;
            shop_Caterpillar_Talk();
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

    void shop_Caterpillar_Talk()
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
                    caterpillar_talk();
                    Main_character_face.sprite = Main_character_face_change[0];
                    Caterpillar_body.sprite = Caterpillar_face_change[0];
                    name_text.text = "毛毛蟲";
                    talk_text.text = "唉，小傢伙，外面很危險，快回去吧。";
                    break;
                case 1:
                    main_talk();
                    name_text.text = "曦然";
                    talk_text.text = "你是誰？";
                    break;
                case 2:
                    caterpillar_talk();
                    name_text.text = "毛毛蟲";
                    talk_text.text = "我是誰不重要，重點是國度危在旦夕，待在外面不安全。";
                    break;
                case 3:
                    main_talk();
                    Main_character_face.sprite = Main_character_face_change[3];
                    name_text.text = "曦然";
                    talk_text.text = "可是我必須要去城堡，我要去看黑暗詛咒的來源。";
                    break;
                case 4:
                    caterpillar_talk();
                    name_text.text = "毛毛蟲";
                    talk_text.text = "妳……難道沒有被黑暗詛咒影響到嗎？";
                    break;
                case 5:
                    talk_text.text = "覺得身體漸漸無法動彈之類的？";
                    break;
                case 6:
                    main_talk();
                    Main_character_face.sprite = Main_character_face_change[3];
                    name_text.text = "曦然";
                    talk_text.text = "沒有。所以只有我一個人去城堡。";
                    break;
                case 7:
                    caterpillar_talk();
                    name_text.text = "毛毛蟲";
                    talk_text.text = "妳還有同伴？";
                    break;
                case 8:
                    main_talk();
                    Main_character_face.sprite = Main_character_face_change[1];
                    name_text.text = "曦然";
                    talk_text.text = "嗯，她說她是國度裡最厲害的魔法師。";
                    break;
                case 9:
                    caterpillar_talk();
                    name_text.text = "毛毛蟲";
                    talk_text.text = $"<size={smallerSize}>原來是莓雷迪斯……</size>";
                    break;
                case 10:
                    End_talk();
                    break;
            }
        }
        void talk_count01()
        {
            switch (talk_number)
            {
                case 0:
                    caterpillar_talk();
                    Main_character_face.sprite = Main_character_face_change[0];
                    Caterpillar_body.sprite = Caterpillar_face_change[0];
                    name_text.text = "毛毛蟲";
                    talk_text.text = "妳的同伴現在還好嗎？";
                    break;
                case 1:
                    main_talk();
                    name_text.text = "曦然";
                    talk_text.text = "她待在糖果屋裡所以沒事。";
                    break;
                case 2:
                    caterpillar_talk();
                    name_text.text = "毛毛蟲";
                    talk_text.text = "那就好，代表魔法結界還沒失效。";
                    break;
                case 3:
                    main_talk();
                    Main_character_face.sprite = Main_character_face_change[3];
                    name_text.text = "曦然";
                    talk_text.text = "你怎麼那麼清楚？";
                    break;
                case 4:
                    Main_character_face.sprite = Main_character_face_change[4];
                    name_text.text = "曦然";
                    talk_text.text = "原來你是莓莓的老師？";
                    break;
                case 5:
                    caterpillar_talk();
                    name_text.text = "毛毛蟲";
                    talk_text.text = "妳推理能力還滿好的嘛。";
                    break;
                case 6:
                    talk_text.text = "是啊，我確實是莓雷迪斯的魔法老師。";
                    break;
                case 7:
                    main_talk();
                    Main_character_face.sprite = Main_character_face_change[0];
                    name_text.text = "曦然";
                    talk_text.text = "她一直想要聯絡你，但都找不到。";
                    break;
                case 8:
                    caterpillar_talk();
                    name_text.text = "毛毛蟲";
                    talk_text.text = "原來啊，再麻煩妳轉告，之後我有空會過去找她。";
                    break;
                case 9:
                    End_talk();
                    break;
            }
        }
        void talk_count02()
        {
            switch (talk_number)
            {
                case 0:
                    caterpillar_talk();
                    Main_character_face.sprite = Main_character_face_change[0];
                    Caterpillar_body.sprite = Caterpillar_face_change[0];
                    name_text.text = "毛毛蟲";
                    talk_text.text = $"<size={smallerSize}>現在情況這麼危險怎麼還有人敢出來賣東西……</size>";
                    break;
                case 1:
                    main_talk();
                    Main_character_face.sprite = Main_character_face_change[0];
                    name_text.text = "曦然";
                    talk_text.text = "婆婆好像一直在睡覺。";
                    break;
                case 2:
                    caterpillar_talk();
                    name_text.text = "毛毛蟲";
                    talk_text.text = "因為詛咒會影響人的行動能力啊。";
                    break;
                case 3:
                    main_talk();
                    Main_character_face.sprite = Main_character_face_change[3];
                    name_text.text = "曦然";
                    talk_text.text = "那你怎麼沒被影響呢？";
                    break;
                case 4:
                    caterpillar_talk();
                    name_text.text = "毛毛蟲";
                    talk_text.text = "我有魔法結界保護。";
                    break;
                case 5:
                    talk_text.text = "雖然我不知道為何妳明明沒有卻沒事。";
                    break;
                case 6:
                    talk_text.text = "妳該不會不是這個世界的人吧？";
                    break;
                case 7:
                    main_talk();
                    Main_character_face.sprite = Main_character_face_change[4];
                    name_text.text = "曦然";
                    talk_text.text = "？";
                    break;
                case 8:
                    caterpillar_talk();
                    name_text.text = "毛毛蟲";
                    talk_text.text = "隨便說說罷了，別放在心上。";
                    break;
                case 9:
                    End_talk();
                    break;
            }
        }
    }

    void End_talk()
    {
        if (F_button_object.sprite == null) P1 = false;
        Caterpillar_talk.SetActive(false);
        static_parameters.isUpgrade_tmp = false;
        talk_number = 0;
        talk_count++;
        if (talk_count > 2) talk_count = 0;
    }

    void caterpillar_talk()
    {
        Main_character_face.color = new Color(0.5f, 0.5f, 0.5f, 1);
        Main_character_body.color = new Color(0.5f, 0.5f, 0.5f, 1);
        Caterpillar_body.color = new Color(1, 1, 1, 1);
    }
    void main_talk()
    {
        Main_character_face.color = new Color(1, 1, 1, 1);
        Main_character_body.color = new Color(1, 1, 1, 1);
        Caterpillar_body.color = new Color(0.5f, 0.5f, 0.5f, 1);
    }
}
