using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting_keybroad : MonoBehaviour
{
    // Start is called before the first frame update
    static public bool ESC_col = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (ESC_col)
            {
                ESC_col = false;
                Time.timeScale = 1;
            }
            else
            {
                ESC_col = true;
                Time.timeScale = 0;
            }
        }
    }
}
