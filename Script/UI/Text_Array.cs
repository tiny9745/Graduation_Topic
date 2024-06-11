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
        Text_contents.Add(new Text_content(11, "《醜小鴨與天鵝湖 》", "none", 0, 0, 0, 0, true, "我感覺自己就像主角醜小鴨，但爸媽卻希望我像天鵝一樣功成名就。\r\n明明在水底下，醜小鴨與天鵝都在努力用腳打水，好讓自己保持優雅。可是他們只看得見我表面上醜陋不堪，沒人會知道我有多麼努力才能活著。\r\n我的結局也能如醜小鴨一樣來個"));
            Text_contents.Add(new Text_content(1110, "幸福生活", "none", 0, 0, 0, 0, true, "嗎？即使醜小鴨經歷了那麼多苦難，忍受天鵝們的嘲諷，最後仍是活出精彩人生。說真的，我有辦法跟他一樣嗎？（怎麼可能）"));
            Text_contents.Add(new Text_content(1120, "救世主", "none", 0, 0, 0, 0, true, "拯救嗎？會不會有哪個人願意拉我一把，讓我逃離爸媽的掌控？還是說，只有我能拯救我自己呢？但我目前還沒有足夠的勇氣……"));
            Text_contents.Add(new Text_content(1130, "反轉", "none", 0, 0, 0, 0, true, "嗎？我也能脫離掌控，找回我自己的主控權嗎？……可惜書只是書，好結局哪有那麼好得到。"));
        
        Text_contents.Add(new Text_content(12, "《薔薇的女兒》", "none", 0, 0, 0, 0, true, "最近有些書荒，剛好圖書館進了些新書就隨意借一本來看。書本內容看了實在是很讓人感到"));
            Text_contents.Add(new Text_content(1210, "憤怒", "none", 0, 0, 0, 0, true, "！\r\n女主角被父母控制所有生活的一切大小事，完全無視她的感受、限制人身自由，這不就跟我爸媽一樣嘛！甚至父母還要強迫女主角當祭品，根本就沒有問過女主角的意願！\r\n難道全天下的父母都認為「因為你是我生養的，所以你的就是我的」嗎？\r\n雖然有些地方所描述的代入感太強，看了很氣憤。（尤其是女主角父母出現的時候！）不過我還是會讀完它。"));
            Text_contents.Add(new Text_content(1220, "驚訝", "none", 0, 0, 0, 0, true, "！\r\n我原本以為這只是普通的家庭生活故事，沒想到突然來個大轉折，出現了黑魔法元素，還有什麼恐怖的黑玫瑰儀式！？\r\n但這本書卻是分類在「親子關係」？這明明就是「懸疑、奇幻」小說吧？是出版社搞錯了嗎？\r\n不過無所謂，這反而引起了我的興趣。我會繼續讀完它，只要我明天能夠早一點完成作業的話……"));
            Text_contents.Add(new Text_content(1230, "驚悚", "none", 0, 0, 0, 0, true, "！\r\n女主角發現了父母長年扶養她的陰謀，只為了要讓她成為黑玫瑰儀式的祭品，這個儀式是家族留下來的傳統，據說能賦予參與者永恆生命，只是每次都必須犧牲一名女兒。（他們還真的相信嗎？）\r\n她從地下室逃離時的恐懼從書裡傳染給我，彷彿我就是逃跑的女孩。逃到一半還是被抓了回去，真是太絕望了……我停止不下來繼續閱讀的欲望。\r\n我想我明天上課會變得很不專心，會一直在想接下來女主角怎麼辦。"));
            Text_contents.Add(new Text_content(1240, "緊張", "none", 0, 0, 0, 0, true, "！\r\n看著女主角從父母洗腦中脫離，要在他們眼皮下慢慢找尋真相，最終發現他們只是把她當成祭品撫養，她會死於一場詭異的儀式中，真的太嚇人了！\r\n幸好最後女主成功逃離那些想傷害她的人，這過程實在是太緊張刺激了！許久沒看到這麼精彩的故事，我的心情也忍不住激動起來了。\r\n不曉得會不會有續集呢？其中一些伏筆還沒解開讓人覺得有些在意呢……"));
        
        Text_contents.Add(new Text_content(13, "《奇異蘋果》", "none", 0, 0, 0, 0, true, "這個故事絲毫沒有"));
            Text_contents.Add(new Text_content(1310, "反轉", "none", 0, 0, 0, 0, true, "的部分，從頭到尾只是在講一個老頭以為自己得到有魔力的蘋果並沾沾自喜，還傻傻的放到爛掉而不吃！簡直是"));
                Text_contents.Add(new Text_content(13110, "浪費", "none", 0, 0, 0, 0, true, "買蘋果的錢又浪費食物。只是聽到別人說這是有魔力的蘋果就笨到相信，連個事實都懶得求證。\r\n可笑的是，這世界還真有許多人是如此。"));
                Text_contents.Add(new Text_content(13120, "糟蹋", "none", 0, 0, 0, 0, true, "食物！種子長成果樹再結出蘋果，需要花費多少時間，就這麼任由好吃的蘋果爛掉，我覺得實在太可惜了。\r\n要是我一定會特別好奇有魔力的蘋果是不是更美味而忍不住吃掉。:P"));
            Text_contents.Add(new Text_content(1320, "緊張", "none", 0, 0, 0, 0, true, "感。我原本以為老頭吃了蘋果後肚子痛，是因為觸犯了什麼魔法禁忌？結果根本不是，只是他身體"));
                Text_contents.Add(new Text_content(13210, "不適", "none", 0, 0, 0, 0, true, "，又剛好吃到不新鮮的蘋果。\r\n這商人只是想把爛蘋果賣掉而哄騙老頭說這是「能實現願望的奇異蘋果」，真是騙人太糟糕了，商人應該要有誠信。"));
                Text_contents.Add(new Text_content(13220, "過敏", "none", 0, 0, 0, 0, true, "。\r\n這輩子第一次吃到蘋果，也是最後一次吃到蘋果！我不禁為這個老頭感到可憐……蘋果是多麼好吃的水果，拿來製作成派、麵包或是沙拉，都是多麼好吃的選擇。\r\n突然好想吃啊……"));
            Text_contents.Add(new Text_content(1330, "有趣", "none", 0, 0, 0, 0, true, "的地方。這個故事敘事平淡無奇，也沒有任何重點。我覺得非常"));
                Text_contents.Add(new Text_content(13310, "浪費", "none", 0, 0, 0, 0, true, "寶貴時間，只不過是封面上畫了顆漂亮又美味的蘋果，我就因此被吸引而借來閱讀，真是太讓人後悔了……\r\n果然事情都不能只看表面。"));
                Text_contents.Add(new Text_content(13320, "驚訝", "none", 0, 0, 0, 0, true, "，因為這本書還有幾位名人大力推薦。他們真的有親自閱讀過嗎？還是說只是收錢辦事？這怎麼想也不會是值得看的書，看了等於沒看。"));
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
    public string Text_text;

    public Text_content(uint Name_number, string Name_Text, string Feeling, int HP, float Att_pow, float Att_speed, float Walk_speed, bool Text_exist, string text_text)
    {
        this.Name_number = Name_number;
        this.Name_Text = Name_Text;
        this.Feeling = Feeling;
        this.HP = HP;
        this.Att_pow = Att_pow;
        this.Att_speed = Att_speed;
        this.Walk_speed = Walk_speed;
        this.Text_exist = Text_exist;
        this.Text_text = text_text;
    }
}
