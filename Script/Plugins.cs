using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
                static_parameters.MC_ATK += 1000;
                static_parameters.MC_ATK_tmp = static_parameters.MC_ATK;
                static_parameters.MC_DEF += 1000;
                static_parameters.money += 1000;
                ptest.Test();
                ui.Loadmoney();
            }
            else
            {
                static_parameters.MC_ATK -= 1000;
                static_parameters.MC_ATK_tmp = static_parameters.MC_ATK;
                static_parameters.MC_DEF -= 1000;
                static_parameters.money -= 1000;
                if (static_parameters.money < 0) static_parameters.money = 0;
                ui.Loadmoney();
            }
        }
        if (Input.GetKeyDown(KeyCode.F11) && static_parameters.into_gameFight_Levels < 5 && static_parameters.stage_number < 4 && static_parameters.teaching_stop >= 100)
        {
            static_parameters.Change_enemy = 0;
            static_parameters.into_gameFight_Levels = 4;
            static_parameters.stage_number = 4;
            SceneManager.LoadScene("Fight_241130");
        }
        else if (Input.GetKeyDown(KeyCode.F11))
        {
            Debug.Log("static_parameters.into_gameFight_Levels = " + static_parameters.into_gameFight_Levels);
            Debug.Log("static_parameters.stage_number = " + static_parameters.stage_number);
        }
        if (Input.GetKeyDown(KeyCode.F12) && static_parameters.into_gameFight_Levels <= 5 && static_parameters.stage_number < 5 && static_parameters.teaching_stop >= 100)
        {

            static_parameters.Change_enemy = 0;
            ptest.Test();
            static_parameters.into_gameFight_Levels = 5;
            static_parameters.stage_number = 5;
            SceneManager.LoadScene("Fight_241130");
        }
    }
}
