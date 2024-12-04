using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Drag_Text : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform _rectTransform;
    private Vector2 _originalPosition;
    private CanvasGroup _canvasGroup;
    private Transform _parentTransform;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _originalPosition = _rectTransform.anchoredPosition;
        _canvasGroup = GetComponent<CanvasGroup>();
        _parentTransform = transform.parent; // Parent should be the Grid Layout
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (_canvasGroup != null)
        {
            _canvasGroup.blocksRaycasts = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Move the object along with the cursor
        _rectTransform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (_canvasGroup != null)
        {
            _canvasGroup.blocksRaycasts = true;
        }
        SnapBack();
    }

    private void SnapBack()
    {
        _rectTransform.anchoredPosition = _originalPosition;

    }
}
