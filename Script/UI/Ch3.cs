using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ch3 : MonoBehaviour
{
    static public int page = 0;
    public GameObject Forward, Backward,Checkpage,Diarypage;
    public Image Background;
    public Sprite Page_word, Page_work;
    public Text Diary_Left, Diary_Right;string Read_text;
    int Max_page = 0;

    public UI UI; public Drag_End D_text;
    // Start is called before the first frame update
    void Start()
    {
        Open();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Open()
    {
        Max_page = 0;
        for (int i = 0; i < 4; i++)
        {
            if (static_parameters.Text_box_state[i] != 0)
            {
                Max_page++;
            }
        }
    }
    public void Forwards()
    {
        page++;
        Changepages();
    }
    public void Backwards()
    {
        page--;
        Changepages();    
    }

    void Changepages()
    {
        if (page == 0){
            Backward.SetActive(false);
            Background.sprite = Page_work;
            Checkpage.SetActive(true);
            Diarypage.SetActive(false);
        }else{
            Backward.SetActive(true);
            Background.sprite = Page_word;
            Checkpage.SetActive(false);
            Diarypage.SetActive(true);
        }

        if (page == (Max_page/2)){
            Forward.SetActive(false);
        }else{
            Forward.SetActive(true);
        }
        Write();
    }

    public void Read()
    {
        Read_text = D_text.all_text;       
    }
    void Write()
    {
        if (UI.Diarystatus<3)
        {
            if(UI.Diarystatus==1){
                Diary_Left.text = Read_text;
            }else{
                Diary_Right.text = Read_text;
            }
        }else{
            Diary_Left.text = Read_text;
            Diary_Right.text = Read_text;
        }

    }
}
