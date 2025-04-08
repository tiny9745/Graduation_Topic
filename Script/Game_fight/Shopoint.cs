using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Shopoint : MonoBehaviour
{
    UI ui;
    public SpriteRenderer Goods,sign;//指定實體物件
    public Sprite item1, item2, item3, item4, item5;
    public Sprite Price1, Price2, Price3, Price4, Price5;
    public AudioSource Ad;
    public AudioClip Heal, fall;
    bool P1 = false;
    int spawn,price;
    void Start()
    {
        ui = GameObject.Find("UI").GetComponent<UI>();
        spawn = Random.Range(0, 4);
        Setgoods(spawn);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && P1)
        {
            if (static_parameters.money >= price)
            {
                static_parameters.money -= price;
                Goodseffect(spawn);
            }
            else
            {
                Ad.PlayOneShot(fall);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            P1 = true;
        }
    }
    void Setgoods(int num)
    {
        switch (num)
        {
            case 0:
                price = 100;
                Goods.sprite = item1;
                sign.sprite = Price1;
                break;
            case 1:
                price = 200;
                Goods.sprite = item2;
                sign.sprite = Price2;
                break;
            case 2:
                price = 300;
                Goods.sprite = item3;
                sign.sprite = Price3;
                break;
            case 3:
                price = 500;
                Goods.sprite = item4;
                sign.sprite = Price4;
                break;
            case 4:
                price = 800;
                Goods.sprite = item5;
                sign.sprite = Price5;
                break;
        }
    }
    void Goodseffect(int num)
    {
        switch (num)
        {
            case 0:
                static_parameters.MC_HP += 40;
                if (static_parameters.MC_HP > static_parameters.MC_HP_Max) static_parameters.MC_HP = static_parameters.MC_HP_Max;
                Ad.PlayOneShot(Heal);
                break;
            case 1:
                static_parameters.MC_HP += 90;
                if (static_parameters.MC_HP > static_parameters.MC_HP_Max) static_parameters.MC_HP = static_parameters.MC_HP_Max;
                Ad.PlayOneShot(Heal);
                break;
            case 2:
                static_parameters.MC_HP += 150;
                if (static_parameters.MC_HP > static_parameters.MC_HP_Max) static_parameters.MC_HP = static_parameters.MC_HP_Max;
                Ad.PlayOneShot(Heal);
                break;
            case 3:
                static_parameters.MC_HP += 300;
                if (static_parameters.MC_HP > static_parameters.MC_HP_Max) static_parameters.MC_HP = static_parameters.MC_HP_Max;
                Ad.PlayOneShot(Heal);
                break;
            case 4:
                static_parameters.revival = true;
                break;
            case 5:

                break;
        }
        ui.Loadmoney();
        Destroy(gameObject, 0.1f);
    }
}