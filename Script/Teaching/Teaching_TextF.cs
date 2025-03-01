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
                    name_text.text = "";
                    talk_text.text = "［忽然，外頭傳來了奇怪的聲音。］";
                    break;
                case 3:
                    Magician.sprite = Magician_face[0];
                    name_text.text = "莓莓";
                    talk_text.text = "你等我一下喔，我出去看看。";
                    break;
                case 4:
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
                    name_text.text = "曦然";
                    talk_text.text = "莓莓怎麼了？";
                    break;
                case 7:
                    name_text.text = "";
                    talk_text.text = "*WASD控制曦然去玩偶區拿起鴨子布偶來防禦吧！*";
                    break;
                case 8:
                    name_text.text = "";
                    talk_text.text = "*走出門口，查看莓莓的情況*";
                    break;
                case 9:
                    name_text.text = "";
                    talk_text.text = "*莓莓要受傷了！快按下J鍵使用鴨子布偶來攻擊敵人！*";
                    break;
                case 10:
                    name_text.text = "";
                    talk_text.text = "*把剩餘士兵擊退吧！*";
                    break;
                case 11:
                    Magician.sprite = Magician_face[1];
                    name_text.text = "曦然";
                    talk_text.text = "妳沒事吧？";
                    break;
                case 12:
                    Main_character.sprite = Main_character_face[1];
                    name_text.text = "莓莓";
                    talk_text.text = "我沒事，謝謝妳。但是姜米和其他人變得好奇怪……";
                    break;
                case 13:
                    Magician.sprite = Magician_face[0];
                    name_text.text = "曦然";
                    talk_text.text = "是因為詛咒增強的關係嗎？是不是現在變得很嚴重？";
                    break;
                case 14:
                    Magician.sprite = Magician_face[1];
                    name_text.text = "莓莓";
                    talk_text.text = "我想是的，真糟糕，已經沒辦法用簡單的法術快速擊退他們了";
                    break;
                case 15:
                    Magician.sprite = Magician_face[0];
                    name_text.text = "莓莓";
                    talk_text.text = "……不過妳手上那是什麼？";
                    break;
                case 16:
                    Magician.sprite = Magician_face[1];
                    name_text.text = "曦然";
                    talk_text.text = "我不知道，剛剛最後一個士兵消失時掉下來的東西。";
                    break;
                case 17:
                    name_text.text = "";
                    talk_text.text = "*按下Z鍵，打開筆記本吧！*";
                    break;
                case 18:
                    Magician.sprite = Magician_face[1];
                    name_text.text = "曦然";
                    talk_text.text = "這個碎片材質跟筆記本一樣耶。";
                    break;
                case 19:
                    Magician.sprite = Magician_face[0];
                    name_text.text = "莓莓";
                    talk_text.text = "放上去試看看？";
                    break;
                case 20:
                    name_text.text = "";
                    talk_text.text = "*將剛剛獲得的碎片拖曳到畫面上試試看！*";
                    break;
                case 21:
                    Magician.sprite = Magician_face[1];
                    name_text.text = "曦然";
                    talk_text.text = "出現了一點魔力，哼嗯……似乎跟詛咒有相同的氣息……？";
                    break;
                case 22:
                    Main_character.sprite = Main_character_face[1];
                    name_text.text = "莓莓";
                    talk_text.text = "但是碎片還不夠多，也許只要多去打敗那些受詛咒的人或生物";
                    break;
                case 23:
                    Magician.sprite = Magician_face[0];
                    name_text.text = "莓莓";
                    talk_text.text = "我想就能得到更多碎片來拼湊吧？";
                    break;
                case 24:
                    Magician.sprite = Magician_face[1];
                    name_text.text = "莓莓";
                    talk_text.text = "蒐集到一定的魔力，也許就可以反向解開詛咒呢。";
                    break;
                case 25:
                    Magician.sprite = Magician_face[0];
                    name_text.text = "曦然";
                    talk_text.text = "真的嗎？";
                    break;
                case 26:
                    Magician.sprite = Magician_face[1];
                    name_text.text = "莓莓";
                    talk_text.text = "不過我沒有辦法和你一起去，詛咒影響我越來越深了";
                    break;
                case 27:
                    Magician.sprite = Magician_face[0];
                    name_text.text = "莓莓";
                    talk_text.text = "所以……";
                    break;
                case 28:
                    Magician.sprite = Magician_face[1];
                    name_text.text = "莓莓";
                    talk_text.text = "所以……拜託妳去城堡查看詛咒來源，在路上順便蒐集碎片吧！";
                    break;
                case 29:
                    name_text.text = "";
                    talk_text.text = "（回到房屋裡，早餐草莓巧克力蛋餅已經完成，還有一杯粉色回魂藥水）";
                    break;
                case 30:
                    Main_character.sprite = Main_character_face[0];
                    name_text.text = "莓莓";
                    talk_text.text = "出發前要記得補充好營養，這杯叫做回魂藥水。";
                    break;
                case 31:
                    Magician.sprite = Magician_face[1];
                    name_text.text = "莓莓";
                    talk_text.text = "如果妳不幸被怪物攻擊致死，別擔心！";
                    break;
                case 32:
                    Main_character.sprite = Main_character_face[1];
                    name_text.text = "莓莓";
                    talk_text.text = "妳會重新回到糖果屋裡！不會真的死亡喔！";
                    break;
                case 33:
                    Magician.sprite = Magician_face[0];
                    name_text.text = "莓莓";
                    talk_text.text = "哇，真神奇。";
                    break;
                case 34:
                    name_text.text = "";
                    talk_text.text = "［曦然喝下了回魂藥水，也吃了早餐，準備出發］";
                    break;
                case 35:
                    Magician.sprite = Magician_face[0];
                    name_text.text = "曦然";
                    talk_text.text = "出門小心！願甜蜜與妳同在。";
                    break;
                case 36:
                    name_text.text = "";
                    talk_text.text = "（遊戲正式開始）";
                    break;
            }
            talk_number++;
        }
    }
}
