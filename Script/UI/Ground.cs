using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    // Start is called before the first frame update
    private SpriteRenderer spriteRenderer;
    private Material quadMaterial;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (quadMaterial == null)
        {
            // 使用 Sprites/Default 着色器
            quadMaterial = new Material(Shader.Find("Sprites/Default"));//無法接收光影
            quadMaterial.mainTexture = spriteRenderer.sprite.texture;

            // 設置材質為透明模式，禁用深度寫入，並設置渲染隊列
            quadMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            quadMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            quadMaterial.SetInt("_ZWrite", 0); // 禁用深度寫入
            quadMaterial.renderQueue = 1999;   // 設置為透明渲染隊列
        }
    }

}
