using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UI : MonoBehaviour
{
    public short Diarystatus = 0;
    public Change_mood C_mood; public Ptest piece; public DragPiece_End dragPiece_End;
    public GameObject Notebook, BattleUI, Diaryslots, Diarytext;
    public GameObject Menu, CH1, CH2, CH3, CH4;
    public GameObject BookMark1, BookMark2, BookMark3, BookMark4;
    public GameObject LeftMark1, LeftMark2, LeftMark3, LeftMark4;
    public GameObject TeachiUI, NotebookUI;
    private Color newColor = new Color(1, 1, 1, 0f);
    public Text money;
    public Outline money_outline;
    public DragPiece_End dragPiece_end;
    public Image button_image, craft_image;
    public Sprite craft_sprite;
    public Button Pageup, Pagedown;
    public AudioClip Open, Close;
    public AudioSource Ad;

    public GameObject compass, compass_tips;
    public Text compass_text;
    public Transform compass_tip_in;
    private GameObject targetObject;
    // Start is called before the first frame update
    void Start()
    {
        targetObject = GameObject.Find("Player_S");
        StartCoroutine(RepeatTask());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && DragPiece_End.puzzle_color != -1)
        {
            openclose();
            C_mood.Change();
        }
        if (SceneManager.GetActiveScene().name == "magic_house")
        {
            TeachiUI.SetActive(true);
        }
    }

    private IEnumerator RepeatTask()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.2f);
            compass_col();
        }
    }
    public void Onclick1()
    {
        Diarystatus = 1;
        changechapter();
    }
    public void Onclick2()
    {
        Diarystatus = 2;
        changechapter();
    }
    public void Onclick3()
    {
        Diarystatus = 3;
        changechapter();
    }
    public void Onclick4()
    {
        Diarystatus = 4;
        changechapter();
    }
    public void openclose()
    {
        if (static_parameters.teaching_stop == 6)
        {
            static_parameters.teaching_stop = 7;
            static_parameters.Bookstate = true;
            Notebook.SetActive(true);
            BattleUI.SetActive(false);
            Ad.PlayOneShot(Open);
        }
        if (static_parameters.isTeaching == false && static_parameters.teaching_stop >= 100 && (static_parameters.into_gameFight == false || static_parameters.Change_enemy == 0))
        {
            if (static_parameters.Bookstate)
            {
                // Time.timeScale = 1;
                static_parameters.Bookstate = false;
                Notebook.SetActive(false);
                BattleUI.SetActive(true);
                dragPiece_End.ResetCombination();
                Ad.PlayOneShot(Close);
            }
            else
            {
                // Time.timeScale = 0;
                static_parameters.Bookstate = true;
                Notebook.SetActive(true);
                BattleUI.SetActive(false);
            }
        }
        else if (static_parameters.isTeaching == true && static_parameters.teaching_stop >= 100 && (static_parameters.into_gameFight == false || static_parameters.Change_enemy == 0))
        {
            if (!static_parameters.Bookstate)
            {
                // Time.timeScale = 0;
                static_parameters.Bookstate = true;
                Notebook.SetActive(true);
                BattleUI.SetActive(false);
                Ad.PlayOneShot(Open);
            }
            else
            {
                // Time.timeScale = 1;
                static_parameters.Bookstate = false;
                Notebook.SetActive(false);
                BattleUI.SetActive(true);
                dragPiece_End.ResetCombination();
                Ad.PlayOneShot(Close);
            }
        }
    }
    public void openclose_false()
    {
        Debug.Log("openclose_false");
        static_parameters.Bookstate = false;
        Notebook.SetActive(false);
        BattleUI.SetActive(true);
        dragPiece_End.ResetCombination();
    }

    void piecechange()
    {
        switch (Diarystatus)
        {
            case 1:
                piece.way = 6;
                break;
            default:
                piece.way = 0;
                break;
        }
        piece.page = 0;
        piece.ShowPieces();
    }
    void changechapter()
    {
        switch (Diarystatus)
        {
            case 1:
                dragPiece_End.ResetCombination();
                Menu.SetActive(false); CH1.SetActive(true); CH2.SetActive(false); CH3.SetActive(false); CH4.SetActive(false);
                BookMark1.SetActive(false); BookMark2.SetActive(true); BookMark3.SetActive(true); BookMark4.SetActive(true);
                LeftMark1.SetActive(false); LeftMark2.SetActive(false); LeftMark3.SetActive(false); LeftMark4.SetActive(false);
                break;
            case 2:
                Menu.SetActive(false); CH1.SetActive(false); CH2.SetActive(true); CH3.SetActive(false); CH4.SetActive(false);
                BookMark1.SetActive(false); BookMark2.SetActive(false); BookMark3.SetActive(true); BookMark4.SetActive(true);
                LeftMark1.SetActive(true); LeftMark2.SetActive(false); LeftMark3.SetActive(false); LeftMark4.SetActive(false);
                break;
            case 3:
                dragPiece_End.ResetCombination();
                Menu.SetActive(false); CH1.SetActive(false); CH2.SetActive(false); CH3.SetActive(true); CH4.SetActive(false);
                BookMark1.SetActive(false); BookMark2.SetActive(false); BookMark3.SetActive(false); BookMark4.SetActive(true);
                LeftMark1.SetActive(true); LeftMark2.SetActive(true); LeftMark3.SetActive(false); LeftMark4.SetActive(false);
                break;
            case 4:
                dragPiece_End.ResetCombination();
                Menu.SetActive(false); CH1.SetActive(false); CH2.SetActive(false); CH3.SetActive(false); CH4.SetActive(true);
                BookMark1.SetActive(false); BookMark2.SetActive(false); BookMark3.SetActive(false); BookMark4.SetActive(false);
                LeftMark1.SetActive(true); LeftMark2.SetActive(true); LeftMark3.SetActive(true); LeftMark4.SetActive(false);
                break;
        }
        piecechange();
        Ad.PlayOneShot(Open);
        Diaryslots.SetActive(true); Diarytext.SetActive(false); Skill_public_funtion.Reading = false;
        button_image.color = newColor;
        craft_image.sprite = craft_sprite;
    }
    public void Loadmoney()
    {
        StartCoroutine(money_color());
    }

    private IEnumerator money_color()
    {
        money_outline.effectColor = new Color(95f / 255f, 99f / 255f, 238f / 255f, 1f);
        money.text = static_parameters.money.ToString();
        yield return new WaitForSeconds(0.5f);
        money_outline.effectColor = new Color(1, 1, 1, 1f);
    }

    public bool putting_diary(bool isopen)
    {
        if (isopen)
        {
            Pagedown.enabled = true;
            Pageup.enabled = true;
            return true;
        }
        else
        {
            Pagedown.enabled = false;
            Pageup.enabled = false;
            return false;
        }
    }
    private void compass_col()
    {
        if (static_parameters.into_gameFight && static_parameters.stage_number < 5)
        {
            compass.SetActive(true);
            compass_text.text = "怪物剩餘數量：" + static_parameters.Change_enemy.ToString();
            if (static_parameters.Change_enemy <= 7 && static_parameters.Change_enemy > 0)
            {
                compass_text.color = new Color(238 / 255f, 90 / 255f, 108 / 255f, 1);
                compass_tips.SetActive(true);
                if (targetObject != null)
                {
                    float angle_NPC = FindNearestNPCAngle();
                    compass_tip_in.localEulerAngles = new Vector3(0, 0, -angle_NPC);
                }
            }
            if (static_parameters.Change_enemy == 0)
            {
                compass_text.color = new Color(0, 0, 0, 1);
                compass_tips.SetActive(false);
                compass.SetActive(false);
            }
        }
        else
        {
            compass_text.color = new Color(0, 0, 0, 1);
            compass_tips.SetActive(false);
            compass.SetActive(false);
        }
    }

    public float FindNearestNPCAngle()
    {
        GameObject[] npcs = GameObject.FindGameObjectsWithTag("NPC");
        GameObject nearestNPC = null;
        float shortestDistance = Mathf.Infinity;

        foreach (GameObject npc in npcs)
        {
            float distance = Vector3.Distance(targetObject.transform.position, npc.transform.position); // <--- 這裡改成自己的 transform
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                nearestNPC = npc;
            }
        }

        if (nearestNPC != null)
        {
            Vector3 directionToNPC = (nearestNPC.transform.position - targetObject.transform.position).normalized;
            float angle = Vector3.SignedAngle(transform.forward, directionToNPC, Vector3.up);

            // 把結果從 -180~180 轉成 0~360 比較好理解
            if (angle < 0)
                angle += 360f;

            return angle;
        }
        return -1;
    }
}
