using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UI : MonoBehaviour
{
    public short Diarystatus = 0;
    public Change_mood C_mood; public Ptest piece; public DragPiece_End dragPiece_End;
    public GameObject Notebook, BattleUI, Diaryslots, Diarytext;
    public GameObject Menu, CH1, CH2, CH3, CH4;
    public GameObject BookMark1, BookMark2, BookMark3, BookMark4;
    public GameObject LeftMark1, LeftMark2, LeftMark3, LeftMark4;
    public GameObject TeachiUI;
    private Color newColor = new Color(1, 1, 1, 0.5f);
    public Text money;
    public Outline money_outline;
    public Image button_image, craft_image;
    public Sprite craft_sprite;
    public Button Pageup, Pagedown;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            openclose();
            C_mood.Change();
        }
        if (SceneManager.GetActiveScene().name == "magic_house")
        {
            TeachiUI.SetActive(true);
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
        if (static_parameters.isTeaching == false && static_parameters.teaching_stop >= 6 && static_parameters.into_gameFight == false)
        {
            Debug.Log("static_parameters.Bookstate: " + static_parameters.Bookstate);
            if (!static_parameters.Bookstate)
            {
                // Time.timeScale = 0;
                static_parameters.Bookstate = true;
                Notebook.SetActive(true);
                BattleUI.SetActive(false);
            }
            else
            {
                // Time.timeScale = 1;
                static_parameters.Bookstate = false;
                Notebook.SetActive(false);
                BattleUI.SetActive(true);
            }
        }
    }
    void piecechange()
    {
        switch (Diarystatus)
        {
            case 1:
                piece.way = 6;
                break;
            default:
                piece.way = 0;
                break;
        }
        piece.page = 0;
        piece.ShowPieces();
    }
    void changechapter()
    {
        switch (Diarystatus)
        {
            case 1:
                dragPiece_End.ResetCombination();
                Menu.SetActive(false); CH1.SetActive(true); CH2.SetActive(false); CH3.SetActive(false); CH4.SetActive(false);
                BookMark1.SetActive(false); BookMark2.SetActive(true); BookMark3.SetActive(true); BookMark4.SetActive(true);
                LeftMark1.SetActive(false); LeftMark2.SetActive(false); LeftMark3.SetActive(false); LeftMark4.SetActive(false);
                break;
            case 2:
                Menu.SetActive(false); CH1.SetActive(false); CH2.SetActive(true); CH3.SetActive(false); CH4.SetActive(false);
                BookMark1.SetActive(false); BookMark2.SetActive(false); BookMark3.SetActive(true); BookMark4.SetActive(true);
                LeftMark1.SetActive(true); LeftMark2.SetActive(false); LeftMark3.SetActive(false); LeftMark4.SetActive(false);
                break;
            case 3:
                dragPiece_End.ResetCombination();
                Menu.SetActive(false); CH1.SetActive(false); CH2.SetActive(false); CH3.SetActive(true); CH4.SetActive(false);
                BookMark1.SetActive(false); BookMark2.SetActive(false); BookMark3.SetActive(false); BookMark4.SetActive(true);
                LeftMark1.SetActive(true); LeftMark2.SetActive(true); LeftMark3.SetActive(false); LeftMark4.SetActive(false);
                break;
            case 4:
                dragPiece_End.ResetCombination();
                Menu.SetActive(false); CH1.SetActive(false); CH2.SetActive(false); CH3.SetActive(false); CH4.SetActive(true);
                BookMark1.SetActive(false); BookMark2.SetActive(false); BookMark3.SetActive(false); BookMark4.SetActive(false);
                LeftMark1.SetActive(true); LeftMark2.SetActive(true); LeftMark3.SetActive(true); LeftMark4.SetActive(false);
                break;
        }
        piecechange();
        Diaryslots.SetActive(true); Diarytext.SetActive(false); Skill_public_funtion.Reading = false;
        button_image.color = newColor;
        craft_image.sprite = craft_sprite;
    }
    public void Loadmoney()
    {
        money_color();
    }

    private IEnumerator money_color()
    {
        money_outline.effectColor = new Color(95f / 255f, 99f / 255f, 238f / 255f, 1f);
        money.text = static_parameters.money.ToString();
        yield return new WaitForSeconds(0.5f);
         money_outline.effectColor = new Color(1, 1, 1, 1f);
    }


    public bool putting_diary(bool isopen)
    {
        if (isopen)
        {
            Pagedown.enabled = true;
            Pageup.enabled = true;
            return true;
        }
        else
        {
            Pagedown.enabled = false;
            Pageup.enabled = false;
            return false;
        }
    }
}
