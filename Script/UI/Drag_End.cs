using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class Drag_End : MonoBehaviour, IDropHandler
{
    bool LR_switch = true;
    public GameObject Diary_text_Left;
    public GameObject Diary_text_Right;
    public Auto_text_paper Diary_Auto;
    public void OnDrop(PointerEventData eventData)
    {
        Text dragText = eventData.pointerDrag.GetComponent<Text>(); // Get the Text component on the dragged object
            Text dropText = GetComponent<Text>(); // Get the Text component on the current object
        // If both exist, replace the text content
        if (dragText != null && dropText != null)
        {
            Text_Array.diary_step[Text_Array.diary_number]++;
            dropText.text += dragText.text;
            if (int.TryParse(dragText.name, out int itemNameInt))
            {
                Diary_Auto.diary_text_chose(itemNameInt);
            }
            if(LR_switch && dropText.text.Length >= 50)
            {
                LR_switch = false;
            }
            Diary_text_Left.SetActive(LR_switch);
            Diary_text_Right.SetActive(!LR_switch);
        }
    }
}
