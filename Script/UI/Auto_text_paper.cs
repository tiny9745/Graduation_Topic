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

    void GenerateItems()
    {
        if (Text_Array.Text_contents != null)
        {
            foreach (Text_content content in Text_Array.Text_contents)
            {
                print("content" + content);
                GameObject item = Instantiate(itemPrefab, itemPanel.transform);
                item.name = content.Name_number.ToString(); // Set the name of the generated object
                item.GetComponentInChildren<Text>().text = content.Name_Text; // Set the text content of the generated object
                Text_into(item);
            }
        }
        else
        {
            Debug.LogError("Text_Array.Text_contents is null");
        }
    }

    public void Text_into(GameObject item)
    {
        if (int.TryParse(item.name, out int itemNameInt))
        {
            //diary text Error Destroy
            if (Text_Array.diary_step[0] == 0 && !(itemNameInt < 20)) // diary_step=0 is <20
            {
                print("1:"+ Text_Array.diary_step[0]);
                Destroy(item);
            }
            else if (Text_Array.diary_step[0] == 1 && !(itemNameInt > 1000 && itemNameInt < 10000)) // diary_step=1 is >1000 & <10000
            {
                print("2:"+ Text_Array.diary_step[0]);
                Destroy(item);
            }
            else if (Text_Array.diary_step[0] == 2 && !(itemNameInt < 10000)) // diary_step=2 is <10000
            {
                print("3:" + Text_Array.diary_step[0]);
                Destroy(item);
            }

            //diary_End，位置待商榷
            /*if (itemNameInt < 1300 && Text_Array.diary_step[0] == 2)
            {
                Text_Array.diary_step[0] = -1;
            }
            else if (Text_Array.diary_step[0] == 2 && !(itemNameInt < 10000)) // diary_step=2 is <10000
            {
                Text_Array.diary_step[0] = -1;
            }*/
        }
        else
        {
            Debug.LogError($"Failed to parse item name '{item.name}' to int.");
        }
    }
}

