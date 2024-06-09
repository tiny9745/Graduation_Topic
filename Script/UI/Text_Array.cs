using System.Collections.Generic;
using UnityEngine;

public class Text_Array : MonoBehaviour
{
    // 全局变量定义
    static public List<Text_content> Text_contents = new List<Text_content>();

    void Awake()
    {
        // 初始化Text_content
        Text_contents.Add(new Text_content(1100, "《醜小鴨與天鵝湖 》", 0, 0, 5, false));
            Text_contents.Add(new Text_content(1110, "幸福生活", 3, 3, 0.6f, false));
            Text_contents.Add(new Text_content(1120, "救世主", 1, 1, 1.05f, false));
            Text_contents.Add(new Text_content(1130, "反轉", 1, 3, 0.8f, false));
        
        Text_contents.Add(new Text_content(1200, "《薔薇的女兒》", 1, 1, 2.2f, false));
            Text_contents.Add(new Text_content(1210, "憤怒", 3, 3, 0.6f, false));
            Text_contents.Add(new Text_content(1220, "驚訝", 1, 1, 1.05f, false));
            Text_contents.Add(new Text_content(1230, "驚悚", 1, 3, 0.8f, false));
            Text_contents.Add(new Text_content(1240, "緊張", 1, 3, 0.8f, false));
        
        Text_contents.Add(new Text_content(1300, "《奇異蘋果》", 2, 2, 1.1f, false));
            Text_contents.Add(new Text_content(1310, "反轉", 3, 3, 0.6f, false));
                Text_contents.Add(new Text_content(1311, "浪費", 3, 3, 0.6f, false));
                Text_contents.Add(new Text_content(1312, "糟蹋", 3, 3, 0.6f, false));
            Text_contents.Add(new Text_content(1320, "緊張", 1, 1, 1.05f, false));
                Text_contents.Add(new Text_content(1321, "不適", 1, 1, 1.05f, false));
                Text_contents.Add(new Text_content(1322, "過敏", 1, 1, 1.05f, false));
            Text_contents.Add(new Text_content(1330, "有趣", 1, 3, 0.8f, false));
                Text_contents.Add(new Text_content(1321, "浪費", 1, 1, 1.05f, false));
                Text_contents.Add(new Text_content(1332, "驚訝", 1, 3, 0.8f, false));

        // 打印Text_contents的内容
        PrintTextContents();
    }

    void PrintTextContents()
    {
        foreach (Text_content content in Text_contents)
        {
           // Debug.Log($"Name_number: {content.Name_number}, Name_Text: {content.Name_Text}, Feeling: {content.Feeling}, Attribute_effect_name: {content.Attribute_effect_name}, Attribute_effect_value: {content.Attribute_effect_value}, Text_exist: {content.Text_exist}");
        }
    }
}

public class Text_content
{
    public string Name_Text;
    public uint Name_number;//The n diary, which sentence, which branch
    public int Feeling; // 0=happy,1=sad,2=angry,3=surprise
    public int Attribute_effect_name; // 0=HP, 1=att_pow, 2=att_speed, 3=walk_speed, 4=defense
    public float Attribute_effect_value;
    public bool Text_exist;

    public Text_content(uint Name_number, string Name_Text, int Feeling, int Attribute_effect_name, float Attribute_effect_value, bool Text_exist)
    {
        this.Name_number = Name_number;
        this.Name_Text = Name_Text;
        this.Feeling = Feeling;
        this.Attribute_effect_name = Attribute_effect_name;
        this.Attribute_effect_value = Attribute_effect_value;
        this.Text_exist = Text_exist;
    }
}
