using UnityEngine;
using static UnityEditor.Progress;
using UnityEngine.UI;

public class Shadow : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;  // 将您的 SpriteRenderer 拖放到此处
    public Light sceneLight;  // 将场景中的光源拖放到此处
    private Material spriteMaterial;
    private GameObject quad;
    private Sprite lastSprite;  // 用于检查当前 sprite 是否改变

    void Start()
    {
        // 创建一个新的材质
        sceneLight = GameObject.Find("Directional Light")?.GetComponent<Light>();
        spriteMaterial = new Material(Shader.Find("Standard"));
        spriteMaterial.SetFloat("_Mode", 3);  // 设置为 Transparent 模式
        spriteMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        spriteMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        spriteMaterial.SetInt("_ZWrite", 0);
        spriteMaterial.DisableKeyword("_ALPHATEST_ON");
        spriteMaterial.EnableKeyword("_ALPHABLEND_ON");
        spriteMaterial.DisableKeyword("_ALPHAPREMULTIPLY_ON");
        spriteMaterial.renderQueue = 3000;
        // 将 Sprite 的 Texture 设置为材质的主纹理
        spriteMaterial.mainTexture = spriteRenderer.sprite.texture;
        // 创建一个 Quad 并设置其位置和大小
        quad = GameObject.CreatePrimitive(PrimitiveType.Quad);
        quad.transform.position = transform.position;  // 确保与附加组件位置对齐
        // 移除 Quad 上的 Rigidbody 组件
        Destroy(quad.GetComponent<Rigidbody>());
        // 移除 Quad 上的 MeshCollider 组件
        Destroy(quad.GetComponent<MeshCollider>());
        // 设置 Quad 的大小，使其与附加组件的大小一致
        UpdateQuadSize();
        // 将材质应用到 Quad 上
        quad.GetComponent<Renderer>().material = spriteMaterial;
        // 设置阴影模式为产生阴影但不接收阴影
        quad.GetComponent<Renderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
        quad.GetComponent<Renderer>().receiveShadows = true;
        // 确保 Quad 的中心点对齐
        quad.transform.parent = transform; 
        quad.transform.localPosition = Vector3.zero;
        // 确保光源存在并启用阴影
        if (sceneLight != null)
        {
            sceneLight.shadows = LightShadows.Soft;
        }
        else
        {
            Debug.LogWarning("Scene light not assigned. Please assign a light source in the inspector.");
        }
        RectTransform rectTransform = quad.GetComponent<RectTransform>();
        Transform quadTransform = quad.GetComponent<Transform>();
        if (quadTransform != null)
        {
            Vector3 newPosition = quadTransform.localPosition;
            newPosition.z = 0.05f; // Set the Z position
            quadTransform.localPosition = newPosition;
        }
    }

    void Update()
    {
        // 仅在 Sprite 改变时更新材质的主纹理和 Quad 的大小
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
            // 获取 Sprite 的 bounds 大小
            Bounds bounds = spriteRenderer.bounds;
            // 设置 Quad 的大小，使其与 Sprite 的大小一致
            quad.transform.localScale = new Vector3(bounds.size.x, bounds.size.y, 1);
        }
    }
}
