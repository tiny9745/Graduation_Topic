using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Diary_icon/icon")]

public class Diary_icon : ScriptableObject
{
    public int iconID;
    // public string iconName;
    public Sprite iconImage;
    public string skill_title,skill_content;
    public string diary_title,diary_content;
    public string date;
}
