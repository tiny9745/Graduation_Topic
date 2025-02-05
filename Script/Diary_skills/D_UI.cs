using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class D_UI : MonoBehaviour
{
    static public D_slot[] DSlot;
    public GameObject Pageup, Pagedown;
    public Transform DSlotPoint;
    public Text Diary_title, Diary_content_lift, Diary_content_right;
    int itemsPerPage = 8,startIndex;
    public int page = 0;
    void Start()
    {
        IconManager.Instance.IconInventoryCallBack += UpdateIcon;
        DSlot = DSlotPoint.GetComponentsInChildren<D_slot>();
    }

    // Update is called once per frame
    void UpdateIcon()
    {
        startIndex = page * itemsPerPage;
        for (int i = startIndex; i <startIndex+8; i++)
        {
            if (i < IconManager.Instance.IconList.Count)
            {
                DSlot[i].AddIcon(IconManager.Instance.IconList[i]);
            }else
            {
                DSlot[i].Clean();
            }
        }
    }
    public void NextPage()
    {
        // Check if the next page exists
        if ((page + 1) * itemsPerPage < IconManager.Instance.IconList.Count)
        {
            page++;
        }
    }
    public void PreviousPage()
    {
        if (page > 0) page--;
    }


    private void overflow_text(string Read_text)
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
