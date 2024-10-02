using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class Auto_text_paper : MonoBehaviour
{
    public string mood; // Preset child elements
    public GameObject itemPrefab, itemPanel, ExtraPage2;
    public Text ExtraPage2_text;
    public float[][] diary_buff_check;
    string[] diary_buff_name;
    public Text Pick_Text, ALLB;
    public Text[] diary_name;
    public Drag_End drag_end;
    public Change_mood change_mood;
    public int Diary_serial_number;
    int temp = 0;

    void Start()
    {
        diary_buff_check = new float[5][];
        for (int i = 0; i < diary_buff_check.Length; i++)
        {
            diary_buff_check[i] = new float[4];
        }
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                diary_buff_check[i][j] = 0;
            }
        }
        diary_buff_name = new string[4];
        for (int i = 0; i < diary_buff_name.Length; i++)
        {
            diary_buff_name[i] = "";
        }
        GenerateItems();
    }

    private void GenerateItems()
    {
        del_any_text();
        if (Text_Array.Text_contents != null)
        {
            foreach (Text_content content in Text_Array.Text_contents)
            {
                if (content.Text_exist)
                {
                    GameObject item = null;
                    if (Text_Array.diary_step[0] == 0 && content.Name_number < 100)
                    {
                        item = Instantiate(itemPrefab, itemPanel.transform);
                    }
                    else if (Text_Array.diary_step[0] == 1 && content.Name_number > 1000 && content.Name_number < 10000)
                    {
                        item = Instantiate(itemPrefab, itemPanel.transform);
                    }
                    else if (Text_Array.diary_step[0] == 2 && content.Name_number > 10000)
                    {
                        item = Instantiate(itemPrefab, itemPanel.transform);
                    }
                    else if (Text_Array.diary_step[0] == -1)
                    {
                        item = Instantiate(itemPrefab, itemPanel.transform);
                    }

                    if (item != null)
                    {
                        item.name = content.Name_number.ToString();
                        item.GetComponentInChildren<Text>().text = content.Name_Text;
                        SetCanvasSortingOrder(item);
                    }
                }
            }
        }
        else
        {
            Debug.LogError("Text_Array.Text_contents is null");
        }
    }

    public void diary_text_chose(int item)
    {
        del_any_text();
        if (Text_Array.Text_contents != null)
        {
            foreach (Text_content content in Text_Array.Text_contents)
            {
                if (content.Text_exist)
                {
                    switch (item)
                    {
                        case 11:
                            if (content.Name_number < 1200 && content.Name_number > 1100)
                            {
                                GameObject item2 = Instantiate(itemPrefab, itemPanel.transform);
                                item2.name = content.Name_number.ToString();
                                item2.GetComponentInChildren<Text>().text = content.Name_Text;
                                item2.name = content.Name_number.ToString();
                                item2.GetComponentInChildren<Text>().text = content.Name_Text;
                                SetCanvasSortingOrder(item2);
                            }
                            break;
                        case 12:
                            if (content.Name_number < 1300 && content.Name_number > 1200)
                            {
                                GameObject item2 = Instantiate(itemPrefab, itemPanel.transform);
                                item2.name = content.Name_number.ToString();
                                item2.GetComponentInChildren<Text>().text = content.Name_Text;
                                item2.name = content.Name_number.ToString();
                                item2.GetComponentInChildren<Text>().text = content.Name_Text;
                                item2.name = content.Name_number.ToString();
                                item2.GetComponentInChildren<Text>().text = content.Name_Text;
                                SetCanvasSortingOrder(item2);
                            }
                            break;
                        case 13:
                            if (content.Name_number < 1400 && content.Name_number > 1300)
                            {
                                GameObject item2 = Instantiate(itemPrefab, itemPanel.transform);
                                item2.name = content.Name_number.ToString();
                                item2.GetComponentInChildren<Text>().text = content.Name_Text;
                                item2.name = content.Name_number.ToString();
                                item2.GetComponentInChildren<Text>().text = content.Name_Text;
                                SetCanvasSortingOrder(item2);
                            }
                            break;
                        case 1310:
                            if (content.Name_number < 13200 && content.Name_number > 13100)
                            {
                                GameObject item2 = Instantiate(itemPrefab, itemPanel.transform);
                                item2.name = content.Name_number.ToString();
                                item2.GetComponentInChildren<Text>().text = content.Name_Text;
                                item2.name = content.Name_number.ToString();
                                item2.GetComponentInChildren<Text>().text = content.Name_Text;
                                SetCanvasSortingOrder(item2);
                            }
                            break;
                        case 1320:
                            if (content.Name_number < 13300 && content.Name_number > 13200)
                            {
                                GameObject item2 = Instantiate(itemPrefab, itemPanel.transform);
                                item2.name = content.Name_number.ToString();
                                item2.GetComponentInChildren<Text>().text = content.Name_Text;
                                item2.name = content.Name_number.ToString();
                                item2.GetComponentInChildren<Text>().text = content.Name_Text;
                                SetCanvasSortingOrder(item2);
                            }
                            break;
                        case 1330:
                            if (content.Name_number < 13400 && content.Name_number > 13300)
                            {
                                GameObject item2 = Instantiate(itemPrefab, itemPanel.transform);
                                item2.name = content.Name_number.ToString();
                                item2.GetComponentInChildren<Text>().text = content.Name_Text;
                                item2.name = content.Name_number.ToString();
                                item2.GetComponentInChildren<Text>().text = content.Name_Text;
                                SetCanvasSortingOrder(item2);
                            }
                            break;
                    }
                    if (item == content.Name_number)
                    {
                        diary_buff_check[0][0] += content.HP;
                        diary_buff_check[0][1] += content.Att_pow;
                        diary_buff_check[0][2] += content.Att_speed;
                        diary_buff_check[0][3] += content.Walk_speed;
                        if (content.Feeling != "None")
                        {
                            mood = content.Feeling;
                            Diary_serial_number = item;
                            extraPage2_open_check();
                        }
                    }
                }
            }
        }
    }

    void SetCanvasSortingOrder(GameObject item)// Set sorting order of the Canvas component
    {
        Canvas canvas = item.GetComponent<Canvas>();
        if (canvas == null)
        {
            canvas = item.AddComponent<Canvas>();
            item.AddComponent<GraphicRaycaster>();
        }
        canvas.overrideSorting = true;
        canvas.sortingOrder = 2; // Set the sorting order to 2
    }

    private void extraPage2_open_check()
    {
        ExtraPage2_text.text = "";
        Text_Array.diary_step[0] = -1;
        ExtraPage2.SetActive(true);
        del_any_text();
        ExtraPage2_text.text += "HP:+";
        ExtraPage2_text.text += diary_buff_check[0][0].ToString() + "\r\n";
        ExtraPage2_text.text += "ATK_Pow:+";
        ExtraPage2_text.text += diary_buff_check[0][1].ToString() + "\r\n";
        ExtraPage2_text.text += "ATK_Speed:+";
        ExtraPage2_text.text += diary_buff_check[0][2].ToString() + "\r\n";
        ExtraPage2_text.text += "Walk_Speed:+";
        ExtraPage2_text.text += diary_buff_check[0][3].ToString() + "\r\n";
    }

    private void del_any_text()
    {
        Queue<Transform> children = new Queue<Transform>();
        // Add all child objects to the queue
        foreach (Transform child in transform)
        {
            children.Enqueue(child);
        }
        // Destroy each child object in the queue
        while (children.Count > 0)
        {
            Transform child = children.Dequeue();
            Destroy(child.gameObject);
        }
    }

    public void ExtraPage2_Yes()
    {
        diary_buff_name[0] = ExtraPage2_text.text;
        if (Text_Array.diary_number == 0)
        {
            Pick_Text.text = "新讀的小說";
        }
        else if (Text_Array.diary_number >= 1)
        {
            Pick_Text.text = "其他的小說";
        }
    }

    public void click_D1()
    {
        ALLB.text = diary_buff_name[0];
    }
    public void click_D2()
    {
        ALLB.text = diary_buff_name[1];
    }

    public void ExtraPage2_No()
    {
        ExtraPage2.SetActive(false);
        Text_Array.diary_step[temp] = 0;
        GenerateItems();
    }
    public void Confirm()
    {
        change_mood.Change(mood);
        if (mood == "Happy") {
            Skill_public_funtion.feel_to_skill = 0;
        }
        else if (mood == "Angry"){
            Skill_public_funtion.feel_to_skill = 1;
        }
        else if (mood == "Sad"){
            Skill_public_funtion.feel_to_skill = 2;
        }
        else if (mood == "Wow"){
            Skill_public_funtion.feel_to_skill = 3;
        }
        else{
            Skill_public_funtion.feel_to_skill = -1;
        }
    }
}

