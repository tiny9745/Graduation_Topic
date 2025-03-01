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
                    name_text.text = "莓莓";
                    talk_text.text = "今天天氣真不錯，早餐就來吃草莓蛋餅吧！";
                    break;
                case 1:
                    Magician.sprite = Magician_face[1];
                    name_text.text = "曦然";
                    talk_text.text = "那我還要加巧克力醬！";
                    break;
                case 2:
                    Main_character.sprite = Main_character_face[1];
                    name_text.text = "";
                    talk_text.text = "［忽然，外頭傳來了奇怪的聲音。］";
                    break;
                case 3:
                    Magician.sprite = Magician_face[0];
                    name_text.text = "莓莓";
                    talk_text.text = "你等我一下喔，我出去看看。";
                    break;
                case 4:                 
                    Magician.sprite = Magician_face[1];
                    name_text.text = "";
                    talk_text.text = "［曦然待在原地，準備食材。］";
                    break;
                case 5:
                    Magician.sprite = Magician_face[0];
                    name_text.text = "莓莓";
                    talk_text.text = "啊！！！";
                    break;
                case 6:
                    Magician.sprite = Magician_face[1];
                    name_text.text = "魔法師";
                    talk_text.text = "很好，接下來我們來學習攻擊。";
                    break;
                case 7:
                    Magician.sprite = Magician_face[0];
                    name_text.text = "魔法師";
                    talk_text.text = "請按下鍵盤上的J鍵，試著攻擊一下。";
                    break;
                case 8:
                    Magician.sprite = Magician_face[1];
                    name_text.text = "魔法師";
                    talk_text.text = "很好，接下來我們來學習購買物品。";
                    break;
                case 9:
                    Magician.sprite = Magician_face[0];
                    name_text.text = "魔法師";
                    talk_text.text = "請走到商店前，按下F鍵購買物品。";
                    break;
            }
            talk_number++;
        }
    }
}
