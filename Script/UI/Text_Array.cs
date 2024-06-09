using System.Collections.Generic;
using UnityEngine;

public class Text_Array : MonoBehaviour
{
    static public List<Text_content> Text_contents = new List<Text_content>();

    void Awake()
    {
        // 初始化Text_content
        Text_contents.Add(new Text_content(1100, "《醜小鴨與天鵝湖 》", "none", 0, 0, 0, 0, false));
            Text_contents.Add(new Text_content(1110, "幸福生活", "happy", 0, 0, 0, 0, false));
            Text_contents.Add(new Text_content(1120, "救世主", "happy", 0, 0, 0, 0, false));
            Text_contents.Add(new Text_content(1130, "反轉", "happy", 0, 0, 0, 0, false));
        
        Text_contents.Add(new Text_content(1200, "《薔薇的女兒》", "none", 0, 0, 0, 0, false));
            Text_contents.Add(new Text_content(1210, "憤怒", "happy", 0, 0, 0, 0, false));
            Text_contents.Add(new Text_content(1220, "驚訝", "happy", 0, 0, 0, 0, false));
            Text_contents.Add(new Text_content(1230, "驚悚", "happy", 0, 0, 0, 0, false));
            Text_contents.Add(new Text_content(1240, "緊張", "happy", 0, 0, 0, 0, false));
        
        Text_contents.Add(new Text_content(1300, "《奇異蘋果》", "none", 0, 0, 0, 0, false));
            Text_contents.Add(new Text_content(1310, "反轉", "none", 0, 0, 0, 0, false));
                Text_contents.Add(new Text_content(1311, "浪費", "happy", 0, 0, 0, 0, false));
                Text_contents.Add(new Text_content(1312, "糟蹋", "happy", 0, 0, 0, 0, false));
            Text_contents.Add(new Text_content(1320, "緊張", "none", 0, 0, 0, 0, false));
                Text_contents.Add(new Text_content(1321, "不適", "happy", 0, 0, 0, 0, false));
                Text_contents.Add(new Text_content(1322, "過敏", "happy", 0, 0, 0, 0, false));
            Text_contents.Add(new Text_content(1330, "有趣", "none", 0, 0, 0, 0, false));
                Text_contents.Add(new Text_content(1321, "浪費", "happy", 0, 0, 0, 0, false));
                Text_contents.Add(new Text_content(1332, "驚訝", "happy", 0, 0, 0, 0, false));

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
    public string Feeling; // 0=happy,1=sad,2=angry,3=surprise
    public int HP;
    public float Att_pow;
    public float Att_speed;
    public float Walk_speed;
    public bool Text_exist;

    public Text_content(uint Name_number, string Name_Text, string Feeling, int HP, float Att_pow, float Att_speed, float Walk_speed, bool Text_exist)
    {
        this.Name_number = Name_number;
        this.Name_Text = Name_Text;
        this.Feeling = Feeling;
        this.HP = HP;
        this.Att_pow = Att_pow;
        this.Att_speed = Att_speed;
        this.Walk_speed = Walk_speed;
        this.Text_exist = Text_exist;
    }
}
