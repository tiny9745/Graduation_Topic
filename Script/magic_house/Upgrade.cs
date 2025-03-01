using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ATK_plus, DEF_plus, HP_plus, Speed_plus, Knockback_plus, comfirm, cancel;
    public Image cancel_img,comfirm_img; public Button C2, C1;
    public Sprite cancel_on, cancel_off, comfirm_on, comfirm_off;
    public GameObject AB1, AB2, AB3, AB4, AB5, DB1, DB2, DB3, DB4, DB5, HB1, HB2, HB3, HB4, HB5,
                  SB1, SB2, SB3, SB4, SB5, KB1, KB2, KB3, KB4, KB5;//,comfirm_on,comfirm_off,cancel_on,cancel_off;
    public Text textbox;
    short ATK_LV=1, DEF_LV=1, HP_LV=1, Speed_LV=1, Knockback_LV=1,Click;
    short[] ATK_price = { 100, 200, 300, 400, 500 },
    DEF_price = { 100, 200, 300, 400, 500 },
    HP_price = { 100, 200, 300, 400, 500 },
    Speed_price = { 100, 200, 300, 400, 500 },
    Knockback_price = { 100, 200, 300, 400, 500 };
    void Start()
    {
        C2.onClick.AddListener(ChangeImage1);
        C1.onClick.AddListener(ChangeImage2);
    }
    void ChangeImage1()
    {
        if (comfirm_img.sprite == comfirm_on)
        {
            comfirm_img.sprite = comfirm_off;
        }
        else
        {
            comfirm_img.sprite = comfirm_on;
        }
    }
    void ChangeImage2()
    {
        if (cancel_img.sprite == cancel_on)
        {
            cancel_img.sprite = cancel_off;
        }
        else
        {
            cancel_img.sprite = cancel_on;
        }
    }

    public void ATK()
    {
        Click = 1;
        switch (ATK_LV)
        {
            case 1:
                textbox.text = "升級價格:" + ATK_price[0];
                break;
            case 2:
                textbox.text = "升級價格:" + ATK_price[1];
                break;
            case 3:
                textbox.text = "升級價格:" + ATK_price[2];
                break;
            case 4:
                textbox.text = "升級價格:" + ATK_price[3];
                break;
            case 5:
                textbox.text = "升級價格:" + ATK_price[4];
                break;
        }
    }
    public void DEF()
    {
        Click = 2;
        switch (DEF_LV)
        {
            case 1:
                textbox.text = "升級價格:" + DEF_price[0];
                break;
            case 2:
                textbox.text = "升級價格:" + DEF_price[1];
                break;
            case 3:
                textbox.text = "升級價格:" + DEF_price[2];
                break;
            case 4:
                textbox.text = "升級價格:" + DEF_price[3];
                break;
            case 5:
                textbox.text = "升級價格:" + DEF_price[4];
                break;
        }
    }
    public void HP()
    {
        Click = 3;
        switch (HP_LV)
        {
            case 1:
                textbox.text = "升級價格:" + HP_price[0];
                break;
            case 2:
                textbox.text = "升級價格:" + HP_price[1];
                break;
            case 3:
                textbox.text = "升級價格:" + HP_price[2];
                break;
            case 4:
                textbox.text = "升級價格:" + HP_price[3];
                break;
            case 5:
                textbox.text = "升級價格:" + HP_price[4];
                break;
        }
    }
    public void Speed()
    {
        Click = 4;
        switch (Speed_LV)
        {
            case 1:
                textbox.text = "升級價格:" + Speed_price[0];
                break;
            case 2:
                textbox.text = "升級價格:" + Speed_price[1];
                break;
            case 3:
                textbox.text = "升級價格:" + Speed_price[2];
                break;
            case 4:
                textbox.text = "升級價格:" + Speed_price[3];
                break;
            case 5:
                textbox.text = "升級價格:" + Speed_price[4];
                break;
        }
    }
    public void Knockback()
    {
        Click = 5;
        switch (Knockback_LV)
        {
            case 1:
                textbox.text = "升級價格:" + Knockback_price[0];
                break;
            case 2:
                textbox.text = "升級價格:" + Knockback_price[1];
                break;
            case 3:
                textbox.text = "升級價格:" + Knockback_price[2];
                break;
            case 4:
                textbox.text = "升級價格:" + Knockback_price[3];
                break;
            case 5:
                textbox.text = "升級價格:" + Knockback_price[4];
                break;
        }
    }
    public void Pay()
    {
        switch (Click)
        {
            case 1:
                switch (ATK_LV)
                {
                    case 1:
                        if (static_parameters.money >= ATK_price[0])
                        {
                            static_parameters.money -= ATK_price[0];
                            static_parameters.MC_ATK += 3;
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
                            static_parameters.MC_ATK += 5;
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
                            static_parameters.MC_ATK += 8;
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
                            static_parameters.MC_ATK += 13;
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
                            static_parameters.MC_ATK += 21;
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
                break;
            case 2:
                switch (DEF_LV)
                {
                    case 1:
                        if (static_parameters.money >= DEF_price[0])
                        {
                            static_parameters.money -= DEF_price[0];
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
    }
    public void Cancel()
    {
        Click = 0;
    }
}
