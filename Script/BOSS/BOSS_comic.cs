using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BOSS_comic : MonoBehaviour
{
    public Canvas canvas; // 需要將新建的 Image 放到的 Canvas
    // public GameObject Image_box;
    uint comic_step = 0, comic_step_tmp = 0, Wait_time = 0;
    float comic_time_sum = 0, auto_comic_time;
    bool isTopLayer = true;
    string imagePath = "Sprites/Comic/boss_comic/1/"; // 圖檔在 Resources 中的路徑
    public GameObject tips, BG_Image;
    // Start is called before the first frame update
    public GameObject Demo_End;
    float offsetY;
    void Start()
    {
        comic_step_tmp = comic_step;
        DeleteAllImagesUnderCanvas();
        BG_Image.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        comic_time_sum += Time.deltaTime;
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            BOSS_comic_END();
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
            Debug.Log("comic_step = " + static_parameters.Comic_scene_sort);
            switch (static_parameters.Comic_scene_sort)
            {
                case 0:
                    Debug.Log("comic_step0 = " + comic_step);
                    imagePath = "Sprites/Comic/boss_comic/1/";
                    comic_image_Prologue01();
                    break;
                case 1:
                    Debug.Log("comic_step1 = " + comic_step);
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

    void change_comic_BG(string BG_Path)
    {
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

    private void comic_image_add()
    {
        Sprite newSprite = Resources.Load<Sprite>(imagePath);

        if (newSprite != null)
        {
            Transform comicTransform = canvas.transform.Find("Comic");
            if (comicTransform == null)
            {
                // 如果不存在 Comic 物件，創建一個新的 GameObject 作為容器
                GameObject comicObject = new GameObject("Comic", typeof(RectTransform));
                comicObject.transform.SetParent(canvas.transform, false); // ★ SetParent時用false，防止亂縮放
                comicTransform = comicObject.transform;

                // 設定Comic容器置中
                RectTransform comicRect = comicTransform.GetComponent<RectTransform>();
                comicRect.anchorMin = new Vector2(0.5f, 0.5f);
                comicRect.anchorMax = new Vector2(0.5f, 0.5f);
                comicRect.pivot = new Vector2(0.5f, 0.5f);

                // comicRect.anchoredPosition = new Vector2(0, offsetY);
                // comicRect.anchoredPosition = new Vector2(0, -270f);
                comicRect.anchoredPosition = new Vector2(0, 0);
                comicRect.sizeDelta = Vector2.zero; // 讓它跟隨內容物大小
            }

            // 動態建立新的 Image 物件
            GameObject newImageObject = new GameObject("Comic_Image" + comic_step.ToString(), typeof(RectTransform));
            newImageObject.transform.SetParent(comicTransform, false); // ★ 同樣SetParent要false保持本地設定

            // 新增 Image 組件
            Image newImage = newImageObject.AddComponent<Image>();
            newImage.sprite = newSprite;
            newImage.SetNativeSize(); // 初始設定成Sprite原尺寸

            // 設定 RectTransform
            RectTransform rectTransform = newImage.GetComponent<RectTransform>();
            rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
            rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
            rectTransform.pivot = new Vector2(0.5f, 0.5f);
            rectTransform.anchoredPosition = new Vector2(0, 0); // 完全置中

            // 縮放到螢幕適應
            rectTransform.sizeDelta = new Vector2(1920, 1080);

            // 控制順序
            if (isTopLayer)
            {
                newImageObject.transform.SetSiblingIndex(comicTransform.childCount - 1); // 放到最上面
            }
            else
            {
                newImageObject.transform.SetSiblingIndex(0); // 放到底層
            }

            // 呼叫淡入效果
            StartCoroutine(FadeInImage(newImage, 0.4f));
        }
    }

    IEnumerator FadeInImage(Image image, float duration)
    {
        float elapsedTime = 0f;
        RectTransform rectTransform = image.GetComponent<RectTransform>();

        // 起始位置：原點往下 offset 300
        Vector2 startPos = rectTransform.anchoredPosition - new Vector2(0, 300);
        // 結束位置：原點
        Vector2 endPos = rectTransform.anchoredPosition;

        // 初始化位置
        rectTransform.anchoredPosition = startPos;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / duration);

            // 線性插值從 startPos 到 endPos
            rectTransform.anchoredPosition = Vector2.Lerp(startPos, endPos, t);

            yield return null;
        }

        // 保險設定
        rectTransform.anchoredPosition = endPos;
    }

    void DeleteAllImagesUnderCanvas()
    {
        Transform comicTransform = canvas.transform.Find("Comic"); // 找到 Comic 這個容器
        if (comicTransform != null)
        {
            foreach (Transform child in comicTransform)
            {
                Destroy(child.gameObject); // 刪除 Comic 底下所有的Comic_Image
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
                static_parameters.Bookstate = true;
                change_comic_BG("Sprites/Comic/boss_comic/1/b-bg");
                imagePath = "Sprites/Comic/boss_comic/1/b1";
                tips.SetActive(true);
                Wait_time = 1;
                isTopLayer = true;
                break;
            case 2:
                imagePath = "Sprites/Comic/boss_comic/1/b2";
                Wait_time = 1;
                isTopLayer = false;
                break;
            case 3:
                imagePath = "Sprites/Comic/boss_comic/1/b3";
                Wait_time = 1;
                isTopLayer = true;
                break;
            case 4:
                imagePath = "Sprites/Comic/boss_comic/1/b4";
                Wait_time = 1;
                tips.SetActive(false);
                break;
            case 5:
                imagePath = "Sprites/Comic/boss_comic/1/b5";
                Wait_time = 1;
                isTopLayer = false;
                break;
            case 6:
                imagePath = "Sprites/Comic/boss_comic/1/b6";
                Wait_time = 1;
                break;
            case 7:
                comic_image_add();
                imagePath = "Sprites/Comic/boss_comic/1/b7";
                isTopLayer = false;
                Wait_time = 1;
                break;
            case 8:
                imagePath = "Sprites/Comic/boss_comic/1/b7-0";
                isTopLayer = true;
                Wait_time = 0;
                break;
            case 9:
                imagePath = "Sprites/Comic/boss_comic/1/b7-1";
                Wait_time = 0;
                break;
            case 10:
                imagePath = "Sprites/Comic/boss_comic/1/b8";
                Wait_time = 1;
                break;
            case 11:
                imagePath = "Sprites/Comic/boss_comic/1/b9";
                Wait_time = 1;
                break;
            case 12:
                imagePath = "Sprites/Comic/boss_comic/1/b10";
                Wait_time = 1;
                break;
            case 13:
                imagePath = "Sprites/Comic/boss_comic/1/b11";
                Wait_time = 1;
                break;
            case 14:
                imagePath = "Sprites/Comic/boss_comic/1/b12";
                isTopLayer = false;
                Wait_time = 1;
                break;
            case 15:
                imagePath = "Sprites/Comic/boss_comic/1/b12-1";
                isTopLayer = true;
                Wait_time = 0;
                break;
            case 16:
                imagePath = "Sprites/Comic/boss_comic/1/b12-2";
                Wait_time = 0;
                break;
            case 17:
                imagePath = "Sprites/Comic/boss_comic/1/b12-3";
                Wait_time = 0;
                break;
            case 18:
                imagePath = "Sprites/Comic/boss_comic/1/b12-4";
                Wait_time = 0;
                break;
            case 19:
                Wait_time = 2;
                static_parameters.Comic_scene_sort++;
                DeleteAllImagesUnderCanvas();
                comic_step = 1;
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
                isTopLayer = true;
                imagePath = "Sprites/Comic/boss_comic/2/comics02_1";
                Wait_time = 1;
                break;
            case 2:
                imagePath = "Sprites/Comic/boss_comic/2/c1";
                Wait_time = 1;
                break;
            case 3:
                imagePath = "Sprites/Comic/boss_comic/2/c2";
                Wait_time = 1;
                break;
            case 4:
                imagePath = "Sprites/Comic/boss_comic/2/c3";
                Wait_time = 1;
                break;
            case 5:
                imagePath = "Sprites/Comic/boss_comic/2/c3-1";
                Wait_time = 0;
                break;
            case 6:
                imagePath = "Sprites/Comic/boss_comic/2/c4";
                Wait_time = 1;
                break;
            case 7:
                imagePath = "Sprites/Comic/boss_comic/2/c5";
                Wait_time = 1;
                break;
            case 8:
                imagePath = "Sprites/Comic/boss_comic/2/c6";
                Wait_time = 1;
                break;
            case 9:
                imagePath = "Sprites/Comic/boss_comic/2/c6-1";
                Wait_time = 0;
                break;
            case 10:
                imagePath = "Sprites/Comic/boss_comic/2/c6-2";
                Wait_time = 0;
                break;
            case 11:
                isTopLayer = false;
                imagePath = "Sprites/Comic/boss_comic/2/c7";
                Wait_time = 1;
                break;
            case 12:
                isTopLayer = true;
                imagePath = "Sprites/Comic/boss_comic/2/c8";
                Wait_time = 1;
                break;
            case 13:
                imagePath = "Sprites/Comic/boss_comic/2/c8-1";
                Wait_time = 0;
                break;
            case 14:
                imagePath = "Sprites/Comic/boss_comic/2/c8-2";
                Wait_time = 0;
                break;
            case 15:
                imagePath = "Sprites/Comic/boss_comic/2/c9";
                Wait_time = 1;
                break;
            case 16:
                imagePath = "Sprites/Comic/boss_comic/2/c10";
                Wait_time = 1;
                break;
            case 17:
                imagePath = "Sprites/Comic/boss_comic/2/c11";
                Wait_time = 1;
                break;
            case 18:
                Wait_time = 2;
                BOSS_comic_END();
                return;
        }
        comic_image_add();
    }

    private void BOSS_comic_END()
    {
        static_parameters.Comic_scene_sort = 0;
        static_parameters.Bookstate = false;
        comic_step = 100;
        DeleteAllImagesUnderCanvas();
        BG_Image.SetActive(false);
        Demo_End.SetActive(true);
        BOSS_comic_END_after(0.25f);
    }
    IEnumerator BOSS_comic_END_after(float time_T)
    {
        yield return new WaitForSeconds(time_T);
        gameObject.SetActive(false);
    }
}
