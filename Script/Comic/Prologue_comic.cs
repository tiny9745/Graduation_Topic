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
    public GameObject Image_box;

    // Start is called before the first frame update
    void Start()
    {
        comic_step_tmp = comic_step;
    }

    // Update is called once per frame
    void Update()
    {
        comic_time_sum += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Return) && comic_time_sum > 1.5f)
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
                case 1:
                    change_comic_BG("Sprites/Comic/Prologue/03/background_c2");
                    comic_image_Prologue02();
                    break;
                case 2:
                    change_comic_BG("Sprites/Comic/Prologue/03/background_c3");
                    comic_image_Prologue03();
                    break;
            }
        }
    }

    private void comic_image_add()
    {
        Sprite newSprite = Resources.Load<Sprite>(imagePath);

        // 檢查是否成功載入
        if (newSprite != null)
        {
            // 在 Canvas 底下找到或創建名為 Comic 的物件
            Transform comicTransform = canvas.transform.Find("Comic");
            if (comicTransform == null)
            {
                // 如果不存在 Comic 物件，創建一個新的 GameObject 作為容器
                GameObject comicObject = new GameObject("Comic");
                comicObject.transform.SetParent(canvas.transform); // 設置父物件為 Canvas
                comicTransform = comicObject.transform;
            }

            // 動態建立新的 Image 物件
            GameObject newImageObject = new GameObject("Comic_Image" + comic_step.ToString());
            newImageObject.transform.SetParent(comicTransform); // 設置父物件為 Comic

            // 新增 Image 組件
            Image newImage = newImageObject.AddComponent<Image>();

            // 設置 Image 的 Sprite 為載入的圖片
            newImage.sprite = newSprite;

            // 設定 Image 的位置和大小
            RectTransform rectTransform = newImage.GetComponent<RectTransform>();
            rectTransform.sizeDelta = new Vector2(1920, 1080); // 設定大小
            rectTransform.anchoredPosition = new Vector2(0, -300); // 設定位置（相對於 Canvas 中心）

            // 呼叫淡入效果
            StartCoroutine(FadeInImage(newImage, 1.2f, 300f));
        }
        else
        {
            Debug.LogError("Failed to load image from Resources: " + imagePath);
        }
    }

    IEnumerator FadeInImage(Image image, float duration, float moveDistance)
    {
        float elapsedTime = 0f;
        Color newColor = image.color;
        Vector3 originalPosition = image.transform.position; // 儲存初始位置

        // 初始化 alpha 為 0（完全透明）
        newColor.a = 0f;
        image.color = newColor;

        // 持續時間內逐步增加 alpha 並移動 X 軸位置
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;

            // 更新透明度
            newColor.a = Mathf.Clamp01(elapsedTime / duration);
            image.color = newColor;

            // 更新 Y 軸位置，逐步增加至 moveDistance
            float newXPosition = Mathf.Lerp(originalPosition.y, originalPosition.y + moveDistance, elapsedTime / duration);
            image.transform.position = new Vector3(originalPosition.x, newXPosition, originalPosition.z);

            yield return null; // 等待下一幀
        }

        // 確保最後完全顯示
        newColor.a = 1f;
        image.color = newColor;

        // 確保 X 軸移動到最終位置
        image.transform.position = new Vector3(originalPosition.x, originalPosition.y + moveDistance, originalPosition.z);
    }

    void DeleteAllImagesUnderCanvas()
    {
        foreach (Transform child in Image_box.transform)
        {
            Image image = child.GetComponent<Image>();
            if (image != null)
            {
                Destroy(child.gameObject); // 刪除包含 Image 的 GameObject
            }
        }
    }

    void change_comic_BG(string BG_Path)
    {
        GameObject BG_Image = GameObject.Find("BG");
        // 確認 BG_Image 上有 Image 組件
        if (BG_Image != null)
        {
            Image bgImageComponent = BG_Image.GetComponent<Image>();

            if (bgImageComponent != null)
            {
                Sprite newSprite = Resources.Load<Sprite>(BG_Path);
                if (newSprite != null)
                {
                    bgImageComponent.sprite = newSprite;
                }
                else
                {
                    Debug.LogError("Failed to load image from Resources: " + BG_Path);
                }
            }
            else
            {
                Debug.LogError("BG GameObject does not have an Image component.");
            }
        }
        else
        {
            Debug.LogError("BG GameObject not found.");
        }
    }

    private void comic_image_Prologue01()
    {
        switch (comic_step)
        {
            case 1:
                imagePath = "Sprites/Comic/Prologue/01/comics_1-1";
                break;
            case 2:
                imagePath = "Sprites/Comic/Prologue/01/comics_1-2";
                break;
            case 3:
                imagePath = "Sprites/Comic/Prologue/01/comics_1-3";
                break;
            case 4:
                imagePath = "Sprites/Comic/Prologue/01/dialogbox_1-1";
                break;
            case 5:
                imagePath = "Sprites/Comic/Prologue/01/comics_1-4";
                break;
            case 6:
                comic_step = 1;
                static_parameters.Comic_scene_sort++;
                DeleteAllImagesUnderCanvas();
                return;
        }
        comic_image_add();
    }

    private void comic_image_Prologue02()
    {
        switch (comic_step)
        {
            case 1:
                imagePath = "Sprites/Comic/Prologue/02/comics_2-1";
                break;
            case 2:
                imagePath = "Sprites/Comic/Prologue/02/comics_2-2";
                break;
            case 3:
                imagePath = "Sprites/Comic/Prologue/02/comics_2-3";
                break;
            case 4:
                imagePath = "Sprites/Comic/Prologue/02/comics_2-4";
                break;
            case 5:
                imagePath = "Sprites/Comic/Prologue/02/comics_2-5";
                break;
            case 6:
                imagePath = "Sprites/Comic/Prologue/02/dialogbox_2-";
                break;
            case 7:
                imagePath = "Sprites/Comic/Prologue/02/comics_2-6";
                comic_step = 1;
                static_parameters.Comic_scene_sort++;
                DeleteAllImagesUnderCanvas();
                return;
        }
        comic_image_add();
    }

    private void comic_image_Prologue03()
    {
        switch (comic_step)
        {
            case 1:
                imagePath = "Sprites/Comic/Prologue/03/comics_3-1";
                break;
            case 2:
                imagePath = "Sprites/Comic/Prologue/03/dialogbox_3-1";
                break;
            case 3:
                imagePath = "Sprites/Comic/Prologue/03/comics_3-2";
                break;
            case 4:
                imagePath = "Sprites/Comic/Prologue/03/dialogbox_3-2";
                break;
            case 5:
                imagePath = "Sprites/Comic/Prologue/03/comics_3-3";
                break;
            case 6:
                imagePath = "Sprites/Comic/Prologue/03/dialogbox_3-3";
                break;
            case 7:
                imagePath = "Sprites/Comic/Prologue/03/comics_3-4";
                break;
            case 8:
                imagePath = "Sprites/Comic/Prologue/03/dialogbox_3-5";
                break;
            case 9:
                imagePath = "Sprites/Comic/Prologue/03/dialogbox_3-6";
                break;
            case 10:
                imagePath = "Sprites/Comic/Prologue/03/dialogbox_3-7";
                break;
            case 11:
                imagePath = "Sprites/Comic/Prologue/03/comics_3-5";
                break;
            case 12:
                imagePath = "Sprites/Comic/Prologue/03/dialogbox_3-8";
                break;
            case 13:
                imagePath = "Sprites/Comic/Prologue/03/comics_3-6";
                break;
            case 14:
                imagePath = "Sprites/Comic/Prologue/03/dialogbox_3-9";
                break;
            case 15:
                imagePath = "Sprites/Comic/Prologue/03/comics_3-7";
                break;
            case 16:
                imagePath = "Sprites/Comic/Prologue/03/dialogbox_3-10";
                comic_step = 1;
                static_parameters.Comic_scene_sort++;
                DeleteAllImagesUnderCanvas();
                return;
        }
        comic_image_add();
    }
}