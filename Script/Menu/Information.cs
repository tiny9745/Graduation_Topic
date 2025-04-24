using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Information : MonoBehaviour
{
    // Start is called before the first frame update
    int page = 0;
    public GameObject[] pages = new GameObject[7];
    public GameObject Left_arrow, Right_arrow;
    public GameObject Team_leader_A, Team_leader_B;
    public GameObject traditional_Chinese_painting_A, traditional_Chinese_painting_B;
    public GameObject Yanzhen_A, Yanzhen_B;
    public GameObject YO_A, YO_B;
    void Start()
    {

    }

    public void Left_arrow_click()
    {
        if (page > 0)
        {
            page--;
            arrow_change();
            page_change(page);
        }
    }
    public void Right_arrow_click()
    {
        if (page < 6)
        {
            page++;
            arrow_change();
            page_change(page);
        }
    }
    private void arrow_change()
    {
        if (page == 0)
        {
            Left_arrow.SetActive(false);
            Right_arrow.SetActive(true);
        }
        else if (page == 6)
        {
            Left_arrow.SetActive(true);
            Right_arrow.SetActive(false);
        }
        else
        {
            Left_arrow.SetActive(true);
            Right_arrow.SetActive(true);
        }
    }

    private void page_change(int page_number)
    {
        for (page_number = 0; page_number < pages.Length; page_number++)
        {
            if (page == page_number)
            {
                pages[page_number].SetActive(true);
            }
            else
            {
                pages[page_number].SetActive(false);
            }
        }
    }
    public void Go_back()
    {
        gameObject.SetActive(false);
        page = 0;
        page_change(page);
        arrow_change();
    }

    public void Team_leader_change()
    {
        if (Team_leader_A.activeSelf)
        {
            Team_leader_A.SetActive(false);
            Team_leader_B.SetActive(true);
        }
        else
        {
            Team_leader_A.SetActive(true);
            Team_leader_B.SetActive(false);
        }
    }
    public void traditional_Chinese_painting_change()
    {
        if (traditional_Chinese_painting_A.activeSelf)
        {
            traditional_Chinese_painting_A.SetActive(false);
            traditional_Chinese_painting_B.SetActive(true);
        }
        else
        {
            traditional_Chinese_painting_A.SetActive(true);
            traditional_Chinese_painting_B.SetActive(false);
        }
    }
    public void Yanzhen_change()
    {
        if (Yanzhen_A.activeSelf)
        {
            Yanzhen_A.SetActive(false);
            Yanzhen_B.SetActive(true);
        }
        else
        {
            Yanzhen_A.SetActive(true);
            Yanzhen_B.SetActive(false);
        }
    }
    public void YO_change()
    {
        if (YO_A.activeSelf)
        {
            YO_A.SetActive(false);
            YO_B.SetActive(true);
        }
        else
        {
            YO_A.SetActive(true);
            YO_B.SetActive(false);
        }
    }
}
