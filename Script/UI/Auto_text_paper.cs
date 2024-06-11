using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class Auto_text_paper : MonoBehaviour
{
    public GameObject itemPrefab; // Preset child elements
    public GameObject itemPanel;

    void Start()
    {
        GenerateItems(); // generate objects
    }

    public void GenerateItems()
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
                }
            }
        }

        if (Text_Array.diary_step[0] == 2 && item > 1000 && item < 1300)
        {
            Text_Array.diary_step[0] = -1;
            del_any_text();
        }
        else if (Text_Array.diary_step[0] == 3 && item > 1300 && item < 1400)
        {
            Text_Array.diary_step[0] = -1;
            del_any_text();
        }
    }

     void del_any_text()
    {
        Queue<Transform> children = new Queue<Transform>();
        // 添加所有子物件到队列
        foreach (Transform child in transform)
        {
            children.Enqueue(child);
        }
        // 销毁队列中的每个子物件
        while (children.Count > 0)
        {
            Transform child = children.Dequeue();
            Destroy(child.gameObject);
        }
    }
}

