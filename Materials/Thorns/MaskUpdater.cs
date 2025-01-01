using UnityEngine;

public class MaskUpdater : MonoBehaviour
{
    public GameObject cube; // 指定 Cube 的物件
    public GameObject sprite; // 指定 Sprite 的物件
    public Vector3 cubeSize; // 手動指定 Cube 的大小（如 Cube 的 scale）

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

            // 更新材質的 Cube 中心和大小
            spriteMaterial.SetVector("_CubeCenter", cubeCenter);
            spriteMaterial.SetVector("_CubeSize", cubeSize);
        }
    }
}