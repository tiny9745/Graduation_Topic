using UnityEngine;

public class Shadow : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;  // 將您的SpriteRenderer拖放到此處
    public Light sceneLight;  // 將場景中的光源拖放到此處
    private Material spriteMaterial;
    private GameObject quad;
    private Sprite lastSprite;  // 用於檢查當前sprite是否改變

    void Start()
    {
        // 創建一個新的材質
        spriteMaterial = new Material(Shader.Find("Standard"));
        spriteMaterial.SetFloat("_Mode", 3);  // 設置為Transparent模式
        spriteMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        spriteMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        spriteMaterial.SetInt("_ZWrite", 0);
        spriteMaterial.DisableKeyword("_ALPHATEST_ON");
        spriteMaterial.EnableKeyword("_ALPHABLEND_ON");
        spriteMaterial.DisableKeyword("_ALPHAPREMULTIPLY_ON");
        spriteMaterial.renderQueue = 3000;

        // 將Sprite的Texture設置為材質的主紋理
        spriteMaterial.mainTexture = spriteRenderer.sprite.texture;

        // 創建一個Quad並設置其位置和大小
        quad = GameObject.CreatePrimitive(PrimitiveType.Quad);
        quad.transform.position = transform.position;  // 確保與附加元件位置對齊

        // 設置Quad的大小，使其與附加元件的大小一致
        UpdateQuadSize();

        // 將材質應用到Quad上
        quad.GetComponent<Renderer>().material = spriteMaterial;

        // 確保Quad的中心點對齊
        quad.transform.parent = transform;  // 設置父物體以便於對齊
        quad.transform.localPosition = Vector3.zero;  // 重置本地位置以對齊中心

        // 確保光源存在並啟用影子
        if (sceneLight != null)
        {
            sceneLight.shadows = LightShadows.Soft;
        }
        else
        {
            Debug.LogWarning("Scene light not assigned. Please assign a light source in the inspector.");
        }
    }

    void Update()
    {
        // 僅在Sprite改變時更新材質的主紋理和Quad的大小
        if (spriteRenderer.sprite != lastSprite)
        {
            lastSprite = spriteRenderer.sprite;
            spriteMaterial.mainTexture = spriteRenderer.sprite.texture;
            UpdateQuadSize();
        }
    }

    void UpdateQuadSize()
    {
        if (spriteRenderer != null)
        {
            Bounds bounds = spriteRenderer.bounds;
            quad.transform.localScale = new Vector3(bounds.size.x, bounds.size.y, 1);
        }
    }
}
