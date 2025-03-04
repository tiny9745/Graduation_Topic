using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Teaching_TextF : MonoBehaviour
{
    public GameObject Main_character_object, Magician_object;
    public GameObject dialog_box, Teaching_dialog_box;
    public Image Main_character, Magician;
    public Image Main_character_body, Magician_body;
    public Sprite[] Main_character_face;
    public Sprite[] Magician_face;
    public Image black;
    public Text name_text, talk_text, Narration_text, teach_text;
    public UI _UI;
    uint talk_number = 0;

    void Start()
    {
        static_parameters.teaching_stop = -1;
        _UI = GameObject.Find("UI").GetComponent<UI>();
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && static_parameters.teaching_stop < 19)
        {
            Debug.Log("talk_number:" + talk_number);
            Debug.Log("static_parameters.teaching_stop:" + static_parameters.teaching_stop);
            reading();
        }
        else if (
            static_parameters.teaching_stop == 1 || static_parameters.teaching_stop == 3 && talk_number == 8 ||
            talk_number == 9 && static_parameters.teaching_stop == 5 || talk_number == 10 && static_parameters.teaching_stop == 7 ||
            talk_number == 17 && Input.GetKeyDown(KeyCode.Z) || talk_number == 21 || talk_number == 30
            )
        {
            reading();
        }
    }

    public void reading()
    {
        switch (talk_number)
        {
            case 0:
                static_parameters.teaching_stop = -1;
                open();
                magic_talk();
                Magician.sprite = Magician_face[0];
                name_text.text = "莓莓";
                talk_text.text = "今天天氣真不錯，早餐就來吃草莓蛋餅吧！";
                break;
            case 1:
                main_talk();
                Main_character.sprite = Main_character_face[1];
                name_text.text = "曦然";
                talk_text.text = "那我還要加巧克力醬！";
                break;
            case 2:
                opce_nav();
                not_talk();
                Narration_text.text = "［忽然，外頭傳來了奇怪的聲音。］";
                break;
            case 3:
                opce_nav();
                magic_talk();
                Magician.sprite = Magician_face[0];
                name_text.text = "莓莓";
                talk_text.text = "你等我一下喔，我出去看看。";
                break;
            case 4:
                opce_nav();
                main_talk();
                Magician_object.SetActive(false);
                Narration_text.text = "［曦然待在原地，準備食材。］";
                break;
            case 5:
                opce_nav();
                magic_talk();
                Narration_text.gameObject.SetActive(false);
                talk_text.gameObject.SetActive(true);
                name_text.text = "莓莓";
                talk_text.text = "啊！！！";
                break;
            case 6:
                main_talk();
                Main_character.sprite = Main_character_face[4];
                name_text.text = "曦然";
                talk_text.text = "莓莓怎麼了？";
                break;
            case 7:
                close();
                teach_text.text = "*WASD控制曦然去玩偶區拿起鴨子布偶來防禦吧！*";
                if (static_parameters.teaching_stop == -1)
                {
                    static_parameters.teaching_stop = 0;
                }
                break;
            case 8:
                teach_text.text = "*走出門口，查看莓莓的情況*";
                break;
            case 9:
                teach_text.text = "*莓莓要受傷了！快按下J鍵使用鴨子布偶來攻擊敵人！*";
                break;
            case 10:
                teach_text.text = "*把剩餘士兵擊退吧！*";
                break;
            case 11:
                magic_talk();
                Magician_object.SetActive(true);
                Magician.sprite = Magician_face[4];
                name_text.text = "莓莓";
                talk_text.text = "我沒事，謝謝妳。但是姜米和其他人變得好奇怪……";
                break;
            case 12:
                main_talk();
                Main_character.sprite = Main_character_face[3];
                name_text.text = "曦然";
                talk_text.text = "是因為詛咒增強的關係嗎？是不是現在變得很嚴重？";
                break;
            case 13:
                magic_talk();
                Magician.sprite = Magician_face[3];
                name_text.text = "莓莓";
                talk_text.text = "我想是的，真糟糕，已經沒辦法用簡單的法術快速擊退他們了";
                break;
            case 14:
                name_text.text = "莓莓";
                talk_text.text = "……不過妳手上那是什麼？";
                break;
            case 15:
                main_talk();
                name_text.text = "曦然";
                talk_text.text = "我不知道，剛剛最後一個士兵消失時掉下來的東西。";
                break;
            case 16:
                close();
                static_parameters.teaching_stop = 6;
                teach_text.text = "*按下Z鍵，打開筆記本吧！*";
                break;
            case 18:
                open(); ;
                Main_character.sprite = Main_character_face[0];
                name_text.text = "曦然";
                talk_text.text = "這個碎片材質跟筆記本一樣耶。";
                break;
            case 19:
                magic_talk();
                Magician.sprite = Magician_face[0];
                name_text.text = "莓莓";
                talk_text.text = "放上去試看看？";
                break;
            case 20:
                close();
                teach_text.text = "*將剛剛獲得的碎片拖曳到畫面上試試看！*";
                break;
            case 21:
                close_co();
                break;
            case 22:
                open();
                name_text.text = "莓莓";
                talk_text.text = "出現了一點魔力，哼嗯……似乎跟詛咒有相同的氣息……？";
                break;
            case 23:
                Magician.sprite = Magician_face[3];
                name_text.text = "莓莓";
                talk_text.text = "但是碎片還不夠多，也許只要多去打敗那些受詛咒的人或生物";
                break;
            case 24:
                name_text.text = "莓莓";
                talk_text.text = "我想就能得到更多碎片來拼湊吧？";
                static_parameters.isTeaching = false;
                _UI.openclose();
                break;
            case 25:
                Magician.sprite = Magician_face[0];
                name_text.text = "莓莓";
                talk_text.text = "蒐集到一定的魔力，也許就可以反向解開詛咒呢。";
                break;
            case 26:
                main_talk();
                Main_character.sprite = Main_character_face[4];
                name_text.text = "曦然";
                talk_text.text = "真的嗎？";
                break;
            case 27:
                magic_talk();
                Magician.sprite = Magician_face[3];
                name_text.text = "莓莓";
                talk_text.text = "不過我沒有辦法和你一起去，詛咒影響我越來越深了";
                break;
            case 28:
                Magician.sprite = Magician_face[3];
                name_text.text = "莓莓";
                talk_text.text = "所以……";
                break;
            case 29:
                Magician.sprite = Magician_face[0];
                name_text.text = "莓莓";
                talk_text.text = "所以……拜託妳去城堡查看詛咒來源，在路上順便蒐集碎片吧！";
                SceneManager.LoadScene("magic_house");
                break;
            case 31:
                opce_nav();
                name_text.text = "莓莓";
                talk_text.text = "出發前要記得補充好營養，這杯叫做回魂藥水。";
                break;
            case 32:
                name_text.text = "莓莓";
                talk_text.text = "如果妳不幸被怪物攻擊致死，別擔心！";
                break;
            case 33:
                Magician.sprite = Magician_face[1];
                name_text.text = "莓莓";
                talk_text.text = "妳會重新回到糖果屋裡！不會真的死亡喔！";
                break;
            case 34:
                main_talk();
                Main_character.sprite = Main_character_face[1];
                name_text.text = "曦然";
                talk_text.text = "哇，真神奇。";
                break;
            case 35:
                opce_nav();
                Narration_text.text = "［曦然喝下了回魂藥水，也吃了早餐，準備出發］";
                break;
            case 36:
                opce_nav();
                magic_talk();
                Magician.sprite = Magician_face[0];
                name_text.text = "莓莓";
                talk_text.text = "出門小心！願甜蜜與妳同在。";
                break;
            case 37:
                opce_nav();
                Narration_text.text = "（遊戲正式開始）";
                break;
            case 38:
                close();
                static_parameters.teaching_stop = 101;
                talk_number = 100;
                Teaching_dialog_box.SetActive(false);
                break;
        }
        if (talk_number == 7)
        {
            Debug.Log("talk_number:" + talk_number);
            Debug.Log("static_parameters.teaching_stop:" + static_parameters.teaching_stop);
            if (static_parameters.teaching_stop == 1)
            {
                talk_number++;
                teach_text.text = "*走出門口，查看莓莓的情況*";
            }
        }
        else if (talk_number == 8)
        {
            if (static_parameters.teaching_stop == 3)
            {
                talk_number++;
                teach_text.text = "*莓莓要受傷了！快按下J鍵使用鴨子布偶來攻擊敵人！*";
            }
        }
        else if (talk_number == 9)
        {
            if (static_parameters.teaching_stop == 5)
            {
                talk_number++;
                teach_text.text = "*把剩餘士兵擊退吧！*";
            }
        }
        else if (talk_number == 10)
        {
            if (static_parameters.teaching_stop == 7)
            {
                Debug.Log("!!talk_number:" + talk_number + "static_parameters.teaching_stop:" + static_parameters.teaching_stop);
                talk_number++;
                open();
                name_text.text = "曦然";
                talk_text.text = "妳沒事吧？";
            }
        }
        else if (talk_number == 17)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                static_parameters.teaching_stop = 8;
                talk_number += 2;
                _UI.Onclick2();
                open();
                Main_character.sprite = Main_character_face[0];
                name_text.text = "曦然";
                talk_text.text = "這個碎片材質跟筆記本一樣耶。";
            }
        }
        else if (talk_number == 21)
        {
            if (static_parameters.teaching_stop == 9)
            {
                open();
                talk_number += 2;
                name_text.text = "莓莓";
                talk_text.text = "出現了一點魔力，哼嗯……似乎跟詛咒有相同的氣息……？";
            }
        }
        else if (talk_number == 30)
        {
            if (SceneManager.GetActiveScene().name == "magic_house")
            {
                talk_number++;
                opce_nav();
                Narration_text.text = "（回到房屋裡，早餐草莓巧克力蛋餅已經完成，還有一杯粉色回魂藥水）";
            }
        }
        else
        {
            talk_number++;
        }
    }
    private void open()
    {
        static_parameters.isTeaching = true;
        Magician_object.SetActive(true);
        Main_character_object.SetActive(true);
        dialog_box.SetActive(true);
        Teaching_dialog_box.SetActive(false);
        black.gameObject.SetActive(true);
        black.color = new Color(0, 0, 0, 0.7f);
    }
    private void close()
    {
        static_parameters.isTeaching = false;
        Magician_object.SetActive(false);
        Main_character_object.SetActive(false);
        dialog_box.SetActive(false);
        Teaching_dialog_box.SetActive(true);
        black.color = new Color(0, 0, 0, 1);
        black.gameObject.SetActive(false);
    }
    private void close_co()
    {
        static_parameters.isTeaching = false;
        Magician_object.SetActive(false);
        Main_character_object.SetActive(false);
        dialog_box.SetActive(false);
        Teaching_dialog_box.SetActive(false);
        black.color = new Color(0, 0, 0, 1);
        black.gameObject.SetActive(false);
    }

    void magic_talk()
    {
        Main_character.color = new Color(0.5f, 0.5f, 0.5f, 1);
        Magician.color = new Color(1, 1, 1, 1);
        Main_character_body.color = new Color(0.5f, 0.5f, 0.5f, 1);
        Magician_body.color = new Color(1, 1, 1, 1);
    }

    void main_talk()
    {
        Main_character.color = new Color(1, 1, 1, 1);
        Magician.color = new Color(0.5f, 0.5f, 0.5f, 1);
        Main_character_body.color = new Color(1, 1, 1, 1);
        Magician_body.color = new Color(0.5f, 0.5f, 0.5f, 1);
    }
    void not_talk()
    {
        Main_character.color = new Color(0.5f, 0.5f, 0.5f, 1);
        Magician.color = new Color(0.5f, 0.5f, 0.5f, 1);
        Main_character_body.color = new Color(0.5f, 0.5f, 0.5f, 1);
        Magician_body.color = new Color(0.5f, 0.5f, 0.5f, 1);
    }

    private void opce_nav()
    {
        Narration_text.gameObject.SetActive(!Narration_text.gameObject.activeSelf);
        name_text.gameObject.SetActive(!name_text.gameObject.activeSelf);
        talk_text.gameObject.SetActive(!talk_text.gameObject.activeSelf);
    }
}
