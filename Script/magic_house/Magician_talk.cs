using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Magician_talk : MonoBehaviour
{
    public GameObject dialog_box;
    public Image Main_character_face, Magician_face;
    public Image Main_character_body, Magician_body;
    public Sprite[] Main_character_face_change;
    public Sprite[] Magician_face_change;
    public Text name_text, talk_text, Narration_text;
    static public int talk_number_M = 0;
    public int into_talk_step = 0;
    public UI_Place UI_place;
    int originalSize, smallerSize;
    // public Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        originalSize = talk_text.fontSize;
        smallerSize = originalSize / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && UI_place.isUpgrade && !Setting_keybroad.ESC_col)
        {
            Magician_Talk();
        }
    }

    public void Magician_Talk()
    {
        Debug.Log("talk_number = " + talk_number_M);
        Debug.Log("into_talk_step = " + into_talk_step);
        dialog_box.SetActive(true);
        if (talk_number_M == 0)
        {
            talk_number_0();
        }
        else if (talk_number_M == 1)
        {
            talk_number_1();
        }
        else if (talk_number_M == 2)
        {
            talk_number_2();
        }
        else
        {
            switch (talk_number_M)
            {
                case 3:
                    talk_number_3();
                    break;
                case 4:
                    talk_number_4();
                    break;
                case 5:
                    talk_number_5();
                    break;
                case 6:
                    talk_number_6();
                    break;
                case 7:
                    talk_number_7();
                    break;
                case 8:
                    talk_number_8();
                    break;
                case 9:
                    talk_number_9();
                    break;
                case 10:
                    talk_number_10();
                    break;
                case 11:
                    talk_number_11();
                    break;
                case 12:
                    talk_number_12();
                    break;
                case 13:
                    talk_number_13();
                    break;
                case 14:
                    talk_number_14();
                    break;
            }
        }
        into_talk_step++;
    }

    void talk_number_0()
    {
        switch (into_talk_step)
        {
            case 0:
                main_talk();
                Main_character_face.sprite = Main_character_face_change[0];
                Magician_face.sprite = Magician_face_change[0];
                name_text.text = "曦然";
                talk_text.text = "城堡怎麼去?";
                break;
            case 1:
                magic_talk();
                Main_character_face.sprite = Main_character_face_change[0];
                Magician_face.sprite = Magician_face_change[0];
                name_text.text = "莓莓";
                talk_text.text = "只要看著城堡的屋頂方向，一直走就會到囉。";
                break;
            default:
                talk_number_M++;
                open_level_up();
                break;
        }
    }
    void talk_number_1()
    {
        switch (into_talk_step)
        {
            case 0:
                main_talk();
                Main_character_face.sprite = Main_character_face_change[0];
                Magician_face.sprite = Magician_face_change[0];
                name_text.text = "曦然";
                talk_text.text = "妳剛剛說到了姜米，他是誰？";
                break;
            case 1:
                magic_talk();
                Magician_face.sprite = Magician_face_change[3];
                name_text.text = "莓莓";
                talk_text.text = "嗯……算是我的青梅竹馬吧，他是王宮的士兵長，雖然不善言辭，但對我很好。";
                break;
            case 2:
                main_talk();
                Main_character_face.sprite = Main_character_face_change[0];
                name_text.text = "曦然";
                talk_text.text = "那你的青梅竹馬怎麼會帶一堆士兵來抓你？";
                break;
            case 3:
                magic_talk();
                Magician_face.sprite = Magician_face_change[4];
                name_text.text = "莓莓";
                talk_text.text = "長話短說就是、呃、我不小心……";
                break;
            case 4:
                name_text.text = "莓莓";
                talk_text.text = "溜去王宮裡找姜米時炸了牆壁！所以才會被下令追捕吧！嗯！就是這樣！";
                break;
            case 5:
                main_talk();
                Main_character_face.sprite = Main_character_face_change[3];
                name_text.text = "曦然";
                talk_text.text = "呃，原來我剛剛是在幫忙罪犯……";
                break;
            case 6:
                magic_talk();
                Magician_face.sprite = Magician_face_change[2];
                name_text.text = "莓莓";
                talk_text.text = "我才不是罪犯咧！等一切結束，我會去向王后賠罪啦！";
                break;
            default:
                talk_number_M++;
                open_level_up();
                break;
        }
    }
    void talk_number_2()
    {
        switch (into_talk_step)
        {
            case 0:
                main_talk();
                Main_character_face.sprite = Main_character_face_change[3];
                Magician_face.sprite = Magician_face_change[0];
                name_text.text = "曦然";
                talk_text.text = "如果我在外面死掉了怎麼辦？";
                break;
            case 1:
                magic_talk();
                Magician_face.sprite = Magician_face_change[0];
                name_text.text = "莓莓";
                talk_text.text = "妳會立刻回到糖果屋再次重生，所以別擔心!";
                break;
            case 2:
                magic_talk();
                Magician_face.sprite = Magician_face_change[1];
                name_text.text = "莓莓";
                talk_text.text = "只不過會傳送到糖果屋的哪個地方就不一定了……啊哈哈……";
                break;
            default:
                talk_number_M++;
                open_level_up();
                break;
        }
    }
    void talk_number_3()
    {
        switch (into_talk_step)
        {
            case 0:
                magic_talk();
                Main_character_face.sprite = Main_character_face_change[0];
                Magician_face.sprite = Magician_face_change[2];
                name_text.text = "莓莓";
                talk_text.text = "……";
                break;
            case 1:
                main_talk();
                Main_character_face.sprite = Main_character_face_change[0];
                name_text.text = "曦然";
                talk_text.text = "怎麼了?";
                break;
            case 2:
                magic_talk();
                Magician_face.sprite = Magician_face_change[3];
                name_text.text = "莓莓";
                talk_text.text = "沒什麼，只是在想怎麼都連絡不到老師。";
                break;
            case 3:
                name_text.text = "莓莓";
                talk_text.text = "要是能找到他，就能問清楚如何把怪物復原的魔法了。";
                break;
            case 4:
                main_talk();
                Main_character_face.sprite = Main_character_face_change[0];
                name_text.text = "曦然";
                talk_text.text = "他很厲害嗎？";
                break;
            case 5:
                magic_talk();
                Magician_face.sprite = Magician_face_change[0];
                name_text.text = "莓莓";
                talk_text.text = "當然囉！我的魔法都是老師教的，而我也是老師最出色的學生！";
                break;
            case 6:
                main_talk();
                Main_character_face.sprite = Main_character_face_change[1];
                name_text.text = "曦然";
                talk_text.text = "那祝妳早日聯絡到他。";
                break;
            default:
                open_level_up();
                break;
        }
    }
    void talk_number_4()
    {
        switch (into_talk_step)
        {
            case 0:
                not_talk();
                Main_character_face.sprite = Main_character_face_change[0];
                Magician_face.sprite = Magician_face_change[0];
                name_text.text = "";
                talk_text.text = "角落區域擺了許多造型娃娃，大小也不一。";
                break;
            case 1:
                main_talk();
                Main_character_face.sprite = Main_character_face_change[1];
                name_text.text = "曦然";
                talk_text.text = "這裡真的有好多娃娃。";
                break;
            case 2:
                magic_talk();
                Magician_face.sprite = Magician_face_change[1];
                name_text.text = "莓莓";
                talk_text.text = "很療癒吧？全都是我蒐集來的寶貝喔！來，給妳抱一隻。";
                break;
            case 3:
                main_talk();
                Main_character_face.sprite = Main_character_face_change[1];
                name_text.text = "曦然";
                talk_text.text = "軟綿綿的……摸起來很舒服。";
                break;
            case 4:
                magic_talk();
                Magician_face.sprite = Magician_face_change[0];
                name_text.text = "莓莓";
                talk_text.text = "想要的話我也可以施魔法讓娃娃變成武器唷，怎麼樣，想換造型嗎？";
                break;
            case 5:
                main_talk();
                Main_character_face.sprite = Main_character_face_change[0];
                name_text.text = "曦然";
                talk_text.text = "那倒不必了。";
                break;
            case 6:
                magic_talk();
                Magician_face.sprite = Magician_face_change[0];
                name_text.text = "莓莓";
                talk_text.text = "真可惜，想換的時候再來跟我說吧！";
                break;
            default:
                open_level_up();
                break;
        }
    }
    void talk_number_5()
    {
        switch (into_talk_step)
        {
            case 0:
                main_talk();
                Main_character_face.sprite = Main_character_face_change[3];
                Magician_face.sprite = Magician_face_change[0];
                name_text.text = "曦然";
                talk_text.text = "桌子跟地上都好亂……";
                break;
            case 1:
                magic_talk();
                Magician_face.sprite = Magician_face_change[0];
                name_text.text = "莓莓";
                talk_text.text = "這是亂中有序！聰明人的書桌都長這樣！";
                break;
            case 2:
                main_talk();
                Main_character_face.sprite = Main_character_face_change[3];
                name_text.text = "曦然";
                talk_text.text = "不予置評。";
                break;
            case 3:
                magic_talk();
                Magician_face.sprite = Magician_face_change[2];
                name_text.text = "莓莓";
                talk_text.text = "別跟我說妳想把我的｢井然有序」給破壞掉！";
                break;
            case 4:
                main_talk();
                Main_character_face.sprite = Main_character_face_change[1];
                name_text.text = "曦然";
                talk_text.text = "我認為這是｢七零八落｣、｢參差不齊｣才對。";
                break;
            case 5:
                magic_talk();
                Magician_face.sprite = Magician_face_change[2];
                name_text.text = "莓莓";
                talk_text.text = "我不認同妳的認為！";
                break;
            default:
                open_level_up();
                break;
        }
    }
    void talk_number_6()
    {
        switch (into_talk_step)
        {
            case 0:
                not_talk();
                Main_character_face.sprite = Main_character_face_change[0];
                Magician_face.sprite = Magician_face_change[0];
                name_text.text = "";
                talk_text.text = "研究桌上擺滿了藥水瓶與材料。";
                break;
            case 1:
                main_talk();
                Main_character_face.sprite = Main_character_face_change[0];
                name_text.text = "曦然";
                talk_text.text = "這些藥水都有什麼功用呢？";
                break;
            case 2:
                magic_talk();
                Magician_face.sprite = Magician_face_change[0];
                name_text.text = "莓莓";
                talk_text.text = "哎呀，這是個好問題。那瓶藍色的是堅硬餅乾口味的防禦藥水！";
                break;
            case 3:
                name_text.text = "莓莓";
                talk_text.text = "紫色的是超甜蜜巧克力醬口味的速度藥水！";
                break;
            case 4:
                name_text.text = "莓莓";
                talk_text.text = "黃色的是肉桂蘋果捲口味的擊退藥水！";
                break;
            case 5:
                name_text.text = "莓莓";
                talk_text.text = "粉色的是草莓蛋糕口味的血量藥水！";
                break;
            case 6:
                name_text.text = "莓莓";
                talk_text.text = "紅色是仰望星空派口味的攻擊藥水！";
                break;
            case 7:
                main_talk();
                Main_character_face.sprite = Main_character_face_change[3];
                name_text.text = "曦然";
                talk_text.text = "怎麼好像有一個怪怪的……";
                break;
            case 8:
                magic_talk();
                Magician_face.sprite = Magician_face_change[1];
                name_text.text = "莓莓";
                talk_text.text = "怎麼會？我調配的藥水可是第一名的美味跟有用！";
                break;
            default:
                open_level_up();
                break;
        }
    }
    void talk_number_7()
    {
        switch (into_talk_step)
        {
            case 0:
                not_talk();
                Main_character_face.sprite = Main_character_face_change[0];
                Magician_face.sprite = Magician_face_change[0];
                name_text.text = "";
                talk_text.text = "安靜的屋子裡傳來好大的咕嚕叫聲。";
                break;
            case 1:
                magic_talk();
                Magician_face.sprite = Magician_face_change[3];
                name_text.text = "莓莓";
                talk_text.text = "肚子餓了啦～～～";
                break;
            case 2:
                main_talk();
                Main_character_face.sprite = Main_character_face_change[0];
                name_text.text = "曦然";
                talk_text.text = "魔法沒辦法直接變出食物來嗎？";
                break;
            case 3:
                magic_talk();
                Magician_face.sprite = Magician_face_change[3];
                name_text.text = "莓莓";
                talk_text.text = "我也希望能這樣呀，不過魔法可不能憑空變出東西來呢！";
                break;
            case 4:
                Magician_face.sprite = Magician_face_change[0];
                name_text.text = "莓莓";
                talk_text.text = "例如必須有雞蛋、麵粉、糖等材料才能用魔法直接變出蛋糕！";
                break;
            case 5:
                main_talk();
                Main_character_face.sprite = Main_character_face_change[0];
                name_text.text = "曦然";
                talk_text.text = "雖然沒有那些，不過我在櫃子裡找到一包開封過的餅乾跟糖粉，先墊肚子吧。";
                break;
            case 6:
                Magician_face.sprite = Magician_face_change[1];
                name_text.text = "莓莓";
                talk_text.text = "哎呀我都忘了！太好了我要吃爆加滿糖粉的餅乾！";
                break;
            default:
                open_level_up();
                break;
        }
    }
    void talk_number_8()
    {
        switch (into_talk_step)
        {
            case 0:
                not_talk();
                Main_character_face.sprite = Main_character_face_change[0];
                Magician_face.sprite = Magician_face_change[0];
                name_text.text = "";
                talk_text.text = "牆邊的書櫃與天花板同高，塞滿了各種書籍。";
                break;
            case 1:
                main_talk();
                Main_character_face.sprite = Main_character_face_change[1];
                name_text.text = "曦然";
                talk_text.text = "擁有滿牆藏書是我的夢想。";
                break;
            case 2:
                magic_talk();
                Magician_face.sprite = Magician_face_change[4];
                name_text.text = "莓莓";
                talk_text.text = "在家裡擺一牆書櫃真的很讚欸，我之後還想建一個只放書的糖果圖書館。";
                break;
            case 3:
                main_talk();
                Main_character_face.sprite = Main_character_face_change[1];
                name_text.text = "曦然";
                talk_text.text = "妳都喜歡什麼書呢？";
                break;
            case 4:
                magic_talk();
                Magician_face.sprite = Magician_face_change[0];
                name_text.text = "莓莓";
                talk_text.text = "除了魔法書以外，我最喜歡看小說了！越狗血越好！";
                break;
            case 5:
                main_talk();
                Main_character_face.sprite = Main_character_face_change[1];
                name_text.text = "曦然";
                talk_text.text = "有哪些推薦的呢？";
                break;
            case 6:
                magic_talk();
                Magician_face.sprite = Magician_face_change[0];
                name_text.text = "莓莓";
                talk_text.text = "《玫瑰禁忌》！男女主角互相喜歡卻被家族阻饒的故事！";
                break;
            case 7:
                Magician_face.sprite = Magician_face_change[1];
                name_text.text = "莓莓";
                talk_text.text = "總共三十五集，本本精彩，來，都借妳，讀完記得跟我說感想。";
                break;
            default:
                open_level_up();
                break;
        }
    }
    void talk_number_9()
    {
        switch (into_talk_step)
        {
            case 0:
                magic_talk();
                Main_character_face.sprite = Main_character_face_change[0];
                Magician_face.sprite = Magician_face_change[1];
                name_text.text = "莓莓";
                talk_text.text = "啊～～毛毛地毯，最柔軟最舒服，我好喜歡喔～～";
                break;
            case 1:
                main_talk();
                Main_character_face.sprite = Main_character_face_change[4];
                name_text.text = "曦然";
                talk_text.text = "躺在這不會著涼嗎？";
                break;
            case 2:
                magic_talk();
                Magician_face.sprite = Magician_face_change[0];
                name_text.text = "莓莓";
                talk_text.text = "才不會呢，毛毛地毯最溫暖了！要一起躺嗎？";
                break;
            case 3:
                main_talk();
                Main_character_face.sprite = Main_character_face_change[1];
                name_text.text = "曦然";
                talk_text.text = "……那我也試試。";
                break;
            case 4:
                magic_talk();
                Magician_face.sprite = Magician_face_change[1];
                name_text.text = "莓莓";
                talk_text.text = "所言不虛吧？";
                break;
            default:
                open_level_up();
                break;
        }
    }
    void talk_number_10()
    {
        switch (into_talk_step)
        {
            case 0:
                not_talk();
                Main_character_face.sprite = Main_character_face_change[0];
                Magician_face.sprite = Magician_face_change[0];
                name_text.text = "";
                talk_text.text = "牆壁上其中一幅長方形相框裡的小女孩長得酷似莓莓。";
                break;
            case 1:
                main_talk();
                Main_character_face.sprite = Main_character_face_change[0];
                name_text.text = "曦然";
                talk_text.text = "在看什麼？";
                break;
            case 2:
                magic_talk();
                Magician_face.sprite = Magician_face_change[4];
                name_text.text = "莓莓";
                talk_text.text = "嚇我一跳！沒什麼，就只是一些舊照片。";
                break;
            case 3:
                main_talk();
                Main_character_face.sprite = Main_character_face_change[0];
                name_text.text = "曦然";
                talk_text.text = "照片上的人……那個小女孩長得好像……";
                break;
            case 4:
                magic_talk();
                Magician_face.sprite = Magician_face_change[0];
                name_text.text = "莓莓";
                talk_text.text = "聽說是國王跟王后還有他們的女兒喔！";
                break;
            case 5:
                main_talk();
                Main_character_face.sprite = Main_character_face_change[0];
                name_text.text = "曦然";
                talk_text.text = $"原來如此。<size={smallerSize}>……看來是我的錯覺吧……</size>";
                break;
            default:
                open_level_up();
                break;
        }
    }
    void talk_number_11()
    {
        switch (into_talk_step)
        {
            case 0:
                not_talk();
                Main_character_face.sprite = Main_character_face_change[0];
                Magician_face.sprite = Magician_face_change[0];
                name_text.text = "";
                talk_text.text = "牆壁上其中一幅橢圓相框裡，放著莓莓和不知名女人的合照。";
                break;
            case 1:
                main_talk();
                Main_character_face.sprite = Main_character_face_change[0];
                name_text.text = "曦然";
                talk_text.text = "照片上的是妳跟誰?";
                break;
            case 2:
                magic_talk();
                Magician_face.sprite = Magician_face_change[1];
                name_text.text = "莓莓";
                talk_text.text = "這是我阿姨啦～當初是她鼓勵繼續鑽研魔法的唷！";
                break;
            case 3:
                main_talk();
                Main_character_face.sprite = Main_character_face_change[1];
                name_text.text = "曦然";
                talk_text.text = "是嗎？感覺她人真不錯。";
                break;
            case 4:
                magic_talk();
                Magician_face.sprite = Magician_face_change[0];
                name_text.text = "莓莓";
                talk_text.text = "雖然我媽很討厭她……不過我很喜歡我阿姨呢！";
                break;
            case 5:
                name_text.text = "莓莓";
                talk_text.text = "聽說她跑去異地歷險，到現在還沒回來呢，實在是太酷啦！";
                break;
            case 6:
                main_talk();
                Main_character_face.sprite = Main_character_face_change[1];
                name_text.text = "曦然";
                talk_text.text = "妳怎麼沒跟著一起去？";
                break;
            case 7:
                magic_talk();
                Magician_face.sprite = Magician_face_change[3];
                name_text.text = "莓莓";
                talk_text.text = "這說來話長，有機會我再跟妳說。";
                break;
            default:
                open_level_up();
                break;
        }
    }
    void talk_number_12()
    {
        switch (into_talk_step)
        {
            case 0:
                main_talk();
                Main_character_face.sprite = Main_character_face_change[0];
                Magician_face.sprite = Magician_face_change[0];
                name_text.text = "";
                talk_text.text = "莓莓露出了竊笑。";
                break;
            case 1:
                magic_talk();
                Main_character_face.sprite = Main_character_face_change[0];
                Magician_face.sprite = Magician_face_change[0];
                name_text.text = "莓莓";
                talk_text.text = "蘋果跟梨子比賽看誰先喊對方名字就輸了，妳猜誰贏？";
                break;
            case 2:
                main_talk();
                Main_character_face.sprite = Main_character_face_change[0];
                Magician_face.sprite = Magician_face_change[0];
                name_text.text = "曦然";
                talk_text.text = "唔……蘋果？";
                break;
            case 3:
                magic_talk();
                Main_character_face.sprite = Main_character_face_change[0];
                Magician_face.sprite = Magician_face_change[0];
                name_text.text = "莓莓";
                talk_text.text = "是梨子，因為蘋果答應時說了：｢來啊！｣哈哈哈哈哈！";
                break;
            case 4:
                main_talk();
                Main_character_face.sprite = Main_character_face_change[0];
                Magician_face.sprite = Magician_face_change[0];
                name_text.text = "曦然";
                talk_text.text = "……";
                break;
            default:
                open_level_up();
                break;
        }
    }
    void talk_number_13()
    {
        switch (into_talk_step)
        {
            case 0:
                magic_talk();
                Main_character_face.sprite = Main_character_face_change[0];
                Magician_face.sprite = Magician_face_change[4];
                name_text.text = "莓莓";
                talk_text.text = "不過妳都沒有一些以前的記憶嗎？想都想不起來？";
                break;
            case 1:
                main_talk();
                Main_character_face.sprite = Main_character_face_change[3];
                name_text.text = "曦然";
                talk_text.text = "嗯……只要用力去想，腦袋就感覺蒙上一層白霧一樣。";
                break;
            case 2:
                magic_talk();
                Magician_face.sprite = Magician_face_change[3];
                name_text.text = "莓莓";
                talk_text.text = "這還真是難辦……不過別擔心……因為我發明了這個……";
                break;
            case 3:
                magic_talk();
                Magician_face.sprite = Magician_face_change[0];
                name_text.text = "莓莓";
                talk_text.text = "腦霧驅散劑！";
                break;
            case 4:
                not_talk();
                name_text.text = "";
                talk_text.text = "莓莓的手裡拿著玻璃罐，裡面裝的液體看起來很糟糕。";
                break;
            case 5:
                magic_talk();
                Magician_face.sprite = Magician_face_change[1];
                name_text.text = "莓莓";
                talk_text.text = "怎麼樣？要不要喝看看？雖然是初版，不過我想應該不會有事？";
                break;
            case 6:
                main_talk();
                Main_character_face.sprite = Main_character_face_change[4];
                name_text.text = "曦然";
                talk_text.text = "不、不用了……我突然覺得腦袋清楚多了。";
                break;
            default:
                open_level_up();
                break;
        }
    }
    void talk_number_14()
    {
        switch (into_talk_step)
        {
            case 0:
                not_talk();
                Main_character_face.sprite = Main_character_face_change[0];
                Magician_face.sprite = Magician_face_change[0];
                name_text.text = "";
                talk_text.text = "莓莓的手上拿著一台相機。";
                break;
            case 1:
                magic_talk();
                Magician_face.sprite = Magician_face_change[0];
                name_text.text = "莓莓";
                talk_text.text = "我從櫃子裡找到了魔法相機！要不要跟我合照一張？";
                break;
            case 2:
                main_talk();
                Main_character_face.sprite = Main_character_face_change[3];
                name_text.text = "曦然";
                talk_text.text = "可是我……我不習慣……";
                break;
            case 3:
                magic_talk();
                Magician_face.sprite = Magician_face_change[1];
                name_text.text = "莓莓";
                talk_text.text = "微笑，三二一～喀擦！";
                break;
            case 4:
                main_talk();
                Main_character_face.sprite = Main_character_face_change[2];
                name_text.text = "曦然";
                talk_text.text = "耶。";
                break;
            case 5:
                not_talk();
                name_text.text = "";
                talk_text.text = "曦然試圖露出笑容。";
                break;
            case 6:
                magic_talk();
                Magician_face.sprite = Magician_face_change[4];
                name_text.text = "莓莓";
                talk_text.text = "……我是說微笑，不是皺眉頭。";
                break;
            default:
                open_level_up();
                break;
        }
    }

    void magic_talk()
    {
        Main_character_face.color = new Color(0.5f, 0.5f, 0.5f, 1);
        Magician_face.color = new Color(1, 1, 1, 1);
        Main_character_body.color = new Color(0.5f, 0.5f, 0.5f, 1);
        Magician_body.color = new Color(1, 1, 1, 1);
    }
    void main_talk()
    {
        Main_character_face.color = new Color(1, 1, 1, 1);
        Magician_face.color = new Color(0.5f, 0.5f, 0.5f, 1);
        Main_character_body.color = new Color(1, 1, 1, 1);
        Magician_body.color = new Color(0.5f, 0.5f, 0.5f, 1);
    }
    void not_talk()
    {
        Main_character_face.color = new Color(0.5f, 0.5f, 0.5f, 1);
        Magician_face.color = new Color(0.5f, 0.5f, 0.5f, 1);
        Main_character_body.color = new Color(0.5f, 0.5f, 0.5f, 1);
        Magician_body.color = new Color(0.5f, 0.5f, 0.5f, 1);
    }

    void open_level_up()
    {
        UI_place.UI1();
        close_magician_talk();
    }
    public void close_magician_talk()
    {
        into_talk_step = 0;
        this.gameObject.SetActive(false);
    }
}
