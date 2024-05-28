using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Drag_End : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        Text dragText = eventData.pointerDrag.GetComponent<Text>(); // 获取拖拽物体上的Text组件
        Text dropText = GetComponent<Text>(); // 获取当前物体上的Text组件

        // 如果两者都存在，则进行文本内容的替换
        if (dragText != null && dropText != null)
        {
            dropText.text = dragText.text;
            Destroy(eventData.pointerDrag);
        }
    }
}
