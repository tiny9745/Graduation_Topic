using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteToQuad : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;  // 把你的 SpriteRenderer 拖放到此處

    private GameObject quad;

    void Start()
    {
        // 取得 Sprite 的尺寸
        Vector2 spriteSize = spriteRenderer.sprite.bounds.size;

        // 創建一個新的 Quad
        quad = GameObject.CreatePrimitive(PrimitiveType.Quad);
        Vector3 adjustedPosition = transform.position;
        adjustedPosition.y += 0.1f;
        quad.transform.position = adjustedPosition;
        quad.transform.rotation = transform.rotation;  // 設置與 Sprite 一致的旋轉

        // 確保 Quad 的大小不受父物件縮放的影響
        Vector3 lossyScale = transform.lossyScale;
        quad.transform.localScale = new Vector3(spriteSize.x * lossyScale.x, spriteSize.y * lossyScale.y, 1);

        // 取得 Quad 的材質並設定與 Sprite 相同的材質
        Material material = new Material(Shader.Find("Standard"));
        material.mainTexture = spriteRenderer.sprite.texture;
        quad.GetComponent<Renderer>().material = material;

        // 設置 Quad 以支援光線和陰影
        MeshRenderer quadRenderer = quad.GetComponent<MeshRenderer>();
        quadRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On; // 開啟投射陰影
        quadRenderer.receiveShadows = true; // 開啟接收陰影

        // 將 Quad 設置為 Sprite 的子物件，但保持與父物件無關的縮放
        quad.transform.parent = transform;
    }
}
