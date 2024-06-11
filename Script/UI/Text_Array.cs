using System.Collections.Generic;
using UnityEngine;

public class Text_Array : MonoBehaviour
{
    static public List<Text_content> Text_contents = new List<Text_content>();
    static public short[] diary_step;
    static public ushort diary_number = 0;
    void Awake()
    {
        //diary_step
        diary_step = new short[3];
        diary_step[0] = 0;
        diary_step[1] = 0;
        diary_step[2] = 0;

        //diary_text
        Text_contents.Add(new Text_content(11, "《醜小鴨與天鵝湖 》", "none", 0, 0, 0, 0, true));
            Text_contents.Add(new Text_content(1110, "幸福生活", "none", 0, 0, 0, 0, true));
            Text_contents.Add(new Text_content(1120, "救世主", "none", 0, 0, 0, 0, true));
            Text_contents.Add(new Text_content(1130, "反轉", "none", 0, 0, 0, 0, true));
        
        Text_contents.Add(new Text_content(12, "《薔薇的女兒》", "none", 0, 0, 0, 0, true));
            Text_contents.Add(new Text_content(1210, "憤怒", "none", 0, 0, 0, 0, true));
            Text_contents.Add(new Text_content(1220, "驚訝", "none", 0, 0, 0, 0, true));
            Text_contents.Add(new Text_content(1230, "驚悚", "none", 0, 0, 0, 0, true));
            Text_contents.Add(new Text_content(1240, "緊張", "none", 0, 0, 0, 0, true));
        
        Text_contents.Add(new Text_content(13, "《奇異蘋果》", "none", 0, 0, 0, 0, true));
            Text_contents.Add(new Text_content(1310, "反轉", "none", 0, 0, 0, 0, true));
                Text_contents.Add(new Text_content(13110, "浪費", "none", 0, 0, 0, 0, true));
                Text_contents.Add(new Text_content(13120, "糟蹋", "none", 0, 0, 0, 0, true));
            Text_contents.Add(new Text_content(1320, "緊張", "none", 0, 0, 0, 0, true));
                Text_contents.Add(new Text_content(13210, "不適", "none", 0, 0, 0, 0, true));
                Text_contents.Add(new Text_content(13220, "過敏", "none", 0, 0, 0, 0, true));
            Text_contents.Add(new Text_content(1330, "有趣", "none", 0, 0, 0, 0, true));
                Text_contents.Add(new Text_content(13310, "浪費", "none", 0, 0, 0, 0, true));
                Text_contents.Add(new Text_content(13320, "驚訝", "none", 0, 0, 0, 0, true));
    }

    public void SetRandomTextExistToTrue()
    {
        List<Text_content> falseTextContents = new List<Text_content>();

        // 过滤出 Text_exist 为 false 的对象
        foreach (Text_content content in Text_contents)
        {
            if (!content.Text_exist)
            {
                falseTextContents.Add(content);
            }
        }

        // 随机选择一个对象并将其 Text_exist 设置为 true
        if (falseTextContents.Count > 0)
        {
            int randomIndex = Random.Range(0, falseTextContents.Count);
            falseTextContents[randomIndex].Text_exist = true;

            // 打印已修改的对象
            Debug.Log($"Modified Text_content: Name_number: {falseTextContents[randomIndex].Name_number}, Name_Text: {falseTextContents[randomIndex].Name_Text}, Text_exist: {falseTextContents[randomIndex].Text_exist}");
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
