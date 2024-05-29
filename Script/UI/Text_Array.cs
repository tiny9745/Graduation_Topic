using System.Collections.Generic;
using UnityEngine;

public class Text_Array : MonoBehaviour
{
    // 全局变量定义
    static public List<Text_content> Text_contents = new List<Text_content>();

    void Awake()
    {
        // 初始化Text_content项
        Text_contents.Add(new Text_content(0, "激昂的", 0, 0, 5, false));
        Text_contents.Add(new Text_content(1, "頹喪的", 1, 1, 2.2f, false));
        Text_contents.Add(new Text_content(2, "憤慨的", 2, 2, 1.1f, false));
        Text_contents.Add(new Text_content(3, "慌忙的", 3, 3, 0.6f, true));
        Text_contents.Add(new Text_content(4, "無聊的", 1, 1, 1.05f, true));
        Text_contents.Add(new Text_content(5, "疲憊的", 1, 3, 0.8f, true));

        // 打印Text_contents的内容
        PrintTextContents();
    }

    void PrintTextContents()
    {
        foreach (Text_content content in Text_contents)
        {
            Debug.Log($"Name_number: {content.Name_number}, Name_Text: {content.Name_Text}, Feeling: {content.Feeling}, Attribute_effect_name: {content.Attribute_effect_name}, Attribute_effect_value: {content.Attribute_effect_value}, Text_exist: {content.Text_exist}");
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
    public bool Text_exist;

    public Text_content(int Name_number, string Name_Text, int Feeling, int Attribute_effect_name, float Attribute_effect_value, bool Text_exist)
    {
        this.Name_number = Name_number;
        this.Name_Text = Name_Text;
        this.Feeling = Feeling;
        this.Attribute_effect_name = Attribute_effect_name;
        this.Attribute_effect_value = Attribute_effect_value;
        this.Text_exist = Text_exist;
    }
}
