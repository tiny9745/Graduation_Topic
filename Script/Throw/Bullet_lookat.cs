using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_lookat : MonoBehaviour
{
    public Camera Camera_main; // 儲存攝影機引用
    public GameObject buttonImage; // 儲存目標物件引用

    void Start()
    {
        // 動態查找名稱為 "Camera" 的物件，並將其轉換為 Camera 類型
        GameObject cameraObject = GameObject.Find("Camera");

        if (cameraObject != null)
        {
            Camera_main = cameraObject.GetComponent<Camera>();

        }
    }

    void Update()
    {
        // 確保 Camera_main 和 buttonImage 都已正確賦值
        if (Camera_main != null && buttonImage != null)
        {
            buttonImage.transform.LookAt(Camera_main.transform.position);
        }
    }
}
