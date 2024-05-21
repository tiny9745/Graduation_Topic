using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RandomTileGround : MonoBehaviour
{
    public Sprite[] sprites; // 四张 sprite 图片
    public int tilesX = 10; // X 轴上的瓦片数量
    public int tilesZ = 10; // Z 轴上的瓦片数量
    public float tileSize = 1.0f; // 每个瓦片的大小

    void Start()
    {
        // 确保所有纹理都是可读的
        MakeTexturesReadable();

        // 创建一个新的 GameObject 作为地面
        GameObject ground = new GameObject("Ground");
        MeshRenderer meshRenderer = ground.AddComponent<MeshRenderer>();
        MeshFilter meshFilter = ground.AddComponent<MeshFilter>();

        // 创建一个新的 mesh
        Mesh mesh = new Mesh();

        // 计算顶点、UV 和三角形
        Vector3[] vertices = new Vector3[tilesX * tilesZ * 4];
        Vector2[] uvs = new Vector2[tilesX * tilesZ * 4];
        int[] triangles = new int[tilesX * tilesZ * 6];

        int vertIndex = 0;
        int triIndex = 0;
        for (int x = 0; x < tilesX; x++)
        {
            for (int z = 0; z < tilesZ; z++)
            {
                // 计算瓦片位置
                float xPos = x * tileSize;
                float zPos = z * tileSize;

                // 分配每个瓦片的顶点
                vertices[vertIndex + 0] = new Vector3(xPos, 0, zPos);
                vertices[vertIndex + 1] = new Vector3(xPos + tileSize, 0, zPos);
                vertices[vertIndex + 2] = new Vector3(xPos, 0, zPos + tileSize);
                vertices[vertIndex + 3] = new Vector3(xPos + tileSize, 0, zPos + tileSize);

                // 随机选择一个 sprite
                int randomIndex = Random.Range(0, sprites.Length);
                Sprite sprite = sprites[randomIndex];
                Debug.Log($"Tile ({x}, {z}) uses sprite index: {randomIndex}"); // 调试日志

                Rect rect = sprite.rect;
                Vector2[] spriteUVs = new Vector2[4];
                spriteUVs[0] = new Vector2(rect.xMin / sprite.texture.width, rect.yMin / sprite.texture.height);
                spriteUVs[1] = new Vector2(rect.xMax / sprite.texture.width, rect.yMin / sprite.texture.height);
                spriteUVs[2] = new Vector2(rect.xMin / sprite.texture.width, rect.yMax / sprite.texture.height);
                spriteUVs[3] = new Vector2(rect.xMax / sprite.texture.width, rect.yMax / sprite.texture.height);

                // 分配每个瓦片的 UVs
                uvs[vertIndex + 0] = spriteUVs[0];
                uvs[vertIndex + 1] = spriteUVs[1];
                uvs[vertIndex + 2] = spriteUVs[2];
                uvs[vertIndex + 3] = spriteUVs[3];

                // 分配每个瓦片的三角形
                triangles[triIndex + 0] = vertIndex + 0;
                triangles[triIndex + 1] = vertIndex + 2;
                triangles[triIndex + 2] = vertIndex + 1;
                triangles[triIndex + 3] = vertIndex + 1;
                triangles[triIndex + 4] = vertIndex + 2;
                triangles[triIndex + 5] = vertIndex + 3;

                vertIndex += 4;
                triIndex += 6;
            }
        }

        // 将顶点、UV 和三角形应用到 mesh 上
        mesh.vertices = vertices;
        mesh.uv = uvs;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        // 将 mesh 分配给 MeshFilter 和 MeshRenderer
        meshFilter.mesh = mesh;

        // 创建并分配一个材质
        Material material = new Material(Shader.Find("Sprites/Default"));

        // 创建一个纹理，结合所有 sprite 纹理
        Texture2D combinedTexture = new Texture2D(1, 1); // 临时大小，将稍后调整大小
        List<Texture2D> textures = new List<Texture2D>();
        foreach (Sprite sprite in sprites)
        {
            textures.Add(sprite.texture);
        }
        combinedTexture.PackTextures(textures.ToArray(), 0, 4096); // 调整最大大小

        material.mainTexture = combinedTexture; // 使用合并的纹理
        meshRenderer.material = material;
    }

    void MakeTexturesReadable()
    {
#if UNITY_EDITOR
        foreach (Sprite sprite in sprites)
        {
            Texture2D texture = sprite.texture;
            string assetPath = UnityEditor.AssetDatabase.GetAssetPath(texture);
            TextureImporter importer = UnityEditor.AssetImporter.GetAtPath(assetPath) as TextureImporter;

            if (importer != null)
            {
                importer.isReadable = true;
                UnityEditor.AssetDatabase.ImportAsset(assetPath);
            }
        }
        UnityEditor.AssetDatabase.Refresh();
#endif
    }
}

public class MakeTexturesReadable : MonoBehaviour
{
    public Texture2D[] textures; // 在此分配您的 sprite 纹理

    void Start()
    {
        MakeTexturesReadableMethod();
    }

    void MakeTexturesReadableMethod()
    {
#if UNITY_EDITOR
        foreach (Texture2D texture in textures)
        {
            string assetPath = AssetDatabase.GetAssetPath(texture);
            TextureImporter importer = AssetImporter.GetAtPath(assetPath) as TextureImporter;

            if (importer != null)
            {
                importer.isReadable = true;
                AssetDatabase.ImportAsset(assetPath);
            }
        }
        AssetDatabase.Refresh();
#endif
    }
}
