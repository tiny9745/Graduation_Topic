using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ch3 : MonoBehaviour
{
    static public int page = 0;
    public GameObject Forward, Backward, Checkpage, Diarypage;
    public Image Background;
    public Sprite Page_word, Page_work;
    public Text Diary_Left, Diary_Right;
    public string[] Read_text;
    int Max_page = 0;

    public UI UI;
    // Start is called before the first frame update
    void Start()
    {
        Read_text = new string[4];
        for (int i = 0; i < 4; i++)
        {
            Read_text[i] = "";
        }
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
        if (page == 0)
        {
            Backward.SetActive(false);
            Background.sprite = Page_work;
            Checkpage.SetActive(true);
            Diarypage.SetActive(false);
        }
        else
        {
            Backward.SetActive(true);
            Background.sprite = Page_word;
            Checkpage.SetActive(false);
            Diarypage.SetActive(true);
        }

        if (page == Max_page)
        {
            Forward.SetActive(false);
        }
        else
        {
            Forward.SetActive(true);
        }
        Write();
    }

    public void Read()
    {
        // Read_text = Drag_End.all_text;
    }
    void Write()
    {
        switch (page)
        {
            case 1:
                overflow_text(Read_text[0]);
                // Diary_Left.text = Read_text[0];
                break;
            case 2:
                overflow_text(Read_text[1]);
                break;
            case 3:
                overflow_text(Read_text[2]);
                break;
            case 4:
                overflow_text(Read_text[3]);
                break;
        }
    }

    private void overflow_text(string Read_text)
    {
        TextGenerator textGen = new TextGenerator();
        TextGenerationSettings settings = Diary_Left.GetGenerationSettings(Diary_Left.rectTransform.rect.size);

        int charIndex = 0;
        int overflowIndex = 0;
        bool isLeftFull = false;

        // Find the point at which the text overflows
        while (charIndex < Read_text.Length)
        {
            string tempText = Read_text.Substring(0, charIndex + 1);
            textGen.Populate(tempText, settings);
            if (textGen.characterCountVisible < tempText.Length - 2)
            {
                isLeftFull = true;
                overflowIndex = charIndex;
                break;
            }
            charIndex++;
        }

        // Assign text to left and right texts
        if (isLeftFull)
        {
            Diary_Left.text = Read_text.Substring(0, overflowIndex);
            Diary_Right.text = Read_text.Substring(overflowIndex);
        }
        else
        {
            Diary_Left.text = Read_text;
            Diary_Right.text = "";
        }
    }
}
