using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class D_UI : MonoBehaviour
{
    static public D_slot[] DSlot;
    public GameObject Pageup, Pagedown, Diary, Text;
    public Transform DSlotPoint;
    public Text Diary_title, Diary_content_lift, Diary_content_right;
    int itemsPerPage = 8, startIndex;
    public int page = 0;
    public AudioSource Ad;
    public AudioClip Flip;
    void Start()
    {
        IconManager.Instance.IconInventoryCallBack += UpdateIcon;
        DSlot = DSlotPoint.GetComponentsInChildren<D_slot>();
    }
    void Awake()
    {
        //sbutton();
    }

    // Update is called once per frame
    void UpdateIcon()
    {
        startIndex = page * itemsPerPage;
        Debug.Log("startIndex: " + startIndex);
        for (int i = startIndex; i < startIndex + 8; i++)
        {
            Debug.Log("i: " + i);
            if (i < IconManager.Instance.IconList.Count)
            {
                DSlot[i - startIndex].AddIcon(IconManager.Instance.IconList[i]);
            }
            else
            {
                DSlot[i - startIndex].Clean();
            }
        }
    }
    public void NextPage()
    {
        if ((page + 1) * itemsPerPage < IconManager.Instance.IconList.Count)
        {
            page++;
            Ad.PlayOneShot(Flip);
        }
        UpdateIcon();
        button();
    }
    public void PreviousPage()
    {
        if (Skill_public_funtion.Reading)
        {
            Diary.SetActive(true); Text.SetActive(false);
            Skill_public_funtion.Reading = false;
        }
        else
        {
            if (page > 0)
            {
                page--;
            }
            else
            {
                page = 0;
            }
        }
        Ad.PlayOneShot(Flip);
        UpdateIcon();
        button();
    }
    public void button()
    {
        if (Skill_public_funtion.Reading)
        {
            Pagedown.SetActive(false); Pageup.SetActive(true);
        }
        else
        {
            Debug.Log("page");
            if (page == 0)
            {
                Pageup.SetActive(false);
            }
            else
            {
                Pageup.SetActive(true);
            }
            Debug.Log((page + 1) * itemsPerPage + " " + IconManager.Instance.IconList.Count);
            if ((page + 1) * itemsPerPage < IconManager.Instance.IconList.Count)
            {
                Pagedown.SetActive(true);
                Debug.Log("pagedownT");
            }
            else
            {
                Pagedown.SetActive(false);
                Debug.Log("pagedownF");
            }
        }

    }


    public void overflow_text(string Read_text)
    {
        TextGenerator textGen = new TextGenerator();
        TextGenerationSettings settings = Diary_content_lift.GetGenerationSettings(Diary_content_lift.rectTransform.rect.size);

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
            Diary_content_lift.text = Read_text.Substring(0, overflowIndex);
            Diary_content_right.text = Read_text.Substring(overflowIndex);
        }
        else
        {
            Diary_content_lift.text = Read_text;
            Diary_content_right.text = "";
        }
    }
}
