using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plugins : MonoBehaviour
{
    // Update is called once per frame
    private bool InsertKeyPressed = false;
    public UI ui;
    public Ptest ptest;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Insert))
        {
            InsertKeyPressed = !InsertKeyPressed;
            if (InsertKeyPressed)
            {
                static_parameters.MC_ATK = 1000;
                static_parameters.MC_ATK_tmp = static_parameters.MC_ATK;
                static_parameters.MC_DEF = 1000;
                static_parameters.money += 1000;
                ptest.Test();
                ui.Loadmoney();
            }
            else
            {
                static_parameters.MC_ATK = 40;
                static_parameters.MC_ATK_tmp = static_parameters.MC_ATK;
                static_parameters.MC_DEF = 10;
                static_parameters.money -= 1000;
                if (static_parameters.money < 0) static_parameters.money = 0;
                ui.Loadmoney();
            }
        }
    }
}
