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
                    GameObject item = Instantiate(itemPrefab, itemPanel.transform);
                    item.name = content.Name_number.ToString(); // 设置生成对象的名称
                    item.GetComponentInChildren<Text>().text = content.Name_Text; // 设置生成对象的文本内容
                    Text_into(item);
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
        //diary_End啟用，位置待商榷
        print("iiiiiiiiiii");
        if (Text_Array.diary_step[0] == 1 && item > 1000 && item < 1300)
        {
            Text_Array.diary_step[0] = -1;
            del_any_text();
        }
        else if (Text_Array.diary_step[0] == 2 && item > 1300 && item < 1400)
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

