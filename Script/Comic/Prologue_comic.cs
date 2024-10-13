using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Prologue_comic : MonoBehaviour
{
    uint comic_step = 0;
    uint comic_step_tmp;
    float comic_time_sum = 0;


    string imagePath = "Sprites/Comic/Prologue/01/comics_1-1"; // 圖檔在 Resources 中的路徑
    public Canvas canvas; // 需要將新建的 Image 放到的 Canvas
    // Start is called before the first frame update
    void Start()
    {
        comic_step_tmp = comic_step;
    }

    // Update is called once per frame
    void Update()
    {
        comic_time_sum += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Return) && comic_time_sum > 2.5f)
        {
            comic_time_sum = 0;
            comic_step++;
        }
        if (comic_step != comic_step_tmp)
        {
            comic_step_tmp = comic_step;
            switch (static_parameters.Comic_scene_sort)
            {
                case 0:
                    comic_image_Prologue01();
                    break;
            }
        }
    }

    private void comic_image_Prologue01()
    {
        switch (comic_step)
        {
            case 1:
                imagePath = "Sprites/Comic/Prologue/01/comics_1-1";
                break;
        }
        comic_image_add();
    }

    private void comic_image_add(){
        Sprite newSprite = Resources.Load<Sprite>(imagePath);

        // 檢查是否成功載入
        if (newSprite != null)
        {
            // 動態建立新的 Image 物件
            GameObject newImageObject = new GameObject(imagePath);
            newImageObject.transform.SetParent(canvas.transform); // 設置父物件為 Canvas

            // 新增 Image 組件
            Image newImage = newImageObject.AddComponent<Image>();

            // 設置 Image 的 Sprite 為載入的圖片
            newImage.sprite = newSprite;

            // 設定 Image 的位置和大小
            RectTransform rectTransform = newImage.GetComponent<RectTransform>();
            rectTransform.sizeDelta = new Vector2(1920, 1080); // 設定大小
            rectTransform.anchoredPosition = new Vector2(0, 0); // 設定位置（相對於 Canvas 中心）
        }
        else
        {
            Debug.LogError("Failed to load image from Resources: " + imagePath);
        }
    }
}
