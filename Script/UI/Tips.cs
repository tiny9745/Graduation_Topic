using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Tips : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private RectTransform rectTransform;
    private Vector2 originalPosition;
    float shiftAmount = 275f;
    public float moveSpeed = 10f;
    private Vector2 targetPosition;
    public Image Tipsimg;
    public Sprite blue, red, green, purple, yellow,defult; // 顏色圖片

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        originalPosition = rectTransform.anchoredPosition;
        targetPosition = originalPosition;
    }

    void Update()
    {
        rectTransform.anchoredPosition = Vector2.Lerp(rectTransform.anchoredPosition, targetPosition, Time.deltaTime * moveSpeed);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        targetPosition = originalPosition + Vector2.right * shiftAmount;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        targetPosition = originalPosition;
    }

    public void SetColor(string color)
    {
        switch (color.ToLower())
        {
            case "blu":
                Tipsimg.sprite = blue;
                break;
            case "red":
                Tipsimg.sprite = red;
                break;
            case "grn":
                Tipsimg.sprite = green;
                break;
            case "prp":
                Tipsimg.sprite = purple;
                break;
            case "yel":
                Tipsimg.sprite = yellow;
                break;
            default:
                Tipsimg.sprite = defult; // 預設圖片
                break;
        }
    }
}

