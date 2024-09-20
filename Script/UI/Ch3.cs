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
    int Max_page = 0;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            if (static_parameters.Text_box_state[i] != 0)
            {
                Max_page++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
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
        if (page == 0)
        {
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

        if (page == Max_page)
        {
            Forward.SetActive(false);
        }else{
            Forward.SetActive(true);
        }
    }
}
