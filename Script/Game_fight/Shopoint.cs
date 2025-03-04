using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Shopoint : MonoBehaviour
{
    // Start is called before the first frame update
    //public GameObject Upgrade;
    public SpriteRenderer Goods;//指定實體物件
    public Sprite item1,item2,item3,item4,item5;
    bool P1 = false;
    int spawn, price;
    void Start()
    {
        spawn = Random.Range(0, 5);
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
                Debug.Log("Not enough money");
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
                price = 50;
                Goods.sprite = item1;
                break;
            case 1:
                price = 100;
                Goods.sprite = item2;
                break;
            case 2:
                price = 200;
                Goods.sprite = item3;
                break;
            case 3:
                price = 250;
                Goods.sprite = item4;
                break;
            case 4:
                price = 500;
                Goods.sprite = item5;
                break;
            case 5:
                price = 50;
                break;
        }
    }
    void Goodseffect(int num)
    {
        switch (num)
        {
            case 0:
                //static_parameters.MC_HP_Max += 50;
                //static_parameters.MC_HP += 50;
                Debug.Log("A1");
                break;
            case 1:

                break;
            case 2:

                break;
            case 3:

                break;
            case 4:

                break;
            case 5:

                break;

        }
    }
}