using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Auto_text_paper : MonoBehaviour
{
    public GameObject itemPrefab; // Preset child elements
    public GameObject itemPanel;
    public GameObject ExtraPage2;
    public Text ExtraPage2_text;
    public float[][] diary_buff_check;
    string[] diary_buff_name;
    public Text[] diary_name;
    public Text ALLB;
    int temp = 0;

    void Start()
    {
        diary_buff_check = new float[5][];
        for (int i = 0; i < diary_buff_check.Length; i++)
        {
            diary_buff_check[i] = new float[4];
        }
        for(int i = 0;i < 5; i++)
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
                    if (Text_Array.diary_step[0] == 0 && content.Name_number < 100) // diary_step=0 is <100
                    {
                        GameObject item = Instantiate(itemPrefab, itemPanel.transform);
                        item.name = content.Name_number.ToString();
                        item.GetComponentInChildren<Text>().text = content.Name_Text;
                    }
                    else if (Text_Array.diary_step[0] == 1 && content.Name_number > 1000 && content.Name_number < 10000) // diary_step=1 is >1000 & <10000
                    {
                        GameObject item = Instantiate(itemPrefab, itemPanel.transform);
                        item.name = content.Name_number.ToString();
                        item.GetComponentInChildren<Text>().text = content.Name_Text;
                    }
                    else if (Text_Array.diary_step[0] == 2 && content.Name_number > 10000) // diary_step=2 is >10000
                    {
                        GameObject item = Instantiate(itemPrefab, itemPanel.transform);
                        item.name = content.Name_number.ToString();
                        item.GetComponentInChildren<Text>().text = content.Name_Text;
                    }
                    else if (Text_Array.diary_step[0] == -1) // diary_step=2 is >10000
                    {
                        GameObject item = Instantiate(itemPrefab, itemPanel.transform);
                        item.name = content.Name_number.ToString();
                        item.GetComponentInChildren<Text>().text = content.Name_Text;
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
                    if (item == 11)
                    {
                        if (content.Text_exist && content.Name_number < 1200 && content.Name_number > 1100)
                        {
                            GameObject item2 = Instantiate(itemPrefab, itemPanel.transform);
                            item2.name = content.Name_number.ToString();
                            item2.GetComponentInChildren<Text>().text = content.Name_Text;
                        }
                    }
                    else if (item == 12)
                    {
                        if (content.Text_exist && content.Name_number < 1300 && content.Name_number > 1200)
                        {
                            GameObject item2 = Instantiate(itemPrefab, itemPanel.transform);
                            item2.name = content.Name_number.ToString();
                            item2.GetComponentInChildren<Text>().text = content.Name_Text;
                        }
                    }
                    else if (item == 13)
                    {
                        if (content.Text_exist && content.Name_number < 1400 && content.Name_number > 1300)
                        {
                            GameObject item2 = Instantiate(itemPrefab, itemPanel.transform);
                            item2.name = content.Name_number.ToString();
                            item2.GetComponentInChildren<Text>().text = content.Name_Text;
                        }
                    }
                    else if (item == 1310)
                    {
                        if (content.Text_exist && content.Name_number < 13200 && content.Name_number > 13100)
                        {
                            GameObject item2 = Instantiate(itemPrefab, itemPanel.transform);
                            item2.name = content.Name_number.ToString();
                            item2.GetComponentInChildren<Text>().text = content.Name_Text;
                        }
                    }
                    else if (item == 1320)
                    {
                        if (content.Text_exist && content.Name_number < 13300 && content.Name_number > 13200)
                        {
                            GameObject item2 = Instantiate(itemPrefab, itemPanel.transform);
                            item2.name = content.Name_number.ToString();
                            item2.GetComponentInChildren<Text>().text = content.Name_Text;
                        }
                    }
                    else if (item == 1330)
                    {
                        if (content.Text_exist && content.Name_number < 13400 && content.Name_number > 13300)
                        {
                            GameObject item2 = Instantiate(itemPrefab, itemPanel.transform);
                            item2.name = content.Name_number.ToString();
                            item2.GetComponentInChildren<Text>().text = content.Name_Text;
                        }
                    }
                    if (item == content.Name_number)
                    {
                        diary_buff_check[0][0] += content.HP;
                        diary_buff_check[0][1] += content.Att_pow;
                        diary_buff_check[0][2] += content.Att_speed;
                        diary_buff_check[0][3] += content.Walk_speed;
                    }
                }
            }
        }

        if (Text_Array.diary_step[0] == 2 && item > 1000 && item < 1300)
        {
            extraPage2_open_check();

        }
        else if (Text_Array.diary_step[0] == 3 && item > 1300 && item < 1400)
        {
            extraPage2_open_check();
        }
    }

    private void extraPage2_open_check()
    {
        ExtraPage2_text.text = "";
        Text_Array.diary_step[0] = -1;
        ExtraPage2.SetActive(true);
        del_any_text();
        ExtraPage2_text.text += "HP:+";
        ExtraPage2_text.text += diary_buff_check[0][0].ToString()+ "\r\n";
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
}

