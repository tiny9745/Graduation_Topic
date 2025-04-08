using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class Drops : MonoBehaviour
{
    private UI _UI;
    private Ptest ptest;
    GameObject targetObject;
    UnityEngine.UI.Image diary_icon_Image;
    Animator Chest_Animator;
    int randomIndex,Add;
    bool isAni = false;
    public AudioSource Ad;
    public AudioClip[] Piece, money;
    void Start()
    {
        randomIndex = Random.Range(5, 9);
        if (static_parameters.isTeaching) randomIndex = 1;
        targetObject = GameObject.Find("UI");

        GameObject foundObj = GameObject.Find("note_book");
        if (foundObj != null)
        {
            diary_icon_Image = foundObj.GetComponent<UnityEngine.UI.Image>();
            if (diary_icon_Image == null)
            {
                Debug.LogWarning("Image component not found on note_book!");
            }
        }

        if (targetObject != null)
        {
            ptest = targetObject.GetComponent<Ptest>();
            if (ptest == null)
            {
                Debug.LogWarning("Ptest component not found on UI!");
            }
        }
        _UI = targetObject.GetComponent<UI>();
        Chest_Animator = GetComponent<Animator>();
        Chest_Animator.SetTrigger($"chest{randomIndex}");
    }

    private void Update()
    {
        StartCoroutine(Aniwait());
    }

    private IEnumerator Aniwait()
    {
        yield return new WaitUntil(() =>
        {
            AnimatorStateInfo stateInfo = Chest_Animator.GetCurrentAnimatorStateInfo(0);
            return stateInfo.IsName($"chest{randomIndex}") && stateInfo.normalizedTime >= 0.75f;
        });
        if (targetObject != null && isAni == false)
        {
            isAni = true;
            if (static_parameters.teaching_stop <= 6) static_parameters.teaching_stop = 7;
            ptest._to_Drop(randomIndex);
            switch (randomIndex)
            {
                case 5:
                    Ad.PlayOneShot(Piece[0]);
                    break;
                case 6:
                    Ad.PlayOneShot(Piece[1]);
                    break;
                case 7:
                    Ad.PlayOneShot(Piece[2]);
                    break;
                case 8:
                    Ad.PlayOneShot(Piece[3]);
                    break;
            }
            Add =Random.Range(25, 41);
            static_parameters.money += Add;
            if(Add > 33)
            {
                Ad.PlayOneShot(money[0]);

            }else{
                Ad.PlayOneShot(money[1]);
            }
            diary_icon_Image.color = new Color(1, 170f / 255f, 170f / 255f, 1);
            _UI.Loadmoney();
        }
        yield return new WaitForSeconds(0.25f);

        diary_icon_Image.color = new Color(1, 1, 1, 1);
        yield return new WaitForSeconds(0.4f);
        static_parameters.next_door = true;
        Destroy(gameObject);
    }
}
