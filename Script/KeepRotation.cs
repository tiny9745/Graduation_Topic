using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepRotation : MonoBehaviour
{
    private Quaternion initialRotation;

    void Start()
    {
        // 記錄子物件的初始旋轉
        initialRotation = transform.rotation;
    }

    void LateUpdate()
    {
        // 維持子物件的初始旋轉，不受父物件影響
        transform.rotation = initialRotation;
    }
}
