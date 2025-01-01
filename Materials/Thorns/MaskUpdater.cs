using UnityEngine;

public class CubeMaskController : MonoBehaviour
{
    public GameObject cube;   // 指定 Cube 的物件
    public GameObject sprite; // 指定 Sprite 的物件

    private Material spriteMaterial;

    void Start()
    {
        if (sprite != null)
        {
            // 獲取 Sprite 的材質
            SpriteRenderer spriteRenderer = sprite.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteMaterial = spriteRenderer.material;
            }
        }
    }

    void Update()
    {
        if (cube != null && spriteMaterial != null)
        {
            // 獲取 Cube 的世界中心點
            Vector3 cubeCenter = cube.transform.position;

            // 獲取 Cube 的世界大小 (依賴 lossyScale)
            Vector3 cubeSize = cube.transform.lossyScale;

            // 更新材質的 Cube 中心和大小
            spriteMaterial.SetVector("_CubeCenter", cubeCenter);
            spriteMaterial.SetVector("_CubeSize", cubeSize);
        }
    }
}
