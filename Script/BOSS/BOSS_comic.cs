using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BOSS_comic : MonoBehaviour
{
    public Canvas canvas; // 需要將新建的 Image 放到的 Canvas
    public GameObject Image_box;
    uint comic_step = 0, comic_step_tmp = 0, Wait_time = 0;
    float comic_time_sum = 0, auto_comic_time;
    bool isTopLayer = false;
    string imagePath = "Sprites/Comic/boss_comic/1/"; // 圖檔在 Resources 中的路徑
    public GameObject tips;
    // Start is called before the first frame update
    void Start()
    {
        comic_step_tmp = comic_step;
        DeleteAllImagesUnderCanvas();
    }

    // Update is called once per frame
    void Update()
    {
        comic_time_sum += Time.deltaTime;
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            static_parameters.Comic_scene_sort = 0;
            comic_step = 1;
        }
        if ((Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Mouse0)) && comic_time_sum > 0.5f)
        {
            auto_comic_time = 0;
            comic_time_sum = 0;
            comic_step++;
        }
        if (comic_step != comic_step_tmp)
        {
            comic_step_tmp = comic_step;
            switch (static_parameters.Comic_scene_sort)
            {
                case 0:
                    imagePath = "Sprites/Comic/boss_comic/1/";
                    comic_image_Prologue01();
                    break;
                case 1:
                    imagePath = "Sprites/Comic/boss_comic/2/";
                    comic_image_Prologue02();
                    break;
            }
        }
        else
        {
            switch (Wait_time)
            {//須提前一步
                case 0:
                    auto_comic(2.5f);//換圖時間-無對話框
                    break;
                case 1:
                    auto_comic(1.5f);//換圖時間-對話框
                    break;
                case 2:
                    auto_comic(0.85f);//換圖時間-對話框快
                    break;
            }
        }
    }

    private void comic_image_add()
    {
        Sprite newSprite = Resources.Load<Sprite>(imagePath);

        if (newSprite != null)
        {
            Transform comicTransform = canvas.transform.Find("Comic");
            if (comicTransform == null)
            {
                // 如果不存在 Comic 物件，創建一個新的 GameObject 作為容器
                GameObject comicObject = new GameObject("Comic");
                comicObject.transform.SetParent(canvas.transform); // 設置父物件為 Canvas
                comicTransform = comicObject.transform;
            }

            // 計算縮放比例
            float scaleX = Screen.width / 1920f;
            float scaleY = Screen.height / 1080f;
            float scaleFactor = Mathf.Min(scaleX, scaleY); // 保持原始寬高比

            // 動態建立新的 Image 物件
            GameObject newImageObject = new GameObject("Comic_Image" + comic_step.ToString());
            newImageObject.transform.SetParent(comicTransform); // 設置父物件為 Comic

            // 新增 Image 組件
            Image newImage = newImageObject.AddComponent<Image>();

            // 設置 Image 的 Sprite 為載入的圖片
            newImage.sprite = newSprite;

            // 設定 Image 的位置和大小
            RectTransform rectTransform = newImage.GetComponent<RectTransform>();
            rectTransform.sizeDelta = new Vector2(1920 * scaleFactor, 1080 * scaleFactor); // 調整大小
            rectTransform.anchoredPosition = new Vector2(0, -300 * scaleFactor); // 調整位置

            if (isTopLayer)
            {
                newImageObject.transform.SetSiblingIndex(comicTransform.childCount - 1); // 最上層
            }
            else
            {
                newImageObject.transform.SetSiblingIndex(0); // 最底層
            }

            // 呼叫淡入效果
            StartCoroutine(FadeInImage(newImage, 0.4f, 300f * scaleFactor));
        }
    }

    IEnumerator FadeInImage(Image image, float duration, float moveDistance)
    {
        float elapsedTime = 0f;
        Color newColor = image.color;
        Vector3 originalPosition = image.transform.position; // 儲存初始位置

        // 計算縮放比例
        float scaleFactor = Mathf.Min(Screen.width / 1920f, Screen.height / 1080f);
        moveDistance *= scaleFactor;

        // 初始化 alpha 為 0（完全透明）
        newColor.a = 0f;
        image.color = newColor;

        // 持續時間內逐步增加 alpha
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;

            // 更新透明度
            newColor.a = Mathf.Clamp01(elapsedTime / duration);
            image.color = newColor;

            // 更新 Y 軸位置，逐步增加至 moveDistance
            float newYPosition = Mathf.Lerp(originalPosition.y, originalPosition.y + moveDistance, elapsedTime / duration);
            image.transform.position = new Vector3(originalPosition.x, newYPosition, originalPosition.z);

            yield return null; // 等待下一幀
        }

        // 確保最後完全顯示
        newColor.a = 1f;
        image.color = newColor;

        // 確保 Y 軸移動到最終位置
        image.transform.position = new Vector3(originalPosition.x, originalPosition.y + moveDistance, originalPosition.z);
    }

    IEnumerator FadeOutImage(Image image, float duration, float moveDistance)
    {
        float elapsedTime = 0f;
        Color newColor = image.color;
        Vector3 originalPosition = image.transform.position; // 儲存初始位置

        // 計算縮放比例
        float scaleFactor = Mathf.Min(Screen.width / 1920f, Screen.height / 1080f);
        moveDistance *= scaleFactor;

        // 持續時間內逐步減少 alpha
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            newColor.a = 1 - Mathf.Clamp01(elapsedTime / duration); // 更新透明度
            image.color = newColor;

            // 更新 Y 軸位置，逐步減少至 moveDistance
            float newYPosition = Mathf.Lerp(originalPosition.y, originalPosition.y + moveDistance, elapsedTime / duration);
            image.transform.position = new Vector3(originalPosition.x, newYPosition, originalPosition.z);

            yield return null; // 等待下一幀
        }

        // 確保最後完全隱藏
        newColor.a = 0f;
        image.color = newColor;
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
            }
        }
    }

    private void auto_comic(float time_T)
    {
        auto_comic_time += Time.deltaTime;
        if (auto_comic_time >= time_T)
        {
            comic_time_sum = 0;
            comic_step++;
            auto_comic_time = 0;
        }
    }

    private void comic_image_Prologue01()
    {
        switch (comic_step)
        {
            case 1:
                change_comic_BG("Sprites/Comic/boss_comic/1/b-bg");
                imagePath = "Sprites/Comic/boss_comic/1/b1";
                tips.SetActive(true);
                Wait_time = 1; isTopLayer = true;
                break;
            case 2:
                imagePath = "Sprites/Comic/boss_comic/1/b2";
                Wait_time = 0;
                break;
            case 3:
                imagePath = "Sprites/Comic/boss_comic/1/b3";
                break;
            case 4:
                imagePath = "Sprites/Comic/boss_comic/1/b4";
                Wait_time = 1;
                break;
            case 5:
                imagePath = "Sprites/Comic/boss_comic/1/b5";
                Wait_time = 0;
                break;
            case 6:
                imagePath = "Sprites/Comic/boss_comic/1/b6";
                Wait_time = 1;
                break;
            case 7:
                imagePath = "Sprites/Comic/boss_comic/1/b7";
                Wait_time = 0;
                break;
            case 8:
                imagePath = "Sprites/Comic/boss_comic/1/b7-1";
                Wait_time = 1;
                break;
            case 9:
                imagePath = "Sprites/Comic/boss_comic/1/b8";
                Wait_time = 0;
                break;
            case 10:
                imagePath = "Sprites/Comic/boss_comic/1/b9";
                Wait_time = 1;
                break;
            case 11:
                imagePath = "Sprites/Comic/boss_comic/1/b10";
                Wait_time = 1;
                break;
            case 12:
                imagePath = "Sprites/Comic/boss_comic/1/b11";
                Wait_time = 0;
                break;
            case 13:
                imagePath = "Sprites/Comic/boss_comic/1/b12";
                break;
            case 14:
                imagePath = "Sprites/Comic/boss_comic/1/b12-1";
                Wait_time = 1;
                break;
            case 15:
                imagePath = "Sprites/Comic/boss_comic/1/b12-2";
                Wait_time = 0;
                break;
            case 16:
                imagePath = "Sprites/Comic/boss_comic/1/b12-3";
                Wait_time = 1;
                break;
            case 17:
                imagePath = "Sprites/Comic/boss_comic/1/b12-4";
                Wait_time = 0;
                break;
            case 18:
                static_parameters.Comic_scene_sort++;
                DeleteAllImagesUnderCanvas();
                comic_step = 1;
                tips.SetActive(false);
                return;
        }
        comic_image_add();
    }

    private void comic_image_Prologue02()
    {
        switch (comic_step)
        {
            case 1:
                change_comic_BG("Sprites/Comic/boss_comic/2/c-bg");
                imagePath = "Sprites/Comic/boss_comic/2/comics02_1";
                Wait_time = 1;
                break;
            case 2:
                imagePath = "Sprites/Comic/boss_comic/2/c1";
                break;
            case 3:
                imagePath = "Sprites/Comic/boss_comic/2/c2";
                Wait_time = 0;
                break;
            case 4:
                imagePath = "Sprites/Comic/boss_comic/2/c3";
                isTopLayer = false;
                break;
            case 5:
                imagePath = "Sprites/Comic/boss_comic/2/c3-1";
                isTopLayer = true; Wait_time = 1;
                break;
            case 6:
                imagePath = "Sprites/Comic/boss_comic/2/c4";
                Wait_time = 0;
                break;
            case 7:
                imagePath = "Sprites/Comic/boss_comic/2/c5";
                Wait_time = 1;
                break;
            case 8:
                imagePath = "Sprites/Comic/boss_comic/2/c6";
                Wait_time = 0;
                break;
            case 9:
                imagePath = "Sprites/Comic/boss_comic/2/c6-1";
                isTopLayer = false; Wait_time = 1;
                break;
            case 10:
                imagePath = "Sprites/Comic/boss_comic/2/c6-2";
                isTopLayer = true;
                break;
            case 11:
                imagePath = "Sprites/Comic/boss_comic/2/c7";
                Wait_time = 0;
                break;
            case 12:
                imagePath = "Sprites/Comic/boss_comic/2/c8";
                break;
            case 13:
                imagePath = "Sprites/Comic/boss_comic/2/c8-1";
                Wait_time = 0;
                break;
            case 14:
                imagePath = "Sprites/Comic/boss_comic/2/c8-2";
                isTopLayer = false;
                break;
            case 15:
                imagePath = "Sprites/Comic/boss_comic/2/c9";
                isTopLayer = true; Wait_time = 1;
                break;
            case 16:
                imagePath = "Sprites/Comic/boss_comic/2/c10";
                Wait_time = 0;
                break;
            case 17:
                imagePath = "Sprites/Comic/boss_comic/2/c11";
                isTopLayer = false; Wait_time = 1;
                break;
            case 18:
                static_parameters.Comic_scene_sort = 0;
                comic_step = 1;
                gameObject.SetActive(false);
                return;
        }
    }
}
