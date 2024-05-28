using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text_Array : MonoBehaviour
{
    // 全域變數定義
    static public List<Text_content> Text_contents;

    void Awake()
    {
        Text_contents = new List<Text_content>();

        // 添加Text_content項目
        Text_contents.Add(new Text_content("激昂的", 0, 0, 0, 5));
        Text_contents.Add(new Text_content("頹喪的", 1, 1, 1, 2.2f));
        Text_contents.Add(new Text_content("憤慨的", 2, 2, 2, 1.1f));
        Text_contents.Add(new Text_content("慌忙的", 3, 3, 3, 0.6f));
        Text_contents.Add(new Text_content("無聊的", 4, 1, 1, 1.05f));
        Text_contents.Add(new Text_content("疲憊的", 5, 1, 3, 0.8f));

        // 打印Text_contents的內容
        PrintTextContents();
    }

    void PrintTextContents()
    {
        foreach (Text_content content in Text_contents)
        {
            //Debug.Log($"Name_Text: {content.Name_Text}, Name_number: {content.Name_number}, Feeling: {content.Feeling}, Attribute_effect_name: {content.Attribute_effect_name}, Attribute_effect_value: {content.Attribute_effect_value}");
        }
    }
}

public class Text_content
{
    public string Name_Text;
    public int Name_number;
    public int Feeling; // 0=happy,1=sad,2=angry,3=surprise
    public int Attribute_effect_name; // 0=HP, 1=att_pow, 2=att_speed, 3=walk_speed, 4=defense
    public float Attribute_effect_value;

    public Text_content(string Name_Text, int Name_number, int Feeling, int Attribute_effect_name, float Attribute_effect_value)
    {
        this.Name_Text = Name_Text;
        this.Name_number = Name_number;
        this.Feeling = Feeling;
        this.Attribute_effect_name = Attribute_effect_name;
        this.Attribute_effect_value = Attribute_effect_value;
    }
}
