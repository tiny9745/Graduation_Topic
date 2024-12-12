using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    // Start is called before the first frame update
    private RectTransform _rectTransform;    
    private Vector2 _originalPosition;
    public Sprite nullsprite;
    private CanvasGroup _canvasGroup;
    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _canvasGroup = GetComponent<CanvasGroup>();
        nullsprite = GetComponent<Image>().sprite;
        _originalPosition = _rectTransform.anchoredPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (GetComponent<Image>().sprite != nullsprite)
        {
            _canvasGroup.alpha = 0.6f;
            _canvasGroup.blocksRaycasts = false;
        }else  return;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Move the object along with the cursor
        if (GetComponent<Image>().sprite != nullsprite)
        {
            _rectTransform.position = eventData.position;
        }else  return;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _canvasGroup.alpha = 1f;
        _canvasGroup.blocksRaycasts = true;
        _rectTransform.anchoredPosition = _originalPosition;
    }
}