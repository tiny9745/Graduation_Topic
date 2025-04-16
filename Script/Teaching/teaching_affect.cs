using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class teaching_affect : MonoBehaviour
{
    int number = 1;
    public Image Affect_teaching;
    public Image[] handle_teaching;
    public Sprite[] Affect_teaching_image;

    void Start()
    {
        Time.timeScale = 0;
        number = 1;
        Affect_teaching.sprite = Affect_teaching_image[0];
        handle_teaching[0].color = new Color(1, 160 / 255f, 200 / 255f, 1);
        handle_teaching[1].color = new Color(1, 1, 1, 1);
        handle_teaching[2].color = new Color(1, 1, 1, 1);
        handle_teaching[3].color = new Color(1, 1, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            affect_teaching();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            number--;
            switch (number)
            {
                case 1:
                    handle_teaching_1();
                    break;
                case 2:
                    handle_teaching_2();
                    break;
                case 3:
                    handle_teaching_3();
                    break;
                case 4:
                    handle_teaching_4();
                    break;
                case 5:
                    Time.timeScale = 1;
                    this.gameObject.SetActive(false);
                    break;
            }
        }
    }

    public void affect_teaching()
    {
        number++;
        switch (number)
        {
            case 1:
                handle_teaching_1();
                break;
            case 2:
                handle_teaching_2();
                break;
            case 3:
                handle_teaching_3();
                break;
            case 4:
                handle_teaching_4();
                break;
            case 5:
                static_parameters.isTeaching = false;
                Time.timeScale = 1;
                this.gameObject.SetActive(false);
                break;
        }
    }

    public void handle_teaching_1()
    {
        number = 1;
        Affect_teaching.sprite = Affect_teaching_image[0];
        handle_teaching[0].color = new Color(1, 160 / 255f, 200 / 255f, 1);
        handle_teaching[1].color = new Color(1, 1, 1, 1);
        handle_teaching[2].color = new Color(1, 1, 1, 1);
        handle_teaching[3].color = new Color(1, 1, 1, 1);
    }
    public void handle_teaching_2()
    {
        number = 2;
        Affect_teaching.sprite = Affect_teaching_image[1];
        handle_teaching[0].color = new Color(1, 1, 1, 1);
        handle_teaching[1].color = new Color(1, 160 / 255f, 200 / 255f, 1);
        handle_teaching[2].color = new Color(1, 1, 1, 1);
        handle_teaching[3].color = new Color(1, 1, 1, 1);
    }
    public void handle_teaching_3()
    {
        number = 3;
        Affect_teaching.sprite = Affect_teaching_image[2];
        handle_teaching[0].color = new Color(1, 1, 1, 1);
        handle_teaching[1].color = new Color(1, 1, 1, 1);
        handle_teaching[2].color = new Color(1, 160 / 255f, 200 / 255f, 1);
        handle_teaching[3].color = new Color(1, 1, 1, 1);
    }
    public void handle_teaching_4()
    {
        number = 4;
        Affect_teaching.sprite = Affect_teaching_image[3];
        handle_teaching[0].color = new Color(1, 1, 1, 1);
        handle_teaching[1].color = new Color(1, 1, 1, 1);
        handle_teaching[2].color = new Color(1, 1, 1, 1);
        handle_teaching[3].color = new Color(1, 160 / 255f, 200 / 255f, 1);
    }
}
