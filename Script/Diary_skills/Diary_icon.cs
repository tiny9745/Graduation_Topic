using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Diary_icon/icon")]

public class Diary_icon : ScriptableObject
{
    public int iconID;
    public string iconName;
    public Sprite iconImage;
    public string survival_state = "Dead";
    public string title,content;
}
