using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Upgrade : MonoBehaviour
{
    // Start is called before the first frame update
    UI ui;
    public GameObject ATK_plus, DEF_plus, HP_plus, Speed_plus, Knockback_plus;
    public GameObject AB1, AB2, AB3, AB4, AB5, DB1, DB2, DB3, DB4, DB5, HB1, HB2, HB3, HB4, HB5,
                  SB1, SB2, SB3, SB4, SB5, KB1, KB2, KB3, KB4, KB5;
    public Text namebox, textbox;
    public UI_Place UI_place;
    public static short ATK_LV = 1, DEF_LV = 1, HP_LV = 1, Speed_LV = 1, Knockback_LV = 1, Click = 0;
    short[] ATK_price = { 30, 45, 70, 100, 140 },
    DEF_price = { 30, 50, 75, 100, 140 },
    HP_price = { 30, 45, 70, 100, 140 },
    Speed_price = { 35, 50, 80, 100, 170 },
    Knockback_price = { 35, 60, 80, 100, 170 };
    void Start()
    {
        namebox.text = "";
        textbox.text = "請選擇升級項目";
    }
    public void ATK()
    {
        Click = 1;
        namebox.text = "攻擊";
        switch (ATK_LV)
        {
            case 1:
                textbox.text = "小拳拳捶你胸口！你說不痛？哼！升級成超大拳頭，甜蜜爆擊你喲！\n" + "升級價格:" + ATK_price[0];
                break;
            case 2:
                textbox.text = "小拳拳捶你胸口！你說不痛？哼！升級成超大拳頭，甜蜜爆擊你喲！\n" + "升級價格:" + ATK_price[1];
                break;
            case 3:
                textbox.text = "小拳拳捶你胸口！你說不痛？哼！升級成超大拳頭，甜蜜爆擊你喲！\n" + "升級價格:" + ATK_price[2];
                break;
            case 4:
                textbox.text = "小拳拳捶你胸口！你說不痛？哼！升級成超大拳頭，甜蜜爆擊你喲！\n" + "升級價格:" + ATK_price[3];
                break;
            case 5:
                textbox.text = "小拳拳捶你胸口！你說不痛？哼！升級成超大拳頭，甜蜜爆擊你喲！\n" + "升級價格:" + ATK_price[4];
                break;
        }
    }
    public void DEF()
    {
        Click = 2;
        namebox.text = "防禦";
        switch (DEF_LV)
        {
            case 1:
                textbox.text = "神力盾牌速來加持，讓怪物的攻擊變得跟奶油一樣輕飄飄又軟綿綿！\n" + "升級價格:" + DEF_price[0];
                break;
            case 2:
                textbox.text = "神力盾牌速來加持，讓怪物的攻擊變得跟奶油一樣輕飄飄又軟綿綿！\n" + "升級價格:" + DEF_price[1];
                break;
            case 3:
                textbox.text = "神力盾牌速來加持，讓怪物的攻擊變得跟奶油一樣輕飄飄又軟綿綿！\n" + "升級價格:" + DEF_price[2];
                break;
            case 4:
                textbox.text = "神力盾牌速來加持，讓怪物的攻擊變得跟奶油一樣輕飄飄又軟綿綿！\n" + "升級價格:" + DEF_price[3];
                break;
            case 5:
                textbox.text = "神力盾牌速來加持，讓怪物的攻擊變得跟奶油一樣輕飄飄又軟綿綿！\n" + "升級價格:" + DEF_price[4];
                break;
        }
    }
    public void HP()
    {
        Click = 3;
        namebox.text = "血量";
        switch (HP_LV)
        {
            case 1:
                textbox.text = "來吧，把草莓蛋糕疊得越高越好！只會增加血量，絕對不加血壓哦！\n" + "升級價格:" + HP_price[0];
                break;
            case 2:
                textbox.text = "來吧，把草莓蛋糕疊得越高越好！只會增加血量，絕對不加血壓哦！\n" + "升級價格:" + HP_price[1];
                break;
            case 3:
                textbox.text = "來吧，把草莓蛋糕疊得越高越好！只會增加血量，絕對不加血壓哦！\n" + "升級價格:" + HP_price[2];
                break;
            case 4:
                textbox.text = "來吧，把草莓蛋糕疊得越高越好！只會增加血量，絕對不加血壓哦！\n" + "升級價格:" + HP_price[3];
                break;
            case 5:
                textbox.text = "來吧，把草莓蛋糕疊得越高越好！只會增加血量，絕對不加血壓哦！\n" + "升級價格:" + HP_price[4];
                break;
        }
    }
    public void Speed()
    {
        Click = 4;
        namebox.text = "移速";
        switch (Speed_LV)
        {
            case 1:
                textbox.text = "好像在腳底抹滿了巧克力醬，讓速度快到連流星都追不上你的尾巴！\n" + "升級價格:" + Speed_price[0];
                break;
            case 2:
                textbox.text = "好像在腳底抹滿了巧克力醬，讓速度快到連流星都追不上你的尾巴！\n" + "升級價格:" + Speed_price[1];
                break;
            case 3:
                textbox.text = "好像在腳底抹滿了巧克力醬，讓速度快到連流星都追不上你的尾巴！\n" + "升級價格:" + Speed_price[2];
                break;
            case 4:
                textbox.text = "好像在腳底抹滿了巧克力醬，讓速度快到連流星都追不上你的尾巴！\n" + "升級價格:" + Speed_price[3];
                break;
            case 5:
                textbox.text = "好像在腳底抹滿了巧克力醬，讓速度快到連流星都追不上你的尾巴！\n" + "升級價格:" + Speed_price[4];
                break;
        }
    }
    public void Knockback()
    {
        Click = 5;
        namebox.text = "擊退";
        switch (Knockback_LV)
        {
            case 1:
                textbox.text = "不要小看我的力量，看我輕輕一個揮擊，就把怪物打去外太空度假！\n" + "升級價格:" + Knockback_price[0];
                break;
            case 2:
                textbox.text = "不要小看我的力量，看我輕輕一個揮擊，就把怪物打去外太空度假！\n" + "升級價格:" + Knockback_price[1];
                break;
            case 3:
                textbox.text = "不要小看我的力量，看我輕輕一個揮擊，就把怪物打去外太空度假！\n" + "升級價格:" + Knockback_price[2];
                break;
            case 4:
                textbox.text = "不要小看我的力量，看我輕輕一個揮擊，就把怪物打去外太空度假！\n" + "升級價格:" + Knockback_price[3];
                break;
            case 5:
                textbox.text = "不要小看我的力量，看我輕輕一個揮擊，就把怪物打去外太空度假！\n" + "升級價格:" + Knockback_price[4];
                break;
        }
    }
    public void Pay()
    {
        ui = GameObject.Find("UI").GetComponent<UI>();
        switch (Click)
        {
            case 1:
                switch (ATK_LV)
                {
                    case 1:
                        if (static_parameters.money >= ATK_price[0])
                        {
                            static_parameters.money -= ATK_price[0];
                            static_parameters.MC_ATK += 13;
                            ATK_LV++; AB1.SetActive(true);
                            textbox.text = "升級成功";
                        }
                        else
                        {
                            textbox.text = "金錢不足";
                        }
                        break;
                    case 2:
                        if (static_parameters.money >= ATK_price[1])
                        {
                            static_parameters.money -= ATK_price[1];
                            static_parameters.MC_ATK += 21;
                            ATK_LV++; AB2.SetActive(true);
                            textbox.text = "升級成功";
                        }
                        else
                        {
                            textbox.text = "金錢不足";
                        }
                        break;
                    case 3:
                        if (static_parameters.money >= ATK_price[2])
                        {
                            static_parameters.money -= ATK_price[2];
                            static_parameters.MC_ATK += 34;
                            ATK_LV++; AB3.SetActive(true);
                            textbox.text = "升級成功";
                        }
                        else
                        {
                            textbox.text = "金錢不足";
                        }
                        break;
                    case 4:
                        if (static_parameters.money >= ATK_price[3])
                        {
                            static_parameters.money -= ATK_price[3];
                            static_parameters.MC_ATK += 55;
                            ATK_LV++; AB4.SetActive(true);
                            textbox.text = "升級成功";
                        }
                        else
                        {
                            textbox.text = "金錢不足";
                        }
                        break;
                    case 5:
                        if (static_parameters.money >= ATK_price[4])
                        {
                            static_parameters.money -= ATK_price[4];
                            static_parameters.MC_ATK += 89;
                            ATK_LV++; AB5.SetActive(true);
                            textbox.text = "升級成功";
                        }
                        else
                        {
                            textbox.text = "金錢不足";
                        }
                        break;
                    case 6:
                        textbox.text = "已達最高等級";
                        break;
                        
                }
                static_parameters.MC_ATK_tmp = static_parameters.MC_ATK;
                break;
            case 2:
                switch (DEF_LV)
                {
                    case 1:
                        if (static_parameters.money >= DEF_price[0])
                        {
                            static_parameters.money -= DEF_price[0];
                            static_parameters.MC_DEF += 8;
                            DEF_LV++; DB1.SetActive(true);
                            textbox.text = "升級成功";
                        }
                        else
                        {
                            textbox.text = "金錢不足";
                        }
                        break;
                    case 2:
                        if (static_parameters.money >= DEF_price[1])
                        {
                            static_parameters.money -= DEF_price[1];
                            static_parameters.MC_DEF += 13;
                            DEF_LV++; DB2.SetActive(true);
                            textbox.text = "升級成功";
                        }
                        else
                        {
                            textbox.text = "金錢不足";
                        }
                        break;
                    case 3:
                        if (static_parameters.money >= DEF_price[2])
                        {
                            static_parameters.money -= DEF_price[2];
                            static_parameters.MC_DEF += 21;
                            DEF_LV++; DB3.SetActive(true);
                            textbox.text = "升級成功";
                        }
                        else
                        {
                            textbox.text = "金錢不足";
                        }
                        break;
                    case 4:
                        if (static_parameters.money >= DEF_price[3])
                        {
                            static_parameters.money -= DEF_price[3];
                            static_parameters.MC_DEF += 34;
                            DEF_LV++; DB4.SetActive(true);
                            textbox.text = "升級成功";
                        }
                        else
                        {
                            textbox.text = "金錢不足";
                        }
                        break;
                    case 5:
                        if (static_parameters.money >= DEF_price[4])
                        {
                            static_parameters.money -= DEF_price[4];
                            static_parameters.MC_DEF += 55;
                            DEF_LV++; DB5.SetActive(true);
                            textbox.text = "升級成功";
                        }
                        else
                        {
                            textbox.text = "金錢不足";
                        }
                        break;
                    case 6:
                        textbox.text = "已達最高等級";
                        break;
                }
                break;
            case 3:
                switch (HP_LV)
                {
                    case 1:
                        if (static_parameters.money >= HP_price[0])
                        {
                            static_parameters.money -= HP_price[0];
                            static_parameters.MC_HP_Max += 50; static_parameters.MC_HP = static_parameters.MC_HP_Max;
                            HP_LV++; HB1.SetActive(true);
                            textbox.text = "升級成功";
                        }
                        else
                        {
                            textbox.text = "金錢不足";
                        }
                        break;
                    case 2:
                        if (static_parameters.money >= HP_price[1])
                        {
                            static_parameters.money -= HP_price[1];
                            static_parameters.MC_HP_Max += 80; static_parameters.MC_HP = static_parameters.MC_HP_Max;
                            HP_LV++; HB2.SetActive(true);
                            textbox.text = "升級成功";
                        }
                        else
                        {
                            textbox.text = "金錢不足";
                        }
                        break;
                    case 3:
                        if (static_parameters.money >= HP_price[2])
                        {
                            static_parameters.money -= HP_price[2];
                            static_parameters.MC_HP_Max += 130; static_parameters.MC_HP = static_parameters.MC_HP_Max;
                            HP_LV++; HB3.SetActive(true);
                            textbox.text = "升級成功";
                        }
                        else
                        {
                            textbox.text = "金錢不足";
                        }
                        break;
                    case 4:
                        if (static_parameters.money >= HP_price[3])
                        {
                            static_parameters.money -= HP_price[3];
                            static_parameters.MC_HP_Max += 210; static_parameters.MC_HP = static_parameters.MC_HP_Max;
                            HP_LV++; HB4.SetActive(true);
                            textbox.text = "升級成功";
                        }
                        else
                        {
                            textbox.text = "金錢不足";
                        }
                        break;
                    case 5:
                        if (static_parameters.money >= HP_price[4])
                        {
                            static_parameters.money -= HP_price[4];
                            static_parameters.MC_HP_Max += 340; static_parameters.MC_HP = static_parameters.MC_HP_Max;
                            HP_LV++; HB5.SetActive(true);
                            textbox.text = "升級成功";
                        }
                        else
                        {
                            textbox.text = "金錢不足";
                        }
                        break;
                    case 6:
                        textbox.text = "已達最高等級";
                        break;
                }
                break;
            case 4:
                switch (Speed_LV)
                {
                    case 1:
                        if (static_parameters.money >= Speed_price[0])
                        {
                            static_parameters.money -= Speed_price[0];
                            static_parameters.MC_Wspeed += 3f;
                            Speed_LV++; SB1.SetActive(true);
                            textbox.text = "升級成功";
                        }
                        else
                        {
                            textbox.text = "金錢不足";
                        }
                        break;
                    case 2:
                        if (static_parameters.money >= Speed_price[1])
                        {
                            static_parameters.money -= Speed_price[1];
                            static_parameters.MC_Wspeed += 4f;
                            Speed_LV++; SB2.SetActive(true);
                            textbox.text = "升級成功";
                        }
                        else
                        {
                            textbox.text = "金錢不足";
                        }
                        break;
                    case 3:
                        if (static_parameters.money >= Speed_price[2])
                        {
                            static_parameters.money -= Speed_price[2];
                            static_parameters.MC_Wspeed += 5f;
                            Speed_LV++; SB3.SetActive(true);
                            textbox.text = "升級成功";
                        }
                        else
                        {
                            textbox.text = "金錢不足";
                        }
                        break;
                    case 4:
                        if (static_parameters.money >= Speed_price[3])
                        {
                            static_parameters.money -= Speed_price[3];
                            static_parameters.MC_Wspeed += 5f;
                            Speed_LV++; SB4.SetActive(true);
                            textbox.text = "升級成功";
                        }
                        else
                        {
                            textbox.text = "金錢不足";
                        }
                        break;
                    case 5:
                        if (static_parameters.money >= Speed_price[4])
                        {
                            static_parameters.money -= Speed_price[4];
                            static_parameters.MC_Wspeed += 6f;
                            Speed_LV++; SB5.SetActive(true);
                            textbox.text = "升級成功";
                        }
                        else
                        {
                            textbox.text = "金錢不足";
                        }
                        break;
                    case 6:
                        textbox.text = "已達最高等級";
                        break;
                }
                break;
            case 5:
                switch (Knockback_LV)
                {
                    case 1:
                        if (static_parameters.money >= Knockback_price[0])
                        {
                            static_parameters.money -= Knockback_price[0];
                            static_parameters.knockback_force += 0.3f;
                            Knockback_LV++; KB1.SetActive(true);
                            textbox.text = "升級成功";
                        }
                        else
                        {
                            textbox.text = "金錢不足";
                        }
                        break;
                    case 2:
                        if (static_parameters.money >= Knockback_price[1])
                        {
                            static_parameters.money -= Knockback_price[1];
                            static_parameters.knockback_force += 0.5f;
                            Knockback_LV++; KB2.SetActive(true);
                            textbox.text = "升級成功";
                        }
                        else
                        {
                            textbox.text = "金錢不足";
                        }
                        break;
                    case 3:
                        if (static_parameters.money >= Knockback_price[2])
                        {
                            static_parameters.money -= Knockback_price[2];
                            static_parameters.knockback_force += 0.8f;
                            Knockback_LV++; KB3.SetActive(true);
                            textbox.text = "升級成功";
                        }
                        else
                        {
                            textbox.text = "金錢不足";
                        }
                        break;
                    case 4:
                        if (static_parameters.money >= Knockback_price[3])
                        {
                            static_parameters.money -= Knockback_price[3];
                            static_parameters.knockback_force += 1.3f;
                            Knockback_LV++; KB4.SetActive(true);
                            textbox.text = "升級成功";
                        }
                        else
                        {
                            textbox.text = "金錢不足";
                        }
                        break;
                    case 5:
                        if (static_parameters.money >= Knockback_price[4])
                        {
                            static_parameters.money -= Knockback_price[4];
                            static_parameters.knockback_force += 2.1f;
                            Knockback_LV++; KB5.SetActive(true);
                            textbox.text = "升級成功";
                        }
                        else
                        {
                            textbox.text = "金錢不足";
                        }
                        break;
                    case 6:
                        textbox.text = "已達最高等級";
                        break;
                }
                break;
            default:
                textbox.text = "請選擇升級項目";
                break;
        }
        ui.Loadmoney();
    }
    public void Cancel()
    {
        Click = 0;
        if (textbox.text == "請選擇升級項目")
        {
            UI_place.isUpgrade = !UI_place.isUpgrade;
            UI_place.UI1();
        }
        else
        {
            textbox.text = "請選擇升級項目";
        }
    }
    public void check(int ATK_LV, int DEF_LV, int HP_LV, int Speed_LV, int Knockback_LV)
    {
        switch (ATK_LV)
        {
            case 1:
                break;
            case 2:
                AB1.SetActive(true);
                break;
            case 3:
                AB1.SetActive(true); AB2.SetActive(true);
                break;
            case 4:
                AB1.SetActive(true); AB2.SetActive(true); AB3.SetActive(true);
                break;
            case 5:
                AB1.SetActive(true); AB2.SetActive(true); AB3.SetActive(true); AB4.SetActive(true);
                break;
            case 6:
                AB1.SetActive(true); AB2.SetActive(true); AB3.SetActive(true); AB4.SetActive(true); AB5.SetActive(true);
                break;
        }
        switch (DEF_LV)
        {
            case 1:
                break;
            case 2:
                DB1.SetActive(true);
                break;
            case 3:
                DB1.SetActive(true); DB2.SetActive(true);
                break;
            case 4:
                DB1.SetActive(true); DB2.SetActive(true); DB3.SetActive(true);
                break;
            case 5:
                DB1.SetActive(true); DB2.SetActive(true); DB3.SetActive(true); DB4.SetActive(true);
                break;
            case 6:
                DB1.SetActive(true); DB2.SetActive(true); DB3.SetActive(true); DB4.SetActive(true); DB5.SetActive(true);
                break;
        }
        switch (HP_LV)
        {
            case 1:
                break;
            case 2:
                HB1.SetActive(true);
                break;
            case 3:
                HB1.SetActive(true); HB2.SetActive(true);
                break;
            case 4:
                HB1.SetActive(true); HB2.SetActive(true); HB3.SetActive(true);
                break;
            case 5:
                HB1.SetActive(true); HB2.SetActive(true); HB3.SetActive(true); HB4.SetActive(true);
                break;
            case 6:
                HB1.SetActive(true); HB2.SetActive(true); HB3.SetActive(true); HB4.SetActive(true); HB5.SetActive(true);
                break;
        }
        switch (Speed_LV)
        {
            case 1:
                break;
            case 2:
                SB1.SetActive(true);
                break;
            case 3:
                SB1.SetActive(true); SB2.SetActive(true);
                break;
            case 4:
                SB1.SetActive(true); SB2.SetActive(true); SB3.SetActive(true);
                break;
            case 5:
                SB1.SetActive(true); SB2.SetActive(true); SB3.SetActive(true); SB4.SetActive(true);
                break;
            case 6:
                SB1.SetActive(true); SB2.SetActive(true); SB3.SetActive(true); SB4.SetActive(true); SB5.SetActive(true);
                break;
        }
        switch (Knockback_LV)
        {
            case 1:
                break;
            case 2:
                KB1.SetActive(true);
                break;
            case 3:
                KB1.SetActive(true); KB2.SetActive(true);
                break;
            case 4:
                KB1.SetActive(true); KB2.SetActive(true); KB3.SetActive(true);
                break;
            case 5:
                KB1.SetActive(true); KB2.SetActive(true); KB3.SetActive(true); KB4.SetActive(true);
                break;
            case 6:
                KB1.SetActive(true); KB2.SetActive(true); KB3.SetActive(true); KB4.SetActive(true); KB5.SetActive(true);
                break;
        }
    }
}
