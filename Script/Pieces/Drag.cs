using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform _rectTransform;
    private Vector2 _originalPosition;
    public Sprite nullsprite;
    private CanvasGroup _canvasGroup;
    private Transform _originalParent;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _canvasGroup = GetComponent<CanvasGroup>();
        nullsprite = GetComponent<Image>().sprite;
        _originalPosition = _rectTransform.anchoredPosition;
        _originalParent = _rectTransform.parent; // 儲存原本的父物件
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (GetComponent<Image>().sprite != nullsprite)
        {
            _originalParent = transform.parent;
            transform.SetParent(GameObject.Find("ESC_Canvas").transform, true);

            _canvasGroup.alpha = 0.6f;
            _canvasGroup.blocksRaycasts = false;
        }
        else
        {

            return;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        // 移動物件至滑鼠指標位置
        if (GetComponent<Image>().sprite != nullsprite)
        {
            _rectTransform.position = eventData.position;
        }
        else
        {
            return;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _canvasGroup.alpha = 1f;
        _canvasGroup.blocksRaycasts = true;

        // 回到原本的父物件層級（若需要重設位置）
        transform.SetParent(_originalParent, false);
        _rectTransform.anchoredPosition = _originalPosition;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        OnEndDrag(eventData);
    }
}
