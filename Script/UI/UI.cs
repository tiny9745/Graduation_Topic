using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;
public class UI : MonoBehaviour
{
    short Diarystatus = 0;
    public GameObject Notebook; public GameObject BattleUI;
    public GameObject Menu; public GameObject MC; public GameObject Word; public GameObject Diary; public GameObject Yes;
    public GameObject BookMark1,BookMark2,BookMark3,BookMark4;
    public GameObject LeftMark1,LeftMark2,LeftMark3,LeftMark4;

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
        changechapter();
    }
    public void Onclick2()
    {
        Diarystatus = 2;
        changechapter();
    }
    public void Onclick3()
    {
        Diarystatus = 3;
        changechapter();
    }
    public void Onclick4()
    {
        Diarystatus = 4;
        changechapter();
    }
    public void openclose()
    {
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
    void changechapter()
    {
        switch(Diarystatus)
        {
            case 1:
                Menu.SetActive(false);MC.SetActive(true);Word.SetActive(false);Diary.SetActive(false);Yes.SetActive(false);
                BookMark1.SetActive(false);BookMark2.SetActive(true); BookMark3.SetActive(true);BookMark4.SetActive(true);
                LeftMark1.SetActive(false); LeftMark2.SetActive(false); LeftMark3.SetActive(false); LeftMark4.SetActive(false);            
                break;
            case 2:
                Menu.SetActive(false);MC.SetActive(false);Word.SetActive(true);Diary.SetActive(false);Yes.SetActive(false);
                BookMark1.SetActive(false);BookMark2.SetActive(false); BookMark3.SetActive(true);BookMark4.SetActive(true);
                LeftMark1.SetActive(true); LeftMark2.SetActive(false); LeftMark3.SetActive(false); LeftMark4.SetActive(false);
                break;
            case 3:
                Menu.SetActive(false);MC.SetActive(false);Word.SetActive(false);Diary.SetActive(true);Yes.SetActive(false);
                BookMark1.SetActive(false);BookMark2.SetActive(false); BookMark3.SetActive(false);BookMark4.SetActive(true);
                LeftMark1.SetActive(true); LeftMark2.SetActive(true); LeftMark3.SetActive(false); LeftMark4.SetActive(false);
                break;
            case 4:
                Menu.SetActive(false);MC.SetActive(false);Word.SetActive(false);Diary.SetActive(false);Yes.SetActive(true);
                BookMark1.SetActive(false);BookMark2.SetActive(false); BookMark3.SetActive(false);BookMark4.SetActive(false);
                LeftMark1.SetActive(true); LeftMark2.SetActive(true); LeftMark3.SetActive(true); LeftMark4.SetActive(false);
                break;
        }
    }   
}
