using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Auto_text_paper : MonoBehaviour
{
    public GameObject itemPrefab; // 预置子元素
    public GameObject itemPanel; // 包含 Vertical Layout Group 的面板

    void Start()
    {
        GenerateItems(); // 生成物体
    }

    void GenerateItems()
    {
        print("GenerateItems");
        if (Text_Array.Text_contents != null)
        {
            foreach (Text_content content in Text_Array.Text_contents)
            {
                print("content" + content);
                GameObject item = Instantiate(itemPrefab, itemPanel.transform);
                item.name = content.Name_number.ToString(); // 设置生成对象的名称
                item.GetComponentInChildren<Text>().text = content.Name_Text; // 设置生成对象的文本内容
                if (!content.Text_exist)
                {
                    item.SetActive(content.Text_exist);
                }
            }
        }
        else
        {
            Debug.LogError("Text_Array.Text_contents is null");
        }
    }
}
