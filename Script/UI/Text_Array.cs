using System.Collections.Generic;
using UnityEngine;

public class Text_Array : MonoBehaviour
{
    static public List<Text_content> Text_contents = new List<Text_content>();
    static public short[] diary_step;
    static public uint diary_number = 0;
    static public bool Add_array = true;
    void Awake()
    {
        if (Add_array)
        {
            //diary_step
            diary_step = new short[4];
            diary_step[0] = 0;
            diary_step[1] = 0;
            diary_step[2] = 0;
            diary_step[3] = 0;

            //diary_novel01
            Text_contents.Add(new Text_content(11, "《醜小鴨與天鵝湖》", "none", 25, 5, 0, 0, true, "我感覺自己就像主角醜小鴨，但爸媽卻希望我像天鵝一樣功成名就。\r\n明明在水底下，醜小鴨與天鵝都在努力用腳打水，好讓自己保持優雅。可是他們只看得見我表面上醜陋不堪，沒人會知道我有多麼努力才能活著。\r\n我的結局也能如醜小鴨一樣來個"));
            Text_contents.Add(new Text_content(1110, "幸福生活", "sad", 50, 0, 0, 0, true, "嗎？即使醜小鴨經歷了那麼多苦難，忍受天鵝們的嘲諷，最後仍是活出精彩人生。說真的，我有辦法跟他一樣嗎？（怎麼可能）"));
            Text_contents.Add(new Text_content(1120, "救世主", "sad", 25, 5, 0, 0, true, "拯救嗎？會不會有哪個人願意拉我一把，讓我逃離爸媽的掌控？還是說，只有我能拯救我自己呢？但我目前還沒有足夠的勇氣……"));
            Text_contents.Add(new Text_content(1130, "反轉", "sad", 0, 0, 0, 0, true, "嗎？我也能脫離掌控，找回我自己的主控權嗎？……可惜書只是書，好結局哪有那麼好得到。"));

            Text_contents.Add(new Text_content(12, "《薔薇的女兒》", "none", 0, 0, .05f, 1, true, "最近有些書荒，剛好圖書館進了些新書就隨意借一本來看。書本內容看了實在是很讓人感到"));
            Text_contents.Add(new Text_content(1210, "憤怒", "angry", 0, 10, 0, 0, true, "！\r\n女主角被父母控制所有生活的一切大小事，完全無視她的感受、限制人身自由，這不就跟我爸媽一樣嘛！甚至父母還要強迫女主角當祭品，根本就沒有問過女主角的意願！\r\n難道全天下的父母都認為「因為你是我生養的，所以你的就是我的」嗎？\r\n雖然有些地方所描述的代入感太強，看了很氣憤。（尤其是女主角父母出現的時候！）不過我還是會讀完它。"));
            Text_contents.Add(new Text_content(1220, "驚訝", "wow", 0, 10, 0, 0, true, "！\r\n我原本以為這只是普通的家庭生活故事，沒想到突然來個大轉折，出現了黑魔法元素，還有什麼恐怖的黑玫瑰儀式！？\r\n但這本書卻是分類在「親子關係」？這明明就是「懸疑、奇幻」小說吧？是出版社搞錯了嗎？\r\n不過無所謂，這反而引起了我的興趣。我會繼續讀完它，只要我明天能夠早一點完成作業的話……"));
            Text_contents.Add(new Text_content(1230, "驚悚", "wow", 25, 0, .05f, 0, true, "！\r\n女主角發現了父母長年扶養她的陰謀，只為了要讓她成為黑玫瑰儀式的祭品，這個儀式是家族留下來的傳統，據說能賦予參與者永恆生命，只是每次都必須犧牲一名女兒。（他們還真的相信嗎？）\r\n她從地下室逃離時的恐懼從書裡傳染給我，彷彿我就是逃跑的女孩。逃到一半還是被抓了回去，真是太絕望了……我停止不下來繼續閱讀的欲望。\r\n我想我明天上課會變得很不專心，會一直在想接下來女主角怎麼辦。"));
            Text_contents.Add(new Text_content(1240, "緊張", "happy", 0, 0, 0, 2, true, "！\r\n看著女主角從父母洗腦中脫離，要在他們眼皮下慢慢找尋真相，最終發現他們只是把她當成祭品撫養，她會死於一場詭異的儀式中，真的太嚇人了！\r\n幸好最後女主成功逃離那些想傷害她的人，這過程實在是太緊張刺激了！許久沒看到這麼精彩的故事，我的心情也忍不住激動起來了。\r\n不曉得會不會有續集呢？其中一些伏筆還沒解開讓人覺得有些在意呢……"));

            Text_contents.Add(new Text_content(13, "《奇異蘋果》", "none", 0, 10, 0, 0, true, "這個故事絲毫沒有"));
            Text_contents.Add(new Text_content(1310, "反轉", "none", 0, 0, 0, 2, true, "的部分，從頭到尾只是在講一個老頭以為自己得到有魔力的蘋果並沾沾自喜，還傻傻的放到爛掉而不吃！簡直是"));
            Text_contents.Add(new Text_content(13110, "浪費", "angry", 0, 10, 0, 0, false, "買蘋果的錢又浪費食物。只是聽到別人說這是有魔力的蘋果就笨到相信，連個事實都懶得求證。\r\n可笑的是，這世界還真有許多人是如此。"));
            Text_contents.Add(new Text_content(13120, "糟蹋", "wow", 0, 0, .1f, 0, true, "食物！種子長成果樹再結出蘋果，需要花費多少時間，就這麼任由好吃的蘋果爛掉，我覺得實在太可惜了。\r\n要是我一定會特別好奇有魔力的蘋果是不是更美味而忍不住吃掉。:P"));
            Text_contents.Add(new Text_content(1320, "緊張", "none", 0, 0, 0, 2, true, "感。我原本以為老頭吃了蘋果後肚子痛，是因為觸犯了什麼魔法禁忌？結果根本不是，只是他身體"));
            Text_contents.Add(new Text_content(13210, "不適", "sad", 0, 0, .1f, 0, false, "，又剛好吃到不新鮮的蘋果。\r\n這商人只是想把爛蘋果賣掉而哄騙老頭說這是「能實現願望的奇異蘋果」，真是騙人太糟糕了，商人應該要有誠信。"));
            Text_contents.Add(new Text_content(13220, "過敏", "wow", 0, 0, 0, 2, false, "。\r\n這輩子第一次吃到蘋果，也是最後一次吃到蘋果！我不禁為這個老頭感到可憐……蘋果是多麼好吃的水果，拿來製作成派、麵包或是沙拉，都是多麼好吃的選擇。\r\n突然好想吃啊……"));
            Text_contents.Add(new Text_content(1330, "有趣", "none", 50, 0, 0, 0, false, "的地方。這個故事敘事平淡無奇，也沒有任何重點。我覺得非常"));
            Text_contents.Add(new Text_content(13310, "浪費", "sad", 0, 10, 0, 0, true, "寶貴時間，只不過是封面上畫了顆漂亮又美味的蘋果，我就因此被吸引而借來閱讀，真是太讓人後悔了……\r\n果然事情都不能只看表面。"));
            Text_contents.Add(new Text_content(13320, "驚訝", "angry", 50, 0, 0, 0, true, "，因為這本書還有幾位名人大力推荐。他們真的有親自閱讀過嗎？還是說只是收錢辦事？這怎麼想也不會是值得看的書，看了等於沒看。"));

            //diary_novel02
            Text_contents.Add(new Text_content(21, "小心翼翼", "none", 25, 5, 0, 0, true, "的靠近透明窗邊，看著雨滴打在玻璃上，一顆顆的水珠緩慢匯流成一條小河。\r\n看起來好"));
            Text_contents.Add(new Text_content(2110, "療癒", "none", 50, 0, 0, 0, true, "哦！可以猜猜哪顆雨珠跑得最快，不過我今晚不想把時間耗費在這。\r\n我借了新的小說回來，打算在今晚閱讀。\r\n雖然爸媽說晚上是要我自己讀書複習或預習的時間，不過……那些在補習班都聽過了，我想稍微休息一下也沒關係吧？\r\n搭配著下雨聲閱讀小說，真的太"));
            Text_contents.Add(new Text_content(21110, "愜意", "happy", 50, 0, 0, 0, true, "了。天然的白噪音就是令人心曠神怡啊，不需要戴著耳機也能聽見從四面八方的雨聲，彷彿整個人被雨水包圍起來，實際上則是待在溫暖的室內裡。"));
            Text_contents.Add(new Text_content(21120, "放鬆", "happy", 50, 0, 0, 0, true, "了，尤其整個人縮在暖暖的被窩裡，阻隔了外面的滂沱大雨，反而讓人感到安心。\r\n與其說家庭是溫暖的避風港，不如說我的床上才是！"));
            Text_contents.Add(new Text_content(2120, "浪漫", "none", 25, 5, 0, 0, true, "了！有些戀愛小說裡不都會出現這樣的場景嗎？男女主角因為誤會而分開，其中一方就會傷心的在豪雨中奔跑。大哭時分不清楚雨水和淚水，也反映出受傷的心靈。\r\n這種劇情是有些"));
            Text_contents.Add(new Text_content(21210, "通俗", "none", 50, 0, 0, 0, true, "了，看太多反而會疲乏，還會遭人嫌。只是小說字多，我認為寫這種老掉牙的劇情大概也沒人會想認真看，而現在看書的人越來越少了，大家都在追求速食娛樂。"));
            Text_contents.Add(new Text_content(21220, "常見", "none", 50, 0, 0, 0, true, "了，不過既然常見，就代表大家其實挺喜歡的吧？\r\n不過這種劇情要寫得好看與感人還是需要點技巧，不然俗套的東西反覆再出現，都會看得疲倦。"));

            Text_contents.Add(new Text_content(22, "詢問", "none", 25, 5, 0, 0, true, "爸媽能不能讓我回去房間，但他們似乎沒罵夠我。因為我今天去補習班時遲到了十五分鐘，老師就打給媽媽說，結果她知道了非常生氣。\r\n我不想說是因為我跑去逛書店而錯過公車，來不及趕上補習班的時間。\r\n但我也不想說謊，所以爸媽逼問不出來時，就"));
            Text_contents.Add(new Text_content(2210, "憤怒", "angry", 50, 0, 0, 0, true, "得對我破口大罵。外面的雷雨聲剛好蓋過他們的怒罵聲，所以我有些放空的看著他們扭曲的臉龐。\r\n他們唸了半小時，才肯放我走。我本來打算在今夜閱讀新借的小說，現在心情卻無了。"));
            Text_contents.Add(new Text_content(2220, "面面相覷", "sad", 50, 0, 0, 0, true, "了一會兒，最後媽媽嘆了一口氣的，爸爸看起來也很疲憊。他們要我下次別遲到了，補習班費錢、希望我好好學習之類的叮嚀。\r\n我回到房間裡聽著雨聲滴答滴答，我想這剛好反映了我們家的情況。"));
            
            Text_contents.Add(new Text_content(23, "疲倦", "none", 50, 0, 0, 0, true, "不堪，但就算很累，我也想趕快利用空閒時間翻閱今天新借來的小說。\r\n但我今天有點"));
            Text_contents.Add(new Text_content(2310, "過敏", "wow", 25, 5, 0, 0, true, "，因為天氣驟然變涼，所以一直在流鼻水。桌子上很快就堆滿衛生紙水餃，害我沒辦法專心看書，一直在擤鼻涕，鼻子都快揉成小丑的紅鼻子了。\r\n……嗯，這算不算跟這本《小丑夢魘》的小丑不謀而合了呢？\U0001f921"));
            Text_contents.Add(new Text_content(2320, "不適", "wow", 50, 0, 0, 0, true, "，早上體育課還掛著大太陽，跑了八百公尺讓我身體覺得很不舒服。晚上卻馬上下起大雨，瞬間的濕冷讓我更疲憊了。\r\n但是我真的好想看小說，所以還是稍微看了半小時。最後身體真的承受不了，才倒頭大睡。"));

            //diary_music01
            Text_contents.Add(new Text_content(31, "哭泣", "none", 25, 5, 0, 0, true, "，那時只要看到不認識的人，我就會大爆哭，我想不起來是什麼原因導致我那麼排斥陌生人。\r\n可是我記得媽媽那時候的臉極其冷酷，她絲毫不在意我是不是被陌生人嚇著了，就讓我和那名鋼琴老師相處一室。\r\n鋼琴老師蹲下身，介紹她自己叫做「何乃」，我喊她何乃老師。\r\n她人很"));
            Text_contents.Add(new Text_content(3110, "和藹", "sad", 50, 0, 0, 0, true, "，我還記得她那時候非常溫柔的安撫我，說我們今天先來認識彼此就好。\r\n雖然停止了哭聲，但我的眼淚還是掉不停。何乃老師從包裡掏出一顆太妃糖，塞到了我的掌心裡，她說難過時吃一點甜甜的，心情就會變好。\r\n我不相信陌生人給的東西，但她感覺不像壞人，所以我就相信她了。但正是因為我太相信她，才會有一天跟她說出我的內心話，說我真的很討厭鋼琴、也不想學鋼琴，才會導致她被媽媽開除……;(\r\n後來媽媽換了一個很兇的鋼琴老師，那幾年簡直是我的夢魘。"));

            Text_contents.Add(new Text_content(32, "彆扭", "none", 25, 5, 0, 0, true, "的不知道如何反應，突然看到一個陌生人，當然會覺得恐懼，當然現在不會了……除了與陌生人說話，這得另當別論。\r\n媽媽要我好好學琴，叮囑我要乖巧的聽老師的話。媽媽離開房間後，我好像才後知後覺的哭了。\r\n但何乃老師是個"));
            Text_contents.Add(new Text_content(3210, "有趣", "angry", 50, 0, 0, 0, true, "的人，她那時在我後腦勺附近的空氣撈啊撈，竟然撈出了一支彩色的心型棒棒糖。\r\n我看呆了，一時半刻就停止眼淚。她說我們能邊吃糖、邊認識彼此。但幾乎都是她在說話，我只負責點頭、搖頭和吃糖。\r\n不知道她現在過得怎麼樣了？我記得當初我不管彈得多差，她都會耐心的教導、糾正我，從來沒有厭煩的樣子，我一直很喜歡她，可惜她只教了我兩年。\r\n後來媽媽換了一個兇巴巴的鋼琴老師，她比練習鋼琴還要讓我更討厭。"));

            Text_contents.Add(new Text_content(33, "困惑", "none", 50, 0, 0, 0, true, "不解，不曉得這個陌生人是誰。媽媽說這是我以後的鋼琴老師，以後得跟著她學鋼琴，一個禮拜兩次，一次三個小時。\r\n我記得與她學鋼琴快兩年時，何乃老師跟媽媽大吵一架。因為我跟她說我討厭鋼琴，但卻不敢和媽媽講明白。\r\n於是她替"));
            Text_contents.Add(new Text_content(3310, "我", "sad", 25, 5, 0, 0, true, "向媽媽說，說別逼孩子不喜歡的事情、她已經到了足夠認知到自己喜惡的年紀，之類的……（當時我偷偷貼在房門上偷聽她們在客廳講話），結果她們竟然講到吵起來，媽媽一氣之下就要何乃老師捲鋪蓋。\r\n我感到很愧疚，是我害何乃老師被炒魷魚，要是我沒跟她說我討厭鋼琴就好了，那樣子她就不會被媽媽開除，也不會換下一個討人厭的鋼琴老師了。\r\n我很想念溫柔的何乃老師，不曉得她現在過得怎麼樣？"));

            //diary_plant01
            Text_contents.Add(new Text_content(41, "黃金葛", "none", 25, 5, 0, 0, true, "，她還交付了我一個任務，要我之後就負責照顧這些盆栽。\r\n可能看到我為難的表情，阿姨就笑著說這些植物很好養，只要偶爾澆水就好。我"));
            Text_contents.Add(new Text_content(4110, "點頭", "none", 50, 0, 0, 0, true, "，阿姨好像很開心，還說今天就讓我負責澆水就好，澆完水就可以自由活動了。只要澆水就好嗎？突然減少的工作任務讓我有點"));
            
            Text_contents.Add(new Text_content(41110, "開心", "none", 50, 0, 0, 0, true, "，因為多了很多時間可以去看書了！\r\n我把澆水壺裝滿水，小心翼翼澆在植物上。我從來沒有照顧過植物，這很"));
            Text_contents.Add(new Text_content(41111, "彆扭", "happy", 50, 0, 0, 0, true, "，不過我一次只澆一點點水，慢慢加就不會有過滿的問題，所以看起來還行！\r\n希望這株小黃金葛可以活得很健康！"));
            Text_contents.Add(new Text_content(41112, "奇怪", "happy", 50, 0, 0, 0, true, "吧？我想爸媽不會讓我嘗試園藝，我也沒看過我們家有任何植物出現。\r\n所以，我很期待這株小黃金葛可以長得更加茁壯。"));

            Text_contents.Add(new Text_content(41120, "挫折", "none", 25, 5, 0, 0, true, "，是不是阿姨覺得我連普通的打掃工作都做得不好，才要我做這種易如反掌的事情呢……\r\n總之，這盆黃金葛看起來有點"));
            Text_contents.Add(new Text_content(41121, "玩具", "wow", 50, 0, 0, 0, true, "塑膠感，我摸了摸心型葉片，光光滑滑的觸覺好特別。\r\n\r\n後來我稍微查了一下資料，發現黃金葛的生命力其實很堅韌，真是意想不到。"));
            Text_contents.Add(new Text_content(41122, "愜意", "happy", 50, 0, 0, 0, true, "，只需要慵懶生長、生活也是自由自在，根本沒有任何煩惱，真好。"));

            Text_contents.Add(new Text_content(4120, "搖頭", "none", 50, 0, 0, 0, true, "，因為我覺得我做不來這種事情，但是阿姨說這是我在圖書志工社的任務，要交付給我完成。那……好吧，我還是拿了澆水壺來澆水，我動作是有一點"));
            Text_contents.Add(new Text_content(41210, "僵硬", "sad", 50, 0, 0, 0, true, "，所以水不小心澆得有點多，噢不！小黃金葛，我很抱歉……我下次會注意一點，請你別介意。"));
            Text_contents.Add(new Text_content(41220, "煩躁", "angry", 50, 0, 0, 0, true, "，很氣自己連小事都做不好，我一個不注意不小心就澆太多，結果水從底部盤子滲出……阿姨說下次要澆少一點水，害我更愧疚了。\r\n唉……心情好差。"));

            Text_contents.Add(new Text_content(42, "仙人掌", "none", 25, 5, 0, 0, true, "，她還交付了我一個任務，要我之後就負責照顧這些盆栽。\r\n可能看到我為難的表情，阿姨就笑著說這些植物很好養，只要偶爾澆水就好。我"));
            Text_contents.Add(new Text_content(4210, "點頭", "none", 50, 0, 0, 0, true, "，阿姨好像很開心，還說今天就讓我負責澆水就好，澆完水就可以自由活動了。只要澆水就好嗎？突然減少的工作任務讓我有點"));
            Text_contents.Add(new Text_content(42110, "開心", "none", 50, 0, 0, 0, true, "，因為多了很多時間可以去看書了！\r\n我把澆水壺裝滿水，小心翼翼澆在植物上。我從來沒有照顧過植物，這很"));
            Text_contents.Add(new Text_content(42111, "彆扭", "happy", 50, 0, 0, 0, true, "，不過我一次只澆一點點水，慢慢加就不會有過滿的問題，所以看起來還行！\r\n希望這株小黃金葛可以活得很健康！"));
            Text_contents.Add(new Text_content(42112, "奇怪", "happy", 50, 0, 0, 0, true, "吧？我想爸媽不會讓我嘗試園藝，我也沒看過我們家有任何植物出現。\r\n所以，我很期待這株小黃金葛可以長得更加茁壯。"));

            Text_contents.Add(new Text_content(4210, "搖頭", "none", 50, 0, 0, 0, true, "，阿姨好像很開心，還說今天就讓我負責澆水就好，澆完水就可以自由活動了。只要澆水就好嗎？突然減少的工作任務讓我有點"));
            Text_contents.Add(new Text_content(42210, "開心", "none", 50, 0, 0, 0, true, "，因為多了很多時間可以去看書了！\r\n我把澆水壺裝滿水，小心翼翼澆在植物上。我從來沒有照顧過植物，這很"));
            Text_contents.Add(new Text_content(42211, "彆扭", "happy", 50, 0, 0, 0, true, "，不過我一次只澆一點點水，慢慢加就不會有過滿的問題，所以看起來還行！\r\n希望這株小黃金葛可以活得很健康！"));
            Text_contents.Add(new Text_content(42212, "奇怪", "happy", 50, 0, 0, 0, true, "吧？我想爸媽不會讓我嘗試園藝，我也沒看過我們家有任何植物出現。\r\n所以，我很期待這株小黃金葛可以長得更加茁壯。"));

            Text_contents.Add(new Text_content(41120, "挫折", "none", 25, 5, 0, 0, true, "，是不是阿姨覺得我連普通的打掃工作都做得不好，才要我做這種易如反掌的事情呢……\r\n總之，這盆黃金葛看起來有點"));
            Text_contents.Add(new Text_content(41121, "玩具", "wow", 50, 0, 0, 0, true, "塑膠感，我摸了摸心型葉片，光光滑滑的觸覺好特別。\r\n\r\n後來我稍微查了一下資料，發現黃金葛的生命力其實很堅韌，真是意想不到。"));
            Text_contents.Add(new Text_content(41122, "愜意", "happy", 50, 0, 0, 0, true, "，只需要慵懶生長、生活也是自由自在，根本沒有任何煩惱，真好。"));


            //diary_music03
            Text_contents.Add(new Text_content(21, "小心翼翼", "none", 25, 5, 0, 0, true, ""));
            Text_contents.Add(new Text_content(2110, "療癒", "none", 50, 0, 0, 0, true, ""));
            Text_contents.Add(new Text_content(21110, "愜意", "happy", 50, 0, 0, 0, true, ""));
            Text_contents.Add(new Text_content(21120, "放鬆", "happy", 50, 0, 0, 0, true, ""));
            Text_contents.Add(new Text_content(2120, "浪漫", "none", 25, 5, 0, 0, true, ""));
            Text_contents.Add(new Text_content(21210, "通俗", "none", 50, 0, 0, 0, true, ""));
            Text_contents.Add(new Text_content(21220, "常見", "none", 50, 0, 0, 0, true, ""));

            Text_contents.Add(new Text_content(22, "詢問", "none", 25, 5, 0, 0, true, ""));
            Text_contents.Add(new Text_content(2210, "憤怒", "angry", 50, 0, 0, 0, true, ""));
            Text_contents.Add(new Text_content(2220, "面面相覷", "sad", 50, 0, 0, 0, true, ""));

            Text_contents.Add(new Text_content(23, "疲倦", "none", 50, 0, 0, 0, true, ""));
            Text_contents.Add(new Text_content(2310, "過敏", "wow", 25, 5, 0, 0, true, ""));
            Text_contents.Add(new Text_content(2320, "不適", "wow", 50, 0, 0, 0, true, ""));

            //diary_music03
            Text_contents.Add(new Text_content(21, "小心翼翼", "none", 25, 5, 0, 0, true, ""));
            Text_contents.Add(new Text_content(2110, "療癒", "none", 50, 0, 0, 0, true, ""));
            Text_contents.Add(new Text_content(21110, "愜意", "happy", 50, 0, 0, 0, true, ""));
            Text_contents.Add(new Text_content(21120, "放鬆", "happy", 50, 0, 0, 0, true, ""));
            Text_contents.Add(new Text_content(2120, "浪漫", "none", 25, 5, 0, 0, true, ""));
            Text_contents.Add(new Text_content(21210, "通俗", "none", 50, 0, 0, 0, true, ""));
            Text_contents.Add(new Text_content(21220, "常見", "none", 50, 0, 0, 0, true, ""));

            Text_contents.Add(new Text_content(22, "詢問", "none", 25, 5, 0, 0, true, ""));
            Text_contents.Add(new Text_content(2210, "憤怒", "angry", 50, 0, 0, 0, true, ""));
            Text_contents.Add(new Text_content(2220, "面面相覷", "sad", 50, 0, 0, 0, true, ""));

            Text_contents.Add(new Text_content(23, "疲倦", "none", 50, 0, 0, 0, true, ""));
            Text_contents.Add(new Text_content(2310, "過敏", "wow", 25, 5, 0, 0, true, ""));
            Text_contents.Add(new Text_content(2320, "不適", "wow", 50, 0, 0, 0, true, ""));
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
            print("+HP:" + falseTextContents[randomIndex].HP+ "+Atk:" + falseTextContents[randomIndex].Att_pow);
            Debug.Log($"Modified Text_content: Name_number: {falseTextContents[randomIndex].Name_number}, Name_Text: {falseTextContents[randomIndex].Name_Text}, MC_HP_Max: {static_parameters.MC_HP_Max}, MC_ATK: {static_parameters.MC_ATK}, MC_ATK_Speed: {static_parameters.MC_ATK_Speed}, MC_speed: {static_parameters.MC_Wspeed}, Text_exist: {falseTextContents[randomIndex].Text_exist}");
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
            static_parameters.MC_ATK += Att_pow;
            static_parameters.MC_ATK_Speed += Att_speed;
            static_parameters.MC_Wspeed += Walk_speed;
        }
    }
}
