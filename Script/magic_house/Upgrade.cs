using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ATK_plus, DEF_plus, HP_plus, Speed_plus, Knockback_plus, comfirm, cancel;
    public GameObject B1, B2, B3, B4, B5;
    public Text textbox;
    short ATK_LV, DEF_LV, HP_LV, Speed_LV, Knockback_LV, LV=1, Click;
    short[] ATK_price = { 100, 200, 300, 400, 500 },
    DEF_price = { 100, 200, 300, 400, 500 },
    HP_price = { 100, 200, 300, 400, 500 },
    Speed_price = { 100, 200, 300, 400, 500 },
    Knockback_price = { 100, 200, 300, 400, 500 };
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ATK()
    {
        Click = 1;
        switch (LV)
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
        switch (LV)
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
        switch (LV)
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
        switch (LV)
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
        switch (LV)
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
                switch (LV)
                {
                    case 1:
                        if (static_parameters.money >= ATK_price[0])
                        {
                            static_parameters.money -= ATK_price[0];
                            LV++;B1.SetActive(true);
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
                            LV++;B2.SetActive(true);
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
                            LV++;B3.SetActive(true);
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
                            LV++;B4.SetActive(true);
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
                            LV++;B5.SetActive(true);
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
                switch (LV)
                {
                    case 1:
                        if (static_parameters.money >= DEF_price[0])
                        {
                            static_parameters.money -= DEF_price[0];
                            LV++;B1.SetActive(true);
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
                            LV++;B2.SetActive(true);
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
                            LV++;B3.SetActive(true);
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
                            LV++;B4.SetActive(true);
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
                            LV++;B5.SetActive(true);
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
                switch (LV)
                {
                    case 1:
                        if (static_parameters.money >= HP_price[0])
                        {
                            static_parameters.money -= HP_price[0];
                            LV++;B1.SetActive(true);
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
                            LV++;B2.SetActive(true);
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
                            LV++;B3.SetActive(true);
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
                            LV++;B4.SetActive(true);
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
                            LV++;B5.SetActive(true);
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
                switch (LV)
                {
                    case 1:
                        if (static_parameters.money >= Speed_price[0])
                        {
                            static_parameters.money -= Speed_price[0];
                            LV++;B1.SetActive(true);
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
                            LV++;B2.SetActive(true);
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
                            LV++;B3.SetActive(true);
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
                            LV++;B4.SetActive(true);
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
                            LV++;B5.SetActive(true);
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
                switch (LV)
                {
                    case 1:
                        if (static_parameters.money >= Knockback_price[0])
                        {
                            static_parameters.money -= Knockback_price[0];
                            LV++;B1.SetActive(true);
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
                            LV++;B2.SetActive(true);
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
                            LV++;B3.SetActive(true);
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
                            LV++;B4.SetActive(true);
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
                            LV++;B5.SetActive(true);
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
