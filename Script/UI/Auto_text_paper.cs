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
                        //Text_into(item);
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

    void Text_into(GameObject item)
    {
        if (int.TryParse(item.name, out int itemNameInt))
        {
            //diary text Error Destroy
            if (Text_Array.diary_step[0] == 0 && !(itemNameInt < 100)) // diary_step=0 is <100
            {
                Destroy(item);
            }
            else if (Text_Array.diary_step[0] == 1 && !(itemNameInt > 1000 && itemNameInt < 10000)) // diary_step=1 is >1000 & <10000
            {
                Destroy(item);
            }
            else if (Text_Array.diary_step[0] == 2 && !(itemNameInt > 10000)) // diary_step=2 is >10000
            {
                Destroy(item);
            }
            else if (Text_Array.diary_step[0] == -1) // diary_step=2 is >10000
            {
                Destroy(item);
            }
        }
        else
        {
            Debug.LogError($"Failed to parse item name '{item.name}' to int.");
        }
    }

    public void diary_text_chose(int item)
    {
        if (Text_Array.Text_contents != null)
        {
            foreach (Text_content content in Text_Array.Text_contents)
            {
                if (item == 11)
                {
                    if (content.Text_exist && content.Name_number < 1200 && content.Name_number > 1100)
                    {
                        del_any_text();
                        GameObject item2 = Instantiate(itemPrefab, itemPanel.transform);
                        item2.name = content.Name_number.ToString();
                        item2.GetComponentInChildren<Text>().text = content.Name_Text; 
                    }
                }
                if(item == 12)
                {
                    if (content.Text_exist && content.Name_number < 1300 && content.Name_number > 1400)
                    {
                        del_any_text();
                        GameObject item2 = Instantiate(itemPrefab, itemPanel.transform);
                        item2.name = content.Name_number.ToString();
                        item2.GetComponentInChildren<Text>().text = content.Name_Text; 
                    }
                }
                if (item == 13)
                {
                    if (content.Text_exist && content.Name_number < 1400 && content.Name_number > 1500)
                    {
                        del_any_text();
                        GameObject item2 = Instantiate(itemPrefab, itemPanel.transform);
                        item2.name = content.Name_number.ToString(); 
                        item2.GetComponentInChildren<Text>().text = content.Name_Text;
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

    void filter_dairy_text()
    {

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
        print("del");
    }
}

