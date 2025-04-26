using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chest_tips : MonoBehaviour
{
    private RectTransform rectTransform;
    private Vector2 originalPosition, targetPosition;
    float shiftAmount = 640f;
    private float moveSpeed = 10f;
    private bool isEnd = false;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        originalPosition = rectTransform.anchoredPosition;
        targetPosition = originalPosition;
    }

    void Update()
    {
        if (static_parameters.teaching_stop < 100) return;
        rectTransform.anchoredPosition = Vector2.Lerp(rectTransform.anchoredPosition, targetPosition, Time.deltaTime * moveSpeed);
        if (static_parameters.next_door && !isEnd)
        {
            targetPosition = originalPosition + Vector2.left * shiftAmount;
            if (targetPosition.y <= 660f) isEnd = true;
        }
        else if (static_parameters.next_door && isEnd) Invoke("Delay", 7.5f);
        else
        {
            isEnd = false;
            targetPosition = originalPosition;
        }
    }
    void Delay()
    {
        targetPosition = originalPosition + Vector2.right * shiftAmount;
    }
}