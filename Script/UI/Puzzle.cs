using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Book,Ppage,Check;
    public GameObject Diary_text_Left, Diary_text_Right;
    public Text Diary_Left_Text, Diary_Right_Text;
    public Drag_End drag_end;
    //public GameObject Yes;
    public static bool OC = true;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void FinishDiary()
    {
        Ppage.SetActive(false);
        Check.SetActive(true);
    }

    public void comfirm()
    {
        Check.SetActive(false);
    }
    public void cancel()
    {
        Check.SetActive(false);
    }
    public void Yes_clear_dairy_text()
    {
        Diary_Left_Text.text = "";
        Diary_Right_Text.text = "";
    }
}
