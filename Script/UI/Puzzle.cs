using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Book; public GameObject Extra1; public GameObject Extra2;
    public Image Page_now;
    public Sprite Page_change; public Sprite Page_check;
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
    public void ChangePage()
    {
        Page_now.sprite = Page_change;
    }
    public void CheckPage()
    {
        Page_now.sprite = Page_check;
    }
    public void MoveDiarytoleft()
    {
        if (OC)
        {
            Diary_text_Left.SetActive(true);
            Diary_text_Right.SetActive(true);
            Vector3 targetPosition1 = new Vector3(-300, Book.transform.localPosition.y, Book.transform.localPosition.z);
            Book.transform.localPosition = targetPosition1;

            Vector3 targetPosition2 = new Vector3(-250, Extra1.transform.localPosition.y, Extra1.transform.localPosition.z);
            Extra1.transform.localPosition = targetPosition2;
            Vector3 targetPosition3 = new Vector3(Extra2.transform.localPosition.x - 250, Extra2.transform.localPosition.y, Extra2.transform.localPosition.z);
            Extra2.transform.localPosition = targetPosition3;
            OC = false;
        }
    }
    public void MoveDiarytoright()
    {
        if (!OC)
        {
            Diary_text_Left.SetActive(false);
            Diary_text_Right.SetActive(false);
            Vector3 targetPosition1 = new Vector3(0, Book.transform.localPosition.y, Book.transform.localPosition.z);
            Book.transform.localPosition = targetPosition1;

            Vector3 targetPosition2 = new Vector3(0, Extra1.transform.localPosition.y, Extra1.transform.localPosition.z);
            Extra1.transform.localPosition = targetPosition2;
            Vector3 targetPosition3 = new Vector3(1408, Extra2.transform.localPosition.y, Extra2.transform.localPosition.z);
            Extra2.transform.localPosition = targetPosition3;
            OC = true;
        }
    }

    public void comfirm()
    {
        Extra2.SetActive(false);
        MoveDiarytoright();
        CheckPage();
    }
    public void cancel()
    {
        Extra2.SetActive(false);
        ChangePage();
    }
    public void Yes_clear_dairy_text()
    {
        Diary_Left_Text.text = "";
        Diary_Right_Text.text = "";
    }
}
