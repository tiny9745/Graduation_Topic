using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Book, Ppage, Check;
    public GameObject Diary_text_Left, Diary_text_Right;
    public Text Diary_Left_Text, Diary_Right_Text;
    public Drag_End drag_end;
    //public GameObject Yes;
    public static bool OC = true;
    public GameObject cpmplete_piece_object;
    public Animator complete_piece_animator;
    public Button composite_col;
    public DragPiece_End dragPiece_end;
    Diary_icon thisItem;
    void Start()
    {
        Diary_icon[] all_icon = Resources.LoadAll<Diary_icon>("icon_skill");
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void FinishDiary()
    {
        Ppage.SetActive(false);
        Check.SetActive(true);
    }

    public void comfirm()
    {
        Check.SetActive(false);
    }
    public void cancel()
    {
        Check.SetActive(false);
    }
    public void Yes_clear_dairy_text()
    {
        Diary_Left_Text.text = "";
        Diary_Right_Text.text = "";
    }
    public void Complet_piecing()
    {
        cpmplete_piece_object.SetActive(true);
        complete_piece_animator.SetInteger("piece_complete_color", DragPiece_End.puzzle_color);
        composite_col.enabled = false;
        dragPiece_end.Combination_End();
        switch (DragPiece_End.puzzle_color)
        {
            case 0://Blue

                break;
            case 1://Red

                break;
            case 2://Green

                break;
            case 3://Purple

                break;
            case 4://Yellow

                break;
            default:
                break;
        }
        thisItem = key_count();
        IconManager.Instance.Add(thisItem);
        Invoke("Complete_piece_after", 3.05f);
    }

    Diary_icon key_count()
    {
        
        return null;
    }




    private void Complete_piece_after()
    {
        cpmplete_piece_object.SetActive(false);
        complete_piece_animator.SetInteger("piece_complete_color", -1);
    }
}
