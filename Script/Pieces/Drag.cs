using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    // Start is called before the first frame update
    private RectTransform _rectTransform;
    private Vector2 _originalPosition;
    private CanvasGroup _canvasGroup;
    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _originalPosition = _rectTransform.anchoredPosition;
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _canvasGroup.alpha = .6f;
        _canvasGroup.blocksRaycasts = false;
        Debug.Log("OnBeginDrag");
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Move the object along with the cursor
        _rectTransform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _canvasGroup.alpha = 1f;
        _canvasGroup.blocksRaycasts = true;
        Debug.Log("OnEndDrag");
    }
}