using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Text_Array : MonoBehaviour
{
    static public List<Text_content> Text_contents = new List<Text_content>();
    short pickdiary = 1;
    static public bool Add_array = true;
    public GameObject diarypointer, Rightpage, Dspace;
    public Auto_text_paper auto_Text_Paper; public Ch3 ch3; public Drag_End drag_End;
    public short[] pick_tmp;
    void Awake()
    {
        if (Add_array)
        {
            //diary_step
            pick_tmp = new short[4];
            for (int i = 0; i < 4; i++)
            {
                pick_tmp[i] = 0;
            }

            //diary_novel01
            Text_contents.Add(new Text_content(11, "《醜小鴨與天鵝湖》", "None", 25, 5, 0, 0, true, "我今天讀了一本書，《醜小鴨與天鵝湖》。我感覺自己就像主角醜小鴨，但爸媽卻希望我像天鵝一樣功成名就。\r\n明明在水底下，醜小鴨與天鵝都在努力用腳打水，好讓自己保持優雅。可是他們只看得見我表面上醜陋不堪，沒人會知道我有多麼努力才能活著。\r\n我的結局也能如醜小鴨一樣來個"));
            Text_contents.Add(new Text_content(111, "幸福", "Sad", 50, 0, 0, 0, true, "幸福嗎？即使醜小鴨經歷了那麼多苦難，忍受天鵝們的嘲諷，最後仍是活出精彩人生。說真的，我有辦法跟他一樣嗎？（怎麼可能）"));
            Text_contents.Add(new Text_content(112, "救世主", "Sad", 25, 5, 0, 0, true, "救世主拯救嗎？會不會有哪個人願意拉我一把，讓我逃離爸媽的掌控？還是說，只有我能拯救我自己呢？但我目前還沒有足夠的勇氣……"));
            Text_contents.Add(new Text_content(113, "反轉", "Sad", 0, 0, 0, 0, true, "反轉嗎？我也能脫離掌控，找回我自己的主控權嗎？……可惜書只是書，好結局哪有那麼好得到。"));

            Text_contents.Add(new Text_content(12, "《薔薇的女兒》", "None", 0, 0, .05f, 1, true, "我今天讀了一本書，《薔薇的女兒》。最近有些書荒，剛好圖書館進了些新書就隨意借一本來看。書本內容看了實在是很讓人感到"));
            Text_contents.Add(new Text_content(121, "憤怒", "Angry", 0, 10, 0, 0, true, "憤怒！\r\n女主角被父母控制所有生活的一切大小事，完全無視她的感受、限制人身自由，這不就跟我爸媽一樣嘛！甚至父母還要強迫女主角當祭品，根本就沒有問過女主角的意願！\r\n難道全天下的父母都認為「因為你是我生養的，所以你的就是我的」嗎？\r\n雖然有些地方所描述的代入感太強，看了很氣憤。（尤其是女主角父母出現的時候！）不過我還是會讀完它。"));
            Text_contents.Add(new Text_content(122, "驚訝", "Wow", 0, 10, 0, 0, true, "驚訝！\r\n我原本以為這只是普通的家庭生活故事，沒想到突然來個大轉折，出現了黑魔法元素，還有什麼恐怖的黑玫瑰儀式！？\r\n但這本書卻是分類在「親子關係」？這明明就是「懸疑、奇幻」小說吧？是出版社搞錯了嗎？\r\n不過無所謂，這反而引起了我的興趣。我會繼續讀完它，只要我明天能夠早一點完成作業的話……"));
            Text_contents.Add(new Text_content(123, "驚悚", "Wow", 25, 0, .05f, 0, true, "驚悚！\r\n女主角發現了父母長年扶養她的陰謀，只為了要讓她成為黑玫瑰儀式的祭品，這個儀式是家族留下來的傳統，據說能賦予參與者永恆生命，只是每次都必須犧牲一名女兒。（他們還真的相信嗎？）\r\n她從地下室逃離時的恐懼從書裡傳染給我，彷彿我就是逃跑的女孩。逃到一半還是被抓了回去，真是太絕望了……我停止不下來繼續閱讀的欲望。\r\n我想我明天上課會變得很不專心，會一直在想接下來女主角怎麼辦。"));
            Text_contents.Add(new Text_content(124, "緊張", "Happy", 0, 0, 0, 2, true, "緊張！\r\n看著女主角從父母洗腦中脫離，要在他們眼皮下慢慢找尋真相，最終發現他們只是把她當成祭品撫養，她會死於一場詭異的儀式中，真的太嚇人了！\r\n幸好最後女主成功逃離那些想傷害她的人，這過程實在是太緊張刺激了！許久沒看到這麼精彩的故事，我的心情也忍不住激動起來了。\r\n不曉得會不會有續集呢？其中一些伏筆還沒解開讓人覺得有些在意呢……"));

            Text_contents.Add(new Text_content(13, "《奇異蘋果》", "None", 0, 10, 0, 0, true, "我今天讀了一本書，《奇異蘋果》。這個故事絲毫沒有"));
            Text_contents.Add(new Text_content(131, "反轉", "None", 0, 0, 0, 2, true, "反轉的部分，從頭到尾只是在講一個老頭以為自己得到有魔力的蘋果並沾沾自喜，還傻傻的放到爛掉而不吃！簡直是"));
            Text_contents.Add(new Text_content(1311, "浪費", "Angry", 0, 10, 0, 0, false, "浪費買蘋果的錢又浪費食物。只是聽到別人說這是有魔力的蘋果就笨到相信，連個事實都懶得求證。\r\n可笑的是，這世界還真有許多人是如此。"));
            Text_contents.Add(new Text_content(1312, "糟蹋", "Wow", 0, 0, .1f, 0, true, "糟蹋食物！種子長成果樹再結出蘋果，需要花費多少時間，就這麼任由好吃的蘋果爛掉，我覺得實在太可惜了。\r\n要是我一定會特別好奇有魔力的蘋果是不是更美味而忍不住吃掉。:P"));
            Text_contents.Add(new Text_content(132, "緊張", "None", 0, 0, 0, 2, false, "緊張感。我原本以為老頭吃了蘋果後肚子痛，是因為觸犯了什麼魔法禁忌？結果根本不是，只是他身體"));
            Text_contents.Add(new Text_content(1321, "不適", "Sad", 0, 0, .1f, 0, false, "不適，又剛好吃到不新鮮的蘋果。\r\n這商人只是想把爛蘋果賣掉而哄騙老頭說這是「能實現願望的奇異蘋果」，真是騙人太糟糕了，商人應該要有誠信。"));
            Text_contents.Add(new Text_content(1322, "過敏", "Wow", 0, 0, 0, 2, false, "。過敏\r\n這輩子第一次吃到蘋果，也是最後一次吃到蘋果！我不禁為這個老頭感到可憐……蘋果是多麼好吃的水果，拿來製作成派、麵包或是沙拉，都是多麼好吃的選擇。\r\n突然好想吃啊……"));
            Text_contents.Add(new Text_content(133, "有趣", "None", 50, 0, 0, 0, false, "有趣的地方。這個故事敘事平淡無奇，也沒有任何重點。我覺得非常"));
            Text_contents.Add(new Text_content(1331, "浪費", "Sad", 0, 10, 0, 0, false, "浪費寶貴時間，只不過是封面上畫了顆漂亮又美味的蘋果，我就因此被吸引而借來閱讀，真是太讓人後悔了……\r\n果然事情都不能只看表面。"));
            Text_contents.Add(new Text_content(1332, "驚訝", "Angry", 50, 0, 0, 0, false, "驚訝，因為這本書還有幾位名人大力推荐。他們真的有親自閱讀過嗎？還是說只是收錢辦事？這怎麼想也不會是值得看的書，看了等於沒看。"));

            //diary_novel02
            Text_contents.Add(new Text_content(21, "小心翼翼", "None", 25, 5, 0, 0, true, "今夜天氣不佳，窗外狂風暴雨，閃電雷聲不斷，而我小心翼翼的靠近透明窗邊，看著雨滴打在玻璃上，一顆顆的水珠緩慢匯流成一條小河。\r\n看起來好"));
            Text_contents.Add(new Text_content(211, "療癒", "None", 50, 0, 0, 0, true, "療癒哦！可以猜猜哪顆雨珠跑得最快，不過我今晚不想把時間耗費在這。\r\n我借了新的小說回來，打算在今晚閱讀。\r\n雖然爸媽說晚上是要我自己讀書複習或預習的時間，不過……那些在補習班都聽過了，我想稍微休息一下也沒關係吧？\r\n搭配著下雨聲閱讀小說，真的太"));
            Text_contents.Add(new Text_content(2111, "愜意", "Happy", 50, 0, 0, 0, true, "愜意了。天然的白噪音就是令人心曠神怡啊，不需要戴著耳機也能聽見從四面八方的雨聲，彷彿整個人被雨水包圍起來，實際上則是待在溫暖的室內裡。"));
            Text_contents.Add(new Text_content(2112, "放鬆", "Happy", 50, 0, 0, 0, false, "放鬆了，尤其整個人縮在暖暖的被窩裡，阻隔了外面的滂沱大雨，反而讓人感到安心。\r\n與其說家庭是溫暖的避風港，不如說我的床上才是！"));
            Text_contents.Add(new Text_content(212, "浪漫", "None", 25, 5, 0, 0, false, "浪漫了！有些戀愛小說裡不都會出現這樣的場景嗎？男女主角因為誤會而分開，其中一方就會傷心的在豪雨中奔跑。大哭時分不清楚雨水和淚水，也反映出受傷的心靈。\r\n這種劇情是有些"));
            Text_contents.Add(new Text_content(2121, "通俗", "None", 50, 0, 0, 0, false, "通俗了，看太多反而會疲乏，還會遭人嫌。只是小說字多，我認為寫這種老掉牙的劇情大概也沒人會想認真看，而現在看書的人越來越少了，大家都在追求速食娛樂。"));
            Text_contents.Add(new Text_content(2122, "常見", "None", 50, 0, 0, 0, false, "常見了，不過既然常見，就代表大家其實挺喜歡的吧？\r\n不過這種劇情要寫得好看與感人還是需要點技巧，不然俗套的東西反覆再出現，都會看得疲倦。"));

            Text_contents.Add(new Text_content(22, "詢問", "None", 25, 5, 0, 0, false, "今夜天氣不佳，窗外狂風暴雨，閃電雷聲不斷，而我詢問爸媽能不能讓我回去房間，但他們似乎沒罵夠我。因為我今天去補習班時遲到了十五分鐘，老師就打給媽媽說，結果她知道了非常生氣。\r\n我不想說是因為我跑去逛書店而錯過公車，來不及趕上補習班的時間。\r\n但我也不想說謊，所以爸媽逼問不出來時，就"));
            Text_contents.Add(new Text_content(221, "憤怒", "Angry", 50, 0, 0, 0, false, "憤怒得對我破口大罵。外面的雷雨聲剛好蓋過他們的怒罵聲，所以我有些放空的看著他們扭曲的臉龐。\r\n他們唸了半小時，才肯放我走。我本來打算在今夜閱讀新借的小說，現在心情卻無了。"));
            Text_contents.Add(new Text_content(222, "面面相覷", "Sad", 50, 0, 0, 0, false, "面面相覷了一會兒，最後媽媽嘆了一口氣的，爸爸看起來也很疲憊。他們要我下次別遲到了，補習班費錢、希望我好好學習之類的叮嚀。\r\n我回到房間裡聽著雨聲滴答滴答，我想這剛好反映了我們家的情況。"));

            Text_contents.Add(new Text_content(23, "疲倦", "None", 50, 0, 0, 0, false, "今夜天氣不佳，窗外狂風暴雨，閃電雷聲不斷，而我疲倦不堪，但就算很累，我也想趕快利用空閒時間翻閱今天新借來的小說。\r\n但我今天有點"));
            Text_contents.Add(new Text_content(231, "過敏", "Wow", 25, 5, 0, 0, false, "過敏，因為天氣驟然變涼，所以一直在流鼻水。桌子上很快就堆滿衛生紙水餃，害我沒辦法專心看書，一直在擤鼻涕，鼻子都快揉成小丑的紅鼻子了。\r\n……嗯，這算不算跟這本《小丑夢魘》的小丑不謀而合了呢？\U0001f921"));
            Text_contents.Add(new Text_content(232, "不適", "Wow", 50, 0, 0, 0, false, "不適，早上體育課還掛著大太陽，跑了八百公尺讓我身體覺得很不舒服。晚上卻馬上下起大雨，瞬間的濕冷讓我更疲憊了。\r\n但是我真的好想看小說，所以還是稍微看了半小時。最後身體真的承受不了，才倒頭大睡。"));

            //diary_music01
            Text_contents.Add(new Text_content(31, "哭泣", "None", 25, 5, 0, 0, false, "我學鋼琴也快十年了，如果我有辦法活到一百歲，那麼我現在就有十分之一的時間都奉獻給了鋼琴。但老實說，我一點也不喜歡彈鋼琴。/r/n有時候我會想起以前才七歲時第一次見到那名新來的鋼琴老師，我的反應是哭泣，那時只要看到不認識的人，我就會大爆哭，我想不起來是什麼原因導致我那麼排斥陌生人。\r\n可是我記得媽媽那時候的臉極其冷酷，她絲毫不在意我是不是被陌生人嚇著了，就讓我和那名鋼琴老師相處一室。\r\n鋼琴老師蹲下身，介紹她自己叫做「何乃」，我喊她何乃老師。\r\n她人很"));
            Text_contents.Add(new Text_content(311, "和藹", "Sad", 50, 0, 0, 0, false, "和藹，我還記得她那時候非常溫柔的安撫我，說我們今天先來認識彼此就好。\r\n雖然停止了哭聲，但我的眼淚還是掉不停。何乃老師從包裡掏出一顆太妃糖，塞到了我的掌心裡，她說難過時吃一點甜甜的，心情就會變好。\r\n我不相信陌生人給的東西，但她感覺不像壞人，所以我就相信她了。但正是因為我太相信她，才會有一天跟她說出我的內心話，說我真的很討厭鋼琴、也不想學鋼琴，才會導致她被媽媽開除……;(\r\n後來媽媽換了一個很兇的鋼琴老師，那幾年簡直是我的夢魘。"));

            Text_contents.Add(new Text_content(32, "彆扭", "None", 25, 5, 0, 0, false, "我學鋼琴也快十年了，如果我有辦法活到一百歲，那麼我現在就有十分之一的時間都奉獻給了鋼琴。但老實說，我一點也不喜歡彈鋼琴。/r/n有時候我會想起以前才七歲時第一次見到那名新來的鋼琴老師，我的反應是彆扭的不知道如何反應，突然看到一個陌生人，當然會覺得恐懼，當然現在不會了……除了與陌生人說話，這得另當別論。\r\n媽媽要我好好學琴，叮囑我要乖巧的聽老師的話。媽媽離開房間後，我好像才後知後覺的哭了。\r\n但何乃老師是個"));
            Text_contents.Add(new Text_content(321, "有趣", "Angry", 50, 0, 0, 0, false, "有趣的人，她那時在我後腦勺附近的空氣撈啊撈，竟然撈出了一支彩色的心型棒棒糖。\r\n我看呆了，一時半刻就停止眼淚。她說我們能邊吃糖、邊認識彼此。但幾乎都是她在說話，我只負責點頭、搖頭和吃糖。\r\n不知道她現在過得怎麼樣了？我記得當初我不管彈得多差，她都會耐心的教導、糾正我，從來沒有厭煩的樣子，我一直很喜歡她，可惜她只教了我兩年。\r\n後來媽媽換了一個兇巴巴的鋼琴老師，她比練習鋼琴還要讓我更討厭。"));

            Text_contents.Add(new Text_content(33, "困惑", "None", 50, 0, 0, 0, false, "我學鋼琴也快十年了，如果我有辦法活到一百歲，那麼我現在就有十分之一的時間都奉獻給了鋼琴。但老實說，我一點也不喜歡彈鋼琴。/r/n有時候我會想起以前才七歲時第一次見到那名新來的鋼琴老師，我的反應是困惑不解，不曉得這個陌生人是誰。媽媽說這是我以後的鋼琴老師，以後得跟著她學鋼琴，一個禮拜兩次，一次三個小時。\r\n我記得與她學鋼琴快兩年時，何乃老師跟媽媽大吵一架。因為我跟她說我討厭鋼琴，但卻不敢和媽媽講明白。\r\n於是她替"));
            Text_contents.Add(new Text_content(331, "我", "Sad", 25, 5, 0, 0, false, "我向媽媽說，說別逼孩子不喜歡的事情、她已經到了足夠認知到自己喜惡的年紀，之類的……（當時我偷偷貼在房門上偷聽她們在客廳講話），結果她們竟然講到吵起來，媽媽一氣之下就要何乃老師捲鋪蓋。\r\n我感到很愧疚，是我害何乃老師被炒魷魚，要是我沒跟她說我討厭鋼琴就好了，那樣子她就不會被媽媽開除，也不會換下一個討人厭的鋼琴老師了。\r\n我很想念溫柔的何乃老師，不曉得她現在過得怎麼樣？"));

            //diary_plant01
            Text_contents.Add(new Text_content(41, "黃金葛", "None", 25, 5, 0, 0, false, "今天去上圖書志工社團課，發現圖書館的窗台旁多了好幾盆植物。圖書阿姨說那是別人捐贈的黃金葛，她還交付了我一個任務，要我之後就負責照顧這些盆栽。\r\n可能看到我為難的表情，阿姨就笑著說這些植物很好養，只要偶爾澆水就好。我"));
            Text_contents.Add(new Text_content(411, "點頭", "None", 50, 0, 0, 0, false, "點頭，阿姨好像很開心，還說今天就讓我負責澆水就好，澆完水就可以自由活動了。只要澆水就好嗎？突然減少的工作任務讓我有點"));

            Text_contents.Add(new Text_content(4111, "開心", "None", 50, 0, 0, 0, false, "開心，因為多了很多時間可以去看書了！\r\n我把澆水壺裝滿水，小心翼翼澆在植物上。我從來沒有照顧過植物，這很"));
            Text_contents.Add(new Text_content(41111, "彆扭", "Happy", 50, 0, 0, 0, false, "彆扭，不過我一次只澆一點點水，慢慢加就不會有過滿的問題，所以看起來還行！\r\n希望這株小黃金葛可以活得很健康！"));
            Text_contents.Add(new Text_content(41112, "奇怪", "Happy", 50, 0, 0, 0, false, "奇怪吧？我想爸媽不會讓我嘗試園藝，我也沒看過我們家有任何植物出現。\r\n所以，我很期待這株小黃金葛可以長得更加茁壯。"));

            Text_contents.Add(new Text_content(4112, "挫折", "None", 25, 5, 0, 0, false, "挫折，是不是阿姨覺得我連普通的打掃工作都做得不好，才要我做這種易如反掌的事情呢……\r\n總之，這盆黃金葛看起來有點"));
            Text_contents.Add(new Text_content(41121, "玩具", "Wow", 50, 0, 0, 0, false, "玩具塑膠感，我摸了摸心型葉片，光光滑滑的觸覺好特別。\r\n\r\n後來我稍微查了一下資料，發現黃金葛的生命力其實很堅韌，真是意想不到。"));
            Text_contents.Add(new Text_content(41122, "愜意", "Happy", 50, 0, 0, 0, false, "愜意，只需要慵懶生長、生活也是自由自在，根本沒有任何煩惱，真好。"));

            Text_contents.Add(new Text_content(412, "搖頭", "None", 50, 0, 0, 0, false, "搖頭，因為我覺得我做不來這種事情，但是阿姨說這是我在圖書志工社的任務，要交付給我完成。那……好吧，我還是拿了澆水壺來澆水，我動作是有一點"));
            Text_contents.Add(new Text_content(4121, "僵硬", "Sad", 50, 0, 0, 0, false, "僵硬，所以水不小心澆得有點多，噢不！小黃金葛，我很抱歉……我下次會注意一點，請你別介意。"));
            Text_contents.Add(new Text_content(4122, "煩躁", "Angry", 50, 0, 0, 0, false, "煩躁，很氣自己連小事都做不好，我一個不注意不小心就澆太多，結果水從底部盤子滲出……阿姨說下次要澆少一點水，害我更愧疚了。\r\n唉……心情好差。"));

            Text_contents.Add(new Text_content(42, "仙人掌", "None", 25, 5, 0, 0, false, "今天去上圖書志工社團課，發現圖書館的窗台旁多了好幾盆植物。圖書阿姨說那是別人捐贈的仙人掌，有大有小，有不同的形狀跟顏色，看著就覺得可愛，雖然全身帶滿了刺，我不太敢靠近。阿姨要我之後負責照顧這些盆栽，我愣愣就"));
            Text_contents.Add(new Text_content(421, "點頭", "None", 50, 0, 0, 0, false, "點頭了，但是我完全沒有園藝經驗呀！？這該怎麼辦……要去跟阿姨說明嗎？可是她會不會很"));
            Text_contents.Add(new Text_content(4211, "失望", "Sad", 50, 0, 0, 0, false, "失望？她一定是覺得我有辦法勝任，才會將這個任務交付給我。如果我做得不好，她會不會就變一個態度，不給我好臉色看……\r\n不行，我得去查查怎麼照顧仙人掌，不能讓這些可愛的植物栽在我手裡，我也不想讓阿姨討厭。"));
            Text_contents.Add(new Text_content(4212, "憤怒", "Sad", 50, 0, 0, 0, false, "憤怒？要是我說我辦不到，她會不會怪我為什麼連照顧植物都不會？我不想讓人失望……我後來去查了關於照顧仙人掌的書籍，溫度、水分、土壤似乎都是照顧的要點……有點複雜，但我會努力嘗試。"));

            Text_contents.Add(new Text_content(421, "搖頭", "None", 50, 0, 0, 0, false, "搖頭，阿姨說這不會太難，只要看仙人掌土壤乾了再澆水就好，平時就跟它們講講話就好。\r\n我不曉得這是什麼意思，難道仙人掌也需要社交嗎？我找了一本的書和椅子坐在了窗台旁，和這些仙人掌"));
            Text_contents.Add(new Text_content(4221, "面面相覷", "Happy", 50, 0, 0, 0, false, "面面相覷。我向這些仙人掌打個招呼，跟它們說今天天氣很好。\r\n斜斜照射進來的太陽灑落在仙人掌上，發出淺金色的光輝。"));
            Text_contents.Add(new Text_content(4222, "僵硬", "Wow", 50, 0, 0, 0, false, "僵硬的相對無言，當然啦、仙人掌本來就不會講話了。我還在猶豫要不要跟它們說話，最後卻只是默默翻起了介紹仙人掌的書。\r\n……原來仙人掌會開花啊！"));

            Text_contents.Add(new Text_content(42, "粗肋草", "None", 25, 5, 0, 0, false, "今天去上圖書志工社團課，發現圖書館的窗台旁多了好幾盆植物。圖書阿姨說那是別人捐贈的粗肋草，葉片呈現橢圓形，翠綠上帶著淺色斑點，看起來很像脫漆的牆壁。\r\n阿姨說之後讓我負責照顧這些盆栽，我沒有回應，只是"));
            Text_contents.Add(new Text_content(421, "點頭", "None", 50, 0, 0, 0, false, "點頭。阿姨似乎很開心，把澆水壺交給了我，說每週澆水一次就好，之後也要拜託我了。\r\n於是我便裝了一壺水，"));
            Text_contents.Add(new Text_content(4211, "小心翼翼", "Happy", 50, 0, 0, 0, false, "小心翼翼地傾斜壺口，一點一滴將水注入微乾的土壤裡，直到看見土壤變成深色為止。\r\n搞不懂，我不曉得這麼做是否正確。我找了介紹粗肋草的書，上面寫說粗肋草耐得住陰涼也容易照顧，俗稱「萬年青」。真有趣，小小一株植物的生命力竟然能夠如此旺盛！\r\n對了，後來阿姨有來看這些盆栽的狀況，還誇獎我做得很好。:)"));
            Text_contents.Add(new Text_content(4212, "戰戰兢兢", "Sad", 50, 0, 0, 0, false, "戰戰兢兢的想要澆水，但因為緊張手實在太抖了，不小心將水灑到了地板上……！\r\n太糟糕了，我慌忙的去拿拖把來拖乾地板，最後乾脆將整個圖書館的地板都拖了一次，雖然花了一點時間在額外的事情上，但我最後還是有澆完水。"));

            Text_contents.Add(new Text_content(421, "搖頭", "None", 50, 0, 0, 0, false, "搖頭，但阿姨似乎鐵定要將任務交付給我，她說這不會很難，只要澆水就好。\r\n因為她都這麼說了，我也只好去拿澆水壺裝水。\r\n當我緩慢的澆灌，看著淺色土壤漸漸變深，感到"));
            Text_contents.Add(new Text_content(4221, "放鬆", "Wow", 50, 0, 0, 0, false, "放鬆了下來，我想這麼做應該是正確的吧？\r\n人不喝水會死，而植物當然也得喝水，只是這株小粗肋草就算好幾天不喝水也撐得下去——這是我在書上看來的，真是神奇。"));
            Text_contents.Add(new Text_content(4222, "有趣", "Happy", 50, 0, 0, 0, false, "有趣而新奇，照顧植物是我沒接觸過的事情，有一種開啟新世界的感覺。\r\n雖然平常在路上會遇到很多花草樹木，但我好像都沒有駐足觀賞的經驗，只是習慣了視若無睹，但仔細想想，其實大自然很奇妙呢。下一次也許可以好好觀察路邊的植物。"));

            //diary_play01
            Text_contents.Add(new Text_content(51, "玩具", "None", 25, 5, 0, 0, false, "放學回家時，在路上看到一家新開的玩具店，離公車來還有一段時間，所以我就進去晃晃了。店裡沒有很大，不過似乎還有二樓能上去，空氣中彌漫著新裝潢的氣味。\r\n老闆坐在櫃檯和一名客人講話，幸好，要是店裡一個客人都沒有，那一定很"));
            Text_contents.Add(new Text_content(511, "彆扭", "None", 50, 0, 0, 0, false, "彆扭！老闆會特別注意到有客人進了店裡，我會沒辦法好好逛，而且我很怕有些熱情的人會馬上衝過來問「有哪裡需要幫忙嗎」，我真的會腦袋空白。\r\n總之晃了一下，我還在二樓發現「超長身動物系列」竟然新出了鴨鴨先生！！又白又胖又長的鴨子布偶，真的超可愛！老實說好想要啊！但要是買這麼大的布偶回家去，因為太顯眼絕對會被丟掉……而且爸媽一定會說這東西沒有用處。\r\n可是沒關係，只是看看也開心。"));
            Text_contents.Add(new Text_content(512, "可怕", "Happy", 50, 0, 0, 0, false, "可怕。當然人多時也可怕，不過在有一點人、又不會太多人的地方，比較好能夠默默混進去而不被注目。\r\n我逛了一圈，就是一些桌遊、模型類的玩具。這些我都沒有，一方面是爸媽不可能讓我買這些東西、另一方面是我也沒有朋友能一起玩。\r\n二樓似乎是娃娃區，有一堆絨毛布偶擺在展示架上。真的好可愛呀！不過我不敢拿起來摸，怕弄髒了要賠錢。我還看見「超長身動物系列」新推出了鴨鴨小姐，這系列的布偶動物身子都會拉的好長好長，好像麻糬一樣，真的好想帶一隻回家！"));

            Text_contents.Add(new Text_content(52, "扭蛋", "None", 25, 5, 0, 0, false, "放學回家時，在路上看到一家新開的扭蛋店，公車還要再等一下子，於是我想說就進去看看。店裡擺放了數多排列整齊的機台，轉蛋種類琳瑯滿目，我看到有些眼花撩亂。\r\n雖然爸媽管得很嚴格，不過從來不會進來我的房間。而且轉蛋小小的，比較好偷偷帶回房間裡裝飾。\r\n啊，我還在角落看到了"));
            Text_contents.Add(new Text_content(521, "《醜小鴨與天鵝湖》", "None", 50, 0, 0, 0, false, "《醜小鴨與天鵝湖》轉蛋！？我沒想到這竟然出了轉蛋耶，有主角醜小鴨三種款式，還有三款不同顏色的天鵝配角。\r\n我想說就扭看看吧，結果好"));
            Text_contents.Add(new Text_content(5211, "厲害", "Happy", 50, 0, 0, 0, false, "厲害！！我好像扭到了隱藏版醜小鴨！？是在結局後得到改變——充滿自信的醜小鴨，沒想到運氣會降臨在這種地方！擺在書桌上，看起來閃閃發光～:D"));
            Text_contents.Add(new Text_content(5212, "糟蹋", "Sad", 50, 0, 0, 0, false, "糟蹋我的錢！！！扭到了翠綠天鵝姐姐啊……可惡，我裡面最討厭的就是這個角色！至少讓我扭到淺粉天鵝妹妹啊，比起來她還算是不討人厭！\r\n\r\n雖然我最想要的還是醜小鴨……"));

            Text_contents.Add(new Text_content(522, "《薔薇的女兒》", "None", 50, 0, 0, 0, false, "《薔薇的女兒》轉蛋！？明明類似恐怖小說，但轉蛋卻將主要角色做成Q版坐姿模型，每個人眼睛都圓滾滾，看起來十分可愛。\r\n要是有人因為轉蛋可愛而去看了原版小說，一定會覺得很"));
            Text_contents.Add(new Text_content(5211, "驚訝", "Happy", 50, 0, 0, 0, false, "驚訝，因為故事內容實在是太嚇人了，跟轉蛋可愛形象不成正比。不過要是因此而入坑，我覺得也不錯！我很期待續集，聽說明年就會出版了。\r\n不過我最後並沒有轉，因為我錢帶不夠。"));
            Text_contents.Add(new Text_content(5212, "奇怪", "Wow", 50, 0, 0, 0, false, "奇怪，懷疑自己是不是看錯書籍了，尤其是它分類也怪怪的。\r\n雖然角色都很可愛，不過我今天不想花錢玩轉蛋，後來看一看也沒什麼特別想轉的就離開了。"));

            Text_contents.Add(new Text_content(523, "《奇異蘋果》", "Angry", 50, 0, 0, 0, false, "《奇異蘋果》轉蛋！？這IP到底有多強大？這麼平淡無趣的故事還能出轉蛋？我想它強就是強在美術吧，六種不同蘋果的造型確實很漂亮，連主角老翁都沒有出現，我想廠商也知道根本沒有人想要老翁吧？要是我花錢轉了，彷彿變相支持這種糟糕故事繼續發揚光大。\r\n我不想把錢花在這種地方，就算它蘋果長得有多麼華麗、多麼漂亮，我都不會受到誘惑的！我已經被它封面騙過一次，絕不會再上當第二次！>:("));
            Text_contents.Add(new Text_content(5231, "驚訝", "Happy", 50, 0, 0, 0, false, "驚訝，因為故事內容實在是太嚇人了，跟轉蛋可愛形象不成正比。不過要是因此而入坑，我覺得也不錯！我很期待續集，聽說明年就會出版了。\r\n不過我最後並沒有轉，因為我錢帶不夠。"));
            Text_contents.Add(new Text_content(5232, "奇怪", "Wow", 50, 0, 0, 0, false, "奇怪，懷疑自己是不是看錯書籍了，尤其是它分類也怪怪的。\r\n雖然角色都很可愛，不過我今天不想花錢玩轉蛋，後來看一看也沒什麼特別想轉的就離開了。"));

            Text_contents.Add(new Text_content(53, "書", "None", 50, 0, 0, 0, false, "放學回家時，在路上看到一家新開的書店，趁著公車還沒來，我便開心的進去晃晃了。\r\n現在獨立書店要生存真的很困難，可以的話我想至少買一本書回去（只是要小心藏好不被爸媽發現）。\r\n店裡的暖光和書香讓人感到"));
            Text_contents.Add(new Text_content(531, "放鬆", "None", 25, 5, 0, 0, false, "放鬆，忘卻了在現實的煩惱，可以好好沉浸在書的世界裡。\r\n新的木製書架上擺滿了新書，我拿起其中一本書慢慢翻閱，似乎是個"));
            Text_contents.Add(new Text_content(5311, "救世主", "None", 50, 0, 0, 0, false, "救世主降臨的故事。女主角只是個平凡的農家女孩，但是預言卻說她是傳說中的救世主，必須由她來擊敗恐怖的黑暗君主，才能為世界帶來和平。\r\n噢，看這個簡介好像還挺"));
            Text_contents.Add(new Text_content(53111, "有趣", "Happy", 50, 0, 0, 0, false, "有趣。封面還有燙金設計，還滿華麗的，就買回去看看吧！\r\n店員姐姐人感覺很好，什麼都沒問就將書替我裝進紙袋裡，她的笑容很爽朗，真羨慕這樣的人。"));
            Text_contents.Add(new Text_content(53112, "厲害", "Happy", 50, 0, 0, 0, false, "厲害。好像世界觀設定的很深入，感覺可以仔細推敲一番？買回去看看好了！\r\n幫我結帳的店員臉看起來有點厭世，不過那樣也好，要是話太多我反而覺得緊張。"));

            Text_contents.Add(new Text_content(5312, "驚悚", "None", 50, 0, 0, 0, false, "驚悚的鬼故事。\r\n年輕的女主角是個歷史學家，去到偏遠郊區出差時住進了一家旅社，但是在下著大雨的夜晚聽到了奇怪的腳步聲，跟著腳步聲走出房門外，卻看到一具無頭屍體……\r\n太"));
            Text_contents.Add(new Text_content(53121, "可怕", "Wow", 50, 0, 0, 0, false, "可怕了吧！？我好想知道女主角怎麼反應！等我回過神來我就將這本書給買下來了。\r\n之後一定要找個時間來好好閱讀！"));
            Text_contents.Add(new Text_content(53122, "吸引", "Happy", 50, 0, 0, 0, false, "吸引人了吧？！為什麼簡介斷在這種地方！我一定要買回去看！\r\n雖然封面白骨有點嚇人，不過套著布書套遮住就好了，還能偽裝成課本呢。;)"));

            Text_contents.Add(new Text_content(532, "愜意", "None", 50, 0, 0, 0, false, "愜意！我好想住進像這樣的房間裡，頂到天花板的書架上擺滿了書籍，哇！想想就覺得"));
            Text_contents.Add(new Text_content(5321, "浪漫", "Happy", 50, 0, 0, 0, false, "浪漫，畢竟和書作伴是件愉悅的事。\r\n我翻閱了一些新書推薦區的書，其中幾本我好像在圖書館的新書區有看過？之後借來看看好了。\r\n這次逛了逛後我沒買任何書籍，也許下次再說吧！"));
            Text_contents.Add(new Text_content(5322, "吸引", "Wow", 50, 0, 0, 0, false, "吸引人。\r\n不過，要是沒做好防潮處理，有這麼多木頭也會吸引到白蟻吧？唔，一想到這麼現實的事情，不禁沒了幻想泡泡的魔力。\r\n好吧，至少在書店裡可以體驗到被書包圍的感覺！"));

            //diary_day01
            Text_contents.Add(new Text_content(61, "日記", "None", 25, 5, 0, 0, false, "今天在補習班的時候，我正在寫日記。我沒注意到補習班的男老師靠近，他一把就抽走我的"));
            Text_contents.Add(new Text_content(611, "日記", "None", 50, 0, 0, 0, false, "日記，攤開的本子就這麼被他舉高晃在空中，他甚至怒斥我：「不准在補習班寫作業以外的東西！下次再被我看到就沒收、還要唸給所有人聽！」我真的太"));
            Text_contents.Add(new Text_content(6111, "憤怒", "Angry", 50, 0, 0, 0, false, "憤怒了！明明我已經完成作業了，為什麼我不能寫其他的東西？難道他是怕我寫了一些對他不利的話嗎？真好笑。\r\n絲毫不尊重我的隱私，真不愧是爸媽找的補習班！"));
            Text_contents.Add(new Text_content(6112, "驚訝", "Wow", 50, 0, 0, 0, false, "驚訝了。他以為自己是警察在審問犯人嗎？雖然很不爽，但我不敢頂嘴，我怕他真的把我的日記公開。要是被爸媽知道，所有的錯又會落到我的身上。\r\n下次不帶日記到補習班了。"));

            Text_contents.Add(new Text_content(612, "筆", "None", 25, 5, 0, 0, false, "筆，一副頤指氣使的對我說：「你的握筆不對啊，你爸媽沒好好教你嗎？」他忽然將手搭在我的手上，說是要"));
            Text_contents.Add(new Text_content(6121, "教導", "None", 50, 0, 0, 0, false, "教導我如何握筆。我覺得很不舒服，但不知道該怎麼反應，只是整個人"));
            Text_contents.Add(new Text_content(61211, "僵硬", "Sad", 50, 0, 0, 0, false, "僵硬在原地。幸好另一個女老師剛好進來教室，他馬上就放開了我的手。\r\n後來我洗了十多次手，卻感覺仍然洗不去皮膚上的噁心感。"));
            Text_contents.Add(new Text_content(61212, "緊張", "Sad", 50, 0, 0, 0, false, "緊張了起來。這是性騷擾嗎？還是說只是普通的肢體接觸？會不會只是我誤會了？要是我跟別人講，別人會相信我嗎？我不知道。\r\n我回家後洗手洗了許久，還是感覺很怪。"));

            Text_contents.Add(new Text_content(6122, "我", "None", 50, 0, 0, 0, false, "我重新學習握筆的方式。我還以為我回到了幼兒園的時候，他把筆和我的手調整成所謂的「正確握筆姿勢」，但我只覺得寫起來"));
            Text_contents.Add(new Text_content(61221, "彆扭", "Angry", 50, 0, 0, 0, false, "彆扭。\r\n只要能寫出好看的字，怎麼握筆都無所謂吧？我不懂這老師這麼多管閒事幹嘛，他寫的字甚至比我還難看懂；比起握筆姿勢，我看他還比較需要練習如何寫好端正的字。"));
            Text_contents.Add(new Text_content(61222, "奇怪", "Wow", 50, 0, 0, 0, false, "奇怪。\r\n我不習慣以這樣的方式寫字，也不懂為何連握筆都有一個「正確」方式。感覺人們沒有一個規定就會找不到方向，必須遵循著某種規則才能活著。\r\n總之，怎麼寫字我還是會照原來的方式，我不想連這麼一點小事的決定權也被人剝奪。"));

            Text_contents.Add(new Text_content(62, "作業", "None", 25, 5, 0, 0, false, "今天在補習班的時候，我正在寫作業。是我最不擅長的數學，國中時還勉強能應付，但升上高中後幾乎跟不上進度。看著紙張上的題目，我只覺得"));
            Text_contents.Add(new Text_content(621, "疲倦", "None", 50, 0, 0, 0, false, "疲倦感襲來。明明寫的都是中文字，為什麼我就是無法理解題目意思呢？看了也不知道要套入什麼公式，就算真的套入公式好了，我也算不出來正確答案。補習班老師看我好像很苦惱，於是過來"));
            Text_contents.Add(new Text_content(6211, "教導", "Happy", 50, 0, 0, 0, false, "教導我不懂的地方，她教了我一個更簡約的算法。雖然有點偷吃步，但我一下子便聽懂了！\r\n不曉得之後遇到類似的題目我能不能解得出來，但至少我完成了現在的作業。"));
            Text_contents.Add(new Text_content(6212, "詢問", "Happy", 50, 0, 0, 0, false, "詢問我哪裡不懂。我告訴她：我不知道為什麼要用這個公式，於是老師細心解釋，並一步一步帶我解題，我不懂的部分也會仔細說明，讓我徹底清楚。\r\n真的很感謝老師，我想我有那麼一點不排斥數學了。"));

            Text_contents.Add(new Text_content(622, "困惑", "None", 50, 0, 0, 0, false, "困惑，不禁懷疑是否我的理解力變差了。上課時聽老師講解感覺聽懂了，但為何面對回家作業時就完全算不出來呢？這實在是太"));
            Text_contents.Add(new Text_content(6221, "煩躁", "Wow", 25, 5, 0, 0, false, "煩躁了。我跟數學作業本大眼瞪小眼，我認識它、它認識我，但卻是誰也不理解誰。我真的不知道要怎麼辦，所以乾脆全部選C，計算題全部代入同一個公式強行計算。\r\n唉……反正我至少完成了作業，對吧。"));
            Text_contents.Add(new Text_content(6222, "挫折", "Sad", 50, 0, 0, 0, false, "挫折了。可是我又不敢拿題目去問老師怎麼解題，只好默默假裝自己正在努力認真寫，不想讓別人發現其實我根本就不會算。\r\n我真的很討厭數學。"));

            Text_contents.Add(new Text_content(63, "作文", "None", 25, 5, 0, 0, false, "今天在補習班的時候，我正在寫作文。題目是〈為自己而活〉。真是個"));
            Text_contents.Add(new Text_content(631, "有趣", "None", 50, 0, 0, 0, false, "有趣的題目。為了自己而活？這題目與我八竿子打不著，從我出生以來，都是為了爸媽的欲望生活，練討厭的才藝、讀煩悶的書，沒有一樣是我真正想追求的事物"));
            Text_contents.Add(new Text_content(6311, "幸福", "Happy", 50, 0, 0, 0, false, "幸福了！我只想為自己而活，我想要用我的文字改變世界！我希望所有人都能被溫柔善待！字句裡皆充滿正面能量，我想老師會很喜歡這樣的內容。\r\n文字似乎真的有力量，寫完作文後我感覺自己心靈暫時也變得很正向呢。"));
            Text_contents.Add(new Text_content(6312, "我", "Happy", 50, 0, 0, 0, false, "我了呢。我想活成什麼樣子呢？突然要想還真有點不知所措呢……我好像從來沒有想過這個問題。也許是當個樂善好施、善良的人？還是說情緒穩定、又勇敢的人呢？嗯……我想這些都行吧。"));

            Text_contents.Add(new Text_content(632, "奇怪", "None", 50, 0, 0, 0, false, "奇怪的題目。我想，很多人都難說自己是認真為了自己而活吧。\r\n在世上總有牽掛，孩子為了父母而活、夫妻為了彼此而活……能為了自己而活的人，真的有嗎？怎麼想都很"));
            Text_contents.Add(new Text_content(6321, "困惑", "Sad", 25, 5, 0, 0, false, "困惑，要是真的有這樣純粹的人，我真想向他請教請教。\r\n我總感覺也許有人會說這樣的人是自私自利，可是人生是自己過的呀，為什麼要特別去插手別人的生活呢？如果連自己都活不好，還要去管別人閒事，那才真的是討人厭。:("));
            Text_contents.Add(new Text_content(6322, "厲害", "Wow", 50, 0, 0, 0, false, "厲害，他能夠放下世俗牽掛，完完全全的成為最好的自己。要是爸媽可以減少一些對我的控制欲，我是不是也能朝為自己而活這個目的稍微前進一點？\r\n可惜現實根本不是這樣，我只能在作文寫入美好的想像。"));
        }
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
            static_parameters.MC_HP_Max += falseTextContents[randomIndex].HP;
            static_parameters.MC_ATK += falseTextContents[randomIndex].Att_pow;
            static_parameters.MC_ATK_Speed += falseTextContents[randomIndex].Att_speed;
            static_parameters.MC_Wspeed += falseTextContents[randomIndex].Walk_speed;
            // 打印已修改的对象
            Debug.Log($"Modified Text_content: Name_number: {falseTextContents[randomIndex].Name_number}, Name_Text: {falseTextContents[randomIndex].Name_Text}, MC_HP_Max: {static_parameters.MC_HP_Max}, MC_ATK: {static_parameters.MC_ATK}, MC_ATK_Speed: {static_parameters.MC_ATK_Speed}, MC_speed: {static_parameters.MC_Wspeed}, Text_exist: {falseTextContents[randomIndex].Text_exist}");
        }
    }

    public void pick1()
    {
        if (pick_tmp[0] < 2) pick_tmp[0]++;
        if (pick_tmp[1] < 2) pick_tmp[1] = 0;
        if (pick_tmp[2] < 2) pick_tmp[2] = 0;
        if (pick_tmp[3] < 2) pick_tmp[3] = 0;
        pickdiary = 1;
        click_button_Y();
        pickplace();
    }
    public void pick2()
    {
        if (pick_tmp[0] < 2) pick_tmp[0] = 0;
        if (pick_tmp[1] < 2) pick_tmp[1]++;
        if (pick_tmp[2] < 2) pick_tmp[2] = 0;
        if (pick_tmp[3] < 2) pick_tmp[3] = 0;
        pickdiary = 2;
        click_button_Y();
        pickplace();
    }
    public void pick3()
    {
        if (pick_tmp[0] < 2) pick_tmp[0] = 0;
        if (pick_tmp[1] < 2) pick_tmp[1] = 0;
        if (pick_tmp[2] < 2) pick_tmp[2]++;
        if (pick_tmp[3] < 2) pick_tmp[3] = 0;
        pickdiary = 3;
        click_button_Y();
        pickplace();
    }
    public void pick4()
    {
        if (pick_tmp[0] < 2) pick_tmp[0] = 0;
        if (pick_tmp[1] < 2) pick_tmp[1] = 0;
        if (pick_tmp[2] < 2) pick_tmp[2] = 0;
        if (pick_tmp[3] < 2) pick_tmp[3]++;
        pickdiary = 4;
        click_button_Y();
        pickplace();
    }
    public void Confirm()
    {
        auto_Text_Paper.Confirm();
        //print(auto_Text_Paper.Diary_serial_number+" "+auto_Text_Paper.mood);
    }

    private void click_button_Y()
    {
        // 檢查當前被選中的 UI 元件
        GameObject selectedButton = EventSystem.current.currentSelectedGameObject;

        if (selectedButton != null)
        {
            // 取得按鈕的 RectTransform 並獲取其 Y 座標
            RectTransform rectTransform = selectedButton.GetComponent<RectTransform>();
            Vector3 buttonPos = rectTransform.position; // 世界座標
            float buttonY = buttonPos.y;

            //替換成更新後的位置
            RectTransform rectTransform1 = diarypointer.GetComponent<RectTransform>();
            Vector3 currentPosition = rectTransform1.anchoredPosition;
            currentPosition.y = buttonY;
            rectTransform1.anchoredPosition = currentPosition;
        }
    }

    public void pickplace()
    {
        switch (pickdiary)
        {
            case 1:
                static_parameters.pickdiary = 1;
                break;
            case 2:
                static_parameters.pickdiary = 2;
                break;
            case 3:
                static_parameters.pickdiary = 3;
                break;
            case 4:
                static_parameters.pickdiary = 4;
                break;
        }
        for (int i = 0; i < 4; i++)
        {
            if (pick_tmp[i] == 2)
            {
                pick_tmp[i] = 3;
                auto_Text_Paper.diary_buff_check[i + 1][0] = auto_Text_Paper.diary_buff_check[0][0];
                auto_Text_Paper.diary_buff_check[i + 1][1] = auto_Text_Paper.diary_buff_check[0][1];
                auto_Text_Paper.diary_buff_check[i + 1][2] = auto_Text_Paper.diary_buff_check[0][2];
                auto_Text_Paper.diary_buff_check[i + 1][3] = auto_Text_Paper.diary_buff_check[0][3];
                auto_Text_Paper.diary_buff_name[i] = "";
                auto_Text_Paper.diary_buff_name[i] += "HP:+";
                auto_Text_Paper.diary_buff_name[i] += auto_Text_Paper.diary_buff_check[i + 1][0].ToString() + "\r\n";
                auto_Text_Paper.diary_buff_name[i] += "ATK_Pow:+";
                auto_Text_Paper.diary_buff_name[i] += auto_Text_Paper.diary_buff_check[i + 1][1].ToString() + "\r\n";
                auto_Text_Paper.diary_buff_name[i] += "ATK_Speed:+";
                auto_Text_Paper.diary_buff_name[i] += auto_Text_Paper.diary_buff_check[i + 1][2].ToString() + "\r\n";
                auto_Text_Paper.diary_buff_name[i] += "Walk_Speed:+";
                auto_Text_Paper.diary_buff_name[i] += auto_Text_Paper.diary_buff_check[i + 1][3].ToString() + "\r\n";
                ch3.Read_text[i] = drag_End.all_text;
                foreach (Text_content content in Text_Array.Text_contents)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (content.Name_number == static_parameters.diary_memory[0][j])
                        {
                            content.Text_exist = false;
                            static_parameters.diary_memory[i + 1][j] = static_parameters.diary_memory[0][j];
                            Debug.Log("static_parameters.diary_memory[" + (i + 1) + "][" + j + "]:" + static_parameters.diary_memory[i + 1][j]);
                            static_parameters.diary_memory[0][j] = 0;
                        }
                    }
                }
                // 確保 EventSystem 存在
                if (EventSystem.current != null)
                {
                    // 獲取當前選中的按鈕，確保有選中的按鈕
                    GameObject selectedButton = EventSystem.current.currentSelectedGameObject;
                    if (selectedButton != null)
                    {
                        // 嘗試獲取 Button 組件
                        Button buttonComponent = selectedButton.GetComponent<Button>();
                        if (buttonComponent != null)
                        {
                            // 自訂禁用狀態的外觀，讓按鈕禁用時保持原樣
                            ColorBlock colors = buttonComponent.colors;
                            colors.disabledColor = colors.normalColor;
                            buttonComponent.colors = colors;
                            // 將按鈕設置為不可互動
                            buttonComponent.interactable = false;
                        }
                    }
                }
                auto_Text_Paper.diary_name[i].text = auto_Text_Paper.Pick_Text.text;
                auto_Text_Paper.diary_name_tmp[i].text = auto_Text_Paper.diary_name[i].text;
                auto_Text_Paper.Pick_Text.text = "";
                Rightpage.SetActive(true);
                Dspace.SetActive(false);
            }
            Debug.Log("ch3.Read_text[i]:" + i + ",text:" + ch3.Read_text[i] + "\r\n");
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

    public Text_content(uint Name_number, string Name_Text, string Feeling, int HP, float Att_pow, float Att_speed, float Walk_speed, bool Text_exist, string Text_text)
    {
        this.Name_number = Name_number;
        this.Name_Text = Name_Text;
        this.Feeling = Feeling;
        this.HP = HP;
        this.Att_pow = Att_pow;
        this.Att_speed = Att_speed;
        this.Walk_speed = Walk_speed;
        this.Text_exist = Text_exist;
        this.Text_text = Text_text;
        if (Text_exist)
        {
            static_parameters.MC_HP_Max += HP;
            static_parameters.MC_ATK += Att_pow; static_parameters.MC_ATK_tmp = static_parameters.MC_ATK;
            static_parameters.MC_ATK_Speed += Att_speed; static_parameters.MC_ATK_Speed_tmp = static_parameters.MC_ATK_Speed;
            static_parameters.MC_Wspeed += Walk_speed; static_parameters.MC_Wspeed_tmp = static_parameters.MC_Wspeed;
        }
    }
}

