using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;
public class UI : MonoBehaviour
{
    public short Diarystatus = 0;
    public GameObject Notebook,BattleUI;
    public GameObject Menu,CH1,CH2,CH3,CH4;
    public GameObject BookMark1,BookMark2,BookMark3,BookMark4;
    public GameObject LeftMark1,LeftMark2,LeftMark3,LeftMark4;
    public Ptest piece;
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
        piece.itemsPerPage = 16;
        changechapter();
    }
    public void Onclick2()
    {
        Diarystatus = 2;
        piece.itemsPerPage = 16;
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
    void piecechange()
    {
        piece.way = 0;
        piece.page = 0;
        piece.ShowPieces();
    }
    void changechapter()
    {
        switch(Diarystatus)
        {
            case 1:
                Menu.SetActive(false);CH1.SetActive(true);CH2.SetActive(false);CH3.SetActive(false);CH4.SetActive(false);
                BookMark1.SetActive(false);BookMark2.SetActive(true); BookMark3.SetActive(true);BookMark4.SetActive(true);
                LeftMark1.SetActive(false); LeftMark2.SetActive(false); LeftMark3.SetActive(false); LeftMark4.SetActive(false);            
                break;
            case 2:
                Menu.SetActive(false);CH1.SetActive(false);CH2.SetActive(true);CH3.SetActive(false);CH4.SetActive(false);
                BookMark1.SetActive(false);BookMark2.SetActive(false); BookMark3.SetActive(true);BookMark4.SetActive(true);
                LeftMark1.SetActive(true); LeftMark2.SetActive(false); LeftMark3.SetActive(false); LeftMark4.SetActive(false);
                break;
            case 3:
                Menu.SetActive(false);CH1.SetActive(false);CH2.SetActive(false);CH3.SetActive(true);CH4.SetActive(false);
                BookMark1.SetActive(false);BookMark2.SetActive(false); BookMark3.SetActive(false);BookMark4.SetActive(true);
                LeftMark1.SetActive(true); LeftMark2.SetActive(true); LeftMark3.SetActive(false); LeftMark4.SetActive(false);
                break;
            case 4:
                Menu.SetActive(false);CH1.SetActive(false);CH2.SetActive(false);CH3.SetActive(false);CH4.SetActive(true);
                BookMark1.SetActive(false);BookMark2.SetActive(false); BookMark3.SetActive(false);BookMark4.SetActive(false);
                LeftMark1.SetActive(true); LeftMark2.SetActive(true); LeftMark3.SetActive(true); LeftMark4.SetActive(false);
                break;
        }
        piecechange();
    }
}
