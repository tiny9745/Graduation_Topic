using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Drag_End : MonoBehaviour, IDropHandler
{
    public GameObject Diary_text_Left;
    public GameObject Diary_text_Right;
    public Auto_text_paper Diary_Auto;
    public Text leftText;
    public Text rightText;
    public string all_text;//陣列

    public void OnDrop(PointerEventData eventData)
    {
        Text dragText = eventData.pointerDrag.GetComponent<Text>(); // Get the Text component on the dragged object
        if (dragText != null)
        {
            // Concatenate the dragged text to the existing text and assign to left text
            string fullText = Diary_text_Left.GetComponent<Text>().text;

            if (int.TryParse(dragText.name, out int itemNameInt))
            {
                if (Text_Array.Text_contents != null)
                {
                    foreach (Text_content content in Text_Array.Text_contents)
                    {
                        if (itemNameInt == content.Name_number)
                        {
                            static_parameters.diary_memory[0][static_parameters.diary_step] = content.Name_number;
                            Debug.Log("static_parameters.diary_step:" + static_parameters.diary_step);
                            static_parameters.diary_step++;
                            fullText += content.Text_text;
                            all_text = fullText;
                        }
                    }
                    //測試進行中
                    GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>();

                    foreach (GameObject obj in allObjects)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            // 嘗試將 obj.name 轉換為 int
                            int objectNameAsInt;
                            if (int.TryParse(obj.name, out objectNameAsInt))
                            {
                                // 檢查轉換後的名稱是否與 diary_memory 中的值匹配
                                if (objectNameAsInt < Mathf.Floor(static_parameters.diary_memory[i][0] / 10) * 10 + 10 && objectNameAsInt > Mathf.Floor(static_parameters.diary_memory[i][0] / 10) * 10)
                                {
                                    Destroy(obj); // 刪除物件
                                }
                            }
                        }
                    }
                    //測試進行中
                }
                Diary_Auto.diary_text_chose(itemNameInt);
            }

            // Use TextPageHandler to set the text and handle overflow
            SetText(fullText);
        }
    }

    public void clear_text()
    {
        leftText.text = "";
        rightText.text = "";
    }

    public void SetText(string fullText)
    {
        leftText.text = "";
        rightText.text = "";

        TextGenerator textGen = new TextGenerator();
        TextGenerationSettings settings = leftText.GetGenerationSettings(leftText.rectTransform.rect.size);

        int charIndex = 0;
        int overflowIndex = 0;
        bool isLeftFull = false;

        // Find the point at which the text overflows
        while (charIndex < fullText.Length)
        {
            string tempText = fullText.Substring(0, charIndex + 1);
            textGen.Populate(tempText, settings);
            if (textGen.characterCountVisible < tempText.Length - 2)
            {
                isLeftFull = true;
                overflowIndex = charIndex;
                break;
            }
            charIndex++;
        }

        // Assign text to left and right texts
        if (isLeftFull)
        {
            leftText.text = fullText.Substring(0, overflowIndex);
            rightText.text = fullText.Substring(overflowIndex);
        }
        else
        {
            leftText.text = fullText;
            rightText.text = "";
        }
    }
}