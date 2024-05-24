using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;
public class UI : MonoBehaviour
{
    int Diarystatus = 0;
    public GameObject Notebook; public GameObject BattleUI;
    public GameObject Background;public GameObject Menulayout;
    public GameObject BookMarks; public GameObject LeftMark;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z)){
            openclose();
        }
    }
    public void Onclick1()
    {
        Diarystatus = 1;
    }
    public void Onclick2()
    {
        Diarystatus = 2;
    }
    public void Onclick3()
    {
        Diarystatus = 3;
    }
    public void Onclick4()
    {
        Diarystatus = 4;
    }
    public void openclose()
    {
        print(static_parameters.Bookstate);
        if (!static_parameters.Bookstate)
        {
            Time.timeScale = 0;
            static_parameters.Bookstate = true;
            Notebook.SetActive(true);
            BattleUI.SetActive(false);
        }
        else
        {
            Time.timeScale = 1;
            static_parameters.Bookstate = false;
            Notebook.SetActive(false);
            BattleUI.SetActive(true);
        }
    }
}
