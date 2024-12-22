using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Iconpress : MonoBehaviour
{
    public Diary_icon icon;
    public Text TitleText, ContentText;
    public string title, content;
    public void Press()
    {
        TitleText.text = title;
        ContentText.text = content;
    }
}
