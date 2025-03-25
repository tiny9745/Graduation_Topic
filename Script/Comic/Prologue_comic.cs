using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Prologue_comic : MonoBehaviour
{
    
    public Canvas canvas; // 需要將新建的 Image 放到的 Canvas
    public GameObject Image_box;
    uint comic_step = 0,comic_step_tmp=0,Wait_time=0;
    float comic_time_sum = 0,auto_comic_time;
    bool isTopLayer = false;
    string imagePath = "Sprites/Comic/Prologue/01/comics_1-1"; // 圖檔在 Resources 中的路徑
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
        if ((Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Mouse0)) && comic_time_sum > 0.8f)
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
                    comic_image_Prologue01();
                    break;
                case 1:
                    comic_image_Prologue02();
                    break;
                case 2:
                    comic_image_Prologue03();
                    break;
                case 3:
                    comic_image_Prologue04();
                    break;
                case 4:
                    comic_image_Prologue05();
                    break;
            }
        }
        else
        {
            switch(Wait_time){//須提前一步
                case 0:
                    auto_comic(2.5f);//換圖時間-無對話框
                    break;
                case 1:
                    auto_comic(1.5f);//換圖時間-對話框
                    break;
                case 2:
                    auto_comic(0.55f);//換圖時間-對話框快
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

            if (isTopLayer)
            {
                newImageObject.transform.SetSiblingIndex(comicTransform.childCount - 1); // 最上層
            }
            else
            {
                newImageObject.transform.SetSiblingIndex(0); // 最底層
            }
            // 呼叫淡入效果
            StartCoroutine(FadeInImage(newImage, 0.4f, 300f));
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

        // 持續時間內逐步增加 alpha
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
    IEnumerator FadeOutImage(Image image, float duration, float moveDistance)
    {
        float elapsedTime = 0f;
        Color newColor = image.color;
        Vector3 originalPosition = image.transform.position; // 儲存初始位置

        // 初始化 alpha 為 1（完全不透明）
        newColor.a = 1f;
        image.color = newColor;

        // 持續時間內逐步減少 alpha
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            // 更新透明度
            newColor.a = 1 - Mathf.Clamp01(elapsedTime / duration);
            image.color = newColor;

            // 更新 Y 軸位置，逐步減少至 moveDistance
            float newXPosition = Mathf.Lerp(originalPosition.y + moveDistance, originalPosition.y, elapsedTime / duration);
            image.transform.position = new Vector3(originalPosition.x, newXPosition, originalPosition.z);

            yield return null; // 等待下一幀
        }

        // 確保最後完全隱藏
        newColor.a = 0f;
        image.color = newColor;

        // 確保 X 軸移動到最終位置
        image.transform.position = originalPosition;
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
                else
                {
                    Debug.LogError("Failed to load image from Resources: " + BG_Path);
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
                
                change_comic_BG("Sprites/Comic/Leading comic/01/comics01_1");
                imagePath = "Sprites/Comic/Leading comic/01/comics01_2";  
                Wait_time = 1; isTopLayer = true;  
                break;
            case 2:               
                imagePath = "Sprites/Comic/Leading comic/01/word box01_1";
                Wait_time = 0;
                break;
            case 3:
                imagePath = "Sprites/Comic/Leading comic/01/comics01_3";
                break;
            case 4:
                imagePath = "Sprites/Comic/Leading comic/01/comics01_4";
                Wait_time = 1;
                break;
            case 5:  
                imagePath = "Sprites/Comic/Leading comic/01/word box01_2";
                Wait_time = 0;
                break;
            case 6:               
                imagePath = "Sprites/Comic/Leading comic/01/comics01_5";
                Wait_time = 1;
                break;
            case 7:
                imagePath = "Sprites/Comic/Leading comic/01/word box01_3";
                Wait_time = 0;
                break;
            case 8:
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
                change_comic_BG("Sprites/Comic/Leading comic/white BG");
                imagePath = "Sprites/Comic/Leading comic/02/comics02_1";
                Wait_time = 1;
                break;
            case 2:               
                imagePath = "Sprites/Comic/Leading comic/02/word box02_1";
                break;
            case 3:
                imagePath = "Sprites/Comic/Leading comic/02/word box02_2";
                Wait_time = 0; 
                break;
            case 4:              
                imagePath = "Sprites/Comic/Leading comic/02/comics02_2";
                isTopLayer = false;
                break;
            case 5:             
                imagePath = "Sprites/Comic/Leading comic/02/comics02_3";
                isTopLayer = true; Wait_time = 1;
                break;
            case 6:            
                imagePath = "Sprites/Comic/Leading comic/02/word box02_3";
                Wait_time = 0;
                break;
            case 7:              
                imagePath = "Sprites/Comic/Leading comic/02/comics02_4";
                Wait_time = 1;
                break;
            case 8:           
                imagePath = "Sprites/Comic/Leading comic/02/word box02_4";
                Wait_time = 0;
                break;
            case 9:               
                imagePath = "Sprites/Comic/Leading comic/02/comics02_5";
                isTopLayer = false; Wait_time = 1; 
                break;
            case 10:               
                imagePath = "Sprites/Comic/Leading comic/02/word box02_5";
                isTopLayer = true;
                break;              
            case 11:
                imagePath = "Sprites/Comic/Leading comic/02/word box02_7";
                Wait_time = 0;
                break;
            case 12:
                static_parameters.Comic_scene_sort++;
                DeleteAllImagesUnderCanvas();
                comic_step = 1;
                return;
        }
        comic_image_add();
    }

    private void comic_image_Prologue03()
    {
        switch (comic_step)
        {
            case 1:
                
                change_comic_BG("Sprites/Comic/Leading comic/white BG");
                imagePath = "Sprites/Comic/Leading comic/03/comics03_1";
                Wait_time = 1;
                break;
            case 2:
                imagePath = "Sprites/Comic/Leading comic/03/word box03_1";
                break;
            case 3:
                imagePath = "Sprites/Comic/Leading comic/03/word box03_2";
                Wait_time = 0;
                break;
            case 4:             
                imagePath = "Sprites/Comic/Leading comic/03/comics03_2";
                break;
            case 5:
                imagePath = "Sprites/Comic/Leading comic/03/comics03_3";
                Wait_time = 1;
                break;
            case 6:
                imagePath = "Sprites/Comic/Leading comic/03/word box03_3";
                Wait_time = 0;
                break;
            case 7:               
                imagePath = "Sprites/Comic/Leading comic/03/comics03_4";
                break;
            case 8:
                imagePath = "Sprites/Comic/Leading comic/03/comics03_5";
                Wait_time = 1;
                break;
            case 9:
                imagePath = "Sprites/Comic/Leading comic/03/word box03_4";
                Wait_time = 0;
                break;
            case 10:               
                imagePath = "Sprites/Comic/Leading comic/03/comics03_6";
                break;
            case 11:
                static_parameters.Comic_scene_sort++;
                DeleteAllImagesUnderCanvas();
                comic_step = 1;
                return;
        }
        comic_image_add();
    }
    private void comic_image_Prologue04()
    {
        switch (comic_step)
        {
            case 1:
                imagePath = "Sprites/Comic/Leading comic/04/comics04_1";
                Wait_time = 1;
                break;
            case 2:
                imagePath = "Sprites/Comic/Leading comic/04/word box04_1";
                break;
            case 3:
                imagePath = "Sprites/Comic/Leading comic/04/word box04_2";
                Wait_time = 0;
                break;
            case 4:
                imagePath = "Sprites/Comic/Leading comic/04/comics04_2";
                Wait_time = 1;
                break;
            case 5:    
                imagePath = "Sprites/Comic/Leading comic/04/word box04_3";
                Wait_time = 0;
                break;
            case 6:       
                imagePath = "Sprites/Comic/Leading comic/04/comics04_3";
                Wait_time = 1;
                break;
            case 7:
                imagePath = "Sprites/Comic/Leading comic/04/word box04_4";
                break;
            case 8:
                imagePath = "Sprites/Comic/Leading comic/04/word box04_5";
                Wait_time = 0;
                break;
            case 9:
                imagePath = "Sprites/Comic/Leading comic/04/comics04_4";
                Wait_time = 1;
                break;
            case 10:
                imagePath = "Sprites/Comic/Leading comic/04/word box04_6";
                Wait_time = 0;
                break;
            case 11: 
                imagePath = "Sprites/Comic/Leading comic/04/comics04_5";
                Wait_time = 1;
                break;
            case 12:
                imagePath = "Sprites/Comic/Leading comic/04/word box04_7";
                break;
            case 13:
                imagePath = "Sprites/Comic/Leading comic/04/word box04_8";
                Wait_time = 0; 
                break;
            case 14:
                imagePath = "Sprites/Comic/Leading comic/04/comics04_6";
                Wait_time = 1; isTopLayer = false;
                break;
            case 15:
                imagePath = "Sprites/Comic/Leading comic/04/word box04_9";
                isTopLayer = true;Wait_time = 0;
                break;
            case 16:
                imagePath = "Sprites/Comic/Leading comic/04/comics04_7";
                Wait_time = 1;
                break;
            case 17:
                imagePath = "Sprites/Comic/Leading comic/04/word box04_10";
                break;
            case 18:
                imagePath = "Sprites/Comic/Leading comic/04/word box04_11";
                break;
            case 19:
                imagePath = "Sprites/Comic/Leading comic/04/word box04_12";
                Wait_time = 2;
                break;
            case 20:
                imagePath = "Sprites/Comic/Leading comic/04/word box04_13";
                break;
            case 21:
                imagePath = "Sprites/Comic/Leading comic/04/word box04_14";
                break;
            case 22:
                imagePath = "Sprites/Comic/Leading comic/04/word box04_15";
                break;
            case 23:
                imagePath = "Sprites/Comic/Leading comic/04/word box04_17";
                Wait_time = 0;
                break;
            case 24:
                imagePath = "Sprites/Comic/Leading comic/04/comics04_8";
                break;
            case 25:
                static_parameters.Comic_scene_sort++;
                DeleteAllImagesUnderCanvas();
                comic_step = 1;
                return;
        }
        comic_image_add();
    }
    private void comic_image_Prologue05()
    {
        switch (comic_step)
        {
            case 1:
                change_comic_BG("Sprites/Comic/Leading comic/black BG");
                imagePath = "Sprites/Comic/Leading comic/05/05";
                break;
            case 10:
                static_parameters.Comic_scene_sort = -1;
                comic_step = 1;
                SceneManager.LoadScene("prohibit");
                return;
        }
        comic_image_add();
    }
}