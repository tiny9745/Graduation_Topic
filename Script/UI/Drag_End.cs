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

    public void OnDrop(PointerEventData eventData)
    {
        Text dragText = eventData.pointerDrag.GetComponent<Text>(); // Get the Text component on the dragged object
        if (dragText != null)
        {
            Text_Array.diary_step[Text_Array.diary_number]++;

            // Concatenate the dragged text to the existing text and assign to left text
            string fullText = Diary_text_Left.GetComponent<Text>().text + dragText.text;

            if (int.TryParse(dragText.name, out int itemNameInt))
            {
                if (Text_Array.Text_contents != null)
                {
                    foreach (Text_content content in Text_Array.Text_contents)
                    {
                        if (itemNameInt == content.Name_number)
                        {
                            fullText += content.Text_text;
                        }
                    }
                }
                Diary_Auto.diary_text_chose(itemNameInt);
            }

            // Use TextPageHandler to set the text and handle overflow
            SetText(fullText);
        }
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
            if (textGen.characterCountVisible < tempText.Length)
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