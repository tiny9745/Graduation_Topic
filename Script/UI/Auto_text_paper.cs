using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Auto_text_paper : MonoBehaviour
{
    public GameObject itemPrefab; // Preset child elements
    public GameObject itemPanel;

    void Start()
    {
        GenerateItems(); // generate objects
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
                item.name = content.Name_number.ToString(); // Set the name of the generated object
                item.GetComponentInChildren<Text>().text = content.Name_Text; // Set the text content of the generated object
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
