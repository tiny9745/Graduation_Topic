using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Upgrade : MonoBehaviour
{
    // Start is called before the first frame update
    UI ui;
    public GameObject ATK_plus, DEF_plus, HP_plus, Speed_plus, Knockback_plus;
    public GameObject[] AB, DB, HB, SB, KB;
    public Text namebox, textbox;
    public UI_Place UI_place;
    public static short ATK_LV = 1, DEF_LV = 1, HP_LV = 1, Speed_LV = 1, Knockback_LV = 1, Click = 0;
    short[] ATK_price = { 30, 45, 70, 100, 140 },
    DEF_price = { 30, 50, 75, 100, 140 },
    HP_price = { 30, 45, 70, 100, 140 },
    Speed_price = { 35, 50, 80, 100, 170 },
    Knockback_price = { 35, 60, 80, 100, 170 };

    float[] ATK_add = { 13, 21, 34, 55, 89 },
    DEF_add = { 8, 13, 21, 34, 55 },
    HP_add = { 50, 80, 130, 210, 340 },
    Speed_add = { 3, 4, 5, 5, 6 },
    Knockback_add = { 0.3f, 0.5f, 0.8f, 1.3f, 2.1f };
    void Start()
    {
        namebox.text = "";
        textbox.text = "請選擇升級項目";
    }
    public void ATK()
    {
        Click = 1;
        namebox.text = "攻擊";
        textbox.text = "小拳拳捶你胸口！你說不痛？哼！升級成超大拳頭，甜蜜爆擊你喲！\n";
        if (ATK_LV < 6) textbox.text += "升級價格:" + ATK_price[ATK_LV - 1] + "元";
    }
    public void DEF()
    {
        Click = 2;
        namebox.text = "防禦";
        textbox.text = "神力盾牌速來加持，讓怪物的攻擊變得跟奶油一樣輕飄飄又軟綿綿！\n";
        if (DEF_LV < 6) textbox.text += "升級價格:" + DEF_price[DEF_LV - 1] + "元";
    }
    public void HP()
    {
        Click = 3;
        namebox.text = "血量";
        textbox.text = "來吧，把草莓蛋糕疊得越高越好！只會增加血量，絕對不加血壓哦！\n";
        if (HP_LV < 6) textbox.text += "升級價格:" + HP_price[HP_LV - 1] + "元";
    }
    public void Speed()
    {
        Click = 4;
        namebox.text = "移速";
        textbox.text = "好像在腳底抹滿了巧克力醬，讓速度快到連流星都追不上你的尾巴！\n";
        if (Speed_LV < 6) textbox.text += "升級價格:" + Speed_price[Speed_LV - 1] + "元";
    }
    public void Knockback()
    {
        Click = 5;
        namebox.text = "擊退";
        textbox.text = "不要小看我的力量，看我輕輕一個揮擊，就把怪物打去外太空度假！\n";
        if (Speed_LV < 6) textbox.text += "升級價格:" + Knockback_price[Knockback_LV - 1] + "元";
    }
    public void Pay()
    {
        ui = GameObject.Find("UI").GetComponent<UI>();
        switch (Click)
        {
            case 1:
                if (ATK_LV == 6)
                {
                    textbox.text = "已達最高等級";
                }
                else if (static_parameters.money >= ATK_price[ATK_LV - 1])
                {
                    static_parameters.money -= ATK_price[ATK_LV - 1];
                    static_parameters.MC_ATK += ATK_add[ATK_LV - 1];
                    static_parameters.MC_throw += (int)ATK_add[ATK_LV - 1];
                    ATK_LV++; AB[ATK_LV - 2].SetActive(true);
                    textbox.text = $"升級成功，剩餘{static_parameters.money}元";
                    if (ATK_LV < 6) textbox.text += "\r\n下一級升級價格:" + ATK_price[ATK_LV - 1] + "元";
                    skill_nmueric_renew_ATK();
                }
                else
                {
                    textbox.text = $"金錢不足{ATK_price[ATK_LV - 1] - static_parameters.money}元";
                }
                break;
            case 2:
                if (DEF_LV == 6)
                {
                    textbox.text = "已達最高等級";
                }
                else if (static_parameters.money >= DEF_price[DEF_LV - 1])
                {
                    static_parameters.money -= DEF_price[DEF_LV - 1];
                    static_parameters.MC_DEF += DEF_add[DEF_LV - 1];
                    DEF_LV++; DB[DEF_LV - 2].SetActive(true);
                    textbox.text = $"升級成功，剩餘{static_parameters.money}元";
                    if (DEF_LV < 6) textbox.text += "\r\n下一級升級價格:" + DEF_price[DEF_LV - 1] + "元";
                }
                else
                {
                    textbox.text = $"金錢不足{DEF_price[DEF_LV - 1] - static_parameters.money}元";
                }
                break;
            case 3:
                if (HP_LV == 6)
                {
                    textbox.text = "已達最高等級";
                }
                else if (static_parameters.money >= HP_price[HP_LV - 1])
                {
                    static_parameters.money -= HP_price[HP_LV - 1];
                    static_parameters.MC_HP_Max += HP_add[HP_LV - 1]; static_parameters.MC_HP = static_parameters.MC_HP_Max;
                    HP_LV++; HB[HP_LV - 2].SetActive(true);
                    textbox.text = $"升級成功，剩餘{static_parameters.money}元";
                    if (HP_LV < 6) textbox.text += "\r\n下一級升級價格:" + HP_price[HP_LV - 1] + "元";
                }
                else
                {
                    textbox.text = $"金錢不足{HP_price[HP_LV - 1] - static_parameters.money}元";
                }
                break;
            case 4:
                if (Speed_LV == 6)
                {
                    textbox.text = "已達最高等級";
                }
                else if (static_parameters.money >= Speed_price[Speed_LV - 1])
                {
                    static_parameters.money -= Speed_price[Speed_LV - 1];
                    static_parameters.MC_Wspeed += Speed_add[Speed_LV - 1];
                    Speed_LV++; SB[Speed_LV - 2].SetActive(true);
                    textbox.text = $"升級成功，剩餘{static_parameters.money}元";
                    if (Speed_LV < 6) textbox.text += "\r\n下一級升級價格:" + Speed_price[Speed_LV - 1] + "元";
                    skill_nmueric_renew_Speed();
                }
                else
                {
                    textbox.text = $"金錢不足{Speed_price[Speed_LV - 1] - static_parameters.money}元";
                }
                break;
            case 5:
                if (Knockback_LV == 6)
                {
                    textbox.text = "已達最高等級";
                }
                else if (static_parameters.money >= Knockback_price[Knockback_LV - 1])
                {
                    static_parameters.money -= Knockback_price[Knockback_LV - 1];
                    static_parameters.knockback_force += Knockback_add[Knockback_LV - 1];
                    Knockback_LV++; KB[Knockback_LV - 2].SetActive(true);
                    textbox.text = $"升級成功，剩餘{static_parameters.money}元";
                    if (Knockback_LV < 6) textbox.text += "\r\n下一級升級價格:" + Knockback_price[Knockback_LV - 1] + "元";
                }
                else
                {
                    textbox.text = $"金錢不足{Knockback_price[Knockback_LV - 1] - static_parameters.money}元";
                }
                break;
            default:
                namebox.text = "";
                textbox.text = "請選擇升級項目";
                break;
        }
        ui.Loadmoney();
    }
    public void Cancel()
    {
        Click = 0;
        namebox.text = "";
        textbox.text = "請選擇升級項目";
    }
    public void Close()
    {
        Cancel();
        UI_place.isUpgrade = !UI_place.isUpgrade;
        UI_place.UI1();
    }
    public void check(int ATK_LV, int DEF_LV, int HP_LV, int Speed_LV, int Knockback_LV)
    {
        switch (ATK_LV)
        {
            case 1:
                break;
            case 2:
                AB[0].SetActive(true);
                break;
            case 3:
                AB[0].SetActive(true); AB[1].SetActive(true);
                break;
            case 4:
                AB[0].SetActive(true); AB[1].SetActive(true); AB[2].SetActive(true);
                break;
            case 5:
                AB[0].SetActive(true); AB[1].SetActive(true); AB[2].SetActive(true); AB[3].SetActive(true);
                break;
            case 6:
                AB[0].SetActive(true); AB[1].SetActive(true); AB[2].SetActive(true); AB[3].SetActive(true); AB[4].SetActive(true);
                break;
        }
        switch (DEF_LV)
        {
            case 1:
                break;
            case 2:
                DB[0].SetActive(true);
                break;
            case 3:
                DB[0].SetActive(true); DB[1].SetActive(true);
                break;
            case 4:
                DB[0].SetActive(true); DB[1].SetActive(true); DB[2].SetActive(true);
                break;
            case 5:
                DB[0].SetActive(true); DB[1].SetActive(true); DB[2].SetActive(true); DB[3].SetActive(true);
                break;
            case 6:
                DB[0].SetActive(true); DB[1].SetActive(true); DB[2].SetActive(true); DB[3].SetActive(true); DB[4].SetActive(true);
                break;
        }
        switch (HP_LV)
        {
            case 1:
                break;
            case 2:
                HB[0].SetActive(true);
                break;
            case 3:
                HB[0].SetActive(true); HB[1].SetActive(true);
                break;
            case 4:
                HB[0].SetActive(true); HB[1].SetActive(true); HB[2].SetActive(true);
                break;
            case 5:
                HB[0].SetActive(true); HB[1].SetActive(true); HB[2].SetActive(true); HB[3].SetActive(true);
                break;
            case 6:
                HB[0].SetActive(true); HB[1].SetActive(true); HB[2].SetActive(true); HB[3].SetActive(true); HB[4].SetActive(true);
                break;
        }
        switch (Speed_LV)
        {
            case 1:
                break;
            case 2:
                SB[0].SetActive(true);
                break;
            case 3:
                SB[0].SetActive(true); SB[1].SetActive(true);
                break;
            case 4:
                SB[0].SetActive(true); SB[1].SetActive(true); SB[2].SetActive(true);
                break;
            case 5:
                SB[0].SetActive(true); SB[1].SetActive(true); SB[2].SetActive(true); SB[3].SetActive(true);
                break;
            case 6:
                SB[0].SetActive(true); SB[1].SetActive(true); SB[2].SetActive(true); SB[3].SetActive(true); SB[4].SetActive(true);
                break;
        }
        switch (Knockback_LV)
        {
            case 1:
                break;
            case 2:
                KB[0].SetActive(true);
                break;
            case 3:
                KB[0].SetActive(true); KB[1].SetActive(true);
                break;
            case 4:
                KB[0].SetActive(true); KB[1].SetActive(true); KB[2].SetActive(true);
                break;
            case 5:
                KB[0].SetActive(true); KB[1].SetActive(true); KB[2].SetActive(true); KB[3].SetActive(true);
                break;
            case 6:
                KB[0].SetActive(true); KB[1].SetActive(true); KB[2].SetActive(true); KB[3].SetActive(true); KB[4].SetActive(true);
                break;
        }
    }

    private void skill_nmueric_renew_ATK()
    {
        static_parameters.MC_ATK_tmp = static_parameters.MC_ATK;
        Skill_public_funtion.skill_03_MC_atk = static_parameters.MC_ATK;
        Skill_public_funtion.skill_04_MC_atk = static_parameters.MC_ATK;
        Skill_public_funtion.skill_05_MC_atk = static_parameters.MC_ATK;
    }
    private void skill_nmueric_renew_Speed()
    {
        static_parameters.MC_Wspeed_tmp = static_parameters.MC_Wspeed;
        Skill_public_funtion.skill_32_speed = static_parameters.MC_Wspeed;
    }
}
