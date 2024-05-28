using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Drag_Text : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform _rectTransform;
    private Vector2 _originalRectPosition;
    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _originalRectPosition = _rectTransform.anchoredPosition;
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // 确保_canvasGroup已初始化
        if (_canvasGroup != null)
        {
            _canvasGroup.blocksRaycasts = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // 确保_canvasGroup已初始化
        if (_canvasGroup != null)
        {
            _canvasGroup.blocksRaycasts = true;
        }
        _rectTransform.anchoredPosition = _originalRectPosition;
    }
}
