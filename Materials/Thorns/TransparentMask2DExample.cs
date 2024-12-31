using UnityEngine;

public class TransparentMask2DExample : MonoBehaviour
{
    public Material MaskMaterial;    // 遮罩材質
    public Material MaskedMaterial;  // 被遮罩物件材質
    public Sprite MaskedSprite;      // 被遮罩物件的貼圖

    void Start()
    {
        // 創建遮罩物件
        CreateMask(new Vector3(0, 0, -0.1f), new Vector2(2, 2));

        // 創建被遮罩的物件
        CreateMaskedSprite(new Vector3(0, 0, 0));
    }

    void CreateMaskedSprite(Vector3 position)
    {
        GameObject sprite = new GameObject("MaskedSprite");
        sprite.transform.position = position;

        SpriteRenderer spriteRenderer = sprite.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = MaskedSprite; // 指定貼圖
        spriteRenderer.material = MaskedMaterial; // 使用遮罩專用材質
    }

    void CreateMask(Vector3 position, Vector2 scale)
    {
        GameObject mask = GameObject.CreatePrimitive(PrimitiveType.Quad);
        mask.transform.position = position;
        mask.transform.localScale = new Vector3(scale.x, scale.y, 1);

        Renderer renderer = mask.GetComponent<Renderer>();
        renderer.material = MaskMaterial;

        Destroy(mask.GetComponent<Collider>()); // 移除多餘的碰撞器
    }
}
