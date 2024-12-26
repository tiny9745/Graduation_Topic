using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteToQuad : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;  // 把你的 SpriteRenderer 拖放到此處

    private GameObject quad;
    private Material quadMaterial;  // 儲存材質以避免重複創建

    void Start()
    {
        // 取得 Sprite 的尺寸
        Vector2 spriteSize = spriteRenderer.sprite.bounds.size;

        // 創建一個新的 Quad 物件（只在第一次啟動時創建一次）
        if (quad == null)
        {
            CreateQuad(spriteSize);
        }

        // 調整 Quad 的位置和旋轉
        UpdateQuadPosition();

        // 刪除原始的物件，確保 Quad 保持存在
        Destroy(gameObject);  // 刪除當前物件（SpriteRenderer 所在的物件）
    }

    // 創建 Quad 物件並設定其屬性
    void CreateQuad(Vector2 spriteSize)
    {
        // 創建 Quad 物件
        quad = GameObject.CreatePrimitive(PrimitiveType.Quad);

        // 確保材質只有一次創建
        if (quadMaterial == null)
        {
            quadMaterial = new Material(Shader.Find("Standard"));
            quadMaterial.mainTexture = spriteRenderer.sprite.texture;

            // 設置材質為透明渲染模式，並設置渲染順序和深度屬性
            quadMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            quadMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            quadMaterial.SetInt("_ZWrite", 0); // 禁用深度寫入
            quadMaterial.renderQueue = 3000;   // 設置為透明渲染隊列
        }

        // 設置 Quad 的初始屬性
        quad.GetComponent<Renderer>().material = quadMaterial;

        // 設置 Quad 的大小與 Sprite 相同，並確保不受父物件的縮放影響
        Vector3 lossyScale = transform.lossyScale;
        quad.transform.localScale = new Vector3(spriteSize.x * lossyScale.x, spriteSize.y * lossyScale.y, 1);

        // 啟用陰影投射和接收（可選）
        MeshRenderer quadRenderer = quad.GetComponent<MeshRenderer>();
        quadRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        quadRenderer.receiveShadows = false;

        // 把 Quad 移到場景根層級，確保不被刪除
        quad.transform.parent = null;
    }

    // 更新 Quad 物件的位置與旋轉
    void UpdateQuadPosition()
    {
        // 調整位置以確保 Quad 在最下層
        Vector3 adjustedPosition = transform.position;
        adjustedPosition.z = Mathf.Min(adjustedPosition.z, -1000); // 確保 z 軸足夠遠
        quad.transform.position = adjustedPosition;

        // 設置 Quad 與 Sprite 相同的旋轉角度
        quad.transform.rotation = transform.rotation;
    }
}
