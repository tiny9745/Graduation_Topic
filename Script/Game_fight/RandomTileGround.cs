using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTileGround : MonoBehaviour
{
    public Sprite[] sprites; // 拖入4张Sprite图片
    public int tilesX = 7; // 地面网格在X轴上的数量
    public int tilesZ = 7; // 地面网格在Z轴上的数量
    public float tileSize = 1f; // 每个瓦片的大小

    private MeshRenderer meshRenderer;
    private MeshFilter meshFilter;

    void Start()
    {
        meshRenderer = gameObject.AddComponent<MeshRenderer>();
        meshFilter = gameObject.AddComponent<MeshFilter>();

        Mesh mesh = new Mesh();
        Vector3[] vertices = new Vector3[(tilesX + 1) * (tilesZ + 1)];
        Vector2[] uv = new Vector2[(tilesX + 1) * (tilesZ + 1)];
        int[] triangles = new int[tilesX * tilesZ * 6];

        for (int z = 0; z <= tilesZ; z++)
        {
            for (int x = 0; x <= tilesX; x++)
            {
                vertices[z * (tilesX + 1) + x] = new Vector3(x * tileSize, 0, z * tileSize);
                uv[z * (tilesX + 1) + x] = new Vector2((float)x / tilesX, (float)z / tilesZ);
            }
        }

        for (int z = 0; z < tilesZ; z++)
        {
            for (int x = 0; x < tilesX; x++)
            {
                int start = z * (tilesX + 1) + x;
                int offset = (z * tilesX + x) * 6;

                triangles[offset] = start;
                triangles[offset + 1] = start + tilesX + 1;
                triangles[offset + 2] = start + 1;
                triangles[offset + 3] = start + 1;
                triangles[offset + 4] = start + tilesX + 1;
                triangles[offset + 5] = start + tilesX + 2;
            }
        }

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
        meshFilter.mesh = mesh;

        ApplyRandomSprites();
    }

    void ApplyRandomSprites()
    {
        Texture2D texture = new Texture2D(tilesX, tilesZ);
        for (int z = 0; z < tilesZ; z++)
        {
            for (int x = 0; x < tilesX; x++)
            {
                Sprite sprite = sprites[Random.Range(0, sprites.Length)];
                Color[] pixels = sprite.texture.GetPixels(
                    (int)sprite.textureRect.x,
                    (int)sprite.textureRect.y,
                    (int)sprite.textureRect.width,
                    (int)sprite.textureRect.height
                );

                texture.SetPixels(x * (int)sprite.textureRect.width, z * (int)sprite.textureRect.height, (int)sprite.textureRect.width, (int)sprite.textureRect.height, pixels);
            }
        }

        texture.Apply();
        meshRenderer.material = new Material(Shader.Find("Standard"));
        meshRenderer.material.mainTexture = texture;
    }
}
