using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Book, Ppage, Check;
    public static bool OC = true;
    public GameObject cpmplete_piece_object;
    public Animator complete_piece_animator;
    public Button composite_col;
    public DragPiece_End dragPiece_end;
    public UI UI;
    Diary_icon thisItem;
    public AudioSource audioSource; // 音效來源
    public AudioClip[] audioClip; // 音效片段
    void Start()
    {
        Diary_icon[] all_icon = Resources.LoadAll<Diary_icon>("icon_skill");
        // complete_piece_animator.updateMode = AnimatorUpdateMode.UnscaledTime;
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
    public void Complet_piecing()
    {
        audioSource.PlayOneShot(audioClip[0]);
        cpmplete_piece_object.SetActive(true);
        complete_piece_animator.SetInteger("piece_complete_color", DragPiece_End.puzzle_color);
        composite_col.enabled = false;
        thisItem = key_count();

        dragPiece_end.Combination_End();
        // IconManager.Instance.Add(thisItem);
        StartCoroutine(DelayedAction(3f));
    }
    IEnumerator DelayedAction(float delayInSeconds)
    {
        yield return new WaitForSeconds(delayInSeconds);
        Complete_piece_after();
    }

    Diary_icon key_count()
    {
        if (DragPiece_End.end_count < 10 && DragPiece_End.end_count > 0)//1~9
        {
            return Resources.Load<Diary_icon>("icon_skill/Green");
        }
        else if (DragPiece_End.end_count < 20)//10~19
        {
            return Resources.Load<Diary_icon>("icon_skill/Red");
        }
        else if (DragPiece_End.end_count < 30)//20~29
        {
            return Resources.Load<Diary_icon>("icon_skill/Blue");
        }
        else if (DragPiece_End.end_count < 40)//30~39
        {
            return Resources.Load<Diary_icon>("icon_skill/Purple");
        }
        else if (DragPiece_End.end_count < 50)//40~49
        {
            return Resources.Load<Diary_icon>("icon_skill/Yellow");
        }
        return null;
    }
    private void Complete_piece_after()
    {
        UI.Onclick3();
        switch (Skill_public_funtion.mood_number)
        {
            case 0:
                Skill_public_funtion.WOW += 1;
                break;
            case 1:
                Skill_public_funtion.ANGRY += 1;
                break;
            case 2:
                Skill_public_funtion.SAD += 1;
                break;
            case 4:
                Skill_public_funtion.HAPPY += 1;
                break;
            case 3:
                Skill_public_funtion.PAIN += 1;
                break;
            default:
                break;
        }
        IconManager.Instance.Addicon(DragPiece_End.end_count);
        cpmplete_piece_object.SetActive(false);
        complete_piece_animator.SetInteger("piece_complete_color", -1);
    }
}
